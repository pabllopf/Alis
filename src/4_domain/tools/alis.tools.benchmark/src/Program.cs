using System;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Alis.Tools.Benchmark
{
    /// <summary>
    /// The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
                .Run(args, DefaultConfig.Instance.AddJob(Job.ShortRun
                        .WithPlatform(Platform.AnyCpu)
                        .AsDefault())
                    .WithOptions(ConfigOptions.DisableLogFile)
                    .WithArtifactsPath($"..\\..\\..\\docs\\tests\\{DateTime.Now.ToString("yyyy-MM-dd")}")
                    .AddDiagnoser(MemoryDiagnoser.Default)
                    .AddColumn(StatisticColumn.Mean)
                    .AddColumn(StatisticColumn.Min)
                    .AddColumn(StatisticColumn.Max)
                    .AddExporter(MarkdownExporter.GitHub));
        }
    }
}