using System.Diagnostics;
using Alis.App.Engine.Core;

namespace Alis.App.Engine.Menus
{
    public class TopMenuMac : IMenu
    {
        public SpaceWork SpaceWork { get; }

        public TopMenuMac(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
        }

        public void Initialize()
        {
#if OSX
            ConfigureMenu();
#endif
        }

        public void Start() { }
        public void Update() { }
        public void Render() { }

#if OSX
        [Conditional("OSX")]
        static void ConfigureMenu()
        {
            MonoMac.AppKit.NSApplication.Init();

            // Configuración del menú principal
            MonoMac.AppKit.NSMenu mainMenu = new MonoMac.AppKit.NSMenu();

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
                "Open Scene...\tCmd+O",
                "Open Recent Scene",
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
            MonoMac.AppKit.NSApplication.SharedApplication.MainMenu = mainMenu;
        }

        static void AddMenu(MonoMac.AppKit.NSMenu mainMenu, string title, string[] items)
        {
            MonoMac.AppKit.NSMenuItem menuItem = new MonoMac.AppKit.NSMenuItem(title);
            MonoMac.AppKit.NSMenu submenu = new MonoMac.AppKit.NSMenu(title);

            foreach (string item in items)
            {
                string[] itemParts = item.Split('\t');
                string itemName = itemParts[0];
                string shortcut = itemParts.Length > 1 ? itemParts[1] : null;

                if (itemName == "-")
                {
                    submenu.AddItem(MonoMac.AppKit.NSMenuItem.SeparatorItem);
                }
                else
                {
                    MonoMac.AppKit.NSMenuItem menuOption = new MonoMac.AppKit.NSMenuItem(itemName, (sender, e) =>
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
#endif
    }
}
