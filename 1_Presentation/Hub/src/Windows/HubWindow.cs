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
using Alis.App.Hub.Core;
using Alis.App.Hub.Windows.Sections;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
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
        ///     The space work
        /// </summary>
        private readonly SpaceWork spaceWork;

        /// <summary>
        ///     The selected menu item
        /// </summary>
        private int selectedMenuItem;

        //private string searchQuery = " ";  // Variable para el buscador

        /// <summary>
        ///     Initializes a new instance of the <see cref="HubWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public HubWindow(SpaceWork spaceWork) : base(spaceWork)
        {
            this.spaceWork = spaceWork;

            CommunitySection = new CommunitySection(spaceWork);
            ProjectsSection = new ProjectsSection(spaceWork);
            EditorInstallationSection = new EditorInstallationSection(spaceWork);
            LearnSection = new LearnSection(spaceWork);
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
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
        /// <param name="scaleFactor"></param>
        public override void OnRender(float scaleFactor)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            Vector2F screenSize = io.DisplaySize;

            ImGui.SetNextWindowPos(Vector2F.Zero);
            ImGui.SetNextWindowSize(screenSize);

            ImGui.Begin("##MainWindow", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);

            ImGui.BeginChild("Sidebar", new Vector2F(220 * scaleFactor, screenSize.Y - 20 * scaleFactor), true);

            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(10 * scaleFactor, 10 * scaleFactor));
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(10 * scaleFactor, 10 * scaleFactor));

            ImGui.Separator();
            ImGui.PopStyleVar(2);

            ButtonsLeftMenu(scaleFactor);

            ImGui.SetCursorPosY(screenSize.Y - 70 * scaleFactor);
            if (ImGui.Button($"{FontAwesome5.Cog} Preferences", new Vector2F(200 * scaleFactor, 40 * scaleFactor)))
            {
                OpenPreferences();
            }

            RenderPreferences();

            ImGui.EndChild();

            ImGui.SameLine();
            ImGui.BeginChild("MainContent", new Vector2F(screenSize.X - 220 * scaleFactor, screenSize.Y - 20 * scaleFactor), false);
            RenderMainContent(scaleFactor);
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
        private void ButtonsLeftMenu(float scaleFactor)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 5.0f * scaleFactor);
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(10 * scaleFactor, 10 * scaleFactor));
                ImGui.PushStyleVar(ImGuiStyleVar.ButtonTextAlign, new Vector2F(0, 0.5f));

                if (ImGui.Button(menuItems[i], new Vector2F(200 * scaleFactor, 40 * scaleFactor)))
                {
                    selectedMenuItem = i;
                }

                ImGui.PopStyleVar(3);
            }
        }

        /// <summary>
        ///     Renders the main content
        /// </summary>
        private void RenderMainContent(float scaleFactor)
        {
            ImGui.PushStyleColor(ImGuiCol.ChildBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            switch (selectedMenuItem)
            {
                case 0:
                    ProjectsSection.OnRender(scaleFactor);
                    break;
                case 1:
                    EditorInstallationSection.OnRender(scaleFactor);
                    break;
                case 2:
                    LearnSection.OnRender(scaleFactor);
                    break;
                case 3:
                    CommunitySection.OnRender(scaleFactor);
                    break;
            }

            ImGui.PopStyleColor();
        }
    }
}