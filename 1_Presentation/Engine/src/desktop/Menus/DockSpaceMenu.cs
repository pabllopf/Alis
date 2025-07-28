// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DockSpaceMenu.cs
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

using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Desktop.Menus
{
    /// <summary>
    ///     The dock space menu class
    /// </summary>
    /// <seealso cref="IMenu" />
    internal class DockSpaceMenu : IRenderable, IHasSpaceWork
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DockSpaceMenu" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public DockSpaceMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;

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
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            // Set button and frame background colors
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);

            if (ImGui.BeginMenuBar())
            {
                RenderNavigationButtons();
                RenderSolutionSelector();
                RenderBranchSelector();
                RenderControlButtons();
                RenderBuildOptions();
                RenderUtilityButtons();

                ImGui.PopStyleColor(2);
                ImGui.PopStyleVar();
                ImGui.EndMenuBar();
            }
        }

        /// <summary>
        ///     Renders navigation buttons (e.g., back and forward)
        /// </summary>
        private void RenderNavigationButtons()
        {
            if (ImGui.Button($"{FontAwesome5.ArrowLeft}"))
            {
                Logger.Info("Navigating back...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.ArrowRight}"))
            {
                Logger.Info("Navigating forward...");
            }

            ImGui.SameLine();
        }

        /// <summary>
        ///     Renders the solution selector dropdown
        /// </summary>
        private void RenderSolutionSelector()
        {
            ImGui.SetNextItemWidth(100);
            if (ImGui.BeginCombo("##Solution Name", $"{FontAwesome5.Font} Sample", ImGuiComboFlags.HeightLarge))
            {
                ImGui.Separator();
                if (ImGui.Selectable($"{FontAwesome5.Plus} New Solution"))
                {
                }

                if (ImGui.Selectable($"{FontAwesome5.FolderOpen} Open Solution"))
                {
                }

                ImGui.Separator();
                ImGui.TextDisabled("Recent Solutions");
                if (ImGui.Selectable("Sample Solution"))
                {
                }

                ImGui.EndCombo();
            }

            ImGui.SameLine();
        }

        /// <summary>
        ///     Renders the branch selector dropdown
        /// </summary>
        private void RenderBranchSelector()
        {
            ImGui.SetNextItemWidth(180);
            if (ImGui.BeginCombo("##branchSelector", $"{FontAwesome5.CodeBranch}Master", ImGuiComboFlags.HeightLarge))
            {
                if (ImGui.Selectable("master"))
                {
                    Logger.Info("Switching to branch master...");
                }
                if (ImGui.Selectable("develop"))
                {
                    Logger.Info("Switching to branch develop...");
                }
                if (ImGui.Selectable("feature/new-feature"))
                {
                    Logger.Info("Switching to branch feature/new-feature...");
                }
                ImGui.EndCombo();
            }

            ImGui.SameLine();
        }

        /// <summary>
        ///     Renders control buttons (e.g., Play, Pause, Stop)
        /// </summary>
        private void RenderControlButtons()
        {
            float controlOffset = ImGui.GetWindowWidth() * 0.5f - 65;
            ImGui.SameLine(controlOffset);

            if (ImGui.Button($"{FontAwesome5.Play}"))
            {
                Logger.Info("Starting game...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Pause}"))
            {
                Logger.Info("Pausing game...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Stop}"))
            {
                Logger.Info("Stopping game...");
            }

            ImGui.SameLine();
        }

        /// <summary>
        ///     Renders build options (e.g., build mode selector)
        /// </summary>
        private void RenderBuildOptions()
        {
            float compileOffset = ImGui.GetWindowWidth() - 295;
            ImGui.SameLine(compileOffset);

            if (ImGui.Button($"{FontAwesome5.Hammer}"))
            {
                Logger.Info("Building project...");
            }

            ImGui.SetNextItemWidth(170);
            if (ImGui.BeginCombo("##Build Mode", $"{FontAwesome5.Edit} Release | Any CPU", ImGuiComboFlags.HeightSmall))
            {
                if (ImGui.Selectable("Debug | Any CPU"))
                {
                }

                if (ImGui.Selectable("Release | Any CPU"))
                {
                }

                ImGui.EndCombo();
            }
        }

        /// <summary>
        ///     Renders utility buttons (e.g., Search and Settings)
        /// </summary>
        private void RenderUtilityButtons()
        {
            if (ImGui.Button($"{FontAwesome5.Search}"))
            {
                Logger.Info("Opening search...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Cog}"))
            {
                Logger.Info("Opening settings...");
            }
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}