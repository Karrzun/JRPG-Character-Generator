using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;


public class LLMServerLauncher : MonoBehaviour
{
    public static TaskCompletionSource<bool> ServerReady => serverReadySource;
    private static TaskCompletionSource<bool> serverReadySource = new TaskCompletionSource<bool>();

    private Process serverProcess;


    void Start()
    {
        UnityEngine.Debug.Log("LLMServerLauncher::Start");

        if (SeanWelton.GameSettings.Settings.Gameplay.UseAiDescriptions == false)
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);
        LaunchServer();
    }

    private void LaunchServer()
    {
        if (!File.Exists(LLMServerData.ServerPath))
        {
            UnityEngine.Debug.LogError("Llama server executable not found at: " + LLMServerData.ServerPath);
            serverReadySource.TrySetResult(false);
            return;
        }

        if (!File.Exists(LLMServerData.ModelPath))
        {
            UnityEngine.Debug.LogError("Model file not found at: " + LLMServerData.ModelPath);
            serverReadySource.TrySetResult(false);
            return;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = LLMServerData.ServerPath,
            Arguments = $"-m \"{LLMServerData.ModelPath}\" {LLMServerData.Parameters}",
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            WorkingDirectory = Path.GetDirectoryName(LLMServerData.ServerDirectory)
        };

        serverProcess = new Process { StartInfo = startInfo };
        
        try
        {
            serverProcess.OutputDataReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                    UnityEngine.Debug.Log("[LLM SERVER] Out: " + args.Data);
            };

            serverProcess.ErrorDataReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    UnityEngine.Debug.Log("[LLM SERVER] Err: " + args.Data);
                    if (args.Data.Contains("main: model loaded"))
                    {
                        UnityEngine.Debug.Log("[LLM SERVER] Started");
                        serverReadySource.TrySetResult(true);
                    }
                }
            };

            serverProcess.Start();

            serverProcess.BeginOutputReadLine();
            serverProcess.BeginErrorReadLine();

            _ = WaitForServerReadyAsync();
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError($"[LLM Server] Failed to launch: {ex.Message}");
            serverReadySource.TrySetException(ex);
        }
    }

    private async Task WaitForServerReadyAsync()
    {
        bool isReady = await LLMServerHealth.WaitUntilReadyAsync();

        if (isReady)
        {
            UnityEngine.Debug.Log("[LLM SERVER] Ready");
            serverReadySource.TrySetResult(true);
        }
        else
        {
            UnityEngine.Debug.LogError("[LLM SERVER] Failed to become ready.");
            serverReadySource.TrySetResult(false);
        }
    }

    private void OnApplicationQuit()
    {
        if (serverProcess == null)
        {
            UnityEngine.Debug.LogWarning("[LLM SERVER] Process was null on quit.");
            return;
        }

        if (serverProcess.HasExited)
        {
            UnityEngine.Debug.LogWarning("[LLM SERVER] Process already exited on quit.");
            return;
        }

        serverReadySource.TrySetResult(false);
        serverProcess.Kill();
        serverProcess.Dispose();
        UnityEngine.Debug.Log("[LLM SERVER] Shut down");
    }

}