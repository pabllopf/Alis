// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AHasHasBuilder.cs
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

namespace Alis.Core.Ecs.System
{
    /// <summary>
    ///     The has builder class
    /// </summary>
    /// <seealso cref="IHasBuilder{TOut}" />
    public abstract class AHasHasBuilder<T> : IHasBuilder<T> where T : new()
    {
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The</returns>
        public T Builder() => new T();
        
        /// <summary>
        ///     Creates
        /// </summary>
        /// <returns>The</returns>
        public static T Create() => new T();
    }
}