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
    using Alis.Core.SFML;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

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


        private Vector4 childBackground = new Vector4(0, 0, 0, 0);

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (ImGui.Begin("Hierarchy"))
            {
                if (Project.VideoGame is not null) 
                {

                    ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
                    ImGui.PushStyleColor(ImGuiCol.Button, childBackground);

                    ImGui.BeginChild("GameObject-Child", new Vector2(ImGui.GetContentRegionAvail().X, 80.0f), true);

                    Scene scene = Project.VideoGame.SceneManager.Scenes[0];

                    string content = scene.Name;

                    ImGui.Text("Scene: ");

                    ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X - 40.0f);

                    if (ImGui.InputText("##" + scene.Name, ref content, 512, ImGuiInputTextFlags.EnterReturnsTrue))
                    {
                        scene.Name = content;
                    }

                    ImGui.PopItemWidth();

                    ImGui.SameLine();

                    if (ImGui.Button(Icon.PLUSSQUARE))
                    {
                        ImGui.OpenPopup("ElementList");
                    }

                    if (ImGui.BeginPopup("ElementList"))
                    {
                        if (ImGui.MenuItem("New GameObject"))
                        {
                            AddNewGameObjectToScene();
                        }

                        ImGui.EndPopup();
                    }


                   

                    ImGui.EndChild();

                   

                    ImGui.PopStyleVar();
                    ImGui.PopStyleColor();

                    

                    foreach (GameObject obj in Project.VideoGame.SceneManager.Scenes[0].GameObjects)
                    {
                        if (obj is not null) 
                        {
                            UpdateGameObject(obj);

                            ImGui.AlignTextToFramePadding();

                            ImGui.PushStyleColor(ImGuiCol.Button, childBackground);

                            if (ImGui.Button(obj.Name, new Vector2(ImGui.GetContentRegionAvail().X - 35.0f, 30.0f)))
                            {
                                SelectGameObject(obj);
                            }

                            ImGui.SameLine();

                            if (ImGui.Button(Icon.ALIGNJUSTIFY + "###" + obj.Name))
                            {
                                ImGui.OpenPopup("ElementList " + "###" + obj.Name);
                            }

                            if (ImGui.BeginPopup("ElementList " + "###" + obj.Name))
                            {
                                if (ImGui.MenuItem("Delete" +"###" + obj.Name))
                                {
                                    DeleteGameObjectOfScene(obj);
                                }

                                ImGui.EndPopup();
                            }

                            ImGui.PopStyleColor();
                        }
                    }
                }
            }

            ImGui.End();
        }

        private void UpdateGameObject(GameObject obj)
        {
            if (Project.Get().DLL1 != null) 
            {
                List<Component> tempList = obj.Components.ToList();
                Type[] ty = Project.Get().DLL1.GetTypes();

                for (int i = 0; i < tempList.Count; i++) 
                {
                    if (tempList[i] != null) 
                    {
                        Component compo = tempList[i];
                        Type type = typeof(Component);
                        IEnumerable<Type> types = ty
                        .Where(p => type.IsAssignableFrom(p));

                        if (types.Any(i => i.Name.Equals(compo.GetType().Name))) 
                        {
                            Type final = types.First(i => i.Name.Equals(compo.GetType().Name));

                            if (final.FullName.Equals(obj.Components[i].GetType().FullName) && !final.Assembly.Equals(obj.Components[i].GetType().Assembly)) 
                            {
                                Console.Warning("Create new intencie of " + final.FullName + " on " + obj.Name);

                                Component tempCompo = (Component)Activator.CreateInstance(final);

                                foreach (PropertyInfo property in tempCompo.GetType().GetProperties())
                                {
                                    PropertyInfo info = compo.GetType().GetProperty(property.Name);
                                    if (info != null) 
                                    {
                                        if (property.CanWrite && info.CanWrite && info.Name.Equals(property.Name))
                                        {
                                            property.SetValue(tempCompo, info.GetValue(compo));
                                        }
                                    }


                                }

                                obj.Set(tempCompo, i);
                            }
                        }
                    }
                }
            }
        }

        private void AddNewGameObjectToScene()
        {
            if (Project.VideoGame is not null)
            {
                GameObject obj = new GameObject("GameObject", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)));
                int index = 0;
                while (Project.VideoGame.SceneManager.Scenes[0].Contains(obj)) 
                {
                    obj.Name = "GameObject" + "_" + index;
                    index++;
                }
                Project.VideoGame.SceneManager.Scenes[0].Add(obj);
                LocalData.Save<VideoGame>("Data", Project.Get().DataPath1, Project.VideoGame);
            }
        }

        private void DeleteGameObjectOfScene(GameObject obj)
        {
            if (Project.VideoGame is not null)
            {
                Project.VideoGame.SceneManager.Scenes[0].Remove(obj);
                LocalData.Save<VideoGame>("Data", Project.Get().DataPath1, Project.VideoGame);
            }
        }

        private void SelectGameObject(GameObject obj)
        {
            Inspector.ShowGameObject(obj);
        }
    }
}
