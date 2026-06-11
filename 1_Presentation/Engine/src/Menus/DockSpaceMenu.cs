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

using Alis.App.Engine.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    ///     The dock space menu class
    /// </summary>
    /// <seealso cref="IMenu" />
    internal class DockSpaceMenu : IMenu
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DockSpaceMenu" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public DockSpaceMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the top menu
        /// </summary>
        internal TopMenu TopMenu { get; }


        /// <summary>
        ///     Gets or sets the value of the top menu mac
        /// </summary>
        public TopMenuMac TopMenuMac { get; set; }

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
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));

            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));


            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);

            if (ImGui.BeginMenuBar())
            {
                RenderMenuBarContent();
                ImGui.EndMenuBar();
            }

            ImGui.PopStyleColor(3);
            ImGui.PopStyleVar(2);
        }

        /// <summary>
        ///     Renders the menu bar content
        /// </summary>
        private void RenderMenuBarContent()
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));

            if (ImGui.Button($"{FontAwesome5.Bars}"))
            {
                Logger.Info("Show normal menu...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.ArrowLeft}"))
            {
                Logger.Info("Retrocediendo...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.ArrowRight}"))
            {
                Logger.Info("Avanzando...");
            }

            ImGui.SameLine();

            RenderSolutionCombo();

            ImGui.SameLine();

            RenderControlButtons();
        }

        /// <summary>
        ///     Renders the solution combo box
        /// </summary>
        private static void RenderSolutionCombo()
        {
            ImGui.SetNextItemWidth(100);
            if (ImGui.BeginCombo("##Solution Name", $"{FontAwesome5.Font} Sample", ImGuiComboFlags.HeightLarge))
            {
                ImGui.Separator();
                _ = ImGui.Selectable($"{FontAwesome5.Plus} New Solution");

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
        }

        /// <summary>
        ///     Renders the control buttons
        /// </summary>
        private static void RenderControlButtons()
        {
            float controlOffset = ImGui.GetWindowWidth() * 0.5f - 65;
            ImGui.SameLine(controlOffset);

            if (ImGui.Button($"{FontAwesome5.Play}"))
            {
                Logger.Info("Iniciando...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Stop}"))
            {
                Logger.Info("Deteniendo...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Pause}"))
            {
                Logger.Info("Pausando...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Pen}"))
            {
                Logger.Info("Editando...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Save}"))
            {
                Logger.Info("Guardando...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.FileCode}"))
            {
                Logger.Info("Código...");
            }

            ImGui.SameLine();

            if (ImGui.Button($"{FontAwesome5.Cog}"))
            {
                Logger.Info("Configuración...");
            }
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        void IRuntime.Render()
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
        void IRenderable.Render()
        {
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}