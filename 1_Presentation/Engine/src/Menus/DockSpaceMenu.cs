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

using System;
using System.IO;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Menus
{
    internal class DockSpaceMenu : IMenu
    {
        public void Initialize()
        {
           
        }

       public void Update()
{
    // Establece el padding de la ventana
   //ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);  // Igual padding arriba y abajo
    //ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(4, 4f));
    //ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(4, 4));

    // Set height of the menu bar
    //ImGui.SetWindowSize(new Vector2(0, 5), ImGuiCond.Always);
    
    // Crear barra de menú
    if (ImGui.BeginMenuBar())
    {
        // Elementos centrados dinámicamente
        //float contentHeight = ImGui.GetContentRegionAvail().Y;  // Obtiene el espacio disponible en la ventana
        //float centerOffsetY = contentHeight * 0.5f;  // Calcula el centro vertical

        // Establece la posición de la ventana de manera que se centre verticalmente
        ImGui.SetCursorPosY(2.5f);  // Ajuste para alinear mejor el contenido
        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(4, 5f)); // Ajustar el espaciado si es necesario
        
        // Primer conjunto de botones: izquierda
        if (ImGui.Button($"{FontAwesome5.ArrowLeft}", new Vector2(30, 24)))
        {
            // Lógica para retroceder
            Console.WriteLine("Retrocediendo...");
            ImGui.LoadIniSettingsFromDisk(AssetManager.Find("default_config.ini"));
        }
        ImGui.SameLine();

        if (ImGui.Button($"{FontAwesome5.ArrowRight}", new Vector2(30, 24)))
        {
            // Lógica para avanzar
            Console.WriteLine("Avanzando...");
            ImGui.LoadIniSettingsFromDisk(AssetManager.Find("tall_config.ini"));
        }
        ImGui.SameLine();

        
        // Selector de solución
        ImGui.SetNextItemWidth(100);
        if (ImGui.BeginCombo("##Solution Name", $"{FontAwesome5.Font} Alis", ImGuiComboFlags.HeightLarge))
        {
            ImGui.Separator();
            if (ImGui.Selectable($"{FontAwesome5.Plus} New Solution")) { }
            if (ImGui.Selectable($"{FontAwesome5.FolderOpen} Open Solution")) { }
            ImGui.Separator();
            ImGui.TextDisabled("Recent Solutions");
            if (ImGui.Selectable($"Sample Solution")) { }
            ImGui.EndCombo();
        }
        ImGui.SameLine();
        
        

        // Segundo conjunto de botones: en el centro
        ImGui.SetNextItemWidth(120);
        if (ImGui.BeginCombo("##Scene", $"{FontAwesome5.Cube} Main Menu"))
        {
            if (ImGui.Selectable("Main Menu")) { }
            ImGui.EndCombo();
        }
        ImGui.SameLine();

        // Botones de control: Play, Pause, Stop
        float controlOffset = ImGui.GetWindowWidth() * 0.5f - 65;
        ImGui.SameLine(controlOffset);
        if (ImGui.Button($"{FontAwesome5.Play}", new Vector2(30, 24))) { Console.WriteLine("Ejecutando juego..."); }
        ImGui.SameLine();
        if (ImGui.Button($"{FontAwesome5.Pause}", new Vector2(30, 24))) { Console.WriteLine("Pausando juego..."); }
        ImGui.SameLine();
        if (ImGui.Button($"{FontAwesome5.Stop}", new Vector2(30, 24))) { Console.WriteLine("Deteniendo juego..."); }
        ImGui.SameLine();

        // Botón de compilación
        float compileOffset = ImGui.GetWindowWidth() * 0.75f - 32;
        ImGui.SameLine(compileOffset);
        if (ImGui.Button($"{FontAwesome5.Hammer}", new Vector2(30, 25))) { Console.WriteLine("Compilando proyecto..."); }

        // Selector de plataforma y modo de compilación
        ImGui.SetNextItemWidth(170);
        if (ImGui.BeginCombo("##Build Mode", $"{FontAwesome5.Edit} Release | Any CPU", ImGuiComboFlags.HeightSmall))
        {
            if (ImGui.Selectable("Debug | Any CPU")) { }
            if (ImGui.Selectable("Release | Any CPU")) { }
            ImGui.EndCombo();
        }
        ImGui.SameLine();
        ImGui.SetNextItemWidth(100);
        if (ImGui.BeginCombo("##platform", $"{FontAwesome5.LaptopCode} MacOS", ImGuiComboFlags.HeightLarge))
        {
            if (ImGui.Selectable("Windows")) { }
            if (ImGui.Selectable("MacOS")) { }
            ImGui.EndCombo();
        }

        // Espaciado y botones finales (Buscar y Configuración)
        ImGui.Spacing();
        ImGui.Spacing();
        if (ImGui.Button($"{FontAwesome5.Search}", new Vector2(30, 24))) { Console.WriteLine("Abriendo buscador..."); }
        ImGui.SameLine();
        if (ImGui.Button($"{FontAwesome5.Cog}", new Vector2(30, 24))) { Console.WriteLine("Abriendo ajustes..."); }

        ImGui.PopStyleVar();
        ImGui.EndMenuBar();
    }

    // Restaurar los valores de estilo anteriores
    //ImGui.PopStyleVar(2);
   //ImGui.PopStyleVar();
}


        void IRuntime.Render()
        {
           
        }

        public void Start()
        {
           
        }

        void IRenderable.Render()
        {
            
        }

        public SpaceWork SpaceWork { get; }
    }
}