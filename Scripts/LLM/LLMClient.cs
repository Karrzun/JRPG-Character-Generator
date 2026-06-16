using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UnityEngine;


public class LLMClient : MonoBehaviour
{
    [SerializeField] private int maxTokens = 200;
    [SerializeField, Range(0, 2)] private float temperature = 0.75f;
    [SerializeField, Range(0, 1)] private float topP = 0.85f;

    private static readonly HttpClient client = new HttpClient();

    private const string initString =
        "You are a narrative designer for a medieval Japanese roguelike game. Assume the player knows the setting - do not mention it explicitly (e.g., avoid phrases like \"In medieval Japan\"). Generate a realistic (no magic) character backstory in 80 to 100 words in simple present.";

    private Stopwatch stopwatch;

    private void Start()
    {
        UnityEngine.Debug.Log("LLMClient::Start");
    }


    private void OnEnable() => CharacterGenerator.OnCharactersCreated += CreateDescriptions;
    private void OnDisable() => CharacterGenerator.OnCharactersCreated -= CreateDescriptions;

    public async void SendMessageToServer(string message)
    {
        PromptRequest request = new PromptRequest
        {
            Model = "mistral-7b-instruct-v0.2.Q4_K_M",
            Prompt = $"[INST] {message} [/INST]",
            Max_tokens = 20,
            Temperature = 0.0f,
            Top_P = 0.7f,
            Stop = new[] { "</s>" },
        };
        
        await GetResponseAsync(request);
    }


    private async void CreateDescriptions(List<Character> characters)
    {
        foreach (Character character in characters)
        {
            string aiResult = await GenerateDescriptionAsync(CharacterPromptBuilder.BuildPrompt(character));
            character.SetDescription(aiResult);
        }
    }

    private async Task<string> GenerateDescriptionAsync(string prompt)
    {
        PromptRequest request = new PromptRequest
        {
            Model = "mistral-7b-instruct-v0.2.Q4_K_M",
            Prompt = $"[INST] {initString} {prompt} [/INST]",
            Max_tokens = maxTokens,
            Temperature = temperature,
            Top_P = topP,
            Stop = new[] { "</s>" },
        };

        string response = await GetResponseAsync(request);
        return response;
    }

    private async Task<string> GetResponseAsync(PromptRequest request)
    {
        try
        {
            bool serverReady = await LLMServerLauncher.ServerReady.Task;
            if (!serverReady)
            {
                UnityEngine.Debug.LogError("[LLM CLIENT] Server failed to start.");
                return string.Empty;
            }
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError($"[LLM CLIENT] Server not available: {ex.Message}");
            return string.Empty;
        }

        try
        {
            stopwatch = Stopwatch.StartNew();
            string json = JsonSerializer.Serialize(request);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{LLMServerData.ServerURL}/v1/completions", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            CompletionResponse completion = JsonSerializer.Deserialize<CompletionResponse>(responseBody);
            stopwatch.Stop();
            if (completion?.Choices != null && completion.Choices.Length > 0)
            {
                string result = completion.Choices[0].Text?.Trim();
                //UnityEngine.Debug.Log($"[LLM CLIENT] Finished in {stopwatch.Elapsed.TotalSeconds:F2} sec. (Finish reason: {completion.Choices[0].FinishReason})\n{result}");
                return result;
            }
            else
            {
                UnityEngine.Debug.LogWarning("[LLM CLIENT] No choices returned.");
            }
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError($"[LLM CLIENT] Error: {ex.Message}");
        }

        return string.Empty;
    }

    [System.Serializable]
    private class PromptRequest
    {
        [JsonPropertyName("model")] public string Model { get; set; }
        [JsonPropertyName("prompt")] public string Prompt { get; set; }
        [JsonPropertyName("max_tokens")] public int Max_tokens { get; set; }
        [JsonPropertyName("temperature")] public float Temperature { get; set; }
        [JsonPropertyName("top_p")] public float Top_P { get; set; }
        [JsonPropertyName("stop")] public string[] Stop { get; set; }
    }

    [System.Serializable]
    public class CompletionChoice
    {
        [JsonPropertyName("text")] public string Text { get; set; }
        [JsonPropertyName("index")] public int Index { get; set; }
        [JsonPropertyName("finish_reason")] public string FinishReason { get; set; }
    }

    [System.Serializable]
    public class CompletionResponse
    {
        [JsonPropertyName("choices")] public CompletionChoice[] Choices { get; set; }
    }

}