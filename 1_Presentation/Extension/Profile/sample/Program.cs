

using System;
using System.Threading;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Profile.Builders;
using Alis.Extension.Profile.Helpers;
using Alis.Extension.Profile.Interfaces;
using Alis.Extension.Profile.Models;
using Alis.Extension.Profile.Utilities;

namespace Alis.Extension.Profile.Sample
{
    /// <summary>
    ///     Demonstrates various usage patterns of the profiling system.
    ///     Shows both manual profiling and automatic scope-based profiling.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point for the profiling sample application.
        /// </summary>
        /// <param name="args">Command line arguments (not used).</param>
        public static void Main(string[] args)
        {
            Logger.Info("=== Profiling System Sample ===");
            Logger.Info("");

            ManualProfilingExample();

            Logger.Info("");

            AutomaticProfilingExample();

            Logger.Info("");

            RealTimeMonitoringExample();

            Logger.Info("");
            Logger.Info("=== Sample Completed ===");
        }

        /// <summary>
        ///     Demonstrates manual profiling using the service directly.
        /// </summary>
        private static void ManualProfilingExample()
        {
            Logger.Info("--- Manual Profiling Example ---");

            IProfilerService profilerService = ProfilerServiceBuilder.CreateDefault();

            profilerService.StartProfiling();

            PerformHeavyComputation();

            ProfileSnapshot snapshot = profilerService.StopProfiling();

            Logger.Info(ProfileSnapshotFormatter.FormatCompact(snapshot));
            Logger.Info("");
            Logger.Info(ProfileSnapshotFormatter.FormatDetailed(snapshot));
        }

        /// <summary>
        ///     Demonstrates automatic profiling using the ProfilerScope utility.
        /// </summary>
        private static void AutomaticProfilingExample()
        {
            Logger.Info("--- Automatic Profiling Example ---");

            IProfilerService profilerService = ProfilerServiceBuilder.CreateDefault();

            using (new ProfilerScope(profilerService, snapshot =>
                   {
                       Logger.Info("Profiling completed automatically!");
                       Logger.Info(ProfileSnapshotFormatter.FormatCompact(snapshot));
                   }))
            {
                PerformMemoryIntensiveOperation();
            }
        }

        /// <summary>
        ///     Demonstrates real-time monitoring without stopping profiling.
        /// </summary>
        private static void RealTimeMonitoringExample()
        {
            Logger.Info("--- Real-Time Monitoring Example ---");

            IProfilerService profilerService = ProfilerServiceBuilder.CreateDefault();
            profilerService.StartProfiling();

            for (int i = 1; i <= 3; i++)
            {
                PerformWork();

                ProfileSnapshot currentSnapshot = profilerService.GetCurrentSnapshot();
                Logger.Info($"Checkpoint {i}: {ProfileSnapshotFormatter.FormatCompact(currentSnapshot)}");
            }

            ProfileSnapshot finalSnapshot = profilerService.StopProfiling();
            Logger.Info($"Final: {ProfileSnapshotFormatter.FormatCompact(finalSnapshot)}");
        }

        /// <summary>
        ///     Performs CPU-intensive computation for profiling demonstration.
        /// </summary>
        private static void PerformHeavyComputation()
        {
            double result = 0;
            for (int i = 0; i < 1000000; i++)
            {
                result += Math.Sqrt(i) * Math.Sin(i);
            }
        }

        /// <summary>
        ///     Performs memory-intensive operations for profiling demonstration.
        /// </summary>
        private static void PerformMemoryIntensiveOperation()
        {
            for (int i = 0; i < 100; i++)
            {
                byte[] buffer = new byte[1024 * 100]; // 100 KB per iteration
                Array.Clear(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        ///     Performs general work for profiling demonstration.
        /// </summary>
        private static void PerformWork()
        {
            Thread.Sleep(100);
            for (int i = 0; i < 100000; i++)
            {
                _ = Math.Sqrt(i);
            }
        }
    }
}