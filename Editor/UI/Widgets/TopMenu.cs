//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TopMenu.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using Alis.Editor.Utils;
    using ImGuiNET;
    using System;

    /// <summary>Menu of editor</summary>
    public class TopMenu : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "TopMenu";

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>Initializes a new instance of the <see cref="TopMenu" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        public TopMenu(EventHandler<EventType> eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        /// <summary>Gets the name.</summary>
        /// <returns>Return name widget</returns>
        public override string GetName()
        {
            return Name;
        }

        /// <summary>Draw this instance.</summary>
        public override void Draw()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem(Icon.FILEO + " New Project"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.FOLDEROPEN + " Open Project"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.FLOPPYO + " Save", "CTRL+S"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.REFRESH + " AutoSave"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.GAMEPAD + " Build Settings", "CTRL+SHIFT+B"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.PLAYCIRCLEO + " Build and Run", "CTRL+B"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.POWEROFF + " Exit", "Alt+F4"))
                    {
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem(Icon.UNDO + " Undo", "CTRL+Z"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.REPEAT + " Redo", "CTRL+Y", false, false))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.SCISSORS + " Cut", "CTRL+X"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.FILESO + " Copy", "CTRL+C"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.CLIPBOARD + " Paste", "CTRL+V"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.WRENCH + " Projects Settings"))
                    {
                    }

                    if (ImGui.MenuItem(Icon.COG + " Preferences"))
                    {
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Tools"))
                {
                    if (ImGui.MenuItem(Icon.TERMINAL + " Terminal", "CTRL+T"))
                    {
                        OpenTerminal();
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Window"))
                {
                    if (ImGui.BeginMenu(Icon.WINDOWMAXIMIZE + " Layouts"))
                    {
                        if (ImGui.MenuItem("Default"))
                        {
                        }

                        if (ImGui.MenuItem("Tall"))
                        {
                        }

                        if (ImGui.MenuItem("Wide"))
                        {
                        }

                        ImGui.EndMenu();
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ARCHIVE + " Package Manager"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.BeginMenu(Icon.COGS + " General"))
                    {
                        if (ImGui.MenuItem("Hierarchy"))
                        {
                        }

                        if (ImGui.MenuItem("Scene"))
                        {
                        }

                        if (ImGui.MenuItem("Console"))
                        {
                            eventHandler?.Invoke(this, EventType.OpenConsole);
                        }

                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.VIDEOCAMERA + " Rendering"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.FILM + " Animation"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.HEADPHONES + " Audio"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.BARCHART + " Analysis"))
                    {
                        ImGui.EndMenu();
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Help"))
                {
                    if (ImGui.MenuItem(Icon.QUESTIONCIRCLE + " Manual"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.SUPERPOWERS + " Check for Updates"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.INFOCIRCLE + " About"))
                    {
                    }

                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }
        }

        /// <summary>Load this instance.</summary>
        public override void OnLoad()
        {
        }

        /// <summary>Opens this instance.</summary>
        public override void Open()
        {
        }

        /// <summary>Close this instance.</summary>
        public override void Close()
        {
        }

        /// <summary>Opens the terminal.</summary>
        private void OpenTerminal()
        {
        }
    }
}