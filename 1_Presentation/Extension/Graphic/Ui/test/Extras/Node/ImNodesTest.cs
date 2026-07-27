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
    public class ImNodesTest
    {
        [RequireCImguiSystemFact]
        public void CreateContext_ShouldReturnNonNull()
        {
            ImNodesContext ctx = ImNodes.CreateContext();
            Assert.NotNull(ctx);
        }

        [RequireCImguiSystemFact]
        public void EditorContextCreate_ShouldReturnNonNull()
        {
            ImNodesEditorContext editorCtx = ImNodes.EditorContextCreate();
            Assert.NotNull(editorCtx);
        }

        [RequireCImguiSystemFact]
        public void SetCurrentContext_ShouldNotThrow()
        {
            ImNodesContext ctx = new ImNodesContext();
            ImNodes.SetCurrentContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void SetImGuiContext_ShouldNotThrow()
        {
            IntPtr ctx = IntPtr.Zero;
            ImNodes.SetImGuiContext(ctx);
        }

        [RequireCImguiSystemFact]
        public void SaveCurrentEditorStateToIniString_ShouldThrow()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString());
        }

        [RequireCImguiSystemFact]
        public void SaveCurrentEditorStateToIniString_WithDataSize_ShouldThrow()
        {
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString(ref dataSize));
        }

        [RequireCImguiSystemFact]
        public void SaveEditorStateToIniString_WithEditor_ShouldThrow()
        {
            ImNodesEditorContext editor = new ImNodesEditorContext();
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(editor));
        }

        [RequireCImguiSystemFact]
        public void SaveEditorStateToIniString_WithEditorAndDataSize_ShouldThrow()
        {
            ImNodesEditorContext editor = new ImNodesEditorContext();
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(editor, ref dataSize));
        }

        [RequireCImguiSystemFact]
        public void GetStyle_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.GetStyle());
        }

        [RequireCImguiSystemFact]
        public void GetIo_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.GetIo());
        }

        [RequireCImguiSystemFact]
        public void StyleColorsClassic_NoArg_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsClassic());
        }

        [RequireCImguiSystemFact]
        public void StyleColorsClassic_WithDest_ShouldThrow()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsClassic(dest));
        }

        [RequireCImguiSystemFact]
        public void StyleColorsDark_NoArg_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsDark());
        }

        [RequireCImguiSystemFact]
        public void StyleColorsDark_WithDest_ShouldThrow()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsDark(dest));
        }

        [RequireCImguiSystemFact]
        public void StyleColorsLight_NoArg_ShouldThrow()
        {
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsLight());
        }

        [RequireCImguiSystemFact]
        public void StyleColorsLight_WithDest_ShouldThrow()
        {
            ImNodesStyle dest = new ImNodesStyle();
            Assert.Throws<TypeLoadException>(() => ImNodes.StyleColorsLight(dest));
        }
    }
}
