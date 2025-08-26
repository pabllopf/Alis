// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomConfig.cs
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
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace Alis.Benchmark
{
    
    /// <summary>
    /// The custom config class
    /// </summary>
    /// <seealso cref="ManualConfig"/>
    internal class CustomConfig : ManualConfig
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomConfig" /> class
        /// </summary>
        public CustomConfig()
        {
            Options |= ConfigOptions.DisableLogFile;
            
#if RELEASE
            string outputDirectory = $"../../../Release/Results/{DateTime.Now:yyyy-MM-dd}/";
#else
             string outputDirectory = $"../../../Debug/Results/{DateTime.Now:yyyy-MM-dd}/";
#endif
            ArtifactsPath = outputDirectory;

            AddLogger(ConsoleLogger.Default);

            AddExporter(MarkdownExporter.GitHub);
            AddExporter(CsvExporter.Default);

        #if RELEASE
            Job debugJob = Job.InProcess
                .WithId("Release")
                .WithCustomBuildConfiguration("Release")
                .WithRuntime(CoreRuntime.Core80)
                .WithGcForce(true)
                .WithGcServer(true);
            
        #else
            Job debugJob = Job.InProcess
                .WithId("Debug")
                .WithCustomBuildConfiguration("Debug")
                .WithRuntime(CoreRuntime.Core80)
                .WithGcForce(true)
                .WithGcServer(true);
        
        #endif

            AddJob(debugJob);
            AddDiagnoser(MemoryDiagnoser.Default);
        }
    }
}