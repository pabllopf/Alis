// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EditorInstallationSection.cs
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
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Alis.App.Hub.Core;
using Alis.App.Hub.Entity;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;


namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The editor installation section class
    /// </summary>
    /// <seealso cref="ASection" />
    public class EditorInstallationSection : ASection
    {
        /// <summary>
        ///     The installed version
        /// </summary>
        private List<InstalledVersion> installedVersions = new List<InstalledVersion>();

        /// <summary>
        ///     The is visible
        /// </summary>
        public bool IsVisible;

        /// <summary>
        ///     The selected version index
        /// </summary>
        private int selectedVersionIndex;

        // Example dropdown for selecting version
        /// <summary>
        ///     The empty
        /// </summary>
        private string[] versions = Array.Empty<string>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="EditorInstallationSection" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public EditorInstallationSection(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        ///     Installs the new version
        /// </summary>
        private void InstallNewVersion()
        {
            ImGui.OpenPopup("Install_New_Version");
        }

        /// <summary>
        ///     Renders the install new version popup
        /// </summary>
        private void RenderInstallNewVersionPopup()
        {
            // Set size of the popup: 
            ImGui.SetNextWindowSize(new Vector2F(500, 250));
            ImGui.SetNextWindowPos(new Vector2F(ImGui.GetIo().DisplaySize.X / 2 - 250, ImGui.GetIo().DisplaySize.Y / 2 - 125));
            if (ImGui.BeginPopupModal("Install_New_Version", ref IsVisible, ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove))
            {
                ImGui.Text("Select the version to install:");
                ImGui.Separator();

                // Selector de solución
                ImGui.SetNextItemWidth(100);
                if (ImGui.BeginCombo("Version", $"{versions[selectedVersionIndex]}", ImGuiComboFlags.HeightLarge))
                {
                    for (int i = 0; i < versions.Length; i++)
                    {
                        if (ImGui.Selectable($"{versions[i]}"))
                        {
                            selectedVersionIndex = i;
                        }
                    }

                    ImGui.EndCombo();
                }

                ImGui.Separator();

                if (ImGui.Button("Install"))
                {
                    // Implement the logic to handle the installation of the selected version
                    string selectedVersion = versions[selectedVersionIndex];
                    StartInstallation(selectedVersion);
                    ImGui.CloseCurrentPopup();
                    IsVisible = false;
                }

                ImGui.SameLine();

                if (ImGui.Button("Cancel"))
                {
                    ImGui.CloseCurrentPopup();
                    IsVisible = false;
                }

                ImGui.EndPopup();
            }
        }

        /// <summary>
        ///     Starts the installation using the specified version
        /// </summary>
        /// <param name="version">The version</param>
        private void StartInstallation(string version)
        {
            string installerPath = GetInstallerPath();

            if (File.Exists(installerPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = installerPath,
                    Arguments = $"-versionToInstall \"{version}\"",
                    UseShellExecute = true
                });
            }
            else
            {
                Logger.Info("Installer not found at: " + installerPath);
            }
        }

        /// <summary>
        ///     Gets the installer path
        /// </summary>
        /// <exception cref="FileNotFoundException">Engine executable not found in {installerPath}</exception>
        /// <returns>The string</returns>
        private string GetInstallerPath()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string installerPath = Path.Combine(basePath, "Installer");
            string searchPattern = OperatingSystem.IsWindows() ? "Alis.App.Installer.exe" : "Alis.App.Installer";

            string[] files = Directory.GetFiles(installerPath, searchPattern, SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                throw new FileNotFoundException($"Engine executable not found in {installerPath}");
            }

            return files[0];
        }


        /// <summary>
        ///     Reveals the in finder using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void RevealInFinder(string path)
        {
            // Open the installation path in Finder
            Process.Start(new ProcessStartInfo("open", path) {UseShellExecute = true});
        }

        /// <summary>
        ///     Opens the in terminal using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void OpenInTerminal(string path)
        {
            // Open the installation path in Terminal
            Process.Start(new ProcessStartInfo("open", "-a Terminal " + path) {UseShellExecute = true});
        }

        /// <summary>
        ///     Deletes the installation using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void DeleteInstallation(string path)
        {
            // Delete the installation path
            Directory.Delete(path, true);
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            List<string> availableVersions = FetchAvailableVersionsAsync().Result;
            versions = availableVersions.ToArray();
        }
        
        /// <summary>
        ///     Fetches the available versions
        /// </summary>
        /// <returns>A task containing a list of string</returns>
        private async Task<List<string>> FetchAvailableVersionsAsync()
        {
            List<string> versionList = new List<string>();
            
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "request");
                string response = await client.GetStringAsync("https://api.github.com/repos/pabllopf/alis/releases");
                ReleasesInfo releases = JsonNativeAot.Deserialize<ReleasesInfo>(response);
                
                foreach (ReleaseElement release in releases.Releases)
                {
                    string version = release.Element["tag_name"]?.ToString();
                    if (!string.IsNullOrEmpty(version))
                    {
                        versionList.Add(version);
                    }
                }

                return versionList;
            }
        }

        /// <summary>
        ///     Detects the installed versions
        /// </summary>
        private void DetectInstalledVersions()
        {
            installedVersions = new List<InstalledVersion>();
            string dirProject = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Editor");
            string[] directories = Directory.GetDirectories(dirProject, "v*", SearchOption.TopDirectoryOnly);

            // Order directories by name in descending order:
            Array.Sort(directories, (a, b) => string.Compare(b, a, StringComparison.Ordinal));

            foreach (string directory in directories)
            {
                string version = Path.GetFileName(directory);
                string releaseDate = Directory.GetCreationTime(directory).ToString("yyyy-MM-dd");
                installedVersions.Add(new InstalledVersion(version, releaseDate, directory));
            }
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Ons the render
        /// </summary>
        public override void OnRender()
        {
            DetectInstalledVersions();

            // Button to install new versions
            if (ImGui.Button("Install New Version"))
            {
                // Implement the logic to handle new version installation
                InstallNewVersion();
            }

            RenderInstallNewVersionPopup();

            ImGui.NewLine();

            // Display a table for installed versions
            if (ImGui.BeginTable("InstallsTable", 3, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
            {
                // Setup table columns
                ImGui.TableSetupColumn("Version", ImGuiTableColumnFlags.WidthFixed, 100);
                ImGui.TableSetupColumn("Installation Date", ImGuiTableColumnFlags.WidthFixed, 150);
                ImGui.TableSetupColumn("Actions", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

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
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
        }
    }
}