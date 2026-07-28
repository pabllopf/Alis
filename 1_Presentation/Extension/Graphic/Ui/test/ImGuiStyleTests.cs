// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStyleTests.cs
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

using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui style tests class
    /// </summary>
    public class ImGuiStyleTests
    {
        /// <summary>
        /// Tests that indexer get every index should return correct color
        /// </summary>
        /// <param name="index">The index</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(30)]
        [InlineData(31)]
        [InlineData(32)]
        [InlineData(33)]
        [InlineData(34)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(38)]
        [InlineData(39)]
        [InlineData(40)]
        [InlineData(41)]
        [InlineData(42)]
        [InlineData(43)]
        [InlineData(44)]
        [InlineData(45)]
        [InlineData(46)]
        [InlineData(47)]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        [InlineData(51)]
        [InlineData(52)]
        [InlineData(53)]
        [InlineData(54)]
        public void Indexer_Get_EveryIndex_ShouldReturnCorrectColor(int index)
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(index * 0.01f, index * 0.02f, index * 0.03f, index * 0.04f);

            switch (index)
            {
                case 0: style.Colors0 = expected; break;
                case 1: style.Colors1 = expected; break;
                case 2: style.Colors2 = expected; break;
                case 3: style.Colors3 = expected; break;
                case 4: style.Colors4 = expected; break;
                case 5: style.Colors5 = expected; break;
                case 6: style.Colors6 = expected; break;
                case 7: style.Colors7 = expected; break;
                case 8: style.Colors8 = expected; break;
                case 9: style.Colors9 = expected; break;
                case 10: style.Colors10 = expected; break;
                case 11: style.Colors11 = expected; break;
                case 12: style.Colors12 = expected; break;
                case 13: style.Colors13 = expected; break;
                case 14: style.Colors14 = expected; break;
                case 15: style.Colors15 = expected; break;
                case 16: style.Colors16 = expected; break;
                case 17: style.Colors17 = expected; break;
                case 18: style.Colors18 = expected; break;
                case 19: style.Colors19 = expected; break;
                case 20: style.Colors20 = expected; break;
                case 21: style.Colors21 = expected; break;
                case 22: style.Colors22 = expected; break;
                case 23: style.Colors23 = expected; break;
                case 24: style.Colors24 = expected; break;
                case 25: style.Colors25 = expected; break;
                case 26: style.Colors26 = expected; break;
                case 27: style.Colors27 = expected; break;
                case 28: style.Colors28 = expected; break;
                case 29: style.Colors29 = expected; break;
                case 30: style.Colors30 = expected; break;
                case 31: style.Colors31 = expected; break;
                case 32: style.Colors32 = expected; break;
                case 33: style.Colors33 = expected; break;
                case 34: style.Colors34 = expected; break;
                case 35: style.Colors35 = expected; break;
                case 36: style.Colors36 = expected; break;
                case 37: style.Colors37 = expected; break;
                case 38: style.Colors38 = expected; break;
                case 39: style.Colors39 = expected; break;
                case 40: style.Colors40 = expected; break;
                case 41: style.Colors41 = expected; break;
                case 42: style.Colors42 = expected; break;
                case 43: style.Colors43 = expected; break;
                case 44: style.Colors44 = expected; break;
                case 45: style.Colors45 = expected; break;
                case 46: style.Colors46 = expected; break;
                case 47: style.Colors47 = expected; break;
                case 48: style.Colors48 = expected; break;
                case 49: style.Colors49 = expected; break;
                case 50: style.Colors50 = expected; break;
                case 51: style.Colors51 = expected; break;
                case 52: style.Colors52 = expected; break;
                case 53: style.Colors53 = expected; break;
                case 54: style.Colors54 = expected; break;
            }

            Assert.Equal(expected, style[index]);
        }

        /// <summary>
        /// Tests that indexer set every index should set correct color
        /// </summary>
        /// <param name="index">The index</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(30)]
        [InlineData(31)]
        [InlineData(32)]
        [InlineData(33)]
        [InlineData(34)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(38)]
        [InlineData(39)]
        [InlineData(40)]
        [InlineData(41)]
        [InlineData(42)]
        [InlineData(43)]
        [InlineData(44)]
        [InlineData(45)]
        [InlineData(46)]
        [InlineData(47)]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(50)]
        [InlineData(51)]
        [InlineData(52)]
        [InlineData(53)]
        [InlineData(54)]
        public void Indexer_Set_EveryIndex_ShouldSetCorrectColor(int index)
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(index * 0.01f, index * 0.02f, index * 0.03f, index * 0.04f);

            style[index] = expected;

            switch (index)
            {
                case 0: Assert.Equal(expected, style.Colors0); break;
                case 1: Assert.Equal(expected, style.Colors1); break;
                case 2: Assert.Equal(expected, style.Colors2); break;
                case 3: Assert.Equal(expected, style.Colors3); break;
                case 4: Assert.Equal(expected, style.Colors4); break;
                case 5: Assert.Equal(expected, style.Colors5); break;
                case 6: Assert.Equal(expected, style.Colors6); break;
                case 7: Assert.Equal(expected, style.Colors7); break;
                case 8: Assert.Equal(expected, style.Colors8); break;
                case 9: Assert.Equal(expected, style.Colors9); break;
                case 10: Assert.Equal(expected, style.Colors10); break;
                case 11: Assert.Equal(expected, style.Colors11); break;
                case 12: Assert.Equal(expected, style.Colors12); break;
                case 13: Assert.Equal(expected, style.Colors13); break;
                case 14: Assert.Equal(expected, style.Colors14); break;
                case 15: Assert.Equal(expected, style.Colors15); break;
                case 16: Assert.Equal(expected, style.Colors16); break;
                case 17: Assert.Equal(expected, style.Colors17); break;
                case 18: Assert.Equal(expected, style.Colors18); break;
                case 19: Assert.Equal(expected, style.Colors19); break;
                case 20: Assert.Equal(expected, style.Colors20); break;
                case 21: Assert.Equal(expected, style.Colors21); break;
                case 22: Assert.Equal(expected, style.Colors22); break;
                case 23: Assert.Equal(expected, style.Colors23); break;
                case 24: Assert.Equal(expected, style.Colors24); break;
                case 25: Assert.Equal(expected, style.Colors25); break;
                case 26: Assert.Equal(expected, style.Colors26); break;
                case 27: Assert.Equal(expected, style.Colors27); break;
                case 28: Assert.Equal(expected, style.Colors28); break;
                case 29: Assert.Equal(expected, style.Colors29); break;
                case 30: Assert.Equal(expected, style.Colors30); break;
                case 31: Assert.Equal(expected, style.Colors31); break;
                case 32: Assert.Equal(expected, style.Colors32); break;
                case 33: Assert.Equal(expected, style.Colors33); break;
                case 34: Assert.Equal(expected, style.Colors34); break;
                case 35: Assert.Equal(expected, style.Colors35); break;
                case 36: Assert.Equal(expected, style.Colors36); break;
                case 37: Assert.Equal(expected, style.Colors37); break;
                case 38: Assert.Equal(expected, style.Colors38); break;
                case 39: Assert.Equal(expected, style.Colors39); break;
                case 40: Assert.Equal(expected, style.Colors40); break;
                case 41: Assert.Equal(expected, style.Colors41); break;
                case 42: Assert.Equal(expected, style.Colors42); break;
                case 43: Assert.Equal(expected, style.Colors43); break;
                case 44: Assert.Equal(expected, style.Colors44); break;
                case 45: Assert.Equal(expected, style.Colors45); break;
                case 46: Assert.Equal(expected, style.Colors46); break;
                case 47: Assert.Equal(expected, style.Colors47); break;
                case 48: Assert.Equal(expected, style.Colors48); break;
                case 49: Assert.Equal(expected, style.Colors49); break;
                case 50: Assert.Equal(expected, style.Colors50); break;
                case 51: Assert.Equal(expected, style.Colors51); break;
                case 52: Assert.Equal(expected, style.Colors52); break;
                case 53: Assert.Equal(expected, style.Colors53); break;
                case 54: Assert.Equal(expected, style.Colors54); break;
            }
        }

        /// <summary>
        /// Tests that indexer get negative index should throw
        /// </summary>
        [Fact]
        public void Indexer_Get_NegativeIndex_ShouldThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            Assert.Throws<CustomIndexOutOfRangeException>(() => style[-1]);
        }

        /// <summary>
        /// Tests that indexer get index out of range should throw
        /// </summary>
        [Fact]
        public void Indexer_Get_IndexOutOfRange_ShouldThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            Assert.Throws<CustomIndexOutOfRangeException>(() => style[55]);
        }

        /// <summary>
        /// Tests that indexer set negative index should throw
        /// </summary>
        [Fact]
        public void Indexer_Set_NegativeIndex_ShouldThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            Assert.Throws<CustomIndexOutOfRangeException>(() => style[-1] = new Vector4F());
        }

        /// <summary>
        /// Tests that indexer set index out of range should throw
        /// </summary>
        [Fact]
        public void Indexer_Set_IndexOutOfRange_ShouldThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            Assert.Throws<CustomIndexOutOfRangeException>(() => style[55] = new Vector4F());
        }

        /// <summary>
        /// Scales the all sizes should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void ScaleAllSizes_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(1.5f);
        }

        /// <summary>
        /// Scales the all sizes with zero should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void ScaleAllSizes_WithZero_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(0.0f);
        }

        /// <summary>
        /// Scales the all sizes with negative should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void ScaleAllSizes_WithNegative_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(-1.0f);
        }
    }
}
