// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Exercises the stateful ImNodes wrapper entry points that were not covered by the
    ///     existing context lifecycle tests. Every test owns a fresh ImGui context (and ImNodes
    ///     context) destroyed in finally, and all window-scoped calls run inside a real
    ///     NewFrame/Begin/End/EndFrame cycle.
    /// </summary>
    public class ImNodesRemainingCoverageTests
    {
        /// <summary>
        ///     The image offset of the native GImGui context slot
        /// </summary>
        private const int GImGuiSlot = 0x4597e0;

        /// <summary>
        ///     The dyld image count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_image_count")]
        private static extern int DyldImageCount();

        /// <summary>
        ///     The dyld get image name
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_name")]
        private static extern IntPtr DyldGetImageName(int index);

        /// <summary>
        ///     The dyld get image header
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport("libSystem.dylib", EntryPoint = "_dyld_get_image_header")]
        private static extern IntPtr DyldGetImageHeader(int index);

        /// <summary>
        ///     Creates a raw ImGui context, binds it as the current context and synchronizes the
        ///     native context slot of every loaded cimgui image.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateImGuiContext()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(ctx);
            SyncContextSlots(ctx);
            return ctx;
        }

        /// <summary>
        ///     Creates an ImGui context ready for a real frame: the native context slot of every
        ///     loaded cimgui image is synchronized, a display size is written into the io struct
        ///     and the font atlas is built so that igNewFrame can run without aborting.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateFramedImGuiContext()
        {
            IntPtr ctx = CreateImGuiContext();
            IntPtr ioPtr = ImGuiNative.igGetIO();
            Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            return ctx;
        }

        /// <summary>
        ///     Synchronizes the ImGui context pointer of every loaded cimgui image so that a frame
        ///     started through one image copy is visible to all the other copies.
        /// </summary>
        /// <param name="imgui">The imgui context</param>
        private static void SyncContextSlots(IntPtr imgui)
        {
            int count = DyldImageCount();

            for (int i = 0; i < count; i++)
            {
                string name = Marshal.PtrToStringAnsi(DyldGetImageName(i));

                if (name != null && name.Contains("cimgui"))
                {
                    IntPtr imageBase = DyldGetImageHeader(i);
                    Marshal.WriteInt64(imageBase + GImGuiSlot, imgui.ToInt64());
                }
            }
        }

        /// <summary>
        ///     Verifies the default panning of a freshly created editor context is zero.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextGetPanning_ReturnsDefaultZero()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                Vector2F panning = ImNodes.EditorContextGetPanning();
                Assert.Equal(0.0f, panning.X, 4);
                Assert.Equal(0.0f, panning.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies EditorContextResetPanning is reflected by EditorContextGetPanning.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextResetPanning_AppliesValue()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.EditorContextResetPanning(new Vector2F(12.5f, -3.5f));
                Vector2F panning = ImNodes.EditorContextGetPanning();
                Assert.Equal(12.5f, panning.X, 4);
                Assert.Equal(-3.5f, panning.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies EditorContextMoveToNode pans the editor to the negative origin of the node.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextMoveToNode_PansToNegativeOrigin()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeGridSpacePos(7, new Vector2F(100.0f, 200.0f));
                ImNodes.EditorContextMoveToNode(7);
                Vector2F panning = ImNodes.EditorContextGetPanning();
                Assert.Equal(-100.0f, panning.X, 4);
                Assert.Equal(-200.0f, panning.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetNodeGridSpacePos is reflected by GetNodeGridSpacePos.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetAndGetNodeGridSpacePos_RoundTrip()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeGridSpacePos(3, new Vector2F(45.0f, 67.0f));
                Vector2F pos = ImNodes.GetNodeGridSpacePos(3);
                Assert.Equal(45.0f, pos.X, 4);
                Assert.Equal(67.0f, pos.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetNodeScreenSpacePos is reflected by GetNodeScreenSpacePos while the
        ///     canvas origin and panning remain zero.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetAndGetNodeScreenSpacePos_RoundTrip()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeScreenSpacePos(3, new Vector2F(1.0f, 2.0f));
                Vector2F pos = ImNodes.GetNodeScreenSpacePos(3);
                Assert.Equal(1.0f, pos.X, 4);
                Assert.Equal(2.0f, pos.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetNodeEditorSpacePos is reflected by GetNodeEditorSpacePos while the
        ///     panning remains zero.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetAndGetNodeEditorSpacePos_RoundTrip()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeEditorSpacePos(3, new Vector2F(8.0f, 9.0f));
                Vector2F pos = ImNodes.GetNodeEditorSpacePos(3);
                Assert.Equal(8.0f, pos.X, 4);
                Assert.Equal(9.0f, pos.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies GetNodeDimensions reports the default zero rect size for a node that has
        ///     not been laid out.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetNodeDimensions_ReturnsDefaultRectSize()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeGridSpacePos(3, new Vector2F(0.0f, 0.0f));
                Vector2F dimensions = ImNodes.GetNodeDimensions(3);
                Assert.Equal(0.0f, dimensions.X, 4);
                Assert.Equal(0.0f, dimensions.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SnapNodeToGrid leaves the origin untouched while grid snapping is not
        ///     enabled.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SnapNodeToGrid_KeepsOriginWhenSnappingDisabled()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeGridSpacePos(3, new Vector2F(33.0f, 77.0f));
                ImNodes.SnapNodeToGrid(3);
                Vector2F pos = ImNodes.GetNodeGridSpacePos(3);
                Assert.Equal(33.0f, pos.X, 4);
                Assert.Equal(77.0f, pos.Y, 4);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetNodeDraggable executes for both flag values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNodeDraggable_Executes()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeGridSpacePos(3, new Vector2F(0.0f, 0.0f));
                ImNodes.SetNodeDraggable(3, false);
                ImNodes.SetNodeDraggable(3, true);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SelectNode, IsNodeSelected, NumSelectedNodes and the id based
        ///     ClearNodeSelection round trip.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SelectNode_IsSelectedAndCountable()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeGridSpacePos(7, new Vector2F(0.0f, 0.0f));
                Assert.False(ImNodes.IsNodeSelected(7));
                ImNodes.SelectNode(7);
                Assert.True(ImNodes.IsNodeSelected(7));
                Assert.False(ImNodes.IsNodeSelected(8));
                Assert.Equal(1, ImNodes.NumSelectedNodes());
                ImNodes.ClearNodeSelection(7);
                Assert.Equal(0, ImNodes.NumSelectedNodes());
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies ClearNodeSelection without arguments clears every selected node.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearNodeSelection_WithoutArgument_ClearsAll()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.SetNodeGridSpacePos(7, new Vector2F(0.0f, 0.0f));
                ImNodes.SetNodeGridSpacePos(8, new Vector2F(0.0f, 0.0f));
                ImNodes.SelectNode(7);
                ImNodes.SelectNode(8);
                Assert.Equal(2, ImNodes.NumSelectedNodes());
                ImNodes.ClearNodeSelection();
                Assert.Equal(0, ImNodes.NumSelectedNodes());
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies PushStyleVar with a float value and the matching PopStyleVar overloads
        ///     execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushPopStyleVar_Float_Executes()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.PushStyleVar(ImNodesStyleVar.GridSpacing, 42.0f);
                ImNodes.PopStyleVar();
                ImNodes.PushStyleVar(ImNodesStyleVar.GridSpacing, 24.0f);
                ImNodes.PopStyleVar(1);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies PushStyleVar with a vector value and the matching PopStyleVar execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushPopStyleVar_Vector2_Executes()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.PushStyleVar(ImNodesStyleVar.NodePadding, new Vector2F(5.0f, 6.0f));
                ImNodes.PopStyleVar(1);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies PushColorStyle and PopColorStyle execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushPopColorStyle_Executes()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.PushColorStyle(ImNodesCol.NodeBackground, 4294901760u);
                ImNodes.PopColorStyle();
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies PushAttributeFlag and PopAttributeFlag execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushPopAttributeFlag_Executes()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.PushAttributeFlag(ImNodesConfigs.EnableLinkCreationOnSnap);
                ImNodes.PopAttributeFlag();
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies both IsAnyAttributeActive overloads report false while no attribute is
        ///     active.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsAnyAttributeActive_WithoutActiveAttribute_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                Assert.False(ImNodes.IsAnyAttributeActive());
                int attributeId = 0;
                Assert.False(ImNodes.IsAnyAttributeActive(ref attributeId));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsLinkDestroyed reports false while no link was destroyed.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkDestroyed_WithoutLinkEvent_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                int linkId = 7;
                Assert.False(ImNodes.IsLinkDestroyed(ref linkId));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies every IsLinkDropped overload reports false while no link was dropped.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkDropped_WithoutDropEvent_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                Assert.False(ImNodes.IsLinkDropped());
                int attributeId = 7;
                Assert.False(ImNodes.IsLinkDropped(ref attributeId));
                Assert.False(ImNodes.IsLinkDropped(ref attributeId, false));
                Assert.False(ImNodes.IsLinkDropped(ref attributeId, true));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies every IsLinkCreated overload reports false while no link was created.
        ///     The wrapper forwards the id values as native pointers; non-zero sentinels satisfy
        ///     the native null pointer assertions while the result stays false because no link
        ///     creation state is recorded.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkCreated_WithoutLinkEvent_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                int start = 7;
                int end = 7;
                Assert.False(ImNodes.IsLinkCreated(ref start, ref end));
                bool createdFromSnap = true;
                Assert.False(ImNodes.IsLinkCreated(ref start, ref end, ref createdFromSnap));
                Assert.False(createdFromSnap);
                int startNode = 7;
                Assert.False(ImNodes.IsLinkCreated(ref startNode, ref start, ref end, ref end));
                Assert.False(ImNodes.IsLinkCreated(ref startNode, ref start, ref end, ref end, ref createdFromSnap));
                Assert.False(createdFromSnap);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsLinkHovered reports false while no link is hovered.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkHovered_WithoutHover_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                int linkId = 7;
                Assert.False(ImNodes.IsLinkHovered(ref linkId));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsLinkStarted reports false while no link interaction started.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkStarted_WithoutLinkEvent_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                int attributeId = 7;
                Assert.False(ImNodes.IsLinkStarted(ref attributeId));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsNodeHovered reports false while no node is hovered.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsNodeHovered_WithoutHover_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                int nodeId = 7;
                Assert.False(ImNodes.IsNodeHovered(ref nodeId));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsPinHovered reports false while no pin is hovered.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsPinHovered_WithoutHover_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                int attributeId = 7;
                Assert.False(ImNodes.IsPinHovered(ref attributeId));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsEditorHovered reports false while no canvas window is hovered.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsEditorHovered_WithoutWindow_ReturnsFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                Assert.False(ImNodes.IsEditorHovered());
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsNodeSelected and IsLinkSelected report false for unknown ids and leave
        ///     the id based getters without side effects while nothing is selected.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SelectionQueries_ForUnknownIds_ReturnFalse()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                Assert.False(ImNodes.IsNodeSelected(42));
                Assert.False(ImNodes.IsLinkSelected(42));
                int nodeId = 7;
                ImNodes.GetSelectedNodes(ref nodeId);
                Assert.Equal(7, nodeId);
                int linkId = 7;
                ImNodes.GetSelectedLinks(ref linkId);
                Assert.Equal(7, linkId);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies LoadCurrentEditorStateFromIniString parses the panning line into the
        ///     current editor context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadCurrentEditorStateFromIniString_ParsesPanning()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                string data = "[editor]\npanning=1,2\n";
                ImNodes.LoadCurrentEditorStateFromIniString(data, (uint) data.Length);
                Vector2F panning = ImNodes.EditorContextGetPanning();
                Assert.Equal(1.0f, panning.X, 3);
                Assert.Equal(2.0f, panning.Y, 3);
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies LoadCurrentEditorStateFromIniFile executes without errors when the file
        ///     does not exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadCurrentEditorStateFromIniFile_WithMissingFile_Executes()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.LoadCurrentEditorStateFromIniFile("/tmp/alis_imnodes_missing_file.ini");
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies EditorContextSet executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextSet_Executes()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImNodes.EditorContextSet(new ImNodesEditorContext());
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies every StyleColors overload throws a marshaling TypeLoadException because
        ///     the backing style struct contains an array field that cannot cross the interop
        ///     boundary by value.
        /// </summary>
        [Fact]
        public void StyleColorsDark_Overloads_ThrowTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsDark());
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsDark(new ImNodesStyle()));
        }

        /// <summary>
        ///     Verifies every StyleColorsClassic overload throws a marshaling TypeLoadException
        ///     because the backing style struct contains an array field that cannot cross the
        ///     interop boundary by value.
        /// </summary>
        [Fact]
        public void StyleColorsClassic_Overloads_ThrowTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsClassic());
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsClassic(new ImNodesStyle()));
        }

        /// <summary>
        ///     Verifies every StyleColorsLight overload throws a marshaling TypeLoadException
        ///     because the backing style struct contains an array field that cannot cross the
        ///     interop boundary by value.
        /// </summary>
        [Fact]
        public void StyleColorsLight_Overloads_ThrowTypeLoadException()
        {
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsLight());
            Assert.ThrowsAny<TypeLoadException>(() => ImNodes.StyleColorsLight(new ImNodesStyle()));
        }

        /// <summary>
        ///     Verifies every MiniMap overload throws a MarshalDirectiveException because the
        ///     node hovering callback delegate cannot be marshaled to unmanaged code.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MiniMap_AllOverloads_ThrowMarshalDirectiveException()
        {
            IntPtr imgui = CreateImGuiContext();
            try
            {
                ImNodes.CreateContext();
                Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap());
                Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.25f));
                Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.25f, ImNodesMiniMapLocation.BottomRight));
                Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.25f, ImNodesMiniMapLocation.BottomRight, null));
                Assert.Throws<MarshalDirectiveException>(() => ImNodes.MiniMap(0.25f, ImNodesMiniMapLocation.BottomRight, null, null));
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies a complete node editor frame: editor, node, title bar, input, output and
        ///     static attributes, link creation, selection queries and the MiniMap scope entry
        ///     points execute against the native library.
        /// </summary>
        [MacOsOnly]
        public void NodeEditorFrame_WithNodeAttributesAndLink_Executes()
        {
            IntPtr imgui = CreateFramedImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImGuiNative.igNewFrame();
                ImNodes.BeginNodeEditor();
                ImNodes.BeginNode(1);
                ImNodes.BeginNodeTitleBar();
                ImGui.TextUnformatted("title");
                ImNodes.EndNodeTitleBar();
                ImNodes.BeginInputAttribute(2);
                ImGui.Text("input");
                ImNodes.EndInputAttribute();
                ImNodes.BeginInputAttribute(2, ImNodesPinShape.Quad);
                ImNodes.EndInputAttribute();
                ImNodes.BeginOutputAttribute(3);
                ImNodes.EndOutputAttribute();
                ImNodes.BeginOutputAttribute(3, ImNodesPinShape.QuadFilled);
                ImNodes.EndOutputAttribute();
                ImNodes.BeginStaticAttribute(4);
                ImNodes.EndStaticAttribute();
                Assert.False(ImNodes.IsAttributeActive());
                ImNodes.EndNode();
                ImNodes.Link(5, 2, 3);
                ImNodes.EndNodeEditor();
                ImNodes.SelectLink(5);
                Assert.True(ImNodes.IsLinkSelected(5));
                Assert.Equal(1, ImNodes.NumSelectedLinks());
                ImNodes.ClearLinkSelection(5);
                Assert.Equal(0, ImNodes.NumSelectedLinks());
                ImNodes.ClearLinkSelection();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies ShowDemoWindow drives the whole node editor demo flow inside a real
        ///     ImGui frame.
        /// </summary>
        [MacOsOnly]
        public void ShowDemoWindow_ExecutesInsideFrame()
        {
            IntPtr imgui = CreateFramedImGuiContext();
            try
            {
                ImNodes.CreateContext();
                ImGuiNative.igNewFrame();
                ImNodes.ShowDemoWindow();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImNodes.DestroyContext();
                ImGuiNative.igDestroyContext(imgui);
            }
        }
    }
}
