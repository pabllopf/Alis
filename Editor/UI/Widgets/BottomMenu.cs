//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="BottomMenu.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Editor.Utils;
    using ImGuiNET;
    using System;

    /// <summary>Define the menu.</summary>
    public class BottomMenu : Widget
    {
        /// <summary>The current</summary>
        private static BottomMenu current; 

        /// <summary>The name</summary>
        private const string Name = "BottonMenu";

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The viewport</summary>
        private ImGuiViewportPtr viewport;

        /// <summary>The window flags</summary>
        private ImGuiWindowFlags windowFlags;

        private string messageLoading = string.Empty;

        private bool stateLoading = false;

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static BottomMenu Current { get => current; set => current = value; }

        /// <summary>Initializes a new instance of the <see cref="BottomMenu" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public BottomMenu(EventHandler<EventType> eventHandler)
        {
            this.eventHandler = eventHandler;

            viewport = ImGui.GetMainViewport();

            windowFlags =
                ImGuiWindowFlags.NoDocking |
                ImGuiWindowFlags.NoTitleBar |
                ImGuiWindowFlags.NoCollapse |
                ImGuiWindowFlags.NoResize |
                ImGuiWindowFlags.NoMove |
                ImGuiWindowFlags.NoScrollbar;
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(viewport.Pos.X, (viewport.Size.Y + viewport.Pos.Y) - 32.0f));
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(viewport.Size.X, 1.0f));

            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(0.0f, 3.0f));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(3.0f, 2.0f));

            ImGui.PushStyleColor(ImGuiCol.MenuBarBg, new System.Numerics.Vector4(0.040f, 0.090f, 0.152f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new System.Numerics.Vector4(0.170f, 0.210f, 0.260f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.ChildBg, new System.Numerics.Vector4(0.040f, 0.090f, 0.152f, 1.000f));
            ImGui.PushStyleColor(ImGuiCol.Button, new System.Numerics.Vector4(0.040f, 0.090f, 0.152f, 1.000f));

            bool open = true;

            if (ImGui.Begin("BottonMenu", ref open, windowFlags))
            {
                if (ImGui.BeginChild("Child-BottonMenu", new System.Numerics.Vector2(0.0f, 0.0f), true))
                {
                    if (ImGui.Button(Icon.SHAREALT + " master"))
                    {
                        ImGui.OpenPopup("Branchs");
                    }

                    ImGui.SameLine();

                    StartStylePopPup();
                    if (ImGui.BeginPopup("Branchs"))
                    {
                        if (ImGui.MenuItem(Icon.PLUS + " New Branch"))
                        {
                        }

                        ImGui.Separator();

                        ImGui.Selectable(Icon.CHECK + " master");
                        ImGui.Selectable(Icon.ARROWRIGHT + " develop");

                        ImGui.EndPopup();
                    }

                    EndStylePopPup();

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.RETWEET + " Fetch"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.ARROWDOWN + " Pull"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.ARROWUP + " Push"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.EXCLAMATIONTRIANGLE + " 0"))
                    {
                    }

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.EXCLAMATIONCIRCLE + " 0"))
                    {
                    }

                    if (stateLoading) 
                    {
                        ImGui.SameLine(ImGui.GetWindowSize().X - 130);

                        ImGui.Text(messageLoading);

                        ImGui.SameLine();

                        if (ImGui.Button(Icon.REFRESH + string.Empty, new System.Numerics.Vector2(30, 0)))
                        {
                        }
                    }

                   

                    ImGui.EndChild();
                }
            }

            ImGui.End();

            ImGui.PopStyleVar(5);
            ImGui.PopStyleColor(4);
        }

        public void Loading(bool state, string message) 
        {
            this.messageLoading = message;
            this.stateLoading = state;
        }


        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
        }

        /// <summary>Starts the style pop pup.</summary>
        private void StartStylePopPup()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 5.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(15, 15));
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(5.0f, 5.0f));
        }

        /// <summary>Ends the style pop pup.</summary>
        private void EndStylePopPup()
        {
            ImGui.PopStyleVar(3);
        }
    }
}