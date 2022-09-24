// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextSettings.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Structure defining the creation settings of OpenGL contexts
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct ContextSettings
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Enumeration of the context attribute flags
        /// </summary>
        ////////////////////////////////////////////////////////////
        [Flags]
        public enum Attribute
        {
            /// <summary>Non-debug, compatibility context (this and the core attribute are mutually exclusive)</summary>
            Default = 0,

            /// <summary>Core attribute</summary>
            Core = 1 << 0,

            /// <summary>Debug attribute</summary>
            Debug = 1 << 2
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the settings from depth / stencil bits
        /// </summary>
        /// <param name="depthBits">Depth buffer bits</param>
        /// <param name="stencilBits">Stencil buffer bits</param>
        ////////////////////////////////////////////////////////////
        public ContextSettings(uint depthBits, uint stencilBits) :
            this(depthBits, stencilBits, 0)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the settings from depth / stencil bits and antialiasing level
        /// </summary>
        /// <param name="depthBits">Depth buffer bits</param>
        /// <param name="stencilBits">Stencil buffer bits</param>
        /// <param name="antialiasingLevel">Antialiasing level</param>
        ////////////////////////////////////////////////////////////
        public ContextSettings(uint depthBits, uint stencilBits, uint antialiasingLevel) :
            this(depthBits, stencilBits, antialiasingLevel, 2, 0, Attribute.Default, false)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the settings from depth / stencil bits and antialiasing level
        /// </summary>
        /// <param name="depthBits">Depth buffer bits</param>
        /// <param name="stencilBits">Stencil buffer bits</param>
        /// <param name="antialiasingLevel">Antialiasing level</param>
        /// <param name="majorVersion">Major number of the context version</param>
        /// <param name="minorVersion">Minor number of the context version</param>
        /// <param name="attributes">Attribute flags of the context</param>
        /// <param name="sRgbCapable">sRGB capability of the context</param>
        ////////////////////////////////////////////////////////////
        public ContextSettings(uint depthBits, uint stencilBits, uint antialiasingLevel, uint majorVersion,
            uint minorVersion, Attribute attributes, bool sRgbCapable)
        {
            DepthBits = depthBits;
            StencilBits = stencilBits;
            AntialiasingLevel = antialiasingLevel;
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            AttributeFlags = attributes;
            SRgbCapable = sRgbCapable;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[ContextSettings]" +
                                             " DepthBits(" + DepthBits + ")" +
                                             " StencilBits(" + StencilBits + ")" +
                                             " AntialiasingLevel(" + AntialiasingLevel + ")" +
                                             " MajorVersion(" + MajorVersion + ")" +
                                             " MinorVersion(" + MinorVersion + ")" +
                                             " AttributeFlags(" + AttributeFlags + ")";

        /// <summary>Depth buffer bits (0 is disabled)</summary>
        public uint DepthBits;

        /// <summary>Stencil buffer bits (0 is disabled)</summary>
        public uint StencilBits;

        /// <summary>Antialiasing level (0 is disabled)</summary>
        public uint AntialiasingLevel;

        /// <summary>Major number of the context version</summary>
        public uint MajorVersion;

        /// <summary>Minor number of the context version</summary>
        public uint MinorVersion;

        /// <summary>The attribute flags to create the context with</summary>
        public Attribute AttributeFlags;

        /// <summary>Whether the context framebuffer is sRGB capable</summary>
        public bool SRgbCapable;
    }
}