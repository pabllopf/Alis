// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayer.cs
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
using Alis.App.Engine.Core;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    public class AudioPlayerWindow : IWindow
    {
        private const string WindowName = "Audio Player";
        
        private bool isOpen = true;

        private ImGuiWindowFlags flags = ImGuiWindowFlags.NoCollapse;
        
        public SpaceWork SpaceWork { get; }
        
        public AudioPlayerWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
        }
        
        public void Render()
        {
            if (!isOpen)
            {
                Console.WriteLine("Audio Player Window is closed");
                return;
            }
            
            if (ImGui.Begin(WindowName, ref isOpen, flags))
            {
                ImGui.Text("Sample");
            }   
            ImGui.End();
        }
    }
}