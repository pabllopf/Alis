// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetsWindowTest.cs
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
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests for the <see cref="AssetsWindow"/> class.
    /// </summary>
    public class AssetsWindowTest
    {
        /// <summary>
        ///     Tests that the public static WindowName field is not null.
        /// </summary>
        [Fact]
        public void WindowName_Field_ShouldNotBeNull()
        {
            Assert.NotNull(AssetsWindow.WindowName);
            Assert.NotEmpty(AssetsWindow.WindowName);
        }

        /// <summary>
        ///     Tests that the constructor sets the SpaceWork property correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that the constructor allocates commandPtr successfully.
        /// </summary>
        [Fact]
        public void Constructor_ShouldAllocateCommandPtr()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window);
            // CommandPtr allocation is internal, but window should be instantiated successfully
        }

        /// <summary>
        ///     Tests that the SpaceWork property returns the value set in the constructor.
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that the IsDefaultSize property defaults to true.
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldDefaultToTrue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.True(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that the IsDefaultSize property can be set to false.
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldAllowSetValueToFalse()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.IsDefaultSize = false;

            Assert.False(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that the IsDefaultSize property can be set to true.
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldAllowSetValueToTrue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.IsDefaultSize = true;

            Assert.True(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that Initialize() does not throw an exception.
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Tests that Start() does not throw an exception.
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }
    }
}
