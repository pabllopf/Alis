// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontCoverageTests.cs
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
using System.Reflection;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    ///     The font coverage tests class
    /// </summary>
    public class FontCoverageTests
    {
 
        /// <summary>
        ///     Tests that load texture with missing file throws
        /// </summary>
        [Fact]
        public void LoadTexture_WithMissingFile_Throws()
        {
            Gl.Initialize(null);
            Font font = new Font("missing.bmp", 1, 12);

            Assert.ThrowsAny<Exception>(() => font.LoadTexture("__not_found__.bmp"));
        }

        /// <summary>
        ///     Tests that load texture with valid bmp throws at texture generation
        /// </summary>
        [Fact]
        public void LoadTexture_WithValidBmp_ThrowsAtTextureGeneration()
        {
            Gl.Initialize(null);
            string path = Path.Combine(Path.GetTempPath(), "alis_font_" + Guid.NewGuid().ToString("N") + ".bmp");
            File.WriteAllBytes(path, CreateTinyBmp());
            Font font = new Font("test.bmp", 1, 12);

            try
            {
                Assert.ThrowsAny<Exception>(() => font.LoadTexture(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

        /// <summary>
        ///     Tests that setup buffers throws when open gl not initialized
        /// </summary>
        [Fact]
        public void SetupBuffers_ThrowsWhenOpenGlNotInitialized()
        {
            Gl.Initialize(null);
            Font font = new Font("test.bmp", 1, 12);

            Assert.ThrowsAny<Exception>(() => font.SetupBuffers());
        }

        /// <summary>
        ///     Tests that render text with configured path throws at use program
        /// </summary>
        [Fact]
        public void RenderText_WithConfiguredPath_ThrowsAtUseProgram()
        {
            Gl.Initialize(null);
            Font font = new Font("test.bmp", 1, 12);
            font.Path = "configured";

            Assert.ThrowsAny<Exception>(() => font.RenderText("a", 0, 0, Color.White, Color.Transparent));
        }

        /// <summary>
        ///     Gets the private property using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The property info</returns>
        private static PropertyInfo GetPrivateProperty(string name)
        {
            return typeof(Font).GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
        }

 

        /// <summary>
        ///     Creates the tiny bmp
        /// </summary>
        /// <returns>The byte array</returns>
        private static byte[] CreateTinyBmp()
        {
            byte[] data = new byte[58];
            data[0] = 0x42;
            data[1] = 0x4D;
            data[2] = 58;
            data[10] = 54;
            data[14] = 40;
            data[18] = 1;
            data[22] = 1;
            data[26] = 1;
            data[28] = 24;
            data[34] = 4;
            data[54] = 255;
            data[55] = 0;
            data[56] = 0;
            data[57] = 0;
            return data;
        }
    }
}
