// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GamePadStateTest.cs
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

using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Contract tests for the <see cref="GamePadState" /> struct.
    /// </summary>
    public class GamePadStateTest
    {
        /// <summary>
        ///     Verifies that GamePadState is a value type.
        /// </summary>
        [Fact]
        public void GamePadState_ShouldBeValueType()
        {
            Assert.True(typeof(GamePadState).IsValueType);
        }

        /// <summary>
        ///     Verifies that GamePadState has sequential layout.
        /// </summary>
        [Fact]
        public void GamePadState_ShouldHaveSequentialLayout()
        {
            StructLayoutAttribute attribute = typeof(GamePadState).StructLayoutAttribute;

            Assert.NotNull(attribute);
            Assert.Equal(LayoutKind.Sequential, attribute.Value);
        }

        /// <summary>
        ///     Verifies that the states field has ByValArray marshal attribute.
        /// </summary>
        [Fact]
        public void StatesField_ShouldHaveMarshalAsByValArray()
        {
            FieldInfo field = typeof(GamePadState).GetField("states", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(field);
            MarshalAsAttribute attribute = field.GetCustomAttribute<MarshalAsAttribute>();

            Assert.NotNull(attribute);
            Assert.Equal(UnmanagedType.ByValArray, attribute.Value);
            Assert.Equal(15, attribute.SizeConst);
        }

        /// <summary>
        ///     Verifies that the axes field has ByValArray marshal attribute.
        /// </summary>
        [Fact]
        public void AxesField_ShouldHaveMarshalAsByValArray()
        {
            FieldInfo field = typeof(GamePadState).GetField("axes", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(field);
            MarshalAsAttribute attribute = field.GetCustomAttribute<MarshalAsAttribute>();

            Assert.NotNull(attribute);
            Assert.Equal(UnmanagedType.ByValArray, attribute.Value);
            Assert.Equal(6, attribute.SizeConst);
        }

        /// <summary>
        ///     Verifies that GetButtonState method exists and returns InputState.
        /// </summary>
        [Fact]
        public void GetButtonState_ShouldExist()
        {
            MethodInfo method = typeof(GamePadState).GetMethod("GetButtonState", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(method);
            Assert.Equal(typeof(InputState), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that GetAxis method exists and returns float.
        /// </summary>
        [Fact]
        public void GetAxis_ShouldExist()
        {
            MethodInfo method = typeof(GamePadState).GetMethod("GetAxis", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(method);
            Assert.Equal(typeof(float), method.ReturnType);
        }
    }
}
