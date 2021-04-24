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
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using SFML.System;
    using Alis.Core.SFML;
    using System.IO;

    /// <summary>Manage components of scene.</summary>
    public class Inspector : Widget
    {
        private static Dictionary<Type, Action<Component, PropertyInfo>> fields = new Dictionary<Type, Action<Component, PropertyInfo>>()
        {
            { typeof(bool), DrawBoolField },
            { typeof(string), DrawStringField },
            { typeof(int), DrawIntField },
            { typeof(float), DrawFloatField },
            { typeof(byte), DrawByteField },
            { typeof(long), DrawLongField },
            { typeof(double), DrawDoubleField },
            { typeof(Vector2), DrawVector2Field },
            { typeof(Vector2f), DrawVector2fField },
            { typeof(Vector3), DrawVector3Field },
            { typeof(List<Animation>), DrawListField },
        };

        private static Inspector current;

        /// <summary>The name</summary>
        private const string Name = "Inspector";

        private GameObject gameObject;

        private bool focus;

        public static Inspector Current { get => current; set => current = value; }
        public GameObject GameObject { get => gameObject; set => gameObject = value; }
        public bool Focus { get => focus; set => focus = value; }

        /// <summary>Initializes a new instance of the <see cref="Inspector" /> class.</summary>
        public Inspector()
        {
            current = this;
        }

        public static void ShowGameObject(GameObject gameObject) 
        {
            current.focus = true;
            current.gameObject = gameObject;
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
                if (Project.VideoGame is not null)
                {
                    if (gameObject != null)
                    {
                        SeeObjComponents(gameObject);
                    }
                }
            }

            ImGui.End();
        }

        private void SeeObjComponents(GameObject gameObject)
        {
            #region Block Name 

            ImGui.BeginChild("GameObject-Child", new Vector2(ImGui.GetContentRegionAvail().X, 80.0f), true);

            string content = gameObject.Name;

            ImGui.Text("Name: ");

            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X - 25.0f);

            if (ImGui.InputText(Icon.CUBE + " ##" + gameObject.Name, ref content, 512, ImGuiInputTextFlags.EnterReturnsTrue))
            {
                gameObject.Name = content;
            }

            ImGui.PopItemWidth();
            ImGui.EndChild();

            #endregion

            #region Transform 

            ImGui.BeginGroup();
            ImGui.AlignTextToFramePadding();
            if (ImGui.TreeNodeEx(Icon.ARROWSALT + " " + gameObject.Transform.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
            {
                foreach (PropertyInfo property in gameObject.Transform.GetType().GetProperties())
                {
                    if (property.PropertyType.Equals(typeof(Vector3)))
                    {
                        DrawVector3(gameObject.Transform, property);
                    }
                }

                ImGui.TreePop();
            }

            ImGui.EndGroup();

            #endregion

            #region Show elements

            foreach (Component component in gameObject.Components)
            {
                if (component is not null) 
                {
                    ImGui.BeginGroup();
                    ImGui.AlignTextToFramePadding();
                    if (ImGui.TreeNodeEx(Icon.CUBE + " " + component.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
                    {
                        foreach (PropertyInfo property in component.GetType().GetProperties())
                        {
                            foreach (KeyValuePair<Type, Action<Component, PropertyInfo>> field in fields)
                            {
                                if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                                {
                                    field.Value.Invoke(component, property);
                                }
                            }
                        }

                        ImGui.TreePop();
                    }

                    ImGui.EndGroup();
                }
            }

            #endregion

            #region add component 

            if (ImGui.Button("Add Component", new Vector2(ImGui.GetContentRegionAvail().X, 30f)))
            {
                ImGui.OpenPopup("ElementList");
            }

            if (ImGui.BeginPopup("ElementList"))
            {
                Type type = typeof(Component);
                IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(i => i.GetName().Name.Equals("Core-SFML") || i.GetName().Name.Equals("Core"))
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p));

                foreach (Type component in types)
                {
                    if (!component.Name.Equals("Component") && !component.Name.Equals("Transform"))
                    {
                        if (ImGui.MenuItem(component.Name))
                        {
                            AddComponent(component, gameObject);
                        }
                    }
                }

                if (Project.Get().DLL1 != null) 
                {
                    type = typeof(Component);
                    types = Project.Get().DLL1.GetTypes()
                    .Where(p => type.IsAssignableFrom(p));

                    foreach (Type component in types)
                    {
                        if (!component.Name.Equals("Component") && !component.Name.Equals("Transform"))
                        {
                            if (ImGui.MenuItem(component.Name))
                            {
                                AddComponent(component, gameObject);
                            }
                        }
                    }
                }

            }

            #endregion
        }

        private void ShowComponent(Component component, PropertyInfo property) 
        {
            
        }

        private void AddComponent(Type component, GameObject gameObject) 
        {

            Component temp = (Component)Activator.CreateInstance(component);

            if (!gameObject.Contains(temp)) 
            {
                gameObject.Add(temp);
                Console.Log("Add " + component.FullName + " on " + gameObject.Name);
            }
            else 
            {
                Console.Warning("Alredy exits Add " + component.FullName + " on " + gameObject.Name);
            }
        }
        
        /*
            foreach (Component component in gameObject.Components)
            {
                ImGui.BeginGroup();
                ImGui.AlignTextToFramePadding();
                if (ImGui.TreeNodeEx(icons[component.GetType()] + " " + component.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
                {
                    foreach (PropertyInfo property in component.GetType().GetProperties())
                    {
                        foreach (KeyValuePair<Type, Action<Component, PropertyInfo>> field in fields)
                        {
                            if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                            {
                                field.Value.Invoke(component, property);
                            }
                        }
                    }

                    ImGui.TreePop();
                }

                ImGui.EndGroup();
            }

            if (ImGui.Button("Add Component", new Vector2(ImGui.GetContentRegionAvail().X, 30f)))
            {
                ImGui.OpenPopup("ElementList");
            }

            if (ImGui.BeginPopup("ElementList"))
            {

                Type type = typeof(Component);
                IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p));

                foreach (Type component in types)
                {
                    if (!component.Name.Equals("Component") && !component.Name.Equals("Transform"))
                    {
                        if (ImGui.MenuItem(component.Name))
                        {
                            constructors[component].Invoke(gameObject);
                        }
                    }
                }
            }*/
        


        /*
        ImGui.BeginGroup();
        ImGui.AlignTextToFramePadding();
        if (ImGui.TreeNodeEx(icons[typeof(Transform)] + " " + gameObject.Transform.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
        {
            foreach (PropertyInfo property in gameObject.Transform.GetType().GetProperties())
            {
                if (property.PropertyType.Equals(typeof(Vector3))) 
                {
                    DrawVector3(gameObject.Transform, property);
                }
            }

            ImGui.TreePop();
        }

        ImGui.EndGroup();

        foreach (Component component in gameObject.Components)
        {
            ImGui.BeginGroup();
            ImGui.AlignTextToFramePadding();
            if (ImGui.TreeNodeEx(icons[component.GetType()] + " " + component.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
            {
                foreach (PropertyInfo property in component.GetType().GetProperties())
                {
                    foreach (KeyValuePair<Type, Action<Component, PropertyInfo>> field in fields)
                    {
                        if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                        {
                            field.Value.Invoke(component, property);
                        }
                    }
                }

                ImGui.TreePop();
            }

            ImGui.EndGroup();
        }

        if (ImGui.Button("Add Component", new Vector2(ImGui.GetContentRegionAvail().X, 30f)))
        {
            ImGui.OpenPopup("ElementList");
        }

        if (ImGui.BeginPopup("ElementList"))
        {

            Type type = typeof(Component);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (Type component in types)
            {
                if (!component.Name.Equals("Component") && !component.Name.Equals("Transform"))
                {
                    if (ImGui.MenuItem(component.Name))
                    {
                        constructors[component].Invoke(gameObject);
                    }
                }
            }
        }*/


        private static void DrawStringField(Component component, PropertyInfo property)
        {
            string content = (string)property.GetValue(component) ?? "";

            if (ImGui.InputText(property.Name, ref content, 512))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawBoolField(Component component, PropertyInfo property)
        {
            bool content = (bool)property.GetValue(component);
            if (ImGui.Checkbox(property.Name, ref content))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawFloatField(Component component, PropertyInfo property)
        {
            float content = (float)property.GetValue(component);
            if (ImGui.InputFloat(property.Name, ref content, 0.1f))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawIntField(Component component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawByteField(Component component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawLongField(Component component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawDoubleField(Component component, PropertyInfo property)
        {
            double content = (double)property.GetValue(component);
            if (ImGui.InputDouble(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawVector2Field(Component component, PropertyInfo property)
        {
            ImGui.Text(property.Name);
            ImGui.Columns(2, property.Name, true);
            Vector2 content = (Vector2)property.GetValue(component);
            float x = content.X;

            if (ImGui.InputFloat("X" + "## " + property.Name, ref x))
            {
                content.X = x;
                property.SetValue(component, content);
            }

            ImGui.NextColumn();

            float y = content.Y;
            if (ImGui.InputFloat("Y" + "## " + property.Name, ref y))
            {
                content.Y = y;
                property.SetValue(component, content);
            }

            ImGui.Columns(1);
        }

        private static void DrawVector2fField(Component component, PropertyInfo property)
        {
            ImGui.Text(property.Name);
            ImGui.Columns(2, property.Name, true);
            Vector2f content = (Vector2f)property.GetValue(component);
            float x = content.X;

            if (ImGui.InputFloat("X" + "## " + property.Name, ref x))
            {
                content.X = x;
                property.SetValue(component, content);
            }

            ImGui.NextColumn();

            float y = content.Y;
            if (ImGui.InputFloat("Y" + "## " + property.Name, ref y))
            {
                content.Y = y;
                property.SetValue(component, content);
            }

            ImGui.Columns(1);
        }

        private static void DrawVector3Field(Component component, PropertyInfo property)
        {
            ImGui.Text(property.Name);
            ImGui.Columns(3, property.Name, true);
            Vector3 content = (Vector3)property.GetValue(component);
            float x = content.X;

            if (ImGui.InputFloat("X" + "## " + property.Name, ref x))
            {
                content.X = x;
                property.SetValue(component, content);
            }

            ImGui.NextColumn();

            float y = content.Y;
            if (ImGui.InputFloat("Y" + "## " + property.Name, ref y))
            {
                content.Y = y;
                property.SetValue(component, content);
            }

            ImGui.NextColumn();

            float z = content.Z;
            if (ImGui.InputFloat("Z" + "## " + property.Name, ref z))
            {
                content.Z = z;
                property.SetValue(component, content);
            }

            ImGui.Columns(1);
        }

        private static void DrawVector3(Transform transform, PropertyInfo property)
        {
            ImGui.Text(property.Name);
            ImGui.Columns(3, property.Name, true);
            Vector3 content = (Vector3)property.GetValue(transform);
            float x = content.X;

            if (ImGui.InputFloat("X" + "## " + property.Name, ref x))
            {
                content.X = x;
                property.SetValue(transform, content);
            }

            ImGui.NextColumn();

            float y = content.Y;
            if (ImGui.InputFloat("Y" + "## " + property.Name, ref y))
            {
                content.Y = y;
                property.SetValue(transform, content);
            }

            ImGui.NextColumn();

            float z = content.Z;
            if (ImGui.InputFloat("Z" + "## " + property.Name, ref z))
            {
                content.Z = z;
                property.SetValue(transform, content);
            }

            ImGui.Columns(1);
        }

        private static void DrawListField(Component component, PropertyInfo prop)
        {
            //List<Animation> list = (List<Animation>)prop.GetValue(component);

            List<Animation> list = (List<Animation>)prop.GetValue(component);

            if (ImGui.Button("+", new Vector2(30, 30)))
            {
                Console.Log("Add new element");
                list.Add(new Animation());
                prop.SetValue(component, list);

                Console.Log("" + list.Count);
            }

            ImGui.SameLine();

            if (ImGui.Button("-", new Vector2(30, 30)))
            {
                if (list.Count > 0) 
                {
                    list.RemoveAt(list.Count - 1);
                }
                
                prop.SetValue(component, list);

                Console.Log("" + list.Count);
            }

            ImGui.SameLine();

            ImGui.Text("Animation");

            ImGui.Text("Tree Animations: ");

            foreach (Animation animation in list)
            {
                ImGui.Separator();

                ImGui.Text("Animation " + list.IndexOf(animation));

                string content = (string)animation.Name ?? "";

                if (ImGui.InputText("Name " + "## " + list.IndexOf(animation), ref content, 512))
                {
                    animation.Name = content;
                }

                float content2 = (float)animation.Speed;
                if (ImGui.InputFloat("Speed " + "## " + list.IndexOf(animation), ref content2))
                {
                    animation.Speed = content2;
                }

                int content3 = (int)animation.State;
                if (ImGui.InputInt("State " + "## " + list.IndexOf(animation), ref content3))
                {
                    animation.State = content3;
                }

                List<string> images = animation.Images;

                if (ImGui.Button("+" + "## " + list.IndexOf(animation), new Vector2(30, 30)))
                {
                    images.Add("Default.png");
                    animation.Images = images;
                    prop.SetValue(component, list);
                }

                ImGui.SameLine();

                if (ImGui.Button("-" + "## " + list.IndexOf(animation), new Vector2(30, 30)))
                {
                    if (images.Count > 0)
                    {
                        images.RemoveAt(list.Count - 1);

                        animation.Images = images;
                        prop.SetValue(component, list);
                    }
                }
                ImGui.SameLine();

                ImGui.Text("Images");

                for (int i = 0; i < images.Count; i++) 
                {
                    string cont = (string)images[i] ?? "";

                    if (ImGui.InputText("Name " + "##" + list.IndexOf(animation) + i, ref cont, 512))
                    {
                        string change = cont;
                        images[i] = change;

                        animation.Images = images;
                        prop.SetValue(component, list);
                    }
                }


                ImGui.Separator();

                

            }

            
            


            /*foreach (Animation animation in list)
            {
                foreach (PropertyInfo property in animation.GetType().GetProperties())
                {
                    foreach (KeyValuePair<Type, Action<Component, PropertyInfo>> field in fields)
                    {
                        if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                        {
                            field.Value.Invoke(component, property);
                        }
                    }
                }
            }*/
        }

        private static void NewCollision(GameObject obj)
        {
            obj.Add(new Collision(new Vector2(10, 10), false));
        }

        private static void NewAudiosource(GameObject gameObject)
        {
            gameObject.Add(new AudioSource());
        }

        private static void NewAnimator(GameObject gameObject)
        {
            gameObject.Add(new Animator());
        }

        private static void NewSprite(GameObject gameObject)
        {
            gameObject.Add(new Sprite(""));
        }

        private static void NewCamera(GameObject gameObject)
        {
            gameObject.Add(new Camera(new Vector2(0f, 0f), new Vector2(640f, 380f)));
        }
    }
}