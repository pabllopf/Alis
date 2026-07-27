// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTests.cs
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
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class SdlTests
    {
        [Fact]
        public void SetError_ThenGetError_ReturnsSetMessage()
        {
            Sdl.SetError("test error message");
            string error = Sdl.GetError();
            Assert.Contains("test error message", error);
        }

        [Fact]
        public void GetError_Initially_ReturnsEmptyString()
        {
            Sdl.SetError("");
            string error = Sdl.GetError();
            Assert.NotNull(error);
        }

        [Fact]
        public void ClearHints_DoesNotThrow()
        {
            Sdl.ClearHints();
        }

        [Fact]
        public void SetHint_GetHint_Roundtrip()
        {
            string hint = "TEST_HINT_SETGET";
            bool setResult = Sdl.SetHint(hint, "test_value");
            string value = Sdl.GetHint(hint);

            if (setResult)
            {
                Assert.Equal("test_value", value);
            }
        }

        [Fact]
        public void SetHintWithPriority_GetHint_Roundtrip()
        {
            string hint = "TEST_HINT_PRIORITY";
            bool setResult = Sdl.SetHintWithPriority(hint, "priority_val", HintPriority.SdlHintDefault);
            string value = Sdl.GetHint(hint);

            if (setResult)
            {
                Assert.Equal("priority_val", value);
            }
        }

        [Fact]
        public void GetHintBoolean_ReturnsDefaultForUnknownHint()
        {
            bool result = Sdl.GetHintBoolean("NONEXISTENT_HINT_XYZ", true);
            Assert.True(result);

            result = Sdl.GetHintBoolean("NONEXISTENT_HINT_XYZ", false);
            Assert.False(result);
        }

        [Fact]
        public void Init_And_Quit_Lifecycle()
        {
            uint wasInitBefore = Sdl.WasInit(InitSettings.InitTimer);
            Assert.Equal(0u, wasInitBefore);

            int initResult = Sdl.Init(InitSettings.InitTimer);
            Assert.Equal(0, initResult);

            uint wasInitAfter = Sdl.WasInit(InitSettings.InitTimer);
            Assert.NotEqual(0u, wasInitAfter);

            Sdl.Quit();

            uint wasInitAfterQuit = Sdl.WasInit(InitSettings.InitTimer);
            Assert.Equal(0u, wasInitAfterQuit);
        }

        [Fact]
        public void Init_WithMultipleFlags_Works()
        {
            int result = Sdl.Init(InitSettings.InitTimer | InitSettings.InitAudio | InitSettings.InitEvents);
            Assert.Equal(0, result);
            Sdl.Quit();
        }

        [Fact]
        public void WasInit_AfterPartialInit_ReturnsCorrectFlags()
        {
            Sdl.Init(InitSettings.InitTimer | InitSettings.InitAudio);

            uint timerWasInit = Sdl.WasInit(InitSettings.InitTimer);
            uint audioWasInit = Sdl.WasInit(InitSettings.InitAudio);
            uint videoWasInit = Sdl.WasInit(InitSettings.InitVideo);

            Assert.NotEqual(0u, timerWasInit);
            Assert.NotEqual(0u, audioWasInit);
            Assert.Equal(0u, videoWasInit);

            Sdl.Quit();
        }

        [Fact]
        public void GetNumAudioDrivers_AfterAudioInit_ReturnsPositive()
        {
            Sdl.Init(InitSettings.InitAudio);

            int numDrivers = Sdl.GetNumAudioDrivers();
            Assert.True(numDrivers > 0);

            Sdl.Quit();
        }

        [Fact]
        public void GetCurrentAudioDriver_AfterAudioInit_ReturnsNonNull()
        {
            Sdl.Init(InitSettings.InitAudio);

            string driver = Sdl.GetCurrentAudioDriver();
            Assert.NotNull(driver);
            Assert.NotEmpty(driver);

            Sdl.Quit();
        }

        [Fact]
        public void GetAudioDriver_ByIndex_ReturnsNonNull()
        {
            Sdl.Init(InitSettings.InitAudio);

            int numDrivers = Sdl.GetNumAudioDrivers();
            if (numDrivers > 0)
            {
                string name = Sdl.GetAudioDriver(0);
                Assert.NotNull(name);
                Assert.NotEmpty(name);
            }

            Sdl.Quit();
        }

        [Fact]
        public void GetNumAudioDevices_AfterAudioInit_ReturnsNonNegative()
        {
            Sdl.Init(InitSettings.InitAudio);

            int devices = Sdl.GetNumAudioDevices(0);
            Assert.True(devices >= 0);

            Sdl.Quit();
        }

        [Fact]
        public void GetAudioDeviceStatus_Zero_DoesNotThrow()
        {
            Sdl.Init(InitSettings.InitAudio);

            Sdl.GetAudioDeviceStatus(0);

            Sdl.Quit();
        }

        [Fact]
        public void GetPerformanceFrequency_ReturnsPositive()
        {
            Sdl.Init(InitSettings.InitTimer);

            ulong freq = Sdl.GetPerformanceFrequency();
            Assert.True(freq > 0);

            Sdl.Quit();
        }

        [Fact]
        public void GetPerformanceCounter_ReturnsPositive()
        {
            Sdl.Init(InitSettings.InitTimer);

            ulong counter = Sdl.GetPerformanceCounter();
            Assert.True(counter > 0);

            Sdl.Quit();
        }

        [Fact]
        public void GetPerformanceCounter_Increases()
        {
            Sdl.Init(InitSettings.InitTimer);

            ulong c1 = Sdl.GetPerformanceCounter();
            ulong c2 = Sdl.GetPerformanceCounter();
            Assert.True(c2 >= c1);

            Sdl.Quit();
        }

        [Fact]
        public void GetPixelFormatName_ReturnsNonNull()
        {
            string name = Sdl.GetPixelFormatName(Sdl.PixelFormatRgb888);
            Assert.NotNull(name);
            Assert.NotEmpty(name);
        }

        [Fact]
        public void GetPixelFormatName_ForUnknown_ReturnsNonNull()
        {
            string name = Sdl.GetPixelFormatName(0);
            Assert.NotNull(name);
        }

        [Fact]
        public void FormatEnumToMasks_ForRgb888_ReturnsValidMasks()
        {
            bool result = Sdl.FormatEnumToMasks(Sdl.PixelFormatRgb888, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask);

            Assert.True(result);
            Assert.Equal(32, bpp);
            Assert.NotEqual(0u, rMask);
            Assert.NotEqual(0u, gMask);
            Assert.NotEqual(0u, bMask);
            Assert.Equal(0u, aMask);
        }

        [Fact]
        public void FormatEnumToMasks_ForArgb8888_IncludesAlpha()
        {
            bool result = Sdl.FormatEnumToMasks(Sdl.PixelFormatArgb8888, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask);

            Assert.True(result);
            Assert.NotEqual(0u, aMask);
        }

        [Fact]
        public void CalculateGammaRamp_WithGammaOne_ProducesCorrectValues()
        {
            ushort[] ramp = new ushort[256];

            Sdl.CalculateGammaRamp(1.0f, ramp);

            Assert.Equal(0, ramp[0]);
            Assert.Equal(ushort.MaxValue, ramp[255]);
            Assert.True(ramp[64] < ramp[128]);
            Assert.True(ramp[128] < ramp[192]);
        }

        [Fact]
        public void CalculateGammaRamp_WithGammaTwo_ProducesCorrectShape()
        {
            ushort[] ramp = new ushort[256];

            Sdl.CalculateGammaRamp(2.0f, ramp);

            if (ramp[255] != 0)
            {
                Assert.Equal(0, ramp[0]);
                Assert.True(ramp[255] > 0);
            }
        }

        [Fact]
        public void ComposeCustomBlendMode_ReturnsValidMode()
        {
            BlendModes mode = Sdl.ComposeCustomBlendMode(BlendFactor.SdlBlendFactorZero, BlendFactor.SdlBlendFactorOne, BlendOperation.SdlBlendOperationAdd, BlendFactor.SdlBlendFactorZero, BlendFactor.SdlBlendFactorOne, BlendOperation.SdlBlendOperationAdd);
        }

        [Fact]
        public void GetKeyFromScancode_DoesNotThrow()
        {
            KeyCodes key = Sdl.GetKeyFromScancode(SdlScancode.SdlScancodeA);
        }

        [Fact]
        public void GetScancodeFromKey_DoesNotThrow()
        {
            SdlScancode scancode = Sdl.GetScancodeFromKey(KeyCodes.Unknown);
        }

        [Fact]
        public void GetScancodeName_DoesNotThrow()
        {
            string name = Sdl.GetScancodeName(SdlScancode.SdlScancodeA);
            Assert.NotNull(name);
        }

        [Fact]
        public void GetScancodeFromName_DoesNotThrow()
        {
            SdlScancode sc = Sdl.GetScancodeFromName("A");
        }

        [Fact]
        public void SGetKeyName_DoesNotThrow()
        {
            string name = Sdl.SGetKeyName(KeyCodes.Unknown);
            Assert.NotNull(name);
        }

        [Fact]
        public void GetKeyFromName_DoesNotThrow()
        {
            KeyCodes key = Sdl.GetKeyFromName("A");
        }

        [Fact]
        public void HasEvent_DoesNotThrow()
        {
            Sdl.Init(InitSettings.InitEvents);

            bool result = Sdl.HasEvent(EventType.FirstEvent);
            Assert.False(result);

            Sdl.Quit();
        }

        [Fact]
        public void HasEvents_DoesNotThrow()
        {
            Sdl.Init(InitSettings.InitEvents);

            bool result = Sdl.HasEvents(EventType.FirstEvent, EventType.LastEvent);
            Assert.False(result);

            Sdl.Quit();
        }

        [Fact]
        public void FlushEvent_DoesNotThrow()
        {
            Sdl.Init(InitSettings.InitEvents);

            Sdl.FlushEvent(EventType.FirstEvent);

            Sdl.Quit();
        }

        [Fact]
        public void GetEventState_DoesNotThrow()
        {
            Sdl.Init(InitSettings.InitEvents);

            byte state = Sdl.GetEventState(EventType.FirstEvent);

            Sdl.Quit();
        }

        [Fact]
        public void RegisterEvents_ReturnsNonZero()
        {
            Sdl.Init(InitSettings.InitEvents);

            uint eventType = Sdl.RegisterEvents(1);
            Assert.NotEqual(0u, eventType);

            Sdl.Quit();
        }

        [Fact]
        public void PushEvent_DoesNotThrow()
        {
            Sdl.Init(InitSettings.InitEvents);

            Event sdlEvent = new Event
            {
                type = EventType.Quit
            };
            Sdl.PushEvent(ref sdlEvent);

            Sdl.Quit();
        }

        [Fact]
        public void SdlAudioBitSize_AdditionalCases()
        {
            Assert.Equal((ushort)0x00, Sdl.SdlAudioBitSize(0x0000));
            Assert.Equal((ushort)0x10, Sdl.SdlAudioBitSize(0x0210));
            Assert.Equal((ushort)0xFF, Sdl.SdlAudioBitSize(0x01FF));
            Assert.Equal((ushort)0x08, Sdl.SdlAudioBitSize(0x0108));
        }

        [Fact]
        public void SdlAudioIsFloat_AdditionalCases()
        {
            Assert.True(Sdl.SdlAudioIsFloat(0x0100));
            Assert.False(Sdl.SdlAudioIsFloat(0x0000));
        }

        [Fact]
        public void SdlAudioIsBigEndian_AdditionalCases()
        {
            Assert.False(Sdl.SdlAudioIsBigEndian(0x0000));
            Assert.True(Sdl.SdlAudioIsBigEndian(0x1000));
        }

        [Fact]
        public void SdlAudioIsSigned_AdditionalCases()
        {
            Assert.True(Sdl.SdlAudioIsSigned(0x8000));
            Assert.False(Sdl.SdlAudioIsSigned(0x0000));
        }

        [Fact]
        public void SdlAudioIsInt_AdditionalCases()
        {
            Assert.True(Sdl.SdlAudioIsInt(0x0000));
            Assert.False(Sdl.SdlAudioIsInt(0x0100));
        }

        [Fact]
        public void SdlAudioIsLittleEndian_AdditionalCases()
        {
            Assert.True(Sdl.SdlAudioIsLittleEndian(0x0000));
            Assert.False(Sdl.SdlAudioIsLittleEndian(0x1000));
        }

        [Fact]
        public void SdlAudioIsUnsigned_AdditionalCases()
        {
            Assert.True(Sdl.SdlAudioIsUnsigned(0x0000));
            Assert.False(Sdl.SdlAudioIsUnsigned(0x8000));
        }

        [Fact]
        public void SdlDefinePixelFormat_Constants_AreNonZero()
        {
            Assert.NotEqual(0u, Sdl.PixelFormatIndex1Lsb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex1Msb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex4Lsb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex4Msb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex8);
        }

        [Fact]
        public void PixelFormat_Argb8888_And_Rgba8888_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatArgb8888, Sdl.PixelFormatRgba8888);
        }

        [Fact]
        public void PixelFormat_Argb8888_And_ABgr8888_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatArgb8888, Sdl.PixelFormatABgr8888);
        }

        [Fact]
        public void PixelFormat_Rgb24_And_Bgr24_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatRgb24, Sdl.PixelFormatBgr24);
        }

        [Fact]
        public void PixelFormat_Rgb565_And_Bgr565_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatRgb565, Sdl.PixelFormatBgr565);
        }

        [Fact]
        public void PixelFormat_Yv12_And_Iy_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatYv12, Sdl.PixelFormatIy);
        }

        [Fact]
        public void AudioConstants_AreDistinct()
        {
            Assert.NotEqual(Sdl.AudioU8, Sdl.AudioS8);
            Assert.NotEqual(Sdl.AudioU16Lsb, Sdl.AudioU16Msb);
            Assert.NotEqual(Sdl.AudioS16Lsb, Sdl.AudioS16Msb);
            Assert.NotEqual(Sdl.AudioS32Lsb, Sdl.AudioS32Msb);
            Assert.NotEqual(Sdl.AudioF32Lsb, Sdl.AudioF32Msb);
        }

        [Fact]
        public void PixelFormatRgb888_AliasMatchesGlFormat()
        {
            Assert.Equal(Sdl.GlFormatXRgb888, Sdl.PixelFormatRgb888);
        }

        [Fact]
        public void PixelFormatBgr888_AliasMatchesGlFormat()
        {
            Assert.Equal(Sdl.GlFormatXBgr888, Sdl.PixelFormatBgr888);
        }

        [Fact]
        public void PixelFormatRgb444_AliasMatchesGlFormat()
        {
            Assert.Equal(Sdl.GlFormatXRgb444, Sdl.PixelFormatRgb444);
        }

        [Fact]
        public void PixelFormatBgr444_AliasMatchesGlFormat()
        {
            Assert.Equal(Sdl.GlFormatXBgr444, Sdl.PixelFormatBgr444);
        }

        [Fact]
        public void PixelFormatRgb555_AliasMatchesGlFormat()
        {
            Assert.Equal(Sdl.GlFormatXRgb1555, Sdl.PixelFormatRgb555);
        }

        [Fact]
        public void PixelFormatBgr555_AliasMatchesGlFormat()
        {
            Assert.Equal(Sdl.GlFormatXBgr1555, Sdl.PixelFormatBgr555);
        }
    }
}
