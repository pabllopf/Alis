//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="DockSpace.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using Alis.Core;
    using ImGuiNET;
    using System;
    using System.Numerics;
    using Alis.Tools;

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

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            windowPos = viewportPtr.Pos + extraWindowPos;
            windowSize = viewportPtr.Size - extraWindowSize;

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

            uint dockspaceid = ImGui.GetID("MyDockSpace");
            ImGui.DockSpace(dockspaceid, new System.Numerics.Vector2(0.0f, 0.0f), dockspaceFlags);

            var buttonDefault = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];
            var buttonPressed = new System.Numerics.Vector4(0.078f, 0.095f, 0.108f, 1.000f);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 0));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);

            if (ImGui.BeginMenuBar())
            {
                ImGui.PushStyleColor(ImGuiCol.Button, (button[0] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.MOUSEPOINTER, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(0);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[1] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.HANDPAPERO, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(1);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[2] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ARROWS, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(2);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[3] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.RETWEET, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(3);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[4] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.EXPAND, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(4);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[5] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ARROWSALT, new System.Numerics.Vector2(30, 0)))
                {
                    ClickButton(5);
                }

                ImGui.PopStyleColor();

                ImGui.SameLine((ImGui.GetWindowSize().X / 2) - 50);

                ImGui.PushStyleColor(ImGuiCol.Button, (button[6] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.PLAY, new Vector2(30, 0)))
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
            Logger.Log("DockSpace::Open");
        }

        /// <summary>Closes this instance.</summary>
        public override void Close()
        {
            Logger.Log("DockSpace::Close");
        }

        /// <summary>Clicks the button.</summary>
        /// <param name="v">The v.</param>
        private void ClickButton(int index)
        {
            button[index] = button[index] == 1 ? 0 : 1;
            
            if (index == 6 && GameView.Current != null)
            {
                if (!GameView.Current.IsGaming && button[index] == 1)
                {
                    GameView.Current.IsGaming = true;
                    GameView.Current.Focus = true;
                    BottomMenu.Current.Loading(true, "Running Preview");
                }
                else 
                {
                    BottomMenu.Current.Loading(false, "");
                    GameView.Current.IsGaming = false;
                }
            }
        }
    }
}
