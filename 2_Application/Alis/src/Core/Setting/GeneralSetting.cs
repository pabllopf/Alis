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

using Alis.Builder.Core.Setting;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Setting
{
    /// <summary>Define a </summary>
    public class GeneralSetting : SettingBase,
        IBuilder<GeneralSettingBuilder>
    {
        /// <summary>
        ///     Gets or sets the value of the game name
        /// </summary>
        public string Name { get; set; } = "Alis Game";

        /// <summary>
        ///     Gets or sets the value of the author
        /// </summary>
        public string Author { get; set; } = "Default Author";

        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; } = "Default description of game.";

        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The general setting builder</returns>
        public new GeneralSettingBuilder Builder() => new GeneralSettingBuilder();
    }
}