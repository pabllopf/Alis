//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Hierarchy.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
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
    public class Hierarchy : Widget
    {
        private static Hierarchy current;

        /// <summary>The name</summary>
        private const string Name = "Hierarchy";

        public static Hierarchy Current { get => current; set => current = value; }

        /// <summary>Initializes a new instance of the <see cref="Inspector" /> class.</summary>
        public Hierarchy()
        {
        }

        /// <summary>Closes this instance.</summary>
        public override void Close()
        {
        }

        private Vector4 childBackground = new Vector4(0, 0, 0, 0);

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (ImGui.Begin("Hierarchy"))
            {
               

                if (Project.Current != null)
                {
                    foreach (Scene scene in Project.VideoGame.Scenes)
                    {
                        ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
                        ImGui.PushStyleColor(ImGuiCol.Button, childBackground);

                        ImGui.AlignTextToFramePadding();

                        bool treeopen = ImGui.TreeNodeEx("Scene: " + scene.Name, ImGuiTreeNodeFlags.AllowItemOverlap);

                        ImGui.SameLine();

                        if (ImGui.Button(Icon.PLUSSQUARE))
                        {
                            ImGui.OpenPopup("ElementList");
                        }

                        if (ImGui.BeginPopup("ElementList"))
                        {
                            if (ImGui.MenuItem("New GameObject"))
                            {
                                AddNewGameObjectToScene(scene);
                            }

                            ImGui.EndPopup();
                        }
                        if (treeopen)
                        {
                            foreach (GameObject obj in scene.GameObjects) 
                            {
                                if (ImGui.Button(obj.Name))
                                {
                                    SelectGameObject(obj);
                                }
                            }
                           
                            ImGui.TreePop();
                        }

                        ImGui.PopStyleVar();
                        ImGui.PopStyleColor();
                    }
                }
            }

            ImGui.End();
        }

        private int i = 0;

        private void AddNewGameObjectToScene(Scene scene)
        {
            while (scene.GameObjects.Contains(new GameObject("GameObject " + i + " "))) 
            {
                i++;
            }

            scene.Add(new GameObject("GameObject " + i++ + " "));

            LocalData.Save<VideoGame>("Data", Project.Current.DataPath, Project.VideoGame);

            Inspector.Current.Focus = true;
        }

        private void AddNewGameObjectToScene()
        {
            throw new NotImplementedException();
        }

        private void SelectGameObject(GameObject obj)
        {
            Inspector.Current.Focus = true;
            Inspector.Current.GameObject = obj;
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }
    }
}
