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
        private static float[] color1 = new float[3] { 0.0f, 0.5f, 0.5f };
        private static float[] color1Temp = new float[3] { 0.0f, 0.5f, 0.5f };

        public void Render()
        {
            ImGui.SetNextWindowPos(0, 0, "ImGui.Cond.Once");
            ImGui.SetNextWindowSize(800, 600, "ImGui.Cond.Once");
            ImGui.Begin("Main Window");
            ImGui.Text("Hello, World!");
            ImGui.TextColored(1.0f, 0.0f, 0.0f, 1.0f, "This is red text.");
            ImGui.TextDisabled("This text is disabled.");
            
            float[] values = { 0.0f, 1.0f, 2.0f, 3.0f, 4.0f };
            ImGui.PlotLines("Line Plot", values, values.Length, 0, "Overlay Text", 0.0f, 5.0f, 200.0f, 200.0f);
            ImGui.PlotHistogram("Histogram Plot", values, values.Length, 0, "Overlay Text", 0.0f, 5.0f, 400.0f, 200.0f);

            color1Temp = color1;
            ImGui.ColorEdit3("Color Picker", color1Temp);
            
            
            ImGui.Text("This is a simple ImGui window rendered in Blazor WebAssembly.");
            
            ImGui.End();
        }

        public static void SetColor(float f, float f1, float f2)
        {
            if (color1.Length == 3)
            {
                color1[0] = f;
                color1[1] = f1;
                color1[2] = f2;
                Console.WriteLine($"Color set to: {f}, {f1}, {f2}");
            }
            else
            {
                throw new ArgumentException("Color array must have exactly 3 elements for RGB.");
            }
        }
    }
}