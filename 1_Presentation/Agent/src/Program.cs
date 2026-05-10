using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Alis.App.Agent
{
    /// <summary>
    /// The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The http client
        /// </summary>
        private static readonly HttpClient http = new HttpClient();

        /// <summary>
        /// The ollama url
        /// </summary>
        private const string OllamaUrl = "http://localhost:11434/api/embeddings";
        /// <summary>
        /// The qdrant base
        /// </summary>
        private const string QdrantBase = "http://localhost:6333";
        /// <summary>
        /// The collection
        /// </summary>
        private const string Collection = "repo_chunks";

        /// <summary>
        /// The global file index
        /// </summary>
        private static int globalFileIndex = 0;
        /// <summary>
        /// The global file count
        /// </summary>
        private static int globalFileCount = 0;

        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static async Task Main(string[] args)
        {
            Console.Clear();
            PrintHeader();

            if (!await ValidateEnvironment())
            {
                Console.WriteLine("\n❌ SYSTEM NOT READY");
                return;
            }

            string repoPath = "/Users/pabllopf/Repositorios/Alis/";

            if (!Directory.Exists(repoPath))
            {
                Console.WriteLine("❌ Repo not found");
                return;
            }

            var files = Directory.GetFiles(repoPath, "*.cs", SearchOption.AllDirectories);
            globalFileCount = files.Length;

            Console.WriteLine($"\n📦 Files detected: {globalFileCount}");
            Console.WriteLine("\n▶ STARTING INDEXING...\n");

            foreach (var file in files)
            {
                globalFileIndex++;

                await ProcessFile(file, globalFileIndex, globalFileCount);
            }

            Console.WriteLine("\n\n🎉 DONE - INDEXING COMPLETE");
        }

        // ============================================================
        // FILE PROCESSING
        // ============================================================
        /// <summary>
        /// Processes the file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="index">The index</param>
        /// <param name="total">The total</param>
        private static async Task ProcessFile(string file, int index, int total)
        {
            Console.WriteLine($"\n▶ FILE [{index}/{total}]");
            Console.WriteLine($"   ℹ {file}");

            string code = await File.ReadAllTextAsync(file);

            if (string.IsNullOrWhiteSpace(code))
            {
                Console.WriteLine("   ⚠ Empty file skipped");
                return;
            }

            var chunks = SplitCode(code);

            Console.WriteLine($"   ℹ Chunks: {chunks.Count}");

            int chunkIndex = 0;

            foreach (var chunk in chunks)
            {
                chunkIndex++;

                UpdateChunkProgress(chunkIndex, chunks.Count);

                var embedding = await GetEmbedding(chunk);

                if (embedding == null || embedding.Length == 0)
                {
                    Console.WriteLine("\n   ❌ embedding failed");
                    continue;
                }

                await StoreChunk(file, chunk, embedding);
            }

            Console.WriteLine(); // newline after file
        }

        // ============================================================
        // LIVE UI (IMPORTANT PART)
        // ============================================================
        /// <summary>
        /// Updates the chunk progress using the specified current
        /// </summary>
        /// <param name="current">The current</param>
        /// <param name="total">The total</param>
        private static void UpdateChunkProgress(int current, int total)
        {
            Console.Write($"\r   ℹ Store chunk {current}/{total}   ");
        }

        /// <summary>
        /// Prints the header
        /// </summary>
        private static void PrintHeader()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("🚀 CODE INDEXER AGENT");
            Console.WriteLine("========================================\n");
        }

        // ============================================================
        // ENV VALIDATION
        // ============================================================
        /// <summary>
        /// Validates the environment
        /// </summary>
        /// <returns>A task containing the bool</returns>
        private static async Task<bool> ValidateEnvironment()
        {
            Console.WriteLine("▶ ENV CHECK");

            Console.WriteLine("   ℹ Checking Ollama...");
            bool ollama = await CheckOllama();

            Console.WriteLine("   ℹ Checking Qdrant...");
            bool qdrant = await CheckQdrant();

            if (!ollama || !qdrant)
            {
                Console.WriteLine("\n❌ ENV FAILED");
                return false;
            }

            Console.WriteLine("▶ COLLECTION");

            await EnsureCollection();

            Console.WriteLine("   ✔ Environment ready");

            return true;
        }

        // ============================================================
        // OLLAMA
        // ============================================================
        /// <summary>
        /// Checks the ollama
        /// </summary>
        /// <returns>A task containing the bool</returns>
        private static async Task<bool> CheckOllama()
        {
            try
            {
                var res = await http.PostAsJsonAsync(OllamaUrl, new
                {
                    model = "nomic-embed-text",
                    prompt = "ping"
                });

                Console.WriteLine(res.IsSuccessStatusCode ? "   ✔ Ollama OK" : "   ❌ Ollama FAIL");
                return res.IsSuccessStatusCode;
            }
            catch
            {
                Console.WriteLine("   ❌ Ollama unreachable");
                return false;
            }
        }

        // ============================================================
        // QDRANT
        // ============================================================
        /// <summary>
        /// Checks the qdrant
        /// </summary>
        /// <returns>A task containing the bool</returns>
        private static async Task<bool> CheckQdrant()
        {
            try
            {
                var res = await http.GetAsync($"{QdrantBase}/collections");
                Console.WriteLine(res.IsSuccessStatusCode ? "   ✔ Qdrant OK" : "   ❌ Qdrant FAIL");
                return res.IsSuccessStatusCode;
            }
            catch
            {
                Console.WriteLine("   ❌ Qdrant unreachable");
                return false;
            }
        }

        /// <summary>
        /// Ensures the collection
        /// </summary>
        private static async Task EnsureCollection()
        {
            Console.WriteLine("   ℹ Collection check...");

            var res = await http.GetAsync($"{QdrantBase}/collections/{Collection}");

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine("   ✔ Collection exists");
                return;
            }

            Console.WriteLine("   ℹ Creating collection...");

            var create = await http.PutAsJsonAsync(
                $"{QdrantBase}/collections/{Collection}",
                new
                {
                    vectors = new
                    {
                        size = 768,
                        distance = "Cosine"
                    }
                });

            Console.WriteLine(create.IsSuccessStatusCode
                ? "   ✔ Collection created"
                : "   ❌ Collection creation failed");
        }

        // ============================================================
        // EMBEDDINGS
        // ============================================================
        /// <summary>
        /// Gets the embedding using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>A task containing the float array</returns>
        private static async Task<float[]> GetEmbedding(string text)
        {
            var res = await http.PostAsJsonAsync(OllamaUrl, new
            {
                model = "nomic-embed-text",
                prompt = text
            });

            if (!res.IsSuccessStatusCode)
                return Array.Empty<float>();

            var json = await res.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);

            return JsonSerializer.Deserialize<float[]>(
                doc.RootElement.GetProperty("embedding").ToString()
            );
        }

        // ============================================================
        // STORAGE
        // ============================================================
        /// <summary>
        /// Stores the chunk using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="content">The content</param>
        /// <param name="embedding">The embedding</param>
        private static async Task StoreChunk(string file, string content, float[] embedding)
        {
            var payload = new
            {
                points = new[]
                {
                    new
                    {
                        id = Guid.NewGuid().ToString(),
                        vector = embedding,
                        payload = new
                        {
                            file,
                            content
                        }
                    }
                }
            };

            var res = await http.PutAsJsonAsync(
                $"{QdrantBase}/collections/{Collection}/points",
                payload);

            if (!res.IsSuccessStatusCode)
            {
                Console.Write(" ❌ store fail");
            }
        }

        // ============================================================
        // CHUNKING (SIMPLE BUT STABLE)
        // ============================================================
        /// <summary>
        /// Splits the code using the specified code
        /// </summary>
        /// <param name="code">The code</param>
        /// <returns>The chunks</returns>
        private static List<string> SplitCode(string code)
        {
            var chunks = new List<string>();

            var parts = code.Split("\n\n");

            foreach (var p in parts)
            {
                if (p.Length < 30) continue;
                chunks.Add(p);
            }

            return chunks;
        }
    }
}