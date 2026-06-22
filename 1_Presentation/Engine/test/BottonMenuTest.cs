// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BottomMenuTest.cs
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

using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests for the <see cref="BottomMenu"/> class.
    /// </summary>
    public partial class BottomMenuTest
    {
        /// <summary>
        ///     Tests that the constructor sets the SpaceWork property correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            BottomMenu menu = new BottomMenu(spaceWork);

            Assert.NotNull(menu);
            Assert.Same(spaceWork, menu.SpaceWork);
        }

        /// <summary>
        ///     Tests that the SpaceWork property returns the value set in the constructor.
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            BottomMenu menu = new BottomMenu(spaceWork);

            Assert.NotNull(menu.SpaceWork);
            Assert.Same(spaceWork, menu.SpaceWork);
        }

        /// <summary>
        ///     Tests that Initialize() does not throw an exception.
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            BottomMenu menu = new BottomMenu(spaceWork);

            menu.Initialize();

            Assert.NotNull(menu);
        }

        /// <summary>
        ///     Tests that Start() does not throw an exception.
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            BottomMenu menu = new BottomMenu(spaceWork);

            menu.Start();

            Assert.NotNull(menu);
        }

        /// <summary>
        ///     Tests that Update() does not throw an exception.
        /// </summary>
        [Fact]
        public void Update_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            BottomMenu menu = new BottomMenu(spaceWork);

            menu.Update();

            Assert.NotNull(menu);
        }
    }
}
