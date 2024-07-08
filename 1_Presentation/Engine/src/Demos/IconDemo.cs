// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IconDemo.cs
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

using Alis.App.Engine.Fonts;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Demos
{
    public class IconDemo : IDemo
    {
        public void Run()
        {
            if (ImGui.Begin("Icon Demo"))
            {
                ImGui.Text("Font Awesome 4");
                ImGui.Text("Regular");
                ImGui.Text($"icon: {FontAwesome4.Coffee}");
                ImGui.Text("Solid");
                ImGui.Text($"icon: {FontAwesome4.BatteryFull}");
                ImGui.Text("Brands");
                ImGui.Text($"icon: {FontAwesome4.Github}");
            }
            ImGui.End();
        }
    }
}