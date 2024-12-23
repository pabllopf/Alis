// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ASection.cs
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

using Alis.App.Hub.Core;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The section class
    /// </summary>
    /// <seealso cref="IRuntime" />
    public abstract class ASection : IRuntime
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASection" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ASection(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets or sets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; set; }

        /// <summary>
        ///     Gets or sets the value of the title
        /// </summary>
        public string Title { get; set; } = "Window";

        /// <summary>
        ///     Gets or sets the value of the is open
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is focused
        /// </summary>
        public bool IsFocused { get; set; }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public abstract void OnInit();

        /// <summary>
        ///     Ons the start
        /// </summary>
        public abstract void OnStart();

        /// <summary>
        ///     Ons the update
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        ///     Ons the render
        /// </summary>
        public abstract void OnRender();

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public abstract void OnDestroy();
    }
}