using System;
using System.Numerics;
using System.Text;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The im nodes class
    /// </summary>
    public static unsafe class ImNodes
    {
        /// <summary>
        /// Begins the input attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginInputAttribute(int id)
        {
            ImNodesPinShape shape = (ImNodesPinShape)ImNodesPinShape.CircleFilled;
            ImNodesNative.ImNodes_BeginInputAttribute(id, shape);
        }
        /// <summary>
        /// Begins the input attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        public static void BeginInputAttribute(int id, ImNodesPinShape shape)
        {
            ImNodesNative.ImNodes_BeginInputAttribute(id, shape);
        }
        /// <summary>
        /// Begins the node using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginNode(int id)
        {
            ImNodesNative.ImNodes_BeginNode(id);
        }
        /// <summary>
        /// Begins the node editor
        /// </summary>
        public static void BeginNodeEditor()
        {
            ImNodesNative.ImNodes_BeginNodeEditor();
        }
        /// <summary>
        /// Begins the node title bar
        /// </summary>
        public static void BeginNodeTitleBar()
        {
            ImNodesNative.ImNodes_BeginNodeTitleBar();
        }
        /// <summary>
        /// Begins the output attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginOutputAttribute(int id)
        {
            ImNodesPinShape shape = (ImNodesPinShape)ImNodesPinShape.CircleFilled;
            ImNodesNative.ImNodes_BeginOutputAttribute(id, shape);
        }
        /// <summary>
        /// Begins the output attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        public static void BeginOutputAttribute(int id, ImNodesPinShape shape)
        {
            ImNodesNative.ImNodes_BeginOutputAttribute(id, shape);
        }
        /// <summary>
        /// Begins the static attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public static void BeginStaticAttribute(int id)
        {
            ImNodesNative.ImNodes_BeginStaticAttribute(id);
        }
        /// <summary>
        /// Clears the link selection
        /// </summary>
        public static void ClearLinkSelection()
        {
            ImNodesNative.ImNodes_ClearLinkSelection_Nil();
        }
        /// <summary>
        /// Clears the link selection using the specified link id
        /// </summary>
        /// <param name="link_id">The link id</param>
        public static void ClearLinkSelection(int link_id)
        {
            ImNodesNative.ImNodes_ClearLinkSelection_Int(link_id);
        }
        /// <summary>
        /// Clears the node selection
        /// </summary>
        public static void ClearNodeSelection()
        {
            ImNodesNative.ImNodes_ClearNodeSelection_Nil();
        }
        /// <summary>
        /// Clears the node selection using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        public static void ClearNodeSelection(int node_id)
        {
            ImNodesNative.ImNodes_ClearNodeSelection_Int(node_id);
        }
        /// <summary>
        /// Creates the context
        /// </summary>
        /// <returns>The im nodes context ptr</returns>
        public static ImNodesContextPtr CreateContext()
        {
            ImNodesContext* ret = ImNodesNative.ImNodes_CreateContext();
            return new ImNodesContextPtr(ret);
        }
        /// <summary>
        /// Destroys the context
        /// </summary>
        public static void DestroyContext()
        {
            ImNodesContext* ctx = null;
            ImNodesNative.ImNodes_DestroyContext(ctx);
        }
        /// <summary>
        /// Destroys the context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void DestroyContext(ImNodesContextPtr ctx)
        {
            ImNodesContext* native_ctx = ctx.NativePtr;
            ImNodesNative.ImNodes_DestroyContext(native_ctx);
        }
        /// <summary>
        /// Editors the context create
        /// </summary>
        /// <returns>The im nodes editor context ptr</returns>
        public static ImNodesEditorContextPtr EditorContextCreate()
        {
            ImNodesEditorContext* ret = ImNodesNative.ImNodes_EditorContextCreate();
            return new ImNodesEditorContextPtr(ret);
        }
        /// <summary>
        /// Editors the context free using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        public static void EditorContextFree(ImNodesEditorContextPtr noname1)
        {
            ImNodesEditorContext* native_noname1 = noname1.NativePtr;
            ImNodesNative.ImNodes_EditorContextFree(native_noname1);
        }
        /// <summary>
        /// Editors the context get panning
        /// </summary>
        /// <returns>The retval</returns>
        public static Vector2 EditorContextGetPanning()
        {
            Vector2 __retval;
            ImNodesNative.ImNodes_EditorContextGetPanning(&__retval);
            return __retval;
        }
        /// <summary>
        /// Editors the context move to node using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        public static void EditorContextMoveToNode(int node_id)
        {
            ImNodesNative.ImNodes_EditorContextMoveToNode(node_id);
        }
        /// <summary>
        /// Editors the context reset panning using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public static void EditorContextResetPanning(Vector2 pos)
        {
            ImNodesNative.ImNodes_EditorContextResetPanning(pos);
        }
        /// <summary>
        /// Editors the context set using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        public static void EditorContextSet(ImNodesEditorContextPtr noname1)
        {
            ImNodesEditorContext* native_noname1 = noname1.NativePtr;
            ImNodesNative.ImNodes_EditorContextSet(native_noname1);
        }
        /// <summary>
        /// Ends the input attribute
        /// </summary>
        public static void EndInputAttribute()
        {
            ImNodesNative.ImNodes_EndInputAttribute();
        }
        /// <summary>
        /// Ends the node
        /// </summary>
        public static void EndNode()
        {
            ImNodesNative.ImNodes_EndNode();
        }
        /// <summary>
        /// Ends the node editor
        /// </summary>
        public static void EndNodeEditor()
        {
            ImNodesNative.ImNodes_EndNodeEditor();
        }
        /// <summary>
        /// Ends the node title bar
        /// </summary>
        public static void EndNodeTitleBar()
        {
            ImNodesNative.ImNodes_EndNodeTitleBar();
        }
        /// <summary>
        /// Ends the output attribute
        /// </summary>
        public static void EndOutputAttribute()
        {
            ImNodesNative.ImNodes_EndOutputAttribute();
        }
        /// <summary>
        /// Ends the static attribute
        /// </summary>
        public static void EndStaticAttribute()
        {
            ImNodesNative.ImNodes_EndStaticAttribute();
        }
        /// <summary>
        /// Gets the current context
        /// </summary>
        /// <returns>The im nodes context ptr</returns>
        public static ImNodesContextPtr GetCurrentContext()
        {
            ImNodesContext* ret = ImNodesNative.ImNodes_GetCurrentContext();
            return new ImNodesContextPtr(ret);
        }
        /// <summary>
        /// Gets the io
        /// </summary>
        /// <returns>The im nodes io ptr</returns>
        public static ImNodesIOPtr GetIO()
        {
            ImNodesIO* ret = ImNodesNative.ImNodes_GetIO();
            return new ImNodesIOPtr(ret);
        }
        /// <summary>
        /// Gets the node dimensions using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeDimensions(int id)
        {
            Vector2 __retval;
            ImNodesNative.ImNodes_GetNodeDimensions(&__retval, id);
            return __retval;
        }
        /// <summary>
        /// Gets the node editor space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeEditorSpacePos(int node_id)
        {
            Vector2 __retval;
            ImNodesNative.ImNodes_GetNodeEditorSpacePos(&__retval, node_id);
            return __retval;
        }
        /// <summary>
        /// Gets the node grid space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeGridSpacePos(int node_id)
        {
            Vector2 __retval;
            ImNodesNative.ImNodes_GetNodeGridSpacePos(&__retval, node_id);
            return __retval;
        }
        /// <summary>
        /// Gets the node screen space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <returns>The retval</returns>
        public static Vector2 GetNodeScreenSpacePos(int node_id)
        {
            Vector2 __retval;
            ImNodesNative.ImNodes_GetNodeScreenSpacePos(&__retval, node_id);
            return __retval;
        }
        /// <summary>
        /// Gets the selected links using the specified link ids
        /// </summary>
        /// <param name="link_ids">The link ids</param>
        public static void GetSelectedLinks(ref int link_ids)
        {
            fixed (int* native_link_ids = &link_ids)
            {
                ImNodesNative.ImNodes_GetSelectedLinks(native_link_ids);
            }
        }
        /// <summary>
        /// Gets the selected nodes using the specified node ids
        /// </summary>
        /// <param name="node_ids">The node ids</param>
        public static void GetSelectedNodes(ref int node_ids)
        {
            fixed (int* native_node_ids = &node_ids)
            {
                ImNodesNative.ImNodes_GetSelectedNodes(native_node_ids);
            }
        }
        /// <summary>
        /// Gets the style
        /// </summary>
        /// <returns>The im nodes style ptr</returns>
        public static ImNodesStylePtr GetStyle()
        {
            ImNodesStyle* ret = ImNodesNative.ImNodes_GetStyle();
            return new ImNodesStylePtr(ret);
        }
        /// <summary>
        /// Describes whether is any attribute active
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAnyAttributeActive()
        {
            int* attribute_id = null;
            byte ret = ImNodesNative.ImNodes_IsAnyAttributeActive(attribute_id);
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is any attribute active
        /// </summary>
        /// <param name="attribute_id">The attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsAnyAttributeActive(ref int attribute_id)
        {
            fixed (int* native_attribute_id = &attribute_id)
            {
                byte ret = ImNodesNative.ImNodes_IsAnyAttributeActive(native_attribute_id);
                return ret != 0;
            }
        }
        /// <summary>
        /// Describes whether is attribute active
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsAttributeActive()
        {
            byte ret = ImNodesNative.ImNodes_IsAttributeActive();
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is editor hovered
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsEditorHovered()
        {
            byte ret = ImNodesNative.ImNodes_IsEditorHovered();
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is link created
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="ended_at_attribute_id">The ended at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int started_at_attribute_id, ref int ended_at_attribute_id)
        {
            byte* created_from_snap = null;
            fixed (int* native_started_at_attribute_id = &started_at_attribute_id)
            {
                fixed (int* native_ended_at_attribute_id = &ended_at_attribute_id)
                {
                    byte ret = ImNodesNative.ImNodes_IsLinkCreated_BoolPtr(native_started_at_attribute_id, native_ended_at_attribute_id, created_from_snap);
                    return ret != 0;
                }
            }
        }
        /// <summary>
        /// Describes whether is link created
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="ended_at_attribute_id">The ended at attribute id</param>
        /// <param name="created_from_snap">The created from snap</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int started_at_attribute_id, ref int ended_at_attribute_id, ref bool created_from_snap)
        {
            byte native_created_from_snap_val = created_from_snap ? (byte)1 : (byte)0;
            byte* native_created_from_snap = &native_created_from_snap_val;
            fixed (int* native_started_at_attribute_id = &started_at_attribute_id)
            {
                fixed (int* native_ended_at_attribute_id = &ended_at_attribute_id)
                {
                    byte ret = ImNodesNative.ImNodes_IsLinkCreated_BoolPtr(native_started_at_attribute_id, native_ended_at_attribute_id, native_created_from_snap);
                    created_from_snap = native_created_from_snap_val != 0;
                    return ret != 0;
                }
            }
        }
        /// <summary>
        /// Describes whether is link created
        /// </summary>
        /// <param name="started_at_node_id">The started at node id</param>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="ended_at_node_id">The ended at node id</param>
        /// <param name="ended_at_attribute_id">The ended at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int started_at_node_id, ref int started_at_attribute_id, ref int ended_at_node_id, ref int ended_at_attribute_id)
        {
            byte* created_from_snap = null;
            fixed (int* native_started_at_node_id = &started_at_node_id)
            {
                fixed (int* native_started_at_attribute_id = &started_at_attribute_id)
                {
                    fixed (int* native_ended_at_node_id = &ended_at_node_id)
                    {
                        fixed (int* native_ended_at_attribute_id = &ended_at_attribute_id)
                        {
                            byte ret = ImNodesNative.ImNodes_IsLinkCreated_IntPtr(native_started_at_node_id, native_started_at_attribute_id, native_ended_at_node_id, native_ended_at_attribute_id, created_from_snap);
                            return ret != 0;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Describes whether is link created
        /// </summary>
        /// <param name="started_at_node_id">The started at node id</param>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="ended_at_node_id">The ended at node id</param>
        /// <param name="ended_at_attribute_id">The ended at attribute id</param>
        /// <param name="created_from_snap">The created from snap</param>
        /// <returns>The bool</returns>
        public static bool IsLinkCreated(ref int started_at_node_id, ref int started_at_attribute_id, ref int ended_at_node_id, ref int ended_at_attribute_id, ref bool created_from_snap)
        {
            byte native_created_from_snap_val = created_from_snap ? (byte)1 : (byte)0;
            byte* native_created_from_snap = &native_created_from_snap_val;
            fixed (int* native_started_at_node_id = &started_at_node_id)
            {
                fixed (int* native_started_at_attribute_id = &started_at_attribute_id)
                {
                    fixed (int* native_ended_at_node_id = &ended_at_node_id)
                    {
                        fixed (int* native_ended_at_attribute_id = &ended_at_attribute_id)
                        {
                            byte ret = ImNodesNative.ImNodes_IsLinkCreated_IntPtr(native_started_at_node_id, native_started_at_attribute_id, native_ended_at_node_id, native_ended_at_attribute_id, native_created_from_snap);
                            created_from_snap = native_created_from_snap_val != 0;
                            return ret != 0;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Describes whether is link destroyed
        /// </summary>
        /// <param name="link_id">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkDestroyed(ref int link_id)
        {
            fixed (int* native_link_id = &link_id)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkDestroyed(native_link_id);
                return ret != 0;
            }
        }
        /// <summary>
        /// Describes whether is link dropped
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsLinkDropped()
        {
            int* started_at_attribute_id = null;
            byte including_detached_links = 1;
            byte ret = ImNodesNative.ImNodes_IsLinkDropped(started_at_attribute_id, including_detached_links);
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is link dropped
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkDropped(ref int started_at_attribute_id)
        {
            byte including_detached_links = 1;
            fixed (int* native_started_at_attribute_id = &started_at_attribute_id)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkDropped(native_started_at_attribute_id, including_detached_links);
                return ret != 0;
            }
        }
        /// <summary>
        /// Describes whether is link dropped
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="including_detached_links">The including detached links</param>
        /// <returns>The bool</returns>
        public static bool IsLinkDropped(ref int started_at_attribute_id, bool including_detached_links)
        {
            byte native_including_detached_links = including_detached_links ? (byte)1 : (byte)0;
            fixed (int* native_started_at_attribute_id = &started_at_attribute_id)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkDropped(native_started_at_attribute_id, native_including_detached_links);
                return ret != 0;
            }
        }
        /// <summary>
        /// Describes whether is link hovered
        /// </summary>
        /// <param name="link_id">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkHovered(ref int link_id)
        {
            fixed (int* native_link_id = &link_id)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkHovered(native_link_id);
                return ret != 0;
            }
        }
        /// <summary>
        /// Describes whether is link selected
        /// </summary>
        /// <param name="link_id">The link id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkSelected(int link_id)
        {
            byte ret = ImNodesNative.ImNodes_IsLinkSelected(link_id);
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is link started
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsLinkStarted(ref int started_at_attribute_id)
        {
            fixed (int* native_started_at_attribute_id = &started_at_attribute_id)
            {
                byte ret = ImNodesNative.ImNodes_IsLinkStarted(native_started_at_attribute_id);
                return ret != 0;
            }
        }
        /// <summary>
        /// Describes whether is node hovered
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <returns>The bool</returns>
        public static bool IsNodeHovered(ref int node_id)
        {
            fixed (int* native_node_id = &node_id)
            {
                byte ret = ImNodesNative.ImNodes_IsNodeHovered(native_node_id);
                return ret != 0;
            }
        }
        /// <summary>
        /// Describes whether is node selected
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <returns>The bool</returns>
        public static bool IsNodeSelected(int node_id)
        {
            byte ret = ImNodesNative.ImNodes_IsNodeSelected(node_id);
            return ret != 0;
        }
        /// <summary>
        /// Describes whether is pin hovered
        /// </summary>
        /// <param name="attribute_id">The attribute id</param>
        /// <returns>The bool</returns>
        public static bool IsPinHovered(ref int attribute_id)
        {
            fixed (int* native_attribute_id = &attribute_id)
            {
                byte ret = ImNodesNative.ImNodes_IsPinHovered(native_attribute_id);
                return ret != 0;
            }
        }
        /// <summary>
        /// Links the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="start_attribute_id">The start attribute id</param>
        /// <param name="end_attribute_id">The end attribute id</param>
        public static void Link(int id, int start_attribute_id, int end_attribute_id)
        {
            ImNodesNative.ImNodes_Link(id, start_attribute_id, end_attribute_id);
        }
        /// <summary>
        /// Loads the current editor state from ini file using the specified file name
        /// </summary>
        /// <param name="file_name">The file name</param>
        public static void LoadCurrentEditorStateFromIniFile(string file_name)
        {
            byte* native_file_name;
            int file_name_byteCount = 0;
            if (file_name != null)
            {
                file_name_byteCount = Encoding.UTF8.GetByteCount(file_name);
                if (file_name_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_file_name = Util.Allocate(file_name_byteCount + 1);
                }
                else
                {
                    byte* native_file_name_stackBytes = stackalloc byte[file_name_byteCount + 1];
                    native_file_name = native_file_name_stackBytes;
                }
                int native_file_name_offset = Util.GetUtf8(file_name, native_file_name, file_name_byteCount);
                native_file_name[native_file_name_offset] = 0;
            }
            else { native_file_name = null; }
            ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniFile(native_file_name);
            if (file_name_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_file_name);
            }
        }
        /// <summary>
        /// Loads the current editor state from ini string using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="data_size">The data size</param>
        public static void LoadCurrentEditorStateFromIniString(string data, uint data_size)
        {
            byte* native_data;
            int data_byteCount = 0;
            if (data != null)
            {
                data_byteCount = Encoding.UTF8.GetByteCount(data);
                if (data_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_data = Util.Allocate(data_byteCount + 1);
                }
                else
                {
                    byte* native_data_stackBytes = stackalloc byte[data_byteCount + 1];
                    native_data = native_data_stackBytes;
                }
                int native_data_offset = Util.GetUtf8(data, native_data, data_byteCount);
                native_data[native_data_offset] = 0;
            }
            else { native_data = null; }
            ImNodesNative.ImNodes_LoadCurrentEditorStateFromIniString(native_data, data_size);
            if (data_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_data);
            }
        }
        /// <summary>
        /// Loads the editor state from ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="file_name">The file name</param>
        public static void LoadEditorStateFromIniFile(ImNodesEditorContextPtr editor, string file_name)
        {
            ImNodesEditorContext* native_editor = editor.NativePtr;
            byte* native_file_name;
            int file_name_byteCount = 0;
            if (file_name != null)
            {
                file_name_byteCount = Encoding.UTF8.GetByteCount(file_name);
                if (file_name_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_file_name = Util.Allocate(file_name_byteCount + 1);
                }
                else
                {
                    byte* native_file_name_stackBytes = stackalloc byte[file_name_byteCount + 1];
                    native_file_name = native_file_name_stackBytes;
                }
                int native_file_name_offset = Util.GetUtf8(file_name, native_file_name, file_name_byteCount);
                native_file_name[native_file_name_offset] = 0;
            }
            else { native_file_name = null; }
            ImNodesNative.ImNodes_LoadEditorStateFromIniFile(native_editor, native_file_name);
            if (file_name_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_file_name);
            }
        }
        /// <summary>
        /// Loads the editor state from ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="data">The data</param>
        /// <param name="data_size">The data size</param>
        public static void LoadEditorStateFromIniString(ImNodesEditorContextPtr editor, string data, uint data_size)
        {
            ImNodesEditorContext* native_editor = editor.NativePtr;
            byte* native_data;
            int data_byteCount = 0;
            if (data != null)
            {
                data_byteCount = Encoding.UTF8.GetByteCount(data);
                if (data_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_data = Util.Allocate(data_byteCount + 1);
                }
                else
                {
                    byte* native_data_stackBytes = stackalloc byte[data_byteCount + 1];
                    native_data = native_data_stackBytes;
                }
                int native_data_offset = Util.GetUtf8(data, native_data, data_byteCount);
                native_data[native_data_offset] = 0;
            }
            else { native_data = null; }
            ImNodesNative.ImNodes_LoadEditorStateFromIniString(native_editor, native_data, data_size);
            if (data_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_data);
            }
        }
        /// <summary>
        /// Minis the map
        /// </summary>
        public static void MiniMap()
        {
            float minimap_size_fraction = 0.2f;
            ImNodesMiniMapLocation location = ImNodesMiniMapLocation.TopLeft;
            ImNodesMiniMapNodeHoveringCallback node_hovering_callback = null;
            ImNodesMiniMapNodeHoveringCallbackUserData node_hovering_callback_data = null;
            ImNodesNative.ImNodes_MiniMap(minimap_size_fraction, location, node_hovering_callback, node_hovering_callback_data);
        }
        /// <summary>
        /// Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimap_size_fraction">The minimap size fraction</param>
        public static void MiniMap(float minimap_size_fraction)
        {
            ImNodesMiniMapLocation location = ImNodesMiniMapLocation.TopLeft;
            ImNodesMiniMapNodeHoveringCallback node_hovering_callback = null;
            ImNodesMiniMapNodeHoveringCallbackUserData node_hovering_callback_data = null;
            ImNodesNative.ImNodes_MiniMap(minimap_size_fraction, location, node_hovering_callback, node_hovering_callback_data);
        }
        /// <summary>
        /// Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimap_size_fraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        public static void MiniMap(float minimap_size_fraction, ImNodesMiniMapLocation location)
        {
            ImNodesMiniMapNodeHoveringCallback node_hovering_callback = null;
            ImNodesMiniMapNodeHoveringCallbackUserData node_hovering_callback_data = null;
            ImNodesNative.ImNodes_MiniMap(minimap_size_fraction, location, node_hovering_callback, node_hovering_callback_data);
        }
        /// <summary>
        /// Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimap_size_fraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        /// <param name="node_hovering_callback">The node hovering callback</param>
        public static void MiniMap(float minimap_size_fraction, ImNodesMiniMapLocation location, ImNodesMiniMapNodeHoveringCallback node_hovering_callback)
        {
            ImNodesMiniMapNodeHoveringCallbackUserData node_hovering_callback_data = null;
            ImNodesNative.ImNodes_MiniMap(minimap_size_fraction, location, node_hovering_callback, node_hovering_callback_data);
        }
        /// <summary>
        /// Minis the map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimap_size_fraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        /// <param name="node_hovering_callback">The node hovering callback</param>
        /// <param name="node_hovering_callback_data">The node hovering callback data</param>
        public static void MiniMap(float minimap_size_fraction, ImNodesMiniMapLocation location, ImNodesMiniMapNodeHoveringCallback node_hovering_callback, ImNodesMiniMapNodeHoveringCallbackUserData node_hovering_callback_data)
        {
            ImNodesNative.ImNodes_MiniMap(minimap_size_fraction, location, node_hovering_callback, node_hovering_callback_data);
        }
        /// <summary>
        /// Nums the selected links
        /// </summary>
        /// <returns>The ret</returns>
        public static int NumSelectedLinks()
        {
            int ret = ImNodesNative.ImNodes_NumSelectedLinks();
            return ret;
        }
        /// <summary>
        /// Nums the selected nodes
        /// </summary>
        /// <returns>The ret</returns>
        public static int NumSelectedNodes()
        {
            int ret = ImNodesNative.ImNodes_NumSelectedNodes();
            return ret;
        }
        /// <summary>
        /// Pops the attribute flag
        /// </summary>
        public static void PopAttributeFlag()
        {
            ImNodesNative.ImNodes_PopAttributeFlag();
        }
        /// <summary>
        /// Pops the color style
        /// </summary>
        public static void PopColorStyle()
        {
            ImNodesNative.ImNodes_PopColorStyle();
        }
        /// <summary>
        /// Pops the style var
        /// </summary>
        public static void PopStyleVar()
        {
            int count = 1;
            ImNodesNative.ImNodes_PopStyleVar(count);
        }
        /// <summary>
        /// Pops the style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public static void PopStyleVar(int count)
        {
            ImNodesNative.ImNodes_PopStyleVar(count);
        }
        /// <summary>
        /// Pushes the attribute flag using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        public static void PushAttributeFlag(ImNodesAttributeFlags flag)
        {
            ImNodesNative.ImNodes_PushAttributeFlag(flag);
        }
        /// <summary>
        /// Pushes the color style using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="color">The color</param>
        public static void PushColorStyle(ImNodesCol item, uint color)
        {
            ImNodesNative.ImNodes_PushColorStyle(item, color);
        }
        /// <summary>
        /// Pushes the style var using the specified style item
        /// </summary>
        /// <param name="style_item">The style item</param>
        /// <param name="value">The value</param>
        public static void PushStyleVar(ImNodesStyleVar style_item, float value)
        {
            ImNodesNative.ImNodes_PushStyleVar_Float(style_item, value);
        }
        /// <summary>
        /// Pushes the style var using the specified style item
        /// </summary>
        /// <param name="style_item">The style item</param>
        /// <param name="value">The value</param>
        public static void PushStyleVar(ImNodesStyleVar style_item, Vector2 value)
        {
            ImNodesNative.ImNodes_PushStyleVar_Vec2(style_item, value);
        }
        /// <summary>
        /// Saves the current editor state to ini file using the specified file name
        /// </summary>
        /// <param name="file_name">The file name</param>
        public static void SaveCurrentEditorStateToIniFile(string file_name)
        {
            byte* native_file_name;
            int file_name_byteCount = 0;
            if (file_name != null)
            {
                file_name_byteCount = Encoding.UTF8.GetByteCount(file_name);
                if (file_name_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_file_name = Util.Allocate(file_name_byteCount + 1);
                }
                else
                {
                    byte* native_file_name_stackBytes = stackalloc byte[file_name_byteCount + 1];
                    native_file_name = native_file_name_stackBytes;
                }
                int native_file_name_offset = Util.GetUtf8(file_name, native_file_name, file_name_byteCount);
                native_file_name[native_file_name_offset] = 0;
            }
            else { native_file_name = null; }
            ImNodesNative.ImNodes_SaveCurrentEditorStateToIniFile(native_file_name);
            if (file_name_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_file_name);
            }
        }
        /// <summary>
        /// Saves the current editor state to ini string
        /// </summary>
        /// <returns>The string</returns>
        public static string SaveCurrentEditorStateToIniString()
        {
            uint* data_size = null;
            byte* ret = ImNodesNative.ImNodes_SaveCurrentEditorStateToIniString(data_size);
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Saves the current editor state to ini string using the specified data size
        /// </summary>
        /// <param name="data_size">The data size</param>
        /// <returns>The string</returns>
        public static string SaveCurrentEditorStateToIniString(ref uint data_size)
        {
            fixed (uint* native_data_size = &data_size)
            {
                byte* ret = ImNodesNative.ImNodes_SaveCurrentEditorStateToIniString(native_data_size);
                return Util.StringFromPtr(ret);
            }
        }
        /// <summary>
        /// Saves the editor state to ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="file_name">The file name</param>
        public static void SaveEditorStateToIniFile(ImNodesEditorContextPtr editor, string file_name)
        {
            ImNodesEditorContext* native_editor = editor.NativePtr;
            byte* native_file_name;
            int file_name_byteCount = 0;
            if (file_name != null)
            {
                file_name_byteCount = Encoding.UTF8.GetByteCount(file_name);
                if (file_name_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_file_name = Util.Allocate(file_name_byteCount + 1);
                }
                else
                {
                    byte* native_file_name_stackBytes = stackalloc byte[file_name_byteCount + 1];
                    native_file_name = native_file_name_stackBytes;
                }
                int native_file_name_offset = Util.GetUtf8(file_name, native_file_name, file_name_byteCount);
                native_file_name[native_file_name_offset] = 0;
            }
            else { native_file_name = null; }
            ImNodesNative.ImNodes_SaveEditorStateToIniFile(native_editor, native_file_name);
            if (file_name_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_file_name);
            }
        }
        /// <summary>
        /// Saves the editor state to ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <returns>The string</returns>
        public static string SaveEditorStateToIniString(ImNodesEditorContextPtr editor)
        {
            ImNodesEditorContext* native_editor = editor.NativePtr;
            uint* data_size = null;
            byte* ret = ImNodesNative.ImNodes_SaveEditorStateToIniString(native_editor, data_size);
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Saves the editor state to ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="data_size">The data size</param>
        /// <returns>The string</returns>
        public static string SaveEditorStateToIniString(ImNodesEditorContextPtr editor, ref uint data_size)
        {
            ImNodesEditorContext* native_editor = editor.NativePtr;
            fixed (uint* native_data_size = &data_size)
            {
                byte* ret = ImNodesNative.ImNodes_SaveEditorStateToIniString(native_editor, native_data_size);
                return Util.StringFromPtr(ret);
            }
        }
        /// <summary>
        /// Selects the link using the specified link id
        /// </summary>
        /// <param name="link_id">The link id</param>
        public static void SelectLink(int link_id)
        {
            ImNodesNative.ImNodes_SelectLink(link_id);
        }
        /// <summary>
        /// Selects the node using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        public static void SelectNode(int node_id)
        {
            ImNodesNative.ImNodes_SelectNode(node_id);
        }
        /// <summary>
        /// Sets the current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetCurrentContext(ImNodesContextPtr ctx)
        {
            ImNodesContext* native_ctx = ctx.NativePtr;
            ImNodesNative.ImNodes_SetCurrentContext(native_ctx);
        }
        /// <summary>
        /// Sets the im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        public static void SetImGuiContext(IntPtr ctx)
        {
            ImNodesNative.ImNodes_SetImGuiContext(ctx);
        }
        /// <summary>
        /// Sets the node draggable using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="draggable">The draggable</param>
        public static void SetNodeDraggable(int node_id, bool draggable)
        {
            byte native_draggable = draggable ? (byte)1 : (byte)0;
            ImNodesNative.ImNodes_SetNodeDraggable(node_id, native_draggable);
        }
        /// <summary>
        /// Sets the node editor space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="editor_space_pos">The editor space pos</param>
        public static void SetNodeEditorSpacePos(int node_id, Vector2 editor_space_pos)
        {
            ImNodesNative.ImNodes_SetNodeEditorSpacePos(node_id, editor_space_pos);
        }
        /// <summary>
        /// Sets the node grid space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="grid_pos">The grid pos</param>
        public static void SetNodeGridSpacePos(int node_id, Vector2 grid_pos)
        {
            ImNodesNative.ImNodes_SetNodeGridSpacePos(node_id, grid_pos);
        }
        /// <summary>
        /// Sets the node screen space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="screen_space_pos">The screen space pos</param>
        public static void SetNodeScreenSpacePos(int node_id, Vector2 screen_space_pos)
        {
            ImNodesNative.ImNodes_SetNodeScreenSpacePos(node_id, screen_space_pos);
        }
        /// <summary>
        /// Snaps the node to grid using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        public static void SnapNodeToGrid(int node_id)
        {
            ImNodesNative.ImNodes_SnapNodeToGrid(node_id);
        }
        /// <summary>
        /// Styles the colors classic
        /// </summary>
        public static void StyleColorsClassic()
        {
            ImNodesStyle* dest = null;
            ImNodesNative.ImNodes_StyleColorsClassic(dest);
        }
        /// <summary>
        /// Styles the colors classic using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsClassic(ImNodesStylePtr dest)
        {
            ImNodesStyle* native_dest = dest.NativePtr;
            ImNodesNative.ImNodes_StyleColorsClassic(native_dest);
        }
        /// <summary>
        /// Styles the colors dark
        /// </summary>
        public static void StyleColorsDark()
        {
            ImNodesStyle* dest = null;
            ImNodesNative.ImNodes_StyleColorsDark(dest);
        }
        /// <summary>
        /// Styles the colors dark using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsDark(ImNodesStylePtr dest)
        {
            ImNodesStyle* native_dest = dest.NativePtr;
            ImNodesNative.ImNodes_StyleColorsDark(native_dest);
        }
        /// <summary>
        /// Styles the colors light
        /// </summary>
        public static void StyleColorsLight()
        {
            ImNodesStyle* dest = null;
            ImNodesNative.ImNodes_StyleColorsLight(dest);
        }
        /// <summary>
        /// Styles the colors light using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        public static void StyleColorsLight(ImNodesStylePtr dest)
        {
            ImNodesStyle* native_dest = dest.NativePtr;
            ImNodesNative.ImNodes_StyleColorsLight(native_dest);
        }
    }
}
