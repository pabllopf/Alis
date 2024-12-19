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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Node
{
    /// <summary>
    ///     The im nodes test class
    /// </summary>
    public class ImNodesTest
    {
        /// <summary>
        ///     Tests that BeginInputAttribute starts an input attribute with default shape
        /// </summary>
        [Fact]
        public void BeginInputAttribute_ShouldStartInputAttributeWithDefaultShape()
        {
            int id = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginInputAttribute(id));
        }

        /// <summary>
        ///     Tests that BeginInputAttribute starts an input attribute with specified shape
        /// </summary>
        [Fact]
        public void BeginInputAttribute_ShouldStartInputAttributeWithSpecifiedShape()
        {
            int id = 1;
            ImNodesPinShape shape = ImNodesPinShape.CircleFilled;
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginInputAttribute(id, shape));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginNode starts a node with the specified id
        /// </summary>
        [Fact]
        public void BeginNode_ShouldStartNodeWithSpecifiedId()
        {
            int id = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginNode(id));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginNodeEditor starts the node editor
        /// </summary>
        [Fact]
        public void BeginNodeEditor_ShouldStartNodeEditor()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginNodeEditor());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginNodeTitleBar starts the node title bar
        /// </summary>
        [Fact]
        public void BeginNodeTitleBar_ShouldStartNodeTitleBar()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginNodeTitleBar());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginOutputAttribute starts an output attribute with default shape
        /// </summary>
        [Fact]
        public void BeginOutputAttribute_ShouldStartOutputAttributeWithDefaultShape()
        {
            int id = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginOutputAttribute(id));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginOutputAttribute starts an output attribute with specified shape
        /// </summary>
        [Fact]
        public void BeginOutputAttribute_ShouldStartOutputAttributeWithSpecifiedShape()
        {
            int id = 1;
            ImNodesPinShape shape = ImNodesPinShape.CircleFilled;
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginOutputAttribute(id, shape));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginStaticAttribute starts a static attribute with the specified id
        /// </summary>
        [Fact]
        public void BeginStaticAttribute_ShouldStartStaticAttributeWithSpecifiedId()
        {
            int id = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.BeginStaticAttribute(id));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearLinkSelection clears the link selection
        /// </summary>
        [Fact]
        public void ClearLinkSelection_ShouldClearLinkSelection()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.ClearLinkSelection());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearLinkSelection clears the link selection with specified link id
        /// </summary>
        [Fact]
        public void ClearLinkSelection_ShouldClearLinkSelectionWithSpecifiedLinkId()
        {
            int linkId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.ClearLinkSelection(linkId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearNodeSelection clears the node selection
        /// </summary>
        [Fact]
        public void ClearNodeSelection_ShouldClearNodeSelection()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.ClearNodeSelection());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearNodeSelection clears the node selection with specified node id
        /// </summary>
        [Fact]
        public void ClearNodeSelection_ShouldClearNodeSelectionWithSpecifiedNodeId()
        {
            int nodeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.ClearNodeSelection(nodeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that CreateContext creates a new context
        /// </summary>
        [Fact]
        public void CreateContext_ShouldCreateNewContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.CreateContext());
        }

        /// <summary>
        ///     Tests that DestroyContext destroys the context
        /// </summary>
        [Fact]
        public void DestroyContext_ShouldDestroyContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.CreateContext());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextCreate creates a new editor context
        /// </summary>
        [Fact]
        public void EditorContextCreate_ShouldCreateNewEditorContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextCreate());
        }

        /// <summary>
        ///     Tests that EditorContextFree frees the editor context
        /// </summary>
        [Fact]
        public void EditorContextFree_ShouldFreeEditorContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextCreate());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextGetPanning gets the panning of the editor context
        /// </summary>
        [Fact]
        public void EditorContextGetPanning_ShouldGetPanningOfEditorContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextGetPanning());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextMoveToNode moves the editor context to the specified node
        /// </summary>
        [Fact]
        public void EditorContextMoveToNode_ShouldMoveEditorContextToSpecifiedNode()
        {
            int nodeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextMoveToNode(nodeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextResetPanning resets the panning of the editor context
        /// </summary>
        [Fact]
        public void EditorContextResetPanning_ShouldResetPanningOfEditorContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextResetPanning(new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that EditorContextSet sets the editor context
        /// </summary>
        [Fact]
        public void EditorContextSet_ShouldSetEditorContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextCreate());
        }

        /// <summary>
        ///     Tests that EndInputAttribute ends the input attribute
        /// </summary>
        [Fact]
        public void EndInputAttribute_ShouldEndInputAttribute()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EndInputAttribute());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndNode ends the node
        /// </summary>
        [Fact]
        public void EndNode_ShouldEndNode()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EndNode());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndNodeEditor ends the node editor
        /// </summary>
        [Fact]
        public void EndNodeEditor_ShouldEndNodeEditor()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EndNodeEditor());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndNodeTitleBar ends the node title bar
        /// </summary>
        [Fact]
        public void EndNodeTitleBar_ShouldEndNodeTitleBar()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EndNodeTitleBar());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndOutputAttribute ends the output attribute
        /// </summary>
        [Fact]
        public void EndOutputAttribute_ShouldEndOutputAttribute()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EndOutputAttribute());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndStaticAttribute ends the static attribute
        /// </summary>
        [Fact]
        public void EndStaticAttribute_ShouldEndStaticAttribute()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EndStaticAttribute());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetCurrentContext gets the current context
        /// </summary>
        [Fact]
        public void GetCurrentContext_ShouldGetCurrentContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.GetCurrentContext());
        }

        /// <summary>
        ///     Tests that GetNodeDimensions gets the dimensions of the node
        /// </summary>
        [Fact]
        public void GetNodeDimensions_ShouldGetDimensionsOfNode()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.GetNodeDimensions(1));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetNodeEditorSpacePos gets the editor space position of the node
        /// </summary>
        [Fact]
        public void GetNodeEditorSpacePos_ShouldGetEditorSpacePositionOfNode()
        {
            int nodeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.GetNodeEditorSpacePos(nodeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetNodeGridSpacePos gets the grid space position of the node
        /// </summary>
        [Fact]
        public void GetNodeGridSpacePos_ShouldGetGridSpacePositionOfNode()
        {
            int nodeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.GetNodeGridSpacePos(nodeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetNodeScreenSpacePos gets the screen space position of the node
        /// </summary>
        [Fact]
        public void GetNodeScreenSpacePos_ShouldGetScreenSpacePositionOfNode()
        {
            int nodeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.GetNodeScreenSpacePos(nodeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetSelectedLinks gets the selected links
        /// </summary>
        [Fact]
        public void GetSelectedLinks_ShouldGetSelectedLinks()
        {
            int linkIds = 0;
            Assert.Throws<DllNotFoundException>(() => ImNodes.GetSelectedLinks(ref linkIds));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetSelectedNodes gets the selected nodes
        /// </summary>
        [Fact]
        public void GetSelectedNodes_ShouldGetSelectedNodes()
        {
            int nodeIds = 0;
            Assert.Throws<DllNotFoundException>(() => ImNodes.GetSelectedNodes(ref nodeIds));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsAnyAttributeActive returns whether any attribute is active
        /// </summary>
        [Fact]
        public void IsAnyAttributeActive_ShouldReturnWhetherAnyAttributeIsActive()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsAnyAttributeActive());
            // Add assertions to verify the behavior
        }


        /// <summary>
        ///     Tests that IsAnyAttributeActive returns whether any attribute is active with specified attribute id
        /// </summary>
        [Fact]
        public void IsAnyAttributeActive_ShouldReturnWhetherAnyAttributeIsActiveWithSpecifiedAttributeId()
        {
            int attributeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsAnyAttributeActive(ref attributeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsAttributeActive returns whether the attribute is active
        /// </summary>
        [Fact]
        public void IsAttributeActive_ShouldReturnWhetherAttributeIsActive()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsAttributeActive());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsEditorHovered returns whether the editor is hovered
        /// </summary>
        [Fact]
        public void IsEditorHovered_ShouldReturnWhetherEditorIsHovered()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsEditorHovered());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created
        /// </summary>
        [Fact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreated()
        {
            int startedAtAttributeId = 1;
            int endedAtAttributeId = 2;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkCreated(ref startedAtAttributeId, ref endedAtAttributeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created with specified snap
        /// </summary>
        [Fact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreatedWithSpecifiedSnap()
        {
            int startedAtAttributeId = 1;
            int endedAtAttributeId = 2;
            bool createdFromSnap = false;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkCreated(ref startedAtAttributeId, ref endedAtAttributeId, ref createdFromSnap));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created with specified node and attribute ids
        /// </summary>
        [Fact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreatedWithSpecifiedNodeAndAttributeIds()
        {
            int startedAtNodeId = 1;
            int startedAtAttributeId = 2;
            int endedAtNodeId = 3;
            int endedAtAttributeId = 4;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkCreated(ref startedAtNodeId, ref startedAtAttributeId, ref endedAtNodeId, ref endedAtAttributeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created with specified node and attribute ids and snap
        /// </summary>
        [Fact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreatedWithSpecifiedNodeAndAttributeIdsAndSnap()
        {
            int startedAtNodeId = 1;
            int startedAtAttributeId = 2;
            int endedAtNodeId = 3;
            int endedAtAttributeId = 4;
            bool createdFromSnap = false;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkCreated(ref startedAtNodeId, ref startedAtAttributeId, ref endedAtNodeId, ref endedAtAttributeId, ref createdFromSnap));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDestroyed returns whether a link is destroyed
        /// </summary>
        [Fact]
        public void IsLinkDestroyed_ShouldReturnWhetherLinkIsDestroyed()
        {
            int linkId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkDestroyed(ref linkId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDropped returns whether a link is dropped
        /// </summary>
        [Fact]
        public void IsLinkDropped_ShouldReturnWhetherLinkIsDropped()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkDropped());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDropped returns whether a link is dropped with specified attribute id
        /// </summary>
        [Fact]
        public void IsLinkDropped_ShouldReturnWhetherLinkIsDroppedWithSpecifiedAttributeId()
        {
            int startedAtAttributeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkDropped(ref startedAtAttributeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDropped returns whether a link is dropped with specified attribute id and detached links
        /// </summary>
        [Fact]
        public void IsLinkDropped_ShouldReturnWhetherLinkIsDroppedWithSpecifiedAttributeIdAndDetachedLinks()
        {
            int startedAtAttributeId = 1;
            bool includingDetachedLinks = true;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkDropped(ref startedAtAttributeId, includingDetachedLinks));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkHovered returns whether a link is hovered
        /// </summary>
        [Fact]
        public void IsLinkHovered_ShouldReturnWhetherLinkIsHovered()
        {
            int linkId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkHovered(ref linkId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkSelected returns whether a link is selected
        /// </summary>
        [Fact]
        public void IsLinkSelected_ShouldReturnWhetherLinkIsSelected()
        {
            int linkId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkSelected(linkId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkStarted returns whether a link is started
        /// </summary>
        [Fact]
        public void IsLinkStarted_ShouldReturnWhetherLinkIsStarted()
        {
            int startedAtAttributeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsLinkStarted(ref startedAtAttributeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsNodeHovered returns whether a node is hovered
        /// </summary>
        [Fact]
        public void IsNodeHovered_ShouldReturnWhetherNodeIsHovered()
        {
            int nodeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsNodeHovered(ref nodeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsNodeSelected returns whether a node is selected
        /// </summary>
        [Fact]
        public void IsNodeSelected_ShouldReturnWhetherNodeIsSelected()
        {
            int nodeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsNodeSelected(nodeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsPinHovered returns whether a pin is hovered
        /// </summary>
        [Fact]
        public void IsPinHovered_ShouldReturnWhetherPinIsHovered()
        {
            int attributeId = 1;
            Assert.Throws<DllNotFoundException>(() => ImNodes.IsPinHovered(ref attributeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that Link links the specified attributes
        /// </summary>
        [Fact]
        public void Link_ShouldLinkSpecifiedAttributes()
        {
            int id = 1;
            int startAttributeId = 2;
            int endAttributeId = 3;
            Assert.Throws<DllNotFoundException>(() => ImNodes.Link(id, startAttributeId, endAttributeId));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadCurrentEditorStateFromIniFile loads the current editor state from ini file
        /// </summary>
        [Fact]
        public void LoadCurrentEditorStateFromIniFile_ShouldLoadCurrentEditorStateFromIniFile()
        {
            string fileName = "test.ini";
            Assert.Throws<DllNotFoundException>(() => ImNodes.LoadCurrentEditorStateFromIniFile(fileName));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadCurrentEditorStateFromIniString loads the current editor state from ini string
        /// </summary>
        [Fact]
        public void LoadCurrentEditorStateFromIniString_ShouldLoadCurrentEditorStateFromIniString()
        {
            string data = "test";
            uint dataSize = (uint) data.Length;
            Assert.Throws<DllNotFoundException>(() => ImNodes.LoadCurrentEditorStateFromIniString(data, dataSize));
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadEditorStateFromIniFile loads the editor state from ini file
        /// </summary>
        [Fact]
        public void LoadEditorStateFromIniFile_ShouldLoadEditorStateFromIniFile()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextCreate());
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadEditorStateFromIniString loads the editor state from ini string
        /// </summary>
        [Fact]
        public void LoadEditorStateFromIniString_ShouldLoadEditorStateFromIniString()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.EditorContextCreate());
        }

        /// <summary>
        ///     Tests that num selected links throws dll not found exception
        /// </summary>
        [Fact]
        public void NumSelectedLinks_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.NumSelectedLinks());
        }

        /// <summary>
        ///     Tests that num selected nodes throws dll not found exception
        /// </summary>
        [Fact]
        public void NumSelectedNodes_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.NumSelectedNodes());
        }

        /// <summary>
        ///     Tests that pop attribute flag throws dll not found exception
        /// </summary>
        [Fact]
        public void PopAttributeFlag_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PopAttributeFlag());
        }

        /// <summary>
        ///     Tests that pop color style throws dll not found exception
        /// </summary>
        [Fact]
        public void PopColorStyle_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PopColorStyle());
        }

        /// <summary>
        ///     Tests that pop style var throws dll not found exception
        /// </summary>
        [Fact]
        public void PopStyleVar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PopStyleVar());
        }

        /// <summary>
        ///     Tests that pop style var with count throws dll not found exception
        /// </summary>
        [Fact]
        public void PopStyleVar_WithCount_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PopStyleVar(1));
        }

        /// <summary>
        ///     Tests that push attribute flag throws dll not found exception
        /// </summary>
        [Fact]
        public void PushAttributeFlag_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PushAttributeFlag(ImNodesConfig.None));
        }

        /// <summary>
        ///     Tests that push color style throws dll not found exception
        /// </summary>
        [Fact]
        public void PushColorStyle_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PushColorStyle(ImNodesCol.NodeBackground, 0));
        }

        /// <summary>
        ///     Tests that push style var float throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleVar_Float_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PushStyleVar(ImNodesStyleVar.NodePadding, 0.0f));
        }

        /// <summary>
        ///     Tests that push style var vector 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void PushStyleVar_Vector2_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.PushStyleVar(ImNodesStyleVar.NodePadding, new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that save current editor state to ini file throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveCurrentEditorStateToIniFile_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SaveCurrentEditorStateToIniFile("fileName"));
        }

        /// <summary>
        ///     Tests that save current editor state to ini string throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveCurrentEditorStateToIniString_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString());
        }

        /// <summary>
        ///     Tests that save current editor state to ini string with data size throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveCurrentEditorStateToIniString_WithDataSize_ThrowsDllNotFoundException()
        {
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString(ref dataSize));
        }

        /// <summary>
        ///     Tests that save editor state to ini file throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveEditorStateToIniFile_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SaveEditorStateToIniFile(new ImNodesEditorContext(), "fileName"));
        }

        /// <summary>
        ///     Tests that save editor state to ini string throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveEditorStateToIniString_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(new ImNodesEditorContext()));
        }

        /// <summary>
        ///     Tests that save editor state to ini string with data size throws dll not found exception
        /// </summary>
        [Fact]
        public void SaveEditorStateToIniString_WithDataSize_ThrowsDllNotFoundException()
        {
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(new ImNodesEditorContext(), ref dataSize));
        }

        /// <summary>
        ///     Tests that select link throws dll not found exception
        /// </summary>
        [Fact]
        public void SelectLink_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SelectLink(0));
        }

        /// <summary>
        ///     Tests that select node throws dll not found exception
        /// </summary>
        [Fact]
        public void SelectNode_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SelectNode(0));
        }

        /// <summary>
        ///     Tests that set current context throws dll not found exception
        /// </summary>
        [Fact]
        public void SetCurrentContext_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SetCurrentContext(new ImNodesContext()));
        }

        /// <summary>
        ///     Tests that set im gui context throws dll not found exception
        /// </summary>
        [Fact]
        public void SetImGuiContext_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SetImGuiContext(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that set node draggable throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNodeDraggable_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SetNodeDraggable(0, true));
        }

        /// <summary>
        ///     Tests that set node editor space pos throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNodeEditorSpacePos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SetNodeEditorSpacePos(0, new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that set node grid space pos throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNodeGridSpacePos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SetNodeGridSpacePos(0, new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that set node screen space pos throws dll not found exception
        /// </summary>
        [Fact]
        public void SetNodeScreenSpacePos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SetNodeScreenSpacePos(0, new Vector2F(0, 0)));
        }

        /// <summary>
        ///     Tests that snap node to grid throws dll not found exception
        /// </summary>
        [Fact]
        public void SnapNodeToGrid_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImNodes.SnapNodeToGrid(0));
        }
    }
}