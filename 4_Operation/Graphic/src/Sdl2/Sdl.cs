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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Sdl2.Delegates;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;

namespace Alis.Core.Graphic.Sdl2
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Fourcc(byte a, byte b, byte c, byte d) => (uint) (a | (b << 8) | (c << 16) | (d << 24));

        /// <summary>
        ///     Sdl the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IntPtr RwFromFile([IsNotNull] string file, [IsNotNull] string mode)
        {
            Validator.Validate(file, nameof(file));
            Validator.Validate(mode, nameof(mode));
            IntPtr result = NativeSdl.InternalRWFromFile(file, mode);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The result</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadFile([IsNotNull] string file, out IntPtr dataSize)
        {
            Validator.Validate(file, nameof(file));
            IntPtr result = NativeSdl.InternalLoadFile(file, out dataSize);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetError()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetError());
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetError([IsNotNull] string fmtAndArgList)
        {
            Validator.Validate(fmtAndArgList, nameof(fmtAndArgList));
            NativeSdl.InternalSetError(fmtAndArgList);
        }

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Init([IsNotNull] Init flags)
        {
            Validator.Validate(flags, nameof(flags));
            int result = NativeSdl.InternalInit(flags);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Quit()
        {
            NativeSdl.InternalQuit();
        }

        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WasInit([IsNotNull] Init flags)
        {
            Validator.Validate(flags, nameof(flags));
            uint result = NativeSdl.InternalWasInit(flags);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Clears the hints
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearHints()
        {
            NativeSdl.InternalClearHints();
        }

        /// <summary>
        ///     Sdl the get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetHint([IsNotNull] string name)
        {
            Validator.Validate(name, nameof(name));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetHint(name));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetHint([IsNotNull] string name, [IsNotNull] string value)
        {
            Validator.Validate(name, nameof(name));
            Validator.Validate(value, nameof(value));
            bool result = NativeSdl.InternalSetHint(name, value);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetHintWithPriority([IsNotNull] string name, [IsNotNull] string value, HintPriority priority)
        {
            Validator.Validate(name, nameof(name));
            Validator.Validate(value, nameof(value));
            Validator.Validate(priority, nameof(priority));
            bool result = NativeSdl.InternalSetHintWithPriority(name, value, priority);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetHintBoolean([IsNotNull] string name, bool defaultValue)
        {
            Validator.Validate(name, nameof(name));
            Validator.Validate(defaultValue, nameof(defaultValue));
            bool result = NativeSdl.InternalGetHintBoolean(name, defaultValue);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlVersion GetVersion() => new SdlVersion(2, 0, 18);

        /// <summary>
        ///     Sdl the window pos undefined display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosUndefinedDisplay([IsNotNull] int x) => (int) (WindowPos.WindowPosUndefinedMask | (WindowPos) x);

        /// <summary>
        ///     Describes whether sdl window pos is undefined
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsUndefined([IsNotNull] int x) => (x & 0xFFFF0000) == (long) WindowPos.WindowPosUndefinedMask;

        /// <summary>
        ///     Sdl the window pos centered display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosCenteredDisplay([IsNotNull] int x) => (int) (WindowPos.WindowPosCenteredMask | (WindowPos) x);

        /// <summary>
        ///     Describes whether sdl window pos is centered
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsCentered([IsNotNull] int x) => (x & 0xFFFF0000) == (long) WindowPos.WindowPosCenteredMask;

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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateWindow([IsNotNull] string title, [IsNotNull] int x, [IsNotNull] int y, [IsNotNull] int w, [IsNotNull] int h, [IsNotNull] WindowFlags flags)
        {
            Validator.Validate(title, nameof(title));
            Validator.Validate(x, nameof(x));
            Validator.Validate(y, nameof(y));
            Validator.Validate(w, nameof(w));
            Validator.Validate(h, nameof(h));
            Validator.Validate(flags, nameof(flags));
            IntPtr result = NativeSdl.InternalCreateWindow(title, x, y, w, h, flags);
            Validator.Validate(result, nameof(result));
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
        public static int CreateWindowAndRenderer([IsNotNull] int width, [IsNotNull] int height, [IsNotNull] WindowFlags windowFlags, out IntPtr window, out IntPtr renderer)
        {
            Validator.Validate(width, nameof(width));
            Validator.Validate(height, nameof(height));
            return NativeSdl.InternalCreateWindowAndRenderer(width, height, windowFlags, out window, out renderer);
        }

        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalDestroyWindow(window);
        }

        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetClosestDisplayMode([IsNotNull] int displayIndex, ref SdlDisplayMode mode, out SdlDisplayMode closest)
        {
            Validator.Validate(displayIndex, nameof(displayIndex));
            IntPtr result = NativeSdl.InternalGetClosestDisplayMode(displayIndex, ref mode, out closest);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetCurrentDisplayMode([IsNotNull] int displayIndex, out SdlDisplayMode mode)
        {
            Validator.Validate(displayIndex, nameof(displayIndex));
            int result = NativeSdl.InternalGetCurrentDisplayMode(displayIndex, out mode);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string GetCurrentVideoDriver()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetCurrentVideoDriver());
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDesktopDisplayMode([IsNotNull] int displayIndex, out SdlDisplayMode mode)
        {
            Validator.Validate(displayIndex, nameof(displayIndex));
            int result = NativeSdl.InternalGetDesktopDisplayMode(displayIndex, out mode);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetDisplayName([IsNotNull] int index)
        {
            Validator.Validate(index, nameof(index));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetDisplayName(index));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayBounds([IsNotNull] int displayIndex, out RectangleI rect)
        {
            Validator.Validate(displayIndex, nameof(displayIndex));
            int result = NativeSdl.InternalGetDisplayBounds(displayIndex, out rect);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayDpi([IsNotNull] int displayIndex, out float dDpi, out float hDpi, out float vDpi)
        {
            Validator.Validate(displayIndex, nameof(displayIndex));
            int result = NativeSdl.InternalGetDisplayDPI(displayIndex, out dDpi, out hDpi, out vDpi);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayMode([IsNotNull] int displayIndex, [IsNotNull] int modeIndex, out SdlDisplayMode mode)
        {
            Validator.Validate(displayIndex, nameof(displayIndex));
            Validator.Validate(modeIndex, nameof(modeIndex));
            int result = NativeSdl.InternalGetDisplayMode(displayIndex, modeIndex, out mode);
            Validator.Validate(result, nameof(result));
            return result;
        }


        /// <summary>
        ///     Gets the display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayUsableBounds([IsNotNull] int displayIndex, out RectangleI rect) => NativeSdl.InternalGetDisplayUsableBounds(displayIndex, out rect);


        /// <summary>
        ///     Gets the num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumDisplayModes([IsNotNull] int displayIndex) => NativeSdl.InternalGetNumDisplayModes(displayIndex);

        /// <summary>
        ///     Gets the num video displays
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumVideoDisplays() => NativeSdl.InternalGetNumVideoDisplays();

        /// <summary>
        ///     Gets the num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumVideoDrivers() => NativeSdl.InternalGetNumVideoDrivers();

        /// <summary>
        ///     Sdl the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetVideoDriver([IsNotNull] int index) => Marshal.PtrToStringAnsi(NativeSdl.InternalGetVideoDriver(index));

        /// <summary>
        ///     Gets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetWindowBrightness([IsNotNull] IntPtr window) => NativeSdl.InternalGetWindowBrightness(window);

        /// <summary>
        ///     Sets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowOpacity([IsNotNull] IntPtr window, [IsNotNull] float opacity) => NativeSdl.InternalSetWindowOpacity(window, opacity);

        /// <summary>
        ///     Gets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowOpacity([IsNotNull] IntPtr window, out float outOpacity) => NativeSdl.InternalGetWindowOpacity(window, out outOpacity);

        /// <summary>
        ///     Sets the window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowModalFor([IsNotNull] IntPtr modalWindow, [IsNotNull] IntPtr parentWindow) => NativeSdl.InternalSetWindowModalFor(modalWindow, parentWindow);

        /// <summary>
        ///     Sets the window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowInputFocus([IsNotNull] IntPtr window) => NativeSdl.InternalSetWindowInputFocus(window);

        /// <summary>
        ///     Sdl the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowData([IsNotNull] IntPtr window, [IsNotNull] string name) => NativeSdl.InternalGetWindowData(window, name);

        /// <summary>
        ///     Gets the window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowDisplayIndex([IsNotNull] IntPtr window) => NativeSdl.InternalGetWindowDisplayIndex(window);

        /// <summary>
        ///     Gets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowDisplayMode([IsNotNull] IntPtr window, out SdlDisplayMode mode)
        {
            Validator.Validate(window, nameof(window));
            int result = NativeSdl.InternalGetWindowDisplayMode(window, out mode);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowFlags([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            uint result = NativeSdl.InternalGetWindowFlags(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowFromId([IsNotNull] uint id)
        {
            Validator.Validate(id, nameof(id));
            IntPtr result = NativeSdl.InternalGetWindowFromID(id);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowGammaRamp([IsNotNull] IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(red, nameof(red));
            Validator.Validate(green, nameof(green));
            Validator.Validate(blue, nameof(blue));
            int result = NativeSdl.InternalGetWindowGammaRamp(window, red, green, blue);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetWindowGrab([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            bool result = NativeSdl.InternalGetWindowGrab(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetWindowKeyboardGrab([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            bool result = NativeSdl.InternalGetWindowKeyboardGrab(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetWindowMouseGrab([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            bool result = NativeSdl.InternalGetWindowMouseGrab(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowId([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            uint result = NativeSdl.InternalGetWindowID(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowPixelFormat([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            return NativeSdl.InternalGetWindowPixelFormat(window);
        }

        /// <summary>
        ///     Gets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowMaximumSize([IsNotNull] IntPtr window, out int maxW, out int maxH)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalGetWindowMaximumSize(window, out maxW, out maxH);
        }

        /// <summary>
        ///     Gets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowMinimumSize([IsNotNull] IntPtr window, out int minW, out int minH)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalGetWindowMinimumSize(window, out minW, out minH);
        }

        /// <summary>
        ///     Gets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowPosition([IsNotNull] IntPtr window, out int x, out int y)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalGetWindowPosition(window, out x, out y);
        }


        /// <summary>
        ///     Gets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowSize([IsNotNull] IntPtr window, out int w, out int h)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalGetWindowSize(window, out w, out h);
        }

        /// <summary>
        ///     Gets the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowSurface([IsNotNull] IntPtr window) => NativeSdl.InternalGetWindowSurface(window);

        /// <summary>
        ///     Sdl the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetWindowTitle([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetWindowTitle(window));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gls the bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex</param>
        /// <param name="texH">The tex</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BindTexture([IsNotNull] IntPtr texture, out float texW, out float texH)
        {
            Validator.Validate(texture, nameof(texture));
            return NativeSdl.InternalGlBindTexture(texture, out texW, out texH);
        }

        /// <summary>
        ///     Gls the create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateContext([IsNotNull] IntPtr window) => NativeSdl.InternalGlCreateContext(window);

        /// <summary>
        ///     Gls the delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteContext([IsNotNull] IntPtr context)
        {
            NativeSdl.InternalGlDeleteContext(context);
        }

        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetProcAddress([IsNotNull] string proc) => NativeSdl.InternalGlGetProcAddress(proc);

        /// <summary>
        ///     Sdl the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ExtensionSupported([IsNotNull] string extension) => NativeSdl.InternalGlExtensionSupported(extension);

        /// <summary>
        ///     Gls the reset attributes
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetAttribute([IsNotNull] GlAttr attr, out int value) => NativeSdl.InternalGlGetAttribute(attr, out value);

        /// <summary>
        ///     Gls the get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSwapInterval() => NativeSdl.InternalGlGetSwapInterval();

        /// <summary>
        ///     Gls the make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MakeCurrent([IsNotNull] IntPtr window, [IsNotNull] IntPtr context) => NativeSdl.InternalGlMakeCurrent(window, context);


        /// <summary>
        ///     Gls the get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCurrentWindow() => NativeSdl.InternalGlGetCurrentWindow();

        /// <summary>
        ///     Gls the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCurrentContext()
        {
            IntPtr result = NativeSdl.InternalGlGetCurrentContext();
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gls the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetDrawableSize([IsNotNull] IntPtr window, out int w, out int h)
        {
            NativeSdl.InternalGlGetDrawableSize(window, out w, out h);
        }

        /// <summary>
        ///     Gls the set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetAttributeByInt([IsNotNull] GlAttr attr, [IsNotNull] int value) => NativeSdl.InternalGlSetAttribute(attr, value);

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetAttributeByProfile([IsNotNull] GlAttr attr, [IsNotNull] GlProfile profile)
        {
            Validator.Validate(attr, nameof(attr));
            Validator.Validate(profile, nameof(profile));
            int result = NativeSdl.InternalGlSetAttribute(attr, (int) profile);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gls the set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSwapInterval([IsNotNull] int interval)
        {
            Validator.Validate(interval, nameof(interval));
            int result = NativeSdl.InternalGlSetSwapInterval(interval);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gls the swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SwapWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalGlSwapWindow(window);
        }

        /// <summary>
        ///     Gls the unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UnbindTexture([IsNotNull] IntPtr texture)
        {
            Validator.Validate(texture, nameof(texture));
            int result = NativeSdl.InternalGlUnbindTexture(texture);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Hides the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HideWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalHideWindow(window);
        }

        /// <summary>
        ///     Maximizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximizeWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalMaximizeWindow(window);
        }

        /// <summary>
        ///     Minimizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinimizeWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalMinimizeWindow(window);
        }

        /// <summary>
        ///     Raises the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RaiseWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalRaiseWindow(window);
        }

        /// <summary>
        ///     Restores the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RestoreWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalRestoreWindow(window);
        }

        /// <summary>
        ///     Sets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowBrightness([IsNotNull] IntPtr window, float brightness)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(brightness, nameof(brightness));
            int result = NativeSdl.InternalSetWindowBrightness(window, brightness);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SetWindowData([IsNotNull] IntPtr window, [IsNotNull] string name, [IsNotNull] IntPtr userdata)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(name, nameof(name));
            Validator.Validate(userdata, nameof(userdata));
            IntPtr result = NativeSdl.InternalSetWindowData(window, name, userdata);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowDisplayMode([IsNotNull] IntPtr window, ref SdlDisplayMode mode)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(mode, nameof(mode));
            int result = NativeSdl.InternalSetWindowDisplayMode(window, ref mode);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowDisplayMode([IsNotNull] IntPtr window, [IsNotNull] IntPtr mode)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(mode, nameof(mode));
            int result = NativeSdl.InternalSetWindowDisplayMode(window, mode);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowFullscreen([IsNotNull] IntPtr window, [IsNotNull] uint flags)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(flags, nameof(flags));
            int result = NativeSdl.InternalSetWindowFullscreen(window, flags);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowGammaRamp([IsNotNull] IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(red, nameof(red));
            Validator.Validate(green, nameof(green));
            Validator.Validate(blue, nameof(blue));
            int result = NativeSdl.InternalSetWindowGammaRamp(window, red, green, blue);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowGrab([IsNotNull] IntPtr window, [IsNotNull] bool grabbed)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(grabbed, nameof(grabbed));
            NativeSdl.InternalSetWindowGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowKeyboardGrab([IsNotNull] IntPtr window, [IsNotNull] bool grabbed)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(grabbed, nameof(grabbed));
            NativeSdl.InternalSetWindowKeyboardGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMouseGrab([IsNotNull] IntPtr window, bool grabbed)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(grabbed, nameof(grabbed));
            NativeSdl.InternalSetWindowMouseGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowIcon([IsNotNull] IntPtr window, [IsNotNull] IntPtr icon)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(icon, nameof(icon));
            NativeSdl.InternalSetWindowIcon(window, icon);
        }

        /// <summary>
        ///     Sets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMaximumSize([IsNotNull] IntPtr window, [IsNotNull] int maxW, [IsNotNull] int maxH)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(maxW, nameof(maxW));
            Validator.Validate(maxH, nameof(maxH));
            NativeSdl.InternalSetWindowMaximumSize(window, maxW, maxH);
        }

        /// <summary>
        ///     Sets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMinimumSize([IsNotNull] IntPtr window, [IsNotNull] int minW, [IsNotNull] int minH)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(minW, nameof(minW));
            Validator.Validate(minH, nameof(minH));
            NativeSdl.InternalSetWindowMinimumSize(window, minW, minH);
        }

        /// <summary>
        ///     Sets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowPosition([IsNotNull] IntPtr window, [IsNotNull] int x, [IsNotNull] int y)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(x, nameof(x));
            Validator.Validate(y, nameof(y));
            NativeSdl.InternalSetWindowPosition(window, x, y);
        }

        /// <summary>
        ///     Sets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowSize([IsNotNull] IntPtr window, [IsNotNull] int w, [IsNotNull] int h)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(w, nameof(w));
            Validator.Validate(h, nameof(h));
            NativeSdl.InternalSetWindowSize(window, w, h);
        }

        /// <summary>
        ///     Sets the window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowBordered([IsNotNull] IntPtr window, bool bordered)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(bordered, nameof(bordered));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowBordersSize([IsNotNull] IntPtr window, out int top, out int left, out int bottom, out int right)
        {
            Validator.Validate(window, nameof(window));
            int result = NativeSdl.InternalGetWindowBordersSize(window, out top, out left, out bottom, out right);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowResizable([IsNotNull] IntPtr window, bool resizable)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(resizable, nameof(resizable));
            NativeSdl.InternalSetWindowResizable(window, resizable);
        }

        /// <summary>
        ///     Sets the window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowAlwaysOnTop([IsNotNull] IntPtr window, bool onTop)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(onTop, nameof(onTop));
            NativeSdl.InternalSetWindowAlwaysOnTop(window, onTop);
        }

        /// <summary>
        ///     Sdl the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowTitle([IsNotNull] IntPtr window, [IsNotNull] string title)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(title, nameof(title));
            NativeSdl.InternalSetWindowTitle(window, title);
        }

        /// <summary>
        ///     Shows the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShowWindow([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            NativeSdl.InternalShowWindow(window);
        }

        /// <summary>
        ///     Updates the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateWindowSurface([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            int result = NativeSdl.InternalUpdateWindowSurface(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Updates the window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateWindowSurfaceRects([IsNotNull] IntPtr window, [In] RectangleI[] rects, [IsNotNull] int numRects)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(rects, nameof(rects));
            Validator.Validate(numRects, nameof(numRects));
            int result = NativeSdl.InternalUpdateWindowSurfaceRects(window, rects, numRects);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowHitTest([IsNotNull] IntPtr window, SdlHitTest callback, [IsNotNull] IntPtr callbackData)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(callbackData, nameof(callbackData));
            Validator.Validate(callback, nameof(callback));
            int result = NativeSdl.InternalSetWindowHitTest(window, callback, callbackData);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetGrabbedWindow()
        {
            IntPtr result = NativeSdl.InternalGetGrabbedWindow();
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowMouseRect([IsNotNull] IntPtr window, ref RectangleI rect)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(rect, nameof(rect));
            int result = NativeSdl.InternalSetWindowMouseRect(window, ref rect);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowMouseRect([IsNotNull] IntPtr window, [IsNotNull] IntPtr rect)
        {
            Validator.Validate(window, nameof(window));
            Validator.Validate(rect, nameof(rect));
            int result = NativeSdl.InternalSetWindowMouseRect(window, rect);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowMouseRect([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            IntPtr result = NativeSdl.InternalGetWindowMouseRect(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Flashes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FlashWindow([IsNotNull] IntPtr window, FlashOperation operation)
        {
            Validator.Validate(window, nameof(window));
            int result = NativeSdl.InternalFlashWindow(window, operation);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BlendMode ComposeCustomBlendMode([IsNotNull] BlendFactor srcColorFactor, [IsNotNull] BlendFactor dstColorFactor, [IsNotNull] BlendOperation colorOperation, [IsNotNull] BlendFactor srcAlphaFactor, [IsNotNull] BlendFactor dstAlphaFactor, [IsNotNull] BlendOperation alphaOperation)
        {
            Validator.Validate(srcColorFactor, nameof(srcColorFactor));
            Validator.Validate(dstColorFactor, nameof(dstColorFactor));
            Validator.Validate(colorOperation, nameof(colorOperation));
            Validator.Validate(srcAlphaFactor, nameof(srcAlphaFactor));
            Validator.Validate(dstAlphaFactor, nameof(dstAlphaFactor));
            Validator.Validate(alphaOperation, nameof(alphaOperation));
            BlendMode result = NativeSdl.InternalComposeCustomBlendMode(srcColorFactor, dstColorFactor, colorOperation, srcAlphaFactor, dstAlphaFactor, alphaOperation);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Creates the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRenderer([IsNotNull] IntPtr window, [IsNotNull] int index, RendererFlags flags) => NativeSdl.InternalCreateRenderer(window, index, flags);

        /// <summary>
        ///     Creates the software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateSoftwareRenderer([IsNotNull] IntPtr surface)
        {
            Validator.Validate(surface, nameof(surface));
            IntPtr result = NativeSdl.InternalCreateSoftwareRenderer(surface);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateTexture([IsNotNull] IntPtr renderer, [IsNotNull] uint format, [IsNotNull] int access, [IsNotNull] int w, [IsNotNull] int h) => NativeSdl.InternalCreateTexture(renderer, format, access, w, h);

        /// <summary>
        ///     Creates the texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateTextureFromSurface([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr surface)
        {
            Validator.Validate(renderer, nameof(renderer));
            Validator.Validate(surface, nameof(surface));
            IntPtr result = NativeSdl.InternalCreateTextureFromSurface(renderer, surface);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Destroys the renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyRenderer([IsNotNull] IntPtr renderer)
        {
            NativeSdl.InternalDestroyRenderer(renderer);
        }

        /// <summary>
        ///     Destroys the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyTexture([IsNotNull] IntPtr texture)
        {
            NativeSdl.InternalDestroyTexture(texture);
        }

        /// <summary>
        ///     Gets the num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumRenderDrivers() => NativeSdl.InternalGetNumRenderDrivers();

        /// <summary>
        ///     Gets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDrawBlendMode([IsNotNull] IntPtr renderer, out BlendMode blendMode) => NativeSdl.InternalGetRenderDrawBlendMode(renderer, out blendMode);

        /// <summary>
        ///     Sets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureScaleMode([IsNotNull] IntPtr texture, ScaleMode scaleMode) => NativeSdl.InternalSetTextureScaleMode(texture, scaleMode);

        /// <summary>
        ///     Gets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureScaleMode([IsNotNull] IntPtr texture, out ScaleMode scaleMode) => NativeSdl.InternalGetTextureScaleMode(texture, out scaleMode);

        /// <summary>
        ///     Sets the texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureUserData([IsNotNull] IntPtr texture, [IsNotNull] IntPtr userdata) => NativeSdl.InternalSetTextureUserData(texture, userdata);

        /// <summary>
        ///     Internals the sdl get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetTextureUserData([IsNotNull] IntPtr texture) => NativeSdl.InternalGetTextureUserData(texture);

        /// <summary>
        ///     Gets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDrawColor([IsNotNull] IntPtr renderer, out byte r, out byte g, out byte b, out byte a) => NativeSdl.InternalGetRenderDrawColor(renderer, out r, out g, out b, out a);

        /// <summary>
        ///     Gets the render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDriverInfo([IsNotNull] int index, out SdlRendererInfo info) => NativeSdl.InternalGetRenderDriverInfo(index, out info);

        /// <summary>
        ///     Gets the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetRenderer([IsNotNull] IntPtr window) => NativeSdl.InternalGetRenderer(window);

        /// <summary>
        ///     Gets the renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRendererInfo([IsNotNull] IntPtr renderer, out SdlRendererInfo info) => NativeSdl.InternalGetRendererInfo(renderer, out info);

        /// <summary>
        ///     Gets the renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRendererOutputSize([IsNotNull] IntPtr renderer, out int w, out int h) => NativeSdl.InternalGetRendererOutputSize(renderer, out w, out h);

        /// <summary>
        ///     Gets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureAlphaMod([IsNotNull] IntPtr texture, out byte alpha) => NativeSdl.InternalGetTextureAlphaMod(texture, out alpha);

        /// <summary>
        ///     Gets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureBlendMode([IsNotNull] IntPtr texture, out BlendMode blendMode) => NativeSdl.InternalGetTextureBlendMode(texture, out blendMode);

        /// <summary>
        ///     Gets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureColorMod([IsNotNull] IntPtr texture, out byte r, out byte g, out byte b) => NativeSdl.InternalGetTextureColorMod(texture, out r, out g, out b);

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTexture([IsNotNull] IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch) => NativeSdl.InternalLockTexture(texture, ref rect, out pixels, out pitch);

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTextureToSurface([IsNotNull] IntPtr texture, ref RectangleI rect, out IntPtr surface) => NativeSdl.InternalLockTextureToSurface(texture, ref rect, out surface);

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTextureToSurface([IsNotNull] IntPtr texture, [IsNotNull] IntPtr rect, out IntPtr surface)
        {
            Validator.Validate(texture, nameof(texture));
            Validator.Validate(rect, nameof(rect));
            int result = NativeSdl.InternalLockTextureToSurface(texture, rect, out surface);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Queries the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int QueryTexture([IsNotNull] IntPtr texture, out uint format, out int access, out int w, out int h)
        {
            Validator.Validate(texture, nameof(texture));
            int result = NativeSdl.InternalQueryTexture(texture, out format, out access, out w, out h);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Renders the clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderClear([IsNotNull] IntPtr renderer)
        {
            Validator.Validate(renderer, nameof(renderer));
            int result = NativeSdl.InternalRenderClear(renderer);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect)
        {
            Validator.Validate(renderer, nameof(renderer));
            Validator.Validate(texture, nameof(texture));
            Validator.Validate(srcRect, nameof(srcRect));
            Validator.Validate(dstRect, nameof(dstRect));
            int result = NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, ref dstRect);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleI dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, srcRect, ref dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, dstRect);

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopy(renderer, texture, srcRect, dstRect);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointI center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointI center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, center, flip);

        /// <summary>
        ///     Renders the draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLine([IsNotNull] IntPtr renderer, [IsNotNull] int x1, [IsNotNull] int y1, [IsNotNull] int x2, [IsNotNull] int y2) => NativeSdl.InternalRenderDrawLine(renderer, x1, y1, x2, y2);

        /// <summary>
        ///     Renders the draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLines([IsNotNull] IntPtr renderer, [In] PointI[] points, [IsNotNull] int count) => NativeSdl.InternalRenderDrawLines(renderer, points, count);

        /// <summary>
        ///     Renders the draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPoint([IsNotNull] IntPtr renderer, [IsNotNull] int x, [IsNotNull] int y) => NativeSdl.InternalRenderDrawPoint(renderer, x, y);

        /// <summary>
        ///     Renders the draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPoints([IsNotNull] IntPtr renderer, [In] PointI[] points, [IsNotNull] int count) => NativeSdl.InternalRenderDrawPoints(renderer, points, count);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRect([IsNotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderDrawRect(renderer, ref rect);

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRect([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect) => NativeSdl.InternalRenderDrawRect(renderer, rect);

        /// <summary>
        ///     Renders the draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRects([IsNotNull] IntPtr renderer, [In] RectangleI[] rects, [IsNotNull] int count) => NativeSdl.InternalRenderDrawRects(renderer, rects, count);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRect([IsNotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderFillRect(renderer, ref rect);

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRect([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect) => NativeSdl.InternalRenderFillRect(renderer, rect);

        /// <summary>
        ///     Renders the fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRects([IsNotNull] IntPtr renderer, [In] RectangleI[] rects, [IsNotNull] int count) => NativeSdl.InternalRenderFillRects(renderer, rects, count);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst) => NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, ref dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleF dst) => NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, ref dst);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, dstRect);

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect) => NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, dstRect);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dst, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, RendererFlip flip) => NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dst, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointF center, RendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, ref center, flip);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, ref dst, angle, center, flip);

        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointF center, RendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, ref center, flip);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleF dst, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, ref dst, angle, center, flip);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, center, flip);


        /// <summary>
        ///     Renders the copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlip flip) => NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, center, flip);


        /// <summary>
        ///     Renders the geometry using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderGeometry([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [In] SdlVertex[] vertices, [IsNotNull] int numVertices, [In] [IsNotNull] int[] indices, [IsNotNull] int numIndices) => NativeSdl.InternalRenderGeometry(renderer, texture, vertices, numVertices, indices, numIndices);

        /// <summary>
        ///     Renders the draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPointF([IsNotNull] IntPtr renderer, float x, float y) => NativeSdl.InternalRenderDrawPointF(renderer, x, y);

        /// <summary>
        ///     Renders the draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPointsF(IntPtr renderer, [In] PointF[] points, [IsNotNull] int count) => NativeSdl.InternalRenderDrawPointsF(renderer, points, count);

        /// <summary>
        ///     Renders the draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLineF([IsNotNull] IntPtr renderer, float x1, float y1, float x2, float y2) => NativeSdl.InternalRenderDrawLineF(renderer, x1, y1, x2, y2);


        /// <summary>
        ///     Renders the draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLinesF([IsNotNull] IntPtr renderer, [In] PointF[] points, [IsNotNull] int count) => NativeSdl.InternalRenderDrawLinesF(renderer, points, count);


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectF([IsNotNull] IntPtr renderer, ref RectangleF rect) => NativeSdl.InternalRenderDrawRectF(renderer, ref rect);


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect) => NativeSdl.InternalRenderDrawRectF(renderer, rect);

        /// <summary>
        ///     Renders the draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectsF([IsNotNull] IntPtr renderer, [In] RectangleF[] rects, [IsNotNull] int count) => NativeSdl.InternalRenderDrawRectsF(renderer, rects, count);


        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectF([IsNotNull] IntPtr renderer, RectangleF rect) => NativeSdl.InternalRenderFillRectF(renderer, rect);

        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect) => NativeSdl.InternalRenderFillRectF(renderer, rect);

        /// <summary>
        ///     Renders the fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectsF([IsNotNull] IntPtr renderer, [In] RectangleF[] rects, [IsNotNull] int count) => NativeSdl.InternalRenderFillRectsF(renderer, rects, count);


        /// <summary>
        ///     Renders the get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetClipRect([IsNotNull] IntPtr renderer, out RectangleI rect)
        {
            NativeSdl.InternalRenderGetClipRect(renderer, out rect);
        }


        /// <summary>
        ///     Renders the get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetLogicalSize([IsNotNull] IntPtr renderer, out int w, out int h)
        {
            NativeSdl.InternalRenderGetLogicalSize(renderer, out w, out h);
        }


        /// <summary>
        ///     Renders the get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetScale([IsNotNull] IntPtr renderer, out float scaleX, out float scaleY)
        {
            NativeSdl.InternalRenderGetScale(renderer, out scaleX, out scaleY);
        }


        /// <summary>
        ///     Renders the window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderWindowToLogical([IsNotNull] IntPtr renderer, [IsNotNull] int windowX, [IsNotNull] int windowY, out float logicalX, out float logicalY)
        {
            NativeSdl.InternalRenderWindowToLogical(renderer, windowX, windowY, out logicalX, out logicalY);
        }


        /// <summary>
        ///     Renders the logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderLogicalToWindow([IsNotNull] IntPtr renderer, float logicalX, float logicalY, out int windowX, out int windowY)
        {
            NativeSdl.InternalRenderLogicalToWindow(renderer, logicalX, logicalY, out windowX, out windowY);
        }


        /// <summary>
        ///     Renders the get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderGetViewport([IsNotNull] IntPtr renderer, out RectangleI rect) => NativeSdl.InternalRenderGetViewport(renderer, out rect);

        /// <summary>
        ///     Renders the present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderReadPixels([IsNotNull] IntPtr renderer, ref RectangleI rect, [IsNotNull] uint format, [IsNotNull] IntPtr pixels, [IsNotNull] int pitch) => NativeSdl.InternalRenderReadPixels(renderer, ref rect, format, pixels, pitch);


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetClipRect([IsNotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderSetClipRect(renderer, ref rect);


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetClipRect([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect) => NativeSdl.InternalRenderSetClipRect(renderer, rect);

        /// <summary>
        ///     Renders the set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetLogicalSize([IsNotNull] IntPtr renderer, [IsNotNull] int w, [IsNotNull] int h) => NativeSdl.InternalRenderSetLogicalSize(renderer, w, h);


        /// <summary>
        ///     Renders the set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetScale([IsNotNull] IntPtr renderer, float scaleX, float scaleY) => NativeSdl.InternalRenderSetScale(renderer, scaleX, scaleY);


        /// <summary>
        ///     Renders the set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetIntegerScale([IsNotNull] IntPtr renderer, bool enable) => NativeSdl.InternalRenderSetIntegerScale(renderer, enable);

        /// <summary>
        ///     Renders the set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetViewport([IsNotNull] IntPtr renderer, ref RectangleI rect) => NativeSdl.InternalRenderSetViewport(renderer, ref rect);

        /// <summary>
        ///     Sets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawBlendMode([IsNotNull] IntPtr renderer, BlendMode blendMode) => NativeSdl.InternalSetRenderDrawBlendMode(renderer, blendMode);

        /// <summary>
        ///     Sets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawColor([IsNotNull] IntPtr renderer, [IsNotNull] byte r, [IsNotNull] byte g, [IsNotNull] byte b, [IsNotNull] byte a) => NativeSdl.InternalSetRenderDrawColor(renderer, r, g, b, a);


        /// <summary>
        ///     Sets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderTarget([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture) => NativeSdl.InternalSetRenderTarget(renderer, texture);

        /// <summary>
        ///     Sets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureAlphaMod([IsNotNull] IntPtr texture, [IsNotNull] byte alpha) => NativeSdl.InternalSetTextureAlphaMod(texture, alpha);


        /// <summary>
        ///     Sets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureBlendMode([IsNotNull] IntPtr texture, BlendMode blendMode) => NativeSdl.InternalSetTextureBlendMode(texture, blendMode);


        /// <summary>
        ///     Sets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureColorMod([IsNotNull] IntPtr texture, [IsNotNull] byte r, [IsNotNull] byte g, [IsNotNull] byte b) => NativeSdl.InternalSetTextureColorMod(texture, r, g, b);


        /// <summary>
        ///     Unlocks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockTexture([IsNotNull] IntPtr texture)
        {
            NativeSdl.InternalUnlockTexture(texture);
        }

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateTexture([IsNotNull] IntPtr texture, ref RectangleI rect, [IsNotNull] IntPtr pixels, [IsNotNull] int pitch) => NativeSdl.InternalUpdateTexture(texture, ref rect, pixels, pitch);

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateTexture([IsNotNull] IntPtr texture, [IsNotNull] IntPtr rect, [IsNotNull] IntPtr pixels, [IsNotNull] int pitch) => NativeSdl.InternalUpdateTexture(texture, rect, pixels, pitch);

        /// <summary>
        ///     Updates the nv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uvPlane">The uv plane</param>
        /// <param name="uvPitch">The uv pitch</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateNvTexture([IsNotNull] IntPtr texture, ref RectangleI rect, [IsNotNull] IntPtr yPlane, [IsNotNull] int yPitch, [IsNotNull] IntPtr uvPlane, [IsNotNull] int uvPitch) => NativeSdl.InternalUpdateNVTexture(texture, ref rect, yPlane, yPitch, uvPlane, uvPitch);

        /// <summary>
        ///     Renders the target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderTargetSupported([IsNotNull] IntPtr renderer) => NativeSdl.InternalRenderTargetSupported(renderer);

        /// <summary>
        ///     Gets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetRenderTarget([IsNotNull] IntPtr renderer) => NativeSdl.InternalGetRenderTarget(renderer);

        /// <summary>
        ///     Renders the set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetVSync([IsNotNull] IntPtr renderer, [IsNotNull] int vsync) => NativeSdl.InternalRenderSetVSync(renderer, vsync);

        /// <summary>
        ///     Renders the is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RenderIsClipEnabled([IsNotNull] IntPtr renderer) => NativeSdl.InternalRenderIsClipEnabled(renderer);

        /// <summary>
        ///     Calculates the gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CalculateGammaRamp(float gamma, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp)
        {
            NativeSdl.InternalCalculateGammaRamp(gamma, ramp);
        }

        /// <summary>
        ///     Sdl the get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetPixelFormatName([IsNotNull] uint format)
        {
            Validator.Validate(format, nameof(format));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetPixelFormatName(format));
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool FormatEnumToMasks([IsNotNull] uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask) => NativeSdl.InternalPixelFormatEnumToMasks(format, out bpp, out rMask, out gMask, out bMask, out aMask);

        /// <summary>
        ///     Sets the palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The colors</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetPaletteColors([IsNotNull] IntPtr palette, [In] SdlColor[] colors, [IsNotNull] int firstColor, [IsNotNull] int nColors) => NativeSdl.InternalSetPaletteColors(palette, colors, firstColor, nColors);

        /// <summary>
        ///     Sets the pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetPixelFormatPalette([IsNotNull] IntPtr format, [IsNotNull] IntPtr palette) => NativeSdl.InternalSetPixelFormatPalette(format, palette);

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect)
        {
            Validator.Validate(src, nameof(src));
            Validator.Validate(srcRect, nameof(srcRect));
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(dstRect, nameof(dstRect));
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, ref dstRect);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([IsNotNull] IntPtr src, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect)
        {
            Validator.Validate(src, nameof(src));
            Validator.Validate(srcRect, nameof(srcRect));
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(dstRect, nameof(dstRect));
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, ref dstRect);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, [IsNotNull] IntPtr dstRect)
        {
            Validator.Validate(src, nameof(src));
            Validator.Validate(srcRect, nameof(srcRect));
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(dstRect, nameof(dstRect));
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, dstRect);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([IsNotNull] IntPtr src, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dst, [IsNotNull] IntPtr dstRect)
        {
            Validator.Validate(src, nameof(src));
            Validator.Validate(srcRect, nameof(srcRect));
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(dstRect, nameof(dstRect));
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, dstRect);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Converts the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ConvertSurface([IsNotNull] IntPtr src, [IsNotNull] IntPtr fmt, [IsNotNull] uint flags)
        {
            Validator.Validate(src, nameof(src));
            Validator.Validate(fmt, nameof(fmt));
            Validator.Validate(flags, nameof(flags));
            IntPtr result = NativeSdl.InternalConvertSurface(src, fmt, flags);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRgbSurfaceWithFormat([IsNotNull] uint flags, [IsNotNull] int width, [IsNotNull] int height, [IsNotNull] int depth, [IsNotNull] uint format) => NativeSdl.InternalCreateRGBSurfaceWithFormat(flags, width, height, depth, format);

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRect([IsNotNull] IntPtr dst, ref RectangleI rect, [IsNotNull] uint color) => NativeSdl.InternalFillRect(dst, ref rect, color);

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRect([IsNotNull] IntPtr dst, [IsNotNull] IntPtr rect, [IsNotNull] uint color) => NativeSdl.InternalFillRect(dst, rect, color);

        /// <summary>
        ///     Fills the rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRects([IsNotNull] IntPtr dst, [In] RectangleI[] rects, [IsNotNull] int count, [IsNotNull] uint color)
        {
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(rects, nameof(rects));
            Validator.Validate(count, nameof(count));
            Validator.Validate(color, nameof(color));
            int result = NativeSdl.InternalFillRects(dst, rects, count, color);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetClipRect([IsNotNull] IntPtr surface, out RectangleI rect)
        {
            Validator.Validate(surface, nameof(surface));
            NativeSdl.InternalGetClipRect(surface, out rect);
            Validator.Validate(rect, nameof(rect));
        }

        /// <summary>
        ///     Has the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasColorKey([IsNotNull] IntPtr surface) => NativeSdl.InternalHasColorKey(surface);

        /// <summary>
        ///     Gets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetColorKey([IsNotNull] IntPtr surface, out uint key) => NativeSdl.InternalGetColorKey(surface, out key);

        /// <summary>
        ///     Gets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceAlphaMod([IsNotNull] IntPtr surface, out byte alpha) => NativeSdl.InternalGetSurfaceAlphaMod(surface, out alpha);

        /// <summary>
        ///     Gets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceBlendMode([IsNotNull] IntPtr surface, out BlendMode blendMode) => NativeSdl.InternalGetSurfaceBlendMode(surface, out blendMode);

        /// <summary>
        ///     Gets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceColorMod([IsNotNull] IntPtr surface, out byte r, out byte g, out byte b) => NativeSdl.InternalGetSurfaceColorMod(surface, out r, out g, out b);

        /// <summary>
        ///     Sdl the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadBmp([IsNotNull] string file) => NativeSdl.InternalLoadBMP_RW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Sets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SetClipRect([IsNotNull] IntPtr surface, ref RectangleI rect) => NativeSdl.InternalSetClipRect(surface, ref rect);

        /// <summary>
        ///     Sets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetColorKey([IsNotNull] IntPtr surface, [IsNotNull] int flag, [IsNotNull] uint key) => NativeSdl.InternalSetColorKey(surface, flag, key);

        /// <summary>
        ///     Sets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceAlphaMod([IsNotNull] IntPtr surface, [IsNotNull] byte alpha) => NativeSdl.InternalSetSurfaceAlphaMod(surface, alpha);

        /// <summary>
        ///     Sets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceBlendMode([IsNotNull] IntPtr surface, BlendMode blendMode) => NativeSdl.InternalSetSurfaceBlendMode(surface, blendMode);

        /// <summary>
        ///     Sets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceColorMod([IsNotNull] IntPtr surface, [IsNotNull] byte r, [IsNotNull] byte g, [IsNotNull] byte b) => NativeSdl.InternalSetSurfaceColorMod(surface, r, g, b);

        /// <summary>
        ///     Sets the surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfacePalette([IsNotNull] IntPtr surface, [IsNotNull] IntPtr palette) => NativeSdl.InternalSetSurfacePalette(surface, palette);

        /// <summary>
        ///     Sets the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceRle([IsNotNull] IntPtr surface, [IsNotNull] int flag) => NativeSdl.InternalSetSurfaceRLE(surface, flag);

        /// <summary>
        ///     Has the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasSurfaceRle([IsNotNull] IntPtr surface) => NativeSdl.InternalHasSurfaceRLE(surface);

        /// <summary>
        ///     Uppers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpperBlit([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalUpperBlit(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Uppers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpperBlitScaled([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect) => NativeSdl.InternalUpperBlitScaled(src, ref srcRect, dst, ref dstRect);

        /// <summary>
        ///     Has the clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasClipboardText() => NativeSdl.InternalHasClipboardText();

        /// <summary>
        ///     Sdl the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetClipboardText()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetClipboardText());
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetClipboardText([IsNotNull] string text) => NativeSdl.InternalSetClipboardText(text);

        /// <summary>
        ///     Peeps the events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PeepEvents([Out] SdlEvent[] events, [IsNotNull] int numEvents, EventAction action, EventType minType, EventType maxType) => NativeSdl.InternalPeepEvents(events, numEvents, action, minType, maxType);


        /// <summary>
        ///     Has the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEvent(EventType type) => NativeSdl.InternalHasEvent(type);

        /// <summary>
        ///     Has the events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEvents(EventType minType, EventType maxType) => NativeSdl.InternalHasEvents(minType, maxType);

        /// <summary>
        ///     Flushes the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FlushEvent([IsNotNull] EventType type)
        {
            NativeSdl.InternalFlushEvent(type);
        }


        /// <summary>
        ///     Polls the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ExcludeFromCodeCoverage]
        public static int PollEvent(out SdlEvent sdlEvent) => NativeSdl.InternalPollEvent(out sdlEvent);

        /// <summary>
        ///     Pushes the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PushEvent(ref SdlEvent sdlEvent) => NativeSdl.InternalPushEvent(ref sdlEvent);

        /// <summary>
        ///     Sets the event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEventFilter(SdlEventFilter filter, [IsNotNull] IntPtr userdata)
        {
            NativeSdl.InternalSetEventFilter(filter, userdata);
        }

        /// <summary>
        ///     Adds the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddEventWatch(SdlEventFilter filter, [IsNotNull] IntPtr userdata)
        {
            NativeSdl.InternalAddEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Del the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DelEventWatch(SdlEventFilter filter, [IsNotNull] IntPtr userdata)
        {
            NativeSdl.InternalDelEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Sdl the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetEventState(EventType type) => NativeSdl.InternalEventState(type, Query);

        /// <summary>
        ///     Registers the events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RegisterEvents([IsNotNull] int numEvents) => NativeSdl.InternalRegisterEvents(numEvents);

        /// <summary>
        ///     Sdl the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode ScanCodeToKeyCode(SdlScancode x) => (SdlKeycode) ((int) x | KScancodeMask);

        /// <summary>
        ///     Gets the keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetKeyboardFocus() => NativeSdl.InternalGetKeyboardFocus();

        /// <summary>
        ///     Gets the keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetKeyboardState(out int numKeys) => NativeSdl.InternalGetKeyboardState(out numKeys);

        /// <summary>
        ///     Gets the mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KeyMod GetModState() => NativeSdl.InternalGetModState();

        /// <summary>
        ///     Sets the mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetModState(KeyMod modState)
        {
            NativeSdl.InternalSetModState(modState);
        }

        /// <summary>
        ///     Gets the key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode GetKeyFromScancode(SdlScancode scancode) => NativeSdl.InternalGetKeyFromScancode(scancode);

        /// <summary>
        ///     Gets the scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlScancode GetScancodeFromKey(SdlKeycode key) => NativeSdl.InternalGetScancodeFromKey(key);

        /// <summary>
        ///     Sdl the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetScancodeName(SdlScancode scancode)
        {
            Validator.Validate(scancode, nameof(scancode));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetScancodeName(scancode));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlScancode GetScancodeFromName([IsNotNull] string name) => NativeSdl.InternalGetScancodeFromName(name);

        /// <summary>
        ///     Sdl the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SGetKeyName(SdlKeycode key)
        {
            Validator.Validate(key, nameof(key));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetKeyName(key));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode GetKeyFromName([IsNotNull] string name) => NativeSdl.InternalGetKeyFromName(name);

        /// <summary>
        ///     Starts the text input
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StartTextInput()
        {
            NativeSdl.InternalStartTextInput();
        }

        /// <summary>
        ///     Is the text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTextInputActive() => NativeSdl.InternalIsTextInputActive();

        /// <summary>
        ///     Stops the text input
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StopTextInput()
        {
            NativeSdl.InternalStopTextInput();
        }

        /// <summary>
        ///     Sets the text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTextInputRect(ref RectangleI rect)
        {
            Validator.Validate(rect, nameof(rect));
            NativeSdl.InternalSetTextInputRect(ref rect);
        }

        /// <summary>
        ///     Has the screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasScreenKeyboardSupport()
        {
            bool result = NativeSdl.InternalHasScreenKeyboardSupport();
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Is the screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsScreenKeyboardShown([IsNotNull] IntPtr window)
        {
            Validator.Validate(window, nameof(window));
            bool result = NativeSdl.InternalIsScreenKeyboardShown(window);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetMouseFocus() => NativeSdl.InternalGetMouseFocus();

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateOutXAndY(out int x, out int y) => NativeSdl.InternalGetMouseState(out x, out y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateXAndYOut([IsNotNull] IntPtr x, out int y) => NativeSdl.InternalGetMouseState(x, out y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateXOutAndY(out int x, [IsNotNull] IntPtr y) => NativeSdl.InternalGetMouseState(out x, y);

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateToXAndY([IsNotNull] IntPtr x, [IsNotNull] IntPtr y) => NativeSdl.InternalGetMouseState(x, y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateOutXAndOutY(out int x, out int y) => NativeSdl.InternalGetGlobalMouseState(out x, out y);

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateXAndY([IsNotNull] IntPtr x, [IsNotNull] IntPtr y) => NativeSdl.InternalGetGlobalMouseState(x, y);

        /// <summary>
        ///     Gets the relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetRelativeMouseState(out int x, out int y) => NativeSdl.InternalGetRelativeMouseState(out x, out y);

        /// <summary>
        ///     Warps the mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WarpMouseInWindow([IsNotNull] IntPtr window, [IsNotNull] int x, [IsNotNull] int y)
        {
            NativeSdl.InternalWarpMouseInWindow(window, x, y);
        }

        /// <summary>
        ///     Warps the mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WarpMouseGlobal([IsNotNull] int x, [IsNotNull] int y) => NativeSdl.InternalWarpMouseGlobal(x, y);

        /// <summary>
        ///     Sets the relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRelativeMouseMode(bool enabled) => NativeSdl.InternalSetRelativeMouseMode(enabled);

        /// <summary>
        ///     Captures the mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CaptureMouse([IsNotNull] bool enabled) => NativeSdl.InternalCaptureMouse(enabled);

        /// <summary>
        ///     Gets the relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateCursor([IsNotNull] IntPtr data, [IsNotNull] IntPtr mask, [IsNotNull] int w, [IsNotNull] int h, [IsNotNull] int hotX, [IsNotNull] int hotY) => NativeSdl.InternalCreateCursor(data, mask, w, h, hotX, hotY);

        /// <summary>
        ///     Creates the color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateColorCursor([IsNotNull] IntPtr surface, [IsNotNull] int hotX, [IsNotNull] int hotY) => NativeSdl.InternalCreateColorCursor(surface, hotX, hotY);

        /// <summary>
        ///     Creates the system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateSystemCursor(SystemCursor id) => NativeSdl.InternalCreateSystemCursor(id);

        /// <summary>
        ///     Sets the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCursor([IsNotNull] IntPtr cursor)
        {
            NativeSdl.InternalSetCursor(cursor);
        }

        /// <summary>
        ///     Gets the cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCursor() => NativeSdl.InternalGetCursor();

        /// <summary>
        ///     Frees the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FreeCursor([IsNotNull] IntPtr cursor)
        {
            NativeSdl.InternalFreeCursor(cursor);
        }

        /// <summary>
        ///     Shows the cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ShowCursor([IsNotNull] int toggle) => NativeSdl.InternalShowCursor(toggle);

        /// <summary>
        ///     Sdl the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Button([IsNotNull] uint x) => (uint) (1 << ((int) x - 1));

        /// <summary>
        ///     Gets the touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetTouchDevice([IsNotNull] int index) => NativeSdl.InternalGetTouchDevice(index);

        /// <summary>
        ///     Gets the num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumTouchFingers(long touchId) => NativeSdl.InternalGetNumTouchFingers(touchId);

        /// <summary>
        ///     Gets the touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetTouchFinger([IsNotNull] long touchId, [IsNotNull] int index) => NativeSdl.InternalGetTouchFinger(touchId, index);

        /// <summary>
        ///     Gets the touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TouchDeviceType GetTouchDeviceType([IsNotNull] long touchId) => NativeSdl.InternalGetTouchDeviceType(touchId);


        /// <summary>
        ///     Joysticks the rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickRumble([IsNotNull] IntPtr joystick, [IsNotNull] ushort lowFrequencyRumble, [IsNotNull] ushort highFrequencyRumble, [IsNotNull] uint durationMs) => NativeSdl.InternalJoystickRumble(joystick, lowFrequencyRumble, highFrequencyRumble, durationMs);

        /// <summary>
        ///     Joysticks the rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickRumbleTriggers([IsNotNull] IntPtr joystick, [IsNotNull] ushort leftRumble, [IsNotNull] ushort rightRumble, [IsNotNull] uint durationMs) => NativeSdl.InternalJoystickRumbleTriggers(joystick, leftRumble, rightRumble, durationMs);

        /// <summary>
        ///     Joysticks the close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickClose([IsNotNull] IntPtr joystick)
        {
            NativeSdl.InternalJoystickClose(joystick);
        }

        /// <summary>
        ///     Joysticks the event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickEventState([IsNotNull] int state) => NativeSdl.InternalJoystickEventState(state);

        /// <summary>
        ///     Joysticks the get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short JoystickGetAxis([IsNotNull] IntPtr joystick, [IsNotNull] int axis) => NativeSdl.InternalJoystickGetAxis(joystick, axis);

        /// <summary>
        ///     Joysticks the get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JoystickGetAxisInitialState([IsNotNull] IntPtr joystick, [IsNotNull] int axis, out ushort state) => NativeSdl.InternalJoystickGetAxisInitialState(joystick, axis, out state);

        /// <summary>
        ///     Joysticks the get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickGetBall([IsNotNull] IntPtr joystick, [IsNotNull] int ball, out int dx, out int dy) => NativeSdl.InternalJoystickGetBall(joystick, ball, out dx, out dy);

        /// <summary>
        ///     Joysticks the get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte JoystickGetButton([IsNotNull] IntPtr joystick, [IsNotNull] int button) => NativeSdl.InternalJoystickGetButton(joystick, button);

        /// <summary>
        ///     Joysticks the get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte JoystickGetHat([IsNotNull] IntPtr joystick, [IsNotNull] int hat) => NativeSdl.InternalJoystickGetHat(joystick, hat);

        /// <summary>
        ///     Sdl the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickName([IsNotNull] IntPtr joystick)
        {
            Validator.Validate(joystick, nameof(joystick));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickName(joystick));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickNameForIndex([IsNotNull] int deviceIndex)
        {
            Validator.Validate(deviceIndex, nameof(deviceIndex));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickNameForIndex(deviceIndex));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Joysticks the num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumAxes([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickNumAxes(joystick);

        /// <summary>
        ///     Joysticks the num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumBalls([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickNumBalls(joystick);

        /// <summary>
        ///     Joysticks the num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumButtons([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickNumButtons(joystick);

        /// <summary>
        ///     Joysticks the num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumHats([IsNotNull] IntPtr joystick)
        {
            Validator.Validate(joystick, nameof(joystick));
            int result = NativeSdl.InternalJoystickNumHats(joystick);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Joysticks the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickOpen([IsNotNull] int deviceIndex)
        {
            Validator.Validate(deviceIndex, nameof(deviceIndex));
            IntPtr result = NativeSdl.InternalJoystickOpen(deviceIndex);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Joysticks the update
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickUpdate()
        {
            NativeSdl.InternalJoystickUpdate();
        }

        /// <summary>
        ///     Nums the joysticks
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumJoysticks()
        {
            int result = NativeSdl.InternalNumJoysticks();
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Joysticks the get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetDeviceGuid([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceGUID(deviceIndex);

        /// <summary>
        ///     Joysticks the get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetGuid(IntPtr joystick) => NativeSdl.InternalJoystickGetGUID(joystick);

        /// <summary>
        ///     Joysticks the get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickGetGuidString(Guid guid, [IsNotNull] byte[] pszGuid, [IsNotNull] int cbGuid)
        {
            NativeSdl.InternalJoystickGetGUIDString(guid, pszGuid, cbGuid);
        }

        /// <summary>
        ///     Sdl the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetGuidFromString([IsNotNull] string pchGuid) => NativeSdl.InternalJoystickGetGUIDFromString(pchGuid);

        /// <summary>
        ///     Joysticks the get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceVendor([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceVendor(deviceIndex);

        /// <summary>
        ///     Joysticks the get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceProduct([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceProduct(deviceIndex);

        /// <summary>
        ///     Joysticks the get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceProductVersion([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceProductVersion(deviceIndex);

        /// <summary>
        ///     Joysticks the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JoystickType JoystickGetDeviceType([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceType(deviceIndex);

        /// <summary>
        ///     Joysticks the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickGetDeviceInstanceId([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickGetDeviceInstanceID(deviceIndex);

        /// <summary>
        ///     Joysticks the get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetVendor([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetVendor(joystick);

        /// <summary>
        ///     Joysticks the get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetProduct([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetProduct(joystick);

        /// <summary>
        ///     Joysticks the get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetProductVersion([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetProductVersion(joystick);

        /// <summary>
        ///     Sdl the joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickGetSerial([IsNotNull] IntPtr joystick)
        {
            Validator.Validate(joystick, nameof(joystick));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickGetSerial(joystick));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Joysticks the get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JoystickType JoystickGetType([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetType(joystick);

        /// <summary>
        ///     Joysticks the get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JoystickGetAttached([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickGetAttached(joystick);

        /// <summary>
        ///     Joysticks the instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickInstanceId([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickInstanceID(joystick);

        /// <summary>
        ///     Joysticks the current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static JoystickPowerLevel JoystickCurrentPowerLevel([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickCurrentPowerLevel(joystick);

        /// <summary>
        ///     Joysticks the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickFromInstanceId([IsNotNull] int instanceId) => NativeSdl.InternalJoystickFromInstanceID(instanceId);

        /// <summary>
        ///     Locks the joysticks
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockJoysticks()
        {
            NativeSdl.InternalLockJoysticks();
        }

        /// <summary>
        ///     Unlocks the joysticks
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockJoysticks()
        {
            NativeSdl.InternalUnlockJoysticks();
        }

        /// <summary>
        ///     Joysticks the from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickFromPlayerIndex([IsNotNull] int playerIndex) => NativeSdl.InternalJoystickFromPlayerIndex(playerIndex);

        /// <summary>
        ///     Joysticks the set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickSetPlayerIndex([IsNotNull] IntPtr joystick, [IsNotNull] int playerIndex)
        {
            NativeSdl.InternalJoystickSetPlayerIndex(joystick, playerIndex);
        }

        /// <summary>
        ///     Sdl the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="nAxes">The axes</param>
        /// <param name="nButtons">The buttons</param>
        /// <param name="nHats">The hats</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlJoystickAttachVirtual([IsNotNull] int type, [IsNotNull] int nAxes, [IsNotNull] int nButtons, [IsNotNull] int nHats) => NativeSdl.InternalJoystickAttachVirtual(type, nAxes, nButtons, nHats);

        /// <summary>
        ///     Joysticks the detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickDetachVirtual([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickDetachVirtual(deviceIndex);

        /// <summary>
        ///     Joysticks the is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JoystickIsVirtual([IsNotNull] int deviceIndex) => NativeSdl.InternalJoystickIsVirtual(deviceIndex);

        /// <summary>
        ///     Joysticks the set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualAxis([IsNotNull] IntPtr joystick, [IsNotNull] int axis, short value) => NativeSdl.InternalJoystickSetVirtualAxis(joystick, axis, value);

        /// <summary>
        ///     Joysticks the set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualButton([IsNotNull] IntPtr joystick, [IsNotNull] int button, [IsNotNull] byte value) => NativeSdl.InternalJoystickSetVirtualButton(joystick, button, value);

        /// <summary>
        ///     Joysticks the set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualHat([IsNotNull] IntPtr joystick, [IsNotNull] int hat, [IsNotNull] byte value) => NativeSdl.InternalJoystickSetVirtualHat(joystick, hat, value);

        /// <summary>
        ///     Joysticks the has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JoystickHasLed([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickHasLED(joystick);

        /// <summary>
        ///     Joysticks the has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JoystickHasRumble([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickHasRumble(joystick);

        /// <summary>
        ///     Joysticks the has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool JoystickHasRumbleTriggers([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickHasRumbleTriggers(joystick);


        /// <summary>
        ///     Joysticks the set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetLed([IsNotNull] IntPtr joystick, [IsNotNull] byte red, [IsNotNull] byte green, [IsNotNull] byte blue) => NativeSdl.InternalJoystickSetLED(joystick, red, green, blue);

        /// <summary>
        ///     Joysticks the send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSendEffect([IsNotNull] IntPtr joystick, [IsNotNull] IntPtr data, [IsNotNull] int size) => NativeSdl.InternalJoystickSendEffect(joystick, data, size);

        /// <summary>
        ///     Sdl the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerAddMapping([IsNotNull] string mappingString) => NativeSdl.InternalGameControllerAddMapping(mappingString);

        /// <summary>
        ///     Games the controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerNumMappings() => NativeSdl.InternalGameControllerNumMappings();

        /// <summary>
        ///     Sdl the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForIndex([IsNotNull] int mappingIndex)
        {
            Validator.Validate(mappingIndex, nameof(mappingIndex));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForIndex(mappingIndex));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerAddMappingsFromFile([IsNotNull] string file) => NativeSdl.InternalGameControllerAddMappingsFromRW(RwFromFile(file, "rb"), 1);

        /// <summary>
        ///     Sdl the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForGuid(Guid guid)
        {
            Validator.Validate(guid, nameof(guid));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForGUID(guid));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMapping([IsNotNull] IntPtr gameController)
        {
            Validator.Validate(gameController, nameof(gameController));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMapping(gameController));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Is the game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGameController([IsNotNull] int joystickIndex) => NativeSdl.InternalIsGameController(joystickIndex);

        /// <summary>
        ///     Sdl the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerNameForIndex([IsNotNull] int joystickIndex)
        {
            Validator.Validate(joystickIndex, nameof(joystickIndex));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerNameForIndex(joystickIndex));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForDeviceIndex([IsNotNull] int joystickIndex)
        {
            Validator.Validate(joystickIndex, nameof(joystickIndex));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForDeviceIndex(joystickIndex));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Games the controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerOpen([IsNotNull] int joystickIndex) => NativeSdl.InternalGameControllerOpen(joystickIndex);

        /// <summary>
        ///     Sdl the game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerName([IsNotNull] IntPtr gameController)
        {
            Validator.Validate(gameController, nameof(gameController));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerName(gameController));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Games the controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetVendor([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetVendor(gameController);

        /// <summary>
        ///     Games the controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetProduct([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetProduct(gameController);

        /// <summary>
        ///     Games the controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetProductVersion([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetProductVersion(gameController);


        /// <summary>
        ///     Sdl the game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetSerial([IsNotNull] IntPtr gameController)
        {
            Validator.Validate(gameController, nameof(gameController));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetSerial(gameController));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Games the controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerGetAttached([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetAttached(gameController);

        /// <summary>
        ///     Games the controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerGetJoystick([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetJoystick(gameController);

        /// <summary>
        ///     Games the controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerEventState([IsNotNull] int state) => NativeSdl.InternalGameControllerEventState(state);

        /// <summary>
        ///     Games the controller update
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerUpdate()
        {
            NativeSdl.InternalGameControllerUpdate();
        }

        /// <summary>
        ///     Sdl the game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameControllerAxis GameControllerGetAxisFromString([IsNotNull] string pchString) => NativeSdl.InternalGameControllerGetAxisFromString(pchString);

        /// <summary>
        ///     Sdl the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetStringForAxis(GameControllerAxis axis)
        {
            Validator.Validate(axis, nameof(axis));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetStringForAxis(axis));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButtonBind GameControllerGetBindForAxis([IsNotNull] IntPtr gameController, GameControllerAxis axis)
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForAxis(
                gameController,
                axis
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind
            {
                bindType = (GameControllerBindType) dumb.bindType
            };
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /// <summary>
        ///     Games the controller get axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GameControllerGetAxis([IsNotNull] IntPtr gameController, GameControllerAxis axis) => NativeSdl.InternalGameControllerGetAxis(gameController, axis);

        /// <summary>
        ///     Sdl the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GameControllerButton GameControllerGetButtonFromString([IsNotNull] string pchString) => NativeSdl.InternalGameControllerGetButtonFromString(pchString);

        /// <summary>
        ///     Sdl the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetStringForButton(GameControllerButton button)
        {
            Validator.Validate(button, nameof(button));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetStringForButton(button));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButtonBind GameControllerGetBindForButton(
            IntPtr gameController,
            GameControllerButton button
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForButton(
                gameController,
                button
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind
            {
                bindType = (GameControllerBindType) dumb.bindType
            };
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        /// <summary>
        ///     Games the controller get button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GameControllerGetButton([IsNotNull] IntPtr gameController, GameControllerButton button) => NativeSdl.InternalGameControllerGetButton(gameController, button);

        /// <summary>
        ///     Games the controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerRumble([IsNotNull] IntPtr gameController, [IsNotNull] ushort lowFrequencyRumble, [IsNotNull] ushort highFrequencyRumble, [IsNotNull] uint durationMs) => NativeSdl.InternalGameControllerRumble(gameController, lowFrequencyRumble, highFrequencyRumble, durationMs);

        /// <summary>
        ///     Games the controller rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerRumbleTriggers([IsNotNull] IntPtr gameController, [IsNotNull] ushort leftRumble, [IsNotNull] ushort rightRumble, [IsNotNull] uint durationMs) => NativeSdl.InternalGameControllerRumbleTriggers(gameController, leftRumble, rightRumble, durationMs);

        /// <summary>
        ///     Games the controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerClose([IsNotNull] IntPtr gameController)
        {
            NativeSdl.InternalGameControllerClose(gameController);
        }

        /// <summary>
        ///     Internals the sdl game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerFromInstanceId([IsNotNull] int joyId) => NativeSdl.InternalGameControllerFromInstanceID(joyId);

        /// <summary>
        ///     Games the controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerType GameControllerTypeForIndex([IsNotNull] int joystickIndex) => NativeSdl.InternalGameControllerTypeForIndex(joystickIndex);

        /// <summary>
        ///     Games the controller get type using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl game controller type</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerType GameControllerGetType([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetType(gameController);

        /// <summary>
        ///     Games the controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerFromPlayerIndex([IsNotNull] int playerIndex) => NativeSdl.InternalGameControllerFromPlayerIndex(playerIndex);


        /// <summary>
        ///     Games the controller set player index using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="playerIndex">The player index</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerSetPlayerIndex([IsNotNull] IntPtr gameController, [IsNotNull] int playerIndex)
        {
            NativeSdl.InternalGameControllerSetPlayerIndex(gameController, playerIndex);
        }


        /// <summary>
        ///     Games the controller has led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerHasLed([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerHasLED(gameController);


        /// <summary>
        ///     Games the controller has rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerHasRumble([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerHasRumble(gameController);

        /// <summary>
        ///     Games the controller has rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerHasRumbleTriggers([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerHasRumbleTriggers(gameController);

        /// <summary>
        ///     Games the controller set led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSetLed([IsNotNull] IntPtr gameController, [IsNotNull] byte red, [IsNotNull] byte green, [IsNotNull] byte blue) => NativeSdl.InternalGameControllerSetLED(gameController, red, green, blue);


        /// <summary>
        ///     Games the controller has axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerHasAxis([IsNotNull] IntPtr gameController, GameControllerAxis axis) => NativeSdl.InternalGameControllerHasAxis(gameController, axis);

        /// <summary>
        ///     Games the controller has button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerHasButton([IsNotNull] IntPtr gameController, GameControllerButton button) => NativeSdl.InternalGameControllerHasButton(gameController, button);

        /// <summary>
        ///     Games the controller get num touchpads using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetNumTouchpads([IsNotNull] IntPtr gameController) => NativeSdl.InternalGameControllerGetNumTouchpads(gameController);

        /// <summary>
        ///     Games the controller get num touchpad fingers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetNumTouchpadFingers([IsNotNull] IntPtr gameController, [IsNotNull] int touchpad) => NativeSdl.InternalGameControllerGetNumTouchpadFingers(gameController, touchpad);

        /// <summary>
        ///     Games the controller get touchpad finger using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <param name="finger">The finger</param>
        /// <param name="state">The state</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pressure">The pressure</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetTouchpadFinger([IsNotNull] IntPtr gameController, [IsNotNull] int touchpad, [IsNotNull] int finger, out byte state, out float x, out float y, out float pressure) => NativeSdl.InternalGameControllerGetTouchpadFinger(gameController, touchpad, finger, out state, out x, out y, out pressure);

        /// <summary>
        ///     Games the controller has sensor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerHasSensor([IsNotNull] IntPtr gameController, SensorType type) => NativeSdl.InternalGameControllerHasSensor(gameController, type);

        /// <summary>
        ///     Games the controller set sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSetSensorEnabled([IsNotNull] IntPtr gameController, SensorType type, bool enabled) => NativeSdl.InternalGameControllerSetSensorEnabled(gameController, type, enabled);

        /// <summary>
        ///     Games the controller is sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GameControllerIsSensorEnabled([IsNotNull] IntPtr gameController, SensorType type) => NativeSdl.InternalGameControllerIsSensorEnabled(gameController, type);


        /// <summary>
        ///     Games the controller get sensor data using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetSensorData([IsNotNull] IntPtr gameController, SensorType type, [IsNotNull] IntPtr data, [IsNotNull] int numValues) => NativeSdl.InternalGameControllerGetSensorData(gameController, type, data, numValues);

        /// <summary>
        ///     Games the controller get sensor data rate using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GameControllerGetSensorDataRate([IsNotNull] IntPtr gameController, SensorType type) => NativeSdl.InternalGameControllerGetSensorDataRate(gameController, type);


        /// <summary>
        ///     Games the controller send effect using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSendEffect([IsNotNull] IntPtr gameController, [IsNotNull] IntPtr data, [IsNotNull] int size) => NativeSdl.InternalGameControllerSendEffect(gameController, data, size);


        /// <summary>
        ///     Joysticks the is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickIsHaptic([IsNotNull] IntPtr joystick) => NativeSdl.InternalJoystickIsHaptic(joystick);

        /// <summary>
        ///     Mouses the is haptic
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MouseIsHaptic() => NativeSdl.InternalMouseIsHaptic();

        /// <summary>
        ///     Nums the haptics
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumHaptics()
        {
            int result = NativeSdl.InternalNumHaptics();
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Nums the sensors
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumSensors() => NativeSdl.InternalNumSensors();

        /// <summary>
        ///     Sdl the sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SensorGetDeviceName([IsNotNull] int deviceIndex)
        {
            Validator.Validate(deviceIndex, nameof(deviceIndex));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalSensorGetDeviceName(deviceIndex));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sensors the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SensorType SensorGetDeviceType([IsNotNull] int deviceIndex) => NativeSdl.InternalSensorGetDeviceType(deviceIndex);

        /// <summary>
        ///     Sensors the get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetDeviceNonPortableType([IsNotNull] int deviceIndex) => NativeSdl.InternalSensorGetDeviceNonPortableType(deviceIndex);

        /// <summary>
        ///     Sensors the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetDeviceInstanceId([IsNotNull] int deviceIndex) => NativeSdl.InternalSensorGetDeviceInstanceID(deviceIndex);

        /// <summary>
        ///     Sensors the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SensorOpen([IsNotNull] int deviceIndex)
        {
            Validator.Validate(deviceIndex, nameof(deviceIndex));
            IntPtr result = NativeSdl.InternalSensorOpen(deviceIndex);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sensors the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SensorFromInstanceId([IsNotNull] int instanceId) => NativeSdl.InternalSensorFromInstanceID(instanceId);

        /// <summary>
        ///     Sdl the sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SensorGetName([IsNotNull] IntPtr sensor)
        {
            Validator.Validate(sensor, nameof(sensor));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalSensorGetName(sensor));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sensors the get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SensorType SensorGetType([IsNotNull] IntPtr sensor) => NativeSdl.InternalSensorGetType(sensor);

        /// <summary>
        ///     Sensors the get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetNonPortableType([IsNotNull] IntPtr sensor) => NativeSdl.InternalSensorGetNonPortableType(sensor);

        /// <summary>
        ///     Sensors the get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetInstanceId([IsNotNull] IntPtr sensor) => NativeSdl.InternalSensorGetInstanceID(sensor);

        /// <summary>
        ///     Sensors the get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetData([IsNotNull] IntPtr sensor, float[] data, [IsNotNull] int numValues) => NativeSdl.InternalSensorGetData(sensor, data, numValues);

        /// <summary>
        ///     Sensors the close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SensorClose([IsNotNull] IntPtr sensor)
        {
            NativeSdl.InternalSensorClose(sensor);
        }

        /// <summary>
        ///     Sensors the update
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SensorUpdate()
        {
            NativeSdl.InternalSensorUpdate();
        }

        /// <summary>
        ///     Locks the sensors
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockSensors()
        {
            NativeSdl.InternalLockSensors();
        }

        /// <summary>
        ///     Unlocks the sensors
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockSensors()
        {
            NativeSdl.InternalUnlockSensors();
        }

        /// <summary>
        ///     Sdl the audio bit size using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The ushort</returns>
        public static ushort SdlAudioBitSize([IsNotNull] ushort x) => (ushort) (x & AudioMaskBitSize);

        /// <summary>
        ///     Describes whether sdl audio is float
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsFloat([IsNotNull] ushort x) => (x & AudioMaskDatatype) != 0;

        /// <summary>
        ///     Describes whether sdl audio is big endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsBigEndian([IsNotNull] ushort x) => (x & AudioMaskEndian) != 0;

        /// <summary>
        ///     Describes whether sdl audio is signed
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsSigned([IsNotNull] ushort x) => (x & AudioMaskSigned) != 0;

        /// <summary>
        ///     Describes whether sdl audio is int
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsInt([IsNotNull] ushort x) => (x & AudioMaskDatatype) == 0;

        /// <summary>
        ///     Describes whether sdl audio is little endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsLittleEndian([IsNotNull] ushort x) => (x & AudioMaskEndian) == 0;

        /// <summary>
        ///     Describes whether sdl audio is unsigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsUnsigned([IsNotNull] ushort x) => (x & AudioMaskSigned) == 0;

        /// <summary>
        ///     Closes the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CloseAudioDevice([IsNotNull] uint dev)
        {
            NativeSdl.InternalCloseAudioDevice(dev);
        }

        /// <summary>
        ///     Sdl the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The string</returns>
        public static string GetAudioDeviceName([IsNotNull] int index, [IsNotNull] int isCapture)
        {
            Validator.Validate(index, nameof(index));
            Validator.Validate(isCapture, nameof(isCapture));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDeviceName(index, isCapture));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioStatus GetAudioDeviceStatus([IsNotNull] uint dev) => NativeSdl.InternalGetAudioDeviceStatus(dev);

        /// <summary>
        ///     Sdl the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string GetAudioDriver([IsNotNull] int index)
        {
            Validator.Validate(index, nameof(index));
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDriver(index));
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetCurrentAudioDriver()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetCurrentAudioDriver());
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumAudioDevices([IsNotNull] int isCapture)
        {
            Validator.Validate(isCapture, nameof(isCapture));
            int result = NativeSdl.InternalGetNumAudioDevices(isCapture);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumAudioDrivers()
        {
            int result = NativeSdl.InternalGetNumAudioDrivers();
            Validator.Validate(result, nameof(result));
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
        public static IntPtr LoadWav([IsNotNull] string file, out SdlAudioSpec spec, out IntPtr audioBuf, out uint audioLen)
        {
            Validator.Validate(file, nameof(file));
            IntPtr result = NativeSdl.InternalLoadWAV_RW(RwFromFile(file, "rb"), 0, out spec, out audioBuf, out audioLen);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Locks the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockAudioDevice([IsNotNull] uint dev)
        {
            Validator.Validate(dev, nameof(dev));
            NativeSdl.InternalLockAudioDevice(dev);
        }

        /// <summary>
        ///     Mixes the audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [IsNotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [IsNotNull] byte[] src, [IsNotNull] uint len, [IsNotNull] int volume)
        {
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(src, nameof(src));
            Validator.Validate(len, nameof(len));
            Validator.Validate(volume, nameof(volume));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudioFormat([IsNotNull] IntPtr dst, [IsNotNull] IntPtr src, [IsNotNull] ushort format, [IsNotNull] uint len, [IsNotNull] int volume)
        {
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(src, nameof(src));
            Validator.Validate(format, nameof(format));
            Validator.Validate(len, nameof(len));
            Validator.Validate(volume, nameof(volume));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [IsNotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [IsNotNull] byte[] src, [IsNotNull] ushort format, [IsNotNull] uint len, [IsNotNull] int volume)
        {
            Validator.Validate(dst, nameof(dst));
            Validator.Validate(src, nameof(src));
            Validator.Validate(format, nameof(format));
            Validator.Validate(len, nameof(len));
            Validator.Validate(volume, nameof(volume));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint OpenAudioDevice([IsNotNull] IntPtr device, [IsNotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [IsNotNull] int allowedChanges)
        {
            Validator.Validate(device, nameof(device));
            Validator.Validate(isCapture, nameof(isCapture));
            Validator.Validate(desired, nameof(desired));
            Validator.Validate(allowedChanges, nameof(allowedChanges));
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlOpenAudioDevice(string device, int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, int allowedChanges)
        {
            Validator.Validate(device, nameof(device));
            Validator.Validate(isCapture, nameof(isCapture));
            Validator.Validate(desired, nameof(desired));
            Validator.Validate(allowedChanges, nameof(allowedChanges));
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlPauseAudio([IsNotNull] int pauseOn)
        {
            Validator.Validate(pauseOn, nameof(pauseOn));
            NativeSdl.InternalPauseAudio(pauseOn);
        }

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlPauseAudioDevice([IsNotNull] uint dev, [IsNotNull] int pauseOn)
        {
            Validator.Validate(dev, nameof(dev));
            Validator.Validate(pauseOn, nameof(pauseOn));
            NativeSdl.InternalPauseAudioDevice(dev, pauseOn);
        }

        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlUnlockAudioDevice([IsNotNull] uint dev)
        {
            Validator.Validate(dev, nameof(dev));
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
        public static IntPtr SdlNewAudioStream([IsNotNull] ushort srcFormat, [IsNotNull] byte srcChannels, [IsNotNull] int srcRate, [IsNotNull] ushort dstFormat, [IsNotNull] byte dstChannels, [IsNotNull] int dstRate)
        {
            Validator.Validate(srcFormat, nameof(srcFormat));
            Validator.Validate(srcChannels, nameof(srcChannels));
            Validator.Validate(srcRate, nameof(srcRate));
            Validator.Validate(dstFormat, nameof(dstFormat));
            Validator.Validate(dstChannels, nameof(dstChannels));
            Validator.Validate(dstRate, nameof(dstRate));
            IntPtr result = NativeSdl.InternalNewAudioStream(srcFormat, srcChannels, srcRate, dstFormat, dstChannels, dstRate);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamPut([IsNotNull] IntPtr stream, [IsNotNull] IntPtr buf, [IsNotNull] int len)
        {
            Validator.Validate(stream, nameof(stream));
            Validator.Validate(buf, nameof(buf));
            Validator.Validate(len, nameof(len));
            int result = NativeSdl.InternalAudioStreamPut(stream, buf, len);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamGet([IsNotNull] IntPtr stream, [IsNotNull] IntPtr buf, [IsNotNull] int len)
        {
            Validator.Validate(stream, nameof(stream));
            Validator.Validate(buf, nameof(buf));
            Validator.Validate(len, nameof(len));
            int result = NativeSdl.InternalAudioStreamGet(stream, buf, len);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamAvailable([IsNotNull] IntPtr stream)
        {
            Validator.Validate(stream, nameof(stream));
            int result = NativeSdl.InternalAudioStreamAvailable(stream);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlAudioStreamClear([IsNotNull] IntPtr stream)
        {
            Validator.Validate(stream, nameof(stream));
            NativeSdl.InternalAudioStreamClear(stream);
        }

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlFreeAudioStream([IsNotEmpty] IntPtr stream)
        {
            Validator.Validate(stream, nameof(stream));
            NativeSdl.InternalFreeAudioStream(stream);
        }

        /// <summary>
        ///     Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlGetAudioDeviceSpec([IsNotNull] int index, [IsNotNull] int isCapture, out SdlAudioSpec spec)
        {
            Validator.Validate(index, nameof(index));
            Validator.Validate(isCapture, nameof(isCapture));
            int result = NativeSdl.InternalGetAudioDeviceSpec(index, isCapture, out spec);
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Internals the sdl get performance frequency
        /// </summary>
        /// <returns>The ulong</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetPerformanceFrequency()
        {
            ulong result = NativeSdl.InternalGetPerformanceFrequency();
            Validator.Validate(result, nameof(result));
            return result;
        }

        /// <summary>
        ///     Gets the performance counter
        /// </summary>
        /// <returns>The ulong</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetPerformanceCounter()
        {
            ulong result = NativeSdl.InternalGetPerformanceCounter();
            Validator.Validate(result, nameof(result));
            return result;
        }
    }
}