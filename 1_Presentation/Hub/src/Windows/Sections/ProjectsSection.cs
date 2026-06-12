// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProjectsSection.cs
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
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using Alis.App.Hub.Core;
using Alis.App.Hub.Entity;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;
using Alis.Extension.Io.FileDialog;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The projects section class
    /// </summary>
    /// <seealso cref="ASection" />
    public class ProjectsSection : ASection
    {
        /// <summary>
        /// The not connected status
        /// </summary>
        private const string NotConnectedStatus = "NOT CONNECTED";

        /// <summary>
        /// Gets the sample path
        /// </summary>
        /// <returns>The string</returns>
        private static string GetSamplePath() =>
            Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,
                "..", "..", "..", "..", "..",
                "1_Presentation", "Engine", "sample", "alis.app.engine.sample"));

#if DEBUG
        private List<Project> projects = new List<Project>
        {
            new Project("MacOS Project", GetSamplePath(), NotConnectedStatus, "3 days ago", "v1.5.0"),
            new Project("MacOS Project (latest)", GetSamplePath(), NotConnectedStatus, "3 days ago", "v1.0.5")
        };
#else
        /// <summary>
        /// The not connected status
        /// </summary>
        private List<Project> projects = new List<Project>
        {
            new Project("MacOS Project (latest)", GetSamplePath(), NotConnectedStatus, "3 days ago", "v0.9.0"),
            new Project("Windows Project", GetSamplePath(), NotConnectedStatus, "5 minutes ago", "v0.9.0")
        };
