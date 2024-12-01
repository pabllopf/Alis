// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleWindow.cs
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
    ///     The console window class
    /// </summary>
    public class ConsoleWindow : IWindow
    {
        private static readonly string NameWindow = $"{FontAwesome5.Terminal} Console";

        /// <summary>
        ///     The command ptr
        /// </summary>
        private readonly IntPtr commandPtr;

        /// <summary>
        ///     The no collapse
        /// </summary>
        private readonly ImGuiWindowFlags flags = ImGuiWindowFlags.NoCollapse;

        /// <summary>
        ///     The command
        /// </summary>
        private byte[] command = new byte[256];

        /// <summary>
        ///     The is open
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConsoleWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ConsoleWindow(SpaceWork spaceWork)
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

            if (ImGui.Begin(NameWindow, ref isOpen, flags))
            {
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.13f, 0.14f, 0.15f, 1.0f));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4(0.13f, 0.14f, 0.15f, 1.0f));

                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0.0f);
                // Barra superior con botones y filtro
                ImGui.Button($"{FontAwesome5.TrashAlt}");


                ImGui.PopStyleVar(1);
                ImGui.PopStyleColor(2);

                ImGui.SameLine();

                // Ajuste dinámico del ancho del filtro
                // Calculamos el ancho disponible menos el espacio ocupado por los botones finales
                float buttonWidth = 32 + ImGui.GetStyle().ItemSpacing.X;
                float remainingButtonsWidth = buttonWidth * 4f; // 3 botones a la derecha
                float filterWidth = ImGui.GetContentRegionAvail().X - remainingButtonsWidth;
                if (filterWidth > 0)
                {
                    ImGui.SetNextItemWidth(filterWidth);
                }

                ImGui.InputText($"{FontAwesome5.Search}", commandPtr, 256);

                ImGui.SameLine();

                ImGui.Spacing();
                ImGui.SameLine();
                ImGui.Spacing();
                ImGui.SameLine();

                ImGui.Button($"{FontAwesome5.ExclamationCircle}");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.ExclamationTriangle}");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.Bug}");

                // Espacio para el área de scroll
                ImGui.Separator(); // Opcional: para separar visualmente las secciones

                // Contenedor con scroll
                ImGui.BeginChild("ScrollingRegion", ImGui.GetContentRegionAvail(), false, ImGuiWindowFlags.HorizontalScrollbar);
                for (int i = 0; i < 100; i++)
                {
                    ImGui.Text($"{FontAwesome5.Bug} [{DateTime.Now}] Line {i}");
                }

                ImGui.EndChild();
            }

            ImGui.End();
        }

        /// <summary>
        ///     Gets the terminal output
        /// </summary>
        /// <returns>The string array</returns>
        private string[] GetTerminalOutput() => new string[0];
    }
}