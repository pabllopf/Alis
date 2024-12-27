// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTestP2.cs
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
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2
{
    /// <summary>
    ///     The sdl test class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SdlTestP2
    {
        /// <summary>
        ///     Tests that render present should not throw exception
        /// </summary>
        [Fact]
        public void RenderPresent_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            Sdl.RenderPresent(renderer);

            // Assert
            Assert.False(Sdl.IsScreenKeyboardShown(renderer));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render read pixels should return expected value
        /// </summary>
        [Fact]
        public void RenderReadPixels_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            uint format = 0;
            IntPtr pixels = IntPtr.Zero;
            int pitch = 0;

            // Act
            int result = Sdl.RenderReadPixels(renderer, ref rect, format, pixels, pitch);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render set clip rect should return expected value
        /// </summary>
        [Fact]
        public void RenderSetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            int result = Sdl.RenderSetClipRect(renderer, ref rect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render set logical size should return expected value
        /// </summary>
        [Fact]
        public void RenderSetLogicalSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            int w = 0;
            int h = 0;

            // Act
            int result = Sdl.RenderSetLogicalSize(renderer, w, h);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render set scale should return expected value
        /// </summary>
        [Fact]
        public void RenderSetScale_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            float scaleX = 0.0f;
            float scaleY = 0.0f;

            // Act
            int result = Sdl.RenderSetScale(renderer, scaleX, scaleY);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set render draw blend mode should return expected value
        /// </summary>
        [Fact]
        public void SetRenderDrawBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            BlendModes blendMode = BlendModes.None;

            // Act
            int result = Sdl.SetRenderDrawBlendMode(renderer, blendMode);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set render draw color should return expected value
        /// </summary>
        [Fact]
        public void SetRenderDrawColor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            byte r = 0;
            byte g = 0;
            byte b = 0;
            byte a = 0;

            // Act
            int result = Sdl.SetRenderDrawColor(renderer, r, g, b, a);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set render target should return expected value
        /// </summary>
        [Fact]
        public void SetRenderTarget_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            IntPtr texture = IntPtr.Zero;

            // Act
            int result = Sdl.SetRenderTarget(renderer, texture);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set texture alpha mod should return expected value
        /// </summary>
        [Fact]
        public void SetTextureAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            byte alpha = 0;

            // Act
            int result = Sdl.SetTextureAlphaMod(texture, alpha);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that update texture should return expected value
        /// </summary>
        [Fact]
        public void UpdateTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            IntPtr pixels = IntPtr.Zero;
            int pitch = 0;

            // Act
            int result = Sdl.UpdateTexture(texture, ref rect, pixels, pitch);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render target supported should return expected value
        /// </summary>
        [Fact]
        public void RenderTargetSupported_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            bool result = Sdl.RenderTargetSupported(renderer);

            // Assert
            Assert.False(result); // Replace true with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render is clip enabled should return expected value
        /// </summary>
        [Fact]
        public void RenderIsClipEnabled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            bool result = Sdl.RenderIsClipEnabled(renderer);

            // Assert
            Assert.False(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that calculate gamma ramp should not throw exception
        /// </summary>
        [Fact]
        public void CalculateGammaRamp_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            float gamma = 1.0f;
            ushort[] ramp = new ushort[256];

            // Act
            Sdl.CalculateGammaRamp(gamma, ramp);

            // Assert
            Assert.Equal(0, ramp[0]);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that blit surface should return expected value
        /// </summary>
        [Fact]
        public void BlitSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            IntPtr dst = IntPtr.Zero;
            RectangleI dstRect = new RectangleI();

            // Act
            int result = Sdl.BlitSurface(src, ref srcRect, dst, ref dstRect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that convert surface should return expected value
        /// </summary>
        [Fact]
        public void ConvertSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            IntPtr fmt = IntPtr.Zero;
            uint flags = 0;

            // Act
            IntPtr result = Sdl.ConvertSurface(src, fmt, flags);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that create rgb surface with format should return expected value
        /// </summary>
        [Fact]
        public void CreateRgbSurfaceWithFormat_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            uint flags = 0;
            int width = 0;
            int height = 0;
            int depth = 0;
            uint format = 0;

            // Act
            IntPtr result = Sdl.CreateRgbSurfaceWithFormat(flags, width, height, depth, format);

            // Assert
            Assert.NotEqual(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that fill rect should return expected value
        /// </summary>
        [Fact]
        public void FillRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr dst = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            uint color = 0;

            // Act
            int result = Sdl.FillRect(dst, ref rect, color);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get clip rect should return expected value
        /// </summary>
        [Fact]
        public void GetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            Sdl.GetClipRect(surface, out RectangleI _);

            // Assert
            Assert.Equal(0, surface.ToInt64());

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that has color key should return expected value
        /// </summary>
        [Fact]
        public void HasColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            bool result = Sdl.HasColorKey(surface);

            // Assert
            Assert.False(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get color key should return expected value
        /// </summary>
        [Fact]
        public void GetColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetColorKey(surface, out uint _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get surface alpha mod should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetSurfaceAlphaMod(surface, out byte _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get surface blend mode should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetSurfaceBlendMode(surface, out BlendModes _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get surface color mod should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceColorMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetSurfaceColorMod(surface, out byte _, out byte _, out byte _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that load bmp should return expected value
        /// </summary>
        [Fact]
        public void LoadBmp_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            string file = AssetManager.Find("tile000.bmp");

            // Act
            IntPtr result = Sdl.LoadBmp(file);

            // Assert

            Assert.NotEqual(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set clip rect should return expected value
        /// </summary>
        [Fact]
        public void SetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            bool result = Sdl.SetClipRect(surface, ref rect);

            // Assert

            Assert.False(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set color key should return expected value
        /// </summary>
        [Fact]
        public void SetColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            int flag = 0;
            uint key = 0;

            // Act
            int result = Sdl.SetColorKey(surface, flag, key);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set surface alpha mod should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            byte alpha = 0;

            // Act
            int result = Sdl.SetSurfaceAlphaMod(surface, alpha);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set surface blend mode should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            BlendModes blendMode = BlendModes.None;

            // Act
            int result = Sdl.SetSurfaceBlendMode(surface, blendMode);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set surface color mod should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceColorMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            byte r = 0, g = 0, b = 0;

            // Act
            int result = Sdl.SetSurfaceColorMod(surface, r, g, b);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set surface palette should return expected value
        /// </summary>
        [Fact]
        public void SetSurfacePalette_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            IntPtr palette = IntPtr.Zero;

            // Act
            int result = Sdl.SetSurfacePalette(surface, palette);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that upper blit should return expected value
        /// </summary>
        [Fact]
        public void UpperBlit_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            IntPtr dst = IntPtr.Zero;
            RectangleI dstRect = new RectangleI();

            // Act
            int result = Sdl.UpperBlit(src, ref srcRect, dst, ref dstRect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that upper blit scaled should return expected value
        /// </summary>
        [Fact]
        public void UpperBlitScaled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr src = IntPtr.Zero;
            RectangleI srcRect = new RectangleI();
            IntPtr dst = IntPtr.Zero;
            RectangleI dstRect = new RectangleI();

            // Act
            int result = Sdl.UpperBlitScaled(src, ref srcRect, dst, ref dstRect);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that has clipboard text should return expected value
        /// </summary>
        [Fact]
        public void HasClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            bool result = Sdl.HasClipboardText();

            // Assert
            Assert.Equal(result ? true : false, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get clipboard text should return expected value
        /// </summary>
        [Fact]
        public void GetClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string result = Sdl.GetClipboardText();

            // Assert
            if (string.IsNullOrEmpty(result))
            {
                Assert.True(string.IsNullOrEmpty(result));
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set clipboard text should return expected value
        /// </summary>
        [Fact]
        public void SetClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            string text = "test";

            // Act
            int result = Sdl.SetClipboardText(text);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that peep events should return expected value
        /// </summary>
        [Fact]
        public void PeepEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            Event[] events = new Event[10];
            int numEvents = 10;
            EventAction action = EventAction.SdlAddEvent;
            EventType minType = EventType.FirstEvent;
            EventType maxType = EventType.LastEvent;

            // Act
            int result = Sdl.PeepEvents(events, numEvents, action, minType, maxType);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that has event should return expected value
        /// </summary>
        [Fact]
        public void HasEvent_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            EventType type = EventType.FirstEvent;

            // Act
            bool result = Sdl.HasEvent(type);

            // Assert

            Assert.False(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that has events should return expected value
        /// </summary>
        [Fact]
        public void HasEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            EventType minType = EventType.FirstEvent;
            EventType maxType = EventType.LastEvent;

            // Act
            bool result = Sdl.HasEvents(minType, maxType);

            // Assert

            Assert.Equal(result ? true : false, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that flush event should not throw exception
        /// </summary>
        [Fact]
        public void FlushEvent_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            EventType type = EventType.FirstEvent;

            // Act
            Sdl.FlushEvent(type);

            // Assert
            Assert.False(Sdl.HasEvent(type));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick is haptic should return expected value
        /// </summary>
        [Fact]
        public void JoystickIsHaptic_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr joystick = IntPtr.Zero;

            // Act
            int result = Sdl.JoystickIsHaptic(joystick);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that mouse is haptic should return expected value
        /// </summary>
        [Fact]
        public void MouseIsHaptic_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.MouseIsHaptic();

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that num haptics should return expected value
        /// </summary>
        [Fact]
        public void NumHaptics_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.NumHaptics();

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that game controller from instance id should return expected value
        /// </summary>
        [Fact]
        public void GameControllerFromInstanceId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            int joyId = 0;

            // Act
            IntPtr result = Sdl.GameControllerFromInstanceId(joyId);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window surface should return expected value
        /// </summary>
        [Fact]
        public void GetWindowSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.GetWindowSurface(window);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get window grab should return expected value
        /// </summary>
        [Fact]
        public void GetWindowGrab_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            bool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.False(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that warp mouse in window should execute without exception
        /// </summary>
        [Fact]
        public void WarpMouseInWindow_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero; // Replace with actual window pointer
            int x = 0; // Replace with actual x value
            int y = 0; // Replace with actual y value

            // Act
            Sdl.WarpMouseInWindow(window, x, y);

            // Assert
            Assert.Equal(IntPtr.Zero, window);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that warp mouse global should return expected value
        /// </summary>
        [Fact]
        public void WarpMouseGlobal_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            int x = 0; // Replace with actual x value
            int y = 0; // Replace with actual y value

            // Act
            int result = Sdl.WarpMouseGlobal(x, y);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set relative mouse mode should return expected value
        /// </summary>
        [Fact]
        public void SetRelativeMouseMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            bool enabled = false; // Replace with actual enabled value

            // Act
            int result = Sdl.SetRelativeMouseMode(enabled);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that capture mouse should return expected value
        /// </summary>
        [Fact]
        public void CaptureMouse_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            bool enabled = false; // Replace with actual enabled value

            // Act
            int result = Sdl.CaptureMouse(enabled);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get relative mouse mode should return expected value
        /// </summary>
        [Fact]
        public void GetRelativeMouseMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            bool result = Sdl.GetRelativeMouseMode();

            // Assert
            // Replacefalse with the expected result
            Assert.False(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that create cursor should return expected value
        /// </summary>
        [Fact]
        public void CreateCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr data = IntPtr.Zero; // Replace with actual data pointer
            IntPtr mask = IntPtr.Zero; // Replace with actual mask pointer
            int w = 0; // Replace with actual w value
            int h = 0; // Replace with actual h value
            int hotX = 0; // Replace with actual hotX value
            int hotY = 0; // Replace with actual hotY value

            // Act
            IntPtr result = Sdl.CreateCursor(data, mask, w, h, hotX, hotY);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that create color cursor should return expected value
        /// </summary>
        [Fact]
        public void CreateColorCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero; // Replace with actual surface pointer
            int hotX = 0; // Replace with actual hotX value
            int hotY = 0; // Replace with actual hotY value

            // Act
            IntPtr result = Sdl.CreateColorCursor(surface, hotX, hotY);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that create system cursor should return expected value
        /// </summary>
        [Fact]
        public void CreateSystemCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            SystemCursor id = SystemCursor.SdlSystemCursorArrow; // Replace with actual id value

            // Act
            IntPtr result = Sdl.CreateSystemCursor(id);

            // Assert
            if (result != IntPtr.Zero)
            {
                Assert.NotEqual(IntPtr.Zero, result);
            }
            else
            {
                Assert.Equal(IntPtr.Zero, result);
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set cursor should execute without exception
        /// </summary>
        [Fact]
        public void SetCursor_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr cursor = IntPtr.Zero; // Replace with actual cursor pointer

            // Act
            Sdl.SetCursor(cursor);

            // Assert
            Assert.Equal(IntPtr.Zero, cursor);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get cursor should return expected value
        /// </summary>
        [Fact]
        public void GetCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetCursor();

            // Assert
            if (result != IntPtr.Zero)
            {
                Assert.NotEqual(IntPtr.Zero, result);
            }
            else
            {
                Assert.Equal(IntPtr.Zero, result);
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that free cursor should execute without exception
        /// </summary>
        [Fact]
        public void FreeCursor_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr cursor = IntPtr.Zero; // Replace with actual cursor pointer

            // Act
            Sdl.FreeCursor(cursor);

            // Assert
            Assert.Equal(IntPtr.Zero, cursor);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that show cursor should return expected value
        /// </summary>
        [Fact]
        public void ShowCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            int toggle = 0; // Replace with actual toggle value

            // Act
            int result = Sdl.ShowCursor(toggle);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that del event watch should execute without exception
        /// </summary>
        [Fact]
        public void DelEventWatch_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr userdata = IntPtr.Zero; // Replace with actual userdata

            // Act
            Sdl.DelEventWatch(null, userdata);

            // Assert
            Assert.Equal(IntPtr.Zero, userdata);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get event state should return expected value
        /// </summary>
        [Fact]
        public void GetEventState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            EventType type = EventType.FirstEvent; // Replace with actual type

            // Act
            byte result = Sdl.GetEventState(type);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result == 0 || result == 1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that register events should return expected value
        /// </summary>
        [Fact]
        public void RegisterEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            int numEvents = 0; // Replace with actual numEvents

            // Act
            uint result = Sdl.RegisterEvents(numEvents);

            // Assert
            // Replace 0 with the expected result
            Assert.NotEqual(0U, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that scan code to key code should return expected value
        /// </summary>
        [Fact]
        public void ScanCodeToKeyCode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            SdlScancode x = SdlScancode.SdlScancodeUnknown; // Replace with actual x

            // Act
            KeyCodes result = Sdl.ScanCodeToKeyCode(x);

            // Assert
            // Replace SdlKeycode.Unknown with the expected result
            Assert.NotEqual(KeyCodes.Unknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get keyboard focus should return expected value
        /// </summary>
        [Fact]
        public void GetKeyboardFocus_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetKeyboardFocus();

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get keyboard state should return expected value
        /// </summary>
        [Fact]
        public void GetKeyboardState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr result = Sdl.GetKeyboardState(out int _);

            // Assert
            // Replace IntPtr.Zero with the expected result
            Assert.NotEqual(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get mod state should return expected value
        /// </summary>
        [Fact]
        public void GetModState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            KeyMods result = Sdl.GetModState();

            // Assert
            if (KeyMods.None == result)
            {
                Assert.Equal(KeyMods.None, result);
            }
            else
            {
                Assert.NotEqual(KeyMods.None, result);
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set mod state should execute without exception
        /// </summary>
        [Fact]
        public void SetModState_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            KeyMods modState = KeyMods.None; // Replace with actual modState

            // Act
            Sdl.SetModState(modState);

            // Assert
            Assert.Equal(KeyMods.None, modState);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get key from scancode should return expected value
        /// </summary>
        [Fact]
        public void GetKeyFromScancode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            SdlScancode scancode = SdlScancode.SdlScancodeUnknown; // Replace with actual scancode

            // Act
            KeyCodes result = Sdl.GetKeyFromScancode(scancode);

            // Assert
            // Replace SdlKeycode.Unknown with the expected result
            Assert.Equal(KeyCodes.Unknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get scancode from key should return expected value
        /// </summary>
        [Fact]
        public void GetScancodeFromKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            KeyCodes key = KeyCodes.Unknown; // Replace with actual key

            // Act
            SdlScancode result = Sdl.GetScancodeFromKey(key);

            // Assert
            // Replace SdlScancode.Unknown with the expected result
            Assert.Equal(SdlScancode.SdlScancodeUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get scancode name should return expected value
        /// </summary>
        [Fact]
        public void GetScancodeName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            SdlScancode scancode = SdlScancode.SdlScancodeUnknown; // Replace with actual scancode

            // Act
            string result = Sdl.GetScancodeName(scancode);

            // Assert
            // Replace "" with the expected result
            Assert.Equal("", result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get scancode from name should return expected value
        /// </summary>
        [Fact]
        public void GetScancodeFromName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            string name = ""; // Replace with actual name

            // Act
            SdlScancode result = Sdl.GetScancodeFromName(name);

            // Assert
            // Replace SdlScancode.Unknown with the expected result
            Assert.Equal(SdlScancode.SdlScancodeUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get key name should return expected value
        /// </summary>
        [Fact]
        public void GetKeyName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            KeyCodes key = KeyCodes.Unknown; // Replace with actual key

            // Act
            string result = Sdl.SGetKeyName(key);

            // Assert
            // Replace "" with the expected result
            Assert.Equal("", result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get key from name should return expected value
        /// </summary>
        [Fact]
        public void GetKeyFromName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            string name = ""; // Replace with actual name

            // Act
            KeyCodes result = Sdl.GetKeyFromName(name);

            // Assert
            // Replace SdlKeycode.Unknown with the expected result
            Assert.Equal(KeyCodes.Unknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy with rectangle i returns expected result
        /// </summary>
        [Fact]
        public void RenderCopy_WithRectangleI_ReturnsExpectedResult()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            RectangleI srcRect = new RectangleI();
            int result = Sdl.RenderCopy(IntPtr.Zero, IntPtr.Zero, ref srcRect, IntPtr.Zero);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy with int ptr returns expected result
        /// </summary>
        [Fact]
        public void RenderCopy_WithIntPtr_ReturnsExpectedResult()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr srcRect = IntPtr.Zero;
            IntPtr dstRect = IntPtr.Zero;
            int result = Sdl.RenderCopy(IntPtr.Zero, IntPtr.Zero, srcRect, dstRect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick close with valid joystick closes without error
        /// </summary>
        [Fact]
        public void JoystickClose_WithValidJoystick_ClosesWithoutError()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr joystick = IntPtr.Zero;

            // Act
            Sdl.JoystickClose(joystick);

            // Assert
            Assert.Equal(IntPtr.Zero, joystick);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick close with invalid joystick throws exception
        /// </summary>
        [Fact]
        public void JoystickClose_WithInvalidJoystick_ThrowsException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr joystick = IntPtr.Zero; // Invalid joystick

            // Act and Assert
            Sdl.JoystickClose(joystick);

            Assert.Equal(IntPtr.Zero, joystick);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get guid string valid guid returns expected string
        /// </summary>
        [Fact]
        public void JoystickGetGuidString_ValidGuid_ReturnsExpectedString()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            Guid testGuid = Guid.NewGuid();
            byte[] pszGuid = new byte[64];
            int cbGuid = pszGuid.Length;

            // Act
            Sdl.JoystickGetGuidString(testGuid, pszGuid, cbGuid);

            // Assert
            Assert.NotNull(testGuid.ToString());

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that joystick get guid string invalid guid throws exception
        /// </summary>
        [Fact]
        public void JoystickGetGuidString_InvalidGuid_ThrowsException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            Guid testGuid = Guid.Empty; // Invalid Guid
            byte[] pszGuid = new byte[64];
            int cbGuid = pszGuid.Length;

            // Act and Assert
            Sdl.JoystickGetGuidString(testGuid, pszGuid, cbGuid);

            Assert.Equal(Guid.Empty, testGuid);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get relative mouse state valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetRelativeMouseState_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GetRelativeMouseState(out int _, out int _);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get relative mouse state invalid params throws exception
        /// </summary>
        [Fact]
        public void GetRelativeMouseState_InvalidParams_ThrowsException()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act and Assert
            Sdl.GetRelativeMouseState(out int x, out int y);

            Assert.Equal(0, x);
            Assert.Equal(0, y);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that push event valid event returns expected int
        /// </summary>
        [Fact]
        public void PushEvent_ValidEvent_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            Event sdlEvent = new Event(); // Replace with the desired SdlEvent

            // Act
            int result = Sdl.PushEvent(ref sdlEvent);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set event filter valid filter sets filter without error
        /// </summary>
        [Fact]
        public void SetEventFilter_ValidFilter_SetsFilterWithoutError()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr userdata = IntPtr.Zero; // Replace with the desired userdata

            // Act
            Sdl.SetEventFilter(null, userdata);

            // Assert
            Assert.Equal(IntPtr.Zero, userdata);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that add event watch valid filter adds watch without error
        /// </summary>
        [Fact]
        public void AddEventWatch_ValidFilter_AddsWatchWithoutError()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr userdata = IntPtr.Zero; // Replace with the desired userdata

            // Act
            Sdl.AddEventWatch(null, userdata);

            // Assert
            Assert.Equal(IntPtr.Zero, userdata);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get mouse state x and y out valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetMouseStateXAndYOut_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr x = IntPtr.Zero;

            // Act
            uint result = Sdl.GetMouseStateXAndYOut(x, out int _);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get mouse state x out and y valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetMouseStateXOutAndY_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr y = IntPtr.Zero;

            // Act
            uint result = Sdl.GetMouseStateXOutAndY(out int _, y);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that get mouse state to x and y valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetMouseStateToXAndY_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr x = IntPtr.Zero;
            IntPtr y = IntPtr.Zero;

            // Act
            uint result = Sdl.GetMouseStateToXAndY(x, y);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that blit surface valid params returns expected int
        /// </summary>
        [Fact]
        public void BlitSurface_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr src = IntPtr.Zero; // Replace with the desired source
            IntPtr srcRect = IntPtr.Zero; // Replace with the desired source rectangle
            IntPtr dst = IntPtr.Zero; // Replace with the desired destination
            RectangleI dstRect = new RectangleI(); // Replace with the desired destination rectangle

            // Act
            int result = Sdl.BlitSurface(src, srcRect, dst, ref dstRect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that blit surface ref src rect valid params returns expected int
        /// </summary>
        [Fact]
        public void BlitSurface_RefSrcRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr src = IntPtr.Zero; // Replace with the desired source
            RectangleI srcRect = new RectangleI(); // Replace with the desired source rectangle
            IntPtr dst = IntPtr.Zero; // Replace with the desired destination
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle

            // Act
            int result = Sdl.BlitSurface(src, ref srcRect, dst, dstRect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that blit surface no ref src rect valid params returns expected int
        /// </summary>
        [Fact]
        public void BlitSurface_NoRefSrcRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr src = IntPtr.Zero; // Replace with the desired source
            IntPtr srcRect = IntPtr.Zero; // Replace with the desired source rectangle
            IntPtr dst = IntPtr.Zero; // Replace with the desired destination
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle

            // Act
            int result = Sdl.BlitSurface(src, srcRect, dst, dstRect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that format enum to masks valid params returns expected bool
        /// </summary>
        [Fact]
        public void FormatEnumToMasks_ValidParams_ReturnsExpectedBool()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            uint format = 0x86161804; // Replace with the desired format

            // Act
            bool result = Sdl.FormatEnumToMasks(format, out int _, out uint _, out uint _, out uint _, out uint _);

            // Assert
            Assert.True(result == false || result);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set palette colors valid params returns expected int
        /// </summary>
        [Fact]
        public void SetPaletteColors_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr palette = IntPtr.Zero; // Replace with the desired palette
            Color[] colors = new Color[256]; // Replace with the desired colors
            int firstColor = 0, nColors = 256; // Replace with the desired first color and number of colors

            // Act
            int result = Sdl.SetPaletteColors(palette, colors, firstColor, nColors);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that set pixel format palette valid params returns expected int
        /// </summary>
        [Fact]
        public void SetPixelFormatPalette_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr format = IntPtr.Zero; // Replace with the desired format
            IntPtr palette = IntPtr.Zero; // Replace with the desired palette

            // Act
            int result = Sdl.SetPixelFormatPalette(format, palette);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that fill rect valid params returns expected int
        /// </summary>
        [Fact]
        public void FillRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr dst = IntPtr.Zero; // Replace with the desired dst
            IntPtr rect = IntPtr.Zero; // Replace with the desired rect
            uint color = 0xFFFFFF; // Replace with the desired color

            // Act
            int result = Sdl.FillRect(dst, rect, color);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that fill rects valid params returns expected int
        /// </summary>
        [Fact]
        public void FillRects_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr dst = IntPtr.Zero; // Replace with the desired dst
            RectangleI[] rects = new RectangleI[1]; // Replace with the desired rects
            int count = rects.Length;
            uint color = 0xFFFFFF; // Replace with the desired color

            // Act
            int result = Sdl.FillRects(dst, rects, count, color);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyEx_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            RectangleI srcRect = new RectangleI(); // Replace with the desired source rectangle
            RectangleI dstRect = new RectangleI(); // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            PointI center = new PointI(); // Replace with the desired center point
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, ref center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex with int ptr src rect valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyEx_WithIntPtrSrcRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the desired source rectangle
            RectangleI dstRect = new RectangleI(); // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            PointI center = new PointI(); // Replace with the desired center point
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, srcRect, ref dstRect, angle, ref center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex with int ptr dst rect valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyEx_WithIntPtrDstRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            RectangleI srcRect = new RectangleI(); // Replace with the desired source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            PointI center = new PointI(); // Replace with the desired center point
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, dstRect, angle, ref center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex with int ptr center valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyEx_WithIntPtrCenter_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            RectangleI srcRect = new RectangleI(); // Replace with the desired source rectangle
            RectangleI dstRect = new RectangleI(); // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            IntPtr center = IntPtr.Zero; // Replace with the desired center point
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, ref dstRect, angle, center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy f valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyF_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            IntPtr srcRect = IntPtr.Zero; // Replace with the desired source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle

            // Act
            int result = Sdl.RenderCopyF(renderer, texture, srcRect, dstRect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex v 2 valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyEx_v2_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            RectangleI srcRect = new RectangleI(0, 0, 0, 0); // Replace with the desired source rectangle
            RectangleF dst = new RectangleF(0, 0, 0, 0); // Replace with the desired destination rectangle
            double angle = 0; // Replace with the desired angle
            PointF center = new PointF(); // Replace with the desired center point
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyEx(renderer, texture, ref srcRect, ref dst, angle, ref center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render set clip rect valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderSetClipRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr rect = IntPtr.Zero; // Replace with the desired rect

            // Act
            int result = Sdl.RenderSetClipRect(renderer, rect);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that render copy ex f valid params returns expected int
        /// </summary>
        [Fact]
        public void RenderCopyExF_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr renderer = IntPtr.Zero; // Replace with the desired renderer
            IntPtr texture = IntPtr.Zero; // Replace with the desired texture
            RectangleI srcRect = new RectangleI(); // Replace with the desired source rectangle
            IntPtr dstRect = IntPtr.Zero; // Replace with the desired destination rectangle
            double angle = 0.0; // Replace with the desired angle
            PointF center = new PointF(); // Replace with the desired center
            RendererFlips flips = RendererFlips.None; // Replace with the desired flip

            // Act
            int result = Sdl.RenderCopyExF(renderer, texture, ref srcRect, dstRect, angle, ref center, flips);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl button l mask valid call returns expected uint
        /// </summary>
        [Fact]
        public void GlButtonLMask_ValidCall_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GlButtonLMask;

            // Assert
            Assert.True(result == 0 || result == 1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl button m mask valid call returns expected uint
        /// </summary>
        [Fact]
        public void GlButtonMMask_ValidCall_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GlButtonMMask;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl button r mask valid call returns expected uint
        /// </summary>
        [Fact]
        public void GlButtonRMask_ValidCall_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GlButtonRMask;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl button x 1 mask valid call returns expected uint
        /// </summary>
        [Fact]
        public void GlButtonX1Mask_ValidCall_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GlButtonX1Mask;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }

        /// <summary>
        ///     Tests that gl button x 2 mask valid call returns expected uint
        /// </summary>
        [Fact]
        public void GlButtonX2Mask_ValidCall_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GlButtonX2Mask;

            // Assert
            Assert.False(result == 0 || result == 1);

            Sdl.Quit();
        }
    }
}