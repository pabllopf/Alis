//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="DockSpace.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Numerics;
    using Alis.Editor.Utils;
    using ImGuiNET;

    /// <summary>Manage the windows. </summary>
    public class DockSpace : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "DockSpace";

        /// <summary>The button</summary>
        private int[] button = { 1, 0, 0, 0, 0, 0, 0 };

        /// <summary>The flags</summary>
        private ImGuiDockNodeFlags dockspaceFlags;

        /// <summary>The window flags</summary>
        private ImGuiWindowFlags windowFlags;

        /// <summary>The viewport pointer</summary>
        private ImGuiViewportPtr viewportPtr;

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The window position</summary>
        private Vector2 windowPos;

        /// <summary>The extra window position</summary>
        private Vector2 extraWindowPos;

        /// <summary>The window size</summary>
        private Vector2 windowSize;

        /// <summary>The extra window size</summary>
        private Vector2 extraWindowSize;

        /// <summary>Initializes a new instance of the <see cref="DockSpace" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public DockSpace(EventHandler<EventType> eventHandler) 
        {
            this.eventHandler = eventHandler;

            dockspaceFlags = ImGuiDockNodeFlags.None;
            windowFlags = 
                ImGuiWindowFlags.MenuBar | 
                ImGuiWindowFlags.NoDocking |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoResize |
                ImGuiWindowFlags.NoMove |
                ImGuiWindowFlags.NoBringToFrontOnFocus |
                ImGuiWindowFlags.NoNavFocus;

            viewportPtr = ImGui.GetMainViewport();
            extraWindowPos = new Vector2(0.0f, 24.5f);
            extraWindowSize = new Vector2(0.0f, 50f);
        }

        /// <summary>Called when [load].</summary>
        public override void OnLoad()
        {
            Debug.Log("DockSpace::OnLoad");
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            windowPos = viewportPtr.Pos + extraWindowPos;
            windowSize = viewportPtr.Size + extraWindowSize;

            ImGui.SetNextWindowPos(windowPos);
            ImGui.SetNextWindowSize(windowSize);
            ImGui.SetNextWindowViewport(viewportPtr.ID);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);

            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(0.0f, 0.0f));
            bool open = true;
            ImGui.Begin("DockSpace", ref open, windowFlags);
            ImGui.PopStyleVar();

            ImGui.PopStyleVar(2);

            ImGuiIOPtr io = ImGui.GetIO();
            uint dockspace_id = ImGui.GetID("MyDockSpace");
            ImGui.DockSpace(dockspace_id, new System.Numerics.Vector2(0.0f, 0.0f), dockspaceFlags);

            var buttonDefault = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];
            var buttonPressed = new System.Numerics.Vector4(0.078f, 0.095f, 0.108f, 1.000f);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 0));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);

            if (ImGui.BeginMenuBar())
            {
                ImGui.PushStyleColor(ImGuiCol.Button, (button[0] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_MOUSE_POINTER, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(0);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[1] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_HAND_PAPER_O, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(1);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[2] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_ARROWS, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(2);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[3] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_RETWEET, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(3);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[4] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_EXPAND, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(4);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[5] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_ARROWS_ALT, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(5);
                }

                ImGui.PopStyleColor();

                ImGui.SameLine((ImGui.GetWindowSize().X / 2) - 50);

                ImGui.PushStyleColor(ImGuiCol.Button, (button[6] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ICON_FA_PLAY, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(6);
                }

                ImGui.PopStyleColor();

                ImGui.EndMenuBar();
            }

            ImGui.PopStyleVar(2);

            ImGui.End();
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
            Debug.Log("DockSpace::Open");
        }

        /// <summary>Closes this instance.</summary>
        public override void Close()
        {
            Debug.Log("DockSpace::Close");
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            Debug.Log("DockSpace::GetName::" + Name);
            return Name;
        }

        /// <summary>Clicks the button.</summary>
        /// <param name="v">The v.</param>
        private static void ClickButton(int v)
        {
        }
    }
}
