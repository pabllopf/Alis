//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="DockSpace.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System.Numerics;
    using Alis.Editor.Utils;
    using ImGuiNET;
    using Alis.Tools;
    using System;

    /// <summary>Manage the windows. </summary>
    public class DockSpace : Widget
    {
        /// <summary>The button</summary>
        private int[] button = { 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>The flags</summary>
        private ImGuiDockNodeFlags dockspaceFlags;

        /// <summary>The window flags</summary>
        private ImGuiWindowFlags windowFlags;

        /// <summary>The viewport pointer</summary>
        private ImGuiViewportPtr viewportPtr;

        /// <summary>The window position</summary>
        private Vector2 windowPos;

        /// <summary>The extra window position</summary>
        private Vector2 extraWindowPos;

        /// <summary>The window size</summary>
        private Vector2 windowSize;

        /// <summary>The extra window size</summary>
        private Vector2 extraWindowSize;

        /// <summary>The is playing</summary>
        private bool isPlaying;

        /// <summary>The button pressed</summary>
        private Vector4 buttonPressed;

        /// <summary>Initializes a new instance of the <see cref="DockSpace" /> class.</summary>
        public DockSpace()
        {
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

            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0.0f, 0.0f));
            bool open = true;
            ImGui.Begin("DockSpace", ref open, windowFlags);
            ImGui.PopStyleVar();

            ImGui.PopStyleVar(2);

            uint dockspaceid = ImGui.GetID("MyDockSpace");
            ImGui.DockSpace(dockspaceid, new Vector2(0.0f, 0.0f), dockspaceFlags);

            var buttonDefault = ImGui.GetStyle().Colors[(int)ImGuiCol.Button];
            buttonPressed = new Vector4(0.654f, 0.070f, 0.070f, 1.000f);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 0));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 0.0f);

            if (ImGui.BeginMenuBar())
            {
                ImGui.PushStyleColor(ImGuiCol.Button, (button[0] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.MOUSEPOINTER, new System.Numerics.Vector2(30, 0)))
                {
                    //ClickButton(0);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[1] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.HANDPAPERO, new System.Numerics.Vector2(30, 0)))
                {
                    //ClickButton(1);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[2] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ARROWS, new System.Numerics.Vector2(30, 0)))
                {
                    //ClickButton(2);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[3] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.RETWEET, new System.Numerics.Vector2(30, 0)))
                {
                    //ClickButton(3);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[4] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.EXPAND, new System.Numerics.Vector2(30, 0)))
                {
                    //ClickButton(4);
                }

                ImGui.PopStyleColor();

                ImGui.PushStyleColor(ImGuiCol.Button, (button[5] == 1) ? buttonPressed : buttonDefault);
                if (ImGui.Button(Icon.ARROWSALT, new System.Numerics.Vector2(30, 0)))
                {
                    //ClickButton(5);
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

        /// <summary>Plays the game.</summary>
        private void PlayGame()
        {
            Logger.Log("Play Game");
        }

        /// <summary>Clicks the button.</summary>
        /// <param name="v">The v.</param>
        private void ClickButton(int index)
        {
            button[index] = button[index] == 1 ? 0 : 1;

            if (index == 6)
            {
                Logger.Log("Play game scene view");

                if (!GameView.IsGaming)
                {
                    SceneView.Disable = true;

                    GameView.IsGaming = true;
                    GameView.Focus = true;
                    BottomMenu.Loading(true, "Gaming");
                    return;
                }


                if (GameView.IsGaming)
                {
                    GameView.IsGaming = false;
                    
                    BottomMenu.Loading(false, "");

                    SceneView.Disable = false;
                    return;
                }
            }
        }
    }
}
