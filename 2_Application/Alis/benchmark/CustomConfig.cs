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
using Alis.Benchmark.CustomEcs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Loggers;

namespace Alis.Benchmark
{
    internal class CustomConfig : ManualConfig
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomConfig" /> class
        /// </summary>
        public CustomConfig()
        {
            Options |= ConfigOptions.DisableLogFile;

            // Especifica la carpeta de salida
            string outputDirectory = $"../../../../Results/{nameof(AlisEcsBenchmark)}/{DateTime.Now:yyyy-MM-dd_HH-mm-ss}/";

            // Configura la ruta de los artefactos
            ArtifactsPath = outputDirectory;

            // Desactiva la generación de archivos de log, pero mantiene la consola
            AddLogger(ConsoleLogger.Default); // Muestra solo en consola sin guardar logs en ficheros

            // Agrega los exportadores
            AddExporter(MarkdownExporter.GitHub);
            AddExporter(CsvExporter.Default);
        }
    }
}