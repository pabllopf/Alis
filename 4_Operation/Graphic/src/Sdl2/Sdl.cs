// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Sdl.cs
// 
//  Author: Pablo Perdomo Falcón
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
        ///     The sdl window pos undefined mask
        /// </summary>
        public const int WindowPosUndefinedMask = 0x1FFF0000;

        /// <summary>
        ///     The sdl window pos centered mask
        /// </summary>
        public const int WindowPosCenteredMask = 0x2FFF0000;

        /// <summary>
        ///     The sdl window pos undefined
        /// </summary>
        public const int WindowPosUndefined = 0x1FFF0000;

        /// <summary>
        ///     The sdl window pos centered
        /// </summary>
        public const int WindowPosCentered = 0x2FFF0000;

        /// <summary>
        ///     The sdl sw surface
        /// </summary>
        public const uint SwSurface = 0x00000000;

        /// <summary>
        ///     The sdl pre alloc
        /// </summary>
        public const uint PreAlloc = 0x00000001;

        /// <summary>
        ///     The sdl rle accel
        /// </summary>
        public const uint RleAccel = 0x00000002;

        /// <summary>
        ///     The sdl dont free
        /// </summary>
        public const uint DontFree = 0x00000004;

        /// <summary>
        ///     The sdl pressed
        /// </summary>
        public const byte Pressed = 1;

        /// <summary>
        ///     The sdl released
        /// </summary>
        public const byte Released = 0;

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
        ///     The max value
        /// </summary>
        public const uint TouchMouseId = uint.MaxValue;

        /// <summary>
        ///     The sdl hat centered
        /// </summary>
        public const byte HatCentered = 0x00;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatUp = 0x01;

        /// <summary>
        ///     The sdl hat right
        /// </summary>
        public const byte HatRight = 0x02;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatDown = 0x04;

        /// <summary>
        ///     The sdl hat left
        /// </summary>
        public const byte HatLeft = 0x08;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatRightUp = HatRight | HatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatRightDown = HatRight | HatDown;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte HatLeftUp = HatLeft | HatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte HatLeftDown = HatLeft | HatDown;


        /// <summary>
        ///     The sdl iphone max g force
        /// </summary>
        public const float IphoneMaxGForce = 5.0f;

        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        public const ushort HapticConstant = 1 << 0;

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        public const ushort HapticSine = 1 << 1;

        /// <summary>
        ///     The sdl haptic left right
        /// </summary>
        public const ushort HapticLeftRight = 1 << 2;

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        public const ushort HapticTriangle = 1 << 3;

        /// <summary>
        ///     The sdl haptic saw tooth up
        /// </summary>
        public const ushort HapticSawToothUp = 1 << 4;

        /// <summary>
        ///     The sdl haptic saw tooth down
        /// </summary>
        public const ushort HapticSawToothDown = 1 << 5;

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        public const ushort HapticSpring = 1 << 7;

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        public const ushort HapticDamper = 1 << 8;

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        public const ushort HapticInertia = 1 << 9;

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        public const ushort HapticFriction = 1 << 10;

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        public const ushort HapticCustom = 1 << 11;

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        public const ushort HapticGain = 1 << 12;

        /// <summary>
        ///     The sdl haptic auto center
        /// </summary>
        public const ushort HapticAutoCenter = 1 << 13;

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        public const ushort HapticStatus = 1 << 14;

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        public const ushort HapticPauseVar = 1 << 15;

        /// <summary>
        ///     The sdl haptic polar
        /// </summary>
        public const byte HapticPolar = 0;

        /// <summary>
        ///     The sdl haptic cartesian
        /// </summary>
        public const byte HapticCartesian = 1;

        /// <summary>
        ///     The sdl haptic spherical
        /// </summary>
        public const byte HapticSpherical = 2;

        /// <summary>
        ///     The sdl haptic steering axis
        /// </summary>
        public const byte HapticSteeringAxis = 3;

        /// <summary>
        ///     The sdl haptic infinity
        /// </summary>
        public const uint HapticInfinity = 4294967295U;

        /// <summary>
        ///     The sdl standard gravity
        /// </summary>
        public const float StandardGravity = 9.80665f;

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
        ///     The sdl patch level
        /// </summary>
        public static int GetGlCompiledVersion()
        {
            return 2 * 1000 + 0 * 100 + 18;
        }

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
        ///     The sdl pixel type index8
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
        public static readonly uint PixelFormatRgb24 = SdlDefinePixelFormat(TypePixel.TypeArrayU8, (uint) SdlArrayOrder.SdlArrayOrderRgb, 0, 24, 3);

        /// <summary>
        ///     The sdl array order bgr
        /// </summary>
        public static readonly uint PixelFormatBgr24 = SdlDefinePixelFormat(TypePixel.TypeArrayU8, (uint) SdlArrayOrder.SdlArrayOrderBgr, 0, 24, 3);

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
        ///     The sdl define pixel four
        /// </summary>
        public static readonly uint GlFormatYuy2 = SdlDefinePixelFourcc((byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        public static readonly uint GlFormatUy = SdlDefinePixelFourcc((byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y');

        /// <summary>
        ///     The sdl define pixel four
        /// </summary>
        public static readonly uint GlFormatYv = SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U');

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
        ///     Sdl the fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Fourcc(byte a, byte b, byte c, byte d)
        {
            return (uint) (a | (b << 8) | (c << 16) | (d << 24));
        }

        /// <summary>
        ///     Sdl the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RwFromFile([NotNull] string file, [NotNull] string mode)
        {
            Validator.ValidateInput(file);
            Validator.ValidateInput(mode);
            IntPtr result = NativeSdl.InternalRWFromFile(file, mode);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sdl the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadFile([NotNull] string file, out IntPtr dataSize)
        {
            Validator.ValidateInput(file);
            IntPtr result = NativeSdl.InternalLoadFile(file, out dataSize);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sdl the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetError()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetError());
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetError([NotNull] string fmtAndArgList)
        {
            Validator.ValidateInput(fmtAndArgList);
            NativeSdl.InternalSetError(fmtAndArgList);
        }

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Init([NotNull] SdlInit flags)
        {
            Validator.ValidateInput(flags);
            int result = NativeSdl.InternalInit(flags);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [return: NotNull]
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint WasInit([NotNull] SdlInit flags)
        {
            Validator.ValidateInput(flags);
            uint result = NativeSdl.InternalWasInit(flags);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Clears the hints
        /// </summary>
        [return: NotNull]
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetHint([NotNull] string name)
        {
            Validator.ValidateInput(name);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetHint(name));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool SetHint([NotNull] string name, [NotNull] string value)
        {
            Validator.ValidateInput(name);
            Validator.ValidateInput(value);
            SdlBool result = NativeSdl.InternalSetHint(name, value);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool SetHintWithPriority([NotNull] string name, [NotNull] string value, SdlHintPriority priority)
        {
            Validator.ValidateInput(name);
            Validator.ValidateInput(value);
            Validator.ValidateInput(priority);
            SdlBool result = NativeSdl.InternalSetHintWithPriority(name, value, priority);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetHintBoolean([NotNull] string name, SdlBool defaultValue)
        {
            Validator.ValidateInput(name);
            Validator.ValidateInput(defaultValue);
            SdlBool result = NativeSdl.InternalGetHintBoolean(name, defaultValue);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlVersion GetVersion()
        {
            return new SdlVersion(2, 0, 18);
        }

        /// <summary>
        ///     Sdl the window pos undefined display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosUndefinedDisplay([NotNull] int x)
        {
            return WindowPosUndefinedMask | x;
        }

        /// <summary>
        ///     Describes whether sdl window pos is undefined
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsUndefined([NotNull] int x)
        {
            return (x & 0xFFFF0000) == WindowPosUndefinedMask;
        }

        /// <summary>
        ///     Sdl the window pos centered display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int WindowPosCenteredDisplay([NotNull] int x)
        {
            return WindowPosCenteredMask | x;
        }

        /// <summary>
        ///     Describes whether sdl window pos is centered
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool WindowPosIsCentered([NotNull] int x)
        {
            return (x & 0xFFFF0000) == WindowPosCenteredMask;
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateWindow([NotNull] string title, [NotNull] int x, [NotNull] int y, [NotNull] int w, [NotNull] int h, [NotNull] SdlWindowFlags flags)
        {
            Validator.ValidateInput(title);
            Validator.ValidateInput(x);
            Validator.ValidateInput(y);
            Validator.ValidateInput(w);
            Validator.ValidateInput(h);
            Validator.ValidateInput(flags);
            var result = NativeSdl.InternalCreateWindow(title, x, y, w, h, flags);
            Validator.ValidateOutput(result);
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
        public static int CreateWindowAndRenderer([NotNull] int width, [NotNull] int height, [NotNull] SdlWindowFlags windowFlags, out IntPtr window, out IntPtr renderer)
        {
            Validator.ValidateInput(width);
            Validator.ValidateInput(height);
            return NativeSdl.InternalCreateWindowAndRenderer(width, height, windowFlags, out window, out renderer);
        }
        
        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalDestroyWindow(window);
        }
        
        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetClosestDisplayMode([NotNull] int displayIndex, ref SdlDisplayMode mode, out SdlDisplayMode closest)
        {
            Validator.ValidateInput(displayIndex);
            IntPtr result = NativeSdl.InternalGetClosestDisplayMode(displayIndex, ref mode, out closest);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetCurrentDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetCurrentDisplayMode(displayIndex, out mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string GetCurrentVideoDriver()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetCurrentVideoDriver());
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDesktopDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetDesktopDisplayMode(displayIndex, out mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetDisplayName([NotNull] int index)
        {
            Validator.ValidateInput(index);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetDisplayName(index));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayBounds([NotNull] int displayIndex, out RectangleI rect)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetDisplayBounds(displayIndex, out rect);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayDpi([NotNull] int displayIndex, out float dDpi, out float hDpi, out float vDpi)
        {
            Validator.ValidateInput(displayIndex);
            int result = NativeSdl.InternalGetDisplayDPI(displayIndex, out dDpi, out hDpi, out vDpi);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Gets the display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayMode([NotNull] int displayIndex, [NotNull] int modeIndex, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(displayIndex);
            Validator.ValidateInput(modeIndex);
            int result = NativeSdl.InternalGetDisplayMode(displayIndex, modeIndex, out mode);
            Validator.ValidateOutput(result);
            return result;
        }


        /// <summary>
        ///     Gets the display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDisplayUsableBounds([NotNull] int displayIndex, out RectangleI rect)
        {
            return NativeSdl.InternalGetDisplayUsableBounds(displayIndex, out rect);
        }


        /// <summary>
        ///     Gets the num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumDisplayModes([NotNull] int displayIndex)
        {
            return NativeSdl.InternalGetNumDisplayModes(displayIndex);
        }

        /// <summary>
        ///     Gets the num video displays
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumVideoDisplays()
        {
            return NativeSdl.InternalGetNumVideoDisplays();
        }

        /// <summary>
        ///     Gets the num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumVideoDrivers()
        {
            return NativeSdl.InternalGetNumVideoDrivers();
        }

        /// <summary>
        ///     Sdl the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetVideoDriver([NotNull] int index)
        {
            return Marshal.PtrToStringAnsi(NativeSdl.InternalGetVideoDriver(index));
        }

        /// <summary>
        ///     Gets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetWindowBrightness([NotNull] IntPtr window)
        {
            return NativeSdl.InternalGetWindowBrightness(window);
        }

        /// <summary>
        ///     Sets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowOpacity([NotNull] IntPtr window, [NotNull] float opacity)
        {
            return NativeSdl.InternalSetWindowOpacity(window, opacity);
        }

        /// <summary>
        ///     Gets the window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowOpacity([NotNull] IntPtr window, out float outOpacity)
        {
            return NativeSdl.InternalGetWindowOpacity(window, out outOpacity);
        }

        /// <summary>
        ///     Sets the window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowModalFor([NotNull] IntPtr modalWindow, [NotNull] IntPtr parentWindow)
        {
            return NativeSdl.InternalSetWindowModalFor(modalWindow, parentWindow);
        }

        /// <summary>
        ///     Sets the window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowInputFocus([NotNull] IntPtr window)
        {
            return NativeSdl.InternalSetWindowInputFocus(window);
        }

        /// <summary>
        ///     Sdl the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowData([NotNull] IntPtr window, [NotNull] string name)
        {
            return NativeSdl.InternalGetWindowData(window, name);
        }

        /// <summary>
        ///     Gets the window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowDisplayIndex([NotNull] IntPtr window)
        {
            return NativeSdl.InternalGetWindowDisplayIndex(window);
        }

        /// <summary>
        ///     Gets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowDisplayMode([NotNull] IntPtr window, out SdlDisplayMode mode)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalGetWindowDisplayMode(window, out mode);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Gets the window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowFlags([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            uint result = NativeSdl.InternalGetWindowFlags(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowFromId([NotNull] uint id)
        {
            Validator.ValidateInput(id);
            IntPtr result = NativeSdl.InternalGetWindowFromID(id);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowGammaRamp([NotNull] IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(red);
            Validator.ValidateInput(green);
            Validator.ValidateInput(blue);
            int result = NativeSdl.InternalGetWindowGammaRamp(window, red, green, blue);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetWindowGrab([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            SdlBool result = NativeSdl.InternalGetWindowGrab(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetWindowKeyboardGrab([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            SdlBool result = NativeSdl.InternalGetWindowKeyboardGrab(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetWindowMouseGrab([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            SdlBool result = NativeSdl.InternalGetWindowMouseGrab(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowId([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            uint result = NativeSdl.InternalGetWindowID(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetWindowPixelFormat([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            return NativeSdl.InternalGetWindowPixelFormat(window);
        }

        /// <summary>
        ///     Gets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowMaximumSize([NotNull] IntPtr window, out int maxW, out int maxH)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowMaximumSize(window, out maxW, out maxH);
        }

        /// <summary>
        ///     Gets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowMinimumSize([NotNull] IntPtr window, out int minW, out int minH)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowMinimumSize(window, out minW, out minH);
        }

        /// <summary>
        ///     Gets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowPosition([NotNull] IntPtr window, out int x, out int y)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowPosition(window, out x, out y);
        }


        /// <summary>
        ///     Gets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetWindowSize([NotNull] IntPtr window, out int w, out int h)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGetWindowSize(window, out w, out h);
        }

        /// <summary>
        ///     Gets the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowSurface([NotNull] IntPtr window)
        {
            return NativeSdl.InternalGetWindowSurface(window);
        }

        /// <summary>
        ///     Sdl the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetWindowTitle([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetWindowTitle(window));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gls the bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex</param>
        /// <param name="texH">The tex</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BindTexture([NotNull] IntPtr texture, out float texW, out float texH)
        {
            Validator.ValidateInput(texture);
            return NativeSdl.InternalGlBindTexture(texture, out texW, out texH);
        }

        /// <summary>
        ///     Gls the create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateContext([NotNull] IntPtr window)
        {
            return NativeSdl.InternalGlCreateContext(window);
        }

        /// <summary>
        ///     Gls the delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteContext([NotNull] IntPtr context)
        {
            NativeSdl.InternalGlDeleteContext(context);
        }
        
        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetProcAddress([NotNull] string proc)
        {
            return NativeSdl.InternalGlGetProcAddress(proc);
        }

        /// <summary>
        ///     Sdl the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool ExtensionSupported([NotNull] string extension)
        {
            return NativeSdl.InternalGlExtensionSupported(extension);
        }

        /// <summary>
        ///     Gls the reset attributes
        /// </summary>
        [return: NotNull]
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetAttribute([NotNull] SdlGlAttr attr, out int value)
        {
            return NativeSdl.InternalGlGetAttribute(attr, out value);
        }

        /// <summary>
        ///     Gls the get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSwapInterval()
        {
            return NativeSdl.InternalGlGetSwapInterval();
        }

        /// <summary>
        ///     Gls the make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MakeCurrent([NotNull] IntPtr window, [NotNull] IntPtr context)
        {
            return NativeSdl.InternalGlMakeCurrent(window, context);
        }


        /// <summary>
        ///     Gls the get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCurrentWindow()
        {
            return NativeSdl.InternalGlGetCurrentWindow();
        }

        /// <summary>
        ///     Gls the get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCurrentContext()
        {
            IntPtr result = NativeSdl.InternalGlGetCurrentContext();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gls the get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetDrawableSize([NotNull] IntPtr window, out int w, out int h)
        {
            NativeSdl.InternalGlGetDrawableSize(window, out w, out h);
        }

        /// <summary>
        ///     Gls the set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetAttributeByInt([NotNull] SdlGlAttr attr, [NotNull] int value)
        {
            return NativeSdl.InternalGlSetAttribute(attr, value);
        }

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetAttributeByProfile([NotNull] SdlGlAttr attr, [NotNull] SdlGlProfile profile)
        {
            Validator.ValidateInput(attr);
            Validator.ValidateInput(profile);
            int result = NativeSdl.InternalGlSetAttribute(attr, (int) profile);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gls the set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSwapInterval([NotNull] int interval)
        {
            Validator.ValidateInput(interval);
            int result = NativeSdl.InternalGlSetSwapInterval(interval);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gls the swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SwapWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalGlSwapWindow(window);
        }

        /// <summary>
        ///     Gls the unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UnbindTexture([NotNull] IntPtr texture)
        {
            Validator.ValidateInput(texture);
            int result = NativeSdl.InternalGlUnbindTexture(texture);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Hides the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HideWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalHideWindow(window);
        }
        
        /// <summary>
        ///     Maximizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximizeWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalMaximizeWindow(window);
        }

        /// <summary>
        ///     Minimizes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinimizeWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalMinimizeWindow(window);
        }

        /// <summary>
        ///     Raises the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RaiseWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalRaiseWindow(window);
        }

        /// <summary>
        ///     Restores the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RestoreWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalRestoreWindow(window);
        }

        /// <summary>
        ///     Sets the window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowBrightness([NotNull] IntPtr window, float brightness)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(brightness);
            int result = NativeSdl.InternalSetWindowBrightness(window, brightness);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SetWindowData([NotNull] IntPtr window, [NotNull] string name, [NotNull] IntPtr userdata)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(name);
            Validator.ValidateInput(userdata);
            IntPtr result = NativeSdl.InternalSetWindowData(window, name, userdata);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowDisplayMode([NotNull] IntPtr window, ref SdlDisplayMode mode)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(mode);
            int result = NativeSdl.InternalSetWindowDisplayMode(window, ref mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowDisplayMode([NotNull] IntPtr window, [NotNull] IntPtr mode)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(mode);
            int result = NativeSdl.InternalSetWindowDisplayMode(window, mode);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowFullscreen([NotNull] IntPtr window, [NotNull] uint flags)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(flags);
            int result = NativeSdl.InternalSetWindowFullscreen(window, flags);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowGammaRamp([NotNull] IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(red);
            Validator.ValidateInput(green);
            Validator.ValidateInput(blue);
            int result = NativeSdl.InternalSetWindowGammaRamp(window, red, green, blue);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(grabbed);
            NativeSdl.InternalSetWindowGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowKeyboardGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(grabbed);
            NativeSdl.InternalSetWindowKeyboardGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMouseGrab([NotNull] IntPtr window, SdlBool grabbed)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(grabbed);
            NativeSdl.InternalSetWindowMouseGrab(window, grabbed);
        }

        /// <summary>
        ///     Sets the window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowIcon([NotNull] IntPtr window, [NotNull] IntPtr icon)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(icon);
            NativeSdl.InternalSetWindowIcon(window, icon);
        }

        /// <summary>
        ///     Sets the window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMaximumSize([NotNull] IntPtr window, [NotNull] int maxW, [NotNull] int maxH)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(maxW);
            Validator.ValidateInput(maxH);
            NativeSdl.InternalSetWindowMaximumSize(window, maxW, maxH);
        }

        /// <summary>
        ///     Sets the window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowMinimumSize([NotNull] IntPtr window, [NotNull] int minW, [NotNull] int minH)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(minW);
            Validator.ValidateInput(minH);
            NativeSdl.InternalSetWindowMinimumSize(window, minW, minH);
        }

        /// <summary>
        ///     Sets the window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowPosition([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(x);
            Validator.ValidateInput(y);
            NativeSdl.InternalSetWindowPosition(window, x, y);
        }

        /// <summary>
        ///     Sets the window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowSize([NotNull] IntPtr window, [NotNull] int w, [NotNull] int h)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(w);
            Validator.ValidateInput(h);
            NativeSdl.InternalSetWindowSize(window, w, h);
        }

        /// <summary>
        ///     Sets the window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowBordered([NotNull] IntPtr window, SdlBool bordered)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(bordered);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWindowBordersSize([NotNull] IntPtr window, out int top, out int left, out int bottom, out int right)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalGetWindowBordersSize(window, out top, out left, out bottom, out right);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowResizable([NotNull] IntPtr window, SdlBool resizable)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(resizable);
            NativeSdl.InternalSetWindowResizable(window, resizable);
        }

        /// <summary>
        ///     Sets the window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowAlwaysOnTop([NotNull] IntPtr window, SdlBool onTop)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(onTop);
            NativeSdl.InternalSetWindowAlwaysOnTop(window, onTop);
        }

        /// <summary>
        ///     Sdl the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWindowTitle([NotNull] IntPtr window, [NotNull] string title)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(title);
            NativeSdl.InternalSetWindowTitle(window, title);
        }

        /// <summary>
        ///     Shows the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShowWindow([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            NativeSdl.InternalShowWindow(window);
        }

        /// <summary>
        ///     Updates the window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateWindowSurface([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalUpdateWindowSurface(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Updates the window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateWindowSurfaceRects([NotNull] IntPtr window, [In] RectangleI[] rects, [NotNull] int numRects)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(rects);
            Validator.ValidateInput(numRects);
            int result = NativeSdl.InternalUpdateWindowSurfaceRects(window, rects, numRects);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sets the window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowHitTest([NotNull] IntPtr window, SdlHitTest callback, [NotNull] IntPtr callbackData)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(callbackData);
            Validator.ValidateInput(callback);
            int result = NativeSdl.InternalSetWindowHitTest(window, callback, callbackData);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetGrabbedWindow()
        {
            IntPtr result = NativeSdl.InternalGetGrabbedWindow();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowMouseRect([NotNull] IntPtr window, ref RectangleI rect)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(rect);
            int result = NativeSdl.InternalSetWindowMouseRect(window, ref rect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetWindowMouseRect([NotNull] IntPtr window, [NotNull] IntPtr rect)
        {
            Validator.ValidateInput(window);
            Validator.ValidateInput(rect);
            int result = NativeSdl.InternalSetWindowMouseRect(window, rect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetWindowMouseRect([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            IntPtr result = NativeSdl.InternalGetWindowMouseRect(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Flashes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FlashWindow([NotNull] IntPtr window, SdlFlashOperation operation)
        {
            Validator.ValidateInput(window);
            int result = NativeSdl.InternalFlashWindow(window, operation);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBlendMode ComposeCustomBlendMode([NotNull] SdlBlendFactor srcColorFactor, [NotNull] SdlBlendFactor dstColorFactor, [NotNull] SdlBlendOperation colorOperation, [NotNull] SdlBlendFactor srcAlphaFactor, [NotNull] SdlBlendFactor dstAlphaFactor, [NotNull] SdlBlendOperation alphaOperation)
        {
            Validator.ValidateInput(srcColorFactor);
            Validator.ValidateInput(dstColorFactor);
            Validator.ValidateInput(colorOperation);
            Validator.ValidateInput(srcAlphaFactor);
            Validator.ValidateInput(dstAlphaFactor);
            Validator.ValidateInput(alphaOperation);
            SdlBlendMode result = NativeSdl.InternalComposeCustomBlendMode(srcColorFactor, dstColorFactor, colorOperation, srcAlphaFactor, dstAlphaFactor, alphaOperation);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Creates the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRenderer([NotNull] IntPtr window, [NotNull] int index, SdlRendererFlags flags)
        {
            return NativeSdl.InternalCreateRenderer(window, index, flags);
        }

        /// <summary>
        ///     Creates the software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateSoftwareRenderer([NotNull] IntPtr surface)
        {
            return NativeSdl.InternalCreateSoftwareRenderer(surface);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateTexture([NotNull] IntPtr renderer, [NotNull] uint format, [NotNull] int access, [NotNull] int w, [NotNull] int h)
        {
            return NativeSdl.InternalCreateTexture(renderer, format, access, w, h);
        }

        /// <summary>
        ///     Creates the texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateTextureFromSurface([NotNull] IntPtr renderer, [NotNull] IntPtr surface)
        {
            return NativeSdl.InternalCreateTextureFromSurface(renderer, surface);
        }

        /// <summary>
        ///     Destroys the renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyRenderer([NotNull] IntPtr renderer)
        {
            NativeSdl.InternalDestroyRenderer(renderer);
        }

        /// <summary>
        ///     Destroys the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyTexture([NotNull] IntPtr texture)
        {
            NativeSdl.InternalDestroyTexture(texture);
        }

        /// <summary>
        ///     Gets the num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumRenderDrivers()
        {
            return NativeSdl.InternalGetNumRenderDrivers();
        }

        /// <summary>
        ///     Gets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDrawBlendMode([NotNull] IntPtr renderer, out SdlBlendMode blendMode)
        {
            return NativeSdl.InternalGetRenderDrawBlendMode(renderer, out blendMode);
        }

        /// <summary>
        ///     Sets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureScaleMode([NotNull] IntPtr texture, SdlScaleMode scaleMode)
        {
            return NativeSdl.InternalSetTextureScaleMode(texture, scaleMode);
        }

        /// <summary>
        ///     Gets the texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureScaleMode([NotNull] IntPtr texture, out SdlScaleMode scaleMode)
        {
            return NativeSdl.InternalGetTextureScaleMode(texture, out scaleMode);
        }

        /// <summary>
        ///     Sets the texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureUserData([NotNull] IntPtr texture, [NotNull] IntPtr userdata)
        {
            return NativeSdl.InternalSetTextureUserData(texture, userdata);
        }

        /// <summary>
        ///     Internals the sdl get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetTextureUserData([NotNull] IntPtr texture)
        {
            return NativeSdl.InternalGetTextureUserData(texture);
        }

        /// <summary>
        ///     Gets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDrawColor([NotNull] IntPtr renderer, out byte r, out byte g, out byte b, out byte a)
        {
            return NativeSdl.InternalGetRenderDrawColor(renderer, out r, out g, out b, out a);
        }

        /// <summary>
        ///     Gets the render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRenderDriverInfo([NotNull] int index, out SdlRendererInfo info)
        {
            return NativeSdl.InternalGetRenderDriverInfo(index, out info);
        }

        /// <summary>
        ///     Gets the renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetRenderer([NotNull] IntPtr window)
        {
            return NativeSdl.InternalGetRenderer(window);
        }

        /// <summary>
        ///     Gets the renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRendererInfo([NotNull] IntPtr renderer, out SdlRendererInfo info)
        {
            return NativeSdl.InternalGetRendererInfo(renderer, out info);
        }

        /// <summary>
        ///     Gets the renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetRendererOutputSize([NotNull] IntPtr renderer, out int w, out int h)
        {
            return NativeSdl.InternalGetRendererOutputSize(renderer, out w, out h);
        }

        /// <summary>
        ///     Gets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureAlphaMod([NotNull] IntPtr texture, out byte alpha)
        {
            return NativeSdl.InternalGetTextureAlphaMod(texture, out alpha);
        }

        /// <summary>
        ///     Gets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureBlendMode([NotNull] IntPtr texture, out SdlBlendMode blendMode)
        {
            return NativeSdl.InternalGetTextureBlendMode(texture, out blendMode);
        }

        /// <summary>
        ///     Gets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTextureColorMod([NotNull] IntPtr texture, out byte r, out byte g, out byte b)
        {
            return NativeSdl.InternalGetTextureColorMod(texture, out r, out g, out b);
        }

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTexture([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch)
        {
            return NativeSdl.InternalLockTexture(texture, ref rect, out pixels, out pitch);
        }

        /// <summary>
        ///     Locks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr pixels, out int pitch)
        {
            return NativeSdl.InternalLockTexture(texture, rect, out pixels, out pitch);
        }

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTextureToSurface([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr surface)
        {
            return NativeSdl.InternalLockTextureToSurface(texture, ref rect, out surface);
        }

        /// <summary>
        ///     Locks the texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockTextureToSurface([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr surface)
        {
            return NativeSdl.InternalLockTextureToSurface(texture, rect, out surface);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int QueryTexture([NotNull] IntPtr texture, out uint format, out int access, out int w, out int h)
        {
            return NativeSdl.InternalQueryTexture(texture, out format, out access, out w, out h);
        }

        /// <summary>
        ///     Renders the clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderClear([NotNull] IntPtr renderer)
        {
            return NativeSdl.InternalRenderClear(renderer);
        }

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect)
        {
            return NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, ref dstRect);
        }

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect)
        {
            return NativeSdl.InternalRenderCopy(renderer, texture, srcRect, ref dstRect);
        }

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect)
        {
            return NativeSdl.InternalRenderCopy(renderer, texture, ref srcRect, dstRect);
        }

        /// <summary>
        ///     Renders the copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect)
        {
            return NativeSdl.InternalRenderCopy(renderer, texture, srcRect, dstRect);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, ref center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, ref center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, ref center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, ref center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, dstRect, angle, center, flip);
        }

        /// <summary>
        ///     Renders the draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLine([NotNull] IntPtr renderer, [NotNull] int x1, [NotNull] int y1, [NotNull] int x2, [NotNull] int y2)
        {
            return NativeSdl.InternalRenderDrawLine(renderer, x1, y1, x2, y2);
        }

        /// <summary>
        ///     Renders the draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLines([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count)
        {
            return NativeSdl.InternalRenderDrawLines(renderer, points, count);
        }

        /// <summary>
        ///     Renders the draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPoint([NotNull] IntPtr renderer, [NotNull] int x, [NotNull] int y)
        {
            return NativeSdl.InternalRenderDrawPoint(renderer, x, y);
        }

        /// <summary>
        ///     Renders the draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPoints([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count)
        {
            return NativeSdl.InternalRenderDrawPoints(renderer, points, count);
        }

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRect([NotNull] IntPtr renderer, ref RectangleI rect)
        {
            return NativeSdl.InternalRenderDrawRect(renderer, ref rect);
        }

        /// <summary>
        ///     Renders the draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect)
        {
            return NativeSdl.InternalRenderDrawRect(renderer, rect);
        }

        /// <summary>
        ///     Renders the draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count)
        {
            return NativeSdl.InternalRenderDrawRects(renderer, rects, count);
        }

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRect([NotNull] IntPtr renderer, ref RectangleI rect)
        {
            return NativeSdl.InternalRenderFillRect(renderer, ref rect);
        }

        /// <summary>
        ///     Renders the fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect)
        {
            return NativeSdl.InternalRenderFillRect(renderer, rect);
        }

        /// <summary>
        ///     Renders the fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count)
        {
            return NativeSdl.InternalRenderFillRects(renderer, rects, count);
        }

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst)
        {
            return NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, ref dst);
        }

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst)
        {
            return NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, ref dst);
        }

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect)
        {
            return NativeSdl.InternalRenderCopyF(renderer, texture, ref srcRect, dstRect);
        }

        /// <summary>
        ///     Renders the copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect)
        {
            return NativeSdl.InternalRenderCopyF(renderer, texture, srcRect, dstRect);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, ref srcRect, ref dst, angle, ref center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyEx(renderer, texture, srcRect, ref dst, angle, ref center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, ref center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, ref dst, angle, center, flip);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, ref center, flip);
        }


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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, ref dst, angle, center, flip);
        }


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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, center, flip);
        }


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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip)
        {
            return NativeSdl.InternalRenderCopyExF(renderer, texture, srcRect, dstRect, angle, center, flip);
        }


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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderGeometry([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [In] SdlVertex[] vertices, [NotNull] int numVertices, [In] [NotNull] int[] indices, [NotNull] int numIndices)
        {
            return NativeSdl.InternalRenderGeometry(renderer, texture, vertices, numVertices, indices, numIndices);
        }

        /// <summary>
        ///     Renders the draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPointF([NotNull] IntPtr renderer, float x, float y)
        {
            return NativeSdl.InternalRenderDrawPointF(renderer, x, y);
        }

        /// <summary>
        ///     Renders the draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawPointsF(IntPtr renderer, [In] PointF[] points, [NotNull] int count)
        {
            return NativeSdl.InternalRenderDrawPointsF(renderer, points, count);
        }

        /// <summary>
        ///     Renders the draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLineF([NotNull] IntPtr renderer, float x1, float y1, float x2, float y2)
        {
            return NativeSdl.InternalRenderDrawLineF(renderer, x1, y1, x2, y2);
        }


        /// <summary>
        ///     Renders the draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawLinesF([NotNull] IntPtr renderer, [In] PointF[] points, [NotNull] int count)
        {
            return NativeSdl.InternalRenderDrawLinesF(renderer, points, count);
        }


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectF([NotNull] IntPtr renderer, ref RectangleF rect)
        {
            return NativeSdl.InternalRenderDrawRectF(renderer, ref rect);
        }


        /// <summary>
        ///     Renders the draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect)
        {
            return NativeSdl.InternalRenderDrawRectF(renderer, rect);
        }


        /// <summary>
        ///     Renders the draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderDrawRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count)
        {
            return NativeSdl.InternalRenderDrawRectsF(renderer, rects, count);
        }


        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectF([NotNull] IntPtr renderer, RectangleF rect)
        {
            return NativeSdl.InternalRenderFillRectF(renderer, rect);
        }

        /// <summary>
        ///     Renders the fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect)
        {
            return NativeSdl.InternalRenderFillRectF(renderer, rect);
        }

        /// <summary>
        ///     Renders the fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFillRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count)
        {
            return NativeSdl.InternalRenderFillRectsF(renderer, rects, count);
        }


        /// <summary>
        ///     Renders the get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetClipRect([NotNull] IntPtr renderer, out RectangleI rect)
        {
            NativeSdl.InternalRenderGetClipRect(renderer, out rect);
        }


        /// <summary>
        ///     Renders the get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetLogicalSize([NotNull] IntPtr renderer, out int w, out int h)
        {
            NativeSdl.InternalRenderGetLogicalSize(renderer, out w, out h);
        }


        /// <summary>
        ///     Renders the get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderGetScale([NotNull] IntPtr renderer, out float scaleX, out float scaleY)
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderWindowToLogical([NotNull] IntPtr renderer, [NotNull] int windowX, [NotNull] int windowY, out float logicalX, out float logicalY)
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RenderLogicalToWindow([NotNull] IntPtr renderer, float logicalX, float logicalY, out int windowX, out int windowY)
        {
            NativeSdl.InternalRenderLogicalToWindow(renderer, logicalX, logicalY, out windowX, out windowY);
        }


        /// <summary>
        ///     Renders the get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderGetViewport([NotNull] IntPtr renderer, out RectangleI rect)
        {
            return NativeSdl.InternalRenderGetViewport(renderer, out rect);
        }

        /// <summary>
        ///     Renders the present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [return: NotNull]
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderReadPixels([NotNull] IntPtr renderer, ref RectangleI rect, [NotNull] uint format, [NotNull] IntPtr pixels, [NotNull] int pitch)
        {
            return NativeSdl.InternalRenderReadPixels(renderer, ref rect, format, pixels, pitch);
        }


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetClipRect([NotNull] IntPtr renderer, ref RectangleI rect)
        {
            return NativeSdl.InternalRenderSetClipRect(renderer, ref rect);
        }


        /// <summary>
        ///     Renders the set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetClipRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect)
        {
            return NativeSdl.InternalRenderSetClipRect(renderer, rect);
        }


        /// <summary>
        ///     Renders the set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetLogicalSize([NotNull] IntPtr renderer, [NotNull] int w, [NotNull] int h)
        {
            return NativeSdl.InternalRenderSetLogicalSize(renderer, w, h);
        }


        /// <summary>
        ///     Renders the set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetScale([NotNull] IntPtr renderer, float scaleX, float scaleY)
        {
            return NativeSdl.InternalRenderSetScale(renderer, scaleX, scaleY);
        }


        /// <summary>
        ///     Renders the set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetIntegerScale([NotNull] IntPtr renderer, SdlBool enable)
        {
            return NativeSdl.InternalRenderSetIntegerScale(renderer, enable);
        }

        /// <summary>
        ///     Renders the set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetViewport([NotNull] IntPtr renderer, ref RectangleI rect)
        {
            return NativeSdl.InternalRenderSetViewport(renderer, ref rect);
        }


        /// <summary>
        ///     Sets the render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawBlendMode([NotNull] IntPtr renderer, SdlBlendMode blendMode)
        {
            return NativeSdl.InternalSetRenderDrawBlendMode(renderer, blendMode);
        }

        /// <summary>
        ///     Sets the render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderDrawColor([NotNull] IntPtr renderer, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a)
        {
            return NativeSdl.InternalSetRenderDrawColor(renderer, r, g, b, a);
        }


        /// <summary>
        ///     Sets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRenderTarget([NotNull] IntPtr renderer, [NotNull] IntPtr texture)
        {
            return NativeSdl.InternalSetRenderTarget(renderer, texture);
        }

        /// <summary>
        ///     Sets the texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureAlphaMod([NotNull] IntPtr texture, [NotNull] byte alpha)
        {
            return NativeSdl.InternalSetTextureAlphaMod(texture, alpha);
        }


        /// <summary>
        ///     Sets the texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureBlendMode([NotNull] IntPtr texture, SdlBlendMode blendMode)
        {
            return NativeSdl.InternalSetTextureBlendMode(texture, blendMode);
        }


        /// <summary>
        ///     Sets the texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetTextureColorMod([NotNull] IntPtr texture, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b)
        {
            return NativeSdl.InternalSetTextureColorMod(texture, r, g, b);
        }


        /// <summary>
        ///     Unlocks the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockTexture([NotNull] IntPtr texture)
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr pixels, [NotNull] int pitch)
        {
            return NativeSdl.InternalUpdateTexture(texture, ref rect, pixels, pitch);
        }

        /// <summary>
        ///     Updates the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, [NotNull] IntPtr pixels, [NotNull] int pitch)
        {
            return NativeSdl.InternalUpdateTexture(texture, rect, pixels, pitch);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpdateNvTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr yPlane, [NotNull] int yPitch, [NotNull] IntPtr uvPlane, [NotNull] int uvPitch)
        {
            return NativeSdl.InternalUpdateNVTexture(texture, ref rect, yPlane, yPitch, uvPlane, uvPitch);
        }

        /// <summary>
        ///     Renders the target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RenderTargetSupported([NotNull] IntPtr renderer)
        {
            return NativeSdl.InternalRenderTargetSupported(renderer);
        }

        /// <summary>
        ///     Gets the render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetRenderTarget([NotNull] IntPtr renderer)
        {
            return NativeSdl.InternalGetRenderTarget(renderer);
        }

        /// <summary>
        ///     Renders the get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGetMetalLayer([NotNull] IntPtr renderer)
        {
            return NativeSdl.InternalRenderGetMetalLayer(renderer);
        }

        /// <summary>
        ///     Renders the get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGetMetalCommandEncoder([NotNull] IntPtr renderer)
        {
            return NativeSdl.InternalRenderGetMetalCommandEncoder(renderer);
        }

        /// <summary>
        ///     Renders the set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderSetVSync([NotNull] IntPtr renderer, [NotNull] int vsync)
        {
            return NativeSdl.InternalRenderSetVSync(renderer, vsync);
        }

        /// <summary>
        ///     Renders the is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RenderIsClipEnabled([NotNull] IntPtr renderer)
        {
            return NativeSdl.InternalRenderIsClipEnabled(renderer);
        }

        /// <summary>
        ///     Renders the flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderFlush([NotNull] IntPtr renderer)
        {
            return NativeSdl.InternalRenderFlush(renderer);
        }

        /// <summary>
        ///     Sdl the define pixel fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlDefinePixelFourcc([NotNull] byte a, [NotNull] byte b, [NotNull] byte c, [NotNull] byte d)
        {
            return Fourcc(a, b, c, d);
        }

        /// <summary>
        ///     Sdl the define pixel format using the specified type
        /// </summary>
        /// <param name="typePixel">The type</param>
        /// <param name="order">The order</param>
        /// <param name="layout">The layout</param>
        /// <param name="bits">The bits</param>
        /// <param name="bytes">The bytes</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlDefinePixelFormat(TypePixel typePixel, [NotNull] uint order, PackedLayout layout, [NotNull] byte bits, [NotNull] byte bytes)
        {
            return (uint) ((1 << 28) | ((byte) typePixel << 24) | ((byte) order << 20) | ((byte) layout << 16) | (bits << 8) | bytes);
        }

        /// <summary>
        ///     Sdl the pixel flag using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelFlag([NotNull] uint x)
        {
            return (byte) ((x >> 28) & 0x0F);
        }

        /// <summary>
        ///     Sdl the pixel type using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelType([NotNull] uint x)
        {
            return (byte) ((x >> 24) & 0x0F);
        }

        /// <summary>
        ///     Sdl the pixel order using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelOrder([NotNull] uint x)
        {
            return (byte) ((x >> 20) & 0x0F);
        }

        /// <summary>
        ///     Sdl the pixel layout using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlPixelLayout([NotNull] uint x)
        {
            return (byte) ((x >> 16) & 0x0F);
        }

        /// <summary>
        ///     Sdl the bits per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlBitsPerPixel([NotNull] uint x)
        {
            return (byte) ((x >> 8) & 0xFF);
        }

        /// <summary>
        ///     Sdl the bytes per pixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte SdlBytesPerPixel([NotNull] uint x)
        {
            if (SdlIsPixelFormatFour(x))
            {
                if (x == GlFormatYuy2 ||
                    x == GlFormatUy ||
                    x == GlFormatYv)
                {
                    return 2;
                }

                return 1;
            }

            return (byte) (x & 0xFF);
        }

        /// <summary>
        ///     Describes whether sdl is pixel format indexed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPixelFormatIndexed([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            TypePixel pTypePixel =
                (TypePixel) SdlPixelType(format);
            return pTypePixel == TypePixel.TypeIndex1 ||
                   pTypePixel == TypePixel.TypeIndex4 ||
                   pTypePixel == TypePixel.TypeIndex8;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format packed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatPacked([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            TypePixel pTypePixel =
                (TypePixel) SdlPixelType(format);
            return pTypePixel == TypePixel.TypePacked8 ||
                   pTypePixel == TypePixel.TypePacked16 ||
                   pTypePixel == TypePixel.TypePacked32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format array
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatArray([NotNull] uint format)
        {
            if (SdlIsPixelFormatFour(format))
            {
                return false;
            }

            TypePixel pTypePixel =
                (TypePixel) SdlPixelType(format);
            return pTypePixel == TypePixel.TypeArrayU8 ||
                   pTypePixel == TypePixel.TypeArrayU16 ||
                   pTypePixel == TypePixel.TypeArrayU32 ||
                   pTypePixel == TypePixel.TypeArrayF16 ||
                   pTypePixel == TypePixel.TypeArrayF32;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format alpha
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatAlpha([NotNull] uint format)
        {
            if (SdlIsPixelFormatPacked(format))
            {
                PackedOrder pOrder =
                    (PackedOrder) SdlPixelOrder(format);
                return pOrder == PackedOrder.PackedOrderARgb ||
                       pOrder == PackedOrder.PackedOrderRGba ||
                       pOrder == PackedOrder.PackedOrderABgr ||
                       pOrder == PackedOrder.PackedOrderBGra;
            }

            if (SdlIsPixelFormatArray(format))
            {
                SdlArrayOrder aOrder =
                    (SdlArrayOrder) SdlPixelOrder(format);
                return aOrder == SdlArrayOrder.SdlArrayOrderArgb ||
                       aOrder == SdlArrayOrder.SdlArrayOrderRgba ||
                       aOrder == SdlArrayOrder.SdlArrayOrderAbgR ||
                       aOrder == SdlArrayOrder.SdlArrayOrderBgrA;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether sdl is pixel format fourcc
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlIsPixelFormatFour([NotNull] uint format)
        {
            return (format == 0) && (SdlPixelFlag(format) != 1);
        }

        /// <summary>
        ///     Allow the format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr AllocFormat([NotNull] uint pixelFormat)
        {
            return NativeSdl.InternalAllocFormat(pixelFormat);
        }

        /// <summary>
        ///     Allow the palette using the specified n colors
        /// </summary>
        /// <param name="nColors">The colors</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr AllocPalette([NotNull] int nColors)
        {
            return NativeSdl.InternalAllocPalette(nColors);
        }

        /// <summary>
        ///     Calculates the gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [return: NotNull]
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetPixelFormatName([NotNull] uint format)
        {
            Validator.ValidateInput(format);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetPixelFormatName(format));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetRgb([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b)
        {
            NativeSdl.InternalGetRGB(pixel, format, out r, out g, out b);
        }


        /// <summary>
        ///     Gets the rgba using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetRgba([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b, out byte a)
        {
            NativeSdl.InternalGetRGBA(pixel, format, out r, out g, out b, out a);
        }

        /// <summary>
        ///     Maps the rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint MapRgb([NotNull] IntPtr format, byte r, [NotNull] byte g, [NotNull] byte b)
        {
            return NativeSdl.InternalMapRGB(format, r, g, b);
        }


        /// <summary>
        ///     Maps the rgba using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint MapRgba([NotNull] IntPtr format, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a)
        {
            return NativeSdl.InternalMapRGBA(format, r, g, b, a);
        }

        /// <summary>
        ///     Mask the to pixel format enum using the specified bpp
        /// </summary>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The mask</param>
        /// <param name="gMask">The mask</param>
        /// <param name="bMask">The mask</param>
        /// <param name="aMask">The mask</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint MasksToPixelFormatEnum([NotNull] int bpp, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask)
        {
            return NativeSdl.InternalMasksToPixelFormatEnum(bpp, rMask, gMask, bMask, aMask);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool FormatEnumToMasks([NotNull] uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask)
        {
            return NativeSdl.InternalPixelFormatEnumToMasks(format, out bpp, out rMask, out gMask, out bMask, out aMask);
        }


        /// <summary>
        ///     Sets the palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The colors</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetPaletteColors([NotNull] IntPtr palette, [In] SdlColor[] colors, [NotNull] int firstColor, [NotNull] int nColors)
        {
            return NativeSdl.InternalSetPaletteColors(palette, colors, firstColor, nColors);
        }


        /// <summary>
        ///     Sets the pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetPixelFormatPalette([NotNull] IntPtr format, [NotNull] IntPtr palette)
        {
            return NativeSdl.InternalSetPixelFormatPalette(format, palette);
        }


        /// <summary>
        ///     Sdl the point in rect using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool PointInRect(ref PointI p, ref RectangleI r)
        {
            return (p.x >= r.x) && (p.x < r.x + r.w) && (p.y >= r.y) && (p.y < r.y + r.h) ? SdlBool.True : SdlBool.False;
        }

        /// <summary>
        ///     Encloses the points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool EnclosePoints([In] PointI[] points, [NotNull] int count, ref RectangleI clip, out RectangleI result)
        {
            return NativeSdl.InternalEnclosePoints(points, count, ref clip, out result);
        }

        /// <summary>
        ///     Has the intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasIntersection(ref RectangleI a, ref RectangleI b)
        {
            return NativeSdl.InternalHasIntersection(ref a, ref b);
        }

        /// <summary>
        ///     Intersects the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IntersectRect(ref RectangleI a, ref RectangleI b, out RectangleI result)
        {
            return NativeSdl.InternalIntersectRect(ref a, ref b, out result);
        }

        /// <summary>
        ///     Intersects the rect and line using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IntersectRectAndLine(ref RectangleI rect, ref int x1, ref int y1, ref int x2, ref int y2)
        {
            return NativeSdl.InternalIntersectRectAndLine(ref rect, ref x1, ref y1, ref x2, ref y2);
        }

        /// <summary>
        ///     Sdl the rect empty using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RectEmpty(ref RectangleI r)
        {
            return r.w <= 0 || r.h <= 0 ? SdlBool.True : SdlBool.False;
        }

        /// <summary>
        ///     Sdl the rect equals using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool RectEquals(ref RectangleI a, ref RectangleI b)
        {
            return (a.x == b.x) && (a.y == b.y) && (a.w == b.w) && (a.h == b.h) ? SdlBool.True : SdlBool.False;
        }

        /// <summary>
        ///     Unions the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnionRect(RectangleI a, RectangleI b, out RectangleI result)
        {
            Validator.ValidateInput(a);
            Validator.ValidateInput(b);
            NativeSdl.InternalUnionRect(a, b, out result);
        }

        /// <summary>
        ///     Describes whether sdl must lock
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SdlMustLock([NotNull] IntPtr surface)
        {
            SdlSurface sur = Marshal.PtrToStructure<SdlSurface>(surface);
            return (sur.flags & RleAccel) != 0;
        }

        /// <summary>
        ///     Blit the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, ref dstRect);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, ref dstRect);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, ref srcRect, dst, dstRect);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(srcRect);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(dstRect);
            int result = NativeSdl.InternalBlitSurface(src, srcRect, dst, dstRect);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Converts the surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ConvertSurface([NotNull] IntPtr src, [NotNull] IntPtr fmt, [NotNull] uint flags)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(fmt);
            Validator.ValidateInput(flags);
            IntPtr result = NativeSdl.InternalConvertSurface(src, fmt, flags);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Converts the surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ConvertSurfaceFormat([NotNull] IntPtr src, [NotNull] uint pixelFormat, [NotNull] uint flags)
        {
            return NativeSdl.InternalConvertSurfaceFormat(src, pixelFormat, flags);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRgbSurfaceWithFormat([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint format)
        {
            return NativeSdl.InternalCreateRGBSurfaceWithFormat(flags, width, height, depth, format);
        }


        /// <summary>
        ///     Creates the rgb surface with format from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateRgbSurfaceWithFormatFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint format)
        {
            return NativeSdl.InternalCreateRGBSurfaceWithFormatFrom(pixels, width, height, depth, pitch, format);
        }


        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRect([NotNull] IntPtr dst, ref RectangleI rect, [NotNull] uint color)
        {
            return NativeSdl.InternalFillRect(dst, ref rect, color);
        }

        /// <summary>
        ///     Fills the rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRect([NotNull] IntPtr dst, [NotNull] IntPtr rect, [NotNull] uint color)
        {
            return NativeSdl.InternalFillRect(dst, rect, color);
        }

        /// <summary>
        ///     Fills the rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FillRects([NotNull] IntPtr dst, [In] RectangleI[] rects, [NotNull] int count, [NotNull] uint color)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(rects);
            Validator.ValidateInput(count);
            Validator.ValidateInput(color);
            int result = NativeSdl.InternalFillRects(dst, rects, count, color);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetClipRect([NotNull] IntPtr surface, out RectangleI rect)
        {
            Validator.ValidateInput(surface);
            NativeSdl.InternalGetClipRect(surface, out rect);
            Validator.ValidateOutput(rect);
        }

        /// <summary>
        ///     Has the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasColorKey([NotNull] IntPtr surface)
        {
            return NativeSdl.InternalHasColorKey(surface);
        }

        /// <summary>
        ///     Gets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetColorKey([NotNull] IntPtr surface, out uint key)
        {
            return NativeSdl.InternalGetColorKey(surface, out key);
        }

        /// <summary>
        ///     Gets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceAlphaMod([NotNull] IntPtr surface, out byte alpha)
        {
            return NativeSdl.InternalGetSurfaceAlphaMod(surface, out alpha);
        }

        /// <summary>
        ///     Gets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceBlendMode([NotNull] IntPtr surface, out SdlBlendMode blendMode)
        {
            return NativeSdl.InternalGetSurfaceBlendMode(surface, out blendMode);
        }

        /// <summary>
        ///     Gets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSurfaceColorMod([NotNull] IntPtr surface, out byte r, out byte g, out byte b)
        {
            return NativeSdl.InternalGetSurfaceColorMod(surface, out r, out g, out b);
        }

        /// <summary>
        ///     Sdl the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadBmp([NotNull] string file)
        {
            return NativeSdl.InternalLoadBMP_RW(RwFromFile(file, "rb"), 1);
        }

        /// <summary>
        ///     Locks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LockSurface([NotNull] IntPtr surface)
        {
            return NativeSdl.InternalLockSurface(surface);
        }

        /// <summary>
        ///     Lowers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LowerBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            return NativeSdl.InternalLowerBlit(src, ref srcRect, dst, ref dstRect);
        }

        /// <summary>
        ///     Lowers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LowerBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            return NativeSdl.InternalLowerBlitScaled(src, ref srcRect, dst, ref dstRect);
        }

        /// <summary>
        ///     Sdl the save bmp using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SaveBmp([NotNull] IntPtr surface, [NotNull] string file)
        {
            return NativeSdl.InternalSaveBMP_RW(surface, RwFromFile(file, "wb"), 1);
        }

        /// <summary>
        ///     Sets the clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool SetClipRect([NotNull] IntPtr surface, ref RectangleI rect)
        {
            return NativeSdl.InternalSetClipRect(surface, ref rect);
        }

        /// <summary>
        ///     Sets the color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetColorKey([NotNull] IntPtr surface, [NotNull] int flag, [NotNull] uint key)
        {
            return NativeSdl.InternalSetColorKey(surface, flag, key);
        }

        /// <summary>
        ///     Sets the surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceAlphaMod([NotNull] IntPtr surface, [NotNull] byte alpha)
        {
            return NativeSdl.InternalSetSurfaceAlphaMod(surface, alpha);
        }

        /// <summary>
        ///     Sets the surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceBlendMode([NotNull] IntPtr surface, SdlBlendMode blendMode)
        {
            return NativeSdl.InternalSetSurfaceBlendMode(surface, blendMode);
        }

        /// <summary>
        ///     Sets the surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceColorMod([NotNull] IntPtr surface, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b)
        {
            return NativeSdl.InternalSetSurfaceColorMod(surface, r, g, b);
        }

        /// <summary>
        ///     Sets the surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfacePalette([NotNull] IntPtr surface, [NotNull] IntPtr palette)
        {
            return NativeSdl.InternalSetSurfacePalette(surface, palette);
        }

        /// <summary>
        ///     Sets the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetSurfaceRle([NotNull] IntPtr surface, [NotNull] int flag)
        {
            return NativeSdl.InternalSetSurfaceRLE(surface, flag);
        }

        /// <summary>
        ///     Has the surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasSurfaceRle([NotNull] IntPtr surface)
        {
            return NativeSdl.InternalHasSurfaceRLE(surface);
        }

        /// <summary>
        ///     Soft the stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SoftStretch([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            return NativeSdl.InternalSoftStretch(src, ref srcRect, dst, ref dstRect);
        }

        /// <summary>
        ///     Soft the stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SoftStretchLinear([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            return NativeSdl.InternalSoftStretchLinear(src, ref srcRect, dst, ref dstRect);
        }

        /// <summary>
        ///     Unlocks the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnlockSurface([NotNull] IntPtr surface)
        {
            NativeSdl.InternalUnlockSurface(surface);
        }

        /// <summary>
        ///     Uppers the blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpperBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            return NativeSdl.InternalUpperBlit(src, ref srcRect, dst, ref dstRect);
        }

        /// <summary>
        ///     Uppers the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UpperBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect)
        {
            return NativeSdl.InternalUpperBlitScaled(src, ref srcRect, dst, ref dstRect);
        }

        /// <summary>
        ///     Duplicates the surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr DuplicateSurface([NotNull] IntPtr surface)
        {
            return NativeSdl.InternalDuplicateSurface(surface);
        }

        /// <summary>
        ///     Has the clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasClipboardText()
        {
            return NativeSdl.InternalHasClipboardText();
        }

        /// <summary>
        ///     Sdl the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetClipboardText()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetClipboardText());
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetClipboardText([NotNull] string text)
        {
            return NativeSdl.InternalSetClipboardText(text);
        }

        /// <summary>
        ///     Pumps the events
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PumpEvents()
        {
            NativeSdl.InternalPumpEvents();
        }

        /// <summary>
        ///     Peeps the events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PeepEvents([Out] SdlEvent[] events, [NotNull] int numEvents, SdlEventAction action, SdlEventType minType, SdlEventType maxType)
        {
            return NativeSdl.InternalPeepEvents(events, numEvents, action, minType, maxType);
        }


        /// <summary>
        ///     Has the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasEvent(SdlEventType type)
        {
            return NativeSdl.InternalHasEvent(type);
        }

        /// <summary>
        ///     Has the events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasEvents(SdlEventType minType, SdlEventType maxType)
        {
            return NativeSdl.InternalHasEvents(minType, maxType);
        }

        /// <summary>
        ///     Flushes the event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FlushEvent([NotNull] SdlEventType type)
        {
            NativeSdl.InternalFlushEvent(type);
        }

        /// <summary>
        ///     Flushes the events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FlushEvents(SdlEventType min, SdlEventType max)
        {
            NativeSdl.InternalFlushEvents(min, max);
        }

        /// <summary>
        ///     Polls the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PollEvent(out SdlEvent sdlEvent)
        {
            return NativeSdl.InternalPollEvent(out sdlEvent);
        }

        /// <summary>
        ///     Waits the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WaitEvent(out SdlEvent sdlEvent)
        {
            return NativeSdl.InternalWaitEvent(out sdlEvent);
        }

        /// <summary>
        ///     Waits the event timeout using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WaitEventTimeout(out SdlEvent sdlEvent, [NotNull] int timeout)
        {
            return NativeSdl.InternalWaitEventTimeout(out sdlEvent, timeout);
        }

        /// <summary>
        ///     Pushes the event using the specified sdl event
        /// </summary>
        /// <param name="sdlEvent">The sdl event</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int PushEvent(ref SdlEvent sdlEvent)
        {
            return NativeSdl.InternalPushEvent(ref sdlEvent);
        }

        /// <summary>
        ///     Sets the event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEventFilter(SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalSetEventFilter(filter, userdata);
        }

        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The ret val</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetEventFilter(out SdlEventFilter filter, out IntPtr userdata)
        {
            SdlBool val = NativeSdl.InternalGetEventFilter(out IntPtr result, out userdata);
            if (result != IntPtr.Zero)
            {
                filter = (SdlEventFilter) Marshal.GetDelegateForFunctionPointer(
                    result,
                    typeof(SdlEventFilter)
                );
            }
            else
            {
                filter = null;
            }

            return val;
        }

        /// <summary>
        ///     Adds the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalAddEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Del the event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DelEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalDelEventWatch(filter, userdata);
        }

        /// <summary>
        ///     Filters the events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FilterEvents([NotNull] SdlEventFilter filter, [NotNull] IntPtr userdata)
        {
            NativeSdl.InternalFilterEvents(filter, userdata);
        }

        /// <summary>
        ///     Sdl the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetEventState(SdlEventType type)
        {
            return NativeSdl.InternalEventState(type, Query);
        }

        /// <summary>
        ///     Registers the events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RegisterEvents([NotNull] int numEvents)
        {
            return NativeSdl.InternalRegisterEvents(numEvents);
        }

        /// <summary>
        ///     Sdl the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode ScanCodeToKeyCode(SdlScancode x)
        {
            return (SdlKeycode) ((int) x | KScancodeMask);
        }

        /// <summary>
        ///     Gets the keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetKeyboardFocus()
        {
            return NativeSdl.InternalGetKeyboardFocus();
        }

        /// <summary>
        ///     Gets the keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetKeyboardState(out int numKeys)
        {
            return NativeSdl.InternalGetKeyboardState(out numKeys);
        }

        /// <summary>
        ///     Gets the mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeyMod GetModState()
        {
            return NativeSdl.InternalGetModState();
        }

        /// <summary>
        ///     Sets the mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetModState(SdlKeyMod modState)
        {
            NativeSdl.InternalSetModState(modState);
        }

        /// <summary>
        ///     Gets the key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode GetKeyFromScancode(SdlScancode scancode)
        {
            return NativeSdl.InternalGetKeyFromScancode(scancode);
        }

        /// <summary>
        ///     Gets the scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlScancode GetScancodeFromKey(SdlKeycode key)
        {
            return NativeSdl.InternalGetScancodeFromKey(key);
        }

        /// <summary>
        ///     Sdl the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetScancodeName(SdlScancode scancode)
        {
            Validator.ValidateInput(scancode);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetScancodeName(scancode));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlScancode GetScancodeFromName([NotNull] string name)
        {
            return NativeSdl.InternalGetScancodeFromName(name);
        }

        /// <summary>
        ///     Sdl the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SGetKeyName(SdlKeycode key)
        {
           Validator.ValidateInput(key);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetKeyName(key));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlKeycode GetKeyFromName([NotNull] string name)
        {
            return NativeSdl.InternalGetKeyFromName(name);
        }

        /// <summary>
        ///     Starts the text input
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StartTextInput()
        {
            NativeSdl.InternalStartTextInput();
        }

        /// <summary>
        ///     Is the text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IsTextInputActive()
        {
            return NativeSdl.InternalIsTextInputActive();
        }

        /// <summary>
        ///     Stops the text input
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StopTextInput()
        {
            NativeSdl.InternalStopTextInput();
        }

        /// <summary>
        ///     Sets the text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTextInputRect(ref RectangleI rect)
        {
            Validator.ValidateInput(rect);
            NativeSdl.InternalSetTextInputRect(ref rect);
        }

        /// <summary>
        ///     Has the screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool HasScreenKeyboardSupport()
        {
            var result = NativeSdl.InternalHasScreenKeyboardSupport();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Is the screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IsScreenKeyboardShown([NotNull] IntPtr window)
        {
            Validator.ValidateInput(window);
            var result = NativeSdl.InternalIsScreenKeyboardShown(window);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetMouseFocus()
        {
            return NativeSdl.InternalGetMouseFocus();
        }

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateOutXAndY(out int x, out int y)
        {
            return NativeSdl.InternalGetMouseState(out x, out y);
        }

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateXAndYOut([NotNull] IntPtr x, out int y)
        {
            return NativeSdl.InternalGetMouseState(x, out y);
        }

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateXOutAndY(out int x, [NotNull] IntPtr y)
        {
            return NativeSdl.InternalGetMouseState(out x, y);
        }

        /// <summary>
        ///     Gets the mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetMouseStateToXAndY([NotNull] IntPtr x, [NotNull] IntPtr y)
        {
            return NativeSdl.InternalGetMouseState(x, y);
        }

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateOutXAndOutY(out int x, out int y)
        {
            return NativeSdl.InternalGetGlobalMouseState(out x, out y);
        }

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateXAndYOut([NotNull] IntPtr x, out int y)
        {
            return NativeSdl.InternalGetGlobalMouseState(x, out y);
        }

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateOutXAndY(out int x, [NotNull] IntPtr y)
        {
            return NativeSdl.InternalGetGlobalMouseState(out x, y);
        }

        /// <summary>
        ///     Gets the global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetGlobalMouseStateXAndY([NotNull] IntPtr x, [NotNull] IntPtr y)
        {
            return NativeSdl.InternalGetGlobalMouseState(x, y);
        }

        /// <summary>
        ///     Gets the relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint GetRelativeMouseState(out int x, out int y)
        {
            return NativeSdl.InternalGetRelativeMouseState(out x, out y);
        }

        /// <summary>
        ///     Warps the mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WarpMouseInWindow([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y)
        {
            NativeSdl.InternalWarpMouseInWindow(window, x, y);
        }

        /// <summary>
        ///     Warps the mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WarpMouseGlobal([NotNull] int x, [NotNull] int y)
        {
            return NativeSdl.InternalWarpMouseGlobal(x, y);
        }

        /// <summary>
        ///     Sets the relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetRelativeMouseMode(SdlBool enabled)
        {
            return NativeSdl.InternalSetRelativeMouseMode(enabled);
        }

        /// <summary>
        ///     Captures the mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CaptureMouse([NotNull] SdlBool enabled)
        {
            return NativeSdl.InternalCaptureMouse(enabled);
        }

        /// <summary>
        ///     Gets the relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GetRelativeMouseMode()
        {
            return NativeSdl.InternalGetRelativeMouseMode();
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateCursor([NotNull] IntPtr data, [NotNull] IntPtr mask, [NotNull] int w, [NotNull] int h, [NotNull] int hotX, [NotNull] int hotY)
        {
            return NativeSdl.InternalCreateCursor(data, mask, w, h, hotX, hotY);
        }

        /// <summary>
        ///     Creates the color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateColorCursor([NotNull] IntPtr surface, [NotNull] int hotX, [NotNull] int hotY)
        {
            return NativeSdl.InternalCreateColorCursor(surface, hotX, hotY);
        }

        /// <summary>
        ///     Creates the system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr CreateSystemCursor(SdlSystemCursor id)
        {
            return NativeSdl.InternalCreateSystemCursor(id);
        }

        /// <summary>
        ///     Sets the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCursor([NotNull] IntPtr cursor)
        {
            NativeSdl.InternalSetCursor(cursor);
        }

        /// <summary>
        ///     Gets the cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCursor()
        {
            return NativeSdl.InternalGetCursor();
        }

        /// <summary>
        ///     Frees the cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FreeCursor([NotNull] IntPtr cursor)
        {
            NativeSdl.InternalFreeCursor(cursor);
        }

        /// <summary>
        ///     Shows the cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ShowCursor([NotNull] int toggle)
        {
            return NativeSdl.InternalShowCursor(toggle);
        }

        /// <summary>
        ///     Sdl the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Button([NotNull] uint x)
        {
            return (uint) (1 << ((int) x - 1));
        }

        /// <summary>
        ///     Gets the num touch devices
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumTouchDevices()
        {
            return NativeSdl.InternalGetNumTouchDevices();
        }

        /// <summary>
        ///     Gets the touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetTouchDevice([NotNull] int index)
        {
            return NativeSdl.InternalGetTouchDevice(index);
        }

        /// <summary>
        ///     Gets the num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumTouchFingers(long touchId)
        {
            return NativeSdl.InternalGetNumTouchFingers(touchId);
        }

        /// <summary>
        ///     Gets the touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetTouchFinger([NotNull] long touchId, [NotNull] int index)
        {
            return NativeSdl.InternalGetTouchFinger(touchId, index);
        }

        /// <summary>
        ///     Gets the touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlTouchDeviceType GetTouchDeviceType([NotNull] long touchId)
        {
            return NativeSdl.InternalGetTouchDeviceType(touchId);
        }


        /// <summary>
        ///     Joysticks the rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickRumble([NotNull] IntPtr joystick, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs)
        {
            return NativeSdl.InternalJoystickRumble(joystick, lowFrequencyRumble, highFrequencyRumble, durationMs);
        }

        /// <summary>
        ///     Joysticks the rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickRumbleTriggers([NotNull] IntPtr joystick, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs)
        {
            return NativeSdl.InternalJoystickRumbleTriggers(joystick, leftRumble, rightRumble, durationMs);
        }

        /// <summary>
        ///     Joysticks the close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickClose([NotNull] IntPtr joystick)
        {
            NativeSdl.InternalJoystickClose(joystick);
        }

        /// <summary>
        ///     Joysticks the event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickEventState([NotNull] int state)
        {
            return NativeSdl.InternalJoystickEventState(state);
        }

        /// <summary>
        ///     Joysticks the get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short JoystickGetAxis([NotNull] IntPtr joystick, [NotNull] int axis)
        {
            return NativeSdl.InternalJoystickGetAxis(joystick, axis);
        }

        /// <summary>
        ///     Joysticks the get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickGetAxisInitialState([NotNull] IntPtr joystick, [NotNull] int axis, out ushort state)
        {
            return NativeSdl.InternalJoystickGetAxisInitialState(joystick, axis, out state);
        }

        /// <summary>
        ///     Joysticks the get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickGetBall([NotNull] IntPtr joystick, [NotNull] int ball, out int dx, out int dy)
        {
            return NativeSdl.InternalJoystickGetBall(joystick, ball, out dx, out dy);
        }

        /// <summary>
        ///     Joysticks the get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte JoystickGetButton([NotNull] IntPtr joystick, [NotNull] int button)
        {
            return NativeSdl.InternalJoystickGetButton(joystick, button);
        }

        /// <summary>
        ///     Joysticks the get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte JoystickGetHat([NotNull] IntPtr joystick, [NotNull] int hat)
        {
            return NativeSdl.InternalJoystickGetHat(joystick, hat);
        }

        /// <summary>
        ///     Sdl the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickName([NotNull] IntPtr joystick)
        {
            Validator.ValidateInput(joystick);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickName(joystick));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickNameForIndex([NotNull] int deviceIndex)
        {
           Validator.ValidateInput(deviceIndex);
           string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickNameForIndex(deviceIndex));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Joysticks the num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumAxes([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickNumAxes(joystick);
        }

        /// <summary>
        ///     Joysticks the num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumBalls([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickNumBalls(joystick);
        }

        /// <summary>
        ///     Joysticks the num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumButtons([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickNumButtons(joystick);
        }

        /// <summary>
        ///     Joysticks the num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickNumHats([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickNumHats(joystick);
        }

        /// <summary>
        ///     Joysticks the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickOpen([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickOpen(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the update
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickUpdate()
        {
            NativeSdl.InternalJoystickUpdate();
        }

        /// <summary>
        ///     Nums the joysticks
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumJoysticks()
        {
            int result = NativeSdl.InternalNumJoysticks();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Joysticks the get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetDeviceGuid([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickGetDeviceGUID(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetGuid(IntPtr joystick)
        {
            return NativeSdl.InternalJoystickGetGUID(joystick);
        }

        /// <summary>
        ///     Joysticks the get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickGetGuidString(Guid guid, [NotNull] byte[] pszGuid, [NotNull] int cbGuid)
        {
            NativeSdl.InternalJoystickGetGUIDString(guid, pszGuid, cbGuid);
        }

        /// <summary>
        ///     Sdl the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid JoystickGetGuidFromString([NotNull] string pchGuid)
        {
            return NativeSdl.InternalJoystickGetGUIDFromString(pchGuid);
        }

        /// <summary>
        ///     Joysticks the get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceVendor([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickGetDeviceVendor(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceProduct([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickGetDeviceProduct(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetDeviceProductVersion([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickGetDeviceProductVersion(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlJoystickType JoystickGetDeviceType([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickGetDeviceType(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickGetDeviceInstanceId([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickGetDeviceInstanceID(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetVendor([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickGetVendor(joystick);
        }

        /// <summary>
        ///     Joysticks the get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetProduct([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickGetProduct(joystick);
        }

        /// <summary>
        ///     Joysticks the get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort JoystickGetProductVersion([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickGetProductVersion(joystick);
        }

        /// <summary>
        ///     Sdl the joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string JoystickGetSerial([NotNull] IntPtr joystick)
        {
            Validator.ValidateInput(joystick);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalJoystickGetSerial(joystick));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Joysticks the get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlJoystickType JoystickGetType([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickGetType(joystick);
        }

        /// <summary>
        ///     Joysticks the get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickGetAttached([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickGetAttached(joystick);
        }

        /// <summary>
        ///     Joysticks the instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickInstanceId([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickInstanceID(joystick);
        }

        /// <summary>
        ///     Joysticks the current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlJoystickPowerLevel JoystickCurrentPowerLevel([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickCurrentPowerLevel(joystick);
        }

        /// <summary>
        ///     Joysticks the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickFromInstanceId([NotNull] int instanceId)
        {
            return NativeSdl.InternalJoystickFromInstanceID(instanceId);
        }

        /// <summary>
        ///     Locks the joysticks
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockJoysticks()
        {
            NativeSdl.InternalLockJoysticks();
        }

        /// <summary>
        ///     Unlocks the joysticks
        /// </summary>
        [return: NotNull]
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr JoystickFromPlayerIndex([NotNull] int playerIndex)
        {
            return NativeSdl.InternalJoystickFromPlayerIndex(playerIndex);
        }

        /// <summary>
        ///     Joysticks the set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void JoystickSetPlayerIndex([NotNull] IntPtr joystick, [NotNull] int playerIndex)
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlJoystickAttachVirtual([NotNull] int type, [NotNull] int nAxes, [NotNull] int nButtons, [NotNull] int nHats)
        {
            return NativeSdl.InternalJoystickAttachVirtual(type, nAxes, nButtons, nHats);
        }

        /// <summary>
        ///     Joysticks the detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickDetachVirtual([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickDetachVirtual(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickIsVirtual([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalJoystickIsVirtual(deviceIndex);
        }

        /// <summary>
        ///     Joysticks the set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualAxis([NotNull] IntPtr joystick, [NotNull] int axis, short value)
        {
            return NativeSdl.InternalJoystickSetVirtualAxis(joystick, axis, value);
        }

        /// <summary>
        ///     Joysticks the set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualButton([NotNull] IntPtr joystick, [NotNull] int button, [NotNull] byte value)
        {
            return NativeSdl.InternalJoystickSetVirtualButton(joystick, button, value);
        }

        /// <summary>
        ///     Joysticks the set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetVirtualHat([NotNull] IntPtr joystick, [NotNull] int hat, [NotNull] byte value)
        {
            return NativeSdl.InternalJoystickSetVirtualHat(joystick, hat, value);
        }

        /// <summary>
        ///     Joysticks the has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickHasLed([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickHasLED(joystick);
        }

        /// <summary>
        ///     Joysticks the has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickHasRumble([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickHasRumble(joystick);
        }

        /// <summary>
        ///     Joysticks the has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool JoystickHasRumbleTriggers([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickHasRumbleTriggers(joystick);
        }


        /// <summary>
        ///     Joysticks the set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSetLed([NotNull] IntPtr joystick, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue)
        {
            return NativeSdl.InternalJoystickSetLED(joystick, red, green, blue);
        }

        /// <summary>
        ///     Joysticks the send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickSendEffect([NotNull] IntPtr joystick, [NotNull] IntPtr data, [NotNull] int size)
        {
            return NativeSdl.InternalJoystickSendEffect(joystick, data, size);
        }

        /// <summary>
        ///     Sdl the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerAddMapping([NotNull] string mappingString)
        {
            return NativeSdl.InternalGameControllerAddMapping(mappingString);
        }

        /// <summary>
        ///     Games the controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerNumMappings()
        {
            return NativeSdl.InternalGameControllerNumMappings();
        }

        /// <summary>
        ///     Sdl the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForIndex([NotNull] int mappingIndex)
        {
            Validator.ValidateInput(mappingIndex);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForIndex(mappingIndex));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerAddMappingsFromFile([NotNull] string file)
        {
            return NativeSdl.InternalGameControllerAddMappingsFromRW(RwFromFile(file, "rb"), 1);
        }

        /// <summary>
        ///     Sdl the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForGuid(Guid guid)
        {
           Validator.ValidateInput(guid);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForGUID(guid));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMapping([NotNull] IntPtr gameController)
        {
            Validator.ValidateInput(gameController);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMapping(gameController));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Is the game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool IsGameController([NotNull] int joystickIndex)
        {
            return NativeSdl.InternalIsGameController(joystickIndex);
        }

        /// <summary>
        ///     Sdl the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerNameForIndex([NotNull] int joystickIndex)
        {
           Validator.ValidateInput(joystickIndex);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerNameForIndex(joystickIndex));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerMappingForDeviceIndex([NotNull] int joystickIndex)
        {
           Validator.ValidateInput(joystickIndex);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerMappingForDeviceIndex(joystickIndex));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Games the controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerOpen([NotNull] int joystickIndex)
        {
            return NativeSdl.InternalGameControllerOpen(joystickIndex);
        }

        /// <summary>
        ///     Sdl the game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerName([NotNull] IntPtr gameController)
        {
            Validator.ValidateInput(gameController);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerName(gameController));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Games the controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetVendor([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerGetVendor(gameController);
        }

        /// <summary>
        ///     Games the controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetProduct([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerGetProduct(gameController);
        }

        /// <summary>
        ///     Games the controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort GameControllerGetProductVersion([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerGetProductVersion(gameController);
        }


        /// <summary>
        ///     Sdl the game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetSerial([NotNull] IntPtr gameController)
        {
            Validator.ValidateInput(gameController);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetSerial(gameController));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Games the controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerGetAttached([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerGetAttached(gameController);
        }

        /// <summary>
        ///     Games the controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerGetJoystick([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerGetJoystick(gameController);
        }

        /// <summary>
        ///     Games the controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerEventState([NotNull] int state)
        {
            return NativeSdl.InternalGameControllerEventState(state);
        }

        /// <summary>
        ///     Games the controller update
        /// </summary>
        [return: NotNull]
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerAxis GameControllerGetAxisFromString([NotNull] string pchString)
        {
            return NativeSdl.InternalGameControllerGetAxisFromString(pchString);
        }

        /// <summary>
        ///     Sdl the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetStringForAxis(SdlGameControllerAxis axis)
        {
            Validator.ValidateInput(axis);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetStringForAxis(axis));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButtonBind GameControllerGetBindForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis)
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForAxis(
                gameController,
                axis
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind
            {
                bindType = (SdlGameControllerBindType) dumb.bindType
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short GameControllerGetAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis)
        {
            return NativeSdl.InternalGameControllerGetAxis(gameController, axis);
        }

        /// <summary>
        ///     Sdl the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButton GameControllerGetButtonFromString([NotNull] string pchString)
        {
            return NativeSdl.InternalGameControllerGetButtonFromString(pchString);
        }

        /// <summary>
        ///     Sdl the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GameControllerGetStringForButton(SdlGameControllerButton button)
        {
            Validator.ValidateInput(button);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGameControllerGetStringForButton(button));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerButtonBind GameControllerGetBindForButton(
            IntPtr gameController,
            SdlGameControllerButton button
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = NativeSdl.InternalGameControllerGetBindForButton(
                gameController,
                button
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind
            {
                bindType = (SdlGameControllerBindType) dumb.bindType
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GameControllerGetButton([NotNull] IntPtr gameController, SdlGameControllerButton button)
        {
            return NativeSdl.InternalGameControllerGetButton(gameController, button);
        }

        /// <summary>
        ///     Games the controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerRumble([NotNull] IntPtr gameController, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs)
        {
            return NativeSdl.InternalGameControllerRumble(gameController, lowFrequencyRumble, highFrequencyRumble, durationMs);
        }

        /// <summary>
        ///     Games the controller rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerRumbleTriggers([NotNull] IntPtr gameController, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs)
        {
            return NativeSdl.InternalGameControllerRumbleTriggers(gameController, leftRumble, rightRumble, durationMs);
        }

        /// <summary>
        ///     Games the controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerClose([NotNull] IntPtr gameController)
        {
            NativeSdl.InternalGameControllerClose(gameController);
        }
        
        /// <summary>
        ///     Internals the sdl game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerFromInstanceId([NotNull] int joyId)
        {
            return NativeSdl.InternalGameControllerFromInstanceID(joyId);
        }

        /// <summary>
        ///     Games the controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerType GameControllerTypeForIndex([NotNull] int joystickIndex)
        {
            return NativeSdl.InternalGameControllerTypeForIndex(joystickIndex);
        }

        /// <summary>
        ///     Games the controller get type using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl game controller type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlGameControllerType GameControllerGetType([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerGetType(gameController);
        }

        /// <summary>
        ///     Games the controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GameControllerFromPlayerIndex([NotNull] int playerIndex)
        {
            return NativeSdl.InternalGameControllerFromPlayerIndex(playerIndex);
        }


        /// <summary>
        ///     Games the controller set player index using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="playerIndex">The player index</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GameControllerSetPlayerIndex([NotNull] IntPtr gameController, [NotNull] int playerIndex)
        {
            NativeSdl.InternalGameControllerSetPlayerIndex(gameController, playerIndex);
        }


        /// <summary>
        ///     Games the controller has led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasLed([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerHasLED(gameController);
        }


        /// <summary>
        ///     Games the controller has rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasRumble([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerHasRumble(gameController);
        }

        /// <summary>
        ///     Games the controller has rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasRumbleTriggers([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerHasRumbleTriggers(gameController);
        }

        /// <summary>
        ///     Games the controller set led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSetLed([NotNull] IntPtr gameController, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue)
        {
            return NativeSdl.InternalGameControllerSetLED(gameController, red, green, blue);
        }


        /// <summary>
        ///     Games the controller has axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis)
        {
            return NativeSdl.InternalGameControllerHasAxis(gameController, axis);
        }

        /// <summary>
        ///     Games the controller has button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasButton([NotNull] IntPtr gameController, SdlGameControllerButton button)
        {
            return NativeSdl.InternalGameControllerHasButton(gameController, button);
        }

        /// <summary>
        ///     Games the controller get num touchpads using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetNumTouchpads([NotNull] IntPtr gameController)
        {
            return NativeSdl.InternalGameControllerGetNumTouchpads(gameController);
        }

        /// <summary>
        ///     Games the controller get num touchpad fingers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetNumTouchpadFingers([NotNull] IntPtr gameController, [NotNull] int touchpad)
        {
            return NativeSdl.InternalGameControllerGetNumTouchpadFingers(gameController, touchpad);
        }

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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetTouchpadFinger([NotNull] IntPtr gameController, [NotNull] int touchpad, [NotNull] int finger, out byte state, out float x, out float y, out float pressure)
        {
            return NativeSdl.InternalGameControllerGetTouchpadFinger(gameController, touchpad, finger, out state, out x, out y, out pressure);
        }

        /// <summary>
        ///     Games the controller has sensor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerHasSensor([NotNull] IntPtr gameController, SdlSensorType type)
        {
            return NativeSdl.InternalGameControllerHasSensor(gameController, type);
        }

        /// <summary>
        ///     Games the controller set sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSetSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type, SdlBool enabled)
        {
            return NativeSdl.InternalGameControllerSetSensorEnabled(gameController, type, enabled);
        }

        /// <summary>
        ///     Games the controller is sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlBool GameControllerIsSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type)
        {
            return NativeSdl.InternalGameControllerIsSensorEnabled(gameController, type);
        }


        /// <summary>
        ///     Games the controller get sensor data using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerGetSensorData([NotNull] IntPtr gameController, SdlSensorType type, [NotNull] IntPtr data, [NotNull] int numValues)
        {
            return NativeSdl.InternalGameControllerGetSensorData(gameController, type, data, numValues);
        }

        /// <summary>
        ///     Games the controller get sensor data rate using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GameControllerGetSensorDataRate([NotNull] IntPtr gameController, SdlSensorType type)
        {
            return NativeSdl.InternalGameControllerGetSensorDataRate(gameController, type);
        }


        /// <summary>
        ///     Games the controller send effect using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GameControllerSendEffect([NotNull] IntPtr gameController, [NotNull] IntPtr data, [NotNull] int size)
        {
            return NativeSdl.InternalGameControllerSendEffect(gameController, data, size);
        }


        /// <summary>
        /// Joysticks the is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int JoystickIsHaptic([NotNull] IntPtr joystick)
        {
            return NativeSdl.InternalJoystickIsHaptic(joystick);
        }

        /// <summary>
        ///     Mouses the is haptic
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MouseIsHaptic()
        {
            return NativeSdl.InternalMouseIsHaptic();
        }

        /// <summary>
        ///     Nums the haptics
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumHaptics()
        {
            int result = NativeSdl.InternalNumHaptics();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Nums the sensors
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumSensors()
        {
            return NativeSdl.InternalNumSensors();
        }

        /// <summary>
        ///     Sdl the sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SensorGetDeviceName([NotNull] int deviceIndex)
        {
            Validator.ValidateInput(deviceIndex);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalSensorGetDeviceName(deviceIndex));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sensors the get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlSensorType SensorGetDeviceType([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalSensorGetDeviceType(deviceIndex);
        }

        /// <summary>
        ///     Sensors the get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetDeviceNonPortableType([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalSensorGetDeviceNonPortableType(deviceIndex);
        }

        /// <summary>
        ///     Sensors the get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetDeviceInstanceId([NotNull] int deviceIndex)
        {
            return NativeSdl.InternalSensorGetDeviceInstanceID(deviceIndex);
        }

        /// <summary>
        ///     Sensors the open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SensorOpen([NotNull] int deviceIndex)
        {
            Validator.ValidateInput(deviceIndex);
            IntPtr result = NativeSdl.InternalSensorOpen(deviceIndex);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sensors the from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr SensorFromInstanceId([NotNull] int instanceId)
        {
            return NativeSdl.InternalSensorFromInstanceID(instanceId);
        }

        /// <summary>
        ///     Sdl the sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string SensorGetName([NotNull] IntPtr sensor)
        {
            Validator.ValidateInput(sensor);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalSensorGetName(sensor));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sensors the get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlSensorType SensorGetType([NotNull] IntPtr sensor)
        {
            return NativeSdl.InternalSensorGetType(sensor);
        }

        /// <summary>
        ///     Sensors the get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetNonPortableType([NotNull] IntPtr sensor)
        {
            return NativeSdl.InternalSensorGetNonPortableType(sensor);
        }

        /// <summary>
        ///     Sensors the get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetInstanceId([NotNull] IntPtr sensor)
        {
            return NativeSdl.InternalSensorGetInstanceID(sensor);
        }

        /// <summary>
        ///     Sensors the get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SensorGetData([NotNull] IntPtr sensor, float[] data, [NotNull] int numValues)
        {
            return NativeSdl.InternalSensorGetData(sensor, data, numValues);
        }

        /// <summary>
        ///     Sensors the close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SensorClose([NotNull] IntPtr sensor)
        {
            NativeSdl.InternalSensorClose(sensor);
        }

        /// <summary>
        ///     Sensors the update
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SensorUpdate()
        {
            NativeSdl.InternalSensorUpdate();
        }

        /// <summary>
        ///     Locks the sensors
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockSensors()
        {
            NativeSdl.InternalLockSensors();
        }

        /// <summary>
        ///     Unlocks the sensors
        /// </summary>
        [return: NotNull]
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
        public static ushort SdlAudioBitSize([NotNull] ushort x)
        {
            return (ushort) (x & AudioMaskBitSize);
        }

        /// <summary>
        ///     Describes whether sdl audio is float
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsFloat([NotNull] ushort x)
        {
            return (x & AudioMaskDatatype) != 0;
        }

        /// <summary>
        ///     Describes whether sdl audio is big endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsBigEndian([NotNull] ushort x)
        {
            return (x & AudioMaskEndian) != 0;
        }

        /// <summary>
        ///     Describes whether sdl audio is signed
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsSigned([NotNull] ushort x)
        {
            return (x & AudioMaskSigned) != 0;
        }

        /// <summary>
        ///     Describes whether sdl audio is int
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsInt([NotNull] ushort x)
        {
            return (x & AudioMaskDatatype) == 0;
        }

        /// <summary>
        ///     Describes whether sdl audio is little endian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsLittleEndian([NotNull] ushort x)
        {
            return (x & AudioMaskEndian) == 0;
        }

        /// <summary>
        ///     Describes whether sdl audio is unsigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SdlAudioIsUnsigned([NotNull] ushort x)
        {
            return (x & AudioMaskSigned) == 0;
        }

        /// <summary>
        ///     Sdl the audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static int AudioInit([NotNull] string driverName)
        {
            Validator.ValidateInput(driverName);
            var result = NativeSdl.InternalAudioInit(driverName);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Audio the quit
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AudioQuit()
        {
            NativeSdl.InternalAudioQuit();
        }
        
        /// <summary>
        ///     Closes the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CloseAudioDevice([NotNull] uint dev)
        {
            NativeSdl.InternalCloseAudioDevice(dev);
        }
        
        /// <summary>
        ///     Sdl the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The string</returns>
        public static string GetAudioDeviceName([NotNull] int index, [NotNull] int isCapture)
        {
            Validator.ValidateInput(index);
            Validator.ValidateInput(isCapture);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDeviceName(index, isCapture));
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlAudioStatus GetAudioDeviceStatus([NotNull] uint dev)
        {
            return NativeSdl.InternalGetAudioDeviceStatus(dev);
        }

        /// <summary>
        ///     Sdl the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string GetAudioDriver([NotNull] int index)
        {
            Validator.ValidateInput(index);
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetAudioDriver(index));
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Sdl the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetCurrentAudioDriver()
        {
            string result = Marshal.PtrToStringAnsi(NativeSdl.InternalGetCurrentAudioDriver());
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Gets the num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumAudioDevices([NotNull] int isCapture)
        {
            return NativeSdl.InternalGetNumAudioDevices(isCapture);
        }

        /// <summary>
        ///     Gets the num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetNumAudioDrivers()
        {
            var result = NativeSdl.InternalGetNumAudioDrivers();
            Validator.ValidateOutput(result);
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
        public static IntPtr LoadWav([NotNull] string file, out SdlAudioSpec spec, out IntPtr audioBuf, out uint audioLen)
        {
            Validator.ValidateInput(file);
            var result = NativeSdl.InternalLoadWAV_RW(RwFromFile(file, "rb"), 0, out spec, out audioBuf, out audioLen);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Locks the audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LockAudioDevice([NotNull] uint dev)
        {
            Validator.ValidateInput(dev);
            NativeSdl.InternalLockAudioDevice(dev);
        }

        /// <summary>
        ///     Mixes the audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] src, [NotNull] uint len, [NotNull] int volume)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(src);
            Validator.ValidateInput(len);
            Validator.ValidateInput(volume);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudioFormat([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(src);
            Validator.ValidateInput(format);
            Validator.ValidateInput(len);
            Validator.ValidateInput(volume);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume)
        {
            Validator.ValidateInput(dst);
            Validator.ValidateInput(src);
            Validator.ValidateInput(format);
            Validator.ValidateInput(len);
            Validator.ValidateInput(volume);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint OpenAudioDevice([NotNull] IntPtr device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges)
        {
            Validator.ValidateInput(device);
            Validator.ValidateInput(isCapture);
            Validator.ValidateInput(desired);
            Validator.ValidateInput(allowedChanges);
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);
            Validator.ValidateOutput(result);
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SdlOpenAudioDevice(string device, int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, int allowedChanges)
        {
            Validator.ValidateInput(device);
            Validator.ValidateInput(isCapture);
            Validator.ValidateInput(desired);
            Validator.ValidateInput(allowedChanges);
            uint result = NativeSdl.InternalOpenAudioDevice(device, isCapture, ref desired, out obtained, allowedChanges);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlPauseAudio([NotNull] int pauseOn)
        {
            Validator.ValidateInput(pauseOn);
            NativeSdl.InternalPauseAudio(pauseOn);
        }

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlPauseAudioDevice([NotNull] uint dev, [NotNull] int pauseOn)
        {
            Validator.ValidateInput(dev);
            Validator.ValidateInput(pauseOn);
            NativeSdl.InternalPauseAudioDevice(dev, pauseOn);
        }
        
        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlUnlockAudioDevice([NotNull] uint dev)
        {
            Validator.ValidateInput(dev);
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
        public static IntPtr SdlNewAudioStream([NotNull] ushort srcFormat, [NotNull] byte srcChannels, [NotNull] int srcRate, [NotNull] ushort dstFormat, [NotNull] byte dstChannels, [NotNull] int dstRate)
        {
            Validator.ValidateInput(srcFormat);
            Validator.ValidateInput(srcChannels);
            Validator.ValidateInput(srcRate);
            Validator.ValidateInput(dstFormat);
            Validator.ValidateInput(dstChannels);
            Validator.ValidateInput(dstRate);
            IntPtr result = NativeSdl.InternalNewAudioStream(srcFormat, srcChannels, srcRate, dstFormat, dstChannels, dstRate);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamPut([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len)
        {
            Validator.ValidateInput(stream);
            Validator.ValidateInput(buf);
            Validator.ValidateInput(len);
            int result = NativeSdl.InternalAudioStreamPut(stream, buf, len);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamGet([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len)
        {
            Validator.ValidateInput(stream);
            Validator.ValidateInput(buf);
            Validator.ValidateInput(len);
            int result = NativeSdl.InternalAudioStreamGet(stream, buf, len);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlAudioStreamAvailable([NotNull] IntPtr stream)
        {
            Validator.ValidateInput(stream);
            int result = NativeSdl.InternalAudioStreamAvailable(stream);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlAudioStreamClear([NotNull] IntPtr stream)
        {
            Validator.ValidateInput(stream);
            NativeSdl.InternalAudioStreamClear(stream);
        }

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SdlFreeAudioStream([NotEmpty] IntPtr stream)
        {
            Validator.ValidateInput(stream);
            NativeSdl.InternalFreeAudioStream(stream);
        }

        /// <summary>
        ///     Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SdlGetAudioDeviceSpec([NotNull] int index, [NotNull] int isCapture, out SdlAudioSpec spec)
        {
            Validator.ValidateInput(index);
            Validator.ValidateInput(isCapture);
            int result = NativeSdl.InternalGetAudioDeviceSpec(index, isCapture, out spec);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Internals the sdl get performance frequency
        /// </summary>
        /// <returns>The ulong</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetPerformanceFrequency()
        {
            ulong result = NativeSdl.InternalGetPerformanceFrequency();
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Gets the performance counter
        /// </summary>
        /// <returns>The ulong</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong GetPerformanceCounter()
        {
            ulong result = NativeSdl.InternalGetPerformanceCounter();
            Validator.ValidateOutput(result);
            return result;
        }
    }
}