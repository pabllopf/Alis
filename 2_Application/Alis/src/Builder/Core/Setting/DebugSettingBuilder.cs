// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DebugSettingBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Setting;

namespace Alis.Builder.Core.Setting
{
    /// <summary>
    ///     The debug setting builder class
    /// </summary>
    public class DebugSettingBuilder :
        IBuild<DebugSetting>
    {
        /// <summary>
        ///     The debug setting
        /// </summary>
        private readonly DebugSetting debugSetting = new DebugSetting();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The debug setting</returns>
        public DebugSetting Build() => debugSetting;

        /// <summary>
        /// Logs the level using the specified log level
        /// </summary>
        /// <param name="logLevel">The log level</param>
        /// <returns>The debug setting builder</returns>
        public DebugSettingBuilder LogLevel(LogLevel logLevel)
        {
            debugSetting.Level = logLevel;
            Logger.LogLevel = logLevel;
            return this;
        }
    }
}