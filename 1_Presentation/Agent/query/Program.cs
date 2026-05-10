using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Alis.App.Query;

public sealed class QueryService
{
    private readonly HttpClient _httpClient;

    private const string OllamaEndpoint = "http://localhost:11434";
    private const string QdrantEndpoint = "http://localhost:6333";

    private const string EmbeddingModel = "nomic-embed-text";
    private const string ChatModel = "qwen3.5:27b-coding-nvfp4";

    private const string CollectionName = "repo_chunks";

    public QueryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // =====================================================
    // PUBLIC API
    // =====================================================
    public async Task<string> AskAsync(string question, int topK = 8)
    {
        LogHeader(question);

        string rewritten = RewriteQuery(question);

        var embedding = await GetEmbeddingAsync(rewritten);

        var results = await SearchAsync(embedding, topK);

        LogResults(results);

        string context = BuildContext(results);

        return await AskLLMAsync(question, context);
    }

    // =====================================================
    // QUERY REWRITE (INTENT FIX)
    // =====================================================
    private static string RewriteQuery(string q)
    {
        q = q.ToLowerInvariant();

        if (q.Contains("init") || q.Contains("initialize"))
            return q + " constructor factory DI registration LoggerFactory";

        if (q.Contains("logger"))
            return q + " initialization setup creation bootstrap";

        return q;
    }

    // =====================================================
    // EMBEDDING
    // =====================================================
    private async Task<float[]> GetEmbeddingAsync(string text)
    {
        var payload = new
        {
            model = EmbeddingModel,
            prompt = text
        };

        var response = await _httpClient.PostAsJsonAsync(
            $"{OllamaEndpoint}/api/embeddings",
            payload);

        string raw = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Embedding error:\n{raw}");

        using var json = JsonDocument.Parse(raw);

        if (!json.RootElement.TryGetProperty("embedding", out var emb))
            throw new Exception("Embedding field missing");

        var list = new List<float>();

        foreach (var v in emb.EnumerateArray())
            list.Add(v.GetSingle());

        return list.ToArray();
    }

    // =====================================================
    // QDRANT SEARCH (FULL ROBUST PARSER)
    // =====================================================
    private async Task<List<SearchResult>> SearchAsync(float[] embedding, int topK)
    {
        var payload = new
        {
            vector = embedding,
            limit = topK,
            with_payload = true
        };

        var response = await _httpClient.PostAsJsonAsync(
            $"{QdrantEndpoint}/collections/{CollectionName}/points/search",
            payload);

        string raw = await response.Content.ReadAsStringAsync();

        LogRawQdrant(raw);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Qdrant HTTP error:\n{raw}");

        using var json = JsonDocument.Parse(raw);
        var root = json.RootElement;

        if (!root.TryGetProperty("result", out var result))
            return new List<SearchResult>();

        JsonElement points;

        // CASE 1: direct array
        if (result.ValueKind == JsonValueKind.Array)
        {
            points = result;
        }
        // CASE 2: object wrapper
        else if (result.ValueKind == JsonValueKind.Object)
        {
            if (result.TryGetProperty("points", out var p))
                points = p;
            else
                return new List<SearchResult>();
        }
        else
        {
            return new List<SearchResult>();
        }

        return ParsePoints(points);
    }

    // =====================================================
    // PARSER
    // =====================================================
    private List<SearchResult> ParsePoints(JsonElement array)
    {
        var results = new List<SearchResult>();

        foreach (var item in array.EnumerateArray())
        {
            try
            {
                if (!item.TryGetProperty("payload", out var payload))
                    continue;

                results.Add(new SearchResult
                {
                    Score = item.TryGetProperty("score", out var s) ? s.GetDouble() : 0,

                    File = Safe(payload, "file"),
                    Content = Safe(payload, "content"),

                    ChunkIndex = SafeInt(payload, "chunkIndex"),
                    StartLine = SafeInt(payload, "startLine"),
                    EndLine = SafeInt(payload, "endLine")
                });
            }
            catch
            {
                // ignore broken chunks
            }
        }

        return results;
    }

    // =====================================================
    // LLM
    // =====================================================
    private async Task<string> AskLLMAsync(string question, string context)
    {
        var payload = new
        {
            model = ChatModel,
            stream = false,
            messages = new object[]
            {
                new
                {
                    role = "system",
                    content =
@"You are a senior C# architect analyzing a large codebase.

IMPORTANT:
- Distinguish initialization vs usage
- Prefer constructors, factories, DI setup
- Do NOT assume logging calls are initialization"
                },
                new
                {
                    role = "user",
                    content =
$@"QUESTION:
{question}

CONTEXT:
{context}"
                }
            }
        };

        var response = await _httpClient.PostAsJsonAsync(
            $"{OllamaEndpoint}/api/chat",
            payload);

        string raw = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"LLM error:\n{raw}");

        using var json = JsonDocument.Parse(raw);

        return json.RootElement
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? "";
    }

    // =====================================================
    // CONTEXT
    // =====================================================
    private static string BuildContext(List<SearchResult> results)
    {
        var sb = new StringBuilder();

        foreach (var r in results)
        {
            sb.AppendLine("========================================");
            sb.AppendLine($"FILE: {r.File}");
            sb.AppendLine($"LINES: {r.StartLine}-{r.EndLine}");
            sb.AppendLine($"SCORE: {r.Score:F4}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(r.Content);
            sb.AppendLine();
        }

        return sb.ToString();
    }

    // =====================================================
    // LOGGING
    // =====================================================
    private static void LogHeader(string question)
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("🔎 QUERY");
        Console.WriteLine("========================================\n");
        Console.WriteLine($"▶ Question: {question}\n");
    }

    private static void LogResults(List<SearchResult> results)
    {
        Console.WriteLine("\n▶ MATCHES");

        foreach (var r in results)
            Console.WriteLine($"📄 {r.File} | {r.Score:F4}");

        Console.WriteLine();
    }

    private static void LogRawQdrant(string raw)
    {
        Console.WriteLine("\n▶ QDRANT RAW RESPONSE:");
        Console.WriteLine(raw);
    }

    // =====================================================
    // SAFE HELPERS
    // =====================================================
    private static string Safe(JsonElement el, string key)
        => el.TryGetProperty(key, out var v) ? v.GetString() ?? "" : "";

    private static int SafeInt(JsonElement el, string key)
        => el.TryGetProperty(key, out var v) ? v.GetInt32() : 0;
}

// =====================================================
// MODEL
// =====================================================
public sealed class SearchResult
{
    public double Score { get; init; }
    public string File { get; init; } = "";
    public string Content { get; init; } = "";
    public int ChunkIndex { get; init; }
    public int StartLine { get; init; }
    public int EndLine { get; init; }
}

// =====================================================
// PROGRAM LOOP
// =====================================================
public static class Program
{
    public static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🚀 ALIS QUERY AGENT\n");

        using var http = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(10)
        };

        var agent = new QueryService(http);

        while (true)
        {
            Console.Write("❯ ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            try
            {
                var result = await agent.AskAsync(input);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(result);
                Console.ResetColor();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}