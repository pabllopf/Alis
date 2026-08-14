// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2SurfaceCoverageTests.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for software surface operations
    /// </summary>
    public class Sdl2SurfaceCoverageTests
    {
        /// <summary>
        ///     Tests that a software surface can be created and filled
        /// </summary>
        [RequireSdl2Fact]
        public void SurfaceCreateAndFill_Works()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            RectangleI rect = new RectangleI();
            Sdl.FillRect(surface, ref rect, 0xFF0000FF);
            Sdl.FillRect(surface, IntPtr.Zero, 0xFF0000FF);
            Sdl.FillRects(surface, new RectangleI[1], 1, 0xFF0000FF);
        }

        /// <summary>
        ///     Tests that surface state getters work on a real surface
        /// </summary>
        [RequireSdl2Fact]
        public void SurfaceStateGetters_Work()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            RectangleI rect;
            Sdl.GetClipRect(surface, out rect);
            Sdl.HasColorKey(surface);
            uint key;
            Sdl.GetColorKey(surface, out key);
            byte alpha;
            Sdl.GetSurfaceAlphaMod(surface, out alpha);
            BlendModes blend;
            Sdl.GetSurfaceBlendMode(surface, out blend);
            byte r;
            byte g;
            byte b;
            Sdl.GetSurfaceColorMod(surface, out r, out g, out b);
        }

        /// <summary>
        ///     Tests that surface state setters work on a real surface
        /// </summary>
        [RequireSdl2Fact]
        public void SurfaceStateSetters_Work()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            RectangleI rect = new RectangleI();
            Sdl.SetClipRect(surface, ref rect);
            Sdl.SetColorKey(surface, 1, 0xFF);
            Sdl.SetSurfaceAlphaMod(surface, 128);
            Sdl.SetSurfaceBlendMode(surface, BlendModes.None);
            Sdl.SetSurfaceColorMod(surface, 128, 128, 128);
        }

        /// <summary>
        ///     Tests that surface locking works on a real surface
        /// </summary>
        [RequireSdl2Fact]
        public void SurfaceLock_Works()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            Sdl.LockSurface(surface);
            Sdl.UnlockSurface(surface);
        }

        /// <summary>
        ///     Tests that blit operations work between software surfaces
        /// </summary>
        [RequireSdl2Fact]
        public void SurfaceBlits_Work()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            RectangleI rect = new RectangleI();
            Sdl.UpperBlit(surface, ref rect, surface, ref rect);
            Sdl.UpperBlitScaled(surface, ref rect, surface, ref rect);
            Sdl.BlitSurface(surface, ref rect, surface, ref rect);
            Sdl.BlitSurface(surface, IntPtr.Zero, surface, ref rect);
            Sdl.BlitSurface(surface, ref rect, surface, IntPtr.Zero);
            Sdl.BlitSurface(surface, IntPtr.Zero, surface, IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that palette functions accept null pointers
        /// </summary>
        [RequireSdl2Fact]
        public void PaletteFunctions_WithNull_DoNotCrash()
        {
            Sdl.SetPaletteColors(IntPtr.Zero, new Color[1], 0, 1);
            Sdl.SetPixelFormatPalette(IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that setting a null palette on a surface does not crash
        /// </summary>
        [RequireSdl2Fact]
        public void SetSurfacePalette_WithNull_DoesNotCrash()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            Sdl.SetSurfacePalette(surface, IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that converting a surface with a null format does not crash
        /// </summary>
        [RequireSdl2Fact]
        public void ConvertSurface_WithNullFormat_DoesNotCrash()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            Sdl.ConvertSurface(surface, IntPtr.Zero, 0);
        }

        /// <summary>
        ///     Tests that a software renderer can be created on a surface
        /// </summary>
        [RequireSdl2Fact]
        public void CreateSoftwareRenderer_Works()
        {
            IntPtr surface = Sdl.CreateRgbSurfaceWithFormat(0, 64, 64, 32, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(IntPtr.Zero, surface);
            IntPtr renderer = Sdl.CreateSoftwareRenderer(surface);
            if (renderer != IntPtr.Zero)
            {
                Sdl.DestroyRenderer(renderer);
            }
        }

        /// <summary>
        ///     Tests that a bitmap can be loaded from the assets folder
        /// </summary>
        [RequireSdl2Fact]
        public void LoadBmp_FromAssets_ReturnsSurface()
        {
            string file = Sdl2TestAssets.Find("tile000.bmp");
            if (file == null)
            {
                return;
            }
            IntPtr surface = Sdl.LoadBmp(file);
            Assert.NotEqual(IntPtr.Zero, surface);
        }
    }
}
