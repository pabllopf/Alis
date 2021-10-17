using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;

namespace Alis.Tools.Benchmark
{
    public class Program
    {
        public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
            .Run(args, DefaultConfig.Instance.AddJob(Job.ShortRun
                .WithPlatform(BenchmarkDotNet.Environments.Platform.AnyCpu)
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
