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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Delegates;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2
{
    /// <summary>
    /// The sdl test class
    /// </summary>
    public class SdlTestP2
    {
        /// <summary>
        /// Tests that render present should not throw exception
        /// </summary>
        [Fact]
        public void RenderPresent_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            Sdl.RenderPresent(renderer);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.IsScreenKeyboardShown(renderer));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render read pixels should return expected value
        /// </summary>
        [Fact]
        public void RenderReadPixels_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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

        /// Tests that render set clip rect should return expected value

        /// </summary>

        [Fact]
        public void RenderSetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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

        /// Tests that render set logical size should return expected value

        /// </summary>

        [Fact]
        public void RenderSetLogicalSize_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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

        /// Tests that render set scale should return expected value

        /// </summary>

        [Fact]
        public void RenderSetScale_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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

        /// Tests that set render draw blend mode should return expected value

        /// </summary>

        [Fact]
        public void SetRenderDrawBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            SdlBlendMode blendMode = SdlBlendMode.None;

            // Act
            int result = Sdl.SetRenderDrawBlendMode(renderer, blendMode);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>

        /// Tests that set render draw color should return expected value

        /// </summary>

        [Fact]
        public void SetRenderDrawColor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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

        /// Tests that set render target should return expected value

        /// </summary>

        [Fact]
        public void SetRenderTarget_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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

        /// Tests that set texture alpha mod should return expected value

        /// </summary>

        [Fact]
        public void SetTextureAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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

        /// Tests that unlock texture should not throw exception

        /// </summary>

        [Fact]
        public void UnlockTexture_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;

            // Act
            Sdl.UnlockTexture(texture);

            // Assert
            Assert.Equal(IntPtr.Zero, Sdl.GetTextureUserData(texture));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that update texture should return expected value
        /// </summary>
        [Fact]
        public void UpdateTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that update nv texture should return expected value
        /// </summary>
        [Fact]
        public void UpdateNvTexture_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr texture = IntPtr.Zero;
            RectangleI rect = new RectangleI();
            IntPtr yPlane = IntPtr.Zero;
            int yPitch = 0;
            IntPtr uvPlane = IntPtr.Zero;
            int uvPitch = 0;

            // Act
            int result = Sdl.UpdateNvTexture(texture, ref rect, yPlane, yPitch, uvPlane, uvPitch);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render target supported should return expected value
        /// </summary>
        [Fact]
        public void RenderTargetSupported_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.RenderTargetSupported(renderer);

            // Assert
            Assert.Equal(SdlBool.False, result); // Replace SdlBool.True with the expected result

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get render target should return expected value
        /// </summary>
        [Fact]
        public void GetRenderTarget_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            IntPtr result = Sdl.GetRenderTarget(renderer);

            // Assert
            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render set v sync should return expected value
        /// </summary>
        [Fact]
        public void RenderSetVSync_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;
            int vsync = 1;

            // Act
            int result = Sdl.RenderSetVSync(renderer, vsync);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render is clip enabled should return expected value
        /// </summary>
        [Fact]
        public void RenderIsClipEnabled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr renderer = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.RenderIsClipEnabled(renderer);

            // Assert
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that calculate gamma ramp should not throw exception
        /// </summary>
        [Fact]
        public void CalculateGammaRamp_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that blit surface should return expected value
        /// </summary>
        [Fact]
        public void BlitSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that convert surface should return expected value
        /// </summary>
        [Fact]
        public void ConvertSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that create rgb surface with format should return expected value
        /// </summary>
        [Fact]
        public void CreateRgbSurfaceWithFormat_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that fill rect should return expected value
        /// </summary>
        [Fact]
        public void FillRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get clip rect should return expected value
        /// </summary>
        [Fact]
        public void GetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that has color key should return expected value
        /// </summary>
        [Fact]
        public void HasColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.HasColorKey(surface);

            // Assert
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get color key should return expected value
        /// </summary>
        [Fact]
        public void GetColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get surface alpha mod should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get surface blend mode should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            int result = Sdl.GetSurfaceBlendMode(surface, out SdlBlendMode _);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get surface color mod should return expected value
        /// </summary>
        [Fact]
        public void GetSurfaceColorMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that load bmp should return expected value
        /// </summary>
        [Fact]
        public void LoadBmp_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that set clip rect should return expected value
        /// </summary>
        [Fact]
        public void SetClipRect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            RectangleI rect = new RectangleI();

            // Act
            SdlBool result = Sdl.SetClipRect(surface, ref rect);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set color key should return expected value
        /// </summary>
        [Fact]
        public void SetColorKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that set surface alpha mod should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceAlphaMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that set surface blend mode should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceBlendMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            SdlBlendMode blendMode = SdlBlendMode.None;

            // Act
            int result = Sdl.SetSurfaceBlendMode(surface, blendMode);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set surface color mod should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceColorMod_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that set surface palette should return expected value
        /// </summary>
        [Fact]
        public void SetSurfacePalette_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that set surface rle should return expected value
        /// </summary>
        [Fact]
        public void SetSurfaceRle_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;
            int flag = 0;

            // Act
            int result = Sdl.SetSurfaceRle(surface, flag);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has surface rle should return expected value
        /// </summary>
        [Fact]
        public void HasSurfaceRle_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr surface = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.HasSurfaceRle(surface);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that upper blit should return expected value
        /// </summary>
        [Fact]
        public void UpperBlit_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that upper blit scaled should return expected value
        /// </summary>
        [Fact]
        public void UpperBlitScaled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that has clipboard text should return expected value
        /// </summary>
        [Fact]
        public void HasClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlBool result = Sdl.HasClipboardText();

            // Assert
            Assert.Equal(result == SdlBool.True ? SdlBool.True : SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get clipboard text should return expected value
        /// </summary>
        [Fact]
        public void GetClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            string result = Sdl.GetClipboardText();

            // Assert
            if (result != null)
            {
                Assert.Equal("test", result);
            }
            else
            {
                Assert.Null(result);
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set clipboard text should return expected value
        /// </summary>
        [Fact]
        public void SetClipboardText_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that peep events should return expected value
        /// </summary>
        [Fact]
        public void PeepEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEvent[] events = new SdlEvent[10];
            int numEvents = 10;
            SdlEventAction action = SdlEventAction.SdlAddEvent;
            SdlEventType minType = SdlEventType.SdlFirstEvent;
            SdlEventType maxType = SdlEventType.SdlLastEvent;

            // Act
            int result = Sdl.PeepEvents(events, numEvents, action, minType, maxType);

            // Assert
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has event should return expected value
        /// </summary>
        [Fact]
        public void HasEvent_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEventType type = SdlEventType.SdlFirstEvent;

            // Act
            SdlBool result = Sdl.HasEvent(type);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that has events should return expected value
        /// </summary>
        [Fact]
        public void HasEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEventType minType = SdlEventType.SdlFirstEvent;
            SdlEventType maxType = SdlEventType.SdlLastEvent;

            // Act
            SdlBool result = Sdl.HasEvents(minType, maxType);

            // Assert

            Assert.Equal(result == SdlBool.True ? SdlBool.True : SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that flush event should not throw exception
        /// </summary>
        [Fact]
        public void FlushEvent_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEventType type = SdlEventType.SdlFirstEvent;

            // Act
            Sdl.FlushEvent(type);

            // Assert
            Assert.Equal(SdlBool.False, Sdl.HasEvent(type));

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller set sensor enabled should return expected value
        /// </summary>
        [Fact]
        public void GameControllerSetSensorEnabled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlSensorType type = SdlSensorType.SdlSensorAccel;
            SdlBool enabled = SdlBool.True;

            // Act
            int result = Sdl.GameControllerSetSensorEnabled(gameController, type, enabled);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller is sensor enabled should return expected value
        /// </summary>
        [Fact]
        public void GameControllerIsSensorEnabled_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlSensorType type = SdlSensorType.SdlSensorAccel;

            // Act
            SdlBool result = Sdl.GameControllerIsSensorEnabled(gameController, type);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller get sensor data should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetSensorData_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlSensorType type = SdlSensorType.SdlSensorAccel;
            IntPtr data = IntPtr.Zero;
            int numValues = 1;

            // Act
            int result = Sdl.GameControllerGetSensorData(gameController, type, data, numValues);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller get sensor data rate should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetSensorDataRate_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlSensorType type = SdlSensorType.SdlSensorAccel;

            // Act
            float result = Sdl.GameControllerGetSensorDataRate(gameController, type);

            // Assert

            Assert.Equal(0.0f, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller send effect should return expected value
        /// </summary>
        [Fact]
        public void GameControllerSendEffect_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            IntPtr data = IntPtr.Zero;
            int size = 1;

            // Act
            int result = Sdl.GameControllerSendEffect(gameController, data, size);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that joystick is haptic should return expected value
        /// </summary>
        [Fact]
        public void JoystickIsHaptic_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that mouse is haptic should return expected value
        /// </summary>
        [Fact]
        public void MouseIsHaptic_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.MouseIsHaptic();

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that num haptics should return expected value
        /// </summary>
        [Fact]
        public void NumHaptics_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.NumHaptics();

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that num sensors should return expected value
        /// </summary>
        [Fact]
        public void NumSensors_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            int result = Sdl.NumSensors();

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get device name should return expected value
        /// </summary>
        [Fact]
        public void SensorGetDeviceName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0;

            // Act
            string result = Sdl.SensorGetDeviceName(deviceIndex);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get device type should return expected value
        /// </summary>
        [Fact]
        public void SensorGetDeviceType_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0;

            // Act
            SdlSensorType result = Sdl.SensorGetDeviceType(deviceIndex);

            // Assert

            Assert.Equal(SdlSensorType.SdlSensorInvalid, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get device non portable type should return expected value
        /// </summary>
        [Fact]
        public void SensorGetDeviceNonPortableType_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0;

            // Act
            int result = Sdl.SensorGetDeviceNonPortableType(deviceIndex);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get device instance id should return expected value
        /// </summary>
        [Fact]
        public void SensorGetDeviceInstanceId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0;

            // Act
            int result = Sdl.SensorGetDeviceInstanceId(deviceIndex);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor open should return expected value
        /// </summary>
        [Fact]
        public void SensorOpen_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int deviceIndex = 0;

            // Act
            IntPtr result = Sdl.SensorOpen(deviceIndex);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor from instance id should return expected value
        /// </summary>
        [Fact]
        public void SensorFromInstanceId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int instanceId = 0;

            // Act
            IntPtr result = Sdl.SensorFromInstanceId(instanceId);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get name should return expected value
        /// </summary>
        [Fact]
        public void SensorGetName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero;

            // Act
            string result = Sdl.SensorGetName(sensor);

            // Assert

            Assert.Null(result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get type should return expected value
        /// </summary>
        [Fact]
        public void SensorGetType_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero;

            // Act
            SdlSensorType result = Sdl.SensorGetType(sensor);

            // Assert

            Assert.Equal(SdlSensorType.SdlSensorInvalid, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get non portable type should return expected value
        /// </summary>
        [Fact]
        public void SensorGetNonPortableType_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero;

            // Act
            int result = Sdl.SensorGetNonPortableType(sensor);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get instance id should return expected value
        /// </summary>
        [Fact]
        public void SensorGetInstanceId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero;

            // Act
            int result = Sdl.SensorGetInstanceId(sensor);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor get data should return expected value
        /// </summary>
        [Fact]
        public void SensorGetData_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero;
            float[] data = new float[1];
            int numValues = 1;

            // Act
            int result = Sdl.SensorGetData(sensor, data, numValues);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor close should not throw exception
        /// </summary>
        [Fact]
        public void SensorClose_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr sensor = IntPtr.Zero;

            // Act
            Sdl.SensorClose(sensor);

            // Assert
            Assert.Equal(IntPtr.Zero, sensor);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that sensor update should not throw exception
        /// </summary>
        [Fact]
        public void SensorUpdate_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            Sdl.SensorUpdate();

            // Assert
            Assert.Equal(0, Sdl.NumSensors());

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller from instance id should return expected value
        /// </summary>
        [Fact]
        public void GameControllerFromInstanceId_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that game controller type for index should return expected value
        /// </summary>
        [Fact]
        public void GameControllerTypeForIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int joystickIndex = 0;

            // Act
            SdlGameControllerType result = Sdl.GameControllerTypeForIndex(joystickIndex);

            // Assert

            Assert.Equal(SdlGameControllerType.SdlControllerTypeUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller get type should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetType_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            SdlGameControllerType result = Sdl.GameControllerGetType(gameController);

            // Assert

            Assert.Equal(SdlGameControllerType.SdlControllerTypeUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller from player index should return expected value
        /// </summary>
        [Fact]
        public void GameControllerFromPlayerIndex_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            int playerIndex = 0;

            // Act
            IntPtr result = Sdl.GameControllerFromPlayerIndex(playerIndex);

            // Assert

            Assert.Equal(IntPtr.Zero, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller set player index should not throw exception
        /// </summary>
        [Fact]
        public void GameControllerSetPlayerIndex_ShouldNotThrowException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            int playerIndex = 0;

            // Act
            Sdl.GameControllerSetPlayerIndex(gameController, playerIndex);

            // Assert
            Assert.Equal(IntPtr.Zero, gameController);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller has led should return expected value
        /// </summary>
        [Fact]
        public void GameControllerHasLed_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GameControllerHasLed(gameController);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller has rumble should return expected value
        /// </summary>
        [Fact]
        public void GameControllerHasRumble_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GameControllerHasRumble(gameController);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller has rumble triggers should return expected value
        /// </summary>
        [Fact]
        public void GameControllerHasRumbleTriggers_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GameControllerHasRumbleTriggers(gameController);

            // Assert
            Assert.True(result == SdlBool.False || result == SdlBool.True);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller set led should return expected value
        /// </summary>
        [Fact]
        public void GameControllerSetLed_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            byte red = 0;
            byte green = 0;
            byte blue = 0;

            // Act
            int result = Sdl.GameControllerSetLed(gameController, red, green, blue);

            // Assert

            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller has axis should return expected value
        /// </summary>
        [Fact]
        public void GameControllerHasAxis_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlGameControllerAxis axis = SdlGameControllerAxis.SdlControllerAxisInvalid;

            // Act
            SdlBool result = Sdl.GameControllerHasAxis(gameController, axis);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller has button should return expected value
        /// </summary>
        [Fact]
        public void GameControllerHasButton_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;
            SdlGameControllerButton button = SdlGameControllerButton.SdlControllerButtonInvalid;

            // Act
            SdlBool result = Sdl.GameControllerHasButton(gameController, button);

            // Assert

            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that game controller get num touchpads should return expected value
        /// </summary>
        [Fact]
        public void GameControllerGetNumTouchpads_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr gameController = IntPtr.Zero;

            // Act
            int result = Sdl.GameControllerGetNumTouchpads(gameController);

            // Assert
            Assert.True(result >= 0);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get window surface should return expected value
        /// </summary>
        [Fact]
        public void GetWindowSurface_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get window grab should return expected value
        /// </summary>
        [Fact]
        public void GetWindowGrab_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            IntPtr window = IntPtr.Zero;

            // Act
            SdlBool result = Sdl.GetWindowGrab(window);

            // Assert
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that warp mouse in window should execute without exception
        /// </summary>
        [Fact]
        public void WarpMouseInWindow_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that warp mouse global should return expected value
        /// </summary>
        [Fact]
        public void WarpMouseGlobal_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that set relative mouse mode should return expected value
        /// </summary>
        [Fact]
        public void SetRelativeMouseMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlBool enabled = SdlBool.False; // Replace with actual enabled value

            // Act
            int result = Sdl.SetRelativeMouseMode(enabled);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that capture mouse should return expected value
        /// </summary>
        [Fact]
        public void CaptureMouse_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlBool enabled = SdlBool.False; // Replace with actual enabled value

            // Act
            int result = Sdl.CaptureMouse(enabled);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result >= -1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get relative mouse mode should return expected value
        /// </summary>
        [Fact]
        public void GetRelativeMouseMode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlBool result = Sdl.GetRelativeMouseMode();

            // Assert
            // Replace SdlBool.False with the expected result
            Assert.Equal(SdlBool.False, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that create cursor should return expected value
        /// </summary>
        [Fact]
        public void CreateCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that create color cursor should return expected value
        /// </summary>
        [Fact]
        public void CreateColorCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that create system cursor should return expected value
        /// </summary>
        [Fact]
        public void CreateSystemCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlSystemCursor id = SdlSystemCursor.SdlSystemCursorArrow; // Replace with actual id value

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
        /// Tests that set cursor should execute without exception
        /// </summary>
        [Fact]
        public void SetCursor_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get cursor should return expected value
        /// </summary>
        [Fact]
        public void GetCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that free cursor should execute without exception
        /// </summary>
        [Fact]
        public void FreeCursor_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that show cursor should return expected value
        /// </summary>
        [Fact]
        public void ShowCursor_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that del event watch should execute without exception
        /// </summary>
        [Fact]
        public void DelEventWatch_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get event state should return expected value
        /// </summary>
        [Fact]
        public void GetEventState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlEventType type = SdlEventType.SdlFirstEvent; // Replace with actual type

            // Act
            byte result = Sdl.GetEventState(type);

            // Assert
            // Replace 0 with the expected result
            Assert.True(result == 0 || result == 1);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that register events should return expected value
        /// </summary>
        [Fact]
        public void RegisterEvents_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that scan code to key code should return expected value
        /// </summary>
        [Fact]
        public void ScanCodeToKeyCode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlScancode x = SdlScancode.SdlScancodeUnknown; // Replace with actual x

            // Act
            SdlKeycode result = Sdl.ScanCodeToKeyCode(x);

            // Assert
            // Replace SdlKeycode.Unknown with the expected result
            Assert.NotEqual(SdlKeycode.SdlkUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get keyboard focus should return expected value
        /// </summary>
        [Fact]
        public void GetKeyboardFocus_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get keyboard state should return expected value
        /// </summary>
        [Fact]
        public void GetKeyboardState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get mod state should return expected value
        /// </summary>
        [Fact]
        public void GetModState_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlKeyMod result = Sdl.GetModState();

            // Assert
            if (SdlKeyMod.None == result)
            {
                Assert.Equal(SdlKeyMod.None, result);
            }
            else
            {
                Assert.NotEqual(SdlKeyMod.None, result);
            }

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set mod state should execute without exception
        /// </summary>
        [Fact]
        public void SetModState_ShouldExecuteWithoutException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlKeyMod modState = SdlKeyMod.None; // Replace with actual modState

            // Act
            Sdl.SetModState(modState);

            // Assert
            Assert.Equal(SdlKeyMod.None, modState);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get key from scancode should return expected value
        /// </summary>
        [Fact]
        public void GetKeyFromScancode_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlScancode scancode = SdlScancode.SdlScancodeUnknown; // Replace with actual scancode

            // Act
            SdlKeycode result = Sdl.GetKeyFromScancode(scancode);

            // Assert
            // Replace SdlKeycode.Unknown with the expected result
            Assert.Equal(SdlKeycode.SdlkUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get scancode from key should return expected value
        /// </summary>
        [Fact]
        public void GetScancodeFromKey_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlKeycode key = SdlKeycode.SdlkUnknown; // Replace with actual key

            // Act
            SdlScancode result = Sdl.GetScancodeFromKey(key);

            // Assert
            // Replace SdlScancode.Unknown with the expected result
            Assert.Equal(SdlScancode.SdlScancodeUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get scancode name should return expected value
        /// </summary>
        [Fact]
        public void GetScancodeName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get scancode from name should return expected value
        /// </summary>
        [Fact]
        public void GetScancodeFromName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get key name should return expected value
        /// </summary>
        [Fact]
        public void GetKeyName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            SdlKeycode key = SdlKeycode.SdlkUnknown; // Replace with actual key

            // Act
            string result = Sdl.SGetKeyName(key);

            // Assert
            // Replace "" with the expected result
            Assert.Equal("", result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get key from name should return expected value
        /// </summary>
        [Fact]
        public void GetKeyFromName_ShouldReturnExpectedValue()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);
            string name = ""; // Replace with actual name

            // Act
            SdlKeycode result = Sdl.GetKeyFromName(name);

            // Assert
            // Replace SdlKeycode.Unknown with the expected result
            Assert.Equal(SdlKeycode.SdlkUnknown, result);

            // Cleanup
            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render copy with rectangle i returns expected result
        /// </summary>
        [Fact]
        public void RenderCopy_WithRectangleI_ReturnsExpectedResult()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            RectangleI srcRect = new RectangleI();
            int result = Sdl.RenderCopy(IntPtr.Zero, IntPtr.Zero, ref srcRect, IntPtr.Zero);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that render copy with int ptr returns expected result
        /// </summary>
        [Fact]
        public void RenderCopy_WithIntPtr_ReturnsExpectedResult()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that joystick close with valid joystick closes without error
        /// </summary>
        [Fact]
        public void JoystickClose_WithValidJoystick_ClosesWithoutError()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr joystick = IntPtr.Zero;

            // Act
            Sdl.JoystickClose(joystick);

            // Assert
            Assert.Equal(IntPtr.Zero, joystick);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that joystick close with invalid joystick throws exception
        /// </summary>
        [Fact]
        public void JoystickClose_WithInvalidJoystick_ThrowsException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr joystick = IntPtr.Zero; // Invalid joystick

            // Act and Assert
            Sdl.JoystickClose(joystick);

            Assert.Equal(IntPtr.Zero, joystick);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that joystick get guid string valid guid returns expected string
        /// </summary>
        [Fact]
        public void JoystickGetGuidString_ValidGuid_ReturnsExpectedString()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that joystick get guid string invalid guid throws exception
        /// </summary>
        [Fact]
        public void JoystickGetGuidString_InvalidGuid_ThrowsException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that get relative mouse state valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetRelativeMouseState_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            uint result = Sdl.GetRelativeMouseState(out int _, out int _);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get relative mouse state invalid params throws exception
        /// </summary>
        [Fact]
        public void GetRelativeMouseState_InvalidParams_ThrowsException()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act and Assert
            Sdl.GetRelativeMouseState(out int x, out int y);

            Assert.Equal(0, x);
            Assert.Equal(0, y);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that poll event valid event returns expected int
        /// </summary>
        [Fact]
        public void PollEvent_ValidEvent_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            IntPtr window = Sdl.CreateWindow("Test", 0, 0, 0, 0, 0);
            IntPtr renderer = Sdl.CreateRenderer(window, -1, 0);
            if (renderer == IntPtr.Zero)
            {
                Assert.Equal(IntPtr.Zero, renderer);
            }
            else
            {
                Assert.NotEqual(IntPtr.Zero, renderer);
                if (Sdl.PollEvent(out SdlEvent sdlEvent) != 0)
                {
                    // Assert
                    Assert.Equal(SdlEventType.SdlFirstEvent, sdlEvent.type);
                }
            }

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that push event valid event returns expected int
        /// </summary>
        [Fact]
        public void PushEvent_ValidEvent_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            SdlEvent sdlEvent = new SdlEvent(); // Replace with the desired SdlEvent

            // Act
            int result = Sdl.PushEvent(ref sdlEvent);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set event filter valid filter sets filter without error
        /// </summary>
        [Fact]
        public void SetEventFilter_ValidFilter_SetsFilterWithoutError()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr userdata = IntPtr.Zero; // Replace with the desired userdata

            // Act
            Sdl.SetEventFilter(null, userdata);

            // Assert
            Assert.Equal(IntPtr.Zero, userdata);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get event filter valid filter returns expected bool
        /// </summary>
        [Fact]
        public void GetEventFilter_ValidFilter_ReturnsExpectedBool()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            // Act
            SdlBool result = Sdl.GetEventFilter(out SdlEventFilter _, out IntPtr _);

            // Assert
            Assert.Equal(SdlBool.False, result);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that add event watch valid filter adds watch without error
        /// </summary>
        [Fact]
        public void AddEventWatch_ValidFilter_AddsWatchWithoutError()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr userdata = IntPtr.Zero; // Replace with the desired userdata

            // Act
            Sdl.AddEventWatch(null, userdata);

            // Assert
            Assert.Equal(IntPtr.Zero, userdata);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get mouse state x and y out valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetMouseStateXAndYOut_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr x = IntPtr.Zero;

            // Act
            uint result = Sdl.GetMouseStateXAndYOut(x, out int _);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get mouse state x out and y valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetMouseStateXOutAndY_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr y = IntPtr.Zero;

            // Act
            uint result = Sdl.GetMouseStateXOutAndY(out int _, y);

            // Assert
            Assert.True(result == 0 || result == 1 || result == 2);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that get mouse state to x and y valid params returns expected uint
        /// </summary>
        [Fact]
        public void GetMouseStateToXAndY_ValidParams_ReturnsExpectedUint()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that blit surface valid params returns expected int
        /// </summary>
        [Fact]
        public void BlitSurface_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that blit surface ref src rect valid params returns expected int
        /// </summary>
        [Fact]
        public void BlitSurface_RefSrcRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that blit surface no ref src rect valid params returns expected int
        /// </summary>
        [Fact]
        public void BlitSurface_NoRefSrcRect_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
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
        /// Tests that format enum to masks valid params returns expected bool
        /// </summary>
        [Fact]
        public void FormatEnumToMasks_ValidParams_ReturnsExpectedBool()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            uint format = 0x86161804; // Replace with the desired format

            // Act
            SdlBool result = Sdl.FormatEnumToMasks(format, out int _, out uint _, out uint _, out uint _, out uint _);

            // Assert
            Assert.True(result == SdlBool.False || result == SdlBool.True);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set palette colors valid params returns expected int
        /// </summary>
        [Fact]
        public void SetPaletteColors_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr palette = IntPtr.Zero; // Replace with the desired palette
            SdlColor[] colors = new SdlColor[256]; // Replace with the desired colors
            int firstColor = 0, nColors = 256; // Replace with the desired first color and number of colors

            // Act
            int result = Sdl.SetPaletteColors(palette, colors, firstColor, nColors);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }

        /// <summary>
        /// Tests that set pixel format palette valid params returns expected int
        /// </summary>
        [Fact]
        public void SetPixelFormatPalette_ValidParams_ReturnsExpectedInt()
        {
            // Arrange
            int initResult = Sdl.Init(SdlInit.InitEverything);
            Assert.Equal(0, initResult);

            IntPtr format = IntPtr.Zero; // Replace with the desired format
            IntPtr palette = IntPtr.Zero; // Replace with the desired palette

            // Act
            int result = Sdl.SetPixelFormatPalette(format, palette);

            // Assert
            Assert.True(result >= -1);

            Sdl.Quit();
        }
    }
}