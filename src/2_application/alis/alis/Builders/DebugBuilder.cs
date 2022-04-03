// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DebugBuilder.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core;
using Alis.Core.Configurations;
using Alis.Core.FluentApi;
using Alis.Tools;

namespace Alis.Builders
{
    /// <summary>
    ///     The debug builder class
    /// </summary>
    /// <seealso cref="IBuild{TOrigin}" />
    public class DebugBuilder :
        IBuild<Debug>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The debug</returns>
        public Debug Build() => Game.Setting.Debug;

        /// <summary>
        ///     Logs the level using the specified log level
        /// </summary>
        /// <param name="logLevel">The log level</param>
        /// <returns>The debug builder</returns>
        public DebugBuilder LogLevel(LogLevel logLevel)
        {
            Logger.Level = logLevel;
            Game.Setting.Debug.LogLevel = logLevel;
            return this;
        }

        /// <summary>
        ///     Shows the physic borders using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The debug builder</returns>
        public DebugBuilder ShowPhysicBorders(bool value)
        {
            Game.Setting.Debug.ShowPhysicBorders = value;
            return this;
        }
    }
}