// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TopMenu.cs
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

using Alis.App.Engine.Core;
using Alis.App.Engine.Shortcut;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    ///     The top menu class
    /// </summary>
    /// <seealso cref="IMenu" />
    public class TopMenu : IMenu
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TopMenu" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public TopMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            TopMenuAction.SetSpaceWork(SpaceWork);
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            ApplyTopMenuStyling();

            ImGui.BeginMainMenuBar();

            RenderFileMenu();
            RenderEditMenu();
            RenderAssetsMenu();
            RenderGameObjectMenu();
            RenderComponentMenu();
            RenderToolsMenu();
            RenderWindowMenu();
            RenderHelpMenu();

            ImGui.EndMainMenuBar();
            ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(3);
        }

        private static void ApplyTopMenuStyling()
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));

            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
        }

        private static void RenderFileMenu()
        {
            if (ImGui.BeginMenu("File"))
            {
                RenderMenuItem("New Scene", Shortcuts.NewScene);
                RenderMenuItem("Open Scene...", Shortcuts.OpenScene);
                ImGui.Separator();
                RenderMenuItem("Save", Shortcuts.Save);
                RenderMenuItem("Save As...", Shortcuts.SaveAs);
                ImGui.Separator();
                RenderMenuItem("New Project");
                RenderMenuItem("Open Project");
                RenderMenuItem("Save Project");
                ImGui.Separator();
                RenderMenuItem("Build Profiles");
                RenderMenuItem("Build And Run");
                ImGui.Separator();
                RenderMenuItem("Close");
                ImGui.EndMenu();
            }
        }

        private void RenderEditMenu()
        {
            if (ImGui.BeginMenu("Edit"))
            {
                RenderMenuItem("Undo", Shortcuts.Undo);
                RenderMenuItem("Redo", Shortcuts.Redo);
                ImGui.Separator();
                RenderMenuItem("Undo History");
                ImGui.Separator();
                RenderMenuItem("Select All");
                RenderMenuItem("Deselect All");
                RenderMenuItem("Select Children");
                RenderMenuItem("Select Prefab Root");
                RenderMenuItem("Invert Selection");
                RenderMenuItem("Selection Groups");
                ImGui.Separator();
                RenderMenuItem("Cut");
                RenderMenuItem("Copy");
                RenderMenuItem("Paste");
                RenderMenuItem("Paste Special");
                RenderMenuItem("Duplicate");
                RenderMenuItem("Rename");
                RenderMenuItem("Delete");
                ImGui.Separator();
                RenderMenuItem("Frame Selected in Scene");
                RenderMenuItem("Frame Selected in Window under Cursor");
                RenderMenuItem("Lock View to Selected");
                ImGui.Separator();
                RenderMenuItem("Search");
                ImGui.Separator();
                RenderMenuItem("Play", Shortcuts.Play);
                RenderMenuItem("Pause", Shortcuts.Pause);
                RenderMenuItem("Step");
                ImGui.Separator();
                RenderMenuItem("Project Settings...");
                RenderMenuItem("Clear All PlayerPrefs");
                ImGui.Separator();
                RenderMenuItem("Lighting");
                RenderMenuItem("Graphics Tier");
                RenderMenuItem("Rendering");
                ImGui.EndMenu();
            }
        }

        private void RenderAssetsMenu()
        {
            if (ImGui.BeginMenu("Assets"))
            {
                RenderMenuItem("Create");
                if (ImGui.MenuItem("Import New Asset...\tCmd+I"))
                {
                    TopMenuAction.ExecuteMenuAction("Import New Asset...");
                }

                RenderMenuItem("Import Package...");
                RenderMenuItem("Export Package...");
                ImGui.Separator();
                RenderMenuItem("Find References In Scene");
                RenderMenuItem("Open Asset...");
                ImGui.Separator();
                RenderMenuItem("Reimport");
                RenderMenuItem("Reimport All");
                ImGui.Separator();
                RenderMenuItem("Refresh");
                RenderMenuItem("Remove Unused Assets");
                ImGui.EndMenu();
            }
        }

        private void RenderGameObjectMenu()
        {
            if (ImGui.BeginMenu("GameObject"))
            {
                if (ImGui.MenuItem("Create Empty\tCmd+Shift+N"))
                {
                    TopMenuAction.ExecuteMenuAction("Create Empty");
                }

                RenderMenuItem("Create Empty Child");
                ImGui.Separator();
                RenderMenuItem("2D Object");
                RenderMenuItem("UI");
                ImGui.Separator();
                RenderMenuItem("Light");
                RenderMenuItem("Audio");
                ImGui.Separator();
                RenderMenuItem("Tilemap");
                ImGui.Separator();
                RenderMenuItem("Align With View");
                RenderMenuItem("Align View to Selected");
                RenderMenuItem("Move to View");
                RenderMenuItem("Rename");
                RenderMenuItem("Duplicate");
                RenderMenuItem("Delete");
                ImGui.EndMenu();
            }
        }

        private void RenderComponentMenu()
        {
            if (ImGui.BeginMenu("Component"))
            {
                RenderMenuItem("Add Component");
                ImGui.Separator();
                RenderMenuItem("Physics 2D");
                RenderMenuItem("Rendering 2D");
                RenderMenuItem("Audio");
                RenderMenuItem("UI");
                RenderMenuItem("Scripts");
                ImGui.EndMenu();
            }
        }

        private void RenderToolsMenu()
        {
            if (ImGui.BeginMenu("Tools"))
            {
                RenderMenuItem("Sprite Editor");
                RenderMenuItem("Tilemap Editor");
                RenderMenuItem("Animation Editor");
                ImGui.Separator();
                RenderMenuItem("Custom Tools...");
                ImGui.EndMenu();
            }
        }

        private void RenderWindowMenu()
        {
            if (ImGui.BeginMenu("Window"))
            {
                RenderMenuItem("General");
                RenderMenuItem("Scene View");
                RenderMenuItem("Game View");
                RenderMenuItem("Inspector");
                RenderMenuItem("Hierarchy");
                RenderMenuItem("Console");
                ImGui.EndMenu();
            }
        }

        private void RenderHelpMenu()
        {
            if (ImGui.BeginMenu("Help"))
            {
                RenderMenuItem("About Alis", Shortcuts.AboutAlis);
                ImGui.Separator();
                RenderMenuItem("Preferences", Shortcuts.Preferences);
                RenderMenuItem("Alis Manual");
                RenderMenuItem("API Reference");
                ImGui.Separator();
                RenderMenuItem("Report Bug");
                ImGui.Separator();
                RenderMenuItem("Quit Alis", Shortcuts.QuitAlis);
                ImGui.EndMenu();
            }
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        private static void RenderMenuItem(string text, string shortcut = null)
        {
            if (ImGui.MenuItem(text, shortcut))
            {
                TopMenuAction.ExecuteMenuAction(text);
            }
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}
