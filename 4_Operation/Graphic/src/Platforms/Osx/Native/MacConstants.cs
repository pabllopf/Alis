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

#if OSX
namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Constantes y structs para la plataforma Mac
    /// </summary>
    internal static class MacConstants
    {
        public const ulong NsWindowStyleMaskTitled = 1UL << 0;
        public const ulong NsWindowStyleMaskClosable = 1UL << 1;
        public const ulong NsWindowStyleMaskMiniaturizable = 1UL << 2;
        public const ulong NsWindowStyleMaskResizable = 1UL << 3;
        public const ulong NsBackingStoreBuffered = 2;
        public const long NsApplicationActivationPolicyRegular = 0;
        public const int NsOpenGlpfaOpenGlProfile = 99;
        public const int NsOpenGlProfileVersion32Core = 0x3200;
        public const int NsOpenGlpfaDoubleBuffer = 5;
        public const int NsOpenGlpfaColorSize = 8;
        public const int NsOpenGlpfaDepthSize = 12;
        public const uint KCfStringEncodingUtf8 = 0x08000100;
    }
}
#endif