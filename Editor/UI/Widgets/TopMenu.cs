//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TopMenu.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    using System;
    using Alis.Editor.Utils;
    using ImGuiNET;
    
    /// <summary>Menu of editor</summary>
    public class TopMenu : Widget
    {
        /// <summary>The name</summary>
        private const string Name = "TopMenu";

        /// <summary>The event handler</summary>
        private EventHandler<EventType> eventHandler;

        /// <summary>The process</summary>
        private System.Diagnostics.Process process = new System.Diagnostics.Process();
        
        /// <summary>The start information</summary>
        private System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

        /// <summary>The about state</summary>
        private bool aboutState = false;

        /// <summary>The exit state</summary>
        private bool exitState = false;

        /// <summary>Initializes a new instance of the <see cref="TopMenu" /> class.</summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="info">The information.</param>
        public TopMenu(EventHandler<EventType> eventHandler, Info info)
        {
            this.eventHandler = eventHandler;

            if(info.Platform.Equals(Platform.Windows))
            {
                startInfo.FileName = "cmd";
            }

            if(info.Platform.Equals(Platform.MacOS))
            {
                startInfo.FileName = @"/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
            }

            if(info.Platform.Equals(Platform.Linux))
            {
                startInfo.FileName = "/bin/bash";
                startInfo.Arguments = "-c \" " + "exo-open --launch TerminalEmulator" + " \"";
            }


            startInfo.UseShellExecute = true;
            process.StartInfo = startInfo;
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
                        exitState = true;
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
                        System.Diagnostics.Process.Start("explorer", "https://pabllopf.github.io/Alis/");
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.SUPERPOWERS + " Check for Updates"))
                    {
                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.INFOCIRCLE + " About"))
                    {
                        aboutState = true;
                    }

                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }

            ShowAboutPopup();
            ShowExitPopup();
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
            process.Start();
        }

        private void ShowAboutPopup()
        {
            if (aboutState)
            {
                ImGui.OpenPopup("About");
            }

            if (ImGui.BeginPopupModal("About", ref aboutState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text("Version: 1.0.0");
                ImGui.Text("Author: Pablo Perdomo Falcón");
                ImGui.Text("Licence: General Public License v3.0");

                ImGui.EndPopup();
            }
        }

        /// <summary>Shows the exit popup.</summary>
        private void ShowExitPopup()
        {
            if (exitState) 
            {
                ImGui.OpenPopup("Exit?");
            }

            if (ImGui.BeginPopupModal("Exit?", ref exitState, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings))
            {
                ImGui.Text("Are you sure you want to exit?, Please remenber save the project.");
                if (ImGui.Button("Accept", new System.Numerics.Vector2((ImGui.GetContentRegionAvail().X / 2) - 5.0f, 35.0f)))
                {
                    eventHandler.Invoke(this, EventType.ExitEditor);
                    exitState = false;
                    ImGui.CloseCurrentPopup();
                }

                ImGui.SameLine();

                if (ImGui.Button("Cancel", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X, 35.0f)))
                {
                    exitState = false;
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }
        }
    }
}
