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
using System.Diagnostics.CodeAnalysis;
using Alis.App.Engine.Core;

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The inspector window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class InspectorWindow : IWindow
    {
        /// <summary>
        ///     The info circle
        /// </summary>
        public static readonly string NameWindow = $"{FontAwesome5.InfoCircle} Inspector";

        /*
        // Define a dictionary to map component types to icons
        /// <summary>
        ///     The play
        /// </summary>
        private readonly Dictionary<Type, string> _componentIcons = new Dictionary<Type, string>
        {
            {typeof(Sprite), FontAwesome5.PaintBrush},
            {typeof(Animator), FontAwesome5.ShieldAlt},
            {typeof(BoxCollider), FontAwesome5.ShieldAlt},
            {typeof(Camera), FontAwesome5.Camera},
            {typeof(DirectionalLight), FontAwesome5.Lightbulb},
            {typeof(AudioSource), FontAwesome5.VolumeUp},
            {typeof(Animation), FontAwesome5.Play},
            {typeof(PointLight), FontAwesome5.Lightbulb},
            {typeof(SpotLight), FontAwesome5.Lightbulb},
            {typeof(AreaLight), FontAwesome5.Lightbulb}
        };*/

        /// <summary>
        ///     The tags
        /// </summary>
        private readonly string[] tags = {"Player", "Enemy", "NPC", "Item"};

        /// <summary>
        ///     The selected game object
        /// </summary>
        //private GameObject _selectedGameObject;

        /// <summary>
        ///     The zero
        /// </summary>
        private IntPtr commandBufferName = IntPtr.Zero;

        /// <summary>
        ///     The zero
        /// </summary>
        private IntPtr commandBufferTag = IntPtr.Zero;

        /// <summary>
        ///     The zero
        /// </summary>
        private IntPtr searchQueryComand = IntPtr.Zero;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InspectorWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public InspectorWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

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
            if (ImGui.Begin(NameWindow))
            {
                
            }

            /*if (_selectedGameObject != null)
            {
                RenderHeader();

                RenderTransform();

                RenderComponents();

                RenderAddComponentButton();
            }*/

            ImGui.End();
        }


        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Renders the add component button
        /// </summary>
        private void RenderAddComponentButton()
        {
            if (ImGui.Button("Add Component", new Vector2F(ImGui.GetContentRegionAvail().X, 30)))
            {
                ShowAddComponentPopup();
            }

            // Obtener todos los tipos de componentes en el namespace Alis.xxx
            /*Assembly assembly = Assembly.GetAssembly(typeof(AComponent))!;
            Type[] allTypes = assembly.GetTypes();
            IEnumerable<Type> componentSubclasses = allTypes.Where(t => t.IsSubclassOf(typeof(AComponent)));
            List<Type> componentTypes = componentSubclasses
                .Where(t => (t.Namespace != null) && t.IsClass && !t.IsAbstract && t.Namespace.StartsWith("Alis"))
                .ToList();

            // Agrupar componentes por namespace
            IOrderedEnumerable<IGrouping<string, Type>> groupedComponents = componentTypes
                .GroupBy(t => t.Namespace)
                .OrderBy(g => g.Key);

            ImGui.SetNextWindowSize(new Vector2F(ImGui.GetWindowWidth(), groupedComponents.Count() * 30 + 90));
            if (ImGui.BeginPopup("AddComponentPopup"))
            {
                // Campo de búsqueda

                searchQueryComand = Marshal.StringToHGlobalAnsi(searchQuery);
                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 30);
                ImGui.InputText($"{FontAwesome5.Search}##Search components", searchQueryComand, 256);
                searchQuery = Marshal.PtrToStringAnsi(searchQueryComand);

                // Filtrar componentes según la búsqueda
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    componentTypes = componentTypes
                        .Where(t => t.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }


                foreach (IGrouping<string, Type> group in groupedComponents)
                {
                    if (ImGui.CollapsingHeader(group.Key))
                    {
                        foreach (Type componentType in group)
                        {
                            if (ImGui.MenuItem(componentType.Name))
                            {
                                AddComponentToSelectedGameObject(componentType);
                            }
                        }
                    }
                }

                ImGui.EndPopup();
            }*/
        }

        /// <summary>
        ///     Shows the add component popup
        /// </summary>
        private void ShowAddComponentPopup()
        {
            ImGui.OpenPopup("AddComponentPopup");
        }


        /// <summary>
        ///     Adds a component to the selected game object
        /// </summary>
        /// <param name="componentType">The component type</param>
        private void AddComponentToSelectedGameObject([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type componentType)
        {
            /*
            if (_selectedGameObject == null)
            {
                return;
            }

            AComponent component = (AComponent) Activator.CreateInstance(componentType);
            _selectedGameObject.Add(component);*/
        }

        /// <summary>
        ///     Renderiza la sección superior del inspector con el nombre y el tag del objeto.
        /// </summary>
        private void RenderHeader()
        {
            /*
                if (_selectedGameObject == null)
                {
                    return;
                }*/

            if (ImGui.BeginChild("##Header", new Vector2F(ImGui.GetContentRegionAvail().X, 80), true, ImGuiWindowFlags.NoCollapse))
            {
                // Icon of the object:
                ImGui.PushFont(SpaceWork.FontLoaded30Bold);
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 5); // Adjust the Y position
                ImGui.Text($"{FontAwesome5.Cube}");
                ImGui.PopFont();

                ImGui.SameLine();

                /*
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
                if (ImGui.InputText("##Name", commandBufferName, 256))
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

                string[] layers = {"Default", "UI", "Background", "Foreground"}; // List of possible layers
                int currentLayerIndex = Array.IndexOf(layers, _selectedGameObject.Layer);
                string itemsSeparatedByZerosLayers = string.Join("\0", layers);
                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                if (ImGui.Combo("##Layer", ref currentLayerIndex, itemsSeparatedByZerosLayers))
                {
                    _selectedGameObject.Layer = layers[currentLayerIndex];
                }
            }
*/
                ImGui.EndChild();
            }

            /// <summary>
            ///     Renders the transform
            /// </summary>
            /*private void RenderTransform()
            {
                // Transform
                if (ImGui.CollapsingHeader($"{FontAwesome5.Compass} Transform", ImGuiTreeNodeFlags.DefaultOpen))
                {
                    if (ImGui.BeginChild("##Transform", new Vector2F(ImGui.GetContentRegionAvail().X, 105), true, ImGuiWindowFlags.NoCollapse))
                    {
                        ImGui.AlignTextToFramePadding();
                        ImGui.Text("Position");
                        ImGui.SameLine(80);
                        Vector2F position = _selectedGameObject.Transform.Position;
                        ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                        ImGui.DragFloat2("##Position", ref position, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);

                        ImGui.AlignTextToFramePadding();
                        ImGui.Text("Rotation");
                        ImGui.SameLine(80);
                        float rotation = _selectedGameObject.Transform.Rotation;
                        ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                        ImGui.DragFloat("##Rotation", ref rotation, 0.1f, -360, 360, "%.2f", ImGuiSliderFlags.AlwaysClamp);

                        ImGui.AlignTextToFramePadding();
                        ImGui.Text("Scale");
                        ImGui.SameLine(80);
                        Vector2F scale = _selectedGameObject.Transform.Scale;
                        ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X);
                        ImGui.DragFloat2("##Scale", ref scale, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);

                        _selectedGameObject.Transform = new Transform(position, rotation, scale);
                    }

                    ImGui.EndChild();
                }
            }

            /// <summary>
            ///     Renders the components
            /// </summary>
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

                        if (ImGui.BeginChild($"##{component.GetType().Name}", new Vector2F(ImGui.GetContentRegionAvail().X, counter * 35), true, ImGuiWindowFlags.NoCollapse))
                        {
                            RenderComponentProperties(component);
                        }

                        ImGui.EndChild();
                    }
                }
            }

            /// <summary>
            ///     Renders the component properties using the specified component
            /// </summary>
            /// <param name="component">The component</param>
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
                            case Vector2F vector2Value:
                                ImGui.DragFloat2(propertyId, ref vector2Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                                property.SetValue(component, vector2Value);
                                break;
                            case Vector3F vector3Value:
                                ImGui.DragFloat3(propertyId, ref vector3Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                                property.SetValue(component, vector3Value);
                                break;
                            case Vector4F vector4Value:
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
                                ImGui.DragScalar(propertyId, ImGuiDataType.U8, new IntPtr(byteValue), 1, new IntPtr(byte.MinValue), new IntPtr(byte.MaxValue), "%d", ImGuiSliderFlags.AlwaysClamp);
                                property.SetValue(component, byteValue);
                                break;
                            case sbyte sbyteValue:
                                ImGui.DragScalar(propertyId, ImGuiDataType.S8, new IntPtr(sbyteValue), 1, new IntPtr(sbyte.MinValue), new IntPtr(sbyte.MaxValue), "%d", ImGuiSliderFlags.AlwaysClamp);
                                property.SetValue(component, sbyteValue);
                                break;
                            case short shortValue:
                                ImGui.DragScalar(propertyId, ImGuiDataType.S16, new IntPtr(shortValue), 1, new IntPtr(short.MinValue), new IntPtr(short.MaxValue), "%d", ImGuiSliderFlags.AlwaysClamp);
                                property.SetValue(component, shortValue);
                                break;
                            case ushort ushortValue:
                                ImGui.DragScalar(propertyId, ImGuiDataType.U16, new IntPtr(ushortValue), 1, new IntPtr(ushort.MinValue), new IntPtr(ushort.MaxValue), "%d", ImGuiSliderFlags.AlwaysClamp);
                                property.SetValue(component, ushortValue);
                                break;
                        }
                    }
                }
            }

            /// <summary>
            ///     Selects the game object using the specified game object
            /// </summary>
            /// <param name="gameObject">The game object</param>
            public void SelectGameObject(GameObject gameObject)
            {
                _selectedGameObject = gameObject;
            }*/
        }
    }
}