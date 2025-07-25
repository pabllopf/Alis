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
             // Establece el padding de la ventana
            //ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);  // Igual padding arriba y abajo
            //ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 4f));
            //ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2F(4, 4));

            // Set height of the menu bar
            //ImGui.SetWindowSize(new Vector2F(0, 5), ImGuiCond.Always);


            // Crear barra de menú
            if (ImGui.BeginMenuBar())
            {
                // Elementos centrados dinámicamente
                //float contentHeight = ImGui.GetContentRegionAvail().Y;  // Obtiene el espacio disponible en la ventana
                //float centerOffsetY = contentHeight * 0.5f;  // Calcula el centro vertical


                // Establece la posición de la ventana de manera que se centre verticalmente
                //ImGui.SetCursorPosY(2.5f); // Ajuste para alinear mejor el contenido
                //ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2F(4, 5f)); // Ajustar el espaciado si es necesario

                // Establecer el color de fondo de los botones
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0.15f, 0.15f, 0.15f, 1.0f));
                // quit border:
                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);

                // Primer conjunto de botones: izquierda
                if (ImGui.Button($"{FontAwesome5.ArrowLeft}"))
                {
                    // Lógica para retroceder
                    Logger.Info("Retrocediendo...");
                    //ImGui.LoadIniSettingsFromDisk(AssetManager.Find("Engine_default_config.ini"));
                }

                ImGui.SameLine();

                if (ImGui.Button($"{FontAwesome5.ArrowRight}"))
                {
                    // Lógica para avanzar
                    Logger.Info("Avanzando...");
                    //ImGui.LoadIniSettingsFromDisk(AssetManager.Find("Engine_tall_config.ini"));
                }

                ImGui.SameLine();


                // Selector de solución
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


                // Segundo conjunto de botones: en el centro

                /*
                Scene scene = SpaceWork.VideoGame.Context.SceneManager.CurrentScene;
                List<Scene> scenes = SpaceWork.VideoGame.Context.SceneManager.Scenes;

                int numberCharsName = scene.Name.Length + 1;
                ImGui.SetNextItemWidth(32 + numberCharsName * 10);

                if (ImGui.BeginCombo($"##{scene.Id}", $"{FontAwesome5.Cube} {scene.Name}"))
                {
                    // Show the scenes of game:
                    for (int i = 0; i < scenes.Count; i++)
                    {
                        Scene s = scenes[i];
                        if (ImGui.Selectable($"{FontAwesome5.Cube} {s.Name}"))
                        {
                            SpaceWork.VideoGame.Context.SceneManager.LoadScene(i);
                        }
                    }

                    ImGui.EndCombo();
                }*/


                ImGui.SameLine();

                // Botones de control: Play, Pause, Stop
                float controlOffset = ImGui.GetWindowWidth() * 0.5f - 65;
                ImGui.SameLine(controlOffset);
                if (ImGui.Button($"{FontAwesome5.Play}"))
                {
                    Logger.Info("Ejecutando juego...");
                }

                ImGui.SameLine();
                if (ImGui.Button($"{FontAwesome5.Pause}"))
                {
                    Logger.Info("Pausando juego...");
                }

                ImGui.SameLine();
                if (ImGui.Button($"{FontAwesome5.Stop}"))
                {
                    Logger.Info("Deteniendo juego...");
                }

                ImGui.SameLine();

                // Botón de compilación
                float compileOffset = ImGui.GetWindowWidth() - 295;
                ImGui.SameLine(compileOffset);
                if (ImGui.Button($"{FontAwesome5.Hammer}"))
                {
                    Logger.Info("Compilando proyecto...");
                }

                // Selector de plataforma y modo de compilación
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

                /*
                ImGui.SameLine();
                ImGui.SetNextItemWidth(100);
                if (ImGui.BeginCombo("##platform", $"{FontAwesome5.LaptopCode} MacOS", ImGuiComboFlags.HeightLarge))
                {
                    if (ImGui.Selectable("Windows"))
                    {
                    }

                    if (ImGui.Selectable("MacOS"))
                    {
                    }

                    ImGui.EndCombo();
                }*/

                // Espaciado y botones finales (Buscar y Configuración)
                //ImGui.Spacing();
                //ImGui.Spacing();
                //ImGui.Spacing();


                if (ImGui.Button($"{FontAwesome5.Search}"))
                {
                    Logger.Info("Abriendo buscador...");
                }

                ImGui.SameLine();
                if (ImGui.Button($"{FontAwesome5.Cog}"))
                {
                    Logger.Info("Abriendo ajustes...");
                }

                ImGui.PopStyleColor(2);
                ImGui.PopStyleVar();

                //ImGui.PopStyleVar();
                ImGui.EndMenuBar();
            }
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}