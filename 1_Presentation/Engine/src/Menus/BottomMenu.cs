// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BottomMenu.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    ///     The bottom menu class
    /// </summary>
    /// <seealso cref="IMenu" />
    public class BottomMenu : IMenu
    {
        /// <summary>
        ///     The bottom menu height
        /// </summary>
        private readonly float bottomMenuHeight = 10.0f;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BottomMenu" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public BottomMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
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
            ApplyBottomMenuStyling();
            SetupNextWindowProperties();

            if (ImGui.Begin("Bottom Menu", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar))
            {
                RenderMenuContent();
                ImGui.End();
            }

            ImGui.PopStyleColor(3);
        }

        /// <summary>
        /// Applies the bottom menu styling
        /// </summary>
        private static void ApplyBottomMenuStyling()
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));

            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 3));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
        }

        /// <summary>
        /// Renders the menu content
        /// </summary>
        private static void RenderMenuContent()
        {
            ImGui.Columns(6, "MenuColumns", false);

            RenderBranchSelector();

            ImGui.NextColumn();
            ImGui.NextColumn();
            ImGui.PopStyleVar(3);
            ImGui.NextColumn();

            ImGui.SetCursorPosX(ImGui.GetContentRegionMax().X - 150);
            ImGui.ProgressBar(0.65f, new Vector2F(150, 20), "3/15");
        }

        /// <summary>
        /// Renders the branch selector
        /// </summary>
        private static void RenderBranchSelector()
        {
            if (ImGui.Button($"{FontAwesome5.Bell}##notifications"))
            {
                Logger.Info("Abriendo notificaciones...");
            }

            ImGui.SameLine();

            ImGui.SetNextItemWidth(90);
            if (ImGui.BeginCombo("##branchSelector", $"{FontAwesome5.CodeBranch}Master", ImGuiComboFlags.HeightLarge))
            {
                if (ImGui.Selectable("master"))
                {
                    Logger.Info("Cambiando a la rama master...");
                }

                if (ImGui.Selectable("develop"))
                {
                    Logger.Info("Cambiando a la rama develop...");
                }

                if (ImGui.Selectable("feature/new-feature"))
                {
                    Logger.Info("Cambiando a la rama feature/new-feature...");
                }

                ImGui.EndCombo();
            }
        }

        /// <summary>
        /// Setup the next window properties
        /// </summary>
        private void SetupNextWindowProperties()
        {
            if (!SpaceWork.IsMacOs)
            {
                Vector2F dockSize = SpaceWork.Viewport.Size - new Vector2F(5, 90);
                Vector2F menuSize = new Vector2F(SpaceWork.Viewport.Size.X, bottomMenuHeight);
                ImGui.SetNextWindowPos(new Vector2F(SpaceWork.Viewport.WorkPos.X, SpaceWork.Viewport.WorkPos.Y + dockSize.Y + 31 + bottomMenuHeight / 2));
                ImGui.SetNextWindowSize(menuSize);
            }
            else
            {
                Vector2F dockSize = SpaceWork.Viewport.Size - new Vector2F(5, 35);
                Vector2F menuSize = new Vector2F(SpaceWork.Viewport.Size.X, bottomMenuHeight);
                ImGui.SetNextWindowPos(new Vector2F(SpaceWork.Viewport.WorkPos.X, SpaceWork.Viewport.WorkPos.Y + dockSize.Y + 8));
                ImGui.SetNextWindowSize(menuSize);
            }
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }
    }
}