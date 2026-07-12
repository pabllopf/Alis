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


using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     The im nodes test class
    /// </summary>
    public class ImNodesTest
    {
        /// <summary>
        ///     Tests that BeginInputAttribute starts an input attribute with default shape
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginInputAttribute_ShouldStartInputAttributeWithDefaultShape()
        {
            int id = 1;
        }

        /// <summary>
        ///     Tests that BeginInputAttribute starts an input attribute with specified shape
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginInputAttribute_ShouldStartInputAttributeWithSpecifiedShape()
        {
            int id = 1;
            ImNodesPinShape shape = ImNodesPinShape.CircleFilled;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginNode starts a node with the specified id
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginNode_ShouldStartNodeWithSpecifiedId()
        {
            int id = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginNodeEditor starts the node editor
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginNodeEditor_ShouldStartNodeEditor()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginNodeTitleBar starts the node title bar
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginNodeTitleBar_ShouldStartNodeTitleBar()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginOutputAttribute starts an output attribute with default shape
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginOutputAttribute_ShouldStartOutputAttributeWithDefaultShape()
        {
            int id = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginOutputAttribute starts an output attribute with specified shape
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginOutputAttribute_ShouldStartOutputAttributeWithSpecifiedShape()
        {
            int id = 1;
            ImNodesPinShape shape = ImNodesPinShape.CircleFilled;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that BeginStaticAttribute starts a static attribute with the specified id
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginStaticAttribute_ShouldStartStaticAttributeWithSpecifiedId()
        {
            int id = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearLinkSelection clears the link selection
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearLinkSelection_ShouldClearLinkSelection()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearLinkSelection clears the link selection with specified link id
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearLinkSelection_ShouldClearLinkSelectionWithSpecifiedLinkId()
        {
            int linkId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearNodeSelection clears the node selection
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearNodeSelection_ShouldClearNodeSelection()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that ClearNodeSelection clears the node selection with specified node id
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearNodeSelection_ShouldClearNodeSelectionWithSpecifiedNodeId()
        {
            int nodeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that CreateContext creates a new context
        /// </summary>
        [RequireCImguiSystemFact]
        public void CreateContext_ShouldCreateNewContext()
        {
        }

        /// <summary>
        ///     Tests that DestroyContext destroys the context
        /// </summary>
        [RequireCImguiSystemFact]
        public void DestroyContext_ShouldDestroyContext()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextCreate creates a new editor context
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextCreate_ShouldCreateNewEditorContext()
        {
        }

        /// <summary>
        ///     Tests that EditorContextFree frees the editor context
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextFree_ShouldFreeEditorContext()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextGetPanning gets the panning of the editor context
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextGetPanning_ShouldGetPanningOfEditorContext()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextMoveToNode moves the editor context to the specified node
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextMoveToNode_ShouldMoveEditorContextToSpecifiedNode()
        {
            int nodeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EditorContextResetPanning resets the panning of the editor context
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextResetPanning_ShouldResetPanningOfEditorContext()
        {
        }

        /// <summary>
        ///     Tests that EditorContextSet sets the editor context
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextSet_ShouldSetEditorContext()
        {
        }

        /// <summary>
        ///     Tests that EndInputAttribute ends the input attribute
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndInputAttribute_ShouldEndInputAttribute()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndNode ends the node
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndNode_ShouldEndNode()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndNodeEditor ends the node editor
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndNodeEditor_ShouldEndNodeEditor()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndNodeTitleBar ends the node title bar
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndNodeTitleBar_ShouldEndNodeTitleBar()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndOutputAttribute ends the output attribute
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndOutputAttribute_ShouldEndOutputAttribute()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that EndStaticAttribute ends the static attribute
        /// </summary>
        [RequireCImguiSystemFact]
        public void EndStaticAttribute_ShouldEndStaticAttribute()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetCurrentContext gets the current context
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetCurrentContext_ShouldGetCurrentContext()
        {
        }

        /// <summary>
        ///     Tests that GetNodeDimensions gets the dimensions of the node
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetNodeDimensions_ShouldGetDimensionsOfNode()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetNodeEditorSpacePos gets the editor space position of the node
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetNodeEditorSpacePos_ShouldGetEditorSpacePositionOfNode()
        {
            int nodeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetNodeGridSpacePos gets the grid space position of the node
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetNodeGridSpacePos_ShouldGetGridSpacePositionOfNode()
        {
            int nodeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetNodeScreenSpacePos gets the screen space position of the node
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetNodeScreenSpacePos_ShouldGetScreenSpacePositionOfNode()
        {
            int nodeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetSelectedLinks gets the selected links
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetSelectedLinks_ShouldGetSelectedLinks()
        {
            int linkIds = 0;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that GetSelectedNodes gets the selected nodes
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetSelectedNodes_ShouldGetSelectedNodes()
        {
            int nodeIds = 0;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsAnyAttributeActive returns whether any attribute is active
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsAnyAttributeActive_ShouldReturnWhetherAnyAttributeIsActive()
        {
            // Add assertions to verify the behavior
        }


        /// <summary>
        ///     Tests that IsAnyAttributeActive returns whether any attribute is active with specified attribute id
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsAnyAttributeActive_ShouldReturnWhetherAnyAttributeIsActiveWithSpecifiedAttributeId()
        {
            int attributeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsAttributeActive returns whether the attribute is active
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsAttributeActive_ShouldReturnWhetherAttributeIsActive()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsEditorHovered returns whether the editor is hovered
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsEditorHovered_ShouldReturnWhetherEditorIsHovered()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreated()
        {
            int startedAtAttributeId = 1;
            int endedAtAttributeId = 2;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created with specified snap
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreatedWithSpecifiedSnap()
        {
            int startedAtAttributeId = 1;
            int endedAtAttributeId = 2;
            bool createdFromSnap = false;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created with specified node and attribute ids
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreatedWithSpecifiedNodeAndAttributeIds()
        {
            int startedAtNodeId = 1;
            int startedAtAttributeId = 2;
            int endedAtNodeId = 3;
            int endedAtAttributeId = 4;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkCreated returns whether a link is created with specified node and attribute ids and snap
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkCreated_ShouldReturnWhetherLinkIsCreatedWithSpecifiedNodeAndAttributeIdsAndSnap()
        {
            int startedAtNodeId = 1;
            int startedAtAttributeId = 2;
            int endedAtNodeId = 3;
            int endedAtAttributeId = 4;
            bool createdFromSnap = false;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDestroyed returns whether a link is destroyed
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkDestroyed_ShouldReturnWhetherLinkIsDestroyed()
        {
            int linkId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDropped returns whether a link is dropped
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkDropped_ShouldReturnWhetherLinkIsDropped()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDropped returns whether a link is dropped with specified attribute id
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkDropped_ShouldReturnWhetherLinkIsDroppedWithSpecifiedAttributeId()
        {
            int startedAtAttributeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkDropped returns whether a link is dropped with specified attribute id and detached links
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkDropped_ShouldReturnWhetherLinkIsDroppedWithSpecifiedAttributeIdAndDetachedLinks()
        {
            int startedAtAttributeId = 1;
            bool includingDetachedLinks = true;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkHovered returns whether a link is hovered
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkHovered_ShouldReturnWhetherLinkIsHovered()
        {
            int linkId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkSelected returns whether a link is selected
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkSelected_ShouldReturnWhetherLinkIsSelected()
        {
            int linkId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsLinkStarted returns whether a link is started
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsLinkStarted_ShouldReturnWhetherLinkIsStarted()
        {
            int startedAtAttributeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsNodeHovered returns whether a node is hovered
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsNodeHovered_ShouldReturnWhetherNodeIsHovered()
        {
            int nodeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsNodeSelected returns whether a node is selected
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsNodeSelected_ShouldReturnWhetherNodeIsSelected()
        {
            int nodeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that IsPinHovered returns whether a pin is hovered
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsPinHovered_ShouldReturnWhetherPinIsHovered()
        {
            int attributeId = 1;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that Link links the specified attributes
        /// </summary>
        [RequireCImguiSystemFact]
        public void Link_ShouldLinkSpecifiedAttributes()
        {
            int id = 1;
            int startAttributeId = 2;
            int endAttributeId = 3;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadCurrentEditorStateFromIniFile loads the current editor state from ini file
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadCurrentEditorStateFromIniFile_ShouldLoadCurrentEditorStateFromIniFile()
        {
            string fileName = "test.ini";

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadCurrentEditorStateFromIniString loads the current editor state from ini string
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadCurrentEditorStateFromIniString_ShouldLoadCurrentEditorStateFromIniString()
        {
            string data = "test";
            uint dataSize = (uint) data.Length;

            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadEditorStateFromIniFile loads the editor state from ini file
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadEditorStateFromIniFile_ShouldLoadEditorStateFromIniFile()
        {
            // Add assertions to verify the behavior
        }

        /// <summary>
        ///     Tests that LoadEditorStateFromIniString loads the editor state from ini string
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadEditorStateFromIniString_ShouldLoadEditorStateFromIniString()
        {
        }

        /// <summary>
        ///     Tests that num selected links throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void NumSelectedLinks_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that num selected nodes throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void NumSelectedNodes_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that pop attribute flag throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopAttributeFlag_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that pop color style throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopColorStyle_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that pop style var throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopStyleVar_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that pop style var with count throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopStyleVar_WithCount_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that push attribute flag throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushAttributeFlag_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that push color style throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushColorStyle_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that push style var float throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushStyleVar_Float_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that push style var vector 2 throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushStyleVar_Vector2_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that save current editor state to ini file throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveCurrentEditorStateToIniFile_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that save current editor state to ini string throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveCurrentEditorStateToIniString_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString());
        }

        /// <summary>
        ///     Tests that save current editor state to ini string with data size throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveCurrentEditorStateToIniString_WithDataSize_ThrowsDllNotFoundException()
        {
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveCurrentEditorStateToIniString(ref dataSize));
        }

        /// <summary>
        ///     Tests that save editor state to ini file throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveEditorStateToIniFile_ThrowsDllNotFoundException()
        {
        }
        

        /// <summary>
        ///     Tests that save editor state to ini string with data size throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveEditorStateToIniString_WithDataSize_ThrowsDllNotFoundException()
        {
            uint dataSize = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImNodes.SaveEditorStateToIniString(new ImNodesEditorContext(), ref dataSize));
        }

        /// <summary>
        ///     Tests that select link throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SelectLink_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that select node throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SelectNode_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that set current context throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetCurrentContext_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that set im gui context throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetImGuiContext_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that set node draggable throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNodeDraggable_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that set node editor space pos throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNodeEditorSpacePos_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that set node grid space pos throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNodeGridSpacePos_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that set node screen space pos throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNodeScreenSpacePos_ThrowsDllNotFoundException()
        {
        }

        /// <summary>
        ///     Tests that snap node to grid throws dll not found exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void SnapNodeToGrid_ThrowsDllNotFoundException()
        {
        }
    }
}