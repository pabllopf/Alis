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
using System.Runtime.InteropServices;
using Alis.App.Engine.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The preferences window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class PreferencesWindow : IWindow
    {
        /// <summary>
        /// The cog
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Cog} Preferences";
        /// <summary>
        /// The is open
        /// </summary>
        private bool _isOpen = false;

        // Current selected node in the tree menu
        /// <summary>
        /// The selected node
        /// </summary>
        private string _selectedNode = "General";

        // Tree menu structure
        /// <summary>
        /// The list
        /// </summary>
        private readonly Dictionary<string, List<string>> _menuTree = new Dictionary<string, List<string>>
        {
            { "General", new List<string>() },
            { "Graphics", new List<string> { "Rendering", "Quality" } },
            { "Input", new List<string> { "Key Bindings", "Controllers" } },
            { "Audio", new List<string> { "Volume", "Output Devices" } },
            { "Plugins", new List<string>() },
            { "Advanced", new List<string> { "Scripting", "Debugging" } }
        };
        
        /// <summary>
        /// The command ptr
        /// </summary>
        private IntPtr commandPtr;
        /// <summary>
        /// The empty
        /// </summary>
        private string searchText = string.Empty;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InspectorWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public PreferencesWindow(SpaceWork spaceWork)
        {
            this.SpaceWork = spaceWork;
            commandPtr = Marshal.AllocHGlobal(256);
        }

        /// <summary>
        /// Gets the value of the space work
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
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            if (!_isOpen)
            {
                return;
            }

            // Center the window and set its initial size
            ImGui.SetNextWindowSize(new Vector2F(800, 400), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowPos(new Vector2F((ImGui.GetIo().DisplaySize.X - 800) / 2, (ImGui.GetIo().DisplaySize.Y - 400) / 2), ImGuiCond.FirstUseEver);
            
            if (ImGui.Begin(NameWindow, ref _isOpen, ImGuiWindowFlags.NoCollapse))
            {
                // Set the left column to occupy 1/4 of the window width
                ImGui.Columns(2, "PreferencesColumns", true);
                ImGui.SetColumnWidth(0, ImGui.GetWindowWidth() * 0.25f);

                // Render the search bar and tree menu on the left
                RenderSearchBar();
                RenderTreeMenu();

                ImGui.NextColumn();

                // Render the content based on the selected node
                RenderContent();

                ImGui.Columns(1);
            }

            ImGui.End();
        }

        /// <summary>
        /// Renders the search bar
        /// </summary>
        private void RenderSearchBar()
        {
            ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 30);
            if (ImGui.InputText($"{FontAwesome5.Search}##SearchButton-{nameof(PreferencesWindow)}", commandPtr, 256, ImGuiInputTextFlags.AlwaysOverwrite))
            {
                searchText = Marshal.PtrToStringAnsi(commandPtr);
                Logger.Info(searchText);
            }
            ImGui.Separator();
        }

        /// <summary>
        /// Renders the tree menu
        /// </summary>
        private void RenderTreeMenu()
        {
            foreach (KeyValuePair<string, List<string>> category in _menuTree)
            {
                if (string.IsNullOrEmpty(searchText) || category.Key.ToLower().Contains(searchText.ToLower()))
                {
                    if (ImGui.TreeNodeEx(category.Key, ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.Framed))
                    {
                        foreach (string subItem in category.Value)
                        {
                            if (string.IsNullOrEmpty(searchText) || subItem.ToLower().Contains(searchText.ToLower()))
                            {
                                if (ImGui.Selectable(subItem, _selectedNode == subItem))
                                {
                                    _selectedNode = subItem;
                                }
                            }
                        }

                        ImGui.TreePop();
                    }
                    else if (ImGui.Selectable(category.Key, _selectedNode == category.Key))
                    {
                        _selectedNode = category.Key;
                    }
                }
            }
        }

        /// <summary>
        /// Renders the content
        /// </summary>
        private void RenderContent()
        {
            ImGui.Text($"Settings for: {_selectedNode}");

            switch (_selectedNode)
            {
                case "General":
                    RenderGeneralSettings();
                    break;
                case "Rendering":
                    RenderRenderingSettings();
                    break;
                case "Quality":
                    RenderQualitySettings();
                    break;
                case "Key Bindings":
                    RenderKeyBindingsSettings();
                    break;
                case "Controllers":
                    RenderControllerSettings();
                    break;
                case "Volume":
                    RenderVolumeSettings();
                    break;
                case "Output Devices":
                    RenderOutputDeviceSettings();
                    break;
                case "Scripting":
                    RenderScriptingSettings();
                    break;
                case "Debugging":
                    RenderDebuggingSettings();
                    break;
                default:
                    ImGui.Text("No settings available for this category.");
                    break;
            }
        }

        /// <summary>
        /// Renders the general settings
        /// </summary>
        private void RenderGeneralSettings()
        {
            ImGui.Text("General settings go here.");
        }

        /// <summary>
        /// Renders the rendering settings
        /// </summary>
        private void RenderRenderingSettings()
        {
            ImGui.Text("Rendering settings go here.");
        }

        /// <summary>
        /// Renders the quality settings
        /// </summary>
        private void RenderQualitySettings()
        {
            ImGui.Text("Quality settings go here.");
        }

        /// <summary>
        /// Renders the key bindings settings
        /// </summary>
        private void RenderKeyBindingsSettings()
        {
            ImGui.Text("Key bindings settings go here.");
        }

        /// <summary>
        /// Renders the controller settings
        /// </summary>
        private void RenderControllerSettings()
        {
            ImGui.Text("Controller settings go here.");
        }

        /// <summary>
        /// Renders the volume settings
        /// </summary>
        private void RenderVolumeSettings()
        {
            ImGui.Text("Volume settings go here.");
        }

        /// <summary>
        /// Renders the output device settings
        /// </summary>
        private void RenderOutputDeviceSettings()
        {
            ImGui.Text("Output device settings go here.");
        }

        /// <summary>
        /// Renders the scripting settings
        /// </summary>
        private void RenderScriptingSettings()
        {
            ImGui.Text("Scripting settings go here.");
        }

        /// <summary>
        /// Renders the debugging settings
        /// </summary>
        private void RenderDebuggingSettings()
        {
            ImGui.Text("Debugging settings go here.");
        }

        /// <summary>
        /// The open
        /// </summary>
        public void Open() => _isOpen = true;
    }
}