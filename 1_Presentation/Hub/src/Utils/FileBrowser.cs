// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileBrowser.cs
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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Alis.App.Hub.Core;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Hub.Utils
{
    /// <summary>
    ///     The file browser class
    /// </summary>
    public class FileBrowser
    {
        /// <summary>
        ///     The list
        /// </summary>
        private readonly List<string> directoryContents = new List<string>();

        /// <summary>
        ///     The stack
        /// </summary>
        private readonly Stack<string> forwardHistory = new Stack<string>();

        /// <summary>
        ///     The is searching directory
        /// </summary>
        private readonly bool IsSearchingDirectory = false;

        /// <summary>
        ///     The is searching file
        /// </summary>
        private readonly bool IsSearchingFile = false;

        /// <summary>
        ///     The stack
        /// </summary>
        private readonly Stack<string> navigationHistory = new Stack<string>();

        /// <summary>
        ///     The search extension
        /// </summary>
        private readonly string SearchExtension = "";

        /// <summary>
        ///     The search file
        /// </summary>
        private readonly string SearchFile = "";

        /// <summary>
        ///     The search path
        /// </summary>
        private readonly string SearchPath = "";

        /// <summary>
        ///     The user profile
        /// </summary>
        private string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        ///     The empty
        /// </summary>
        private string searchQuery2 = string.Empty;

        /// <summary>
        ///     The zero
        /// </summary>
        private IntPtr searchQuery2Ptr = IntPtr.Zero;

        /// <summary>
        ///     The show file browser popup
        /// </summary>
        private bool showFileBrowserPopup;

        /// <summary>
        ///     The show hidden files
        /// </summary>
        private bool showHiddenFiles;

        /// <summary>
        ///     The space work
        /// </summary>
        private SpaceWork spaceWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileBrowser" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public FileBrowser(SpaceWork spaceWork) => this.spaceWork = spaceWork;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            Console.WriteLine("FileBrowser:OnInit");
            Console.WriteLine($"FileBrowser:OnInit:SearchPath:{SearchPath}");
            Console.WriteLine($"FileBrowser:OnInit:SearchFile:{SearchFile}");
            Console.WriteLine($"FileBrowser:OnInit:SearchExtension:{SearchExtension}");
            Console.WriteLine($"FileBrowser:OnInit:IsSearchingFile:{IsSearchingFile}");
            Console.WriteLine($"FileBrowser:OnInit:IsSearchingDirectory:{IsSearchingDirectory}");
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart()
        {
        }

        /// <summary>
        ///     Ons the render
        /// </summary>
        public void OnRender()
        {
            ImGui.SetNextWindowSize(new Vector2F(600, 400));
            ImGui.SetNextWindowPos(new Vector2F(ImGui.GetIo().DisplaySize.X / 2 - 300, ImGui.GetIo().DisplaySize.Y / 2 - 200));
            if (ImGui.BeginPopupModal("File Browser", ref showFileBrowserPopup, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove))
            {
                RenderNavigationBar();
                ImGui.Separator();
                RenderSidebar();
                ImGui.SameLine();
                RenderDirectoryContents();
                ImGui.Separator();
                RenderBottomButtons();
                ImGui.EndPopup();
            }
        }

        /// <summary>
        ///     Opens the file browser
        /// </summary>
        public void OpenFileBrowser()
        {
            ImGui.OpenPopup("File Browser");
        }

        /// <summary>
        ///     Sets the search directory using the specified directory
        /// </summary>
        /// <param name="directory">The directory</param>
        public void SetSearchDirectory(string directory)
        {
        }

        /// <summary>
        ///     Sets the search file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="extension">The extension</param>
        public void SetSearchFile(string file, string extension)
        {
        }

        /// <summary>
        ///     Renders the bottom buttons
        /// </summary>
        private void RenderBottomButtons()
        {
            if (ImGui.Button("Select"))
            {
                // Logic to handle the selection of the directory or file
                showFileBrowserPopup = false;
            }

            ImGui.SameLine();

            if (ImGui.Button("Cancel"))
            {
                showFileBrowserPopup = false;
            }

            ImGui.SameLine();

            if (ImGui.Button("View Options"))
            {
                ImGui.OpenPopup("ViewOptionsPopup");
            }

            if (ImGui.BeginPopup("ViewOptionsPopup"))
            {
                if (ImGui.MenuItem("Show Hidden Files", "", ref showHiddenFiles))
                {
                    UpdateDirectoryContents();
                }

                ImGui.EndPopup();
            }
        }

        /// <summary>
        ///     Renders the navigation bar
        /// </summary>
        private void RenderNavigationBar()
        {
            if (ImGui.Button("Back") && (navigationHistory.Count > 0))
            {
                forwardHistory.Push(currentPath);
                currentPath = navigationHistory.Pop();
                UpdateDirectoryContents();
            }

            ImGui.SameLine();

            if (ImGui.Button("Forward") && (forwardHistory.Count > 0))
            {
                navigationHistory.Push(currentPath);
                currentPath = forwardHistory.Pop();
                UpdateDirectoryContents();
            }

            ImGui.SameLine();

            ImGui.SetNextItemWidth(400);
            searchQuery2Ptr = Marshal.StringToHGlobalAnsi(searchQuery2);
            if (ImGui.InputText("##Search", searchQuery2Ptr, 256))
            {
                searchQuery2 = Marshal.PtrToStringAnsi(searchQuery2Ptr);
                UpdateDirectoryContents();
            }
        }

        /// <summary>
        ///     Renders the sidebar
        /// </summary>
        private void RenderSidebar()
        {
            ImGui.BeginChild("Sidebar", new Vector2F(200, 0), true);
            if (ImGui.Selectable("Home", currentPath == Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)))
            {
                navigationHistory.Push(currentPath);
                currentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                UpdateDirectoryContents();
            }

            if (ImGui.Selectable("Documents", currentPath == Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
            {
                navigationHistory.Push(currentPath);
                currentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                UpdateDirectoryContents();
            }

            if (ImGui.Selectable("Downloads", currentPath == Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads"))
            {
                navigationHistory.Push(currentPath);
                currentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Downloads";
                UpdateDirectoryContents();
            }

            ImGui.EndChild();
        }

        /// <summary>
        ///     Renders the directory contents
        /// </summary>
        private void RenderDirectoryContents()
        {
            ImGui.BeginChild("DirectoryContents", new Vector2F(0, 0), true);
            foreach (string item in directoryContents)
            {
                if (Directory.Exists(item))
                {
                    if (ImGui.Selectable(Path.GetFileName(item) + "/", false, ImGuiSelectableFlags.DontClosePopups))
                    {
                        navigationHistory.Push(currentPath);
                        currentPath = item;
                        UpdateDirectoryContents();
                    }
                }
                else
                {
                    ImGui.Text(Path.GetFileName(item));
                }
            }

            ImGui.EndChild();
        }

        /// <summary>
        ///     Updates the directory contents
        /// </summary>
        private void UpdateDirectoryContents()
        {
            directoryContents.Clear();
            try
            {
                directoryContents.AddRange(Directory.GetDirectories(currentPath));
                directoryContents.AddRange(Directory.GetFiles(currentPath).Where(f =>
                    (showHiddenFiles || !Path.GetFileName(f).StartsWith(".")) &&
                    (string.IsNullOrEmpty(searchQuery2) || Path.GetFileName(f).Contains(searchQuery2, StringComparison.OrdinalIgnoreCase))));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating directory contents: " + ex.Message);
            }
        }
    }
}