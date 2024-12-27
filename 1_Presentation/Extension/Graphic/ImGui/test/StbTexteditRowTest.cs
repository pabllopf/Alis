// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditRowTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The stb textedit row test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class StbTexteditRowTest 
    {
        /// <summary>
        ///     Tests that x 0 should be initialized
        /// </summary>
        [Fact]
        public void X0_ShouldBeInitialized()
        {
            StbTexteditRow row = new StbTexteditRow();
            Assert.Equal(0f, row.X0);
        }

        /// <summary>
        ///     Tests that x 1 should be initialized
        /// </summary>
        [Fact]
        public void X1_ShouldBeInitialized()
        {
            StbTexteditRow row = new StbTexteditRow();
            Assert.Equal(0f, row.X1);
        }

        /// <summary>
        ///     Tests that baseline y delta should be initialized
        /// </summary>
        [Fact]
        public void BaselineYDelta_ShouldBeInitialized()
        {
            StbTexteditRow row = new StbTexteditRow();
            Assert.Equal(0f, row.BaselineYDelta);
        }

        /// <summary>
        ///     Tests that ymin should be initialized
        /// </summary>
        [Fact]
        public void Ymin_ShouldBeInitialized()
        {
            StbTexteditRow row = new StbTexteditRow();
            Assert.Equal(0f, row.Ymin);
        }

        /// <summary>
        ///     Tests that ymax should be initialized
        /// </summary>
        [Fact]
        public void Ymax_ShouldBeInitialized()
        {
            StbTexteditRow row = new StbTexteditRow();
            Assert.Equal(0f, row.Ymax);
        }

        /// <summary>
        ///     Tests that num chars should be initialized
        /// </summary>
        [Fact]
        public void NumChars_ShouldBeInitialized()
        {
            StbTexteditRow row = new StbTexteditRow();
            Assert.Equal(0, row.NumChars);
        }

        /// <summary>
        ///     Tests that x 0 should set and get correctly
        /// </summary>
        [Fact]
        public void X0_Should_SetAndGetCorrectly()
        {
            StbTexteditRow row = new StbTexteditRow();
            row.X0 = 1.0f;
            Assert.Equal(1.0f, row.X0);
        }

        /// <summary>
        ///     Tests that x 1 should set and get correctly
        /// </summary>
        [Fact]
        public void X1_Should_SetAndGetCorrectly()
        {
            StbTexteditRow row = new StbTexteditRow();
            row.X1 = 2.0f;
            Assert.Equal(2.0f, row.X1);
        }

        /// <summary>
        ///     Tests that baseline y delta should set and get correctly
        /// </summary>
        [Fact]
        public void BaselineYDelta_Should_SetAndGetCorrectly()
        {
            StbTexteditRow row = new StbTexteditRow();
            row.BaselineYDelta = 3.0f;
            Assert.Equal(3.0f, row.BaselineYDelta);
        }

        /// <summary>
        ///     Tests that ymin should set and get correctly
        /// </summary>
        [Fact]
        public void Ymin_Should_SetAndGetCorrectly()
        {
            StbTexteditRow row = new StbTexteditRow();
            row.Ymin = 4.0f;
            Assert.Equal(4.0f, row.Ymin);
        }

        /// <summary>
        ///     Tests that ymax should set and get correctly
        /// </summary>
        [Fact]
        public void Ymax_Should_SetAndGetCorrectly()
        {
            StbTexteditRow row = new StbTexteditRow();
            row.Ymax = 5.0f;
            Assert.Equal(5.0f, row.Ymax);
        }

        /// <summary>
        ///     Tests that num chars should set and get correctly
        /// </summary>
        [Fact]
        public void NumChars_Should_SetAndGetCorrectly()
        {
            StbTexteditRow row = new StbTexteditRow();
            row.NumChars = 6;
            Assert.Equal(6, row.NumChars);
        }
    }
}