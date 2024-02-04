// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PluginSample.cs
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

namespace Alis.Core.Plugin.Test
{
    /// <summary>
    /// The plugin sample class
    /// </summary>
    /// <seealso cref="IPlugin"/>
    public class PluginSample : IPlugin
    {
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            
        }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Renders this instance
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Render()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Shutdowns this instance
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Shutdown()
        {
            throw new System.NotImplementedException();
        }
    }
}