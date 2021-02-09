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

        private bool focus;

        public static Inspector Current { get => current; set => current = value; }
        public  GameObject GameObject { get => gameObject; set => gameObject = value; }
        public bool Focus { get => focus; set => focus = value; }

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
            if (focus) 
            {
                ImGui.SetNextWindowFocus();
                focus = false;
            }

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
                if (ImGui.TreeNodeEx(component.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
                {
                    foreach (var propertyInfo in component.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType.Equals(typeof(string)))
                        {
                            string content = (string)propertyInfo.GetValue(component) ?? "";

                            if (ImGui.InputText(propertyInfo.Name, ref content, 256, ImGuiInputTextFlags.EnterReturnsTrue))
                            {
                                propertyInfo.SetValue(component, content);
                            }
                        }

                        if (propertyInfo.PropertyType.Equals(typeof(int)))
                        {
                            int content = (int)propertyInfo.GetValue(component);
                            if (ImGui.InputInt(propertyInfo.Name, ref content, 1))
                            {
                                propertyInfo.SetValue(component, content);
                            }
                        }

                        if (propertyInfo.PropertyType.Equals(typeof(float)))
                        {
                            float content = (float)propertyInfo.GetValue(component);
                            if (ImGui.InputFloat(propertyInfo.Name, ref content, 0.1f))
                            {
                                propertyInfo.SetValue(component, content);
                            }
                        }

                        if (propertyInfo.PropertyType.Equals(typeof(bool)))
                        {
                            bool content = (bool)propertyInfo.GetValue(component);
                            if (ImGui.Checkbox(propertyInfo.Name, ref content))
                            {
                                propertyInfo.SetValue(component, content);
                            }
                        }


                        if (propertyInfo.PropertyType.Equals(typeof(Vector2)))
                        {
                            Vector2 content = (Vector2)propertyInfo.GetValue(component);
                            if (ImGui.SliderFloat("X", ref content.X, - float.MaxValue, float.MaxValue)) 
                            {
                                propertyInfo.SetValue(component, content);
                            }

                            ImGui.NextColumn();

                            if (ImGui.SliderFloat("Y", ref content.Y, -float.MaxValue, float.MaxValue))
                            {
                                propertyInfo.SetValue(component, content);
                            }
                        }

                        if (propertyInfo.PropertyType.Equals(typeof(Vector3)))
                        {
                            ImGui.Text(propertyInfo.Name);
                            ImGui.Columns(3, propertyInfo.Name, true);
                            Vector3 content = (Vector3)propertyInfo.GetValue(component);
                            float x = content.X;

                            if (ImGui.InputFloat("X" + "## " + propertyInfo.Name, ref x))
                            {
                                content.X = x;
                                propertyInfo.SetValue(component, content);
                            }

                            ImGui.NextColumn();

                            float y = content.Y;
                            if (ImGui.InputFloat("Y" + "## " + propertyInfo.Name, ref y))
                            {
                                content.Y = y;
                                propertyInfo.SetValue(component, content);
                            }

                            ImGui.NextColumn();

                            float z = content.Z;
                            if (ImGui.InputFloat("Z" + "## " + propertyInfo.Name, ref z))
                            {
                                content.Z = z;
                                propertyInfo.SetValue(component, content);
                            }
                            ImGui.Columns(1);
                        }


                    }

                    ImGui.TreePop();
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
            gameObject.Add(new AudioSource("", Project.Current.AssetsPath + "/", true, 1));
        }

        private void AddNewSprite()
        {
            gameObject.Add(new Sprite("", Project.Current.AssetsPath + "/"));
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
