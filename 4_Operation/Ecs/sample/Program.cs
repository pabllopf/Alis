

using System;
using System.Diagnostics;
using System.Linq;
using Alis.Core.Ecs.Sample.Samples;

namespace Alis.Core.Ecs.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ExecuteSelection(args[0]);
                return;
            }

            PrintMenu();
            Console.Write("Choose a sample by number/key, or type 'all': ");
            string selection = Console.ReadLine()?.Trim() ?? string.Empty;

            ExecuteSelection(selection);
        }

        /// <summary>
        ///     Prints the menu
        /// </summary>
        private static void PrintMenu()
        {
            WriteSectionTitle("Alis ECS Sample Selector");
            Console.WriteLine($"Available samples: {SampleCatalog.All.Count}");
            Console.WriteLine();

            for (int i = 0; i < SampleCatalog.All.Count; i++)
            {
                IEcsSample sample = SampleCatalog.All[i];
                Console.WriteLine($"[{i + 1:00}] {sample.Title}");
                Console.WriteLine($"     Key : {sample.Key}");
                Console.WriteLine($"     What: {sample.Description}");
            }

            Console.WriteLine();
            Console.WriteLine("[A ] Run all samples (all)");
        }

        /// <summary>
        ///     Executes the selection using the specified selection
        /// </summary>
        /// <param name="selection">The selection</param>
        private static void ExecuteSelection(string selection)
        {
            if (string.IsNullOrWhiteSpace(selection))
            {
                Console.WriteLine("No selection provided.");
                return;
            }

            if (selection.Equals("all", StringComparison.OrdinalIgnoreCase) ||
                selection.Equals("a", StringComparison.OrdinalIgnoreCase))
            {
                RunAll();
                return;
            }

            if (int.TryParse(selection, out int index) && (index >= 1) && (index <= SampleCatalog.All.Count))
            {
                RunOne(SampleCatalog.All[index - 1], index);
                return;
            }

            IEcsSample sampleByKey = SampleCatalog.All.FirstOrDefault(sample => sample.Key.Equals(selection, StringComparison.OrdinalIgnoreCase));

            if (sampleByKey is not null)
            {
                int indexByKey = 0;
                for (int i = 0; i < SampleCatalog.All.Count; i++)
                {
                    if (ReferenceEquals(SampleCatalog.All[i], sampleByKey))
                    {
                        indexByKey = i + 1;
                        break;
                    }
                }

                RunOne(sampleByKey, indexByKey);
                return;
            }

            Console.WriteLine($"Invalid selection: '{selection}'.");
            Console.WriteLine("Use a sample number, a sample key, or 'all'.");
        }

        /// <summary>
        ///     Runs the all
        /// </summary>
        private static void RunAll()
        {
            Stopwatch totalTimer = Stopwatch.StartNew();
            int succeeded = 0;
            int failed = 0;

            for (int i = 0; i < SampleCatalog.All.Count; i++)
            {
                if (RunOne(SampleCatalog.All[i], i + 1))
                {
                    succeeded++;
                }
                else
                {
                    failed++;
                }
            }

            totalTimer.Stop();
            Console.WriteLine();
            WriteSectionTitle("Run Summary");
            WriteSuccess($"Succeeded: {succeeded}");
            if (failed > 0)
            {
                WriteError($"Failed: {failed}");
            }
            else
            {
                WriteInfo("Failed: 0");
            }

            WriteInfo($"Total time: {totalTimer.Elapsed.TotalMilliseconds:F2} ms");
        }

        /// <summary>
        ///     Runs the one using the specified sample
        /// </summary>
        /// <param name="sample">The sample</param>
        /// <param name="index">The index</param>
        private static bool RunOne(IEcsSample sample, int index)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Console.WriteLine();
            WriteSectionTitle($"[{index:00}] {sample.Title}");
            WriteInfo($"Key: {sample.Key}");
            WriteInfo($"Description: {sample.Description}");
            Console.WriteLine(new string('-', 72));

            try
            {
                sample.Run();
                timer.Stop();
                WriteSuccess($"Status: OK ({timer.Elapsed.TotalMilliseconds:F2} ms)");
                return true;
            }
            catch (Exception exception)
            {
                timer.Stop();
                WriteError($"Status: FAILED ({timer.Elapsed.TotalMilliseconds:F2} ms)");
                WriteError("Unhandled error details:");
                WriteError(exception.ToString());
                return false;
            }
            finally
            {
                Console.ResetColor();
                Console.WriteLine("=== End ===");
            }
        }

        /// <summary>
        ///     Writes the section title using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        private static void WriteSectionTitle(string text)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        ///     Writes the info using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        private static void WriteInfo(string text)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        ///     Writes the success using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        private static void WriteSuccess(string text)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        ///     Writes the error using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        private static void WriteError(string text)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }
    }
}