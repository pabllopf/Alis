// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneWindow.cs
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
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The scene window class
    /// </summary>
    public class SceneWindow : IWindow
    {
        private const string NameWindow = "Scene";
        
        private bool isOpen = true;
        
        private ImGuiWindowFlags windowFlags = ImGuiWindowFlags.NoCollapse;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneWindow"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SceneWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
        }
        
        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            if (!isOpen)return;

            if (ImGui.Begin(NameWindow, ref isOpen, windowFlags))
            { 
                ImGui.Text($"FPS: {SpaceWork.Fps}");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.Pause}");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.Play}");
                ImGui.SameLine();
                ImGui.Button($"{FontAwesome5.Stop}");
                ImGui.NewLine();
                
                ImGui.Image(
                    IntPtr.Zero,
                    new Vector2(640, 380),
                    new Vector2(1, 1),
                    new Vector2(1, 1),
                    new Vector4(255, 0, 0, 255));

            }
            
            ImGui.End();
        }

        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}