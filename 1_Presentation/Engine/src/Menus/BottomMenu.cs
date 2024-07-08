// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TopMenu.cs
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

using Alis.App.Engine.Core;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    /// The bottom menu class
    /// </summary>
    /// <seealso cref="IMenu"/>
    public class BottomMenu : IMenu
    {
        /// <summary>
        ///     The menu down state
        /// </summary>
        private bool menuDownState = true;

        /// <summary>
        /// The size menu down
        /// </summary>
        private const int SizeMenuDown = 25;

        /// <summary>
        /// Initializes a new instance of the <see cref="BottomMenu"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public BottomMenu(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
        }

        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
        
        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            // Add menu bar flag and disable everything else
            ImGuiWindowFlags styleGlagsMenuDown =
                ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoInputs |
                ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollWithMouse |
                ImGuiWindowFlags.NoSavedSettings |
                ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoBackground |
                ImGuiWindowFlags.MenuBar;

            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0.0f, 0.0f));

            ImGui.SetNextWindowPos(new Vector2(SpaceWork.Viewport.Pos.X, SpaceWork.Viewport.Pos.Y + (SpaceWork.Viewport.Size.Y - SizeMenuDown)));
            ImGui.SetNextWindowSize(new Vector2(SpaceWork.Viewport.Size.X, SizeMenuDown));
            if (ImGui.Begin("##MenuDown", ref menuDownState, styleGlagsMenuDown))
            {
                ImGui.PopStyleVar(3);
                if (ImGui.BeginMenuBar())
                {
                    ImGui.Text("Hello world from menu down");

                    ImGui.Button("sample");

                    ImGui.EndMenuBar();
                }


                ImGui.End();
            }
        }
    }
}