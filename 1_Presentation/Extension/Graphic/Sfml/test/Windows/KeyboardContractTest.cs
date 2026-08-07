// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardContractTest.cs
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
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Contract tests for the <see cref="Keyboard" /> static class.
    /// </summary>
    public class KeyboardContractTest
    {
        /// <summary>
        ///     Verifies that Keyboard is a static class.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Keyboard_ShouldBeStaticClass()
        {
            Assert.True(typeof(Keyboard).IsClass);
            Assert.True(typeof(Keyboard).IsAbstract);
            Assert.True(typeof(Keyboard).IsSealed);
        }

        /// <summary>
        ///     Verifies that Keyboard defines the Key enum.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Keyboard_ShouldDefineKeyEnum()
        {
            Type keyType = typeof(Keyboard).GetNestedType("Key", BindingFlags.Public);

            Assert.NotNull(keyType);
            Assert.True(keyType.IsEnum);
        }

        /// <summary>
        ///     Verifies that Key.Unknown has value -1.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_Unknown_ShouldBeNegativeOne()
        {
            Assert.Equal(-1, (int)Keyboard.Key.Unknown);
        }

        /// <summary>
        ///     Verifies that Key.A has value 0.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_A_ShouldBeZero()
        {
            Assert.Equal(0, (int)Keyboard.Key.A);
        }

        /// <summary>
        ///     Verifies that Key.B has value 1.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_B_ShouldBeOne()
        {
            Assert.Equal(1, (int)Keyboard.Key.B);
        }

        /// <summary>
        ///     Verifies that Key.Escape has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_Escape_ShouldHaveCorrectValue()
        {
            Assert.Equal(36, (int)Keyboard.Key.Escape);
        }

        /// <summary>
        ///     Verifies that Key.Space has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_Space_ShouldHaveCorrectValue()
        {
            Assert.Equal(57, (int)Keyboard.Key.Space);
        }

        /// <summary>
        ///     Verifies that Key.Enter has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_Enter_ShouldHaveCorrectValue()
        {
            Assert.Equal(58, (int)Keyboard.Key.Enter);
        }

        /// <summary>
        ///     Verifies that Key.LControl has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_LControl_ShouldHaveCorrectValue()
        {
            Assert.Equal(37, (int)Keyboard.Key.LControl);
        }

        /// <summary>
        ///     Verifies that Key.LShift has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_LShift_ShouldHaveCorrectValue()
        {
            Assert.Equal(38, (int)Keyboard.Key.LShift);
        }

        /// <summary>
        ///     Verifies that Key.LAlt has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_LAlt_ShouldHaveCorrectValue()
        {
            Assert.Equal(39, (int)Keyboard.Key.LAlt);
        }

        /// <summary>
        ///     Verifies that Key.LSystem has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_LSystem_ShouldHaveCorrectValue()
        {
            Assert.Equal(40, (int)Keyboard.Key.LSystem);
        }

        /// <summary>
        ///     Verifies that Key.RControl has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_RControl_ShouldHaveCorrectValue()
        {
            Assert.Equal(41, (int)Keyboard.Key.RControl);
        }

        /// <summary>
        ///     Verifies that Key.RShift has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_RShift_ShouldHaveCorrectValue()
        {
            Assert.Equal(42, (int)Keyboard.Key.RShift);
        }

        /// <summary>
        ///     Verifies that Key.RAlt has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_RAlt_ShouldHaveCorrectValue()
        {
            Assert.Equal(43, (int)Keyboard.Key.RAlt);
        }

        /// <summary>
        ///     Verifies that Key.RSystem has correct value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Key_RSystem_ShouldHaveCorrectValue()
        {
            Assert.Equal(44, (int)Keyboard.Key.RSystem);
        }

        /// <summary>
        ///     Verifies that all public methods on Keyboard are static.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void AllPublicMethods_ShouldBeStatic()
        {
            MethodInfo[] methods = typeof(Keyboard)
                .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)
                .Where(m => m.DeclaringType == typeof(Keyboard))
                .ToArray();

            Assert.All(methods, method => Assert.True(method.IsStatic));
        }
    }
}
