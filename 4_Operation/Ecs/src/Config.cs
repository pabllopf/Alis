// --------------------------------------------------------------------------
// 
//                               ???? ????? ??? ??????
//                              ????? ????? ??? ??????
//                              ????? ????? ??? ??????
// 
//  --------------------------------------------------------------------------
//  File:Config.cs
// 
//  Author:Pablo Perdomo Falc?n
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

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Config information for a <see cref="World" />.
    /// </summary>
    public class Config
    {
        /// <summary>
        ///     Whether or not to multithread.
        /// </summary>
        public bool MultiThreadedUpdate { get; set; }

        /// <summary>
        ///     The default multithreaded config.
        /// </summary>
        public static Config Multithreaded { get; } = new Config {MultiThreadedUpdate = true};

        /// <summary>
        ///     The default singlethreaded config.
        /// </summary>
        public static Config Singlethreaded { get; } = new Config {MultiThreadedUpdate = false};
    }
}