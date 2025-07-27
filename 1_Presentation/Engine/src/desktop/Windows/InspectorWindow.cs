// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InspectorWindow.cs
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
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Desktop.Windows
{
    /// <summary>
    ///     The inspector window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class InspectorWindow : IWindow
    {
        /// <summary>
        ///     The info circle
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.InfoCircle} Inspector";
        
        private bool _isOpen = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InspectorWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public InspectorWindow(SpaceWork spaceWork)
        {
            this.SpaceWork = spaceWork;
        }
        
        public SpaceWork SpaceWork { get; }

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

        public void Render()
        {
            if (!_isOpen)
            {
                return;
            }

            if(ImGui.Begin(NameWindow, ref _isOpen, ImGuiWindowFlags.NoCollapse))
            {
                ImGui.Text("Inspector Window");
                ImGui.Text("This is a placeholder for the inspector functionality.");
            }
            
            ImGui.End();
        }
    }
}