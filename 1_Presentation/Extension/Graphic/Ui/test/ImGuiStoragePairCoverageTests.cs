// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStoragePairCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui storage pair coverage tests class
    /// </summary>
    public class ImGuiStoragePairCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiStoragePair_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiStoragePair pair = default(ImGuiStoragePair);

            Assert.Equal(0U, pair.Key);
            Assert.Equal(0, pair.Value.ValueI32);
            Assert.Equal(0f, pair.Value.ValueF32);
            Assert.Equal(IntPtr.Zero, pair.Value.ValuePtr);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiStoragePair_SetProperties_StoresValuesCorrectly()
        {
            ImGuiStoragePair pair = new ImGuiStoragePair
            {
                Key = 42U,
                Value = new UnionValue { ValueI32 = 7 }
            };

            Assert.Equal(42U, pair.Key);
            Assert.Equal(7, pair.Value.ValueI32);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiStoragePair_IsValueType_CopyIsIndependent()
        {
            ImGuiStoragePair original = new ImGuiStoragePair
            {
                Key = 1U,
                Value = new UnionValue { ValuePtr = new IntPtr(100) }
            };
            ImGuiStoragePair copy = original;

            copy.Key = 2U;
            copy.Value = new UnionValue { ValuePtr = new IntPtr(200) };

            Assert.Equal(1U, original.Key);
            Assert.Equal(new IntPtr(100), original.Value.ValuePtr);
            Assert.Equal(2U, copy.Key);
            Assert.Equal(new IntPtr(200), copy.Value.ValuePtr);
        }
    }
}