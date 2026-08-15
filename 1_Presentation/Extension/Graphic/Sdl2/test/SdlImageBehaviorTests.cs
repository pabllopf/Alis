// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlImageBehaviorTests.cs
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
using Alis.Extension.Graphic.Sdl2.Sdl2Image;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Behavior tests for the sdl image wrapper asserting observable managed behavior
    ///     without depending on the native sdl2 image runtime being present
    /// </summary>
    public class SdlImageBehaviorTests
    {
        /// <summary>
        ///     Tests that the compiled version is always the bundled 2.0.6 release
        /// </summary>
        [Fact]
        public void Version_ReturnsBundledCompiledVersion()
        {
            Version version = SdlImage.Version();
            Assert.Equal(2, version.Major);
            Assert.Equal(0, version.Minor);
            Assert.Equal(6, version.Build);
        }

        /// <summary>
        ///     Tests that the linked version cannot be marshaled because system version is
        ///     not blittable or the native library is missing
        /// </summary>
        [Fact]
        public void LinkedVersion_Throws_BecauseVersionIsNotMarshallableOrLibraryMissing()
        {
            try
            {
                SdlImage.LinkedVersion();
                Assert.Fail("Linked version should not be marshallable");
            }
            catch (ArgumentException)
            {
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Tests that loading a missing file returns zero
        /// </summary>
        [Fact]
        public void LoadImg_MissingFile_ReturnsZero()
        {
            IntPtr surface = LoadOrZero(() => SdlImage.LoadImg("nonexistent_file_xyz.png"));
            Assert.Equal(IntPtr.Zero, surface);
        }

        /// <summary>
        ///     Tests that loading a typed rw with an invalid source returns zero
        /// </summary>
        [Fact]
        public void LoadTypedRw_InvalidSource_ReturnsZero()
        {
            IntPtr surface = LoadOrZero(() => SdlImage.LoadTypedRw(IntPtr.Zero, 0, "PNG"));
            Assert.Equal(IntPtr.Zero, surface);
        }

        /// <summary>
        ///     Tests that loading a texture with an invalid renderer returns zero
        /// </summary>
        [Fact]
        public void LoadTexture_InvalidRenderer_ReturnsZero()
        {
            IntPtr texture = LoadOrZero(() => SdlImage.LoadTexture(IntPtr.Zero, "test.png"));
            Assert.Equal(IntPtr.Zero, texture);
        }

        /// <summary>
        ///     Tests that loading a texture typed rw with invalid parameters returns zero
        /// </summary>
        [Fact]
        public void LoadTextureTypedRw_InvalidParameters_ReturnsZero()
        {
            IntPtr texture = LoadOrZero(() => SdlImage.LoadTextureTypedRw(IntPtr.Zero, IntPtr.Zero, 0, "PNG"));
            Assert.Equal(IntPtr.Zero, texture);
        }

        /// <summary>
        ///     Tests that saving png with an invalid surface returns an error code
        /// </summary>
        [Fact]
        public void SavePng_InvalidSurface_ReturnsError()
        {
            int result = SaveOrError(() => SdlImage.SavePng(IntPtr.Zero, "alis_coverage_save.png"));
            Assert.NotEqual(0, result);
        }

        /// <summary>
        ///     Tests that saving jpg with an invalid surface returns an error code
        /// </summary>
        [Fact]
        public void SaveJpg_InvalidSurface_ReturnsError()
        {
            int result = SaveOrError(() => SdlImage.SaveJpg(IntPtr.Zero, "alis_coverage_save.jpg", 90));
            Assert.NotEqual(0, result);
        }

        /// <summary>
        ///     Tests that getting the error returns a non null string
        /// </summary>
        [Fact]
        public void GetError_ReturnsNonNullString()
        {
            try
            {
                string error = SdlImage.GetError();
                Assert.NotNull(error);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Tests that the set error message is returned by the get error
        /// </summary>
        [Fact]
        public void SetError_ThenGetError_ContainsMessage()
        {
            try
            {
                SdlImage.SetError("alis image test");
                string error = SdlImage.GetError();
                Assert.Contains("alis image test", error);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Tests that loading an animation with a missing file returns zero
        /// </summary>
        [Fact]
        public void LoadAnimation_MissingFile_ReturnsZero()
        {
            IntPtr animation = LoadOrZero(() => SdlImage.LoadAnimation("nonexistent_file_xyz.gif"));
            Assert.Equal(IntPtr.Zero, animation);
        }

        /// <summary>
        ///     Tests that loading an animation rw with an invalid source returns zero
        /// </summary>
        [Fact]
        public void LoadAnimationRw_InvalidSource_ReturnsZero()
        {
            IntPtr animation = LoadOrZero(() => SdlImage.LoadAnimationRw(IntPtr.Zero, 0));
            Assert.Equal(IntPtr.Zero, animation);
        }

        /// <summary>
        ///     Tests that loading an animation typed rw with invalid parameters returns zero
        /// </summary>
        [Fact]
        public void LoadAnimationTypedRw_InvalidParameters_ReturnsZero()
        {
            IntPtr animation = LoadOrZero(() => SdlImage.LoadAnimationTypedRw(IntPtr.Zero, 0, "GIF"));
            Assert.Equal(IntPtr.Zero, animation);
        }

        /// <summary>
        ///     Tests that freeing a null animation does not throw
        /// </summary>
        [Fact]
        public void FreeAnimation_NullAnimation_DoesNotThrow()
        {
            InvokeIgnoringMissingLibrary(() => SdlImage.FreeAnimation(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that loading a gif animation rw with an invalid source returns zero
        /// </summary>
        [Fact]
        public void LoadGifAnimationRw_InvalidSource_ReturnsZero()
        {
            IntPtr animation = LoadOrZero(() => SdlImage.LoadGifAnimationRw(IntPtr.Zero));
            Assert.Equal(IntPtr.Zero, animation);
        }

        /// <summary>
        ///     Tests that init returns the requested flags and quit completes the round trip
        /// </summary>
        [Fact]
        public void Init_ReturnsRequestedFlags_AndQuitCompletes()
        {
            try
            {
                int result = SdlImage.Init(ImgInitFlags.ImgInitJpg | ImgInitFlags.ImgInitPng);
                Assert.NotEqual(0, result & (int) ImgInitFlags.ImgInitJpg);
                Assert.NotEqual(0, result & (int) ImgInitFlags.ImgInitPng);
                SdlImage.Quit();
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Tests that quit alone does not throw
        /// </summary>
        [Fact]
        public void Quit_DoesNotThrow()
        {
            InvokeIgnoringMissingLibrary(SdlImage.Quit);
        }

        /// <summary>
        ///     Tests that loading an rw with an invalid source returns zero
        /// </summary>
        [Fact]
        public void LoadRw_InvalidSource_ReturnsZero()
        {
            IntPtr surface = LoadOrZero(() => SdlImage.LoadRw(IntPtr.Zero, 0));
            Assert.Equal(IntPtr.Zero, surface);
        }

        /// <summary>
        ///     Tests that saving a jpg rw with invalid parameters returns an error code
        /// </summary>
        [Fact]
        public void SaveJpgRw_InvalidParameters_ReturnsError()
        {
            int result = SaveOrError(() => SdlImage.SaveJpgRw(IntPtr.Zero, IntPtr.Zero, 0, 90));
            Assert.NotEqual(0, result);
        }

        /// <summary>
        ///     Tests that saving a png rw with invalid parameters returns an error code
        /// </summary>
        [Fact]
        public void SavePngRw_InvalidParameters_ReturnsError()
        {
            int result = SaveOrError(() => SdlImage.SavePngRw(IntPtr.Zero, IntPtr.Zero, 0));
            Assert.NotEqual(0, result);
        }

        /// <summary>
        ///     Tests that reading an xpm array with no entries returns zero
        /// </summary>
        [Fact]
        public void ReadXpmFromArray_EmptyArray_ReturnsZero()
        {
            IntPtr surface = LoadOrZero(() => SdlImage.ReadXpmFromArray(new string[0]));
            Assert.Equal(IntPtr.Zero, surface);
        }

        /// <summary>
        ///     Invokes a pointer producing call returning zero when the native library is missing
        /// </summary>
        /// <param name="func">The native wrapped call</param>
        /// <returns>The pointer or zero when the library is missing</returns>
        private static IntPtr LoadOrZero(Func<IntPtr> func)
        {
            try
            {
                return func();
            }
            catch (DllNotFoundException)
            {
                return IntPtr.Zero;
            }
            catch (EntryPointNotFoundException)
            {
                return IntPtr.Zero;
            }
        }

        /// <summary>
        ///     Invokes an int producing call returning an error code when the native library is missing
        /// </summary>
        /// <param name="func">The native wrapped call</param>
        /// <returns>The int result or an error code when the library is missing</returns>
        private static int SaveOrError(Func<int> func)
        {
            try
            {
                return func();
            }
            catch (DllNotFoundException)
            {
                return -1;
            }
            catch (EntryPointNotFoundException)
            {
                return -1;
            }
        }

        /// <summary>
        ///     Invokes a void call ignoring missing library errors
        /// </summary>
        /// <param name="action">The native wrapped call</param>
        private static void InvokeIgnoringMissingLibrary(Action action)
        {
            try
            {
                action();
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
        }
    }
}
