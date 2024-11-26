// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InspectorWindow.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.ComponentModel;
using System.Reflection;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Entity;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The inspector window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class InspectorWindow : IWindow
    {
        private static readonly string NameWindow = $"{FontAwesome5.InfoCircle} Inspector";

        /// <summary>
        ///     Initializes a new instance of the <see cref="InspectorWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public InspectorWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;
        
        private GameObject _selectedGameObject;

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            ImGui.Begin(NameWindow);
            
            if (_selectedGameObject != null)
            {
                // Show the name of the selected game object
                ImGui.Text($"Name: {_selectedGameObject.Name}");
                
                ImGui.SameLine();
                
                // Show the tag of the selected game object
                ImGui.Text($"Tag: {_selectedGameObject.Tag}");
                
                // Show the position of the selected game object as a Vector2 and editable:
                ImGui.Text("Position:");
                Vector2 position = _selectedGameObject.Transform.Position;
                Vector2 pos = new Vector2(position.X, position.Y);
                ImGui.InputFloat2("##Position", ref pos);
                _selectedGameObject.Transform = new Transform(pos, _selectedGameObject.Transform.Rotation, _selectedGameObject.Transform.Scale);
                
                // Show the rotation of the selected game object as a float and editable:
                ImGui.Text("Rotation:");
                float rotation = _selectedGameObject.Transform.Rotation;
                ImGui.InputFloat("##Rotation", ref rotation);
                _selectedGameObject.Transform = new Transform(_selectedGameObject.Transform.Position, rotation, _selectedGameObject.Transform.Scale);
                
                // Show the scale of the selected game object as a Vector2 and editable:
                ImGui.Text("Scale:");
                Vector2 scale = _selectedGameObject.Transform.Scale;
                Vector2 sca = new Vector2(scale.X, scale.Y);
                ImGui.InputFloat2("##Scale", ref sca);
                _selectedGameObject.Transform = new Transform(_selectedGameObject.Transform.Position, _selectedGameObject.Transform.Rotation, sca);
                
               // Show the components of the selected game object
                ImGui.Text("Components:");
                foreach (AComponent component in _selectedGameObject.Components)
                {
                    ImGui.Separator();
                    ImGui.Text(component.GetType().Name);
                    RenderComponentProperties(component);
                }
            }

            ImGui.End();
        }
        
        private void RenderComponentProperties(AComponent component)
        {
            PropertyInfo[] properties = component.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(component);
                    switch (value)
                    {
                        case float floatValue:
                            ImGui.InputFloat(property.Name + "##" + component.GetType().Name, ref floatValue);
                            property.SetValue(component, floatValue);
                            break;
                        case double doubleValue:
                            ImGui.InputDouble(property.Name + "##" + component.GetType().Name, ref doubleValue);
                            property.SetValue(component, doubleValue);
                            break;
                        case int intValue:
                            ImGui.InputInt(property.Name + "##" + component.GetType().Name, ref intValue);
                            property.SetValue(component, intValue);
                            break;
                        case bool boolValue:
                            ImGui.Checkbox(property.Name + "##" + component.GetType().Name, ref boolValue);
                            property.SetValue(component, boolValue);
                            break;
                        case Vector2 vector2Value:
                            ImGui.InputFloat2(property.Name + "##" + component.GetType().Name, ref vector2Value);
                            property.SetValue(component, vector2Value);
                            break;
                        case Vector3 vector3Value:
                            ImGui.InputFloat3(property.Name + "##" + component.GetType().Name, ref vector3Value);
                            property.SetValue(component, vector3Value);
                            break;
                        case Vector4 vector4Value:
                            ImGui.InputFloat4(property.Name + "##" + component.GetType().Name, ref vector4Value);
                            property.SetValue(component, vector4Value);
                            break;
                    }
                    // Add more types as needed
                }
            }
        }
        
        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
        
        public void SelectGameObject(GameObject gameObject)
        {
            _selectedGameObject = gameObject;
        }
    }
}