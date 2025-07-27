// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProjectWindow.cs
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

using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Desktop.Windows
{
    /// <summary>
    ///     The project window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class ProjectWindow : IWindow
    {
        /// <summary>
        ///     The stream
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Stream} Project";
        
        private bool _isOpen = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ProjectWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
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

        public void Render()
        {
            if (!_isOpen)
            {
                return;
            }
            
            if(ImGui.Begin(NameWindow, ref _isOpen, ImGuiWindowFlags.NoCollapse))
            {
                ImGui.Text("Project Window");
            }
            
            ImGui.End();
        }
    }
}