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

using System.IO;
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
    public class GitWindow : IWindow
    {
        /// <summary>
        /// The code
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Code} Git";

        /// <summary>
        /// The is open
        /// </summary>
        private bool _isOpen = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitWindow"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public GitWindow(SpaceWork spaceWork)
        {
            this.SpaceWork = spaceWork;
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

            if (ImGui.Begin(NameWindow, ref _isOpen, ImGuiWindowFlags.NoCollapse))
            {
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);

                // Check if Git is installed
                if (!GitIntegration.IsGitInstalled())
                {
                    ImGui.Text("Git is not installed on this system.");
                }
                else
                {
                    // Check if the current directory is a Git repository
                    string currentDirectory = Directory.GetCurrentDirectory();
                    if (!GitIntegration.IsGitRepository(currentDirectory))
                    {
                        ImGui.Text("This project is not a Git repository.");
                        if (ImGui.Button("Initialize Git Repository"))
                        {
                            GitIntegration.ExecuteGitCommand("init", currentDirectory);
                        }
                    }
                    else
                    {
                        ImGui.Text("Git Controls");

                        if (ImGui.Button("Commit"))
                        {
                            GitIntegration.ExecuteGitCommand("commit -m \"Default commit message\"", currentDirectory);
                        }

                        if (ImGui.Button("Push"))
                        {
                            GitIntegration.ExecuteGitCommand("push", currentDirectory);
                        }

                        if (ImGui.Button("Pull"))
                        {
                            GitIntegration.ExecuteGitCommand("pull", currentDirectory);
                        }

                        if (ImGui.Button("Fetch"))
                        {
                            GitIntegration.ExecuteGitCommand("fetch", currentDirectory);
                        }

                        if (ImGui.Button("Status"))
                        {
                            string status = GitIntegration.ExecuteGitCommand("status", currentDirectory);
                            ImGui.TextWrapped(status);
                        }
                    }
                }

                ImGui.PopStyleVar();
                ImGui.PopStyleColor(2);
            }

            ImGui.End();
        }
    }
}