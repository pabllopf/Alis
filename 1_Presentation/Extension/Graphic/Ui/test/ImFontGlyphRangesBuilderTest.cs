// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRangesBuilderTest.cs
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
using System.Reflection;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImFontGlyphRangesBuilder" /> contracts.
    /// </summary>
    public class ImFontGlyphRangesBuilderTest
    {
        /// <summary>
        ///     Verifies that the builder is implemented as a value type.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStruct()
        {
            Type type = typeof(ImFontGlyphRangesBuilder);

            Assert.True(type.IsValueType);
            Assert.False(type.IsClass);
        }

        /// <summary>
        ///     Verifies that <see cref="ImFontGlyphRangesBuilder.UsedChars" /> starts with default value.
        /// </summary>
        [Fact]
        public void UsedChars_ShouldBeDefaultOnNewInstance()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();

            Assert.Equal(default(ImVector), builder.UsedChars);
        }

        /// <summary>
        ///     Verifies that <see cref="ImFontGlyphRangesBuilder.UsedChars" /> can be assigned and read back.
        /// </summary>
        [Fact]
        public void UsedChars_ShouldRoundTripAssignedValue()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            ImVector usedChars = new ImVector
            {
                Size = 2,
                Capacity = 4,
                Data = IntPtr.Zero
            };

            builder.UsedChars = usedChars;

            Assert.Equal(usedChars.Size, builder.UsedChars.Size);
            Assert.Equal(usedChars.Capacity, builder.UsedChars.Capacity);
            Assert.Equal(usedChars.Data, builder.UsedChars.Data);
        }

        /// <summary>
        ///     Verifies method signatures for native-backed operations remain stable.
        /// </summary>
        [Fact]
        public void NativeBackedMethods_ShouldKeepExpectedSignatures()
        {
            AssertMethod("AddChar", typeof(void), typeof(ushort));
            AssertMethod("Clear", typeof(void));
            AssertMethod("GetBit", typeof(bool), typeof(uint));
            AssertMethod("SetBit", typeof(void), typeof(uint));
        }

        /// <summary>
        ///     Verifies that all API methods in the builder are public instance members.
        /// </summary>
        [Fact]
        public void ApiMethods_ShouldBePublicInstanceMethods()
        {
            MethodInfo addChar = typeof(ImFontGlyphRangesBuilder).GetMethod("AddChar");
            MethodInfo clear = typeof(ImFontGlyphRangesBuilder).GetMethod("Clear");
            MethodInfo getBit = typeof(ImFontGlyphRangesBuilder).GetMethod("GetBit");
            MethodInfo setBit = typeof(ImFontGlyphRangesBuilder).GetMethod("SetBit");

            Assert.NotNull(addChar);
            Assert.NotNull(clear);
            Assert.NotNull(getBit);
            Assert.NotNull(setBit);

            Assert.True(addChar.IsPublic && !addChar.IsStatic);
            Assert.True(clear.IsPublic && !clear.IsStatic);
            Assert.True(getBit.IsPublic && !getBit.IsStatic);
            Assert.True(setBit.IsPublic && !setBit.IsStatic);
        }

        /// <summary>
        ///     Resolves and validates a method by exact signature.
        /// </summary>
        /// <param name="name">The target method name.</param>
        /// <param name="returnType">The expected return type.</param>
        /// <param name="parameterTypes">The expected parameter types.</param>
        private static void AssertMethod(string name, Type returnType, params Type[] parameterTypes)
        {
            MethodInfo method = typeof(ImFontGlyphRangesBuilder).GetMethod(name, BindingFlags.Public | BindingFlags.Instance, null, parameterTypes, null);

            Assert.NotNull(method);
            Assert.Equal(returnType, method.ReturnType);
        }
    }
}