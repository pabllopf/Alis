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
using System.Runtime.InteropServices;
using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Desktop.Windows
{
    /// <summary>
    ///     The inspector window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class SearchAdvanceWindow : IWindow
    {
        /// <summary>
        ///     The info circle
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Search} Search Advance";
        
        /// <summary>
        /// The is open
        /// </summary>
        private bool _isOpen = false;

        private string searchText;
        private IntPtr commandPtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InspectorWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SearchAdvanceWindow(SpaceWork spaceWork)
        {
            this.SpaceWork = spaceWork;
            commandPtr = Marshal.AllocHGlobal(256); // Allocate memory for the command input
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

            // get color from ImGui
            // Set the style color for the window background without pushstyle
            ref ImGuiStyle style = ref ImGui.GetStyle();
            style[(int) ImGuiCol.WindowBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);


            // Set the window to be fixed in size and centered
            Vector2F windowSize = new Vector2F(600, 400);
            Vector2F windowPos = ImGui.GetIo().DisplaySize * 0.5f - windowSize * 0.5f;
            ImGui.SetNextWindowSize(windowSize, ImGuiCond.Always);
            ImGui.SetNextWindowPos(windowPos, ImGuiCond.Always);

            if (ImGui.Begin(NameWindow, ref _isOpen, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoSavedSettings))
            {
                // Search bar
                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 30); // Adjust width to fit the window
                if (ImGui.InputText($"{FontAwesome5.Search}##SearchButton-{nameof(SearchAdvanceWindow)}", commandPtr, 256, ImGuiInputTextFlags.AlwaysOverwrite))
                {
                    searchText = Marshal.PtrToStringAnsi(commandPtr);
                    Logger.Info(searchText);
                }

                ImGui.Separator();

                // Placeholder for search results
                ImGui.Text("Results:");

                // Simulate search results (replace with actual search logic)
                string[] results = { "Asset: Player.prefab", "Config: Graphics Settings", "Documentation: How to use Alis Engine" };

                foreach (var result in results)
                {
                    if (ImGui.Selectable(result))
                    {
                        HandleSearchResultClick(result);
                    }
                }
            }

            ImGui.End();
            
            if (_isOpen)
            {
                style[(int) ImGuiCol.WindowBg] = new Vector4F(0.5f, 0.5f, 0.5f, 1.0f);
            }
           
            
        }

        private void HandleSearchResultClick(string result)
        {
            if (result.StartsWith("Asset:"))
            {
                Console.WriteLine($"Opening asset: {result.Substring(7)}");
                // Logic to open the asset
            }
            else if (result.StartsWith("Config:"))
            {
                Console.WriteLine($"Navigating to config: {result.Substring(8)}");
                // Logic to navigate to the configuration
            }
            else if (result.StartsWith("Documentation:"))
            {
                string url = "https://www.alisengine.com/";
                Console.WriteLine($"Redirecting to documentation: {url}");
                System.Diagnostics.Process.Start(url);
            }
        }

        public void Open() => _isOpen = true;
    }
}