// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IParallelExecutionStrategy.cs
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

using System;

namespace Alis.Extension.Thread.Interfaces
{
    /// <summary>
    ///     Strategy interface for parallel execution decisions
    /// </summary>
    public interface IParallelExecutionStrategy
    {
        /// <summary>
        ///     Determines if the given type can be executed in parallel
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>True if the component can be executed in parallel</returns>
        bool CanExecuteInParallel(Type componentType);

        /// <summary>
        ///     Gets the minimum batch size for the given type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The minimum batch size</returns>
        int GetMinimumBatchSize(Type componentType);
    }
}