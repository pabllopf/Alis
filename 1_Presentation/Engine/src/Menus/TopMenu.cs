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
            // Establecer el color de fondo de los botones
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            // quit border:
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);

            ImGui.BeginMainMenuBar();

            // Menú "File"
            if (ImGui.BeginMenu("File"))
            {
                if (ImGui.MenuItem("New Scene", Shortcuts.NewScene))
                {
                    TopMenuAction.ExecuteMenuAction("New Scene");
                }

                if (ImGui.MenuItem("Open Scene...", Shortcuts.OpenScene))
                {
                    TopMenuAction.ExecuteMenuAction("Open Scene...");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Save", Shortcuts.Save))
                {
                    TopMenuAction.ExecuteMenuAction("Save");
                }

                if (ImGui.MenuItem("Save As...", Shortcuts.SaveAs))
                {
                    TopMenuAction.ExecuteMenuAction("Save As...");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("New Project"))
                {
                    TopMenuAction.ExecuteMenuAction("New Project");
                }

                if (ImGui.MenuItem("Open Project"))
                {
                    TopMenuAction.ExecuteMenuAction("Open Project");
                }

                if (ImGui.MenuItem("Save Project"))
                {
                    TopMenuAction.ExecuteMenuAction("Save Project");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Build Profiles"))
                {
                    TopMenuAction.ExecuteMenuAction("Build Profiles");
                }

                if (ImGui.MenuItem("Build And Run"))
                {
                    TopMenuAction.ExecuteMenuAction("Build And Run");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Close"))
                {
                    TopMenuAction.ExecuteMenuAction("Close");
                }

                ImGui.EndMenu();
            }

            // Menú "Edit"
            if (ImGui.BeginMenu("Edit"))
            {
                if (ImGui.MenuItem("Undo", Shortcuts.Undo))
                {
                    TopMenuAction.ExecuteMenuAction("Undo");
                }

                if (ImGui.MenuItem("Redo", Shortcuts.Redo))
                {
                    TopMenuAction.ExecuteMenuAction("Redo");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Undo History"))
                {
                    TopMenuAction.ExecuteMenuAction("Undo History");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Select All"))
                {
                    TopMenuAction.ExecuteMenuAction("Select All");
                }

                if (ImGui.MenuItem("Deselect All"))
                {
                    TopMenuAction.ExecuteMenuAction("Deselect All");
                }

                if (ImGui.MenuItem("Select Children"))
                {
                    TopMenuAction.ExecuteMenuAction("Select Children");
                }

                if (ImGui.MenuItem("Select Prefab Root"))
                {
                    TopMenuAction.ExecuteMenuAction("Select Prefab Root");
                }

                if (ImGui.MenuItem("Invert Selection"))
                {
                    TopMenuAction.ExecuteMenuAction("Invert Selection");
                }

                if (ImGui.MenuItem("Selection Groups"))
                {
                    TopMenuAction.ExecuteMenuAction("Selection Groups");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Cut"))
                {
                    TopMenuAction.ExecuteMenuAction("Cut");
                }

                if (ImGui.MenuItem("Copy"))
                {
                    TopMenuAction.ExecuteMenuAction("Copy");
                }

                if (ImGui.MenuItem("Paste"))
                {
                    TopMenuAction.ExecuteMenuAction("Paste");
                }

                if (ImGui.MenuItem("Paste Special"))
                {
                    TopMenuAction.ExecuteMenuAction("Paste Special");
                }

                if (ImGui.MenuItem("Duplicate"))
                {
                    TopMenuAction.ExecuteMenuAction("Duplicate");
                }

                if (ImGui.MenuItem("Rename"))
                {
                    TopMenuAction.ExecuteMenuAction("Rename");
                }

                if (ImGui.MenuItem("Delete"))
                {
                    TopMenuAction.ExecuteMenuAction("Delete");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Frame Selected in Scene"))
                {
                    TopMenuAction.ExecuteMenuAction("Frame Selected in Scene");
                }

                if (ImGui.MenuItem("Frame Selected in Window under Cursor"))
                {
                    TopMenuAction.ExecuteMenuAction("Frame Selected in Window under Cursor");
                }

                if (ImGui.MenuItem("Lock View to Selected"))
                {
                    TopMenuAction.ExecuteMenuAction("Lock View to Selected");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Search"))
                {
                    TopMenuAction.ExecuteMenuAction("Search");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Play", Shortcuts.Play))
                {
                    TopMenuAction.ExecuteMenuAction("Play");
                }

                if (ImGui.MenuItem("Pause", Shortcuts.Pause))
                {
                    TopMenuAction.ExecuteMenuAction("Pause");
                }

                if (ImGui.MenuItem("Step"))
                {
                    TopMenuAction.ExecuteMenuAction("Step");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Project Settings..."))
                {
                    TopMenuAction.ExecuteMenuAction("Project Settings...");
                }

                if (ImGui.MenuItem("Clear All PlayerPrefs"))
                {
                    TopMenuAction.ExecuteMenuAction("Clear All PlayerPrefs");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Lighting"))
                {
                    TopMenuAction.ExecuteMenuAction("Lighting");
                }

                if (ImGui.MenuItem("Graphics Tier"))
                {
                    TopMenuAction.ExecuteMenuAction("Graphics Tier");
                }

                if (ImGui.MenuItem("Rendering"))
                {
                    TopMenuAction.ExecuteMenuAction("Rendering");
                }

                ImGui.EndMenu();
            }

            // Menú "Assets"
            if (ImGui.BeginMenu("Assets"))
            {
                if (ImGui.MenuItem("Create"))
                {
                    TopMenuAction.ExecuteMenuAction("Create");
                }

                if (ImGui.MenuItem("Import New Asset...\tCmd+I"))
                {
                    TopMenuAction.ExecuteMenuAction("Import New Asset...");
                }

                if (ImGui.MenuItem("Import Package..."))
                {
                    TopMenuAction.ExecuteMenuAction("Import Package...");
                }

                if (ImGui.MenuItem("Export Package..."))
                {
                    TopMenuAction.ExecuteMenuAction("Export Package...");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Find References In Scene"))
                {
                    TopMenuAction.ExecuteMenuAction("Find References In Scene");
                }

                if (ImGui.MenuItem("Open Asset..."))
                {
                    TopMenuAction.ExecuteMenuAction("Open Asset...");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Reimport"))
                {
                    TopMenuAction.ExecuteMenuAction("Reimport");
                }

                if (ImGui.MenuItem("Reimport All"))
                {
                    TopMenuAction.ExecuteMenuAction("Reimport All");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Refresh"))
                {
                    TopMenuAction.ExecuteMenuAction("Refresh");
                }

                if (ImGui.MenuItem("Remove Unused Assets"))
                {
                    TopMenuAction.ExecuteMenuAction("Remove Unused Assets");
                }

                ImGui.EndMenu();
            }

            // Menú "GameObject"
            if (ImGui.BeginMenu("GameObject"))
            {
                if (ImGui.MenuItem("Create Empty\tCmd+Shift+N"))
                {
                    TopMenuAction.ExecuteMenuAction("Create Empty");
                }

                if (ImGui.MenuItem("Create Empty Child"))
                {
                    TopMenuAction.ExecuteMenuAction("Create Empty Child");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("2D Object"))
                {
                    TopMenuAction.ExecuteMenuAction("2D Object");
                }

                if (ImGui.MenuItem("UI"))
                {
                    TopMenuAction.ExecuteMenuAction("UI");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Light"))
                {
                    TopMenuAction.ExecuteMenuAction("Light");
                }

                if (ImGui.MenuItem("Audio"))
                {
                    TopMenuAction.ExecuteMenuAction("Audio");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Tilemap"))
                {
                    TopMenuAction.ExecuteMenuAction("Tilemap");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Align With View"))
                {
                    TopMenuAction.ExecuteMenuAction("Align With View");
                }

                if (ImGui.MenuItem("Align View to Selected"))
                {
                    TopMenuAction.ExecuteMenuAction("Align View to Selected");
                }

                if (ImGui.MenuItem("Move to View"))
                {
                    TopMenuAction.ExecuteMenuAction("Move to View");
                }

                if (ImGui.MenuItem("Rename"))
                {
                    TopMenuAction.ExecuteMenuAction("Rename");
                }

                if (ImGui.MenuItem("Duplicate"))
                {
                    TopMenuAction.ExecuteMenuAction("Duplicate");
                }

                if (ImGui.MenuItem("Delete"))
                {
                    TopMenuAction.ExecuteMenuAction("Delete");
                }

                ImGui.EndMenu();
            }

            // Menú "Component"
            if (ImGui.BeginMenu("Component"))
            {
                if (ImGui.MenuItem("Add Component"))
                {
                    TopMenuAction.ExecuteMenuAction("Add Component");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Physics 2D"))
                {
                    TopMenuAction.ExecuteMenuAction("Physics 2D");
                }

                if (ImGui.MenuItem("Rendering 2D"))
                {
                    TopMenuAction.ExecuteMenuAction("Rendering 2D");
                }

                if (ImGui.MenuItem("Audio"))
                {
                    TopMenuAction.ExecuteMenuAction("Audio");
                }

                if (ImGui.MenuItem("UI"))
                {
                    TopMenuAction.ExecuteMenuAction("UI");
                }

                if (ImGui.MenuItem("Scripts"))
                {
                    TopMenuAction.ExecuteMenuAction("Scripts");
                }

                ImGui.EndMenu();
            }

            // Menú "Tools"
            if (ImGui.BeginMenu("Tools"))
            {
                if (ImGui.MenuItem("Sprite Editor"))
                {
                    TopMenuAction.ExecuteMenuAction("Sprite Editor");
                }

                if (ImGui.MenuItem("Tilemap Editor"))
                {
                    TopMenuAction.ExecuteMenuAction("Tilemap Editor");
                }

                if (ImGui.MenuItem("Animation Editor"))
                {
                    TopMenuAction.ExecuteMenuAction("Animation Editor");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Custom Tools..."))
                {
                    TopMenuAction.ExecuteMenuAction("Custom Tools...");
                }

                ImGui.EndMenu();
            }

            // Menú "Window"
            if (ImGui.BeginMenu("Window"))
            {
                if (ImGui.MenuItem("General"))
                {
                    TopMenuAction.ExecuteMenuAction("General");
                }

                if (ImGui.MenuItem("Scene View"))
                {
                    TopMenuAction.ExecuteMenuAction("Scene View");
                }

                if (ImGui.MenuItem("Game View"))
                {
                    TopMenuAction.ExecuteMenuAction("Game View");
                }

                if (ImGui.MenuItem("Inspector"))
                {
                    TopMenuAction.ExecuteMenuAction("Inspector");
                }

                if (ImGui.MenuItem("Hierarchy"))
                {
                    TopMenuAction.ExecuteMenuAction("Hierarchy");
                }

                if (ImGui.MenuItem("Console"))
                {
                    TopMenuAction.ExecuteMenuAction("Console");
                }

                ImGui.EndMenu();
            }

            // Menú "Help"
            if (ImGui.BeginMenu("Help"))
            {
                if (ImGui.MenuItem("About Alis", Shortcuts.AboutAlis))
                {
                    TopMenuAction.ExecuteMenuAction("About Alis");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Preferences", Shortcuts.Preferences))
                {
                    TopMenuAction.ExecuteMenuAction("Preferences");
                }

                if (ImGui.MenuItem("Alis Manual"))
                {
                    TopMenuAction.ExecuteMenuAction("Alis Manual");
                }

                if (ImGui.MenuItem("API Reference"))
                {
                    TopMenuAction.ExecuteMenuAction("API Reference");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Report Bug"))
                {
                    TopMenuAction.ExecuteMenuAction("Report Bug");
                }

                ImGui.Separator();
                if (ImGui.MenuItem("Quit Alis", Shortcuts.QuitAlis))
                {
                    TopMenuAction.ExecuteMenuAction("Quit Alis");
                }

                ImGui.EndMenu();
            }


            ImGui.EndMainMenuBar();
            ImGui.PopStyleVar();
            ImGui.PopStyleColor();
            ImGui.PopStyleColor();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}