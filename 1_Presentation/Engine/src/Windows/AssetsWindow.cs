// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetsWindow.cs
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
using System.Runtime.InteropServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The assets window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class AssetsWindow : IWindow
    {
        private static readonly string WindowName = $"{FontAwesome5.FolderOpen} Assets";

        /// <summary>
        ///     The command ptr
        /// </summary>
        private readonly IntPtr commandPtr;

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AssetsWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public AssetsWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
            commandPtr = Marshal.AllocHGlobal(256);
        }

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
            if (!isOpen)
            {
                return;
            }

            if (ImGui.Begin(WindowName, ref isOpen))
            {
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.13f, 0.14f, 0.15f, 1.0f));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4(0.13f, 0.14f, 0.15f, 1.0f));

                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);

                ImGui.SetNextItemWidth(32);
                if (ImGui.BeginCombo("##Plus", $"{FontAwesome5.Plus}", ImGuiComboFlags.HeightLargest | ImGuiComboFlags.NoArrowButton))
                {
                    ImGui.Separator();

                    // Opciones principales
                    if (ImGui.Selectable("Folder")) { }
                    if (ImGui.Selectable("Material")) { }
                    if (ImGui.Selectable("MonoBehaviour Script")) { }
                    ImGui.TextDisabled("Prefab Variant"); // Opción deshabilitada

                    ImGui.Separator();

                    // Submenús
                    if (ImGui.BeginMenu("2D"))
                    {
                        // Agrega opciones específicas de 2D aquí si es necesario
                        ImGui.EndMenu();
                    }
                    if (ImGui.BeginMenu("Animation")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Audio")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Rendering")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Scene")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Scripting")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Search")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Shader")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Shader Graph")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Testing")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Terrain")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Text Core")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("TextMeshPro")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Tutorials")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("Timeline")) { ImGui.EndMenu(); }
                    if (ImGui.BeginMenu("UI Toolkit")) { ImGui.EndMenu(); }

                    ImGui.Separator();

                    // Opciones finales
                    if (ImGui.Selectable("Physics Material")) { }
                    if (ImGui.Selectable("GUI Skin")) { }
                    if (ImGui.Selectable("Custom Font")) { }

                    ImGui.EndCombo();
                }


                ImGui.PopStyleVar(1);
                ImGui.PopStyleColor(2);

                ImGui.SameLine();
                ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - 30);
                ImGui.InputText($"{FontAwesome5.Search}", commandPtr, 256);
                ImGui.Separator();

                ImGui.Columns(2);

                // Obtener el ancho actual de la columna
                float currentWidth = ImGui.GetColumnWidth(0);

                // Configurar límites de la columna
                float minWidth = 100.0f;
                float maxWidth = 300.0f;

                // Ajustar el ancho dentro de los límites
                if (currentWidth < minWidth)
                {
                    ImGui.SetColumnWidth(0, minWidth);
                }
                else if (currentWidth > maxWidth)
                {
                    ImGui.SetColumnWidth(0, maxWidth);
                }

                // Contenido de la primera columna
                ImGui.Text("Directory");

                if (ImGui.TreeNodeEx("Folder"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ImGui.Text($"Folder {i}");
                    }

                    ImGui.TreePop();
                }

                ImGui.NextColumn();

                // Contenido de la segunda columna
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.13f, 0.14f, 0.15f, 1.0f));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4(0.13f, 0.14f, 0.15f, 1.0f));

                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(0, 7));
                ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(2, 5));

                ImGui.Button("Assets");
                ImGui.SameLine();
                ImGui.Text(">");
                ImGui.SameLine();
                ImGui.Button("Textures");

                ImGui.PopStyleVar(3);
                ImGui.PopStyleColor(2);

                ImGui.BeginChild("ScrollingRegion", ImGui.GetContentRegionAvail(), false, ImGuiWindowFlags.HorizontalScrollbar);

                ImGui.Text("Files");
                for (int i = 0; i < 5; i++)
                {
                    ImGui.Text($"Texture {i}");
                }

                ImGui.EndChild();

                //ImGui.EndColumns(); // Finalizar las columnas
            }

            ImGui.End();

        }
    }
}