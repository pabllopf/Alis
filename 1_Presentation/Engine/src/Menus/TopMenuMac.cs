// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TopMenuMac.cs
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

using System.Diagnostics;
using Alis.App.Engine.Core;
using MonoMac.AppKit;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    /// The top menu mac class
    /// </summary>
    /// <seealso cref="IMenu"/>
    public class TopMenuMac : IMenu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopMenuMac"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public TopMenuMac(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
            TopMenuAction.SetSpaceWork(spaceWork);
        }

        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {

            ConfigureMenu();
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
        }
        
        /// <summary>
        /// Configures the menu
        /// </summary>
        [Conditional("OSX")]
        private static void ConfigureMenu()
        {
            NSApplication.Init();

            // Configuración del menú principal
            NSMenu mainMenu = new NSMenu();

            // Submenús principales adaptados a Alis
            AddMenu(mainMenu, "Alis", new[]
            {
                "About Alis",
                "-",
                "Preferences",
                "-",
                "Quit Alis"
            });

            AddMenu(mainMenu, "File", new[]
            {
                "New Scene\tCmd+N",
                "-",
                "Save\tCmd+S",
                "Save As...\tCmd+Shift+S",
                "Save As Scene Template...",
                "-",
                "New Project",
                "Open Project",
                "Save Project",
                "-",
                "Build Profiles",
                "Build And Run",
                "-",
                "Close"
            });

            AddMenu(mainMenu, "Edit", new[]
            {
                "Undo\tCmd+Z",
                "Redo\tCmd+Shift+Z",
                "-",
                "Undo History",
                "-",
                "Select All\tCmd+A",
                "Deselect All",
                "Select Children",
                "Select Prefab Root",
                "Invert Selection",
                "Selection Groups",
                "-",
                "Cut\tCmd+X",
                "Copy\tCmd+C",
                "Paste\tCmd+V",
                "Paste Special",
                "Duplicate\tCmd+D",
                "Rename",
                "Delete",
                "-",
                "Frame Selected in Scene",
                "Frame Selected in Window under Cursor",
                "Lock View to Selected",
                "-",
                "Search",
                "-",
                "Play\tCmd+P",
                "Pause\tCmd+Shift+P",
                "Step",
                "-",
                "Project Settings...",
                "Clear All PlayerPrefs",
                "-",
                "Lighting",
                "Graphics Tier",
                "Rendering"
            });

            AddMenu(mainMenu, "Assets", new[]
            {
                "Create",
                "Import New Asset...\tCmd+I",
                "Import Package...",
                "Export Package...",
                "-",
                "Find References In Scene",
                "Open Asset...",
                "-",
                "Reimport",
                "Reimport All",
                "-",
                "Refresh",
                "Remove Unused Assets"
            });

            AddMenu(mainMenu, "GameObject", new[]
            {
                "Create Empty\tCmd+Shift+N",
                "Create Empty Child",
                "-",
                "2D Object",
                "UI",
                "-",
                "Light",
                "Audio",
                "-",
                "Tilemap",
                "-",
                "Align With View",
                "Align View to Selected",
                "Move to View",
                "Rename",
                "Duplicate",
                "Delete"
            });

            AddMenu(mainMenu, "Component", new[]
            {
                "Add Component",
                "-",
                "Physics 2D",
                "Rendering 2D",
                "Audio",
                "UI",
                "Scripts"
            });

            AddMenu(mainMenu, "Tools", new[]
            {
                "Sprite Editor",
                "Tilemap Editor",
                "Animation Editor",
                "-",
                "Custom Tools..."
            });

            AddMenu(mainMenu, "Window", new[]
            {
                "General",
                "Scene View",
                "Game View",
                "Inspector",
                "Hierarchy",
                "Console"
            });

            AddMenu(mainMenu, "Help", new[]
            {
                "Alis Manual",
                "API Reference",
                "-",
                "Report Bug",
                "About Alis"
            });

            // Asignar el menú principal configurado
            NSApplication.SharedApplication.MainMenu = mainMenu;
        }

        /// <summary>
        /// Adds the menu using the specified main menu
        /// </summary>
        /// <param name="mainMenu">The main menu</param>
        /// <param name="title">The title</param>
        /// <param name="items">The items</param>
        [Conditional("OSX")]
        private static void AddMenu(NSMenu mainMenu, string title, string[] items)
        {
            NSMenuItem menuItem = new NSMenuItem(title);
            NSMenu submenu = new NSMenu(title);

            foreach (string item in items)
            {
                string[] itemParts = item.Split('\t');
                string itemName = itemParts[0];
                string shortcut = itemParts.Length > 1 ? itemParts[1] : null;

                if (itemName == "-")
                {
                    submenu.AddItem(NSMenuItem.SeparatorItem);
                }
                else
                {
                    NSMenuItem menuOption = new NSMenuItem(itemName, (sender, e) =>
                    {
                        Debug.WriteLine($"Clicked on {itemName}");
                        TopMenuAction.ExecuteMenuAction(itemName); // Llama a la lógica
                    });

                    // Asignar atajo de teclado si lo tiene
                    if (!string.IsNullOrEmpty(shortcut))
                    {
                        menuOption.KeyEquivalent = shortcut;
                    }

                    submenu.AddItem(menuOption);
                }
            }

            menuItem.Submenu = submenu;
            mainMenu.AddItem(menuItem);
        }
    }
}