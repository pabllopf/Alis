// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im nodes coverage tests class
    /// </summary>
    public class ImNodesCoverageTests
    {
        /// <summary>
        ///     Tests that create context does not throw and returns a context
        /// </summary>
        [RequireImNodesSystemFact]
        public void CreateContext_DoesNotThrow_ReturnsContext()
        {
            ImNodesContext ctx = ImNodes.CreateContext();
            Assert.NotNull(ctx);
        }

        /// <summary>
        ///     Tests that editor context create does not throw and returns an editor context
        /// </summary>
        [RequireImNodesSystemFact]
        public void EditorContextCreate_DoesNotThrow_ReturnsEditorContext()
        {
            ImNodesEditorContext editorCtx = ImNodes.EditorContextCreate();
            Assert.NotNull(editorCtx);
        }

        /// <summary>
        ///     Tests that set current context does not throw
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetCurrentContext_DoesNotThrow()
        {
            ImNodesContext ctx = ImNodes.CreateContext();
            ImNodes.SetCurrentContext(ctx);
        }

        /// <summary>
        ///     Tests that get current context does not throw
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetCurrentContext_DoesNotThrow()
        {
            ImNodesContext ctx = ImNodes.CreateContext();
            ImNodes.SetCurrentContext(ctx);
            ImNodes.GetCurrentContext();
        }

        /// <summary>
        ///     Tests that set im gui context does not throw using a zero pointer
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetImGuiContext_WithZeroPointer_DoesNotThrow()
        {
            ImNodes.SetImGuiContext(IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that load editor state from ini file with a non null file name does not throw
        /// </summary>
        [RequireImNodesSystemFact]
        public void LoadEditorStateFromIniFile_NonNullFileName_DoesNotThrow()
        {
            ImNodesContext ctx = ImNodes.CreateContext();
            ImNodes.SetCurrentContext(ctx);
            ImNodesEditorContext editor = new ImNodesEditorContext();
            ImNodes.LoadEditorStateFromIniFile(editor, "state.ini");
            Assert.NotNull(ctx);
        }

        /// <summary>
        ///     Tests that load editor state from ini string with a non null data does not throw
        /// </summary>
        [RequireImNodesSystemFact]
        public void LoadEditorStateFromIniString_NonNullData_DoesNotThrow()
        {
            ImNodesContext ctx = ImNodes.CreateContext();
            ImNodes.SetCurrentContext(ctx);
            ImNodesEditorContext editor = new ImNodesEditorContext();
            ImNodes.LoadEditorStateFromIniString(editor, "", 0);
            Assert.NotNull(ctx);
        }

        /// <summary>
        ///     Tests that get style throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetStyle_ThrowsTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.GetStyle());
        }

        /// <summary>
        ///     Tests that get io throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void GetIo_ThrowsTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.GetIo());
        }

        /// <summary>
        ///     Tests that style colors classic throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsClassic_ThrowsTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsClassic());
        }

        /// <summary>
        ///     Tests that style colors classic with dest throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsClassic_WithDest_ThrowsTypeLoadException()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsClassic(dest));
        }

        /// <summary>
        ///     Tests that style colors dark throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsDark_ThrowsTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsDark());
        }

        /// <summary>
        ///     Tests that style colors dark with dest throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsDark_WithDest_ThrowsTypeLoadException()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsDark(dest));
        }

        /// <summary>
        ///     Tests that style colors light throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsLight_ThrowsTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsLight());
        }

        /// <summary>
        ///     Tests that style colors light with dest throws a type load exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsLight_WithDest_ThrowsTypeLoadException()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsLight(dest));
        }

        /// <summary>
        ///     Tests that save current editor state to ini string throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void SaveCurrentEditorStateToIniString_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString());
        }

        /// <summary>
        ///     Tests that save current editor state to ini string with data size throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void SaveCurrentEditorStateToIniString_WithDataSize_ThrowsMarshalDirectiveException()
        {
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString(ref dataSize));
        }

        /// <summary>
        ///     Tests that save editor state to ini string throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void SaveEditorStateToIniString_ThrowsMarshalDirectiveException()
        {
            ImNodesEditorContext editor = new ImNodesEditorContext();
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(editor));
        }

        /// <summary>
        ///     Tests that save editor state to ini string with data size throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void SaveEditorStateToIniString_WithDataSize_ThrowsMarshalDirectiveException()
        {
            ImNodesEditorContext editor = new ImNodesEditorContext();
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(editor, ref dataSize));
        }

        /// <summary>
        ///     Tests that mini map throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void MiniMap_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap());
        }

        /// <summary>
        ///     Tests that mini map with fraction throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void MiniMap_WithFraction_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.2f));
        }

        /// <summary>
        ///     Tests that mini map with fraction and location throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void MiniMap_WithFractionAndLocation_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.2f, ImNodesMiniMapLocation.TopLeft));
        }

        /// <summary>
        ///     Tests that mini map with fraction, location and callback throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void MiniMap_WithFractionLocationAndCallback_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.2f, ImNodesMiniMapLocation.TopLeft, null));
        }

        /// <summary>
        ///     Tests that mini map with fraction, location, callback and data throws a marshal directive exception
        /// </summary>
        [RequireImNodesSystemFact]
        public void MiniMap_WithFractionLocationCallbackAndData_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.2f, ImNodesMiniMapLocation.TopLeft, null, null));
        }
    }
}