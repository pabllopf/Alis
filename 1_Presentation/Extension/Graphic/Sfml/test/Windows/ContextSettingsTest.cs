// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextSettingsTest.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Unit tests for the ContextSettings struct.
    /// </summary>
    public class ContextSettingsTest
    {
        /// <summary>
        ///     Tests the 2-parameter constructor.
        /// </summary>
        [Fact]
        public void Constructor_TwoParams_AssignsFields()
        {
            ContextSettings cs = new ContextSettings(24, 8);
            Assert.Equal(24u, cs.DepthBits);
            Assert.Equal(8u, cs.StencilBits);
            Assert.Equal(0u, cs.AntialiasingLevel);
            Assert.Equal(2u, cs.MajorVersion);
            Assert.Equal(0u, cs.MinorVersion);
            Assert.Equal(ContextSettings.Attributes.None, cs.AttributeFlags);
            Assert.False(cs.SRgbCapable);
        }

        /// <summary>
        ///     Tests the 3-parameter constructor with antialiasing.
        /// </summary>
        [Fact]
        public void Constructor_ThreeParams_AssignsFields()
        {
            ContextSettings cs = new ContextSettings(24, 8, 4);
            Assert.Equal(24u, cs.DepthBits);
            Assert.Equal(8u, cs.StencilBits);
            Assert.Equal(4u, cs.AntialiasingLevel);
            Assert.Equal(2u, cs.MajorVersion);
            Assert.Equal(0u, cs.MinorVersion);
        }
    }
}
