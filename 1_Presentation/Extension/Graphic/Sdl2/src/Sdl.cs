// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sdl2.Delegates;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Graphic.Sdl2
{
    /// <summary>
    ///     The sdl class
    /// </summary>
    public static class Sdl
    {
        /// <summary>
        ///     The sdl text editing event text size
        /// </summary>
        public const int TextEditingEventTextSize = 32;

        /// <summary>
        ///     The sdl text input event text size
        /// </summary>
        public const int TextInputEventTextSize = 32;

        /// <summary>
        ///     The sdl query
        /// </summary>
        public const int Query = -1;

        /// <summary>
        ///     The sdl ignore
        /// </summary>
        public const int Ignore = 0;

        /// <summary>
        ///     The sdl disable
        /// </summary>
        public const int Disable = 0;

        /// <summary>
        ///     The sdl enable
        /// </summary>
        public const int Enable = 1;

        /// <summary>
        ///     The sdl scancode mask
        /// </summary>
        public const int KScancodeMask = 1 << 30;

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public const uint ButtonLeft = 1;

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public const uint ButtonMiddle = 2;

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public const uint ButtonRight = 3;

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public const uint ButtonX1 = 4;

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public const uint ButtonX2 = 5;

        /// <summary>
        ///     The sdl audio mask bit size
        /// </summary>
        public const ushort AudioMaskBitSize = 0xFF;

        /// <summary>
        ///     The sdl audio mask datatype
        /// </summary>
        public const ushort AudioMaskDatatype = 1 << 8;

        /// <summary>
        ///     The sdl audio mask endian
        /// </summary>
        public const ushort AudioMaskEndian = 1 << 12;

        /// <summary>
        ///     The sdl audio mask signed
        /// </summary>
        public const ushort AudioMaskSigned = 1 << 15;

        /// <summary>
        ///     The audio u8
        /// </summary>
        public const ushort AudioU8 = 0x0008;

        /// <summary>
        ///     The audio s8
        /// </summary>
        public const ushort AudioS8 = 0x8008;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16Lsb = 0x0010;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16Lsb = 0x8010;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public const ushort AudioU16Msb = 0x1010;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public const ushort AudioS16Msb = 0x9010;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16 = AudioU16Lsb;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16 = AudioS16Lsb;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32Lsb = 0x8020;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public const ushort AudioS32Msb = 0x9020;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32 = AudioS32Lsb;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32Lsb = 0x8120;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public const ushort AudioF32Msb = 0x9120;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32 = AudioF32Lsb;

        /// <summary>
        ///     The sdl mix max volume
        /// </summary>
        public const int MixMaxVolume = 128;

        /// <summary>
        ///     The sdl android external storage read
        /// </summary>
        public const int AndroidExternalStorageRead = 0x01;

        /// <summary>
        ///     The sdl android external storage write
        /// </summary>
        public const int AndroidExternalStorageWrite = 0x02;

        /// <summary>
        ///     The sdl pixel format unknown
        /// </summary>
        public static readonly uint PixelFormatUnknown = 0;

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint PixelFormatIndex1Lsb = SdlDefinePixelFormat(TypePixel.TypeIndex1, (uint) BitmapOrder.BitMapOrder4321, 0, 1, 0);

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint PixelFormatIndex1Msb = SdlDefinePixelFormat(TypePixel.TypeIndex1, (uint) BitmapOrder.BitMapOrder1234, 0, 1, 0);

        /// <summary>
        ///     The sdl bit map order 4321
        /// </summary>
        public static readonly uint PixelFormatIndex4Lsb = SdlDefinePixelFormat(TypePixel.TypeIndex4, (uint) BitmapOrder.BitMapOrder4321, 0, 4, 0);

        /// <summary>
        ///     The sdl bit map order 1234
        /// </summary>
        public static readonly uint PixelFormatIndex4Msb = SdlDefinePixelFormat(TypePixel.TypeIndex4, (uint) BitmapOrder.BitMapOrder1234, 0, 4, 0);

        /// <summary>
        ///     The sdl pixel TypePixel index8
        /// </summary>
        public static readonly uint PixelFormatIndex8 = SdlDefinePixelFormat(TypePixel.TypeIndex8, 0, 0, 8, 1);

        /// <summary>
        ///     The sdl packed layout 332
        /// </summary>
        public static readonly uint PixelFormatRgb332 = SdlDefinePixelFormat(TypePixel.TypePacked8, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout332, 8, 1);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint GlFormatXRgb444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout4444, 12, 2);

        /// <summary>
        ///     The sdl pixel format x rgb 444
        /// </summary>
        public static readonly uint PixelFormatRgb444 = GlFormatXRgb444;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint GlFormatXBgr444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout4444, 12, 2);

        /// <summary>
        ///     The sdl pixel format x bgr 444
        /// </summary>
        public static readonly uint PixelFormatBgr444 = GlFormatXBgr444;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint GlFormatXRgb1555 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout1555, 15, 2);

        /// <summary>
        ///     The sdl pixel format xrgb1555
        /// </summary>
        public static readonly uint PixelFormatRgb555 = GlFormatXRgb1555;

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint GlFormatXBgr1555 = SdlDefinePixelFormat(TypePixel.TypeIndex1, (uint) BitmapOrder.BitMapOrder4321, PackedLayout.PackedLayout1555, 15, 2);

        /// <summary>
        ///     The sdl pixel format xbgr1555
        /// </summary>
        public static readonly uint PixelFormatBgr555 = GlFormatXBgr1555;

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatArgb4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatRgba4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatABgr4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 4444
        /// </summary>
        public static readonly uint PixelFormatBGra4444 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout4444, 16, 2);

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint PixelFormatArgb1555 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout1555, 16, 2);

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint PixelFormatRgba5551 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout5551, 16, 2);

        /// <summary>
        ///     The sdl packed layout 1555
        /// </summary>
        public static readonly uint PixelFormatABgr1555 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout1555, 16, 2);

        /// <summary>
        ///     The sdl packed layout 5551
        /// </summary>
        public static readonly uint PixelFormatBGra5551 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout5551, 16, 2);

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint PixelFormatRgb565 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout565, 16, 2);

        /// <summary>
        ///     The sdl packed layout 565
        /// </summary>
        public static readonly uint PixelFormatBgr565 = SdlDefinePixelFormat(TypePixel.TypePacked16, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout565, 16, 2);

        /// <summary>
        ///     The sdl array order rgb
        /// </summary>
        public static readonly uint PixelFormatRgb24 = SdlDefinePixelFormat(TypePixel.TypeArrayU8, (uint) ArrayOrder.SdlArrayOrderRgb, 0, 24, 3);

        /// <summary>
        ///     The sdl array order bgr
        /// </summary>
        public static readonly uint PixelFormatBgr24 = SdlDefinePixelFormat(TypePixel.TypeArrayU8, (uint) ArrayOrder.SdlArrayOrderBgr, 0, 24, 3);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint GlFormatXRgb888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderXRgb, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl pixel format x rgb 888
        /// </summary>
        public static readonly uint PixelFormatRgb888 = GlFormatXRgb888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatRgbX8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderRGbx, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint GlFormatXBgr888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderXBgr, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl pixel format x bgr 888
        /// </summary>
        public static readonly uint PixelFormatBgr888 = GlFormatXBgr888;

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatBGrx8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderBGrx, PackedLayout.PackedLayout8888, 24, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatArgb8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatRgba8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderRGba, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatABgr8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderABgr, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 8888
        /// </summary>
        public static readonly uint PixelFormatB8888 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderBGra, PackedLayout.PackedLayout8888, 32, 4);

        /// <summary>
        ///     The sdl packed layout 2101010
        /// </summary>
        public static readonly uint PixelFormatArgb2101010 = SdlDefinePixelFormat(TypePixel.TypePacked32, (uint) PackedOrder.PackedOrderARgb, PackedLayout.PackedLayout2101010, 32, 4);

        /// <summary>
        ///     The sdl define pixel four cc
        /// </summary>
        public static readonly uint PixelFormatYv12 = SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) '1', (byte) '2');

        /// <summary>
        ///     The sdl define pixel four cc
        /// </summary>
        public static readonly uint PixelFormatIy = SdlDefinePixelFourcc((byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V');

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public static readonly uint GlButtonLMask = Button(ButtonLeft);

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public static readonly uint GlButtonMMask = Button(ButtonMiddle);

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public static readonly uint GlButtonRMask = Button(ButtonRight);

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public static readonly uint GlButtonX1Mask = Button(ButtonX1);

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public static readonly uint GlButtonX2Mask = Button(ButtonX2);

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public static readonly ushort GlAudioU16Sys = BitConverter.IsLittleEndian ? AudioU16Lsb : AudioU16Msb;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort GlAudioS16Sys = BitConverter.IsLittleEndian ? AudioS16Lsb : AudioS16Msb;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public static readonly ushort GlAudioS32Sys = BitConverter.IsLittleEndian ? AudioS32Lsb : AudioS32Msb;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public static readonly ushort GlAudioF32Sys = BitConverter.IsLittleEndian ? AudioF32Lsb : AudioF32Msb;

        /// <summary>
        ///     The sdl patch level
        /// </summary>
        public static int GetGlCompiledVersion() => 2 * 1000 + 0 * 100 + 18;

        /// <summary>
        ///     Sdl the fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        public static uint Fourcc(byte a, byte b, byte c, byte d) => (uint) (a | (b << 8) | (c << 16) | (d << 24));

        /// <summary>
        ///     Sdl the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        private static IntPtr RwFromFile(string file, string mode)
        {
            IntPtr result = NativeSdl.InternalRWFromFile(file, mode);

            return result;
        }

        /// <summary>
        ///     Sdl the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The result</returns>
        public static IntPtr LoadFile(string file, out IntPtr dataSize)
        {
            IntPtr result = NativeSdl.InternalLoadFile(file, out dataSize);

            return result;
        }

        /// <summary>
        ///     Sdl the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string GetError()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetError());

            return result;
        }

        /// <summary>
        ///     Sdl the set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void SetError(string fmtAndArgList)
        {
            NativeSdl.InternalSetError(fmtAndArgList);
        }

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        public static int Init(InitSettings flags)
        {
            int result = NativeSdl.InternalInit(flags);

            return result;
        }

        /// <summary>
        ///     Sdl the quit
        /// </summary>
        public static void Quit()
        {
            NativeSdl.InternalQuit();
        }

        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        public static uint WasInit(InitSettings flags)
        {
            uint result = NativeSdl.InternalWasInit(flags);

            return result;
        }

        /// <summary>
        ///     Clears the hints
        /// </summary>
        public static void ClearHints()
        {
            NativeSdl.InternalClearHints();
        }

        /// <summary>
        ///     Sdl the get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        public static string GetHint(string name)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetHint(name));

            return result;
        }

        /// <summary>
        ///     Sdl the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        public static bool SetHint(string name, string value)
        {
            bool result = NativeSdl.InternalSetHint(name, value);

            return result;
        }

        /// <summary>
        ///     Sdl the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        public static bool SetHintWithPriority(string name, string value, HintPriority priority)
        {
            bool result = NativeSdl.InternalSetHintWithPriority(name, value, priority);

            return result;
        }

        /// <summary>
        ///     Sdl the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        public static bool GetHintBoolean(string name, bool defaultValue)
        {
            bool result = NativeSdl.InternalGetHintBoolean(name, defaultValue);

            return result;
        }

        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        public static Version GetVersion() => new Version(2, 0, 18);

        /// <summary>
        ///     Sdl the window pos undefined display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosUndefinedDisplay(int x) => (int) (WindowPos.WindowPosUndefinedMask | (WindowPos) x);

        /// <summary>
        ///     Describes whether sdl window pos is undefined
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsUndefined(int x) => (x & 0xFFFF0000) == (long) WindowPos.WindowPosUndefinedMask;

        /// <summary>
        ///     Sdl the window pos centered display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosCenteredDisplay(int x) => (int) (WindowPos.WindowPosCenteredMask | (WindowPos) x);

        /// <summary>
        ///     Describes whether sdl window pos is centered
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsCentered(int x) => (x & 0xFFFF0000) == (long) WindowPos.WindowPosCenteredMask;

        /// <summary>
        ///     Sdl the create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateWindow(string title, int x, int y, int w, int h, WindowSettings flags)
        {
            IntPtr result = NativeSdl.InternalCreateWindow(title, x, y, w, h, flags);

            return result;
        }

        /// <summary>
        ///     Sdl the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        public static int CreateWindowAndRenderer(int width, int height, WindowSettings windowFlags, out IntPtr window, out IntPtr renderer) => NativeSdl.InternalCreateWindowAndRenderer(width, height, windowFlags, out window, out renderer);

        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void DestroyWindow(IntPtr window)
        {
            NativeSdl.InternalDestroyWindow(window);
        }

        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetClosestDisplayMode(int displayIndex, ref DisplayMode mode, out DisplayMode closest)
        {
            IntPtr result = NativeSdl.InternalGetClosestDisplayMode(displayIndex, ref mode, out closest);

            return result;
        }

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int GetCurrentDisplayMode(int displayIndex, out DisplayMode mode)
        {
            int result = NativeSdl.InternalGetCurrentDisplayMode(displayIndex, out mode);

            return result;
        }

        /// <summary>
        ///     Sdl the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string GetCurrentVideoDriver()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetCurrentVideoDriver());

            return result;
        }

        /// <summary>
        ///     Gets the desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int GetDesktopDisplayMode(int displayIndex, out DisplayMode mode)
        {
            int result = NativeSdl.InternalGetDesktopDisplayMode(displayIndex, out mode);

            return result;
        }

        /// <summary>
        ///     Sdl the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string GetDisplayName(int index)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetDisplayName(index));

            return result;
        }

        /// <summary>
        ///     Gets the display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int GetDisplayBounds(int displayIndex, out RectangleI rect)
        {
            int result = NativeSdl.InternalGetDisplayBounds(displayIndex, out rect);

            return result;
        }

        /// <summary>
        ///     Gets the display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="dDpi">The dpi</param>
        /// <param name="hDpi">The dpi</param>
        /// <param name="vDpi">The dpi</param>
        /// <returns>The int</returns>
        public static int GetDisplayDpi(int displayIndex, out float dDpi, out float hDpi, out float vDpi)
        {
            int result = NativeSdl.InternalGetDisplayDPI(displayIndex, out dDpi, out hDpi, out vDpi);

            return result;
        }

        /// <summary>
        ///     Gets the display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int GetDisplayMode(int displayIndex, int modeIndex, out DisplayMode mode)
        {
            int result = NativeSdl.InternalGetDisplayMode(displayIndex, modeIndex, out mode);

            return result;
        }


        /// <summary>
        ///     Gets the display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int GetDisplayUsableBounds(int displayIndex, out RectangleI rect) => NativeSdl.InternalGetDisplayUsableBounds(displayIndex, out rect);


        /// <summary>
        ///     Gets the num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        public static int GetNumDisplayModes(int displayIndex) => NativeSdl.InternalGetNumDisplayModes(displayIndex);

        /// <summary>
        ///     Gets the num video displays
        /// </summary>
        /// <returns>The int</returns>
        public static int GetNumVideoDisplays() => NativeSdl.InternalGetNumVideoDisplays();

        /// <summary>
        ///     Gets the num video drivers
        /// </summary>
        /// <returns>The int</returns>
        public static int GetNumVideoDrivers() => NativeSdl.InternalGetNumVideoDrivers();

        /// <summary>
        ///     Sdl the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string GetVideoDriver(int index) => Marshal.PtrToStringAnsi(NativeSdl.InternalGetVideoDriver(index));

        /// <summary>
        ///     Gets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        public static float GetWindowBrightness(IntPtr window) => NativeSdl.InternalGetWindowBrightness(window);

        /// <summary>
        ///     Sets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        public static int SetWindowOpacity(IntPtr window, float opacity) => NativeSdl.InternalSetWindowOpacity(window, opacity);

        /// <summary>
        ///     Gets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        public static int GetWindowOpacity(IntPtr window, out float outOpacity) => NativeSdl.InternalGetWindowOpacity(window, out outOpacity);

        /// <summary>
        ///     Sets the window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        public static int SetWindowModalFor(IntPtr modalWindow, IntPtr parentWindow) => NativeSdl.InternalSetWindowModalFor(modalWindow, parentWindow);

        /// <summary>
        ///     Sets the window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        public static int SetWindowInputFocus(IntPtr window) => NativeSdl.InternalSetWindowInputFocus(window);

        /// <summary>
        ///     Sdl the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetWindowData(IntPtr window, string name) => NativeSdl.InternalGetWindowData(window, name);

        /// <summary>
        ///     Gets the window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        public static int GetWindowDisplayIndex(IntPtr window) => NativeSdl.InternalGetWindowDisplayIndex(window);

        /// <summary>
        ///     Gets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int GetWindowDisplayMode(IntPtr window, out DisplayMode mode)
        {
            int result = NativeSdl.InternalGetWindowDisplayMode(window, out mode);

            return result;
        }

        /// <summary>
        ///     Gets the window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        public static uint GetWindowFlags(IntPtr window)
        {
            uint result = NativeSdl.InternalGetWindowFlags(window);

            return result;
        }

        /// <summary>
        ///     Gets the window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetWindowFromId(uint id)
        {
            IntPtr result = NativeSdl.InternalGetWindowFromID(id);

            return result;
        }

        /// <summary>
        ///     Gets the window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        public static int GetWindowGammaRamp(IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            int result = NativeSdl.InternalGetWindowGammaRamp(window, red, green, blue);

            return result;
        }

        /// <summary>
        ///     Gets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        public static bool GetWindowGrab(IntPtr window)
        {
            bool result = NativeSdl.InternalGetWindowGrab(window);

            return result;
        }

        /// <summary>
        ///     Gets the window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        public static uint GetWindowId(IntPtr window)
        {
            uint result = NativeSdl.InternalGetWindowID(window);

            return result;
        }

        /// <summary>
        ///     Gets the window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        public static uint GetWindowPixelFormat(IntPtr window) => NativeSdl.InternalGetWindowPixelFormat(window);

        /// <summary>
        ///     Gets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        public static void GetWindowMaximumSize(IntPtr window, out int maxW, out int maxH)
        {
            NativeSdl.InternalGetWindowMaximumSize(window, out maxW, out maxH);
        }

        /// <summary>
        ///     Gets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        public static void GetWindowMinimumSize(IntPtr window, out int minW, out int minH)
        {
            NativeSdl.InternalGetWindowMinimumSize(window, out minW, out minH);
        }

        /// <summary>
        ///     Gets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public static void GetWindowPosition(IntPtr window, out int x, out int y)
        {
            NativeSdl.InternalGetWindowPosition(window, out x, out y);
        }

        /// <summary>
        ///     simple
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static Vector2F GetWindowSize(IntPtr window)
        {
            NativeSdl.InternalGetWindowSize(window, out int w, out int h);
            return new Vector2F(w, h);
        }

        /// <summary>
        ///     Gets the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetWindowSurface(IntPtr window) => NativeSdl.InternalGetWindowSurface(window);

        /// <summary>
        ///     Sdl the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        public static string GetWindowTitle(IntPtr window)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetWindowTitle(window));

            return result;
        }

        /// <summary>
        ///     Gls the bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex</param>
        /// <param name="texH">The tex</param>
        /// <returns>The int</returns>
        public static int BindTexture(IntPtr texture, out float texW, out float texH) => NativeSdl.InternalGlBindTexture(texture, out texW, out texH);

        /// <summary>
        ///     Gls the create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateContext(IntPtr window) => NativeSdl.InternalGlCreateContext(window);

        /// <summary>
        ///     Gls the delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public static void DeleteContext(IntPtr context)
        {
            NativeSdl.InternalGlDeleteContext(context);
        }

        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetProcAddress(string proc) => NativeSdl.InternalGlGetProcAddress(proc);

        /// <summary>
        ///     Sdl the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        public static bool ExtensionSupported(string extension) => NativeSdl.InternalGlExtensionSupported(extension);

        /// <summary>
        ///     Gls the reset attributes
        /// </summary>
        public static void ResetAttributes()
        {
            NativeSdl.InternalGlResetAttributes();
        }

        /// <summary>
        ///     Gls the get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int GetAttribute(Attr attr, out int value) => NativeSdl.InternalGlGetAttribute(attr, out value);

        /// <summary>
        ///     Gls the get swap interval
        /// </summary>
        /// <returns>The int</returns>
        public static int GetSwapInterval() => NativeSdl.InternalGlGetSwapInterval();

        /// <summary>
        ///     Gls the make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        public static int MakeCurrent(IntPtr window, IntPtr context) => NativeSdl.InternalGlMakeCurrent(window, context);


        /// <summary>
        ///     Gls the get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        public static IntPtr GetCurrentWindow() => NativeSdl.InternalGlGetCurrentWindow();

        /// <summary>
        ///     Gls the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        public static IntPtr GetCurrentContext()
        {
            IntPtr result = NativeSdl.InternalGlGetCurrentContext();

            return result;
        }

        /// <summary>
        ///     Gls the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public static void GetDrawableSize(IntPtr window, out int w, out int h)
        {
            NativeSdl.InternalGlGetDrawableSize(window, out w, out h);
        }

        /// <summary>
        ///     Gls the set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int SetAttributeByInt(Attr attr, int value) => NativeSdl.InternalGlSetAttribute(attr, value);

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        public static int SetAttributeByProfile(Attr attr, Profiles profile)
        {
            int result = NativeSdl.InternalGlSetAttribute(attr, (int) profile);

            return result;
        }

        /// <summary>
        ///     Gls the set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        public static int SetSwapInterval(int interval)
        {
            int result = NativeSdl.InternalGlSetSwapInterval(interval);

            return result;
        }

        /// <summary>
        ///     Gls the swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void SwapWindow(IntPtr window)
        {
            NativeSdl.InternalGlSwapWindow(window);
        }

        /// <summary>
        ///     Gls the unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        public static int UnbindTexture(IntPtr texture)
        {
            int result = NativeSdl.InternalGlUnbindTexture(texture);

            return result;
        }

        /// <summary>
        ///     Hides the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void HideWindow(IntPtr window)
        {
            NativeSdl.InternalHideWindow(window);
        }

        /// <summary>
        ///     Maximizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void MaximizeWindow(IntPtr window)
        {
            NativeSdl.InternalMaximizeWindow(window);
        }

        /// <summary>
        ///     Minimizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void MinimizeWindow(IntPtr window)
        {
            NativeSdl.InternalMinimizeWindow(window);
        }

        /// <summary>
        ///     Raises the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void RaiseWindow(IntPtr window)
        {
            NativeSdl.InternalRaiseWindow(window);
        }

        /// <summary>
        ///     Restores the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void RestoreWindow(IntPtr window)
        {
            NativeSdl.InternalRestoreWindow(window);
        }

        /// <summary>
        ///     Sets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        public static int SetWindowBrightness(IntPtr window, float brightness)
        {
            int result = NativeSdl.InternalSetWindowBrightness(window, brightness);

            return result;
        }

        /// <summary>
        ///     Sdl the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SetWindowData(IntPtr window, string name, IntPtr userdata)
        {
            IntPtr result = NativeSdl.InternalSetWindowData(window, name, userdata);

            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int SetWindowDisplayMode(IntPtr window, ref DisplayMode mode)
        {
            int result = NativeSdl.InternalSetWindowDisplayMode(window, ref mode);

            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        public static int SetWindowDisplayMode(IntPtr window, IntPtr mode)
        {
            int result = NativeSdl.InternalSetWindowDisplayMode(window, mode);

            return result;
        }

        /// <summary>
        ///     Sets the window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        public static int SetWindowFullscreen(IntPtr window, uint flags)
        {
            int result = NativeSdl.InternalSetWindowFullscreen(window, flags);

            return result;
        }

        /// <summary>
        ///     Sets the window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        public static int SetWindowGammaRamp(IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            int result = NativeSdl.InternalSetWindowGammaRamp(window, red, green, blue);

            return result;
        }

        /// <summary>
        ///     Sets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        public static void SetWindowGrab(IntPtr window, bool grabbed)
        {
            NativeSdl.InternalSetWindowGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        public static void SetWindowIcon(IntPtr window, IntPtr icon)
        {
            NativeSdl.InternalSetWindowIcon(window, icon);
        }

        /// <summary>
        ///     Sets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        public static void SetWindowMaximumSize(IntPtr window, int maxW, int maxH)
        {
            NativeSdl.InternalSetWindowMaximumSize(window, maxW, maxH);
        }

        /// <summary>
        ///     Sets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        public static void SetWindowMinimumSize(IntPtr window, int minW, int minH)
        {
            NativeSdl.InternalSetWindowMinimumSize(window, minW, minH);
        }

        /// <summary>
        ///     Sets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public static void SetWindowPosition(IntPtr window, int x, int y)
        {
            NativeSdl.InternalSetWindowPosition(window, x, y);
        }

        /// <summary>
        ///     Sets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public static void SetWindowSize(IntPtr window, int w, int h)
        {
            NativeSdl.InternalSetWindowSize(window, w, h);
        }

        /// <summary>
        ///     Sets the window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        public static void SetWindowBordered(IntPtr window, bool bordered)
        {
            NativeSdl.InternalSetWindowBordered(window, bordered);
        }

        /// <summary>
        ///     Gets the window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        public static int GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom, out int right)
        {
            int result = NativeSdl.InternalGetWindowBordersSize(window, out top, out left, out bottom, out right);

            return result;
        }

        /// <summary>
        ///     Sets the window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        public static void SetWindowResizable(IntPtr window, bool resizable)
        {
            NativeSdl.InternalSetWindowResizable(window, resizable);
        }

        /// <summary>
        ///     Sdl the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        public static void SetWindowTitle(IntPtr window, string title)
        {
            NativeSdl.InternalSetWindowTitle(window, title);
        }

        /// <summary>
        ///     Shows the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void ShowWindow(IntPtr window)
        {
            NativeSdl.InternalShowWindow(window);
        }

        /// <summary>
        ///     Updates the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        public static int UpdateWindowSurface(IntPtr window)
        {
            int result = NativeSdl.InternalUpdateWindowSurface(window);

            return result;
        }

        /// <summary>
        ///     Updates the window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        public static int UpdateWindowSurfaceRects(IntPtr window, [In] RectangleI[] rects, int numRects)
        {
            int result = NativeSdl.InternalUpdateWindowSurfaceRects(window, rects, numRects);

            return result;
        }

        /// <summary>
        ///     Sets the window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        public static int SetWindowHitTest(IntPtr window, SdlHitTest callback, IntPtr callbackData)
        {
            int result = NativeSdl.InternalSetWindowHitTest(window, callback, callbackData);

            return result;
        }

        /// <summary>
        ///     Gets the grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        public static IntPtr GetGrabbedWindow()
        {
            IntPtr result = NativeSdl.InternalGetGrabbedWindow();

            return result;
        }

        /// <summary>
        ///     Composes the custom blend mode using the specified src color factor
        /// </summary>
        /// <param name="srcColorFactor">The src color factor</param>
        /// <param name="dstColorFactor">The dst color factor</param>
        /// <param name="colorOperation">The color operation</param>
        /// <param name="srcAlphaFactor">The src alpha factor</param>
        /// <param name="dstAlphaFactor">The dst alpha factor</param>
        /// <param name="alphaOperation">The alpha operation</param>
        /// <returns>The sdl blend mode</returns>
        public static BlendModes ComposeCustomBlendMode(BlendFactor srcColorFactor, BlendFactor dstColorFactor, BlendOperation colorOperation, BlendFactor srcAlphaFactor, BlendFactor dstAlphaFactor, BlendOperation alphaOperation)
        {
            BlendModes result = NativeSdl.InternalComposeCustomBlendMode(srcColorFactor, dstColorFactor, colorOperation, srcAlphaFactor, dstAlphaFactor, alphaOperation);

            return result;
        }

        /// <summary>
        ///     Creates the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateRenderer(IntPtr window, int index, Renderers flags) => NativeSdl.InternalCreateRenderer(window, index, flags);

        /// <summary>
        ///     Creates the software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateSoftwareRenderer(IntPtr surface)
        {
            IntPtr result = NativeSdl.InternalCreateSoftwareRenderer(surface);

            return result;
        }

        /// <summary>
        ///     Creates the texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateTexture(IntPtr renderer, uint format, int access, int w, int h) => NativeSdl.InternalCreateTexture(renderer, format, access, w, h);

        /// <summary>
        ///     Creates the texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateTextureFromSurface(IntPtr renderer, IntPtr surface)
        {
            IntPtr result = NativeSdl.InternalCreateTextureFromSurface(renderer, surface);

            return result;
        }

        /// <summary>
        ///     Destroys the renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public static void DestroyRenderer(IntPtr renderer)
        {
            NativeSdl.InternalDestroyRenderer(renderer);
        }

        /// <summary>
        ///     Destroys the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public static void DestroyTexture(IntPtr texture)
        {
            NativeSdl.InternalDestroyTexture(texture);
        }

        /// <summary>
        ///     Gets the num render drivers
        /// </summary>
        /// <returns>The int</returns>
        public static int GetNumRenderDrivers() => NativeSdl.InternalGetNumRenderDrivers();

        /// <summary>
        ///     Gets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        public static int GetRenderDrawBlendMode(IntPtr renderer, out BlendModes blendMode) => NativeSdl.InternalGetRenderDrawBlendMode(renderer, out blendMode);

        /// <summary>
        ///     Gets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        public static int GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a) => NativeSdl.InternalGetRenderDrawColor(renderer, out r, out g, out b, out a);

        /// <summary>
        ///     Gets the render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        public static int GetRenderDriverInfo(int index, out RendererInfo info) => NativeSdl.InternalGetRenderDriverInfo(index, out info);

        /// <summary>
        ///     Gets the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetRenderer(IntPtr window) => NativeSdl.InternalGetRenderer(window);

        /// <summary>
        ///     Gets the renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        public static int GetRendererInfo(IntPtr renderer, out RendererInfo info) => NativeSdl.InternalGetRendererInfo(renderer, out info);

        /// <summary>
        ///     Gets the renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int GetRendererOutputSize(IntPtr renderer, out int w, out int h) => NativeSdl.InternalGetRendererOutputSize(renderer, out w, out h);

        /// <summary>
        ///     Gets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        public static int GetTextureAlphaMod(IntPtr texture, out byte alpha) => NativeSdl.InternalGetTextureAlphaMod(texture, out alpha);

        /// <summary>
        ///     Gets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        public static int GetTextureBlendMode(IntPtr texture, out BlendModes blendMode) => NativeSdl.InternalGetTextureBlendMode(texture, out blendMode);

        /// <summary>
        ///     Gets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b) => NativeSdl.InternalGetTextureColorMod(texture, out r, out g, out b);

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        public static int LockTexture(IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch) => NativeSdl.InternalLockTexture(texture, ref rect, out pixels, out pitch);

        /// <summary>
        ///     Queries the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int QueryTexture(IntPtr texture, out uint format, out int access, out int w, out int h)
        {
            int result = NativeSdl.InternalQueryTexture(texture, out format, out access, out w, out h);

            return result;
        }

        /// <summary>
        ///     Renders the clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        public static int RenderClear(IntPtr renderer)
        {
            int result = NativeSdl.InternalRenderClear(renderer);

            return result;
        }

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopy(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect)
        {
            int result = NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, ref dstRect);

            return result;
        }

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopy(IntPtr renderer, IntPtr texture, IntPtr srcRect, ref RectangleI dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, srcRect, ref dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopy(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, IntPtr dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopy(IntPtr renderer, IntPtr texture, IntPtr srcRect, IntPtr dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, srcRect, dstRect);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, ref center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, ref center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, IntPtr dstRect, double angle, ref PointI center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, ref center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcRect, IntPtr dstRect, double angle, ref PointI center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, ref center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcRect, ref RectangleI dstRect, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, IntPtr dstRect, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcRect, IntPtr dstRect, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, center, flips);

        /// <summary>
        ///     Renders the draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        public static int RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2) => NativeSdl.InternalRenderDrawLine(renderer, x1, y1, x2, y2);

        /// <summary>
        ///     Renders the draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderDrawLines(IntPtr renderer, [In] PointI[] points, int count) => NativeSdl.InternalRenderDrawLines(renderer, points, count);

        /// <summary>
        ///     Renders the draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        public static int RenderDrawPoint(IntPtr renderer, int x, int y) => NativeSdl.InternalRenderDrawPoint(renderer, x, y);

        /// <summary>
        ///     Renders the draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderDrawPoints(IntPtr renderer, [In] PointI[] points, int count) => NativeSdl.InternalRenderDrawPoints(renderer, points, count);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderDrawRect(IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderDrawRect(renderer, ref rect);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderDrawRect(IntPtr renderer, IntPtr rect) => NativeSdl.InternalRenderDrawRect(renderer, rect);

        /// <summary>
        ///     Renders the draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderDrawRects(IntPtr renderer, [In] RectangleI[] rects, int count) => NativeSdl.InternalRenderDrawRects(renderer, rects, count);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderFillRect(IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderFillRect(renderer, ref rect);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderFillRect(IntPtr renderer, IntPtr rect) => NativeSdl.InternalRenderFillRect(renderer, rect);

        /// <summary>
        ///     Renders the fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderFillRects(IntPtr renderer, [In] RectangleI[] rects, int count) => NativeSdl.InternalRenderFillRects(renderer, rects, count);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopyF(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, ref RectangleF dst) => NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, ref dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopyF(IntPtr renderer, IntPtr texture, IntPtr srcRect, ref RectangleF dst) => NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, ref dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopyF(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, IntPtr dstRect) => NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, dstRect);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int RenderCopyF(IntPtr renderer, IntPtr texture, IntPtr srcRect, IntPtr dstRect) => NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, dstRect);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dst, angle, ref center, flips);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, RendererFlips flips) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dst, angle, ref center, flips);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyExF(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, IntPtr dstRect, double angle, ref PointF center, RendererFlips flips) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, ref center, flips);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyExF(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, ref dst, angle, center, flips);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyExF(IntPtr renderer, IntPtr texture, IntPtr srcRect, IntPtr dstRect, double angle, ref PointF center, RendererFlips flips) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, ref center, flips);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyExF(IntPtr renderer, IntPtr texture, IntPtr srcRect, ref RectangleF dst, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, ref dst, angle, center, flips);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyExF(IntPtr renderer, IntPtr texture, ref RectangleI srcRect, IntPtr dstRect, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, center, flips);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        public static int RenderCopyExF(IntPtr renderer, IntPtr texture, IntPtr srcRect, IntPtr dstRect, double angle, IntPtr center, RendererFlips flips) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, center, flips);

        /// <summary>
        ///     Renders the draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        public static int RenderDrawPointF(IntPtr renderer, float x, float y) => NativeSdl.InternalRenderDrawPointF(renderer, x, y);

        /// <summary>
        ///     Renders the draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderDrawPointsF(IntPtr renderer, [In] PointF[] points, int count) => NativeSdl.InternalRenderDrawPointsF(renderer, points, count);

        /// <summary>
        ///     Renders the draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        public static int RenderDrawLineF(IntPtr renderer, float x1, float y1, float x2, float y2) => NativeSdl.InternalRenderDrawLineF(renderer, x1, y1, x2, y2);


        /// <summary>
        ///     Renders the draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderDrawLinesF(IntPtr renderer, [In] PointF[] points, int count) => NativeSdl.InternalRenderDrawLinesF(renderer, points, count);


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderDrawRectF(IntPtr renderer, ref RectangleF rect) => NativeSdl.InternalRenderDrawRectF(renderer, ref rect);


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderDrawRectF(IntPtr renderer, IntPtr rect) => NativeSdl.InternalRenderDrawRectF(renderer, rect);

        /// <summary>
        ///     Renders the draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderDrawRectsF(IntPtr renderer, [In] RectangleF[] rects, int count) => NativeSdl.InternalRenderDrawRectsF(renderer, rects, count);


        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderFillRectF(IntPtr renderer, RectangleF rect) => NativeSdl.InternalRenderFillRectF(renderer, rect);

        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderFillRectF(IntPtr renderer, IntPtr rect) => NativeSdl.InternalRenderFillRectF(renderer, rect);

        /// <summary>
        ///     Renders the fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int RenderFillRectsF(IntPtr renderer, [In] RectangleF[] rects, int count) => NativeSdl.InternalRenderFillRectsF(renderer, rects, count);


        /// <summary>
        ///     Renders the get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        public static void RenderGetClipRect(IntPtr renderer, out RectangleI rect)
        {
            NativeSdl.InternalRenderGetClipRect(renderer, out rect);
        }


        /// <summary>
        ///     Renders the get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public static void RenderGetLogicalSize(IntPtr renderer, out int w, out int h)
        {
            NativeSdl.InternalRenderGetLogicalSize(renderer, out w, out h);
        }


        /// <summary>
        ///     Renders the get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        public static void RenderGetScale(IntPtr renderer, out float scaleX, out float scaleY)
        {
            NativeSdl.InternalRenderGetScale(renderer, out scaleX, out scaleY);
        }

        /// <summary>
        ///     Renders the get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderGetViewport(IntPtr renderer, out RectangleI rect) => NativeSdl.InternalRenderGetViewport(renderer, out rect);

        /// <summary>
        ///     Renders the present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public static void RenderPresent(IntPtr renderer)
        {
            NativeSdl.InternalRenderPresent(renderer);
        }

        /// <summary>
        ///     Renders the read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        public static int RenderReadPixels(IntPtr renderer, ref RectangleI rect, uint format, IntPtr pixels, int pitch) => NativeSdl.InternalRenderReadPixels(renderer, ref rect, format, pixels, pitch);


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderSetClipRect(IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderSetClipRect(renderer, ref rect);


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderSetClipRect(IntPtr renderer, IntPtr rect) => NativeSdl.InternalRenderSetClipRect(renderer, rect);

        /// <summary>
        ///     Renders the set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int RenderSetLogicalSize(IntPtr renderer, int w, int h) => NativeSdl.InternalRenderSetLogicalSize(renderer, w, h);


        /// <summary>
        ///     Renders the set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        public static int RenderSetScale(IntPtr renderer, float scaleX, float scaleY) => NativeSdl.InternalRenderSetScale(renderer, scaleX, scaleY);


        /// <summary>
        ///     Renders the set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        public static int RenderSetIntegerScale(IntPtr renderer, bool enable) => NativeSdl.InternalRenderSetIntegerScale(renderer, enable);

        /// <summary>
        ///     Renders the set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int RenderSetViewport(IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderSetViewportWithRef(renderer, ref rect);

        /// <summary>
        ///     Sets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        public static int SetRenderDrawBlendMode(IntPtr renderer, BlendModes blendMode) => NativeSdl.InternalSetRenderDrawBlendMode(renderer, blendMode);

        /// <summary>
        ///     Sets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        public static int SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a) => NativeSdl.InternalSetRenderDrawColor(renderer, r, g, b, a);


        /// <summary>
        ///     Sets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        public static int SetRenderTarget(IntPtr renderer, IntPtr texture) => NativeSdl.InternalSetRenderTarget(renderer, texture);

        /// <summary>
        ///     Sets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        public static int SetTextureAlphaMod(IntPtr texture, byte alpha) => NativeSdl.InternalSetTextureAlphaMod(texture, alpha);


        /// <summary>
        ///     Sets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        public static int SetTextureBlendMode(IntPtr texture, BlendModes blendMode) => NativeSdl.InternalSetTextureBlendMode(texture, blendMode);


        /// <summary>
        ///     Sets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int SetTextureColorMod(IntPtr texture, byte r, byte g, byte b) => NativeSdl.InternalSetTextureColorMod(texture, r, g, b);

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        public static int UpdateTexture(IntPtr texture, ref RectangleI rect, IntPtr pixels, int pitch) => NativeSdl.InternalUpdateTexture(texture, ref rect, pixels, pitch);

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        public static int UpdateTexture(IntPtr texture, IntPtr rect, IntPtr pixels, int pitch) => NativeSdl.InternalUpdateTexture(texture, rect, pixels, pitch);

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        public static int UpdateTexture(IntPtr texture, IntPtr rect, byte[] pixels, int pitch) => NativeSdl.InternalUpdateTexturev2(texture, rect, pixels, pitch);

        /// <summary>
        ///     Renders the target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        public static bool RenderTargetSupported(IntPtr renderer) => NativeSdl.InternalRenderTargetSupported(renderer);

        /// <summary>
        ///     Renders the is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        public static bool RenderIsClipEnabled(IntPtr renderer) => NativeSdl.InternalRenderIsClipEnabled(renderer);

        /// <summary>
        ///     Calculates the gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        public static void CalculateGammaRamp(float gamma, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp)
        {
            NativeSdl.InternalCalculateGammaRamp(gamma, ramp);
        }

        /// <summary>
        ///     Sdl the get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The string</returns>
        public static string GetPixelFormatName(uint format)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetPixelFormatName(format));

            return result;
        }

        /// <summary>
        ///     Pixels the format enum to masks using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The mask</param>
        /// <param name="gMask">The mask</param>
        /// <param name="bMask">The mask</param>
        /// <param name="aMask">The mask</param>
        /// <returns>The sdl bool</returns>
        public static bool FormatEnumToMasks(uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask) => NativeSdl.InternalPixelFormatEnumToMasks(format, out bpp, out rMask, out gMask, out bMask, out aMask);

        /// <summary>
        ///     Sets the palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The colors</param>
        /// <returns>The int</returns>
        public static int SetPaletteColors(IntPtr palette, [In] Color[] colors, int firstColor, int nColors) => NativeSdl.InternalSetPaletteColors(palette, colors, firstColor, nColors);

        /// <summary>
        ///     Sets the pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        public static int SetPixelFormatPalette(IntPtr format, IntPtr palette) => NativeSdl.InternalSetPixelFormatPalette(format, palette);

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int BlitSurface(IntPtr src, ref RectangleI srcRect, IntPtr dst, ref RectangleI dstRect)
        {
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, ref dstRect);

            return result;
        }


        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int BlitSurface(IntPtr src, IntPtr srcRect, IntPtr dst, ref RectangleI dstRect)
        {
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, ref dstRect);

            return result;
        }

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int BlitSurface(IntPtr src, ref RectangleI srcRect, IntPtr dst, IntPtr dstRect)
        {
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, dstRect);

            return result;
        }

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int BlitSurface(IntPtr src, IntPtr srcRect, IntPtr dst, IntPtr dstRect)
        {
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, dstRect);

            return result;
        }

        /// <summary>
        ///     Converts the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        public static IntPtr ConvertSurface(IntPtr src, IntPtr fmt, uint flags)
        {
            IntPtr result = NativeSdl.InternalConvertSurface(src, fmt, flags);

            return result;
        }

        /// <summary>
        ///     Creates the rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateRgbSurfaceWithFormat(uint flags, int width, int height, int depth, uint format) => NativeSdl.InternalCreateRGBSurfaceWithFormat(flags, width, height, depth, format);

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        public static int FillRect(IntPtr dst, ref RectangleI rect, uint color) => NativeSdl.InternalFillRect(dst, ref rect, color);

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        public static int FillRect(IntPtr dst, IntPtr rect, uint color) => NativeSdl.InternalFillRect(dst, rect, color);

        /// <summary>
        ///     Fills the rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        public static int FillRects(IntPtr dst, [In] RectangleI[] rects, int count, uint color)
        {
            int result = NativeSdl.InternalFillRects(dst, rects, count, color);

            return result;
        }

        /// <summary>
        ///     Gets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        public static void GetClipRect(IntPtr surface, out RectangleI rect)
        {
            NativeSdl.InternalGetClipRect(surface, out rect);
        }

        /// <summary>
        ///     Has the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        public static bool HasColorKey(IntPtr surface) => NativeSdl.InternalHasColorKey(surface);

        /// <summary>
        ///     Gets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        public static int GetColorKey(IntPtr surface, out uint key) => NativeSdl.InternalGetColorKey(surface, out key);

        /// <summary>
        ///     Gets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        public static int GetSurfaceAlphaMod(IntPtr surface, out byte alpha) => NativeSdl.InternalGetSurfaceAlphaMod(surface, out alpha);

        /// <summary>
        ///     Gets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        public static int GetSurfaceBlendMode(IntPtr surface, out BlendModes blendMode) => NativeSdl.InternalGetSurfaceBlendMode(surface, out blendMode);

        /// <summary>
        ///     Gets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b) => NativeSdl.InternalGetSurfaceColorMod(surface, out r, out g, out b);

        /// <summary>
        ///     Sdl the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadBmp(string file) => NativeSdl.InternalLoadBMP_RW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Sets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        public static bool SetClipRect(IntPtr surface, ref RectangleI rect) => NativeSdl.InternalSetClipRect(surface, ref rect);

        /// <summary>
        ///     Sets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        public static int SetColorKey(IntPtr surface, int flag, uint key) => NativeSdl.InternalSetColorKey(surface, flag, key);

        /// <summary>
        ///     Sets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        public static int SetSurfaceAlphaMod(IntPtr surface, byte alpha) => NativeSdl.InternalSetSurfaceAlphaMod(surface, alpha);

        /// <summary>
        ///     Sets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        public static int SetSurfaceBlendMode(IntPtr surface, BlendModes blendMode) => NativeSdl.InternalSetSurfaceBlendMode(surface, blendMode);

        /// <summary>
        ///     Sets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b) => NativeSdl.InternalSetSurfaceColorMod(surface, r, g, b);

        /// <summary>
        ///     Sets the surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        public static int SetSurfacePalette(IntPtr surface, IntPtr palette) => NativeSdl.InternalSetSurfacePalette(surface, palette);

        /// <summary>
        ///     Uppers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int UpperBlit(IntPtr src, ref RectangleI srcRect, IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalUpperBlit(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Uppers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        public static int UpperBlitScaled(IntPtr src, ref RectangleI srcRect, IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalUpperBlitScaled(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Has the clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        public static bool HasClipboardText() => NativeSdl.InternalHasClipboardText();

        /// <summary>
        ///     Sdl the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        public static string GetClipboardText()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetClipboardText());

            return result;
        }

        /// <summary>
        ///     Sdl the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        public static int SetClipboardText(string text) => NativeSdl.InternalSetClipboardText(text);

        /// <summary>
        ///     Peeps the events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        public static int PeepEvents([Out] Event[] events, int numEvents, EventAction action, EventType minType, EventType maxType) => NativeSdl.InternalPeepEvents(events, numEvents, action, minType, maxType);


        /// <summary>
        ///     Has the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        public static bool HasEvent(EventType type) => NativeSdl.InternalHasEvent(type);

        /// <summary>
        ///     Has the events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        public static bool HasEvents(EventType minType, EventType maxType) => NativeSdl.InternalHasEvents(minType, maxType);

        /// <summary>
        ///     Flushes the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        public static void FlushEvent(EventType type)
        {
            NativeSdl.InternalFlushEvent(type);
        }


        /// <summary>
        ///     Polls the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining), ExcludeFromCodeCoverage]
        public static int PollEvent(out Event sdlEvent) => NativeSdl.InternalPollEvent(out sdlEvent);

        /// <summary>
        ///     Pushes the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        public static int PushEvent(ref Event sdlEvent) => NativeSdl.InternalPushEvent(ref sdlEvent);

        /// <summary>
        ///     Sets the event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        public static void SetEventFilter(SdlEventFilter filter, IntPtr userdata)
        {
            NativeSdl.InternalSetEventFilter(filter, userdata);
        }

        /// <summary>
        ///     Adds the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        public static void AddEventWatch(SdlEventFilter filter, IntPtr userdata)
        {
            NativeSdl.InternalAddEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Del the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        public static void DelEventWatch(SdlEventFilter filter, IntPtr userdata)
        {
            NativeSdl.InternalDelEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Sdl the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        public static byte GetEventState(EventType type) => NativeSdl.InternalEventState(type, Query);

        /// <summary>
        ///     Registers the events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The uint</returns>
        public static uint RegisterEvents(int numEvents) => NativeSdl.InternalRegisterEvents(numEvents);

        /// <summary>
        ///     Sdl the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        public static KeyCodes ScanCodeToKeyCode(SdlScancode x) => (KeyCodes) ((int) x | KScancodeMask);

        /// <summary>
        ///     Gets the keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        public static IntPtr GetKeyboardFocus() => NativeSdl.InternalGetKeyboardFocus();

        /// <summary>
        ///     Gets the keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetKeyboardState(out int numKeys) => NativeSdl.InternalGetKeyboardState(out numKeys);

        /// <summary>
        ///     Gets the mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        public static KeyMods GetModState() => NativeSdl.InternalGetModState();

        /// <summary>
        ///     Sets the mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        public static void SetModState(KeyMods modState)
        {
            NativeSdl.InternalSetModState(modState);
        }

        /// <summary>
        ///     Gets the key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        public static KeyCodes GetKeyFromScancode(SdlScancode scancode) => NativeSdl.InternalGetKeyFromScancode(scancode);

        /// <summary>
        ///     Gets the scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        public static SdlScancode GetScancodeFromKey(KeyCodes key) => NativeSdl.InternalGetScancodeFromKey(key);

        /// <summary>
        ///     Sdl the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        public static string GetScancodeName(SdlScancode scancode)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetScancodeName(scancode));

            return result;
        }

        /// <summary>
        ///     Sdl the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        public static SdlScancode GetScancodeFromName(string name) => NativeSdl.InternalGetScancodeFromName(name);

        /// <summary>
        ///     Sdl the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public static string SGetKeyName(KeyCodes key)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetKeyName(key));

            return result;
        }

        /// <summary>
        ///     Sdl the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        public static KeyCodes GetKeyFromName(string name) => NativeSdl.InternalGetKeyFromName(name);

        /// <summary>
        ///     Starts the text input
        /// </summary>
        public static void StartTextInput()
        {
            NativeSdl.InternalStartTextInput();
        }

        /// <summary>
        ///     Is the text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        public static bool IsTextInputActive() => NativeSdl.InternalIsTextInputActive();

        /// <summary>
        ///     Stops the text input
        /// </summary>
        public static void StopTextInput()
        {
            NativeSdl.InternalStopTextInput();
        }

        /// <summary>
        ///     Sets the text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        public static void SetTextInputRect(ref RectangleI rect)
        {
            NativeSdl.InternalSetTextInputRect(ref rect);
        }

        /// <summary>
        ///     Has the screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        public static bool HasScreenKeyboardSupport()
        {
            bool result = NativeSdl.InternalHasScreenKeyboardSupport();

            return result;
        }

        /// <summary>
        ///     Is the screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        public static bool IsScreenKeyboardShown(IntPtr window)
        {
            bool result = NativeSdl.InternalIsScreenKeyboardShown(window);

            return result;
        }

        /// <summary>
        ///     Gets the mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        public static IntPtr GetMouseFocus() => NativeSdl.InternalGetMouseFocus();

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint GetMouseStateOutXAndY(out int x, out int y) => NativeSdl.InternalGetMouseState(out x, out y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint GetMouseStateXAndYOut(IntPtr x, out int y) => NativeSdl.InternalGetMouseState(x, out y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint GetMouseStateXOutAndY(out int x, IntPtr y) => NativeSdl.InternalGetMouseState(out x, y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint GetMouseStateToXAndY(IntPtr x, IntPtr y) => NativeSdl.InternalGetMouseState(x, y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint GetGlobalMouseStateOutXAndOutY(out int x, out int y) => NativeSdl.InternalGetGlobalMouseState(out x, out y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint GetGlobalMouseStateXAndY(IntPtr x, IntPtr y) => NativeSdl.InternalGetGlobalMouseState(x, y);

        /// <summary>
        ///     Gets the relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint GetRelativeMouseState(out int x, out int y) => NativeSdl.InternalGetRelativeMouseState(out x, out y);

        /// <summary>
        ///     Warps the mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public static void WarpMouseInWindow(IntPtr window, int x, int y)
        {
            NativeSdl.InternalWarpMouseInWindow(window, x, y);
        }

        /// <summary>
        ///     Warps the mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        public static int WarpMouseGlobal(int x, int y) => NativeSdl.InternalWarpMouseGlobal(x, y);

        /// <summary>
        ///     Sets the relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        public static int SetRelativeMouseMode(bool enabled) => NativeSdl.InternalSetRelativeMouseMode(enabled);

        /// <summary>
        ///     Captures the mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        public static int CaptureMouse(bool enabled) => NativeSdl.InternalCaptureMouse(enabled);

        /// <summary>
        ///     Gets the relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        public static bool GetRelativeMouseMode() => NativeSdl.InternalGetRelativeMouseMode();

        /// <summary>
        ///     Creates the cursor using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="mask">The mask</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateCursor(IntPtr data, IntPtr mask, int w, int h, int hotX, int hotY) => NativeSdl.InternalCreateCursor(data, mask, w, h, hotX, hotY);

        /// <summary>
        ///     Creates the color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateColorCursor(IntPtr surface, int hotX, int hotY) => NativeSdl.InternalCreateColorCursor(surface, hotX, hotY);

        /// <summary>
        ///     Creates the system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        public static IntPtr CreateSystemCursor(SystemCursor id) => NativeSdl.InternalCreateSystemCursor(id);

        /// <summary>
        ///     Sets the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        public static void SetCursor(IntPtr cursor)
        {
            NativeSdl.InternalSetCursor(cursor);
        }

        /// <summary>
        ///     Gets the cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        public static IntPtr GetCursor() => NativeSdl.InternalGetCursor();

        /// <summary>
        ///     Frees the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        public static void FreeCursor(IntPtr cursor)
        {
            NativeSdl.InternalFreeCursor(cursor);
        }

        /// <summary>
        ///     Shows the cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        public static int ShowCursor(int toggle) => NativeSdl.InternalShowCursor(toggle);

        /// <summary>
        ///     Sdl the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        public static uint Button(uint x) => (uint) (1 << ((int) x - 1));

        /// <summary>
        ///     Gets the touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        public static long GetTouchDevice(int index) => NativeSdl.InternalGetTouchDevice(index);

        /// <summary>
        ///     Gets the num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        public static int GetNumTouchFingers(long touchId) => NativeSdl.InternalGetNumTouchFingers(touchId);

        /// <summary>
        ///     Gets the touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GetTouchFinger(long touchId, int index) => NativeSdl.InternalGetTouchFinger(touchId, index);

        /// <summary>
        ///     Gets the touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        public static TouchDeviceType GetTouchDeviceType(long touchId) => NativeSdl.InternalGetTouchDeviceType(touchId);


        /// <summary>
        ///     Joysticks the rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        public static int JoystickRumble(IntPtr joystick, ushort lowFrequencyRumble, ushort highFrequencyRumble, uint durationMs) => NativeSdl.InternalJoystickRumble(joystick, lowFrequencyRumble, highFrequencyRumble, durationMs);

        /// <summary>
        ///     Joysticks the close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        public static void JoystickClose(IntPtr joystick)
        {
            NativeSdl.InternalJoystickClose(joystick);
        }

        /// <summary>
        ///     Joysticks the event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        public static int JoystickEventState(int state) => NativeSdl.InternalJoystickEventState(state);

        /// <summary>
        ///     Joysticks the get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        public static short JoystickGetAxis(IntPtr joystick, int axis) => NativeSdl.InternalJoystickGetAxis(joystick, axis);

        /// <summary>
        ///     Joysticks the get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        public static bool JoystickGetAxisInitialState(IntPtr joystick, int axis, out ushort state) => NativeSdl.InternalJoystickGetAxisInitialState(joystick, axis, out state);

        /// <summary>
        ///     Joysticks the get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        public static int JoystickGetBall(IntPtr joystick, int ball, out int dx, out int dy) => NativeSdl.InternalJoystickGetBall(joystick, ball, out dx, out dy);

        /// <summary>
        ///     Joysticks the get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        public static byte JoystickGetButton(IntPtr joystick, int button) => NativeSdl.InternalJoystickGetButton(joystick, button);

        /// <summary>
        ///     Joysticks the get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        public static byte JoystickGetHat(IntPtr joystick, int hat) => NativeSdl.InternalJoystickGetHat(joystick, hat);

        /// <summary>
        ///     Sdl the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        public static string JoystickName(IntPtr joystick)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickName(joystick));

            return result;
        }

        /// <summary>
        ///     Sdl the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string JoystickNameForIndex(int deviceIndex)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickNameForIndex(deviceIndex));

            return result;
        }

        /// <summary>
        ///     Joysticks the num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        public static int JoystickNumAxes(IntPtr joystick) => NativeSdl.InternalJoystickNumAxes(joystick);

        /// <summary>
        ///     Joysticks the num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        public static int JoystickNumBalls(IntPtr joystick) => NativeSdl.InternalJoystickNumBalls(joystick);

        /// <summary>
        ///     Joysticks the num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        public static int JoystickNumButtons(IntPtr joystick) => NativeSdl.InternalJoystickNumButtons(joystick);

        /// <summary>
        ///     Joysticks the num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        public static int JoystickNumHats(IntPtr joystick)
        {
            int result = NativeSdl.InternalJoystickNumHats(joystick);

            return result;
        }

        /// <summary>
        ///     Joysticks the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        public static IntPtr JoystickOpen(int deviceIndex)
        {
            IntPtr result = NativeSdl.InternalJoystickOpen(deviceIndex);

            return result;
        }

        /// <summary>
        ///     Joysticks the update
        /// </summary>
        public static void JoystickUpdate()
        {
            NativeSdl.InternalJoystickUpdate();
        }

        /// <summary>
        ///     Nums the joysticks
        /// </summary>
        /// <returns>The int</returns>
        public static int NumJoysticks()
        {
            int result = NativeSdl.InternalNumJoysticks();

            return result;
        }

        /// <summary>
        ///     Joysticks the get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        public static Guid JoystickGetDeviceGuid(int deviceIndex) => NativeSdl.InternalJoystickGetDeviceGUID(deviceIndex);

        /// <summary>
        ///     Joysticks the get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        public static Guid JoystickGetGuid(IntPtr joystick) => NativeSdl.InternalJoystickGetGUID(joystick);

        /// <summary>
        ///     Joysticks the get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        public static void JoystickGetGuidString(Guid guid, byte[] pszGuid, int cbGuid)
        {
            NativeSdl.InternalJoystickGetGUIDString(guid, pszGuid, cbGuid);
        }

        /// <summary>
        ///     Sdl the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        public static Guid JoystickGetGuidFromString(string pchGuid) => NativeSdl.InternalJoystickGetGUIDFromString(pchGuid);

        /// <summary>
        ///     Joysticks the get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        public static ushort JoystickGetDeviceVendor(int deviceIndex) => NativeSdl.InternalJoystickGetDeviceVendor(deviceIndex);

        /// <summary>
        ///     Joysticks the get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        public static ushort JoystickGetDeviceProduct(int deviceIndex) => NativeSdl.InternalJoystickGetDeviceProduct(deviceIndex);

        /// <summary>
        ///     Joysticks the get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        public static ushort JoystickGetDeviceProductVersion(int deviceIndex) => NativeSdl.InternalJoystickGetDeviceProductVersion(deviceIndex);

        /// <summary>
        ///     Joysticks the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        public static JoystickType JoystickGetDeviceType(int deviceIndex) => NativeSdl.InternalJoystickGetDeviceType(deviceIndex);

        /// <summary>
        ///     Joysticks the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        public static int JoystickGetDeviceInstanceId(int deviceIndex) => NativeSdl.InternalJoystickGetDeviceInstanceID(deviceIndex);

        /// <summary>
        ///     Joysticks the get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        public static ushort JoystickGetVendor(IntPtr joystick) => NativeSdl.InternalJoystickGetVendor(joystick);

        /// <summary>
        ///     Joysticks the get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        public static ushort JoystickGetProduct(IntPtr joystick) => NativeSdl.InternalJoystickGetProduct(joystick);

        /// <summary>
        ///     Joysticks the get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        public static ushort JoystickGetProductVersion(IntPtr joystick) => NativeSdl.InternalJoystickGetProductVersion(joystick);

        /// <summary>
        ///     Joysticks the get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        public static JoystickType JoystickGetType(IntPtr joystick) => NativeSdl.InternalJoystickGetType(joystick);

        /// <summary>
        ///     Joysticks the get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        public static bool JoystickGetAttached(IntPtr joystick) => NativeSdl.InternalJoystickGetAttached(joystick);

        /// <summary>
        ///     Joysticks the instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        public static int JoystickInstanceId(IntPtr joystick) => NativeSdl.InternalJoystickInstanceID(joystick);

        /// <summary>
        ///     Joysticks the current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        public static JoystickPowerLevel JoystickCurrentPowerLevel(IntPtr joystick) => NativeSdl.InternalJoystickCurrentPowerLevel(joystick);

        /// <summary>
        ///     Joysticks the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        public static IntPtr JoystickFromInstanceId(int instanceId) => NativeSdl.InternalJoystickFromInstanceID(instanceId);

        /// <summary>
        ///     Locks the joysticks
        /// </summary>
        public static void LockJoysticks()
        {
            NativeSdl.InternalLockJoysticks();
        }

        /// <summary>
        ///     Unlocks the joysticks
        /// </summary>
        public static void UnlockJoysticks()
        {
            NativeSdl.InternalUnlockJoysticks();
        }

        /// <summary>
        ///     Sdl the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        public static int GameControllerAddMapping(string mappingString) => NativeSdl.InternalGameControllerAddMapping(mappingString);

        /// <summary>
        ///     Games the controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        public static int GameControllerNumMappings() => NativeSdl.InternalGameControllerNumMappings();

        /// <summary>
        ///     Sdl the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        public static string GameControllerMappingForIndex(int mappingIndex)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForIndex(mappingIndex));

            return result;
        }

        /// <summary>
        ///     Sdl the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int GameControllerAddMappingsFromFile(string file) => NativeSdl.InternalGameControllerAddMappingsFromRW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Sdl the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        public static string GameControllerMappingForGuid(Guid guid)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForGUID(guid));

            return result;
        }

        /// <summary>
        ///     Sdl the game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        public static string GameControllerMapping(IntPtr gameController)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMapping(gameController));

            return result;
        }

        /// <summary>
        ///     Is the game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        public static bool IsGameController(int joystickIndex) => NativeSdl.InternalIsGameController(joystickIndex);

        /// <summary>
        ///     Sdl the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string GameControllerNameForIndex(int joystickIndex)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerNameForIndex(joystickIndex));

            return result;
        }

        /// <summary>
        ///     Sdl the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string GameControllerMappingForDeviceIndex(int joystickIndex)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForDeviceIndex(joystickIndex));

            return result;
        }

        /// <summary>
        ///     Games the controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GameControllerOpen(int joystickIndex) => NativeSdl.InternalGameControllerOpen(joystickIndex);

        /// <summary>
        ///     Sdl the game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        public static string GameControllerName(IntPtr gameController)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerName(gameController));

            return result;
        }

        /// <summary>
        ///     Games the controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        public static ushort GameControllerGetVendor(IntPtr gameController) => NativeSdl.InternalGameControllerGetVendor(gameController);

        /// <summary>
        ///     Games the controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        public static ushort GameControllerGetProduct(IntPtr gameController) => NativeSdl.InternalGameControllerGetProduct(gameController);

        /// <summary>
        ///     Games the controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        public static ushort GameControllerGetProductVersion(IntPtr gameController) => NativeSdl.InternalGameControllerGetProductVersion(gameController);


        /// <summary>
        ///     Games the controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        public static bool GameControllerGetAttached(IntPtr gameController) => NativeSdl.InternalGameControllerGetAttached(gameController);

        /// <summary>
        ///     Games the controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GameControllerGetJoystick(IntPtr gameController) => NativeSdl.InternalGameControllerGetJoystick(gameController);

        /// <summary>
        ///     Games the controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        public static int GameControllerEventState(int state) => NativeSdl.InternalGameControllerEventState(state);

        /// <summary>
        ///     Games the controller update
        /// </summary>
        public static void GameControllerUpdate()
        {
            NativeSdl.InternalGameControllerUpdate();
        }

        /// <summary>
        ///     Sdl the game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        public static GameControllerAxis GameControllerGetAxisFromString(string pchString) => NativeSdl.InternalGameControllerGetAxisFromString(pchString);

        /// <summary>
        ///     Sdl the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        public static string GameControllerGetStringForAxis(GameControllerAxis axis)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetStringForAxis(axis));

            return result;
        }

        /// <summary>
        ///     Sdl the game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        public static GameControllerButtonBind GameControllerGetBindForAxis(IntPtr gameController, GameControllerAxis axis)
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForAxis(
                gameController,
                axis
            );
            GameControllerButtonBind result = new GameControllerButtonBind
            {
                bindType = (GameControllerBindType) dumb.bindType
            };
            result.value.hat.Hat = dumb.unionVal0;
            result.value.hat.HatMask = dumb.unionVal1;
            return result;
        }

        /// <summary>
        ///     Games the controller get axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        public static short GameControllerGetAxis(IntPtr gameController, GameControllerAxis axis) => NativeSdl.InternalGameControllerGetAxis(gameController, axis);

        /// <summary>
        ///     Sdl the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        public static GameControllerButton GameControllerGetButtonFromString(string pchString) => NativeSdl.InternalGameControllerGetButtonFromString(pchString);

        /// <summary>
        ///     Sdl the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        public static string GameControllerGetStringForButton(GameControllerButton button)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetStringForButton(button));

            return result;
        }

        /// <summary>
        ///     Sdl the game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        public static GameControllerButtonBind GameControllerGetBindForButton(
            IntPtr gameController,
            GameControllerButton button
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForButton(
                gameController,
                button
            );
            GameControllerButtonBind result = new GameControllerButtonBind
            {
                bindType = (GameControllerBindType) dumb.bindType
            };
            result.value.hat.Hat = dumb.unionVal0;
            result.value.hat.HatMask = dumb.unionVal1;
            return result;
        }

        /// <summary>
        ///     Games the controller get button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        public static byte GameControllerGetButton(IntPtr gameController, GameControllerButton button) => NativeSdl.InternalGameControllerGetButton(gameController, button);

        /// <summary>
        ///     Games the controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        public static int GameControllerRumble(IntPtr gameController, ushort lowFrequencyRumble, ushort highFrequencyRumble, uint durationMs) => NativeSdl.InternalGameControllerRumble(gameController, lowFrequencyRumble, highFrequencyRumble, durationMs);

        /// <summary>
        ///     Games the controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        public static void GameControllerClose(IntPtr gameController)
        {
            NativeSdl.InternalGameControllerClose(gameController);
        }

        /// <summary>
        ///     Internals the sdl game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        public static IntPtr GameControllerFromInstanceId(int joyId) => NativeSdl.InternalGameControllerFromInstanceID(joyId);

        /// <summary>
        ///     Joysticks the is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        public static int JoystickIsHaptic(IntPtr joystick) => NativeSdl.InternalJoystickIsHaptic(joystick);

        /// <summary>
        ///     Mouses the is haptic
        /// </summary>
        /// <returns>The int</returns>
        public static int MouseIsHaptic() => NativeSdl.InternalMouseIsHaptic();

        /// <summary>
        ///     Nums the haptics
        /// </summary>
        /// <returns>The int</returns>
        public static int NumHaptics()
        {
            int result = NativeSdl.InternalNumHaptics();

            return result;
        }

        /// <summary>
        ///     Sdl the audio bit size using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The ushort</returns>
        public static ushort SdlAudioBitSize(ushort x) => (ushort) (x & AudioMaskBitSize);

        /// <summary>
        ///     Describes whether sdl audio is float
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsFloat(ushort x) => (x & AudioMaskDatatype) != 0;

        /// <summary>
        ///     Describes whether sdl audio is big endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsBigEndian(ushort x) => (x & AudioMaskEndian) != 0;

        /// <summary>
        ///     Describes whether sdl audio is signed
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsSigned(ushort x) => (x & AudioMaskSigned) != 0;

        /// <summary>
        ///     Describes whether sdl audio is int
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsInt(ushort x) => (x & AudioMaskDatatype) == 0;

        /// <summary>
        ///     Describes whether sdl audio is little endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsLittleEndian(ushort x) => (x & AudioMaskEndian) == 0;

        /// <summary>
        ///     Describes whether sdl audio is unsigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsUnsigned(ushort x) => (x & AudioMaskSigned) == 0;

        /// <summary>
        ///     Closes the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        public static void CloseAudioDevice(uint dev)
        {
            NativeSdl.InternalCloseAudioDevice(dev);
        }

        /// <summary>
        ///     Sdl the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The string</returns>
        public static string GetAudioDeviceName(int index, int isCapture)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDeviceName(index, isCapture));

            return result;
        }

        /// <summary>
        ///     Gets the audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        public static AudioStatus GetAudioDeviceStatus(uint dev) => NativeSdl.InternalGetAudioDeviceStatus(dev);

        /// <summary>
        ///     Sdl the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string GetAudioDriver(int index)
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDriver(index));

            return result;
        }

        /// <summary>
        ///     Sdl the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        public static string GetCurrentAudioDriver()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetCurrentAudioDriver());

            return result;
        }

        /// <summary>
        ///     Gets the num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        public static int GetNumAudioDevices(int isCapture)
        {
            int result = NativeSdl.InternalGetNumAudioDevices(isCapture);

            return result;
        }

        /// <summary>
        ///     Gets the num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        public static int GetNumAudioDrivers()
        {
            int result = NativeSdl.InternalGetNumAudioDrivers();

            return result;
        }

        /// <summary>
        ///     Sdl the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadWav(string file, out AudioSpec spec, out IntPtr audioBuf, out uint audioLen)
        {
            IntPtr result = NativeSdl.InternalLoadWAV_RW(RwFromFile(file, "rb"), 0, out spec, out audioBuf, out audioLen);

            return result;
        }

        /// <summary>
        ///     Locks the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        public static void LockAudioDevice(uint dev)
        {
            NativeSdl.InternalLockAudioDevice(dev);
        }

        /// <summary>
        ///     Mixes the audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        public static void MixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] src, uint len, int volume)
        {
            NativeSdl.InternalMixAudio(dst, src, len, volume);
        }

        /// <summary>
        ///     Mixes the audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        public static void MixAudioFormat(IntPtr dst, IntPtr src, ushort format, uint len, int volume)
        {
            NativeSdl.InternalMixAudioFormat(dst, src, format, len, volume);
        }

        /// <summary>
        ///     Mixes the audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        public static void MixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] src, ushort format, uint len, int volume)
        {
            NativeSdl.InternalMixAudioFormat(dst, src, format, len, volume);
        }

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        public static uint OpenAudioDevice(IntPtr device, int isCapture, ref AudioSpec desired, out AudioSpec obtained, int allowedChanges)
        {
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);

            return result;
        }

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        public static uint SdlOpenAudioDevice(string device, int isCapture, ref AudioSpec desired, out AudioSpec obtained, int allowedChanges)
        {
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);

            return result;
        }

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        public static void SdlPauseAudio(int pauseOn)
        {
            NativeSdl.InternalPauseAudio(pauseOn);
        }

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        public static void SdlPauseAudioDevice(uint dev, int pauseOn)
        {
            NativeSdl.InternalPauseAudioDevice(dev, pauseOn);
        }

        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        public static void SdlUnlockAudioDevice(uint dev)
        {
            NativeSdl.InternalUnlockAudioDevice(dev);
        }

        /// <summary>
        ///     Sdl the new audio stream using the specified src format
        /// </summary>
        /// <param name="srcFormat">The src format</param>
        /// <param name="srcChannels">The src channels</param>
        /// <param name="srcRate">The src rate</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dstChannels">The dst channels</param>
        /// <param name="dstRate">The dst rate</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SdlNewAudioStream(ushort srcFormat, byte srcChannels, int srcRate, ushort dstFormat, byte dstChannels, int dstRate)
        {
            IntPtr result = NativeSdl.InternalNewAudioStream(srcFormat, srcChannels, srcRate, dstFormat, dstChannels, dstRate);

            return result;
        }

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        public static int SdlAudioStreamPut(IntPtr stream, IntPtr buf, int len)
        {
            int result = NativeSdl.InternalAudioStreamPut(stream, buf, len);

            return result;
        }

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        public static int SdlAudioStreamGet(IntPtr stream, IntPtr buf, int len)
        {
            int result = NativeSdl.InternalAudioStreamGet(stream, buf, len);

            return result;
        }

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        public static int SdlAudioStreamAvailable(IntPtr stream)
        {
            int result = NativeSdl.InternalAudioStreamAvailable(stream);

            return result;
        }

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public static void SdlAudioStreamClear(IntPtr stream)
        {
            NativeSdl.InternalAudioStreamClear(stream);
        }

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public static void SdlFreeAudioStream(IntPtr stream)
        {
            NativeSdl.InternalFreeAudioStream(stream);
        }

        /// <summary>
        ///     Internals the sdl get performance frequency
        /// </summary>
        /// <returns>The ulong</returns>
        public static ulong GetPerformanceFrequency()
        {
            ulong result = NativeSdl.InternalGetPerformanceFrequency();

            return result;
        }

        /// <summary>
        ///     Gets the performance counter
        /// </summary>
        /// <returns>The ulong</returns>
        public static ulong GetPerformanceCounter()
        {
            ulong result = NativeSdl.InternalGetPerformanceCounter();

            return result;
        }

        /// <summary>
        ///     Sdl the define pixel format using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="order">The order</param>
        /// <param name="layout">The layout</param>
        /// <param name="bits">The bits</param>
        /// <param name="bytes">The bytes</param>
        /// <returns>The uint</returns>
        private static uint SdlDefinePixelFormat(TypePixel type, uint order, PackedLayout layout, byte bits, byte bytes) => (uint) ((1 << 28) | ((byte) type << 24) | ((byte) order << 20) | ((byte) layout << 16) | (bits << 8) | bytes);

        /// <summary>
        ///     Sdl the define pixel fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        public static uint SdlDefinePixelFourcc(byte a, byte b, byte c, byte d) => Fourcc(a, b, c, d);

        /// <summary>
        ///     Queues the audio using the specified device id
        /// </summary>
        /// <param name="deviceId">The device id</param>
        /// <param name="audioData">The audio data</param>
        /// <param name="wavLength">The wav length</param>
        public static void QueueAudio(int deviceId, byte[] audioData, uint wavLength) => NativeSdl.InternalQueueAudio(deviceId, audioData, wavLength);

        /// <summary>
        ///     Maps the rgb using the specified surface object format
        /// </summary>
        /// <param name="surfaceObjectFormat">The surface object format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        public static uint MapRgb(IntPtr surfaceObjectFormat, int r, int g, int b) => NativeSdl.InternalMapRGB(surfaceObjectFormat, r, g, b);

        /// <summary>
        ///     Unlocks the texture using the specified font texture
        /// </summary>
        /// <param name="fontTexture">The font texture</param>
        public static void UnlockTexture(IntPtr fontTexture) => NativeSdl.InternalUnlockTexture(fontTexture);

        /// <summary>
        ///     Locks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        public static void LockSurface(IntPtr surface) => NativeSdl.InternalLockSurface(surface);

        /// <summary>
        ///     Unlocks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        public static void UnlockSurface(IntPtr surface) => NativeSdl.InternalUnlockSurface(surface);
    }
}