// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacConstants.cs
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

#if osxarm64 || osxarm || osxx64 || osx
namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Constantes y structs para la plataforma Mac
    /// </summary>
    internal static class MacConstants
    {
        /// <summary>
        ///     The ns window style mask titled
        /// </summary>
        public const ulong NsWindowStyleMaskTitled = 1UL << 0;

        /// <summary>
        ///     The ns window style mask closable
        /// </summary>
        public const ulong NsWindowStyleMaskClosable = 1UL << 1;

        /// <summary>
        ///     The ns window style mask miniaturizable
        /// </summary>
        public const ulong NsWindowStyleMaskMiniaturizable = 1UL << 2;

        /// <summary>
        ///     The ns window style mask resizable
        /// </summary>
        public const ulong NsWindowStyleMaskResizable = 1UL << 3;

        /// <summary>
        ///     The ns backing store buffered
        /// </summary>
        public const ulong NsBackingStoreBuffered = 2;

        /// <summary>
        ///     The ns application activation policy regular
        /// </summary>
        public const long NsApplicationActivationPolicyRegular = 0;

        /// <summary>
        ///     The ns open glpfa open gl profile
        /// </summary>
        public const int NsOpenGlpfaOpenGlProfile = 99;

        /// <summary>
        ///     The ns open gl profile version 32 core
        /// </summary>
        public const int NsOpenGlProfileVersion32Core = 0x3200;

        /// <summary>
        ///     The ns open glpfa double buffer
        /// </summary>
        public const int NsOpenGlpfaDoubleBuffer = 5;

        /// <summary>
        ///     The ns open glpfa color size
        /// </summary>
        public const int NsOpenGlpfaColorSize = 8;

        /// <summary>
        ///     The ns open glpfa depth size
        /// </summary>
        public const int NsOpenGlpfaDepthSize = 12;

        /// <summary>
        ///     The cf string encoding utf
        /// </summary>
        public const uint KCfStringEncodingUtf8 = 0x08000100;
    }
}

#endif