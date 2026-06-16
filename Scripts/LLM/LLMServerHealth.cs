using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UnityEngine;

public static class LLMServerHealth
{
    public class HealthStatus
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    private static readonly HttpClient client = new HttpClient();

    public static async Task<bool> WaitUntilReadyAsync(int retryDelayMs = 500)
    {
        while (true)
        {
            try
            {
                var resp = await client.GetAsync($"{LLMServerData.ServerURL}/health");
                if (resp.IsSuccessStatusCode)
                {
                    string json = await resp.Content.ReadAsStringAsync();
                    var hs = JsonSerializer.Deserialize<HealthStatus>(json);
                    if (hs.status == "READY")
                        return true;
                    Debug.Log($"Model loading… status={hs.status}");
                }
                else
                {
                    Debug.LogWarning($"Health check failed: {resp.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Debug.Log($"Waiting for server… {e.Message}");
            }

            await Task.Delay(retryDelayMs);
        }
    }

    public static async Task<string> GetServerHealth()
    {
        try
        {
            var resp = await client.GetAsync($"{LLMServerData.ServerURL}/health");
            if (resp.IsSuccessStatusCode)
            {
                string json = await resp.Content.ReadAsStringAsync();
                var hs = JsonSerializer.Deserialize<HealthStatus>(json);
                return hs.status;
            }
            else
            {
                Debug.LogWarning($"Health check failed: {resp.StatusCode}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.Log($"Waiting for server… {e.Message}");
        }

        return null;
    }

}