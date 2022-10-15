// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Linq;
using Alis.Benchmark.ComputeHash;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Alis.Benchmark
{
    /// <summary>
    ///     The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            #if DEBUG
            ManualConfig config = new DebugBuildConfig()
                .WithOptions(ConfigOptions.DisableLogFile)
                .AddExporter(MarkdownExporter.GitHub)
                .WithArtifactsPath($"../../../../docs/benchmarks//{DateTime.Now:yyyy-MM-dd}/{typeof(Program).Assembly.GetName().Name}/debug/");
                
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
            
            #endif
            
            #if RELEASE
            
            ManualConfig config = new DebugBuildConfig()
                .WithOptions(ConfigOptions.DisableLogFile)
                .AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray())
                .AddDiagnoser(DefaultConfig.Instance.GetDiagnosers().ToArray())
                .AddValidator(DefaultConfig.Instance.GetValidators().ToArray())
                .AddDiagnoser(DefaultConfig.Instance.GetDiagnosers().ToArray())
                .AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray())
                .AddJob(DefaultConfig.Instance.GetJobs().ToArray())
                .AddLogger(new ConsoleLogger())
                .WithUnionRule(ConfigUnionRule.AlwaysUseGlobal)
                .AddExporter(MarkdownExporter.GitHub)
                .WithArtifactsPath($"../../../../docs/benchmarks//{DateTime.Now:yyyy-MM-dd}/{typeof(Program).Assembly.FullName}/release/");
                
            Summary[] summarys = BenchmarkRunner.Run(typeof(Program).Assembly, config, args);
            
            ILogger logger = ConsoleLogger.Default;
            
            foreach (Summary summary in summarys)
            {
                MarkdownExporter.Console.ExportToLog(summary, logger);
                ConclusionHelper.Print(logger, summary.BenchmarksCases.First().Config.GetCompositeAnalyser().Analyse(summary).ToList());
            }
            
            #endif
        }
    }
}