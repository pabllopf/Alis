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
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The console window class
    /// </summary>
    public class ConsoleWindow : IWindow
    {
        private bool isOpen = true;
        
        private ImGuiWindowFlags flags = ImGuiWindowFlags.NoCollapse;
        
        private byte[] command = new byte[256];
        
        private IntPtr commandPtr;

        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleWindow"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ConsoleWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
            commandPtr  = Marshal.AllocHGlobal(256);
        }
        

        /// <summary>
        ///     The name window
        /// </summary>
        private const string NameWindow = "Console";

        public void Initialize()
        {
            
        }

        public void Start()
        {
            
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
         public void Render()
        {
            if (!isOpen) return;
            
            if (ImGui.Begin(NameWindow, ref isOpen, flags))
            {
                ImGui.Button("Clear");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.Search}");
                ImGui.SameLine();
                ImGui.InputText("##input", commandPtr, 256, ImGuiInputTextFlags.NoHorizontalScroll);
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.ExclamationCircle}");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.ExclamationTriangle}");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.Bug}");
                
                for (int i = 0; i < 10; i++)
                {
                    ImGui.Text($"{FontAwesome5.Bug} [{DateTime.Now}] Line {i}");
                }
                
            }
            
            ImGui.End();
        }
        
        private string[] GetTerminalOutput()
        {
            return new string[0];
        }
    }
}