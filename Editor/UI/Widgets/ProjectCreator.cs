//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="ProjectCreator.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using ImGuiNET;
    using System;

    /// <summary>Create new project. </summary>
    public class ProjectCreator : Widget
    {
        /// <summary>The name</summary>
        private readonly string name = "ProjectCreator";

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The is select2 d</summary>
        private bool isSelect2D = false;

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The buffer</summary>
        private byte[] pathBuffer = new byte[256]; 

        /// <summary>Initializes a new instance of the <see cref="ProjectCreator" /> class.</summary>
        public ProjectCreator(EventHandler<EventType> eventHandler) 
        {
            this.eventHandler = eventHandler;
        }

        /// <summary>Load this instance.</summary>
        public override void OnLoad()
        {

        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (!isOpen)
            {
                eventHandler?.Invoke(this, EventType.CloseCreatorProject);
                return;
            }

            if (isOpen)
            {
                ImGui.OpenPopup("New Project");
            }

            if (ImGui.BeginPopupModal("New Project", ref isOpen, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                if (ImGui.BeginChild("Project-Child-Master"))
                {

                    if (ImGui.BeginChild("Project-Child-Left", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y)))
                    {
                        string[] items = new string[]{ "AAAA", "BBBB", "CCCC", "DDDD", "EEEE", "FFFF", "GGGG", "HHHH", "IIII", "JJJJ", "KKKK", "LLLLLLL", "MMMM", "OOOOOOO", "PPPP", "QQQQQQQQQQ", "RRR", "SSSS" };
                        string current_item = null;

                        /*if (ImGui::BeginCombo("##combo", current_item)) // The second parameter is the label previewed before opening the combo.
                        {
                            for (int n = 0; n < IM_ARRAYSIZE(items); n++)
                            {
                                bool is_selected = (current_item == items[n]); // You can store your selection however you want, outside or inside your objects
                                if (ImGui::Selectable(items[n], is_selected)
                                    current_item = items[n];
                                if (is_selected)
                                    ImGui::SetItemDefaultFocus();   // You may set the initial focus when opening the combo (scrolling + for keyboard navigation support)
                            }
                            ImGui::EndCombo();
                        */
                        }

                        ImGui.EndChild();

                    ImGui.SameLine();

                    if (ImGui.BeginChild("Project-Child-Right", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y)))
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            ImGui.Text("hola" + i);
                        }
                    }

                    ImGui.EndChild();
                }

                ImGui.EndChild();


                ImGui.InputText("Path", pathBuffer, (uint)pathBuffer.Length);

                ImGui.SameLine();

                if (ImGui.Button("Accept", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 35.0f)))
                { 
                }


                    ImGui.Text("Please note that this is a test version in development.");
                if (ImGui.Button("Accept", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 35.0f)))
                {
                    isOpen = false;
                    ImGui.CloseCurrentPopup();
                }
                ImGui.EndPopup();
            }
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
            isOpen = true;
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
            isOpen = false;
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            return name;
        }
    }
}
