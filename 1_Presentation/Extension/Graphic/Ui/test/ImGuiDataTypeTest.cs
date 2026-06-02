// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDataTypeTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiDataType" /> enum values.
    /// </summary>
    public class ImGuiDataTypeTest
    {
        /// <summary>
        ///     Verifies that S8 has the expected value of 0.
        /// </summary>
        [Fact]
        public void S8_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.S8;
            Assert.Equal(0, (int)value);
        }

        /// <summary>
        ///     Verifies that U8 has the expected value of 1.
        /// </summary>
        [Fact]
        public void U8_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.U8;
            Assert.Equal(1, (int)value);
        }

        /// <summary>
        ///     Verifies that S16 has the expected value of 2.
        /// </summary>
        [Fact]
        public void S16_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.S16;
            Assert.Equal(2, (int)value);
        }

        /// <summary>
        ///     Verifies that U16 has the expected value of 3.
        /// </summary>
        [Fact]
        public void U16_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.U16;
            Assert.Equal(3, (int)value);
        }

        /// <summary>
        ///     Verifies that S32 has the expected value of 4.
        /// </summary>
        [Fact]
        public void S32_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.S32;
            Assert.Equal(4, (int)value);
        }

        /// <summary>
        ///     Verifies that U32 has the expected value of 5.
        /// </summary>
        [Fact]
        public void U32_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.U32;
            Assert.Equal(5, (int)value);
        }

        /// <summary>
        ///     Verifies that S64 has the expected value of 6.
        /// </summary>
        [Fact]
        public void S64_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.S64;
            Assert.Equal(6, (int)value);
        }

        /// <summary>
        ///     Verifies that U64 has the expected value of 7.
        /// </summary>
        [Fact]
        public void U64_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.U64;
            Assert.Equal(7, (int)value);
        }

        /// <summary>
        ///     Verifies that Float has the expected value of 8.
        /// </summary>
        [Fact]
        public void Float_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.Float;
            Assert.Equal(8, (int)value);
        }

        /// <summary>
        ///     Verifies that Double has the expected value of 9.
        /// </summary>
        [Fact]
        public void Double_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.Double;
            Assert.Equal(9, (int)value);
        }

        /// <summary>
        ///     Verifies that Count has the expected value of 10.
        /// </summary>
        [Fact]
        public void Count_ShouldHaveCorrectValue()
        {
            ImGuiDataType value = ImGuiDataType.Count;
            Assert.Equal(10, (int)value);
        }

        /// <summary>
        ///     Verifies that all enum values are distinct.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            var values = (ImGuiDataType[])System.Enum.GetValues(typeof(ImGuiDataType));
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual((int)values[i], (int)values[j]);
                }
            }
        }
    }
}
