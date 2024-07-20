// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MockPlugin2.cs
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

namespace Alis.Extension.Plugin.Test.Mocks
{
    /// <summary>
    /// The mock plugin class
    /// </summary>
    /// <seealso cref="IPlugin"/>
    public class MockPlugin2 : IPlugin
    {
        /// <summary>
        /// Gets or sets the value of the initialize calls
        /// </summary>
        public int InitializeCalls { get;  set; } = 0;
        /// <summary>
        /// Gets or sets the value of the update calls
        /// </summary>
        public int UpdateCalls { get;  set; } = 0;
        /// <summary>
        /// Gets or sets the value of the render calls
        /// </summary>
        public int RenderCalls { get;  set; } = 0;
        /// <summary>
        /// Gets or sets the value of the shutdown calls
        /// </summary>
        public int ShutdownCalls { get;  set; } = 0;

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize() => InitializeCalls++;
        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update() => UpdateCalls++;
        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render() => RenderCalls++;
        /// <summary>
        /// Shutdowns this instance
        /// </summary>
        public void Shutdown() => ShutdownCalls++;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
        }
    }
}