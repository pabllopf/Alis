// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainRender.cs
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

using Microsoft.JSInterop;

namespace Alis.App.Engine.Web
{
    internal class MainRender : IRender
    {
        private float R = 1.0f;
        private float G = 0.0f;
        private float B = 0.0f;
        
        public void Render()
        {
           /* ImGui.SetNextWindowPos(0, 0, "ImGui.Cond.Once");
            ImGui.SetNextWindowSize(800, 600, "ImGui.Cond.Once");
            ImGui.Begin("Main Window");
            ImGui.Text("Hello, World!");
            ImGui.TextColored(1.0f, 0.0f, 0.0f, 1.0f, "This is red text.");
            ImGui.TextDisabled("This text is disabled.");
            
            float[] values = { 0.0f, 1.0f, 2.0f, 3.0f, 4.0f };
            ImGui.PlotLines("Line Plot", values, values.Length, 0, "Overlay Text", 0.0f, 5.0f, 200.0f, 200.0f);
            ImGui.PlotHistogram("Histogram Plot", values, values.Length, 0, "Overlay Text", 0.0f, 5.0f, 400.0f, 200.0f);
            
            ImGui.ColorEdit3("Color Picker", [R, G, B], ChangeColor);
            
            
            ImGui.Text("This is a simple ImGui window rendered in Blazor WebAssembly.");
            
            ImGui.End();*/
        }

        private void ChangeColor(float arg1, float arg2, float arg3)
        {
            R = arg1;
            G = arg2;
            B = arg3;
            Console.WriteLine($"Color set to: R={arg1}, G={arg2}, B={arg3}");
        }

    }
}