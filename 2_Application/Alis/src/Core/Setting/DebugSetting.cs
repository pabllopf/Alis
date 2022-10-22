// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DebugSetting.cs
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
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Setting
{
    /// <summary>
    ///     The debug class
    /// </summary>
    public class DebugSetting : SettingBase,
        IBuilder<DebugSettingBuilder>
    {
        /// <summary>
        ///     The log level
        /// </summary>
        public LogLevel Level { get; set; } = LogLevel.Normal;

        /// <summary>
        ///     Gets or sets the value of the create file log
        /// </summary>
        public bool CreateFileLog { get; set; } = true;

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The debug setting builder</returns>
        public new DebugSettingBuilder Builder() => new DebugSettingBuilder();
    }
}