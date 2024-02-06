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

using Alis.Builder.Core.Ecs.System.Setting.General;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.System.Setting.General
{
    /// <summary>
    ///     The general setting class
    /// </summary>
    /// <seealso cref="IGeneralSetting" />
    /// <seealso cref="IBuilder{TOut}" />
    public class GeneralSetting :
        IGeneralSetting,
        IBuilder<GeneralSettingBuilder>
    {
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The graphic setting builder</returns>
        public GeneralSettingBuilder Builder() => new GeneralSettingBuilder();

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; } = "Default Name";

        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; } = "Default Description";

        /// <summary>
        ///     Gets or sets the value of the version
        /// </summary>
        public string Version { get; set; } = "0.0.0";

        /// <summary>
        ///     Gets or sets the value of the author
        /// </summary>
        public string Author { get; set; } = "Pablo Perdomo Falcón";

        /// <summary>
        ///     Gets or sets the value of the license
        /// </summary>
        public string License { get; set; } = "GPL-3.0 license";

        /// <summary>
        ///     Gets or sets the value of the icon
        /// </summary>
        public string Icon { get; set; } = AssetManager.Find("app.bmp");

        /// <summary>
        /// Gets or sets the value of the debug
        /// </summary>
        public bool Debug { get; set; } = false;
    }
}