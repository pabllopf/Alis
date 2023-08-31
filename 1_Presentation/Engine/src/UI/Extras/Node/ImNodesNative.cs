// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesNative.cs
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

namespace Alis.Core.Graphic.UI.Extras.Node
{
    /// <summary>
    ///     The imnodes native class
    /// </summary>
    public static unsafe class ImNodesNative
    {
        /// <summary>
        ///     Emulates the three button mouse destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void EmulateThreeButtonMouse_destroy(EmulateThreeButtonMouse* self);

        /// <summary>
        ///     Emulates the three button mouse emulate three button mouse
        /// </summary>
        /// <returns>The emulate three button mouse</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern EmulateThreeButtonMouse* EmulateThreeButtonMouse_EmulateThreeButtonMouse();

        /// <summary>
        ///     Ims the nodes begin input attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginInputAttribute(int id, ImNodesPinShape shape);

        /// <summary>
        ///     Ims the nodes begin node using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginNode(int id);

        /// <summary>
        ///     Ims the nodes begin node editor
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginNodeEditor();

        /// <summary>
        ///     Ims the nodes begin node title bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginNodeTitleBar();

        /// <summary>
        ///     Ims the nodes begin output attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginOutputAttribute(int id, ImNodesPinShape shape);

        /// <summary>
        ///     Ims the nodes begin static attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginStaticAttribute(int id);

        /// <summary>
        ///     Ims the nodes clear link selection nil
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearLinkSelection_Nil();

        /// <summary>
        ///     Ims the nodes clear link selection int using the specified link id
        /// </summary>
        /// <param name="linkId">The link id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearLinkSelection_Int(int linkId);

        /// <summary>
        ///     Ims the nodes clear node selection nil
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearNodeSelection_Nil();

        /// <summary>
        ///     Ims the nodes clear node selection int using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearNodeSelection_Int(int nodeId);

        /// <summary>
        ///     Ims the nodes create context
        /// </summary>
        /// <returns>The im nodes context</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesContext* ImNodes_CreateContext();

        /// <summary>
        ///     Ims the nodes destroy context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_DestroyContext(ImNodesContext* ctx);

        /// <summary>
        ///     Ims the nodes editor context create
        /// </summary>
        /// <returns>The im nodes editor context</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesEditorContext* ImNodes_EditorContextCreate();

        /// <summary>
        ///     Ims the nodes editor context free using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextFree(ImNodesEditorContext* noname1);

        /// <summary>
        ///     Ims the nodes editor context get panning using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextGetPanning(Vector2* pOut);

        /// <summary>
        ///     Ims the nodes editor context move to node using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextMoveToNode(int nodeId);

        /// <summary>
        ///     Ims the nodes editor context reset panning using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextResetPanning(Vector2 pos);

        /// <summary>
        ///     Ims the nodes editor context set using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextSet(ImNodesEditorContext* noname1);

        /// <summary>
        ///     Ims the nodes end input attribute
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndInputAttribute();

        /// <summary>
        ///     Ims the nodes end node
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndNode();

        /// <summary>
        ///     Ims the nodes end node editor
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndNodeEditor();

        /// <summary>
        ///     Ims the nodes end node title bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndNodeTitleBar();

        /// <summary>
        ///     Ims the nodes end output attribute
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndOutputAttribute();

        /// <summary>
        ///     Ims the nodes end static attribute
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndStaticAttribute();

        /// <summary>
        ///     Ims the nodes get current context
        /// </summary>
        /// <returns>The im nodes context</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesContext* ImNodes_GetCurrentContext();

        /// <summary>
        ///     Ims the nodes get io
        /// </summary>
        /// <returns>The im nodes io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesIo* ImNodes_GetIO();

        /// <summary>
        ///     Ims the nodes get node dimensions using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeDimensions(Vector2* pOut, int id);

        /// <summary>
        ///     Ims the nodes get node editor space pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="nodeId">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeEditorSpacePos(Vector2* pOut, int nodeId);

        /// <summary>
        ///     Ims the nodes get node grid space pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="nodeId">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeGridSpacePos(Vector2* pOut, int nodeId);

        /// <summary>
        ///     Ims the nodes get node screen space pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="nodeId">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeScreenSpacePos(Vector2* pOut, int nodeId);

        /// <summary>
        ///     Ims the nodes get selected links using the specified link ids
        /// </summary>
        /// <param name="linkIds">The link ids</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetSelectedLinks(int* linkIds);

