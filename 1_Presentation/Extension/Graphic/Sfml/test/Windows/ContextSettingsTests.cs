// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextSettingsTests.cs
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
    ///     Unit tests for the ContextSettings struct constructors and fields.
    /// </summary>
    public class ContextSettingsTests
    {
        /// <summary>
        ///     Tests that default constructed struct has zeroed fields and none attributes.
        /// </summary>
        [Fact]
        public void Default_Constructor_ZeroesFields()
        {
            ContextSettings cs = default;

            Assert.Equal(0u, cs.DepthBits);
            Assert.Equal(0u, cs.StencilBits);
            Assert.Equal(0u, cs.AntialiasingLevel);
            Assert.Equal(0u, cs.MajorVersion);
            Assert.Equal(0u, cs.MinorVersion);
            Assert.Equal(ContextSettings.Attributes.None, cs.AttributeFlags);
            Assert.False(cs.SRgbCapable);
        }

        /// <summary>
        ///     Tests that the two parameter constructor assigns depth and stencil bits.
        /// </summary>
        [Fact]
        public void Constructor_TwoParams_AssignsDepthAndStencil()
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
        ///     Tests that the three parameter constructor assigns antialiasing level.
        /// </summary>
        [Fact]
        public void Constructor_ThreeParams_AssignsAntialiasing()
        {
            ContextSettings cs = new ContextSettings(24, 8, 4);

            Assert.Equal(24u, cs.DepthBits);
            Assert.Equal(8u, cs.StencilBits);
            Assert.Equal(4u, cs.AntialiasingLevel);
            Assert.Equal(2u, cs.MajorVersion);
            Assert.Equal(0u, cs.MinorVersion);
        }

        /// <summary>
        ///     Tests that the seven parameter constructor assigns all fields.
        /// </summary>
        [Fact]
        public void Constructor_SevenParams_AssignsAllFields()
        {
            ContextSettings cs = new ContextSettings(32, 8, 8, 4, 5, ContextSettings.Attributes.Core | ContextSettings.Attributes.Debug, true);

            Assert.Equal(32u, cs.DepthBits);
            Assert.Equal(8u, cs.StencilBits);
            Assert.Equal(8u, cs.AntialiasingLevel);
            Assert.Equal(4u, cs.MajorVersion);
            Assert.Equal(5u, cs.MinorVersion);
            Assert.Equal(ContextSettings.Attributes.Core | ContextSettings.Attributes.Debug, cs.AttributeFlags);
            Assert.True(cs.SRgbCapable);
        }

        /// <summary>
        ///     Tests that seven parameter constructor with none attributes keeps none.
        /// </summary>
        [Fact]
        public void Constructor_SevenParams_WithNoneAttributes_KeepsNone()
        {
            ContextSettings cs = new ContextSettings(16, 4, 2, 3, 1, ContextSettings.Attributes.None, false);

            Assert.Equal(ContextSettings.Attributes.None, cs.AttributeFlags);
            Assert.False(cs.SRgbCapable);
        }

        /// <summary>
        ///     Tests that fields can be mutated directly after construction.
        /// </summary>
        [Fact]
        public void Fields_CanBeMutatedDirectly()
        {
            ContextSettings cs = new ContextSettings(24, 8);

            cs.DepthBits = 48;
            cs.StencilBits = 16;
            cs.AntialiasingLevel = 8;
            cs.MajorVersion = 4;
            cs.MinorVersion = 6;
            cs.AttributeFlags = ContextSettings.Attributes.Debug;
            cs.SRgbCapable = true;

            Assert.Equal(48u, cs.DepthBits);
            Assert.Equal(16u, cs.StencilBits);
            Assert.Equal(8u, cs.AntialiasingLevel);
            Assert.Equal(4u, cs.MajorVersion);
            Assert.Equal(6u, cs.MinorVersion);
            Assert.Equal(ContextSettings.Attributes.Debug, cs.AttributeFlags);
            Assert.True(cs.SRgbCapable);
        }

        /// <summary>
        ///     Tests that ToString includes all component names.
        /// </summary>
        [Fact]
        public void ToString_IncludesComponentNames()
        {
            ContextSettings cs = new ContextSettings(24, 8);

            string str = cs.ToString();

            Assert.Contains("DepthBits", str);
            Assert.Contains("StencilBits", str);
            Assert.Contains("AntialiasingLevel", str);
            Assert.Contains("MajorVersion", str);
            Assert.Contains("MinorVersion", str);
            Assert.Contains("AttributeFlags", str);
        }

        /// <summary>
        ///     Tests that ToString includes the actual field values.
        /// </summary>
        [Fact]
        public void ToString_IncludesFieldValues()
        {
            ContextSettings cs = new ContextSettings(32, 8, 8, 4, 5, ContextSettings.Attributes.Core, true);

            string str = cs.ToString();

            Assert.Contains("32", str);
            Assert.Contains("8", str);
            Assert.Contains("4", str);
            Assert.Contains("5", str);
            Assert.Contains("Core", str);
        }

        /// <summary>
        ///     Tests that attribute enum values are correctly defined.
        /// </summary>
        [Fact]
        public void Attributes_Enum_HasExpectedValues()
        {
            Assert.Equal(0, (int) ContextSettings.Attributes.None);
            Assert.Equal(1, (int) ContextSettings.Attributes.Core);
            Assert.Equal(4, (int) ContextSettings.Attributes.Debug);
        }
    }
}
