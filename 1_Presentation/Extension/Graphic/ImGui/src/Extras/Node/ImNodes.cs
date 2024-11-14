// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodes.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui.Extras.Node
{
    /// <summary>
    ///     The im nodes class
    /// </summary>
    public static class ImNodes
    {
        /// <summary>
        ///     Begins the input attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginInputAttribute(int id)
        {
            ImNodesPinShape shape = ImNodesPinShape.CircleFilled;
            ImNodesNative.ImNodes_BeginInputAttribute(id, shape);
        }

        /// <summary>
        ///     Begins the input attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        public static void BeginInputAttribute(int id, ImNodesPinShape shape)
        {
            ImNodesNative.ImNodes_BeginInputAttribute(id, shape);
        }

        /// <summary>
        ///     Begins the node using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginNode(int id)
        {
            ImNodesNative.ImNodes_BeginNode(id);
        }

        /// <summary>
        ///     Begins the node editor
        /// </summary>
        public static void BeginNodeEditor()
        {
            ImNodesNative.ImNodes_BeginNodeEditor();
        }

        /// <summary>
        ///     Begins the node title bar
        /// </summary>
        public static void BeginNodeTitleBar()
        {
            ImNodesNative.ImNodes_BeginNodeTitleBar();
        }

        /// <summary>
        ///     Begins the output attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginOutputAttribute(int id)
        {
            ImNodesPinShape shape = ImNodesPinShape.CircleFilled;
            ImNodesNative.ImNodes_BeginOutputAttribute(id, shape);
        }

        /// <summary>
        ///     Begins the output attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        public static void BeginOutputAttribute(int id, ImNodesPinShape shape)
        {
            ImNodesNative.ImNodes_BeginOutputAttribute(id, shape);
        }

        /// <summary>
        ///     Begins the static attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginStaticAttribute(int id)
        {
            ImNodesNative.ImNodes_BeginStaticAttribute(id);
        }

        /// <summary>
        ///     Clears the link selection
        /// </summary>
        public static void ClearLinkSelection()
        {
            ImNodesNative.ImNodes_ClearLinkSelection_Nil();
        }

        /// <summary>
        ///     Clears the link selection using the specified link id
        /// </summary>
        /// <param name="linkId">The link id</param>
        public static void ClearLinkSelection(int linkId)
        {
            ImNodesNative.ImNodes_ClearLinkSelection_Int(linkId);
        }

        /// <summary>
        ///     Clears the node selection
        /// </summary>
        public static void ClearNodeSelection()
        {
            ImNodesNative.ImNodes_ClearNodeSelection_Nil();
        }

        /// <summary>
        ///     Clears the node selection using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        public static void ClearNodeSelection(int nodeId)
        {
            ImNodesNative.ImNodes_ClearNodeSelection_Int(nodeId);
        }

        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>The im nodes context ptr</returns>
        public static ImNodesContext CreateContext() => ImNodesNative.ImNodes_CreateContext();

        /// <summary>
        ///     Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            ImNodesNative.ImNodes_DestroyContext(new ImNodesContext());
        }

        /// <summary>
        ///     Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(ImNodesContext ctx)
        {
            ImNodesNative.ImNodes_DestroyContext(new ImNodesContext());
        }

        /// <summary>
        ///     Editors the context create
        /// </summary>
        /// <returns>The im nodes editor context ptr</returns>
        public static ImNodesEditorContext EditorContextCreate() => ImNodesNative.ImNodes_EditorContextCreate();

        /// <summary>
        ///     Editors the context free using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        public static void EditorContextFree(ImNodesEditorContext noname1)
        {
            ImNodesNative.ImNodes_EditorContextFree(noname1);
        }

        /// <summary>
        ///     Editors the context get panning
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 EditorContextGetPanning()
        {
            ImNodesNative.ImNodes_EditorContextGetPanning(out Vector2 retval);
            return retval;
        }

        /// <summary>
        ///     Editors the context move to node using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        public static void EditorContextMoveToNode(int nodeId)
        {
            ImNodesNative.ImNodes_EditorContextMoveToNode(nodeId);
        }

        /// <summary>
        ///     Editors the context reset panning using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public static void EditorContextResetPanning(Vector2 pos)
        {
            ImNodesNative.ImNodes_EditorContextResetPanning(pos);
        }

        /// <summary>
        ///     Editors the context set using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        public static void EditorContextSet(ImNodesEditorContext noname1)
        {
            ImNodesNative.ImNodes_EditorContextSet(noname1);
        }

        /// <summary>
        ///     Ends the input attribute
        /// </summary>
        public static void EndInputAttribute()
        {
            ImNodesNative.ImNodes_EndInputAttribute();
        }

        /// <summary>
        ///     Ends the node
        /// </summary>
        public static void EndNode()
        {
            ImNodesNative.ImNodes_EndNode();
        }

        /// <summary>
        ///     Ends the node editor
        /// </summary>
        public static void EndNodeEditor()
        {
            ImNodesNative.ImNodes_EndNodeEditor();
        }

        /// <summary>
        ///     Ends the node title bar
        /// </summary>
        public static void EndNodeTitleBar()
        {
            ImNodesNative.ImNodes_EndNodeTitleBar();
        }

        /// <summary>
        ///     Ends the output attribute
        /// </summary>
        public static void EndOutputAttribute()
        {
            ImNodesNative.ImNodes_EndOutputAttribute();
        }

        /// <summary>
        ///     Ends the static attribute
        /// </summary>
        public static void EndStaticAttribute()
        {
            ImNodesNative.ImNodes_EndStaticAttribute();
        }

        /// <summary>
        ///     Gets the current context
        /// </summary>
        /// <returns>The im nodes context ptr</returns>
        public static ImNodesContext GetCurrentContext() => ImNodesNative.ImNodes_GetCurrentContext();

        /// <summary>
        ///     Gets the io
        /// </summary>
        /// <returns>The im nodes io ptr</returns>
        public static ImNodesIo GetIo() => ImNodesNative.ImNodes_GetIO();

        /// <summary>
        ///     Gets the node dimensions using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeDimensions(int id)
        {
            ImNodesNative.ImNodes_GetNodeDimensions(out Vector2 retval, id);
            return retval;
        }

        /// <summary>
        ///     Gets the node editor space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeEditorSpacePos(int nodeId)
        {
            ImNodesNative.ImNodes_GetNodeEditorSpacePos(out Vector2 retval, nodeId);
            return retval;
        }

        /// <summary>
        ///     Gets the node grid space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeGridSpacePos(int nodeId)
        {
            ImNodesNative.ImNodes_GetNodeGridSpacePos(out Vector2 retval, nodeId);
            return retval;
        }

        /// <summary>
        ///     Gets the node screen space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeScreenSpacePos(int nodeId)
        {
            ImNodesNative.ImNodes_GetNodeScreenSpacePos(out Vector2 retval, nodeId);
            return retval;
        }

        /// <summary>
        ///     Gets the selected links using the specified link ids
        /// </summary>
        /// <param name="linkIds">The link ids</param>
        public static void GetSelectedLinks(ref int linkIds)
        {
            ImNodesNative.ImNodes_GetSelectedLinks(linkIds);
        }

        /// <summary>
        ///     Gets the selected nodes using the specified node ids
        /// </summary>
        /// <param name="nodeIds">The node ids</param>
        public static void GetSelectedNodes(ref int nodeIds)
        {
            ImNodesNative.ImNodes_GetSelectedNodes(nodeIds);
        }

        /// <summary>
        ///     Gets the style
        /// </summary>
        /// <returns>The im nodes style ptr</returns>
        public static ImNodesStyle GetStyle() => ImNodesNative.ImNodes_GetStyle();

        /// <summary>
        ///     Describes whether is any attribute active
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAnyAttributeActive()
        {
            byte ret = ImNodesNative.ImNodes_IsAnyAttributeActive(0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is any attribute active
        /// </summary>
        /// <param name="attributeId">The attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsAnyAttributeActive(ref int attributeId)
        {
            byte ret = ImNodesNative.ImNodes_IsAnyAttributeActive(attributeId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is attribute active
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAttributeActive()
        {
            byte ret = ImNodesNative.ImNodes_IsAttributeActive();
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is editor hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsEditorHovered()
        {
            byte ret = ImNodesNative.ImNodes_IsEditorHovered();
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link created
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="endedAtAttributeId">The ended at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int startedAtAttributeId, ref int endedAtAttributeId)
        {
            byte[] createdFromSnap = new byte[1];
            byte ret = ImNodesNative.ImNodes_IsLinkCreated_BoolPtr(startedAtAttributeId, endedAtAttributeId, createdFromSnap);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link created
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="endedAtAttributeId">The ended at attribute id</param>
        /// <param name="createdFromSnap">The created from snap</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int startedAtAttributeId, ref int endedAtAttributeId, ref bool createdFromSnap)
        {
            byte[] createdFromSnapArray = new byte[1];
            byte ret = ImNodesNative.ImNodes_IsLinkCreated_BoolPtr(startedAtAttributeId, endedAtAttributeId, createdFromSnapArray);
            createdFromSnap = createdFromSnapArray[0] != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link created
        /// </summary>
        /// <param name="startedAtNodeId">The started at node id</param>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="endedAtNodeId">The ended at node id</param>
        /// <param name="endedAtAttributeId">The ended at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int startedAtNodeId, ref int startedAtAttributeId, ref int endedAtNodeId, ref int endedAtAttributeId)
        {
            byte ret = ImNodesNative.ImNodes_IsLinkCreated_IntPtr(startedAtNodeId, startedAtAttributeId, endedAtNodeId, endedAtAttributeId, 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link created
        /// </summary>
        /// <param name="startedAtNodeId">The started at node id</param>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="endedAtNodeId">The ended at node id</param>
        /// <param name="endedAtAttributeId">The ended at attribute id</param>
        /// <param name="createdFromSnap">The created from snap</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int startedAtNodeId, ref int startedAtAttributeId, ref int endedAtNodeId, ref int endedAtAttributeId, ref bool createdFromSnap)
        {
            byte nativeCreatedFromSnapVal = createdFromSnap ? (byte) 1 : (byte) 0;
            byte ret = ImNodesNative.ImNodes_IsLinkCreated_IntPtr(startedAtNodeId, startedAtAttributeId, endedAtNodeId, endedAtAttributeId, nativeCreatedFromSnapVal);
            createdFromSnap = nativeCreatedFromSnapVal != 0;
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link destroyed
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkDestroyed(ref int linkId)
        {
            byte ret = ImNodesNative.ImNodes_IsLinkDestroyed(linkId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link dropped
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsLinkDropped()
        {
            int startedAtAttributeId = 0;
            byte includingDetachedLinks = 1;
            byte ret = ImNodesNative.ImNodes_IsLinkDropped(startedAtAttributeId, includingDetachedLinks);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link dropped
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkDropped(ref int startedAtAttributeId)
        {
            byte includingDetachedLinks = 1;
            byte ret = ImNodesNative.ImNodes_IsLinkDropped(includingDetachedLinks, includingDetachedLinks);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link dropped
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="includingDetachedLinks">The including detached links</param>
        /// <returns>The bool</returns>
        public static bool IsLinkDropped(ref int startedAtAttributeId, bool includingDetachedLinks)
        {
            byte nativeIncludingDetachedLinks = includingDetachedLinks ? (byte) 1 : (byte) 0;
            byte ret = ImNodesNative.ImNodes_IsLinkDropped(nativeIncludingDetachedLinks, nativeIncludingDetachedLinks);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link hovered
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkHovered(ref int linkId)
        {
            byte ret = ImNodesNative.ImNodes_IsLinkHovered(linkId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link selected
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkSelected(int linkId)
        {
            byte ret = ImNodesNative.ImNodes_IsLinkSelected(linkId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is link started
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkStarted(ref int startedAtAttributeId)
        {
            byte ret = ImNodesNative.ImNodes_IsLinkStarted(startedAtAttributeId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is node hovered
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The bool</returns>
        public static bool IsNodeHovered(ref int nodeId)
        {
            byte ret = ImNodesNative.ImNodes_IsNodeHovered(nodeId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is node selected
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The bool</returns>
        public static bool IsNodeSelected(int nodeId)
        {
            byte ret = ImNodesNative.ImNodes_IsNodeSelected(nodeId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is pin hovered
        /// </summary>
        /// <param name="attributeId">The attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsPinHovered(ref int attributeId)
        {
            byte ret = ImNodesNative.ImNodes_IsPinHovered(attributeId);
            return ret != 0;
        }

        /// <summary>
        ///     Links the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="startAttributeId">The start attribute id</param>
        /// <param name="endAttributeId">The end attribute id</param>
        public static void Link(int id, int startAttributeId, int endAttributeId)
        {
            ImNodesNative.ImNodes_Link(id, startAttributeId, endAttributeId);
        }

        /// <summary>
        ///     Loads the current editor state from ini file using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        public static void LoadCurrentEditorStateFromIniFile(string fileName)
        {
            if (fileName != null)
            {
                byte[] nativeFileName = Encoding.UTF8.GetBytes(fileName);
                ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniFile(nativeFileName);
            }
            else
            {
                ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniFile(null);
            }
        }

        /// <summary>
        ///     Loads the current editor state from ini string using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="dataSize">The data size</param>
        public static void LoadCurrentEditorStateFromIniString(string data, uint dataSize)
        {
            if (data != null)
            {
                byte[] nativeData = Encoding.UTF8.GetBytes(data);
                ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniString(nativeData, dataSize);
            }
            else
            {
                ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniString(null, dataSize);
            }
        }

        /// <summary>
        ///     Loads the editor state from ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="fileName">The file name</param>
        public static void LoadEditorStateFromIniFile(ImNodesEditorContext editor, string fileName)
        {
            if (fileName != null)
            {
                byte[] nativeFileName = Encoding.UTF8.GetBytes(fileName);
                ImNodesNative.ImNodes_LoadEditorStateFromIniFile(editor, nativeFileName);
            }
            else
            {
                ImNodesNative.ImNodes_LoadEditorStateFromIniFile(editor, null);
            }
        }

        /// <summary>
        ///     Loads the editor state from ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="data">The data</param>
        /// <param name="dataSize">The data size</param>
        public static void LoadEditorStateFromIniString(ImNodesEditorContext editor, string data, uint dataSize)
        {
            if (data != null)
            {
                byte[] nativeData = Encoding.UTF8.GetBytes(data);
                ImNodesNative.ImNodes_LoadEditorStateFromIniString(editor, nativeData, dataSize);
            }
            else
            {
                ImNodesNative.ImNodes_LoadEditorStateFromIniString(editor, null, dataSize);
            }
        }

        /// <summary>
        ///     Minis the map
        /// </summary>
        public static void MiniMap()
        {
            float minimapSizeFraction = 0.2f;
            ImNodesMiniMapLocation location = ImNodesMiniMapLocation.TopLeft;
            ImNodesMiniMapNodeHoveringCallback nodeHoveringCallback = null;
            ImNodesMiniMapNodeHoveringCallbackUserData nodeHoveringCallbackData = null;
            ImNodesNative.ImNodes_MiniMap(minimapSizeFraction, location, nodeHoveringCallback, nodeHoveringCallbackData);
        }

        /// <summary>
        ///     Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimapSizeFraction">The minimap size fraction</param>
        public static void MiniMap(float minimapSizeFraction)
        {
            ImNodesMiniMapLocation location = ImNodesMiniMapLocation.TopLeft;
            ImNodesMiniMapNodeHoveringCallback nodeHoveringCallback = null;
            ImNodesMiniMapNodeHoveringCallbackUserData nodeHoveringCallbackData = null;
            ImNodesNative.ImNodes_MiniMap(minimapSizeFraction, location, nodeHoveringCallback, nodeHoveringCallbackData);
        }

        /// <summary>
        ///     Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimapSizeFraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        public static void MiniMap(float minimapSizeFraction, ImNodesMiniMapLocation location)
        {
            ImNodesMiniMapNodeHoveringCallback nodeHoveringCallback = null;
            ImNodesMiniMapNodeHoveringCallbackUserData nodeHoveringCallbackData = null;
            ImNodesNative.ImNodes_MiniMap(minimapSizeFraction, location, nodeHoveringCallback, nodeHoveringCallbackData);
        }

        /// <summary>
        ///     Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimapSizeFraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        /// <param name="nodeHoveringCallback">The node hovering callback</param>
        public static void MiniMap(float minimapSizeFraction, ImNodesMiniMapLocation location, ImNodesMiniMapNodeHoveringCallback nodeHoveringCallback)
        {
            ImNodesMiniMapNodeHoveringCallbackUserData nodeHoveringCallbackData = null;
            ImNodesNative.ImNodes_MiniMap(minimapSizeFraction, location, nodeHoveringCallback, nodeHoveringCallbackData);
        }

        /// <summary>
        ///     Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimapSizeFraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        /// <param name="nodeHoveringCallback">The node hovering callback</param>
        /// <param name="nodeHoveringCallbackData">The node hovering callback data</param>
        public static void MiniMap(float minimapSizeFraction, ImNodesMiniMapLocation location, ImNodesMiniMapNodeHoveringCallback nodeHoveringCallback, ImNodesMiniMapNodeHoveringCallbackUserData nodeHoveringCallbackData)
        {
            ImNodesNative.ImNodes_MiniMap(minimapSizeFraction, location, nodeHoveringCallback, nodeHoveringCallbackData);
        }

        /// <summary>
        ///     Nums the selected links
        /// </summary>
        /// <returns>The ret</returns>
        public static int NumSelectedLinks()
        {
            int ret = ImNodesNative.ImNodes_NumSelectedLinks();
            return ret;
        }

        /// <summary>
        ///     Nums the selected nodes
        /// </summary>
        /// <returns>The ret</returns>
        public static int NumSelectedNodes()
        {
            int ret = ImNodesNative.ImNodes_NumSelectedNodes();
            return ret;
        }

        /// <summary>
        ///     Pops the attribute flag
        /// </summary>
        public static void PopAttributeFlag()
        {
            ImNodesNative.ImNodes_PopAttributeFlag();
        }

        /// <summary>
        ///     Pops the color style
        /// </summary>
        public static void PopColorStyle()
        {
            ImNodesNative.ImNodes_PopColorStyle();
        }

        /// <summary>
        ///     Pops the style var
        /// </summary>
        public static void PopStyleVar()
        {
            int count = 1;
            ImNodesNative.ImNodes_PopStyleVar(count);
        }

        /// <summary>
        ///     Pops the style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleVar(int count)
        {
            ImNodesNative.ImNodes_PopStyleVar(count);
        }

        /// <summary>
        ///     Pushes the attribute flag using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        public static void PushAttributeFlag(ImNodesConfig flag)
        {
            ImNodesNative.ImNodes_PushAttributeFlag(flag);
        }

        /// <summary>
        ///     Pushes the color style using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="color">The color</param>
        public static void PushColorStyle(ImNodesCol item, uint color)
        {
            ImNodesNative.ImNodes_PushColorStyle(item, color);
        }

        /// <summary>
        ///     Pushes the style var using the specified style item
        /// </summary>
        /// <param name="styleItem">The style item</param>
        /// <param name="value">The value</param>
        public static void PushStyleVar(ImNodesStyleVar styleItem, float value)
        {
            ImNodesNative.ImNodes_PushStyleVar_Float(styleItem, value);
        }

        /// <summary>
        ///     Pushes the style var using the specified style item
        /// </summary>
        /// <param name="styleItem">The style item</param>
        /// <param name="value">The value</param>
        public static void PushStyleVar(ImNodesStyleVar styleItem, Vector2 value)
        {
            ImNodesNative.ImNodes_PushStyleVar_Vec2(styleItem, value);
        }

        /// <summary>
        ///     Saves the current editor state to ini file using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        public static void SaveCurrentEditorStateToIniFile(string fileName)
        {
            if (fileName != null)
            {
                byte[] nativeFileName = Encoding.UTF8.GetBytes(fileName);
                ImNodesNative.ImNodes_SaveCurrentEditorStateToIniFile(nativeFileName);
            }
            else
            {
                ImNodesNative.ImNodes_SaveCurrentEditorStateToIniFile(null);
            }
        }

        /// <summary>
        ///     Saves the current editor state to ini string
        /// </summary>
        /// <returns>The string</returns>
        public static string SaveCurrentEditorStateToIniString()
        {
            uint dataSize = 0;
            GCHandle gch = GCHandle.Alloc(dataSize, GCHandleType.Pinned);
            try
            {
                IntPtr dataSizePtr = gch.AddrOfPinnedObject();
                byte[] ret = ImNodesNative.ImNodes_SaveCurrentEditorStateToIniString(dataSizePtr);
                return Encoding.UTF8.GetString(ret);
            }
            finally
            {
                gch.Free();
            }
        }

        /// <summary>
        ///     Saves the current editor state to ini string using the specified data size
        /// </summary>
        /// <param name="dataSize">The data size</param>
        /// <returns>The string</returns>
        public static string SaveCurrentEditorStateToIniString(ref uint dataSize)
        {
            GCHandle gch = GCHandle.Alloc(dataSize, GCHandleType.Pinned);
            try
            {
                IntPtr dataSizePtr = gch.AddrOfPinnedObject();
                byte[] ret = ImNodesNative.ImNodes_SaveCurrentEditorStateToIniString(dataSizePtr);
                return Encoding.UTF8.GetString(ret);
            }
            finally
            {
                gch.Free();
            }
        }

        /// <summary>
        ///     Saves the editor state to ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="fileName">The file name</param>
        public static void SaveEditorStateToIniFile(ImNodesEditorContext editor, string fileName)
        {
            if (fileName != null)
            {
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
                ImNodesNative.ImNodes_SaveEditorStateToIniFile(editor, fileNameBytes);
            }
            else
            {
                ImNodesNative.ImNodes_SaveEditorStateToIniFile(editor, null);
            }
        }

        /// <summary>
        ///     Saves the editor state to ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <returns>The string</returns>
        public static string SaveEditorStateToIniString(ImNodesEditorContext editor)
        {
            byte[] ret = ImNodesNative.ImNodes_SaveEditorStateToIniString(editor, 0);
            // transform byte array to string
            return Encoding.UTF8.GetString(ret);
        }

        /// <summary>
        ///     Saves the editor state to ini string using the specified native editor
        /// </summary>
        /// <param name="nativeEditor">The native editor</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The string</returns>
        public static string SaveEditorStateToIniString(ImNodesEditorContext nativeEditor, ref uint dataSize)
        {
            byte[] ret = ImNodesNative.ImNodes_SaveEditorStateToIniString(nativeEditor, dataSize);
            // transform byte array to string
            return Encoding.UTF8.GetString(ret);
        }

        /// <summary>
        ///     Selects the link using the specified link id
        /// </summary>
        /// <param name="linkId">The link id</param>
        public static void SelectLink(int linkId)
        {
            ImNodesNative.ImNodes_SelectLink(linkId);
        }

        /// <summary>
        ///     Selects the node using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        public static void SelectNode(int nodeId)
        {
            ImNodesNative.ImNodes_SelectNode(nodeId);
        }

        /// <summary>
        ///     Sets the current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetCurrentContext(ImNodesContext ctx)
        {
            ImNodesNative.ImNodes_SetCurrentContext(ctx);
        }

        /// <summary>
        ///     Sets the im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetImGuiContext(IntPtr ctx)
        {
            ImNodesNative.ImNodes_SetImGuiContext(ctx);
        }

        /// <summary>
        ///     Sets the node draggable using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="draggable">The draggable</param>
        public static void SetNodeDraggable(int nodeId, bool draggable)
        {
            byte nativeDraggable = draggable ? (byte) 1 : (byte) 0;
            ImNodesNative.ImNodes_SetNodeDraggable(nodeId, nativeDraggable);
        }

        /// <summary>
        ///     Sets the node editor space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="editorSpacePos">The editor space pos</param>
        public static void SetNodeEditorSpacePos(int nodeId, Vector2 editorSpacePos)
        {
            ImNodesNative.ImNodes_SetNodeEditorSpacePos(nodeId, editorSpacePos);
        }

        /// <summary>
        ///     Sets the node grid space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="gridPos">The grid pos</param>
        public static void SetNodeGridSpacePos(int nodeId, Vector2 gridPos)
        {
            ImNodesNative.ImNodes_SetNodeGridSpacePos(nodeId, gridPos);
        }

        /// <summary>
        ///     Sets the node screen space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="screenSpacePos">The screen space pos</param>
        public static void SetNodeScreenSpacePos(int nodeId, Vector2 screenSpacePos)
        {
            ImNodesNative.ImNodes_SetNodeScreenSpacePos(nodeId, screenSpacePos);
        }

        /// <summary>
        ///     Snaps the node to grid using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        public static void SnapNodeToGrid(int nodeId)
        {
            ImNodesNative.ImNodes_SnapNodeToGrid(nodeId);
        }

        /// <summary>
        ///     Styles the colors classic
        /// </summary>
        public static void StyleColorsClassic()
        {
            ImNodesNative.ImNodes_StyleColorsClassic(new ImNodesStyle());
        }

        /// <summary>
        ///     Styles the colors classic using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsClassic(ImNodesStyle dest)
        {
            ImNodesNative.ImNodes_StyleColorsClassic(dest);
        }

        /// <summary>
        ///     Styles the colors dark
        /// </summary>
        public static void StyleColorsDark()
        {
            ImNodesNative.ImNodes_StyleColorsDark(new ImNodesStyle());
        }

        /// <summary>
        ///     Styles the colors dark using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsDark(ImNodesStyle dest)
        {
            ImNodesNative.ImNodes_StyleColorsDark(dest);
        }

        /// <summary>
        ///     Styles the colors light
        /// </summary>
        public static void StyleColorsLight()
        {
            ImNodesNative.ImNodes_StyleColorsLight(new ImNodesStyle());
        }

        /// <summary>
        ///     Styles the colors light using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsLight(ImNodesStyle dest)
        {
            ImNodesNative.ImNodes_StyleColorsLight(dest);
        }
    }
}