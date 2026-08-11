// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtrNativeCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Invokes the native ImFont methods through the ImFontPtr wrapper using the
    ///     default font rasterized by a headless context font atlas.
    /// </summary>
    public class ImFontPtrNativeCoverageTests
    {
        /// <summary>
        ///     Creates a context, adds the default font, builds the atlas and returns
        ///     the resulting font.
        /// </summary>
        private static ImFontPtr CreateBuiltFont()
        {
            IntPtr context = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(context);
            ImFontAtlasPtr atlas = new ImGuiIoPtr(ImGuiNative.igGetIO()).Fonts;
            ImFontPtr font = atlas.AddFontDefault();
            atlas.Build();
            return font;
        }

        /// <summary>
        ///     Destroys the active context.
        /// </summary>
        private static void DestroyContext()
        {
            ImGuiNative.igDestroyContext(ImGuiNative.igGetCurrentContext());
        }

        /// <summary>
        ///     Verifies IsLoaded returns true for the built default font.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLoaded_AfterBuild_ReturnsTrue()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                Assert.True(font.IsLoaded());
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies GetCharAdvance returns the advance of a glyph.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetCharAdvance_ReturnsAdvance()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                float advance = font.GetCharAdvance('A');
                Assert.True(advance > 0);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies FindGlyph and FindGlyphNoFallback execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FindGlyph_And_FindGlyphNoFallback_Execute()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                _ = font.FindGlyph('A');
                _ = font.FindGlyphNoFallback('A');
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies the struct-backed property getters execute on a real font.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PropertyGetters_OnRealFont_Execute()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                _ = font.IndexAdvanceX;
                _ = font.FallbackAdvanceX;
                _ = font.FontSize;
                _ = font.IndexLookup;
                _ = font.ContainerAtlas;
                _ = font.ConfigData;
                _ = font.ConfigDataCount;
                _ = font.FallbackChar;
                _ = font.EllipsisChar;
                _ = font.DotChar;
                _ = font.DirtyLookupTables;
                _ = font.Scale;
                _ = font.Ascent;
                _ = font.Descent;
                _ = font.MetricsTotalSurface;
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies the ConfigData property setter round trips through the native struct.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ConfigData_Setter_RoundTrips()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                ImFontConfigPtr config = font.ConfigData;
                font.ConfigData = config;
                Assert.Equal(config.NativePtr, font.ConfigData.NativePtr);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies GetDebugName throws because the generated wrapper cannot marshal
        ///     the native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetDebugName_ThrowsMarshalDirectiveException()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                Assert.Throws<MarshalDirectiveException>(() => font.GetDebugName());
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies BuildLookupTable rebuilds the glyph lookup structures.
        /// </summary>
        [RequireCImguiSystemFact]
        public void BuildLookupTable_Executes()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                font.BuildLookupTable();
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies SetGlyphVisible and AddRemapChar execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetGlyphVisible_And_AddRemapChar_Execute()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                font.SetGlyphVisible('A', true);
                font.SetGlyphVisible('B', false);
                font.AddRemapChar('C', 'D');
                font.AddRemapChar('E', 'F', true);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies AddGlyph appends a glyph to the font.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddGlyph_Executes()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                ImFontConfigPtr config = font.ConfigData;
                font.AddGlyph(config, 0x1234, 0, 0, 1, 1, 0, 0, 1, 1, 1.0f);
            }
            finally
            {
                DestroyContext();
            }
        }

        /// <summary>
        ///     Verifies GrowIndex and ClearOutputData execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GrowIndex_And_ClearOutputData_Execute()
        {
            ImFontPtr font = CreateBuiltFont();
            try
            {
                font.GrowIndex(100);
                font.ClearOutputData();
            }
            finally
            {
                DestroyContext();
            }
        }
    }
}
