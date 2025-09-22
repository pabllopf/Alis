// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingsWindow.cs
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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;


using Alis.Extension.Graphic.Ui;

namespace Alis.App.Engine.Windows.Settings
{
    /// <summary>
    ///     The settings window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class SettingsWindow : IWindow
    {
        /// <summary>
        ///     The music
        /// </summary>
        private static readonly string WindowName = $"{FontAwesome5.Wrench} Settings";

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingsWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SettingsWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

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
            if (!isOpen)
            {
                return;
            }

            /*
            object[] settings =
            {
                SpaceWork.VideoGame.Context.Setting.General,
                SpaceWork.VideoGame.Context.Setting.Graphic,
                SpaceWork.VideoGame.Context.Setting.Audio,
                SpaceWork.VideoGame.Context.Setting.Input,
                SpaceWork.VideoGame.Context.Setting.Network,
                SpaceWork.VideoGame.Context.Setting.Physic,
                SpaceWork.VideoGame.Context.Setting.Scene
            };*/

            if (ImGui.Begin(WindowName, ref isOpen))
            {
                //RenderSettings(settings);
            }

            ImGui.End();
        }

        /// <summary>
        ///     Renders the settings using the specified settings
        /// </summary>
        /// <param name="settings">The settings</param>
        private void RenderSettings(object[] settings)
        {
            foreach (object setting in settings)
            {
                string headerName = setting.GetType().Name;
                if (ImGui.CollapsingHeader(headerName))
                {
                    PropertyInfo[] properties = setting.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    int propertyCount = properties.Count(property => property.CanWrite && (property.GetValue(setting) != null));

                    if (ImGui.BeginChild($"##{headerName}Child", new Vector2F(ImGui.GetContentRegionAvail().X, propertyCount * 36), true, ImGuiWindowFlags.NoCollapse))
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            object value = property.GetValue(setting);
                            string uniqueId = $"{property.Name}##{headerName}";

                            bool isJsonIgnored = property.GetCustomAttributes(typeof(JsonIgnoreAttribute), true).Any();

                            if (property.CanWrite || isJsonIgnored)
                            {
                                ImGui.AlignTextToFramePadding();
                                ImGui.Text(property.Name);
                                ImGui.SameLine(100); // Adjust the spacing as needed

                                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X); // Adjust the width as needed

                                if (isJsonIgnored)
                                {
                                    ImGui.BeginDisabled();
                                }

                                switch (value)
                                {
                                    case int intValue:
                                        int uniqueInt = intValue;
                                        ImGui.DragInt(uniqueId, ref uniqueInt, 1f, -1000, 1000);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, uniqueInt);
                                        }

                                        break;
                                    case float floatValue:
                                        ImGui.DragFloat(uniqueId, ref floatValue, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, floatValue);
                                        }

                                        break;
                                    case bool boolValue:
                                        ImGui.Checkbox(uniqueId, ref boolValue);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, boolValue);
                                        }

                                        break;
                                    case Vector2F vector2Value:
                                        ImGui.DragFloat2(uniqueId, ref vector2Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, vector2Value);
                                        }

                                        break;
                                    case Vector3F vector3Value:
                                        ImGui.DragFloat3(uniqueId, ref vector3Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, vector3Value);
                                        }

                                        break;
                                    case Vector4F vector4Value:
                                        ImGui.DragFloat4(uniqueId, ref vector4Value, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, vector4Value);
                                        }

                                        break;
                                    case string stringValue:
                                        IntPtr commandPtr = Marshal.StringToHGlobalAnsi(stringValue);
                                        ImGui.InputText(uniqueId, commandPtr, 256, ImGuiInputTextFlags.AlwaysOverwrite);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, Marshal.PtrToStringAnsi(commandPtr));
                                        }

                                        break;
                                    case Color color:
                                        Vector4F colorValue = new Vector4F(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);
                                        IntPtr commandPtr2 = Marshal.StringToHGlobalAnsi(uniqueId);
                                        ImGui.ColorEdit4(commandPtr2, ref colorValue, ImGuiColorEditFlags.DisplayRgb | ImGuiColorEditFlags.Uint8);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, new Color((byte) (colorValue.X * 255), (byte) (colorValue.Y * 255), (byte) (colorValue.Z * 255), (byte) (colorValue.W * 255)));
                                        }

                                        break;
                                    case Enum enumValue:
                                        string[] enumNames = Enum.GetNames(property.PropertyType);
                                        int currentEnumIndex = Array.IndexOf(enumNames, enumValue.ToString());
                                        string itemsSeparatedByZeros = string.Join("\0", enumNames);
                                        if (ImGui.Combo(uniqueId, ref currentEnumIndex, itemsSeparatedByZeros))
                                        {
                                            if (!isJsonIgnored)
                                            {
                                                property.SetValue(setting, Enum.Parse(property.PropertyType, enumNames[currentEnumIndex]));
                                            }
                                        }

                                        break;
                                    case double doubleValue:
                                        float floatValue2 = (float) doubleValue;
                                        ImGui.DragFloat(uniqueId, ref floatValue2, 0.1f, -1000, 1000, "%.2f", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, floatValue2);
                                        }

                                        break;
                                    case sbyte sbyteValue:
                                        ImGui.DragScalar(uniqueId, ImGuiDataType.S8, new IntPtr(sbyteValue), 1, new IntPtr(sbyte.MinValue), new IntPtr(sbyte.MaxValue), "%d", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, sbyteValue);
                                        }

                                        break;
                                    case byte byteValue:
                                        ImGui.DragScalar(uniqueId, ImGuiDataType.U8, new IntPtr(byteValue), 1, new IntPtr(byte.MinValue), new IntPtr(byte.MaxValue), "%d", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, byteValue);
                                        }

                                        break;
                                    case short shortValue:
                                        ImGui.DragScalar(uniqueId, ImGuiDataType.S16, new IntPtr(shortValue), 1, new IntPtr(short.MinValue), new IntPtr(short.MaxValue), "%d", ImGuiSliderFlags.AlwaysClamp);
                                        if (!isJsonIgnored)
                                        {
                                            property.SetValue(setting, shortValue);
                                        }

                                        break;
                                    default:
                                        ImGui.Text($"{property.Name}: {value}");
                                        break;
                                }

                                if (isJsonIgnored)
                                {
                                    ImGui.EndDisabled();
                                }
                            }
                            else
                            {
                                ImGui.Text($"{property.Name}: {value}");
                            }
                        }
                    }

                    ImGui.EndChild();
                }
            }
        }
    }
}