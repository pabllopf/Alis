//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="ProjectCreator.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Tools;
    using ImGuiNET;
    using System;
    using System.Numerics;
    using System.Text;

    /// <summary>Create new project. </summary>
    public class ProjectCreator : Widget
    {
        /// <summary>The name</summary>
        private readonly string name = "ProjectCreator";

        /// <summary>The is open</summary>
        private bool isOpen = true;

        /// <summary>The is select2 d</summary>
        private bool isSelect2D = false;

        private string[] modes = new string[] { "2D Videogame -SFML Core- " };

        /// <summary>The item space</summary>
        private Vector2 itemSpace = new Vector2(-10.0f, 3.0f);

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        private byte[] nameBuffer = new byte[256];

        /// <summary>The buffer</summary>
        private byte[] pathBuffer = new byte[256];

        private Vector2 sizeMasterChild = new Vector2(550, 200);
        private Vector2 sizeChildLeft = new Vector2();
        private Vector2 sizeChildRight = new Vector2();

        private Vector2 createButton = new Vector2();

        /// <summary>Initializes a new instance of the <see cref="ProjectCreator" /> class.</summary>
        public ProjectCreator(EventHandler<EventType> eventHandler) 
        {
            this.eventHandler = eventHandler;

            byte[] example = Encoding.ASCII.GetBytes("Name");

            for (int i = 0; i < example.Length; i++)
            {
                nameBuffer[i] = example[i];
            }

            example = Encoding.ASCII.GetBytes(Application.DesktopPath);

            for (int i = 0; i < example.Length; i++)
            {
                pathBuffer[i] = example[i];
            }

            current_item = modes[0];
        }

       

        /// <summary>Load this instance.</summary>
        public override void OnLoad()
        {
            
        }

        
        string current_item = null;


        private bool state;


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
                ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                ImGui.InputText("##Name", nameBuffer, (uint)pathBuffer.Length);
                ImGui.PopItemWidth();

                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 3));

                ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X - 27.0f);
                ImGui.BeginGroup();

                
                ImGui.InputText("##Path", pathBuffer, (uint)pathBuffer.Length);
                

                ImGui.SameLine();

                createButton.X = 27.0f;
                createButton.Y = 27.0f;

               
                if (ImGui.Button("...", createButton))
                {
                }

                ImGui.PopStyleVar();
                ImGui.PopItemWidth();
                ImGui.EndGroup();

                



                ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                if (ImGui.BeginCombo("##Mode", current_item))
                {
                    for (int n = 0; n < modes.Length; n++)
                    {
                        bool is_selected = (current_item == modes[n]);
                        if (ImGui.Selectable(modes[n], is_selected))
                        {
                            current_item = modes[n];
                        }

                        if (is_selected)
                        {
                            ImGui.SetItemDefaultFocus();
                        }
                    }
                    ImGui.EndCombo();
                }
                ImGui.PopItemWidth();


                createButton.X = sizeMasterChild.X;
                createButton.Y = 50.0f;
                if (ImGui.Button("Create", createButton))
                {
                }
            }
            ImGui.EndPopup();
        }


                    /*

                    if (ImGui.BeginChild("Project-Child-Left", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X / 3, ImGui.GetContentRegionAvail().Y)))
                    {
                        

                        if (ImGui.BeginCombo("##combo", current_item)) 
                        {
                            for (int n = 0; n < items.Length; n++)
                            {
                                bool is_selected = (current_item == items[n]); // You can store your selection however you want, outside or inside your objects
                                if (ImGui.Selectable(items[n], is_selected))
                                {
                                    current_item = items[n];
                                }

                                if (is_selected) 
                                {
                                    ImGui.SetItemDefaultFocus();
                                }
                            }
                            ImGui.EndCombo();
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
                    */
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
