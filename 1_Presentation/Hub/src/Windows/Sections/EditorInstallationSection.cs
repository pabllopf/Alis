// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EditorInstallationWindow.cs
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
using System.Diagnostics;
using Alis.App.Hub.Core;
using Alis.App.Hub.Entity;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    /// The editor installation section class
    /// </summary>
    /// <seealso cref="ASection"/>
    public class EditorInstallationSection : ASection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorInstallationSection"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public EditorInstallationSection(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        /// Installs the new version
        /// </summary>
        private void InstallNewVersion()
        { 
            Console.WriteLine("Install New Version button clicked.");
        }

        /// <summary>
        /// Reveals the in finder using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void RevealInFinder(string path)
        {
            // Open the installation path in Finder
            Process.Start(new ProcessStartInfo("open", path) {UseShellExecute = true});
        }

        /// <summary>
        /// Opens the in terminal using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void OpenInTerminal(string path)
        {
            // Open the installation path in Terminal
            Process.Start(new ProcessStartInfo("open", "-a Terminal " + path) {UseShellExecute = true});
        }

        /// <summary>
        /// Deletes the installation using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void DeleteInstallation(string path)
        {
            // Logic to delete the installation
            Console.WriteLine($"Delete installation at: {path}");
        }

        /// <summary>
        /// Ons the init
        /// </summary>
        public override void OnInit()
        {
            
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            
        }

        /// <summary>
        /// Ons the render
        /// </summary>
        public override void OnRender()
        {
            // Display a header for the section
            ImGui.Text("Installed Versions");
            ImGui.Separator();

            // Button to install new versions
            if (ImGui.Button("Install New Version"))
            {
                // Implement the logic to handle new version installation
                InstallNewVersion();
            }

            ImGui.NewLine();

            // Display a table for installed versions
            if (ImGui.BeginTable("InstallsTable", 3, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
            {
                // Setup table columns
                ImGui.TableSetupColumn("Version", ImGuiTableColumnFlags.WidthFixed, 100);
                ImGui.TableSetupColumn("Release Date", ImGuiTableColumnFlags.WidthFixed, 150);
                ImGui.TableSetupColumn("Actions", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

                // Example installed versions data
                List<InstalledVersion> installedVersions = new List<InstalledVersion>
                {
                    new InstalledVersion("1.0.0", "2023-01-15", "/path/to/version1"),
                    new InstalledVersion("1.1.0", "2023-06-10", "/path/to/version2"),
                    new InstalledVersion("2.0.0", "2024-03-05", "/path/to/version3")
                };

                // Iterate through each installed version and display in the table
                foreach (InstalledVersion version in installedVersions)
                {
                    ImGui.TableNextRow();

                    // Version column
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(version.Version);

                    // Release date column
                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(version.ReleaseDate);

                    // Actions column
                    ImGui.TableSetColumnIndex(2);

                    // Context menu for actions
                    if (ImGui.Button($"Actions##{version.Version}"))
                    {
                        ImGui.OpenPopup($"ActionsPopup##{version.Version}");
                    }

                    if (ImGui.BeginPopup($"ActionsPopup##{version.Version}"))
                    {
                        if (ImGui.MenuItem("Reveal in Finder"))
                        {
                            RevealInFinder(version.InstallPath);
                        }

                        if (ImGui.MenuItem("Open in Terminal"))
                        {
                            OpenInTerminal(version.InstallPath);
                        }

                        if (ImGui.MenuItem("Delete"))
                        {
                            DeleteInstallation(version.InstallPath);
                        }

                        ImGui.EndPopup();
                    }
                }

                ImGui.EndTable();
            }
        }

        /// <summary>
        /// Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            
        }
    }
}