// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesTest.cs
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

//  File:ImNodesTest.cs
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

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    /// The im nodes test class
    /// </summary>
    public class ImNodesTest
    {
        /// <summary>
        /// Creates the context should return non null
        /// </summary>
        [RequireCImguiSystemFact]
        public void CreateContext_ShouldReturnNonNull()
        {
            ImNodesContext ctx = ImNodes.CreateContext();
        }

        /// <summary>
        /// Editors the context create should return non null
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextCreate_ShouldReturnNonNull()
        {
            ImNodesEditorContext editorCtx = ImNodes.EditorContextCreate();
        }

        /// <summary>
        /// Sets the current context should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetCurrentContext_ShouldNotThrow()
        {
            ImNodesContext ctx = new ImNodesContext();
            ImNodes.SetCurrentContext(ctx);
        }

        /// <summary>
        /// Sets the im gui context should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetImGuiContext_ShouldNotThrow()
        {
            IntPtr ctx = IntPtr.Zero;
            ImNodes.SetImGuiContext(ctx);
        }

        /// <summary>
        /// Saves the current editor state to ini string should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveCurrentEditorStateToIniString_ShouldThrow()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString());
        }

        /// <summary>
        /// Saves the current editor state to ini string with data size should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveCurrentEditorStateToIniString_WithDataSize_ShouldThrow()
        {
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString(ref dataSize));
        }

        /// <summary>
        /// Saves the editor state to ini string with editor should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveEditorStateToIniString_WithEditor_ShouldThrow()
        {
            ImNodesEditorContext editor = new ImNodesEditorContext();
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(editor));
        }

        /// <summary>
        /// Saves the editor state to ini string with editor and data size should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveEditorStateToIniString_WithEditorAndDataSize_ShouldThrow()
        {
            ImNodesEditorContext editor = new ImNodesEditorContext();
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(editor, ref dataSize));
        }

        /// <summary>
        /// Gets the style should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyle_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.GetStyle());
        }

        /// <summary>
        /// Gets the io should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetIo_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.GetIo());
        }

        /// <summary>
        /// Styles the colors classic no arg should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsClassic_NoArg_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsClassic());
        }

        /// <summary>
        /// Styles the colors classic with dest should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsClassic_WithDest_ShouldThrow()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsClassic(dest));
        }

        /// <summary>
        /// Styles the colors dark no arg should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsDark_NoArg_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsDark());
        }

        /// <summary>
        /// Styles the colors dark with dest should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsDark_WithDest_ShouldThrow()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsDark(dest));
        }

        /// <summary>
        /// Styles the colors light no arg should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsLight_NoArg_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsLight());
        }

        /// <summary>
        /// Styles the colors light with dest should throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsLight_WithDest_ShouldThrow()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsLight(dest));
        }
    }
}
