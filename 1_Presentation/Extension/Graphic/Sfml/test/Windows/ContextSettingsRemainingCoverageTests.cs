// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextSettingsRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The context settings remaining coverage tests class
    /// </summary>
    public class ContextSettingsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that attributes enum has correct values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Attributes_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int) ContextSettings.Attributes.None);
            Assert.Equal(1, (int) ContextSettings.Attributes.Core);
            Assert.Equal(4, (int) ContextSettings.Attributes.Debug);
        }

        /// <summary>
        ///     Tests that two parameter constructor assigns depth and stencil bits
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void TwoParameterConstructor_AssignsDepthAndStencilBits()
        {
            ContextSettings settings = new ContextSettings(24u, 8u);

            Assert.Equal(24u, settings.DepthBits);
            Assert.Equal(8u, settings.StencilBits);
            Assert.Equal(0u, settings.AntialiasingLevel);
            Assert.Equal(2u, settings.MajorVersion);
            Assert.Equal(0u, settings.MinorVersion);
            Assert.Equal(ContextSettings.Attributes.None, settings.AttributeFlags);
            Assert.False(settings.SRgbCapable);
        }

        /// <summary>
        ///     Tests that three parameter constructor assigns antialiasing level
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ThreeParameterConstructor_AssignsAntialiasingLevel()
        {
            ContextSettings settings = new ContextSettings(24u, 8u, 4u);

            Assert.Equal(24u, settings.DepthBits);
            Assert.Equal(8u, settings.StencilBits);
            Assert.Equal(4u, settings.AntialiasingLevel);
            Assert.Equal(2u, settings.MajorVersion);
            Assert.Equal(0u, settings.MinorVersion);
        }

        /// <summary>
        ///     Tests that full constructor assigns all fields
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FullConstructor_AssignsAllFields()
        {
            ContextSettings settings = new ContextSettings(32u, 16u, 8u, 4u, 6u, ContextSettings.Attributes.Core | ContextSettings.Attributes.Debug, true);

            Assert.Equal(32u, settings.DepthBits);
            Assert.Equal(16u, settings.StencilBits);
            Assert.Equal(8u, settings.AntialiasingLevel);
            Assert.Equal(4u, settings.MajorVersion);
            Assert.Equal(6u, settings.MinorVersion);
            Assert.Equal(ContextSettings.Attributes.Core | ContextSettings.Attributes.Debug, settings.AttributeFlags);
            Assert.True(settings.SRgbCapable);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            ContextSettings settings = new ContextSettings(24u, 8u, 4u, 3u, 3u, ContextSettings.Attributes.Core, true);

            string str = settings.ToString();

            Assert.Contains("DepthBits(24)", str);
            Assert.Contains("StencilBits(8)", str);
            Assert.Contains("AntialiasingLevel(4)", str);
            Assert.Contains("MajorVersion(3)", str);
            Assert.Contains("MinorVersion(3)", str);
            Assert.Contains("AttributeFlags(Core)", str);
        }
    }
}
