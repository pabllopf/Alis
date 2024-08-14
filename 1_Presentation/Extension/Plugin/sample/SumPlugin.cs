// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SumPlugin.cs
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

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Plugin.Sample
{
    /// <summary>
    ///     The sum plugin class
    /// </summary>
    /// <seealso cref="IPlugin" />
    public class SumPlugin : IPlugin
    {
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            Logger.Info($"result={Sum(1, 2)}");
        }
        
        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            Logger.Trace();
        }
        
        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            Logger.Trace();
        }
        
        /// <summary>
        ///     Shutdowns this instance
        /// </summary>
        public void Shutdown()
        {
            Logger.Trace();
        }
        
        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Logger.Trace();
        }
        
        /// <summary>
        ///     Sums the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public int Sum(int a, int b) => a + b;
    }
}