#endif


        /// <summary>
        ///     The selected project index
        /// </summary>
        private int selectedProjectIndex = -1;

        /// <summary>
        ///     The show create project popup
        /// </summary>
        private bool showCreateProjectPopup;
        
        /// <summary>
        ///     The empty
        /// </summary>
        private string searchQuery = string.Empty;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectsSection" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ProjectsSection(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        ///     Opens the project using the specified project
        /// </summary>
        /// <param name="project">The project</param>
        private void OpenProject(Project project)
        {
            Logger.Info($"Opening project: {project.Name}");

            string projectConfig = JsonNativeAot.Serialize(project);
            string configFilePath = Path.Combine(Path.GetTempPath(), "projectConfig.json");
            File.WriteAllText(configFilePath, projectConfig);

            string enginePath = GetEnginePath(project.EditorVersion);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = enginePath,
                Arguments = configFilePath,
                UseShellExecute = true,
                CreateNoWindow = true
            };

            Task.Run(() =>
            {
                using (Process process = Process.Start(startInfo))
                {
                    process?.WaitForExit();
                }
            });
        }

        /// <summary>
        ///     Gets the engine path using the specified editor version
        /// </summary>
        /// <param name="editorVersion">The editor version</param>
        /// <returns>The engine path</returns>
        private static string GetEnginePath(string editorVersion)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string editorPath = Path.Combine(basePath, "Editor", editorVersion);
            string searchPattern = OperatingSystem.IsWindows() ? "Alis.App.Engine.exe" : "Alis.App.Engine";

            string[] files = Directory.GetFiles(editorPath, searchPattern, SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                throw new FileNotFoundException($"Engine executable not found in {editorPath}");
            }

            return files[0];
        }

        /// <summary>
        ///     Reveals the in finder using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void RevealInFinder(string path)
        {
            ValidateFilePath(path);
            Process.Start(new ProcessStartInfo("open", path) { UseShellExecute = true });
        }

        /// <summary>
        ///     Opens the in terminal using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        private void OpenInTerminal(string path)
        {
            ValidateFilePath(path);
            Process.Start(new ProcessStartInfo("open", "-a Terminal " + path) { UseShellExecute = true });
        }

        /// <summary>
        ///     Validates that a file path is safe to use with shell commands
        /// </summary>
        /// <param name="path">The path to validate</param>
        private static void ValidateFilePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));
            }

            string[] dangerousChars = { ";", "|", "&", "$", "`", "(", ")", "{", "}", "<", ">", "?", "*", "[", "]", "\\", "\"" };
            foreach (string charSeq in dangerousChars)
            {
                if (path.Contains(charSeq))
                {
                    throw new SecurityException($"Path contains potentially dangerous characters: {charSeq}");
                }
            }
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
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
        public override void OnRender(float scale)
        {
            float buttonWidth = 75 * scale;
            float elementHeight = 30 * scale;
            float spaceBetween = 10 * scale;

            ImGui.Separator();
            ImGui.Spacing();

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(spaceBetween, 20 * scale));

            RenderSearchBar(buttonWidth, elementHeight, spaceBetween);

            ImGui.PopStyleVar(2);
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - (elementHeight - ImGui.GetTextLineHeight()) / 2);
            ImGui.Separator();

            ImGui.PushStyleVar(ImGuiStyleVar.CellPadding, new Vector2F(10, 15));

            RenderProjectTable(elementHeight);

            ImGui.PopStyleVar(1);
        }

        /// <summary>
        ///     Renders the search bar using the specified button width
        /// </summary>
        /// <param name="buttonWidth">The button width</param>
        /// <param name="elementHeight">The element height</param>
        /// <param name="spaceBetween">The space between</param>
        private void RenderSearchBar(float buttonWidth, float elementHeight, float spaceBetween)
        {
            float searchBarWidth = ImGui.GetContentRegionAvail().X - (buttonWidth * 4 + spaceBetween * 2);
            float iconHeight = ImGui.GetTextLineHeight();
            float verticalOffset = (elementHeight - iconHeight) / 2;

            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + verticalOffset + 10);
            ImGui.Text($"{FontAwesome5.Search}");

            ImGui.SameLine();
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            ImGui.SetNextItemWidth(searchBarWidth);

            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(5, (elementHeight - iconHeight) / 2));

            IntPtr searchPtr = Marshal.StringToHGlobalAnsi(searchQuery);
            if (ImGui.InputText("##Search", searchPtr, 256))
            {
                searchQuery = Marshal.PtrToStringAnsi(searchPtr);
                Logger.Info("Search query: " + searchQuery);
            }

            Marshal.FreeHGlobal(searchPtr);

            ImGui.PopStyleVar(1);
            ImGui.SameLine();
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 5.0f);

            RenderButtons(buttonWidth, elementHeight, verticalOffset);
        }

        /// <summary>
        ///     Renders the buttons using the specified button width
        /// </summary>
        /// <param name="buttonWidth">The button width</param>
        /// <param name="elementHeight">The element height</param>
        /// <param name="verticalOffset">The vertical offset</param>
        private void RenderButtons(float buttonWidth, float elementHeight, float verticalOffset)
        {
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            if (ImGui.Button("Create", new Vector2F(buttonWidth, elementHeight)))
            {
                CreateProject();
            }

            RenderCreateProjectPopup();

            ImGui.SameLine();
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            _ = ImGui.Button("Import", new Vector2F(buttonWidth, elementHeight));

            ImGui.SameLine();
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() - verticalOffset);
            _ = ImGui.Button("Clone", new Vector2F(buttonWidth, elementHeight));
        }

        /// <summary>
        ///     Creates the project
        /// </summary>
        private static void CreateProject()
        {
            ImGui.OpenPopup("New Project");
        }

        /// <summary>
        ///     The empty
        /// </summary>
        private string projectName = string.Empty;

        /// <summary>
        ///     The empty
        /// </summary>
        private string projectPath = string.Empty;

        /// <summary>
        ///     The empty
        /// </summary>
        private string editorVersion = string.Empty;

        /// <summary>
        ///     Renders the create project popup
        /// </summary>
        private void RenderCreateProjectPopup()
        {
            ImGui.SetNextWindowSize(new Vector2F(600, 350));
            ImGui.SetNextWindowPos(new Vector2F(ImGui.GetIo().DisplaySize.X / 2 - 300, ImGui.GetIo().DisplaySize.Y / 2 - 175));
            if (ImGui.BeginPopupModal("New Project", ref showCreateProjectPopup, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove))
            {
                string name = projectName;
                IntPtr namePtr = Marshal.StringToHGlobalAnsi(name);
                ImGui.Text("Project Name:");
                ImGui.InputText("##ProjectName", namePtr, 100);
                name = Marshal.PtrToStringAnsi(namePtr) ?? name;
                Marshal.FreeHGlobal(namePtr);

                string path = projectPath;
                IntPtr pathPtr = Marshal.StringToHGlobalAnsi(path);
                ImGui.Text("Project Path:");
                ImGui.InputText("##ProjectPath", pathPtr, 256);
                path = Marshal.PtrToStringAnsi(pathPtr) ?? path;
                Marshal.FreeHGlobal(pathPtr);

                ImGui.SameLine();

                if (ImGui.Button($"{FontAwesome5.Folder}## Browse"))
                {
                    IFilePicker filePicker = FilePickerFactory.CreateFilePicker();

                    FilePickerOptions options = new FilePickerOptions
                    {
                        Title = "Select Project Folder",
                        DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        AllowMultiple = false
                    };
                    FilePickerResult selectedFile = filePicker.PickFile(options);

                    if (selectedFile.IsSuccess)
                    {
                        path = selectedFile.SelectedPath;
                        Logger.Info("Selected project path: " + path);
                    }
                }

                string version = editorVersion;
                IntPtr versionPtr = Marshal.StringToHGlobalAnsi(version);
                ImGui.Text("Editor Version:");
                ImGui.InputText("##EditorVersion", versionPtr, 50);
                version = Marshal.PtrToStringAnsi(versionPtr) ?? version;
                Marshal.FreeHGlobal(versionPtr);

                ImGui.Separator();

                if (ImGui.Button("Create"))
                {
                    projectName = name;
                    projectPath = path;
                    editorVersion = version;
                    ImGui.CloseCurrentPopup();
                }

                ImGui.SameLine();

                if (ImGui.Button("Cancel"))
                {
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }
        }

        /// <summary>
        ///     Renders the project table using the specified element height
        /// </summary>
        /// <param name="elementHeight">The element height</param>
        private void RenderProjectTable(float elementHeight)
        {
            if (ImGui.BeginTable("ProjectTable", 4, ImGuiTableFlags.Borders | ImGuiTableFlags.Resizable))
            {
                ImGui.TableSetupColumn("NAME", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("PATH", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableSetupColumn("MODIFIED", ImGuiTableColumnFlags.WidthFixed, 120);
                ImGui.TableSetupColumn("EDITOR VERSION", ImGuiTableColumnFlags.WidthFixed, 150);
                ImGui.TableHeadersRow();

                projects = projects.OrderBy(p => p.Name).ToList();

                for (int i = 0; i < projects.Count; i++)
                {
                    RenderProjectRow(i, elementHeight);
                }

                ImGui.EndTable();
            }
        }

        /// <summary>
        ///     Renders the project row using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="elementHeight">The element height</param>
        private void RenderProjectRow(int index, float elementHeight)
        {
            Project project = projects[index];
            ImGui.TableNextRow();

            ImGui.TableNextColumn();
            float rowHeight = 50;
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + (elementHeight - rowHeight) / 2);

            if (ImGui.Selectable($"##Row{index}", selectedProjectIndex == index, ImGuiSelectableFlags.SpanAllColumns | ImGuiSelectableFlags.AllowDoubleClick, new Vector2F(0, rowHeight)))
            {
                selectedProjectIndex = index;

                if (ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left))
                {
                    OpenProject(project);
                }
            }

            if (ImGui.IsItemHovered() && ImGui.IsMouseClicked(ImGuiMouseButton.Right))
            {
                ImGui.OpenPopup($"ContextMenu##{index}");
                Logger.Info("Right-clicked on project: " + project.Name);
            }

            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + (rowHeight - elementHeight) / 2);
            ImGui.SameLine();
            ImGui.TextColored(new Vector4F(1.0f, 1.0f, 1.0f, 1.0f), project.Name);

            ImGui.TableNextColumn();
            ImGui.TextColored(new Vector4F(0.7f, 0.7f, 0.7f, 1.0f), project.Path);

            ImGui.TableNextColumn();
            ImGui.TextColored(new Vector4F(0.8f, 0.8f, 0.8f, 1.0f), project.ModifiedDate);

            ImGui.TableNextColumn();
            ImGui.TextColored(new Vector4F(0.8f, 0.8f, 0.8f, 1.0f), project.EditorVersion);

            if (ImGui.BeginPopup($"ContextMenu##{index}"))
            {
                RenderContextMenu(project, index);
            }
        }

        /// <summary>
        ///     Renders the context menu using the specified project
        /// </summary>
        /// <param name="project">The project</param>
        /// <param name="index">The index</param>
        private void RenderContextMenu(Project project, int index)
        {
            if (ImGui.MenuItem("Reveal in Finder"))
            {
                RevealInFinder(project.Path);
            }

            if (ImGui.MenuItem("Open in Terminal"))
            {
                OpenInTerminal(project.Path);
            }

            if (ImGui.MenuItem("Remove from List"))
            {
                projects.RemoveAt(index);
            }

            ImGui.EndPopup();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
        }
    }
}