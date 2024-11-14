// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawFlagsTest.cs
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

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im draw flags test class
    /// </summary>
    public class ImDrawFlagsTest
    {
        /// <summary>
        ///     Tests that none should have correct value
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.None;

            // Assert
            Assert.Equal(0, (int) flag);
        }

        /// <summary>
        ///     Tests that closed should have correct value
        /// </summary>
        [Fact]
        public void Closed_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.Closed;

            // Assert
            Assert.Equal(1, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners top left should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersTopLeft_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersTopLeft;

            // Assert
            Assert.Equal(16, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners top right should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersTopRight_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersTopRight;

            // Assert
            Assert.Equal(32, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners bottom left should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersBottomLeft_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersBottomLeft;

            // Assert
            Assert.Equal(64, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners bottom right should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersBottomRight_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersBottomRight;

            // Assert
            Assert.Equal(128, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners none should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersNone_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersNone;

            // Assert
            Assert.Equal(256, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners top should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersTop_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersTop;

            // Assert
            Assert.Equal(48, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners bottom should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersBottom_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersBottom;

            // Assert
            Assert.Equal(192, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners left should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersLeft_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersLeft;

            // Assert
            Assert.Equal(80, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners right should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersRight_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersRight;

            // Assert
            Assert.Equal(160, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners all should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersAll_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersAll;

            // Assert
            Assert.Equal(240, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners default should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersDefault_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersDefault;

            // Assert
            Assert.Equal(240, (int) flag);
        }

        /// <summary>
        ///     Tests that round corners mask should have correct value
        /// </summary>
        [Fact]
        public void RoundCornersMask_ShouldHaveCorrectValue()
        {
            // Act
            ImDrawFlags flag = ImDrawFlags.RoundCornersMask;

            // Assert
            Assert.Equal(496, (int) flag);
        }
    }
}