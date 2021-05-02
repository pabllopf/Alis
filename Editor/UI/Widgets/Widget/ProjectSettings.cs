//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="ProjectSettings.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    using Alis.Core;
    using Alis.Editor.Utils;
    using ImGuiNET;
    using SFML.System;

    /// <summary>Project Settings</summary>
    public class ProjectSettings : Widget
    {
        /// <summary>The focus</summary>
        private static bool focus;

        /// <summary>The fields</summary>
        private static Dictionary<Type, Action<Config, PropertyInfo>> fields = new Dictionary<Type, Action<Config, PropertyInfo>>()
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
            { typeof(Vector3), DrawVector3Field }
        };

        /// <summary>The fields</summary>
        private static Dictionary<Type, Action<Core.Time, PropertyInfo>> fields2 = new Dictionary<Type, Action<Core.Time, PropertyInfo>>()
        {
            { typeof(bool), DrawBoolField },
            { typeof(string), DrawStringField },
            { typeof(int), DrawIntField },
            { typeof(float), DrawFloatField },
            { typeof(byte), DrawByteField },
            { typeof(long), DrawLongField },
            { typeof(double), DrawDoubleField }
        };

        /// <summary>The fields</summary>
        private static Dictionary<Type, Action<Core.WindowManager, PropertyInfo>> fields3 = new Dictionary<Type, Action<Core.WindowManager, PropertyInfo>>()
        {
            { typeof(bool), DrawBoolField },
            { typeof(string), DrawStringField },
            { typeof(int), DrawIntField },
            { typeof(float), DrawFloatField },
            { typeof(byte), DrawByteField },
            { typeof(long), DrawLongField },
            { typeof(double), DrawDoubleField },
             { typeof(Vector2), DrawVector2Field },
            { typeof(Vector2f), DrawVector2fField }
        };

        /// <summary>The is open</summary>
        private bool isOpen;

        /// <summary>The child background</summary>
        private Vector4 childBackground = new Vector4(0, 0, 0, 0);

        /// <summary>Initializes a new instance of the <see cref="ProjectSettings" /> class.</summary>
        public ProjectSettings()
        {
            isOpen = true;
            focus = false;
        }

        /// <summary>Draws this instance.</summary>
        public override void Draw()
        {
            if (!isOpen)
            {
                WidgetManager.Delete(this);
                return;
            }

            if (focus)
            {
                focus = false;
                ImGui.SetNextWindowFocus();
            }

            if (ImGui.Begin("Project Settings", ref isOpen))
            {
                if (Project.VideoGame is not null)
                {
                    if (Project.VideoGame.Config != null)
                    {
                        ShowConfig(Project.VideoGame.Config);
                    }
                }
            }

            ImGui.End();
        }

        /// <summary>
        /// Shows the configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>return none</returns>
        private void ShowConfig(Config config)
        {
            if (ImGui.TreeNodeEx(Icon.WRENCH + " General", ImGuiTreeNodeFlags.AllowItemOverlap | ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (PropertyInfo property in config.GetType().GetProperties())
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
                    ImGui.PushStyleColor(ImGuiCol.Button, childBackground);

                    foreach (KeyValuePair<Type, Action<Config, PropertyInfo>> field in fields)
                    {
                        if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                        {
                            field.Value.Invoke(config, property);
                        }
                    }

                    ImGui.PopStyleVar();
                    ImGui.PopStyleColor();
                }

                ImGui.TreePop();
            }
            
            if (ImGui.TreeNodeEx(Icon.CLOCKO + " Time", ImGuiTreeNodeFlags.AllowItemOverlap | ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (PropertyInfo property in config.Time.GetType().GetProperties())
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
                    ImGui.PushStyleColor(ImGuiCol.Button, childBackground);

                    foreach (KeyValuePair<Type, Action<Core.Time, PropertyInfo>> field in fields2)
                    {
                        if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                        {
                            field.Value.Invoke(config.Time, property);
                        }
                    }

                    ImGui.PopStyleVar();
                    ImGui.PopStyleColor();
                }

                ImGui.TreePop();
            }

            if (ImGui.TreeNodeEx(Icon.WINDOWMAXIMIZE + " Windows", ImGuiTreeNodeFlags.AllowItemOverlap | ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (PropertyInfo property in config.Window.GetType().GetProperties())
                {
                    ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0f);
                    ImGui.PushStyleColor(ImGuiCol.Button, childBackground);

                    foreach (KeyValuePair<Type, Action<WindowManager, PropertyInfo>> field in fields3)
                    {
                        if (field.Key.Equals(property.PropertyType) && property.CanWrite)
                        {
                            field.Value.Invoke(config.Window, property);
                        }
                    }

                    ImGui.PopStyleVar();
                    ImGui.PopStyleColor();
                }

                ImGui.TreePop();
            }
        }

        /// <summary>Focuses this instance.</summary>
        public static void Focus() => focus = true;

        #region ELEMENTS DRAW

        private static void DrawStringField(Config component, PropertyInfo property)
        {
            string content = (string)property.GetValue(component) ?? "";

            if (ImGui.InputText(property.Name, ref content, 512))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawBoolField(Config component, PropertyInfo property)
        {
            bool content = (bool)property.GetValue(component);
            if (ImGui.Checkbox(property.Name, ref content))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawFloatField(Config component, PropertyInfo property)
        {
            float content = (float)property.GetValue(component);
            if (ImGui.InputFloat(property.Name, ref content, 0.1f))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawIntField(Config component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawByteField(Config component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawLongField(Config component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawDoubleField(Config component, PropertyInfo property)
        {
            double content = (double)property.GetValue(component);
            if (ImGui.InputDouble(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawVector2Field(Config component, PropertyInfo property)
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

        private static void DrawVector2fField(Config component, PropertyInfo property)
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

        private static void DrawVector3Field(Config component, PropertyInfo property)
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

        #endregion

        #region DRAW TIME

        private static void DrawStringField(Core.Time component, PropertyInfo property)
        {
            string content = (string)property.GetValue(component) ?? "";

            if (ImGui.InputText(property.Name, ref content, 512))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawBoolField(Core.Time component, PropertyInfo property)
        {
            bool content = (bool)property.GetValue(component);
            if (ImGui.Checkbox(property.Name, ref content))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawFloatField(Core.Time component, PropertyInfo property)
        {
            float content = (float)property.GetValue(component);
            if (ImGui.InputFloat(property.Name, ref content, 0.1f))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawIntField(Core.Time component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawByteField(Core.Time component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawLongField(Core.Time component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawDoubleField(Core.Time component, PropertyInfo property)
        {
            double content = (double)property.GetValue(component);
            if (ImGui.InputDouble(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }


        #endregion

        #region DRAW Windows

        private static void DrawStringField(Core.WindowManager component, PropertyInfo property)
        {
            string content = (string)property.GetValue(component) ?? "";

            if (ImGui.InputText(property.Name, ref content, 512))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawBoolField(Core.WindowManager component, PropertyInfo property)
        {
            bool content = (bool)property.GetValue(component);
            if (ImGui.Checkbox(property.Name, ref content))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawFloatField(Core.WindowManager component, PropertyInfo property)
        {
            float content = (float)property.GetValue(component);
            if (ImGui.InputFloat(property.Name, ref content, 0.1f))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawIntField(Core.WindowManager component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawByteField(Core.WindowManager component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawLongField(Core.WindowManager component, PropertyInfo property)
        {
            int content = (int)property.GetValue(component);
            if (ImGui.InputInt(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawDoubleField(Core.WindowManager component, PropertyInfo property)
        {
            double content = (double)property.GetValue(component);
            if (ImGui.InputDouble(property.Name, ref content, 1))
            {
                property.SetValue(component, content);
            }
        }

        private static void DrawVector2Field(Core.WindowManager component, PropertyInfo property)
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

        private static void DrawVector2fField(Core.WindowManager component, PropertyInfo property)
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


        #endregion
    }
}
