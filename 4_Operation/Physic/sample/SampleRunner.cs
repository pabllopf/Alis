using System;
using System.Diagnostics;
using System.Linq;
using Alis.Core.Physic.Sample.Samples;

namespace Alis.Core.Physic.Sample
{
    /// <summary>
    /// The sample runner class
    /// </summary>
    internal static class SampleRunner
    {
        /// <summary>
        /// Runs the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Run(string[] args)
        {
            if ((args != null) && (args.Length > 0))
            {
                ExecuteSelection(args[0]);
                return;
            }

            PrintMenu();
            Console.Write("Choose a sample by number/key, or type 'all': ");
            string selection = Console.ReadLine();
            selection = selection == null ? string.Empty : selection.Trim();
            ExecuteSelection(selection);
        }

        /// <summary>
        /// Executes the selection using the specified selection
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

            IPhysicSample sampleByKey =
                SampleCatalog.All.FirstOrDefault(sample => sample.Key.Equals(selection, StringComparison.OrdinalIgnoreCase));

            if (sampleByKey != null)
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

            Console.WriteLine("Invalid selection: '{0}'.", selection);
            Console.WriteLine("Use a sample number, a sample key, or 'all'.");
        }

        /// <summary>
        /// Prints the menu
        /// </summary>
        private static void PrintMenu()
        {
            WriteSectionTitle("Alis Physic Sample Selector");
            Console.WriteLine("Available samples: {0}", SampleCatalog.All.Count);
            Console.WriteLine();

            for (int i = 0; i < SampleCatalog.All.Count; i++)
            {
                IPhysicSample sample = SampleCatalog.All[i];
                Console.WriteLine("[{0:00}] {1}", i + 1, sample.Title);
                Console.WriteLine("     Key : {0}", sample.Key);
                Console.WriteLine("     What: {0}", sample.Description);
            }

            Console.WriteLine();
            Console.WriteLine("[A ] Run all samples (all)");
        }

        /// <summary>
        /// Runs the all
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
            WriteSuccess("Succeeded: " + succeeded);
            if (failed > 0)
            {
                WriteError("Failed: " + failed);
            }
            else
            {
                WriteInfo("Failed: 0");
            }

            WriteInfo(string.Format("Total time: {0:F2} ms", totalTimer.Elapsed.TotalMilliseconds));
        }

        /// <summary>
        /// Runs the one using the specified sample
        /// </summary>
        /// <param name="sample">The sample</param>
        /// <param name="index">The index</param>
        /// <returns>The bool</returns>
        private static bool RunOne(IPhysicSample sample, int index)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Console.WriteLine();
            WriteSectionTitle(string.Format("[{0:00}] {1}", index, sample.Title));
            WriteInfo("Key: " + sample.Key);
            WriteInfo("Description: " + sample.Description);
            Console.WriteLine(new string('-', 72));

            try
            {
                SampleRuntime runtime = new SampleRuntime();
                sample.Run(runtime);
                timer.Stop();
                WriteSuccess(string.Format("Status: OK ({0:F2} ms)", timer.Elapsed.TotalMilliseconds));
                return true;
            }
            catch (Exception exception)
            {
                timer.Stop();
                WriteError(string.Format("Status: FAILED ({0:F2} ms)", timer.Elapsed.TotalMilliseconds));
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
        /// Writes the section title using the specified text
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
        /// Writes the info using the specified text
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
        /// Writes the success using the specified text
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
        /// Writes the error using the specified text
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

