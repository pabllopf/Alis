// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSetting.cs
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

namespace Alis.Core.Ecs.Systems.Configuration.General
{
    /// <summary>
    /// The general setting class
    /// </summary>
    /// <seealso cref="IGeneralSetting"/>
    public class GeneralSetting(
        bool debug = false,
        string name = "Default Name",
        string description = "Default Description",
        string version = "0.0.0",
        string author = "Pablo Perdomo Falcón",
        string license = "GPL-3.0 license",
        string icon = "app.jpeg") : IGeneralSetting
    {
        /// <summary>
        /// Gets or sets the value of the debug
        /// </summary>
        public bool Debug { get; set; } = debug;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; } = name;

        /// <summary>
        /// Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; } = description;

        /// <summary>
        /// Gets or sets the value of the version
        /// </summary>
        public string Version { get; set; } = version;

        /// <summary>
        /// Gets or sets the value of the author
        /// </summary>
        public string Author { get; set; } = author;

        /// <summary>
        /// Gets or sets the value of the license
        /// </summary>
        public string License { get; set; } = license;

        /// <summary>
        /// Gets or sets the value of the icon
        /// </summary>
        public string Icon { get; set; } = icon;
    }
}