// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderTextureExecutionTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Executes the <see cref="RenderTexture" /> wrapper members against the real native CSFML library. The
    ///     installed CSFML 3.0 changed the creation ABI to <c>sfRenderTexture_create(sfVector2u, sfBool)</c> while the
    ///     wrapper still declares the CSFML 2.x three integer form; a native probe confirmed that the mismatched call
    ///     dereferences the height argument as a <c>ContextSettings*</c> pointer and kills the test host with a
    ///     SIGSEGV, so no <see cref="RenderTexture" /> instance can be created and every instance member is
    ///     unreachable. Only the members whose native entry point is missing entirely (managed
    ///     <see cref="EntryPointNotFoundException" />) can be exercised safely.
    /// </summary>
    public class RenderTextureExecutionTests
    {
        /// <summary>
        ///     The width used by the assertions
        /// </summary>
        private const uint TextureWidth = 64;

        /// <summary>
        ///     The height used by the assertions
        /// </summary>
        private const uint TextureHeight = 64;

        /// <summary>
        ///     Tests that the maximum antialiasing level property throws the missing entry point error of the installed
        ///     CSFML 3.0 library, which renamed the symbol to <c>sfRenderTexture_getMaximumAntiAliasingLevel</c>
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumAntialiasingLevel_ThrowsEntryPointNotFound()
        {
            Assert.Throws<EntryPointNotFoundException>(() => _ = RenderTexture.MaximumAntialiasingLevel);
        }

        /// <summary>
        ///     Tests that the context settings constructor throws the missing entry point error of the installed CSFML 3.0
        ///     library, which dropped the <c>sfRenderTexture_createWithSettings</c> symbol
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Ctor_WidthHeightContextSettings_ThrowsEntryPointNotFound()
        {
            Assert.Throws<EntryPointNotFoundException>(() =>
            {
                using RenderTexture renderTexture = new RenderTexture(TextureWidth, TextureHeight, new ContextSettings(0, 0));
            });
        }
    }
}