        /// <summary>
        ///     Ims the nodes get selected nodes using the specified node ids
        /// </summary>
        /// <param name="nodeIds">The node ids</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetSelectedNodes(int* nodeIds);

        /// <summary>
        ///     Ims the nodes get style
        /// </summary>
        /// <returns>The im nodes style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesStyle* ImNodes_GetStyle();

        /// <summary>
        ///     Ims the nodes is any attribute active using the specified attribute id
        /// </summary>
        /// <param name="attributeId">The attribute id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsAnyAttributeActive(int* attributeId);

        /// <summary>
        ///     Ims the nodes is attribute active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsAttributeActive();

        /// <summary>
        ///     Ims the nodes is editor hovered
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsEditorHovered();

        /// <summary>
        ///     Ims the nodes is link created bool ptr using the specified started at attribute id
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="endedAtAttributeId">The ended at attribute id</param>
        /// <param name="createdFromSnap">The created from snap</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkCreated_BoolPtr(int* startedAtAttributeId, int* endedAtAttributeId, byte* createdFromSnap);

        /// <summary>
        ///     Ims the nodes is link created int ptr using the specified started at node id
        /// </summary>
        /// <param name="startedAtNodeId">The started at node id</param>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="endedAtNodeId">The ended at node id</param>
        /// <param name="endedAtAttributeId">The ended at attribute id</param>
        /// <param name="createdFromSnap">The created from snap</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkCreated_IntPtr(int* startedAtNodeId, int* startedAtAttributeId, int* endedAtNodeId, int* endedAtAttributeId, byte* createdFromSnap);

        /// <summary>
        ///     Ims the nodes is link destroyed using the specified link id
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkDestroyed(int* linkId);

        /// <summary>
        ///     Ims the nodes is link dropped using the specified started at attribute id
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <param name="includingDetachedLinks">The including detached links</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkDropped(int* startedAtAttributeId, byte includingDetachedLinks);

        /// <summary>
        ///     Ims the nodes is link hovered using the specified link id
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkHovered(int* linkId);

        /// <summary>
        ///     Ims the nodes is link selected using the specified link id
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkSelected(int linkId);

        /// <summary>
        ///     Ims the nodes is link started using the specified started at attribute id
        /// </summary>
        /// <param name="startedAtAttributeId">The started at attribute id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkStarted(int* startedAtAttributeId);

        /// <summary>
        ///     Ims the nodes is node hovered using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsNodeHovered(int* nodeId);

        /// <summary>
        ///     Ims the nodes is node selected using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsNodeSelected(int nodeId);

        /// <summary>
        ///     Ims the nodes is pin hovered using the specified attribute id
        /// </summary>
        /// <param name="attributeId">The attribute id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsPinHovered(int* attributeId);

        /// <summary>
        ///     Ims the nodes link using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="startAttributeId">The start attribute id</param>
        /// <param name="endAttributeId">The end attribute id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_Link(int id, int startAttributeId, int endAttributeId);

        /// <summary>
        ///     Ims the nodes load current editor state from ini file using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadCurrentEditorStateFromIniFile(byte* fileName);

        /// <summary>
        ///     Ims the nodes load current editor state from ini string using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="dataSize">The data size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadCurrentEditorStateFromIniString(byte* data, uint dataSize);

        /// <summary>
        ///     Ims the nodes load editor state from ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="fileName">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadEditorStateFromIniFile(ImNodesEditorContext* editor, byte* fileName);

        /// <summary>
        ///     Ims the nodes load editor state from ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="data">The data</param>
        /// <param name="dataSize">The data size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadEditorStateFromIniString(ImNodesEditorContext* editor, byte* data, uint dataSize);

        /// <summary>
        ///     Ims the nodes mini map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimapSizeFraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        /// <param name="nodeHoveringCallback">The node hovering callback</param>
        /// <param name="nodeHoveringCallbackData">The node hovering callback data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_MiniMap(float minimapSizeFraction, ImNodesMiniMapLocation location, ImNodesMiniMapNodeHoveringCallback nodeHoveringCallback, ImNodesMiniMapNodeHoveringCallbackUserData nodeHoveringCallbackData);

        /// <summary>
        ///     Ims the nodes num selected links
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImNodes_NumSelectedLinks();

        /// <summary>
        ///     Ims the nodes num selected nodes
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImNodes_NumSelectedNodes();

        /// <summary>
        ///     Ims the nodes pop attribute flag
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PopAttributeFlag();

        /// <summary>
        ///     Ims the nodes pop color style
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PopColorStyle();

