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

    /// <summary>Manage components of scene.</summary>
    public class Inspector : Widget
    {
        private readonly Dictionary<Type, Action<Component, PropertyInfo>> fields = new Dictionary<Type, Action<Component, PropertyInfo>>()
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
            { typeof(List<>), DrawListField },
        };



        private readonly Dictionary<Type, Action<GameObject>> constructors = new Dictionary<Type, Action<GameObject>>()
        {
            { typeof(Sprite), NewSprite },
            { typeof(Animator), NewAnimator },
            { typeof(AudioSource), NewAudiosource },
            { typeof(Camera), NewCamera }
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
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
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

        private void SeeObjComponents(GameObject gameObject)
        {
            ImGui.BeginGroup();
            ImGui.BeginChild("GameObject-Child", new Vector2(ImGui.GetContentRegionAvail().X, 80.0f), true);

            string content = gameObject.Name;

            ImGui.Text("Name: ");

            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X - 25.0f);

            if (ImGui.InputText(Icon.CUBE  + " ##" + gameObject.Name, ref content, 512, ImGuiInputTextFlags.EnterReturnsTrue))
            {
                gameObject.Name = content;
            }

            ImGui.PopItemWidth();


            ImGui.EndChild();
            ImGui.EndGroup();


            ImGui.BeginGroup();
            ImGui.AlignTextToFramePadding();
            if (ImGui.TreeNodeEx(gameObject.Transform.Icon + " " + gameObject.Transform.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
            {
                foreach (PropertyInfo property in gameObject.Transform.GetType().GetProperties())
                {
                    foreach (KeyValuePair<Type, Action<Component, PropertyInfo>> field in fields)
                    {
                        if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                        {
                            //field.Value.Invoke((Component)gameObject.Transform, property);
                        }
                    }
                }

                ImGui.TreePop();
            }

            ImGui.EndGroup();

            foreach (Component component in gameObject.Components)
            {
                ImGui.BeginGroup();
                ImGui.AlignTextToFramePadding();
                if (ImGui.TreeNodeEx(component.GetType().GetProperties().ToList().Find(i => i.Name.Equals("Icon")).GetValue(component) + " " + component.GetType().Name, ImGuiTreeNodeFlags.AllowItemOverlap))
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
            }
        }

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

        private static void DrawListField(Component component, PropertyInfo property)
        {
        }


        private static void NewAudiosource(GameObject gameObject)
        {
            gameObject.Add(new AudioSource(Project.Current.AssetsPath + "/" + "", true, 1));
        }

        private static void NewAnimator(GameObject gameObject)
        {
            gameObject.Add(new Animator());
        }

        private static void NewSprite(GameObject gameObject)
        {
            gameObject.Add(new Sprite());
        }

        private static void NewCamera(GameObject gameObject)
        {
            gameObject.Add(new Camera(new Vector2f(0f, 0f), new Vector2f(640f, 380f)));
        }
    }
}