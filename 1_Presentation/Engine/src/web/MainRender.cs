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
    /// <summary>
    /// The main render class
    /// </summary>
    /// <seealso cref="IRender"/>
    internal class MainRender : IRender
    {
        /// <summary>
        /// The checkbox value
        /// </summary>
        private float _checkboxValue = 0.5f;
        
        /// <summary>
        /// The checkbox value
        /// </summary>
        private float _checkboxValue2 = 0.5f;
        
        /// <summary>
        /// The checkbox value
        /// </summary>
        private bool checkboxValue3 = false;
        /// <summary>
        /// The checkbox value
        /// </summary>
        private bool checkboxValue4 = false;
        
        /// <summary>
        /// The color value
        /// </summary>
        private float[] _colorValue = new float[] { 1.0f, 0.0f, 0.0f }; // Default color red

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            ImGui.Begin("Hola", value =>
            {
                Console.WriteLine($"Window is now {(value ? "open" : "closed")}");
            });
            
            ImGui.Text("Texto");
            
            
            ImGui.SliderFloat("Slider", _checkboxValue, 0.0f, 1.0f, value =>
            {
                _checkboxValue = value;
                Console.WriteLine($"Slider value changed: {_checkboxValue}");
            });
            
            ImGui.SliderFloat("Slider22", _checkboxValue2, 0.0f, 1.0f, value =>
            {
                _checkboxValue2 = value;
                Console.WriteLine($"Slider22 value changed: {_checkboxValue2}");
            });
            
            ImGui.TextColored(new float[] { 1.0f, 0.0f, 0.0f }, "Texto rojo");
            ImGui.TextColored(new float[] { 0.0f, 0.0f, 1.0f }, "Texto azul");
            ImGui.TextColored(new float[] { 0.0f, 1.0f, 0.0f }, "Texto verde");
            
            ImGui.TextDisabled("Texto deshabilitado");
            
            ImGui.Separator();
            
            ImGui.Text("Texto normal");
            
            ImGui.Text("Texto normal 2");
            
            ImGui.Checkbox("Checkbox", checkboxValue3, value =>
            {
                checkboxValue3 = value;
                Console.WriteLine($"Checkbox 1 value changed: {checkboxValue3}");
            });
            
            ImGui.Checkbox("Checkbox 2", checkboxValue4 , value =>
            {
                checkboxValue4 = value;
                Console.WriteLine($"Checkbox 2 value changed: {checkboxValue4}");
            });
            
            ImGui.Button("Button");
            
            ImGui.ColorEdit3("ColorEdit3", _colorValue , value =>
            {
                _colorValue = value;
                Console.WriteLine($"ColorEdit3 value changed: {_colorValue[0]}, {_colorValue[1]}, {_colorValue[2]}");
            });
            
            
            ImGui.PlotHistogram("histogram", new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }, 5, "Histogram", 0.0f, 1.0f, new float[] { 0, 80 });
            
            ImGui.PlotLines("lines", new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }, 5, "Lines", 0.0f, 1.0f, new float[] { 0, 80 });
            
            
            
            ImGui.End();
            
        }
    }
}