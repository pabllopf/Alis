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

        public void Render(ImGuiFrameBuilder imgui)
        {
            imgui.Begin("Hola");
            imgui.Text("Texto");
            imgui.SliderFloat("Slider", _checkboxValue, 0.0f, 1.0f);
            imgui.End();
                
            imgui.Begin("Hola mundo 2");
            imgui.Text("Texto 3332");
            imgui.SliderFloat("Slider22", _checkboxValue2, 0.0f, 1.0f);
            imgui.End();
        }

        public void ProcessEvent(string name, object value)
        {
            if (name == "Slider")
            {
                if (value is float floatValue)
                {
                    _checkboxValue = floatValue;
                }
            }
            
            if (name == "Slider22")
            {
                if (value is float floatValue)
                {
                    _checkboxValue2 = floatValue;
                }
            }
        }
    }
}