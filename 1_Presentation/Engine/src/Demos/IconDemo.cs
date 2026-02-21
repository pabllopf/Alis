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

using System.Diagnostics;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The icon demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class IconDemo : IDemo
    {
        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public static string Name => "Icon Demo";

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            SimpleIcons();
        }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Simples the icons
        /// </summary>
        [Conditional("DEBUG")]
        private void SimpleIcons()
        {
            if (ImGui.Begin(Name))
            {
                ImGui.Separator();
                ImGui.Text("Font Awesome 5");
                ImGui.Text($" {FontAwesome5.Bug} {FontAwesome5.Bullhorn} {FontAwesome5.Bullseye} {FontAwesome5.Calendar}");
            }

            ImGui.End();
        }
    }
}