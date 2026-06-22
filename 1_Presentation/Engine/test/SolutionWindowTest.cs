// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:SolutionWindowTest.cs
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
using System.Reflection;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests for the SolutionWindow class
    /// </summary>
    public class SolutionWindowTest
    {
        private static SpaceWork CreateSpaceWork() =>
            (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));

        /// <summary>
        ///     Tests that constructor should set SpaceWork property
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            SolutionWindow window = new SolutionWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that SpaceWork property returns the value set in constructor
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            SolutionWindow window = new SolutionWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that NameWindow static property is not null
        /// </summary>
        [Fact]
        public void NameWindow_StaticProperty_ShouldNotBeNullOrEmpty()
        {
            FieldInfo field = typeof(SolutionWindow).GetField("NameWindow", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            Assert.NotNull(field);
            string value = field.GetValue(null) as string;
            Assert.NotNull(value);
            Assert.NotEmpty(value);
        }

        /// <summary>
        ///     Tests that Initialize should not throw
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            SolutionWindow window = new SolutionWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Tests that Start should not throw
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            SolutionWindow window = new SolutionWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }
        
    }
}
