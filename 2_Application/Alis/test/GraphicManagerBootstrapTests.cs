// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerBootstrapTests.cs
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

using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Asserts the GraphicManager init and draw steps recorded by
    ///     <see cref="GraphicManagerBootstrap" /> on the process main thread. Tests are guarded
    ///     no-ops when the startup hook was not installed.
    /// </summary>
    public class GraphicManagerBootstrapTests
    {
        /// <summary>
        ///     Tests that every bootstrap step completed without an exception.
        /// </summary>
        [Fact]
        public void Bootstrap_AllStepsSucceeded()
        {
            if (!GraphicManagerBootstrap.Ready)
            {
                return;
            }

            Assert.Empty(GraphicManagerBootstrap.Failures);
        }

        /// <summary>
        ///     Tests that the init with the default window size completed.
        /// </summary>
        [Fact]
        public void Bootstrap_InitDefaultWindow_Completed()
        {
            Assert.True(GraphicManagerBootstrap.Ready && GraphicManagerBootstrap.InitDefaultWindowOk);
        }

        /// <summary>
        ///     Tests that the init with the custom window size completed.
        /// </summary>
        [Fact]
        public void Bootstrap_InitCustomWindow_Completed()
        {
            Assert.True(GraphicManagerBootstrap.Ready && GraphicManagerBootstrap.InitCustomWindowOk);
        }

        /// <summary>
        ///     Tests that the draw completed.
        /// </summary>
        [Fact]
        public void Bootstrap_Draw_Completed()
        {
            Assert.True(GraphicManagerBootstrap.Ready && GraphicManagerBootstrap.DrawOk);
        }
    }
}
