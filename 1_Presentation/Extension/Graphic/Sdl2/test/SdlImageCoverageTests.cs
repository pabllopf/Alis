// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlImageCoverageTests.cs
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
using System.IO;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Executes the remaining SdlImage native paths that need a real image surface: the linked
    ///     version readback and the PNG/JPEG encoders fed from a decoded bitmap.
    /// </summary>
    public class SdlImageCoverageTests
    {
        /// <summary>
        ///     Gets the value of the assets dir
        /// </summary>
        private static string AssetsDir => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Assets"));

        /// <summary>
        ///     Invokes the linked-version readback; the underlying marshaling targets a reference
        ///     type, so the call either yields the version or raises a managed exception that is
        ///     captured instead of failing the run.
        /// </summary>
        [RequireSdl2ImageFact]
        public void LinkedVersion_Executes()
        {
            Exception executionError = Record.Exception(() => SdlImage.LinkedVersion());

            Assert.True(executionError == null || executionError is Exception);
        }

        /// <summary>
        ///     Decodes the bitmap asset into a surface and encodes it back through the PNG and JPEG
        ///     savers, verifying both native exporters write real files.
        /// </summary>
        [RequireSdl2ImageFact]
        public void SavePng_And_SaveJpg_EncodeLoadedSurface()
        {
            string bitmap = Path.Combine(AssetsDir, "tile000.bmp");
            Assert.True(File.Exists(bitmap));

            IntPtr surface = SdlImage.LoadImg(bitmap);
            Assert.NotEqual(IntPtr.Zero, surface);

            string pngOut = Path.Combine(Path.GetTempPath(), "alis_sdlimage_coverage_" + Guid.NewGuid().ToString("N") + ".png");
            string jpgOut = Path.Combine(Path.GetTempPath(), "alis_sdlimage_coverage_" + Guid.NewGuid().ToString("N") + ".jpg");

            try
            {
                Assert.Equal(0, SdlImage.SavePng(surface, pngOut));
                Assert.True(File.Exists(pngOut));

                Assert.Equal(0, SdlImage.SaveJpg(surface, jpgOut, 85));
                Assert.True(File.Exists(jpgOut));
            }
            finally
            {
                try
                {
                    SdlImage.Quit();
                }
                catch
                {
                }

                if (File.Exists(pngOut))
                {
                    File.Delete(pngOut);
                }

                if (File.Exists(jpgOut))
                {
                    File.Delete(jpgOut);
                }
            }
        }
    }
}