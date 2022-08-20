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

/*using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
*/

namespace Alis.Core.Updater.Test.Benchmark
{
    /// <summary>
    ///     The program class
    /// </summary>
    public class Program
    {
        /*public static void Main(string[] args)
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
        }*/
    }
}