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
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.13f, 0.14f, 0.15f, 1.0f));

            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 3));


#if OSX
            int posY = 72;
            int sizeMenu = 30;
            float bottomMenuHeight = 30;
#else
            int posY = 170;
            int sizeMenu = 31;
            float bottomMenuHeight = 60;
#endif
           
            
            Vector2F dockSize = SpaceWork.ImGuiController.Viewport.Size - new Vector2F(5, posY);

            // BOTTON MENU
            Vector2F menuSize = new Vector2F(SpaceWork.ImGuiController.Viewport.Size.X, bottomMenuHeight);
            ImGui.SetNextWindowPos(new Vector2F(SpaceWork.ImGuiController.Viewport.WorkPos.X, SpaceWork.ImGuiController.Viewport.WorkPos.Y + dockSize.Y + sizeMenu + bottomMenuHeight / 2));
            ImGui.SetNextWindowSize(menuSize);


            //ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2F(5, 5));
            //ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(5, 5));

            if (ImGui.Begin("Bottom Menu", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar))
            {
                // Dividir el área en columnas flexibles
                ImGui.Columns(6, "MenuColumns", false); // Seis columnas para más botones


                // Botón de notificaciones
                if (ImGui.Button($"{FontAwesome5.Bell}##notifications"))
                {
                    Logger.Info("Abriendo notificaciones...");
                    // Lógica para abrir notificaciones
                }


                ImGui.SameLine();

                // Selector de rama Git
                ImGui.SetNextItemWidth(180);
                if (ImGui.BeginCombo("##branchSelector", $"{FontAwesome5.CodeBranch}Master", ImGuiComboFlags.HeightLarge))
                {
                    if (ImGui.Selectable("master"))
                    {
                        Logger.Info("Cambiando a la rama master...");
                        // Lógica para cambiar a la rama master
                    }

                    if (ImGui.Selectable("develop"))
                    {
                        Logger.Info("Cambiando a la rama develop...");
                        // Lógica para cambiar a la rama develop
                    }

                    if (ImGui.Selectable("feature/new-feature"))
                    {
                        Logger.Info("Cambiando a la rama feature/new-feature...");
                        // Lógica para cambiar a la rama feature/new-feature
                    }

                    ImGui.EndCombo();
                }


                /*
                // Botón de guardar
                if (ImGui.Button($"{FontAwesome5.Save}##save", new Vector2F(32, 32)))
                {
                   Logger.Info("Guardando...");
                    // Lógica para guardar el proyecto
                }*/

                //ImGui.BeginTooltip();
                //ImGui.Text("Guardar");
                //ImGui.EndTooltip();

                ImGui.NextColumn();

                /*
                // Botón de deshacer
                if (ImGui.Button($"{FontAwesome5.Undo}##undo", new Vector2F(32, 32)))
                {
                   Logger.Info("Deshaciendo...");
                    // Lógica para deshacer
                }

                //ImGui.BeginTooltip();
                //ImGui.Text("Deshacer");
                //ImGui.EndTooltip();

                // Botón de rehacer
                if (ImGui.Button($"{FontAwesome5.Redo}##redo", new Vector2F(32, 32)))
                {
                   Logger.Info("Rehaciendo...");
                    // Lógica para rehacer
                }

                //ImGui.BeginTooltip();
                //ImGui.Text("Rehacer");
                //ImGui.EndTooltip();
                */

                ImGui.NextColumn();


                //ImGui.BeginTooltip();

                //ImGui.Text("Seleccionar rama de Git");

                //ImGui.EndTooltip();

                ImGui.NextColumn();

                /*
                // Botón de herramientas rápidas
                if (ImGui.Button($"{FontAwesome5.Tools}##tools", new Vector2F(32, 32)))
                {
                    ImGui.OpenPopup("ToolsMenu");
                }*/

                // ImGui.BeginTooltip();

                //ImGui.Text("Herramientas rápidas");

                //ImGui.EndTooltip();

                /*
                if (ImGui.BeginPopup("ToolsMenu"))
                {
                    if (ImGui.MenuItem("Configurar entorno"))
                    {
                       Logger.Info("Abriendo configuración del entorno...");
                        // Lógica para configurar entorno
                    }

                    if (ImGui.MenuItem("Reparar proyecto"))
                    {
                       Logger.Info("Reparando proyecto...");
                        // Lógica para reparar proyecto
                    }

                    ImGui.EndPopup();
                }*/

                ImGui.NextColumn();

                //ImGui.BeginTooltip();

                //ImGui.Text("Notificaciones");

                //ImGui.EndTooltip();

                
                ImGui.NextColumn();

                // Barra de carga alineada a la derecha
                ImGui.SetCursorPosX(ImGui.GetContentRegionMax().X - 150); // Ajustar según el tamaño de la barra
                ImGui.ProgressBar(1f, new Vector2F(150, ImGui.GetContentRegionMax().Y - 10), "3/15"); // Ejemplo de barra al 65%

                ImGui.PopStyleVar(2);
                
                ImGui.End();
            }

            // Restaurar el estilo
            //ImGui.PopStyleVar(2);
            ImGui.PopStyleColor(2);
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }
    }
}