// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Debug.cs
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

using System.Text.Json.Serialization;
using Alis.Tools;

namespace Alis.Core.Configurations
{
    /// <summary>
    ///     The debug class
    /// </summary>
    public class Debug
    {
        /// <summary>
        ///     The log level
        /// </summary>
        private LogLevel logLevel;

        /// <summary>
        ///     The show physic borders
        /// </summary>
        private bool showPhysicBorders;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Debug" /> class
        /// </summary>
        public Debug()
        {
            ShowPhysicBorders = false;
            LogLevel = LogLevel.Critical;
            Logger.Trace();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Debug" /> class
        /// </summary>
        /// <param name="showPhysicBorders">The show physic borders</param>
        /// <param name="logLevel">The log level</param>
        [JsonConstructor]
        public Debug(bool showPhysicBorders, LogLevel logLevel)
        {
            ShowPhysicBorders = showPhysicBorders;
            LogLevel = logLevel;
            Logger.Trace(showPhysicBorders, logLevel);
        }

        /// <summary>
        ///     Gets or sets the value of the show physic borders
        /// </summary>
        [JsonPropertyName("_ShowPhysicBorders")]
        public bool ShowPhysicBorders
        {
            get
            {
                Logger.Trace($"Debug.ShowPhysicBorders '{showPhysicBorders}'");
                return showPhysicBorders;
            }
            set
            {
                Logger.Trace($"Debug.ShowPhysicBorders from '{showPhysicBorders}' to '{value}'");
                showPhysicBorders = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the log level
        /// </summary>
        [JsonPropertyName("_LogLevel")]
        public LogLevel LogLevel
        {
            get
            {
                Logger.Trace($"Debug.LogLevel '{logLevel}'");
                return logLevel;
            }
            set
            {
                Logger.Trace($"Debug.LogLevel from '{logLevel}' to '{value}'");
                logLevel = value;
            }
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            ShowPhysicBorders = false;
            LogLevel = LogLevel.Critical;
            Logger.Trace();
        }
    }
}