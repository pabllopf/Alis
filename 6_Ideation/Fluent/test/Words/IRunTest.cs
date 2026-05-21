// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRunTest.cs
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

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IRun interface.
    ///     Tests the Run method for execution.
    /// </summary>
    public class IRunTest
    {
        /// <summary>
        ///     Tests that IRun can be implemented.
        /// </summary>
        [Fact]
        public void IRun_CanBeImplemented()
        {
            TestRunner runner = new TestRunner();
            Assert.NotNull(runner);
            Assert.IsAssignableFrom<IRun>(runner);
        }

        /// <summary>
        ///     Tests that Run method can be called.
        /// </summary>
        [Fact]
        public void Run_CanBeCalled()
        {
            TestRunner runner = new TestRunner();
            runner.Run();
            Assert.True(runner.HasRun);
        }

        /// <summary>
        ///     Tests that Run increments execution count.
        /// </summary>
        [Fact]
        public void Run_IncrementsExecutionCount()
        {
            TestRunner runner = new TestRunner();
            runner.Run();
            Assert.Equal(1, runner.RunCount);
            runner.Run();
            Assert.Equal(2, runner.RunCount);
        }

        /// <summary>
        ///     Tests Run can be called multiple times.
        /// </summary>
        [Theory, InlineData(1), InlineData(5), InlineData(100)]
        public void Run_SupportsMultipleCalls(int callCount)
        {
            TestRunner runner = new TestRunner();
            for (int i = 0; i < callCount; i++)
            {
                runner.Run();
            }

            Assert.Equal(callCount, runner.RunCount);
        }

        /// <summary>
        ///     Helper implementation of IRun.
        /// </summary>
        private class TestRunner : IRun
        {
            /// <summary>
            ///     Gets or sets the value of the has run
            /// </summary>
            public bool HasRun { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the run count
            /// </summary>
            public int RunCount { get; private set; }

            /// <summary>
            ///     Runs this instance
            /// </summary>
            public void Run()
            {
                HasRun = true;
                RunCount++;
            }
        }
    }
}