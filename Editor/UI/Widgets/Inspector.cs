//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Inspector.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using ImGuiNET;
    using Alis.Core;
    using Alis.Editor.Utils;
    using System;
    using System.Numerics;
    using Alis.Tools;

    /// <summary>Manage components of scene.</summary>
    public class Inspector : Widget
    {
        private static Inspector current;

        /// <summary>The name</summary>
        private const string Name = "Inspector";

        private GameObject gameObject;

        public static Inspector Current { get => current; set => current = value; }
        public  GameObject GameObject { get => gameObject; set => gameObject = value; }

        /// <summary>Initializes a new instance of the <see cref="Inspector" /> class.</summary>
        public Inspector()
        {
        }

        /// <summary>Closes this instance.</summary>
        public override void Close()
        {
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (ImGui.Begin("Inspector"))
            {
                if (Project.Current != null) 
                {
                    if (gameObject != null) 
                    {
                        SeeObjComponents(gameObject);
                    }
                }
            }

            ImGui.End();
        }

        private Vector4 childBackground = new Vector4(0, 0, 0, 0);

        private void SeeObjComponents(GameObject gameObject)
        {
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
            ImGui.PushStyleColor(ImGuiCol.Button, childBackground);

            ImGui.AlignTextToFramePadding();

            foreach (IComponent component in gameObject.Components)
            {
                if (component.GetType().Equals(typeof(Transform)))
                {
                    if (ImGui.TreeNodeEx("Transform", ImGuiTreeNodeFlags.AllowItemOverlap))
                    {
                        ImGui.Text("Position");
                        ImGui.TreePop();
                    }
                }

                if (component.GetType().Equals(typeof(AudioSource)))
                {
                    if (ImGui.TreeNodeEx("AudioSource", ImGuiTreeNodeFlags.AllowItemOverlap))
                    {
                        ImGui.Text("Position");
                        ImGui.TreePop();
                    }
                }

                if (component.GetType().Equals(typeof(Sprite)))
                {
                    if (ImGui.TreeNodeEx("Sprite", ImGuiTreeNodeFlags.AllowItemOverlap))
                    {
                        ImGui.Text("Position");
                        ImGui.TreePop();
                    }
                }
            }
            
           // ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
            if (ImGui.Button(Icon.PLUSSQUARE + " Add Component"))
            {
                ImGui.OpenPopup("ElementList");
            }
           

            if (ImGui.BeginPopup("ElementList"))
            {
                if (ImGui.MenuItem("New Audiosource"))
                {
                    AddNewAudiosource();
                }

                if (ImGui.MenuItem("New Sprite"))
                {
                    AddNewSprite();
                }

                ImGui.EndPopup();
            }

           // ImGui.PopItemWidth();


            ImGui.PopStyleVar();
            ImGui.PopStyleColor();
        }

        private void AddNewAudiosource()
        {
            gameObject.Add(new AudioSource("Example.wav", Project.Current.AssetsPath + "/", true));
            LocalData.Save<VideoGame>("Data", Project.Current.DataPath, Project.VideoGame);
        }

        private void AddNewSprite()
        {
            gameObject.Add(new Sprite());
            LocalData.Save<VideoGame>("Data", Project.Current.DataPath, Project.VideoGame);
        }

        private void SelectGameObject(GameObject obj)
        {
            
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }

        
    }
}
