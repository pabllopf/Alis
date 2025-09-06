// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImColorTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im color test class
    /// </summary>
    public class ImColorTest
    {
        /// <summary>
        ///     Tests that value should be initialized correctly
        /// </summary>
        [Fact]
        public void Value_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImColor color = new ImColor {Value = new Vector4F(1.0f, 0.5f, 0.25f, 1.0f)};

            // Act
            Vector4F value = color.Value;

            // Assert
            Assert.Equal(new Vector4F(1.0f, 0.5f, 0.25f, 1.0f), value);
        }

        /// <summary>
        ///     Tests that set hsv should set correct values
        /// </summary>
        [Fact]
        public void SetHsv_ShouldSetCorrectValues()
        {
            // Arrange
            ImColor color = new ImColor();

            // Act
            Assert.Throws<DllNotFoundException>(() => color.SetHsv(0.5f, 0.5f, 0.5f));
        }

        /// <summary>
        ///     Tests that set hsv with alpha should set correct values
        /// </summary>
        [Fact]
        public void SetHsv_WithAlpha_ShouldSetCorrectValues()
        {
            // Arrange
            ImColor color = new ImColor();

            // Act
            Assert.Throws<DllNotFoundException>(() => color.SetHsv(0.5f, 0.5f, 0.5f, 0.8f));
        }

        /// <summary>
        ///     Tests that value should set and get correctly
        /// </summary>
        [Fact]
        public void Value_Should_SetAndGetCorrectly()
        {
            ImColor color = new ImColor();
            Vector4F value = new Vector4F(1, 2, 3, 4);
            color.Value = value;
            Assert.Equal(value, color.Value);
        }

        /// <summary>
        ///     Tests that set hsv should set correct values
        /// </summary>
        [Fact]
        public void SetHsv_Should_SetCorrectValues()
        {
            ImColor color = new ImColor();
            Assert.Throws<DllNotFoundException>(() => color.SetHsv(0.5f, 0.5f, 0.5f));
        }

        /// <summary>
        ///     Tests that set hsv with alpha should set correct values
        /// </summary>
        [Fact]
        public void SetHsv_WithAlpha_Should_SetCorrectValues()
        {
            ImColor color = new ImColor();
            Assert.Throws<DllNotFoundException>(() => color.SetHsv(0.5f, 0.5f, 0.5f, 0.5f));
        }

        /// <summary>
        ///     Tests that v 3 set hsv should set correct values
        /// </summary>
        [Fact]
        public void V3_SetHsv_Should_SetCorrectValues()
        {
            ImColor color = new ImColor();
            Assert.Throws<DllNotFoundException>(() => color.SetHsv(0.5f, 0.5f, 0.5f));
        }

        /// <summary>
        ///     Tests that v 3 set hsv with alpha should set correct values
        /// </summary>
        [Fact]
        public void V3_SetHsv_WithAlpha_Should_SetCorrectValues()
        {
            ImColor color = new ImColor();
            Assert.Throws<DllNotFoundException>(() => color.SetHsv(0.5f, 0.5f, 0.5f, 0.5f));
        }
    }
}