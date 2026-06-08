// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ThreadTaskTest.cs
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
using System.Threading;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The thread task test class
    /// </summary>
    public class ThreadTaskTest
    {
        /// <summary>
        ///     Tests that execute should execute action
        /// </summary>
        [Fact]
        public void Execute_ShouldExecuteAction()
        {
            bool actionExecuted = false;
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadTask threadTask = new ThreadTask(token => { actionExecuted = true; }, cts.Token);

            threadTask.Execute(cts.Token);

            System.Threading.Thread.Sleep(1000);

            cts.Cancel();

            Assert.True(actionExecuted);
        }

        /// <summary>
        ///     Tests that execute throws exception when action throws
        /// </summary>
        [Fact]
        public void Execute_WhenActionThrows_ExceptionIsThrown()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadTask threadTask = new ThreadTask(token => { throw new InvalidOperationException("Test exception"); }, cts.Token);

            Assert.Throws<InvalidOperationException>(() => threadTask.Execute(cts.Token));
        }
    }
}