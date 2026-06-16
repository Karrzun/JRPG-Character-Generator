using System.IO;
using UnityEngine;

public static class LLMServerData 
{
    public const string ServerFile = "llama-server.exe";
    public const string ModelFile = "mistral-7b-instruct-v0.2.Q4_K_M.gguf";

    public static string ServerDirectory => Path.Combine(Application.streamingAssetsPath, "LLM", "server");
    public static string ModelDirectory => Path.Combine(Application.streamingAssetsPath, "LLM", "models");

    public static string ServerPath => Path.Combine(ServerDirectory, ServerFile);
    public static string ModelPath => Path.Combine(ModelDirectory, ModelFile);


    // Parameters
    public const int PortNumber = 8080;
    public static string ServerURL => $"http://localhost:{PortNumber}";

    public static int GpuLayers => 33;
    public static int GpuMemoryMB = SystemInfo.graphicsMemorySize;
    public static int ContextSize => Mathf.Clamp(GpuMemoryMB / 2, 2048, 32768);

    public static string Parameters => $"--port {PortNumber} --device CUDA0 --gpu-layers {GpuLayers} --ctx-size {ContextSize}";
}