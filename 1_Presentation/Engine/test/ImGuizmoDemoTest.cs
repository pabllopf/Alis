// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizmoDemoTest.cs
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
    public class ImGuizmoDemoTest
    {
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            ImGuizmoDemo demo = new ImGuizmoDemo();

            Assert.NotNull(demo);
        }

        [Fact]
        public void Class_ShouldImplementIDemo()
        {
            Assert.IsAssignableFrom<IDemo>(new ImGuizmoDemo());
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            ImGuizmoDemo demo = new ImGuizmoDemo();

            demo.Initialize();
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            ImGuizmoDemo demo = new ImGuizmoDemo();

            demo.Start();
        }


    }
}
