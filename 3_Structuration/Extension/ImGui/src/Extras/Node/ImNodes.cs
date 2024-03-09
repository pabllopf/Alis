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
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.App.Engine.UI.Extras.Node
{
    /// <summary>
    ///     The im nodes class
    /// </summary>
    public static unsafe class ImNodes
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
        public static ImNodesContextPtr CreateContext()
        {
            ImNodesContext* ret = ImNodesNative.ImNodes_CreateContext();
            return new ImNodesContextPtr(ret);
        }

        /// <summary>
        ///     Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            ImNodesContext* ctx = null;
            ImNodesNative.ImNodes_DestroyContext(ctx);
        }

        /// <summary>
        ///     Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(ImNodesContextPtr ctx)
        {
            ImNodesContext* nativeCtx = ctx.NativePtr;
            ImNodesNative.ImNodes_DestroyContext(nativeCtx);
        }

        /// <summary>
        ///     Editors the context create
        /// </summary>
        /// <returns>The im nodes editor context ptr</returns>
        public static ImNodesEditorContextPtr EditorContextCreate()
        {
            ImNodesEditorContext* ret = ImNodesNative.ImNodes_EditorContextCreate();
            return new ImNodesEditorContextPtr(ret);
        }

        /// <summary>
        ///     Editors the context free using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        public static void EditorContextFree(ImNodesEditorContextPtr noname1)
        {
            ImNodesEditorContext* nativeNoname1 = noname1.NativePtr;
            ImNodesNative.ImNodes_EditorContextFree(nativeNoname1);
        }

        /// <summary>
        ///     Editors the context get panning
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 EditorContextGetPanning()
        {
            Vector2 retval;
            ImNodesNative.ImNodes_EditorContextGetPanning(&retval);
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
        public static void EditorContextSet(ImNodesEditorContextPtr noname1)
        {
            ImNodesEditorContext* nativeNoname1 = noname1.NativePtr;
            ImNodesNative.ImNodes_EditorContextSet(nativeNoname1);
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
        public static ImNodesContextPtr GetCurrentContext()
        {
            ImNodesContext* ret = ImNodesNative.ImNodes_GetCurrentContext();
            return new ImNodesContextPtr(ret);
        }

        /// <summary>
        ///     Gets the io
        /// </summary>
        /// <returns>The im nodes io ptr</returns>
        public static ImNodesIoPtr GetIo()
        {
            ImNodesIo* ret = ImNodesNative.ImNodes_GetIO();
            return new ImNodesIoPtr(ret);
        }

        /// <summary>
        ///     Gets the node dimensions using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeDimensions(int id)
        {
            Vector2 retval;
            ImNodesNative.ImNodes_GetNodeDimensions(&retval, id);
            return retval;
        }

        /// <summary>
        ///     Gets the node editor space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeEditorSpacePos(int nodeId)
        {
            Vector2 retval;
            ImNodesNative.ImNodes_GetNodeEditorSpacePos(&retval, nodeId);
            return retval;
        }

        /// <summary>
        ///     Gets the node grid space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeGridSpacePos(int nodeId)
        {
            Vector2 retval;
            ImNodesNative.ImNodes_GetNodeGridSpacePos(&retval, nodeId);
            return retval;
        }

        /// <summary>
        ///     Gets the node screen space pos using the specified node id
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeScreenSpacePos(int nodeId)
        {
            Vector2 retval;
            ImNodesNative.ImNodes_GetNodeScreenSpacePos(&retval, nodeId);
            return retval;
        }

        /// <summary>
        ///     Gets the selected links using the specified link ids
        /// </summary>
        /// <param name="linkIds">The link ids</param>
        public static void GetSelectedLinks(ref int linkIds)
        {
            fixed (int* nativeLinkIds = &linkIds)
            {
                ImNodesNative.ImNodes_GetSelectedLinks(nativeLinkIds);
            }
        }

        /// <summary>
        ///     Gets the selected nodes using the specified node ids
        /// </summary>
        /// <param name="nodeIds">The node ids</param>
        public static void GetSelectedNodes(ref int nodeIds)
        {
            fixed (int* nativeNodeIds = &nodeIds)
            {
                ImNodesNative.ImNodes_GetSelectedNodes(nativeNodeIds);
            }
        }

        /// <summary>
        ///     Gets the style
        /// </summary>
        /// <returns>The im nodes style ptr</returns>
        public static ImNodesStylePtr GetStyle()
        {
            ImNodesStyle* ret = ImNodesNative.ImNodes_GetStyle();
            return new ImNodesStylePtr(ret);
        }

        /// <summary>
        ///     Describes whether is any attribute active
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAnyAttributeActive()
        {
            int* attributeId = null;
            byte ret = ImNodesNative.ImNodes_IsAnyAttributeActive(attributeId);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether is any attribute active
        /// </summary>
        /// <param name="attributeId">The attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsAnyAttributeActive(ref int attributeId)
        {
            fixed (int* nativeAttributeId = &attributeId)
            {
                byte ret = ImNodesNative.ImNodes_IsAnyAttributeActive(nativeAttributeId);
                return ret != 0;
            }
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
            byte* createdFromSnap = null;
            fixed (int* nativeStartedAtAttributeId = &startedAtAttributeId)
            {
                fixed (int* nativeEndedAtAttributeId = &endedAtAttributeId)
                {
                    byte ret = ImNodesNative.ImNodes_IsLinkCreated_BoolPtr(nativeStartedAtAttributeId, nativeEndedAtAttributeId, createdFromSnap);
                    return ret != 0;
                }
            }
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
            byte nativeCreatedFromSnapVal = createdFromSnap ? (byte) 1 : (byte) 0;
            byte* nativeCreatedFromSnap = &nativeCreatedFromSnapVal;
            fixed (int* nativeStartedAtAttributeId = &startedAtAttributeId)
            {
                fixed (int* nativeEndedAtAttributeId = &endedAtAttributeId)
                {
                    byte ret = ImNodesNative.ImNodes_IsLinkCreated_BoolPtr(nativeStartedAtAttributeId, nativeEndedAtAttributeId, nativeCreatedFromSnap);
                    createdFromSnap = nativeCreatedFromSnapVal != 0;
                    return ret != 0;
                }
            }
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
            byte* createdFromSnap = null;
            fixed (int* nativeStartedAtNodeId = &startedAtNodeId)
            {
                fixed (int* nativeStartedAtAttributeId = &startedAtAttributeId)
                {
                    fixed (int* nativeEndedAtNodeId = &endedAtNodeId)
                    {
                        fixed (int* nativeEndedAtAttributeId = &endedAtAttributeId)
                        {
                            byte ret = ImNodesNative.ImNodes_IsLinkCreated_IntPtr(nativeStartedAtNodeId, nativeStartedAtAttributeId, nativeEndedAtNodeId, nativeEndedAtAttributeId, createdFromSnap);
                            return ret != 0;
                        }
                    }
                }
            }
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
            byte* nativeCreatedFromSnap = &nativeCreatedFromSnapVal;
            fixed (int* nativeStartedAtNodeId = &startedAtNodeId)
            {
                fixed (int* nativeStartedAtAttributeId = &startedAtAttributeId)
                {
                    fixed (int* nativeEndedAtNodeId = &endedAtNodeId)
                    {
                        fixed (int* nativeEndedAtAttributeId = &endedAtAttributeId)
                        {
                            byte ret = ImNodesNative.ImNodes_IsLinkCreated_IntPtr(nativeStartedAtNodeId, nativeStartedAtAttributeId, nativeEndedAtNodeId, nativeEndedAtAttributeId, nativeCreatedFromSnap);
                            createdFromSnap = nativeCreatedFromSnapVal != 0;
                            return ret != 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Describes whether is link destroyed
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkDestroyed(ref int linkId)
        {
            fixed (int* nativeLinkId = &linkId)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkDestroyed(nativeLinkId);
                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether is link dropped
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsLinkDropped()
        {
            int* startedAtAttributeId = null;
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
            fixed (int* nativeStartedAtAttributeId = &startedAtAttributeId)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkDropped(nativeStartedAtAttributeId, includingDetachedLinks);
                return ret != 0;
            }
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
            fixed (int* nativeStartedAtAttributeId = &startedAtAttributeId)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkDropped(nativeStartedAtAttributeId, nativeIncludingDetachedLinks);
                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether is link hovered
        /// </summary>
        /// <param name="linkId">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkHovered(ref int linkId)
        {
            fixed (int* nativeLinkId = &linkId)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkHovered(nativeLinkId);
                return ret != 0;
            }
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
            fixed (int* nativeStartedAtAttributeId = &startedAtAttributeId)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkStarted(nativeStartedAtAttributeId);
                return ret != 0;
            }
        }

        /// <summary>
        ///     Describes whether is node hovered
        /// </summary>
        /// <param name="nodeId">The node id</param>
        /// <returns>The bool</returns>
        public static bool IsNodeHovered(ref int nodeId)
        {
            fixed (int* nativeNodeId = &nodeId)
            {
                byte ret = ImNodesNative.ImNodes_IsNodeHovered(nativeNodeId);
                return ret != 0;
            }
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
            fixed (int* nativeAttributeId = &attributeId)
            {
                byte ret = ImNodesNative.ImNodes_IsPinHovered(nativeAttributeId);
                return ret != 0;
            }
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
            byte* nativeFileName;
            int fileNameByteCount = 0;
            if (fileName != null)
            {
                fileNameByteCount = Encoding.UTF8.GetByteCount(fileName);
                if (fileNameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFileName = Util.Allocate(fileNameByteCount + 1);
                }
                else
                {
                    byte* nativeFileNameStackBytes = stackalloc byte[fileNameByteCount + 1];
                    nativeFileName = nativeFileNameStackBytes;
                }

                int nativeFileNameOffset = Util.GetUtf8(fileName, nativeFileName, fileNameByteCount);
                nativeFileName[nativeFileNameOffset] = 0;
            }
            else
            {
                nativeFileName = null;
            }

            ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniFile(nativeFileName);
            if (fileNameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFileName);
            }
        }

        /// <summary>
        ///     Loads the current editor state from ini string using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="dataSize">The data size</param>
        public static void LoadCurrentEditorStateFromIniString(string data, uint dataSize)
        {
            byte* nativeData;
            int dataByteCount = 0;
            if (data != null)
            {
                dataByteCount = Encoding.UTF8.GetByteCount(data);
                if (dataByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeData = Util.Allocate(dataByteCount + 1);
                }
                else
                {
                    byte* nativeDataStackBytes = stackalloc byte[dataByteCount + 1];
                    nativeData = nativeDataStackBytes;
                }

                int nativeDataOffset = Util.GetUtf8(data, nativeData, dataByteCount);
                nativeData[nativeDataOffset] = 0;
            }
            else
            {
                nativeData = null;
            }

            ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniString(nativeData, dataSize);
            if (dataByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeData);
            }
        }

        /// <summary>
        ///     Loads the editor state from ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="fileName">The file name</param>
        public static void LoadEditorStateFromIniFile(ImNodesEditorContextPtr editor, string fileName)
        {
            ImNodesEditorContext* nativeEditor = editor.NativePtr;
            byte* nativeFileName;
            int fileNameByteCount = 0;
            if (fileName != null)
            {
                fileNameByteCount = Encoding.UTF8.GetByteCount(fileName);
                if (fileNameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFileName = Util.Allocate(fileNameByteCount + 1);
                }
                else
                {
                    byte* nativeFileNameStackBytes = stackalloc byte[fileNameByteCount + 1];
                    nativeFileName = nativeFileNameStackBytes;
                }

                int nativeFileNameOffset = Util.GetUtf8(fileName, nativeFileName, fileNameByteCount);
                nativeFileName[nativeFileNameOffset] = 0;
            }
            else
            {
                nativeFileName = null;
            }

            ImNodesNative.ImNodes_LoadEditorStateFromIniFile(nativeEditor, nativeFileName);
            if (fileNameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFileName);
            }
        }

        /// <summary>
        ///     Loads the editor state from ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="data">The data</param>
        /// <param name="dataSize">The data size</param>
        public static void LoadEditorStateFromIniString(ImNodesEditorContextPtr editor, string data, uint dataSize)
        {
            ImNodesEditorContext* nativeEditor = editor.NativePtr;
            byte* nativeData;
            int dataByteCount = 0;
            if (data != null)
            {
                dataByteCount = Encoding.UTF8.GetByteCount(data);
                if (dataByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeData = Util.Allocate(dataByteCount + 1);
                }
                else
                {
                    byte* nativeDataStackBytes = stackalloc byte[dataByteCount + 1];
                    nativeData = nativeDataStackBytes;
                }

                int nativeDataOffset = Util.GetUtf8(data, nativeData, dataByteCount);
                nativeData[nativeDataOffset] = 0;
            }
            else
            {
                nativeData = null;
            }

            ImNodesNative.ImNodes_LoadEditorStateFromIniString(nativeEditor, nativeData, dataSize);
            if (dataByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeData);
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
        public static void PushAttributeFlag(ImNodesAttribute flag)
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
            byte* nativeFileName;
            int fileNameByteCount = 0;
            if (fileName != null)
            {
                fileNameByteCount = Encoding.UTF8.GetByteCount(fileName);
                if (fileNameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFileName = Util.Allocate(fileNameByteCount + 1);
                }
                else
                {
                    byte* nativeFileNameStackBytes = stackalloc byte[fileNameByteCount + 1];
                    nativeFileName = nativeFileNameStackBytes;
                }

                int nativeFileNameOffset = Util.GetUtf8(fileName, nativeFileName, fileNameByteCount);
                nativeFileName[nativeFileNameOffset] = 0;
            }
            else
            {
                nativeFileName = null;
            }

            ImNodesNative.ImNodes_SaveCurrentEditorStateToIniFile(nativeFileName);
            if (fileNameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFileName);
            }
        }

        /// <summary>
        ///     Saves the current editor state to ini string
        /// </summary>
        /// <returns>The string</returns>
        public static string SaveCurrentEditorStateToIniString()
        {
            uint* dataSize = null;
            byte* ret = ImNodesNative.ImNodes_SaveCurrentEditorStateToIniString(dataSize);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Saves the current editor state to ini string using the specified data size
        /// </summary>
        /// <param name="dataSize">The data size</param>
        /// <returns>The string</returns>
        public static string SaveCurrentEditorStateToIniString(ref uint dataSize)
        {
            fixed (uint* nativeDataSize = &dataSize)
            {
                byte* ret = ImNodesNative.ImNodes_SaveCurrentEditorStateToIniString(nativeDataSize);
                return Util.StringFromPtr(ret);
            }
        }

        /// <summary>
        ///     Saves the editor state to ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="fileName">The file name</param>
        public static void SaveEditorStateToIniFile(ImNodesEditorContextPtr editor, string fileName)
        {
            ImNodesEditorContext* nativeEditor = editor.NativePtr;
            byte* nativeFileName;
            int fileNameByteCount = 0;
            if (fileName != null)
            {
                fileNameByteCount = Encoding.UTF8.GetByteCount(fileName);
                if (fileNameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFileName = Util.Allocate(fileNameByteCount + 1);
                }
                else
                {
                    byte* nativeFileNameStackBytes = stackalloc byte[fileNameByteCount + 1];
                    nativeFileName = nativeFileNameStackBytes;
                }

                int nativeFileNameOffset = Util.GetUtf8(fileName, nativeFileName, fileNameByteCount);
                nativeFileName[nativeFileNameOffset] = 0;
            }
            else
            {
                nativeFileName = null;
            }

            ImNodesNative.ImNodes_SaveEditorStateToIniFile(nativeEditor, nativeFileName);
            if (fileNameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFileName);
            }
        }

        /// <summary>
        ///     Saves the editor state to ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <returns>The string</returns>
        public static string SaveEditorStateToIniString(ImNodesEditorContextPtr editor)
        {
            ImNodesEditorContext* nativeEditor = editor.NativePtr;
            uint* dataSize = null;
            byte* ret = ImNodesNative.ImNodes_SaveEditorStateToIniString(nativeEditor, dataSize);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Saves the editor state to ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The string</returns>
        public static string SaveEditorStateToIniString(ImNodesEditorContextPtr editor, ref uint dataSize)
        {
            ImNodesEditorContext* nativeEditor = editor.NativePtr;
            fixed (uint* nativeDataSize = &dataSize)
            {
                byte* ret = ImNodesNative.ImNodes_SaveEditorStateToIniString(nativeEditor, nativeDataSize);
                return Util.StringFromPtr(ret);
            }
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
        public static void SetCurrentContext(ImNodesContextPtr ctx)
        {
            ImNodesContext* nativeCtx = ctx.NativePtr;
            ImNodesNative.ImNodes_SetCurrentContext(nativeCtx);
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
            ImNodesStyle* dest = null;
            ImNodesNative.ImNodes_StyleColorsClassic(dest);
        }

        /// <summary>
        ///     Styles the colors classic using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsClassic(ImNodesStylePtr dest)
        {
            ImNodesStyle* nativeDest = dest.NativePtr;
            ImNodesNative.ImNodes_StyleColorsClassic(nativeDest);
        }

        /// <summary>
        ///     Styles the colors dark
        /// </summary>
        public static void StyleColorsDark()
        {
            ImNodesStyle* dest = null;
            ImNodesNative.ImNodes_StyleColorsDark(dest);
        }

        /// <summary>
        ///     Styles the colors dark using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsDark(ImNodesStylePtr dest)
        {
            ImNodesStyle* nativeDest = dest.NativePtr;
            ImNodesNative.ImNodes_StyleColorsDark(nativeDest);
        }

        /// <summary>
        ///     Styles the colors light
        /// </summary>
        public static void StyleColorsLight()
        {
            ImNodesStyle* dest = null;
            ImNodesNative.ImNodes_StyleColorsLight(dest);
        }

        /// <summary>
        ///     Styles the colors light using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsLight(ImNodesStylePtr dest)
        {
            ImNodesStyle* nativeDest = dest.NativePtr;
            ImNodesNative.ImNodes_StyleColorsLight(nativeDest);
        }
    }
}