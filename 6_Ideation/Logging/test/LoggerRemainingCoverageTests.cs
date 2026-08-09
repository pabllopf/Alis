// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerRemainingCoverageTests.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     The logger remaining coverage tests class
    /// </summary>
    [Collection("LoggerStaticCollection")]
    public class LoggerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that trace with custom logger writes to output
        /// </summary>
        [Fact]
        public void Trace_WithCustomLogger_WritesToOutput()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(memoryOutput);
            Logger.SetDefaultLogger(factory.CreateLogger("CustomLogger"));

            Logger.Trace("trace");
            Logger.Warning("warn");
            Logger.Error("error");
            Logger.Debug("debug");

            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Equal(4, entries.Count);
        }

        /// <summary>
        ///     Tests that info after reset reinitializes default logger
        /// </summary>
        [Fact]
        public void Info_AfterReset_ReinitializesDefaultLogger()
        {
            Logger.SetDefaultLogger(null);

            Logger.Info("after-reset");

            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(memoryOutput);
            Logger.SetDefaultLogger(factory.CreateLogger("CustomLogger"));

            Logger.Info("after-custom");
            Assert.Single(memoryOutput.GetEntries());
        }
    }
}
