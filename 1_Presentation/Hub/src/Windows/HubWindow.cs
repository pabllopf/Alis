// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HubWindow.cs
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
using System.IO;
using Alis.App.Hub.Windows.Sections;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Controllers;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Hub.Windows
{
    /// <summary>
    ///     The hub menu class
    /// </summary>
    public class HubWindow : AWindow
    {
        /// <summary>
        ///     The community section
        /// </summary>
        public readonly CommunitySection CommunitySection;

        /// <summary>
        ///     The editor installation section
        /// </summary>
        public readonly EditorInstallationSection EditorInstallationSection;

        /// <summary>
        ///     The learn section
        /// </summary>
        public readonly LearnSection LearnSection;

        /// <summary>
        ///     The gamepad
        /// </summary>
        private readonly string[] menuItems =
        {
            $"{FontAwesome5.Cube} Projects",
            $"{FontAwesome5.Download} Installs",
            $"{FontAwesome5.Book} Learn",
            $"{FontAwesome5.Gamepad} Community"
        };

        /// <summary>
        ///     The projects section
        /// </summary>
        public readonly ProjectsSection ProjectsSection;
        
        /// <summary>
        ///     The selected menu item
        /// </summary>
        private int selectedMenuItem;

        private ImGuiControllerImplementGlfw imGuiController;
        
        public HubWindow(ImGuiControllerImplementGlfw imGuiController)
        {
            this.imGuiController = imGuiController;
            CommunitySection = new CommunitySection();
            ProjectsSection = new ProjectsSection();
            EditorInstallationSection = new EditorInstallationSection();
            LearnSection = new LearnSection();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        /// <param name="imGuiController"></param>
        public override void OnInit()
        {
            
            ProjectsSection.OnInit();
            EditorInstallationSection.OnInit();
            LearnSection.OnInit();
            CommunitySection.OnInit();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            ProjectsSection.OnStart();
            EditorInstallationSection.OnStart();
            LearnSection.OnStart();
            CommunitySection.OnStart();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            ProjectsSection.OnUpdate();
            EditorInstallationSection.OnUpdate();
            LearnSection.OnUpdate();
            CommunitySection.OnUpdate();
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public override void OnRender()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            Vector2F screenSize = io.DisplaySize;

            // Proporciones responsivas
            float sidebarWidth = screenSize.X * 0.22f; // 22% del ancho
            float sidebarPadding = screenSize.X * 0.01f; // 1% padding
            float sidebarHeight = screenSize.Y - (2 * sidebarPadding);
            float buttonWidth = sidebarWidth - (2 * sidebarPadding);
            float buttonHeight = screenSize.Y * 0.09f; // 9% del alto
            float iconSize = sidebarWidth * 0.16f; // 16% del ancho de la barra lateral
            float preferencesButtonHeight = buttonHeight * 0.85f;
            float preferencesButtonY = screenSize.Y - (preferencesButtonHeight + preferencesButtonHeight / 3 + sidebarPadding * 1.5f);

            ImGui.SetNextWindowPos(Vector2F.Zero);
            ImGui.SetNextWindowSize(screenSize);

            ImGui.Begin("##MainWindow", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);

            ImGui.BeginChild("Sidebar", new Vector2F(sidebarWidth, sidebarHeight), true);

            // Padding simétrico para los botones
            float buttonPaddingX = sidebarPadding;
            float buttonPaddingY = sidebarPadding;
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(buttonPaddingX, buttonPaddingY));
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(sidebarPadding, sidebarPadding));

            // Mostrar el logo y el texto "ALIS"
            if (File.Exists(AssetManager.Find("Hub_logo.bmp")))
            {
                //IntPtr textureId = ImageLoader.LoadTextureFromFile(AssetManager.Find("Hub_logo.bmp"));
                //ImGui.Image(textureId, new Vector2F(iconSize, iconSize));
                ImGui.SameLine();

                ImGui.PushFont(imGuiController.FontLoaded45Bold);
                Vector2F textSize = ImGui.CalcTextSize("ALIS");
                float textY = (iconSize - textSize.Y) / 2;
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + textY);
                ImGui.Text("ALIS");
                ImGui.PopFont();
            }

            ImGui.Separator();
            ImGui.PopStyleVar(2);

            ButtonsLeftMenu(buttonWidth, buttonHeight, buttonPaddingX, buttonPaddingY, sidebarPadding);

            ImGui.SetCursorPosY(preferencesButtonY);
            if (ImGui.Button($"{FontAwesome5.Cog} Preferences", new Vector2F(buttonWidth, preferencesButtonHeight)))
            {
                OpenPreferences();
            }

            RenderPreferences();

            ImGui.EndChild();

            ImGui.SameLine();
            ImGui.BeginChild("MainContent", new Vector2F(screenSize.X - sidebarWidth - sidebarPadding, screenSize.Y - (2 * sidebarPadding)), false);
            RenderMainContent();
            ImGui.EndChild();

            ImGui.End();
        }

        /// <summary>
        ///     Renders the preferences
        /// </summary>
        private void RenderPreferences()
        {
            if (ImGui.BeginPopupModal("Preferences"))
            {
                ImGui.Text("Preferences");
                ImGui.Separator();

                ImGui.Text("Select your favorite color:");

                ImGui.Separator();

                ImGui.Text("Select your favorite font:");
                ImGui.Text("This is a sample text with the selected font.");

                ImGui.Separator();

                ImGui.Text("Select your favorite font size:");

                ImGui.Separator();

                ImGui.Text("Select your favorite font style:");

                ImGui.Separator();

                ImGui.Text("Select your favorite font color:");

                ImGui.Separator();

                if (ImGui.Button("Close"))
                {
                    ImGui.CloseCurrentPopup();
                }

                ImGui.EndPopup();
            }
        }

        /// <summary>
        ///     Opens the preferences
        /// </summary>
        private void OpenPreferences()
        {
            ImGui.OpenPopup("Preferences");
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void OnDestroy()
        {
            ProjectsSection.OnDestroy();
            EditorInstallationSection.OnDestroy();
            LearnSection.OnDestroy();
            CommunitySection.OnDestroy();
        }

        /// <summary>
        ///     Buttonses the left menu
        /// </summary>
        private void ButtonsLeftMenu(float buttonWidth, float buttonHeight, float buttonPaddingX, float buttonPaddingY, float sidebarPadding)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 5.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(sidebarPadding, sidebarPadding));
                ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2F(0, 0.5f));
                ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(buttonPaddingX, buttonPaddingY));

                if (ImGui.Button(menuItems[i], new Vector2F(buttonWidth, buttonHeight)))
                {
                    selectedMenuItem = i;
                }

                ImGui.PopStyleVar(4);
            }
        }

        /// <summary>
        ///     Renders the main content
        /// </summary>
        private void RenderMainContent()
        {
            ImGui.PushStyleColor(ImGuiCol.ChildBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            switch (selectedMenuItem)
            {
                case 0:
                    ProjectsSection.OnRender();
                    break;
                case 1:
                    EditorInstallationSection.OnRender();
                    break;
                case 2:
                    LearnSection.OnRender();
                    break;
                case 3:
                    CommunitySection.OnRender();
                    break;
            }

            ImGui.PopStyleColor();
        }
    }
}
