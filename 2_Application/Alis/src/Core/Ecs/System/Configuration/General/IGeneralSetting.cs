// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGeneralSetting.cs
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

namespace Alis.Core.Ecs.System.Configuration.General
{
    /// <summary>
    ///     The general setting interface
    /// </summary>
    public interface IGeneralSetting
    {
        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        bool Debug { get; set; }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets the value of the version
        /// </summary>
        string Version { get; set; }

        /// <summary>
        ///     Gets or sets the value of the author
        /// </summary>
        string Author { get; set; }

        /// <summary>
        ///     Gets or sets the value of the license
        /// </summary>
        string License { get; set; }

        /// <summary>
        ///     Gets or sets the value of the icon
        /// </summary>
        string Icon { get; set; }
    }
}