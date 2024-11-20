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
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Menus
{
    /// <summary>
    ///     The top menu class
    /// </summary>
    /// <seealso cref="IMenu" />
    public class TopMenu : IMenu
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TopMenu" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public TopMenu(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            ImGui.BeginMainMenuBar();
            if (ImGui.BeginMenu("File"))
            {
                if (ImGui.MenuItem("Open")) 
                {
                    // Acción al seleccionar "Open"
                }

                if (ImGui.MenuItem("Save")) 
                {
                    // Acción al seleccionar "Save"
                }

                if (ImGui.MenuItem("Exit")) 
                {
                    // Acción al seleccionar "Exit"
                }
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Edit"))
            {
                if (ImGui.MenuItem("Undo")) 
                {
                    // Acción al seleccionar "Undo"
                }

                if (ImGui.MenuItem("Redo")) 
                {
                    // Acción al seleccionar "Redo"
                }
                ImGui.EndMenu();
            }

            ImGui.EndMainMenuBar();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}