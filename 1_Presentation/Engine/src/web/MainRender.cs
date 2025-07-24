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
        private float _checkboxValue = 0.5f;
        
        private float _checkboxValue2 = 0.5f;
        
        private bool checkboxValue3 = false;
        private bool checkboxValue4 = false;
        
        private float[] _colorValue = new float[] { 1.0f, 0.0f, 0.0f }; // Default color red

        public void Render(ImGuiFrameBuilder imgui)
        {
            imgui.Begin("Hola");
            
            imgui.Text("Texto");
            
            
            imgui.SliderFloat("Slider", _checkboxValue, 0.0f, 1.0f);
            imgui.SliderFloat("Slider22", _checkboxValue2, 0.0f, 1.0f);
            
            imgui.TextColored(new float[] { 1.0f, 0.0f, 0.0f }, "Texto rojo");
            imgui.TextColored(new float[] { 0.0f, 0.0f, 1.0f }, "Texto azul");
            imgui.TextColored(new float[] { 0.0f, 1.0f, 0.0f }, "Texto verde");
            
            imgui.TextDisabled("Texto deshabilitado");
            
            imgui.Separator();
            
            imgui.Text("Texto normal");
            
            imgui.Text("Texto normal 2");
            
            imgui.Checkbox("Checkbox", checkboxValue3);
            imgui.Checkbox("Checkbox 2", checkboxValue4);
            
            imgui.Button("Button");
            
            imgui.ColorEdit3("ColorEdit3", _colorValue);
            
            
            imgui.PlotHistogram("histogram", new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }, 5, "Histogram", 0.0f, 1.0f, new float[] { 0, 80 });
            
            imgui.PlotLines("lines", new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }, 5, "Lines", 0.0f, 1.0f, new float[] { 0, 80 });
            
            imgui.End();
            
        }

        public void ProcessEvent(string name, object? value)
        {
            if (name == "Slider")
            {
                _checkboxValue = Convert.ToSingle(value);
            }
            
            if (name == "Slider22")
            {
                _checkboxValue2 = Convert.ToSingle(value);
            }

            if (name == "Checkbox")
            {
                checkboxValue3 = Convert.ToBoolean(value);
            }
            
            if (name == "Checkbox 2")
            {
                checkboxValue4 = Convert.ToBoolean(value);
            }

            if (name == "ColorEdit3")
            {
                if (value is System.Text.Json.JsonElement elem && elem.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    _colorValue = elem.EnumerateArray().Select(x => x.GetSingle()).ToArray();
                }
            }
        }
    }
}