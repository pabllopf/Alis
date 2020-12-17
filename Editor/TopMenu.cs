namespace Alis.Editor
{
    using ImGuiNET;
    using System;
    using System.Collections.Generic;

    public class TopMenu
    {
        private bool open = true;

        public TopMenu() 
        {
        
        }

        private void OpenTerminal()
        {
         
        }

        public void Draw() 
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem(Icon.ICON_FA_FILE_O + " New Project"))
                    {

                    }

                    if (ImGui.MenuItem(Icon.ICON_FA_FOLDER_OPEN + " Open Project"))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ICON_FA_FLOPPY_O + " Save", "CTRL+S"))
                    {

                    }

                    if (ImGui.MenuItem(Icon.ICON_FA_REFRESH + " AutoSave"))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ICON_FA_GAMEPAD + " Build Settings", "CTRL+SHIFT+B"))
                    {

                    }

                    if (ImGui.MenuItem(Icon.ICON_FA_PLAY_CIRCLE_O + " Build and Run", "CTRL+B"))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ICON_FA_POWER_OFF + " Exit", "Alt+F4"))
                    {
                        open = false;
                    }

                    ImGui.EndMenu();
                }



                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem(Icon.ICON_FA_UNDO + " Undo", "CTRL+Z"))
                    {

                    }

                    if (ImGui.MenuItem(Icon.ICON_FA_REPEAT + " Redo", "CTRL+Y", false, false))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ICON_FA_SCISSORS + " Cut", "CTRL+X"))
                    {

                    }

                    if (ImGui.MenuItem(Icon.ICON_FA_FILES_O + " Copy", "CTRL+C"))
                    {

                    }

                    if (ImGui.MenuItem(Icon.ICON_FA_CLIPBOARD + " Paste", "CTRL+V"))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ICON_FA_WRENCH + " Projects Settings"))
                    {

                    }

                    if (ImGui.MenuItem(Icon.ICON_FA_COG + " Preferences"))
                    {

                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Tools"))
                {
                    if (ImGui.MenuItem(Icon.ICON_FA_TERMINAL + " Terminal", "CTRL+T"))
                    {
                        OpenTerminal();
                    }

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Window"))
                {
                    if (ImGui.BeginMenu(Icon.ICON_FA_WINDOW_MAXIMIZE + " Layouts"))
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

                    if (ImGui.MenuItem(Icon.ICON_FA_ARCHIVE + " Package Manager"))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.BeginMenu(Icon.ICON_FA_COGS + " General"))
                    {
                        if (ImGui.MenuItem("Hierarchy"))
                        {

                        }

                        if (ImGui.MenuItem("Scene"))
                        {

                        }

                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.ICON_FA_VIDEO_CAMERA + " Rendering"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.ICON_FA_FILM + " Animation"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.ICON_FA_HEADPHONES + " Audio"))
                    {
                        ImGui.EndMenu();
                    }

                    if (ImGui.BeginMenu(Icon.ICON_FA_BAR_CHART + " Analysis"))
                    {
                        ImGui.EndMenu();
                    }

                    ImGui.EndMenu();
                }


                if (ImGui.BeginMenu("Help"))
                {
                    if (ImGui.MenuItem(Icon.ICON_FA_QUESTION_CIRCLE + " Manual"))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ICON_FA_SUPERPOWERS + " Check for Updates"))
                    {

                    }

                    ImGui.Separator();

                    if (ImGui.MenuItem(Icon.ICON_FA_INFO_CIRCLE + " About"))
                    {

                    }

                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }
        }
    }
}