        /// <summary>
        ///     Ims the nodes pop style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PopStyleVar(int count);

        /// <summary>
        ///     Ims the nodes push attribute flag using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushAttributeFlag(ImNodesAttributeFlags flag);

        /// <summary>
        ///     Ims the nodes push color style using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="color">The color</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushColorStyle(ImNodesCol item, uint color);

        /// <summary>
        ///     Ims the nodes push style var float using the specified style item
        /// </summary>
        /// <param name="styleItem">The style item</param>
        /// <param name="value">The value</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushStyleVar_Float(ImNodesStyleVar styleItem, float value);

        /// <summary>
        ///     Ims the nodes push style var vec 2 using the specified style item
        /// </summary>
        /// <param name="styleItem">The style item</param>
        /// <param name="value">The value</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushStyleVar_Vec2(ImNodesStyleVar styleItem, Vector2 value);

        /// <summary>
        ///     Ims the nodes save current editor state to ini file using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SaveCurrentEditorStateToIniFile(byte* fileName);

        /// <summary>
        ///     Ims the nodes save current editor state to ini string using the specified data size
        /// </summary>
        /// <param name="dataSize">The data size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImNodes_SaveCurrentEditorStateToIniString(uint* dataSize);

        /// <summary>
        ///     Ims the nodes save editor state to ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="fileName">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SaveEditorStateToIniFile(ImNodesEditorContext* editor, byte* fileName);

        /// <summary>
        ///     Ims the nodes save editor state to ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImNodes_SaveEditorStateToIniString(ImNodesEditorContext* editor, uint* dataSize);

        /// <summary>
        ///     Ims the nodes select link using the specified link id
        /// </summary>
        /// <param name="linkId">The link id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SelectLink(int linkId);

        /// <summary>
        ///     Ims the nodes select node using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SelectNode(int nodeId);

        /// <summary>
        ///     Ims the nodes set current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetCurrentContext(ImNodesContext* ctx);

        /// <summary>
        ///     Ims the nodes set im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetImGuiContext(IntPtr ctx);

        /// <summary>
        ///     Ims the nodes set node draggable using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="draggable">The draggable</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeDraggable(int nodeId, byte draggable);

        /// <summary>
        ///     Ims the nodes set node editor space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="editorSpacePos">The editor space pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeEditorSpacePos(int nodeId, Vector2 editorSpacePos);

        /// <summary>
        ///     Ims the nodes set node grid space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="gridPos">The grid pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeGridSpacePos(int nodeId, Vector2 gridPos);

        /// <summary>
        ///     Ims the nodes set node screen space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <param name="screenSpacePos">The screen space pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeScreenSpacePos(int nodeId, Vector2 screenSpacePos);

        /// <summary>
        ///     Ims the nodes snap node to grid using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SnapNodeToGrid(int nodeId);

        /// <summary>
        ///     Ims the nodes style colors classic using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_StyleColorsClassic(ImNodesStyle* dest);

        /// <summary>
        ///     Ims the nodes style colors dark using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_StyleColorsDark(ImNodesStyle* dest);

        /// <summary>
        ///     Ims the nodes style colors light using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_StyleColorsLight(ImNodesStyle* dest);

        /// <summary>
        ///     Ims the nodes io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodesIO_destroy(ImNodesIo* self);

        /// <summary>
        ///     Ims the nodes io im nodes io
        /// </summary>
        /// <returns>The im nodes io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesIo* ImNodesIO_ImNodesIO();

        /// <summary>
        ///     Ims the nodes style destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodesStyle_destroy(ImNodesStyle* self);

        /// <summary>
        ///     Ims the nodes style im nodes style
        /// </summary>
        /// <returns>The im nodes style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesStyle* ImNodesStyle_ImNodesStyle();

        /// <summary>
        ///     Links the detach with modifier click destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LinkDetachWithModifierClick_destroy(LinkDetachWithModifierClick* self);

        /// <summary>
        ///     Links the detach with modifier click link detach with modifier click
        /// </summary>
        /// <returns>The link detach with modifier click</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern LinkDetachWithModifierClick* LinkDetachWithModifierClick_LinkDetachWithModifierClick();

        /// <summary>
        ///     Multiples the select modifier destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MultipleSelectModifier_destroy(MultipleSelectModifier* self);

        /// <summary>
        ///     Multiples the select modifier multiple select modifier
        /// </summary>
        /// <returns>The multiple select modifier</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern MultipleSelectModifier* MultipleSelectModifier_MultipleSelectModifier();
    }
}