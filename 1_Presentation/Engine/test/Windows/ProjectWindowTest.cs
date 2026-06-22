// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProjectWindowTest.cs
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

using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test.Windows
{
    /// <summary>
    ///     The project window test class
    /// </summary>
    public class ProjectWindowTest
    {
        /// <summary>
        ///     Tests that NameWindow is a non-empty string
        /// </summary>
        [Fact]
        public void NameWindow_ShouldBeNonEmpty()
        {
            Assert.NotNull(ProjectWindow.NameWindow);
            Assert.NotEmpty(ProjectWindow.NameWindow);
        }

        /// <summary>
        ///     Tests that constructor initializes SpaceWork
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeSpaceWork()
        {
            SpaceWork spaceWork = new SpaceWork();

            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.Equal(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that SpaceWork property is readable
        /// </summary>
        [Fact]
        public void SpaceWork_ShouldBeReadable()
        {
            SpaceWork spaceWork = new SpaceWork();

            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
        }
    }
}
