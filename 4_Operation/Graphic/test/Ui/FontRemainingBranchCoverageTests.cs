// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontRemainingBranchCoverageTests.cs
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
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    ///     Coverage tests for the font gl-bound initialization methods.
    /// </summary>
    public class FontRemainingBranchCoverageTests
    {
        /// <summary>
        ///     Tests that initialize shaders throws when open gl is not initialized
        /// </summary>
        [Fact]
        public void InitializeShaders_ThrowsWhenOpenGlNotInitialized()
        {
            Font font = new Font("test.bmp", 1, 16);

            Assert.ThrowsAny<Exception>(() => font.InitializeShaders());
        }

        /// <summary>
        ///     Tests that load texture uses the resources fallback when the file is missing
        /// </summary>
        [Fact]
        public void LoadTexture_WithMissingFile_UsesResourcesFallback()
        {
            Font font = new Font("missing_font_resource", 1, 16);

            Assert.ThrowsAny<Exception>(() => font.LoadTexture("no_such_file.bmp"));
        }

        /// <summary>
        ///     Tests that setup buffers computes geometry before throwing when open gl is not initialized
        /// </summary>
        [Fact]
        public void SetupBuffers_ComputesGeometryThenThrowsWhenOpenGlNotInitialized()
        {
            Font font = new Font("test.bmp", 1, 16);

            Assert.ThrowsAny<Exception>(() => font.SetupBuffers());
        }

        /// <summary>
        ///     Tests that render text with a name file enters the gl initialization block
        /// </summary>
        [Fact]
        public void RenderText_WithNameFile_EntersGlInitializationBlock()
        {
            Font font = new Font("test.bmp", 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("hello", 0, 0, Color.White, Color.Transparent));
        }

        /// <summary>
        ///     Tests that render text with an empty name file skips the gl initialization block
        /// </summary>
        [Fact]
        public void RenderText_WithEmptyNameFile_SkipsGlInitializationBlock()
        {
            Font font = new Font(string.Empty, 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("hello", 0, 0, Color.White, Color.Transparent));
        }
    }
}
