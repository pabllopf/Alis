// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDemoTest.cs
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

using Alis.App.Engine.Demos;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    /// The demo test class
    /// </summary>
    public class IDemoTest
    {
        /// <summary>
        /// Tests that interface should be public
        /// </summary>
        [Fact]
        public void Interface_ShouldBePublic()
        {
            Assert.True(typeof(IDemo).IsInterface);
            Assert.True(typeof(IDemo).IsPublic);
        }

        /// <summary>
        /// Tests that interface should be implemented by icon demo
        /// </summary>
        [Fact]
        public void Interface_ShouldBeImplementedByIconDemo()
        {
            Assert.IsAssignableFrom<IDemo>(new IconDemo());
        }

        /// <summary>
        /// Tests that interface should be implemented by im gui demo
        /// </summary>
        [Fact]
        public void Interface_ShouldBeImplementedByImGuiDemo()
        {
            Assert.IsAssignableFrom<IDemo>(new ImGuiDemo());
        }

        /// <summary>
        /// Tests that interface should be implemented by im guizmo demo
        /// </summary>
        [Fact]
        public void Interface_ShouldBeImplementedByImGuizmoDemo()
        {
            Assert.IsAssignableFrom<IDemo>(new ImGuizmoDemo());
        }

        /// <summary>
        /// Tests that interface should be implemented by im node demo
        /// </summary>
        [Fact]
        public void Interface_ShouldBeImplementedByImNodeDemo()
        {
            Assert.IsAssignableFrom<IDemo>(new ImNodeDemo());
        }

        /// <summary>
        /// Tests that interface should be implemented by im plot demo
        /// </summary>
        [Fact]
        public void Interface_ShouldBeImplementedByImPlotDemo()
        {
            Assert.IsAssignableFrom<IDemo>(new ImPlotDemo());
        }
    }
}
