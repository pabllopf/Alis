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

using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Entity;
using Alis.Extension.Graphic.ImGui.Native;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Light;
using Alis.Core.Ecs.Component.Render;
using Alis.Extension.Graphic.ImGui;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The inspector window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class InspectorWindow : IWindow
    {
        /// <summary>
        /// The info circle
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.InfoCircle} Inspector";

        /// <summary>
        /// The selected game object
        /// </summary>
        private GameObject _selectedGameObject;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InspectorWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public InspectorWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        // Define a dictionary to map component types to icons
        private readonly Dictionary<Type, string> _componentIcons = new Dictionary<Type, string>
        {
            { typeof(Sprite), FontAwesome5.PaintBrush },
            { typeof(Animator), FontAwesome5.ShieldAlt },
            { typeof(BoxCollider), FontAwesome5.ShieldAlt },
            { typeof(Camera), FontAwesome5.Camera },
            { typeof(DirectionalLight), FontAwesome5.Lightbulb },
            { typeof(AudioSource), FontAwesome5.VolumeUp },
            { typeof(Animation), FontAwesome5.Play}
        };
        
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
                RenderHeader();
                
                RenderTransform();

                RenderComponents();
            }

            ImGui.End();
        }
        
        private IntPtr commandBufferName = IntPtr.Zero;
        private IntPtr commandBufferTag = IntPtr.Zero;
        
        private string[] tags = { "Player", "Enemy", "NPC", "Item" };
        
        /// <summary>
        /// Renderiza la sección superior del inspector con el nombre y el tag del objeto.
        /// </summary>
        private void RenderHeader()
        {
            if (_selectedGameObject == null)
            {
                return;
            }

            if (ImGui.BeginChild("##Header", new Vector2(ImGui.GetContentRegionAvail().X, 80), true, ImGuiWindowFlags.NoCollapse))
            {
                // Icon of the object:
                ImGui.PushFont(SpaceWork.fontLoaded30Bold);
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 5); // Adjust the Y position
                ImGui.Text($"{FontAwesome5.Cube}");
                ImGui.PopFont();

                ImGui.SameLine();
                
                // check if iseneable:
                bool isEnable = _selectedGameObject.IsEnable;
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() - 3); // Adjust the Y position
                ImGui.Checkbox($"##{_selectedGameObject.Name} isEnable", ref isEnable);
                _selectedGameObject.IsEnable = isEnable;
                
                ImGui.SameLine();
                
                // name of the object
                commandBufferName = Marshal.StringToHGlobalAnsi(_selectedGameObject.Name);
                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() - 3); // Adjust the Y position
                if (ImGui.InputText("##Name",  commandBufferName, 256))
                {
                    _selectedGameObject.Name = Marshal.PtrToStringAnsi(commandBufferName);
                }
            
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() - 3); // Adjust the Y position
                ImGui.Separator();
            
                // Show Tag and Layer of the object
                ImGui.AlignTextToFramePadding();
                ImGui.Text("Tag:");
                ImGui.SameLine();

                int currentTagIndex = Array.IndexOf(tags, _selectedGameObject.Tag);
                string itemsSeparatedByZerosTags = string.Join("\0", tags);
                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X / 2 - 10);
                if (ImGui.Combo("##Tag", ref currentTagIndex, itemsSeparatedByZerosTags))
                {
                    _selectedGameObject.Tag = tags[currentTagIndex];
                }

                ImGui.SameLine();

                ImGui.AlignTextToFramePadding();
                ImGui.Text("Layer:");
                ImGui.SameLine();

                string[] layers = { "Default", "UI", "Background", "Foreground" }; // List of possible layers
                int currentLayerIndex = Array.IndexOf(layers, _selectedGameObject.Layer);
                string itemsSeparatedByZerosLayers = string.Join("\0", layers);
                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                if (ImGui.Combo("##Layer", ref currentLayerIndex, itemsSeparatedByZerosLayers))
                {
                    _selectedGameObject.Layer = layers[currentLayerIndex];
                }
            }
            ImGui.EndChild();
        }

        private void RenderTransform()
        {
            // Transform
            if (ImGui.CollapsingHeader($"{FontAwesome5.Compass} Transform", ImGuiTreeNodeFlags.DefaultOpen))
            {
                if(ImGui.BeginChild("##Transform", new Vector2(ImGui.GetContentRegionAvail().X, 105), true, ImGuiWindowFlags.NoCollapse))
                {
                    ImGui.AlignTextToFramePadding();
                    ImGui.Text("Position"); ImGui.SameLine(80);
                    Vector2 position = _selectedGameObject.Transform.Position;
                    ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                    ImGui.DragFloat2("##Position", ref position , 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);

                    ImGui.AlignTextToFramePadding();
                    ImGui.Text("Rotation"); ImGui.SameLine(80);
                    float rotation = _selectedGameObject.Transform.Rotation;
                    ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                    ImGui.DragFloat("##Rotation", ref rotation, 0.1f, -360, 360, "%.2f", ImGuiSliderFlags.AlwaysClamp);

                    ImGui.AlignTextToFramePadding();
                    ImGui.Text("Scale"); ImGui.SameLine(80);
                    Vector2 scale = _selectedGameObject.Transform.Scale;
                    ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                    ImGui.DragFloat2("##Scale", ref scale, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);

                    _selectedGameObject.Transform = new Transform(position, rotation, scale);
                }
                ImGui.EndChild();
            }
        }

        private void RenderComponents()
        {
            // Show the components of the selected game object
            foreach (AComponent component in _selectedGameObject.Components)
            {
                string icon = _componentIcons.TryGetValue(component.GetType(), out string value) ? value : FontAwesome5.File;
                bool isEnabled = component.IsEnable;

                ImGui.AlignTextToFramePadding();
                ImGui.Checkbox($"##{component.GetType().Name}Enabled", ref isEnabled);
                component.IsEnable = isEnabled;

                ImGui.SameLine();

                if (ImGui.CollapsingHeader($"{icon} {component.GetType().Name}", ImGuiTreeNodeFlags.None))
                {
                    Type typeP = component.GetType();
                    PropertyInfo[] properties = typeP.GetProperties();
                    int counter = 0;
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (properties[i].PropertyType == typeof(IntPtr) || properties[i].Name == "Name" || properties[i].Name == "Id" || properties[i].Name == "Tag" || properties[i].Name == "GameObject" || properties[i].Name == "Context" || properties[i].Name == "IsEnable")
                        {
                            continue;
                        }

                        if (properties[i].CanRead && properties[i].CanWrite)
                        {
                            counter++;
                        }
                    }

                    if (ImGui.BeginChild($"##{component.GetType().Name}", new Vector2(ImGui.GetContentRegionAvail().X, counter * 35), true, ImGuiWindowFlags.NoCollapse))
                    {
                        RenderComponentProperties(component);
                    }

                    ImGui.EndChild();
                }
            }
        }

        
        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        private void RenderComponentProperties(AComponent component)
        {
            Type typeP = component.GetType();
            PropertyInfo[] properties = typeP.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // omit propertie name, id and tag:
                if (property.PropertyType == typeof(IntPtr) || property.Name == "Name" || property.Name == "Id" || property.Name == "Tag" || property.Name == "GameObject" || property.Name == "Context" || property.Name == "IsEnable")
                {
                    continue;
                }

                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(component);
                    string propertyId = $"##{property.Name}{component.GetType().Name}";

                    ImGui.AlignTextToFramePadding();
                    ImGui.Text(property.Name);
                    ImGui.SameLine(100); // Adjust the spacing as needed

                    ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X); // Adjust the width as needed
                    
                    switch (value)
                    {
                        case float floatValue:
                            ImGui.DragFloat(propertyId, ref floatValue, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, floatValue);
                            break;
                        case double doubleValue:
                            float floatDoubleValue = (float) doubleValue;
                            ImGui.DragFloat(propertyId, ref floatDoubleValue, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, (double) floatDoubleValue);
                            break;
                        case int intValue:
                            ImGui.DragInt(propertyId, ref intValue, 1, -1000, 1000, "%d", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, intValue);
                            break;
                        case bool boolValue:
                            ImGui.Checkbox(propertyId, ref boolValue);
                            property.SetValue(component, boolValue);
                            break;
                        case Vector2 vector2Value:
                            ImGui.DragFloat2(propertyId, ref vector2Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, vector2Value);
                            break;
                        case Vector3 vector3Value:
                            ImGui.DragFloat3(propertyId, ref vector3Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, vector3Value);
                            break;
                        case Vector4 vector4Value:
                            ImGui.DragFloat4(propertyId, ref vector4Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, vector4Value);
                            break;
                        case string stringValue:
                            IntPtr stringBuffer = Marshal.StringToHGlobalAnsi(stringValue);
                            if (ImGui.InputText(propertyId, stringBuffer, 256))
                            {
                                property.SetValue(component, Marshal.PtrToStringAnsi(stringBuffer));
                            }

                            Marshal.FreeHGlobal(stringBuffer);
                            break;
                        case Enum enumValue:
                            string[] enumNames = Enum.GetNames(property.PropertyType);
                            int currentEnumIndex = Array.IndexOf(enumNames, enumValue.ToString());
                            // enumNames separated by zeros:
                            string itemsSeparatedByZeros = string.Join("\0", enumNames);
                            if (ImGui.Combo(propertyId, ref currentEnumIndex, itemsSeparatedByZeros))
                            {
                                property.SetValue(component, Enum.Parse(property.PropertyType, enumNames[currentEnumIndex]));
                            }

                            break;
                        case byte byteValue:
                            ImGui.DragScalar(propertyId, ImGuiDataType.U8,  byteValue, 1, byte.MinValue, byte.MaxValue, "%d", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, byteValue);
                            break;
                        case sbyte sbyteValue:
                            ImGui.DragScalar(propertyId, ImGuiDataType.S8,  sbyteValue, 1, sbyte.MinValue, sbyte.MaxValue, "%d", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, sbyteValue);
                            break;
                        case short shortValue:
                            ImGui.DragScalar(propertyId, ImGuiDataType.S16,  shortValue, 1, short.MinValue, short.MaxValue, "%d", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, shortValue);
                            break;
                        case ushort ushortValue:
                            ImGui.DragScalar(propertyId, ImGuiDataType.U16,  ushortValue, 1, ushort.MinValue, ushort.MaxValue, "%d", ImGuiSliderFlags.AlwaysClamp);
                            property.SetValue(component, ushortValue);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Selects the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void SelectGameObject(GameObject gameObject)
        {
            _selectedGameObject = gameObject;
        }
    }
}