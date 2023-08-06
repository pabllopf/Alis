using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace imnodesNET
{
    /// <summary>
    /// The imnodes native class
    /// </summary>
    public static unsafe partial class imnodesNative
    {
        /// <summary>
        /// Emulates the three button mouse destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void EmulateThreeButtonMouse_destroy(EmulateThreeButtonMouse* self);
        /// <summary>
        /// Emulates the three button mouse emulate three button mouse
        /// </summary>
        /// <returns>The emulate three button mouse</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern EmulateThreeButtonMouse* EmulateThreeButtonMouse_EmulateThreeButtonMouse();
        /// <summary>
        /// Ims the nodes begin input attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginInputAttribute(int id, ImNodesPinShape shape);
        /// <summary>
        /// Ims the nodes begin node using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginNode(int id);
        /// <summary>
        /// Ims the nodes begin node editor
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginNodeEditor();
        /// <summary>
        /// Ims the nodes begin node title bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginNodeTitleBar();
        /// <summary>
        /// Ims the nodes begin output attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shape">The shape</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginOutputAttribute(int id, ImNodesPinShape shape);
        /// <summary>
        /// Ims the nodes begin static attribute using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_BeginStaticAttribute(int id);
        /// <summary>
        /// Ims the nodes clear link selection nil
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearLinkSelection_Nil();
        /// <summary>
        /// Ims the nodes clear link selection int using the specified link id
        /// </summary>
        /// <param name="link_id">The link id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearLinkSelection_Int(int link_id);
        /// <summary>
        /// Ims the nodes clear node selection nil
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearNodeSelection_Nil();
        /// <summary>
        /// Ims the nodes clear node selection int using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_ClearNodeSelection_Int(int node_id);
        /// <summary>
        /// Ims the nodes create context
        /// </summary>
        /// <returns>The im nodes context</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesContext* ImNodes_CreateContext();
        /// <summary>
        /// Ims the nodes destroy context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_DestroyContext(ImNodesContext* ctx);
        /// <summary>
        /// Ims the nodes editor context create
        /// </summary>
        /// <returns>The im nodes editor context</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesEditorContext* ImNodes_EditorContextCreate();
        /// <summary>
        /// Ims the nodes editor context free using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextFree(ImNodesEditorContext* noname1);
        /// <summary>
        /// Ims the nodes editor context get panning using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextGetPanning(Vector2* pOut);
        /// <summary>
        /// Ims the nodes editor context move to node using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextMoveToNode(int node_id);
        /// <summary>
        /// Ims the nodes editor context reset panning using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextResetPanning(Vector2 pos);
        /// <summary>
        /// Ims the nodes editor context set using the specified noname 1
        /// </summary>
        /// <param name="noname1">The noname</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EditorContextSet(ImNodesEditorContext* noname1);
        /// <summary>
        /// Ims the nodes end input attribute
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndInputAttribute();
        /// <summary>
        /// Ims the nodes end node
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndNode();
        /// <summary>
        /// Ims the nodes end node editor
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndNodeEditor();
        /// <summary>
        /// Ims the nodes end node title bar
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndNodeTitleBar();
        /// <summary>
        /// Ims the nodes end output attribute
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndOutputAttribute();
        /// <summary>
        /// Ims the nodes end static attribute
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_EndStaticAttribute();
        /// <summary>
        /// Ims the nodes get current context
        /// </summary>
        /// <returns>The im nodes context</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesContext* ImNodes_GetCurrentContext();
        /// <summary>
        /// Ims the nodes get io
        /// </summary>
        /// <returns>The im nodes io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesIO* ImNodes_GetIO();
        /// <summary>
        /// Ims the nodes get node dimensions using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="id">The id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeDimensions(Vector2* pOut, int id);
        /// <summary>
        /// Ims the nodes get node editor space pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="node_id">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeEditorSpacePos(Vector2* pOut, int node_id);
        /// <summary>
        /// Ims the nodes get node grid space pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="node_id">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeGridSpacePos(Vector2* pOut, int node_id);
        /// <summary>
        /// Ims the nodes get node screen space pos using the specified p out
        /// </summary>
        /// <param name="pOut">The out</param>
        /// <param name="node_id">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetNodeScreenSpacePos(Vector2* pOut, int node_id);
        /// <summary>
        /// Ims the nodes get selected links using the specified link ids
        /// </summary>
        /// <param name="link_ids">The link ids</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetSelectedLinks(int* link_ids);
        /// <summary>
        /// Ims the nodes get selected nodes using the specified node ids
        /// </summary>
        /// <param name="node_ids">The node ids</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_GetSelectedNodes(int* node_ids);
        /// <summary>
        /// Ims the nodes get style
        /// </summary>
        /// <returns>The im nodes style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesStyle* ImNodes_GetStyle();
        /// <summary>
        /// Ims the nodes is any attribute active using the specified attribute id
        /// </summary>
        /// <param name="attribute_id">The attribute id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsAnyAttributeActive(int* attribute_id);
        /// <summary>
        /// Ims the nodes is attribute active
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsAttributeActive();
        /// <summary>
        /// Ims the nodes is editor hovered
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsEditorHovered();
        /// <summary>
        /// Ims the nodes is link created bool ptr using the specified started at attribute id
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="ended_at_attribute_id">The ended at attribute id</param>
        /// <param name="created_from_snap">The created from snap</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkCreated_BoolPtr(int* started_at_attribute_id, int* ended_at_attribute_id, byte* created_from_snap);
        /// <summary>
        /// Ims the nodes is link created int ptr using the specified started at node id
        /// </summary>
        /// <param name="started_at_node_id">The started at node id</param>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="ended_at_node_id">The ended at node id</param>
        /// <param name="ended_at_attribute_id">The ended at attribute id</param>
        /// <param name="created_from_snap">The created from snap</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkCreated_IntPtr(int* started_at_node_id, int* started_at_attribute_id, int* ended_at_node_id, int* ended_at_attribute_id, byte* created_from_snap);
        /// <summary>
        /// Ims the nodes is link destroyed using the specified link id
        /// </summary>
        /// <param name="link_id">The link id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkDestroyed(int* link_id);
        /// <summary>
        /// Ims the nodes is link dropped using the specified started at attribute id
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <param name="including_detached_links">The including detached links</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkDropped(int* started_at_attribute_id, byte including_detached_links);
        /// <summary>
        /// Ims the nodes is link hovered using the specified link id
        /// </summary>
        /// <param name="link_id">The link id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkHovered(int* link_id);
        /// <summary>
        /// Ims the nodes is link selected using the specified link id
        /// </summary>
        /// <param name="link_id">The link id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkSelected(int link_id);
        /// <summary>
        /// Ims the nodes is link started using the specified started at attribute id
        /// </summary>
        /// <param name="started_at_attribute_id">The started at attribute id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsLinkStarted(int* started_at_attribute_id);
        /// <summary>
        /// Ims the nodes is node hovered using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsNodeHovered(int* node_id);
        /// <summary>
        /// Ims the nodes is node selected using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsNodeSelected(int node_id);
        /// <summary>
        /// Ims the nodes is pin hovered using the specified attribute id
        /// </summary>
        /// <param name="attribute_id">The attribute id</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImNodes_IsPinHovered(int* attribute_id);
        /// <summary>
        /// Ims the nodes link using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="start_attribute_id">The start attribute id</param>
        /// <param name="end_attribute_id">The end attribute id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_Link(int id, int start_attribute_id, int end_attribute_id);
        /// <summary>
        /// Ims the nodes load current editor state from ini file using the specified file name
        /// </summary>
        /// <param name="file_name">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadCurrentEditorStateFromIniFile(byte* file_name);
        /// <summary>
        /// Ims the nodes load current editor state from ini string using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="data_size">The data size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadCurrentEditorStateFromIniString(byte* data, uint data_size);
        /// <summary>
        /// Ims the nodes load editor state from ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="file_name">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadEditorStateFromIniFile(ImNodesEditorContext* editor, byte* file_name);
        /// <summary>
        /// Ims the nodes load editor state from ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="data">The data</param>
        /// <param name="data_size">The data size</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_LoadEditorStateFromIniString(ImNodesEditorContext* editor, byte* data, uint data_size);
        /// <summary>
        /// Ims the nodes mini map using the specified minimap size fraction
        /// </summary>
        /// <param name="minimap_size_fraction">The minimap size fraction</param>
        /// <param name="location">The location</param>
        /// <param name="node_hovering_callback">The node hovering callback</param>
        /// <param name="node_hovering_callback_data">The node hovering callback data</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_MiniMap(float minimap_size_fraction, ImNodesMiniMapLocation location, ImNodesMiniMapNodeHoveringCallback node_hovering_callback, ImNodesMiniMapNodeHoveringCallbackUserData node_hovering_callback_data);
        /// <summary>
        /// Ims the nodes num selected links
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImNodes_NumSelectedLinks();
        /// <summary>
        /// Ims the nodes num selected nodes
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImNodes_NumSelectedNodes();
        /// <summary>
        /// Ims the nodes pop attribute flag
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PopAttributeFlag();
        /// <summary>
        /// Ims the nodes pop color style
        /// </summary>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PopColorStyle();
        /// <summary>
        /// Ims the nodes pop style var using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PopStyleVar(int count);
        /// <summary>
        /// Ims the nodes push attribute flag using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushAttributeFlag(ImNodesAttributeFlags flag);
        /// <summary>
        /// Ims the nodes push color style using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="color">The color</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushColorStyle(ImNodesCol item, uint color);
        /// <summary>
        /// Ims the nodes push style var float using the specified style item
        /// </summary>
        /// <param name="style_item">The style item</param>
        /// <param name="value">The value</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushStyleVar_Float(ImNodesStyleVar style_item, float value);
        /// <summary>
        /// Ims the nodes push style var vec 2 using the specified style item
        /// </summary>
        /// <param name="style_item">The style item</param>
        /// <param name="value">The value</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_PushStyleVar_Vec2(ImNodesStyleVar style_item, Vector2 value);
        /// <summary>
        /// Ims the nodes save current editor state to ini file using the specified file name
        /// </summary>
        /// <param name="file_name">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SaveCurrentEditorStateToIniFile(byte* file_name);
        /// <summary>
        /// Ims the nodes save current editor state to ini string using the specified data size
        /// </summary>
        /// <param name="data_size">The data size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImNodes_SaveCurrentEditorStateToIniString(uint* data_size);
        /// <summary>
        /// Ims the nodes save editor state to ini file using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="file_name">The file name</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SaveEditorStateToIniFile(ImNodesEditorContext* editor, byte* file_name);
        /// <summary>
        /// Ims the nodes save editor state to ini string using the specified editor
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="data_size">The data size</param>
        /// <returns>The byte</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* ImNodes_SaveEditorStateToIniString(ImNodesEditorContext* editor, uint* data_size);
        /// <summary>
        /// Ims the nodes select link using the specified link id
        /// </summary>
        /// <param name="link_id">The link id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SelectLink(int link_id);
        /// <summary>
        /// Ims the nodes select node using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SelectNode(int node_id);
        /// <summary>
        /// Ims the nodes set current context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetCurrentContext(ImNodesContext* ctx);
        /// <summary>
        /// Ims the nodes set im gui context using the specified ctx
        /// </summary>
        /// <param name="ctx">The ctx</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetImGuiContext(IntPtr ctx);
        /// <summary>
        /// Ims the nodes set node draggable using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="draggable">The draggable</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeDraggable(int node_id, byte draggable);
        /// <summary>
        /// Ims the nodes set node editor space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="editor_space_pos">The editor space pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeEditorSpacePos(int node_id, Vector2 editor_space_pos);
        /// <summary>
        /// Ims the nodes set node grid space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="grid_pos">The grid pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeGridSpacePos(int node_id, Vector2 grid_pos);
        /// <summary>
        /// Ims the nodes set node screen space pos using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        /// <param name="screen_space_pos">The screen space pos</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SetNodeScreenSpacePos(int node_id, Vector2 screen_space_pos);
        /// <summary>
        /// Ims the nodes snap node to grid using the specified node id
        /// </summary>
        /// <param name="node_id">The node id</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_SnapNodeToGrid(int node_id);
        /// <summary>
        /// Ims the nodes style colors classic using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_StyleColorsClassic(ImNodesStyle* dest);
        /// <summary>
        /// Ims the nodes style colors dark using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_StyleColorsDark(ImNodesStyle* dest);
        /// <summary>
        /// Ims the nodes style colors light using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodes_StyleColorsLight(ImNodesStyle* dest);
        /// <summary>
        /// Ims the nodes io destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodesIO_destroy(ImNodesIO* self);
        /// <summary>
        /// Ims the nodes io im nodes io
        /// </summary>
        /// <returns>The im nodes io</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesIO* ImNodesIO_ImNodesIO();
        /// <summary>
        /// Ims the nodes style destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImNodesStyle_destroy(ImNodesStyle* self);
        /// <summary>
        /// Ims the nodes style im nodes style
        /// </summary>
        /// <returns>The im nodes style</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern ImNodesStyle* ImNodesStyle_ImNodesStyle();
        /// <summary>
        /// Links the detach with modifier click destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LinkDetachWithModifierClick_destroy(LinkDetachWithModifierClick* self);
        /// <summary>
        /// Links the detach with modifier click link detach with modifier click
        /// </summary>
        /// <returns>The link detach with modifier click</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern LinkDetachWithModifierClick* LinkDetachWithModifierClick_LinkDetachWithModifierClick();
        /// <summary>
        /// Multiples the select modifier destroy using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MultipleSelectModifier_destroy(MultipleSelectModifier* self);
        /// <summary>
        /// Multiples the select modifier multiple select modifier
        /// </summary>
        /// <returns>The multiple select modifier</returns>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern MultipleSelectModifier* MultipleSelectModifier_MultipleSelectModifier();
    }
}
