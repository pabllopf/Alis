// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObject.cs
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

using System.Linq;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Test.Helper;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.Results;
using Xunit;
using Xunit.Abstractions;

namespace Alis.Test.Benchmarks
{
    /// <summary>
    /// The game object benchmark test class
    /// </summary>
    public class GameObjectTest
    {
        /// <summary>
        /// The test output helper
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;
        
        /// <summary>
        /// The default
        /// </summary>
        private ManualConfig config = ManualConfig
            .Create(new DebugInProcessConfig())
            .WithOptions(ConfigOptions.Default);
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectTest"/> class
        /// </summary>
        /// <param name="testOutputHelper">The test output helper</param>
        public GameObjectTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
        
        /// <summary>
        /// Tests that game object benchmark test clear v 2
        /// </summary>
        [Fact]
        public void GameObject_BenchmarkTest_Clear()
        {
            Summary summary = BenchmarkRunner.Run<ClearComponentOfGameObjectBenchmark>(config);
            PrintSummary(summary);
        }
        
        /// <summary>
        /// Tests that game object benchmark test get
        /// </summary>
        [Fact]
        public void GameObject_BenchmarkTest_Get()
        {
            Summary summary = BenchmarkRunner.Run<GetComponentOfGameObjectBenchmark>(config);
            PrintSummary(summary);
        }
        
        /// <summary>
        /// Tests that game object benchmark test add
        /// </summary>
        [Fact]
        public void GameObject_BenchmarkTest_Add()
        {
            Summary summary = BenchmarkRunner.Run<AddComponentOfGameObjectBenchmark>(config);
            PrintSummary(summary);
        }
        
        /// <summary>
        /// Tests that game object benchmark test remove
        /// </summary>
        [Fact]
        public void GameObject_BenchmarkTest_Remove()
        {
            Summary summary = BenchmarkRunner.Run<RemoveComponentOfGameObjectBenchmark>(config);
            PrintSummary(summary);
        }
        
        /// <summary>
        /// Tests that game object benchmark test contains
        /// </summary>
        [Fact]
        public void GameObject_BenchmarkTest_Contains()
        {
            Summary summary = BenchmarkRunner.Run<ContainsComponentOfGameObjectBenchmark>(config);
            PrintSummary(summary);
        }

        /// <summary>
        /// Prints the summary using the specified summary
        /// </summary>
        /// <param name="summary">The summary</param>
        internal void PrintSummary(Summary summary)
        {
             int numOfChars = 14;
            
            string header = " | ";
            foreach (SummaryTable.SummaryTableColumn variable in summary.Table.Columns)
            {
                if (variable.Header.Equals("Method") || variable.Header.Equals("N") || variable.Header.Equals("Mean") || variable.Header.Equals("Error") || variable.Header.Equals("StdDev") || variable.Header.Equals("Allocated"))
                {
                    header += variable.Header;
                    
                    // calculate the rest of chars to add:
                    int rest = numOfChars - variable.Header.Length;
                    for (int i = 0; i < rest; i++)
                    {
                        header += " ";
                    }
                    
                    header += " | ";
                }
            }
            
            testOutputHelper.WriteLine(header);
            
            // Collect and print each row
            int rowCount = summary.Table.Columns.First().Content.Length;
            for (int i = 0; i < rowCount; i++)
            {
                string row = " | ";
                
                // if this row have NA in some column, skip it:
                if (summary.Table.Columns.Any(c => c.Content[i] == "NA"))
                {
                   continue; 
                }
                    
                foreach (SummaryTable.SummaryTableColumn column in summary.Table.Columns)
                {
                    if (column.Header.Equals("Method") || column.Header.Equals("N") || column.Header.Equals("Mean") || column.Header.Equals("Error") || column.Header.Equals("StdDev") || column.Header.Equals("Allocated"))
                    {
                        row += column.Content[i];
                        
                        // calculate the rest of chars to add:
                        int rest = numOfChars - column.Content[i].Length;
                        for (int k = 0; k < rest; k++)
                        {
                            row += " ";
                        }
                        
                        row += " | ";
                    }
                }
                testOutputHelper.WriteLine(row);
            }
        }
    }
}