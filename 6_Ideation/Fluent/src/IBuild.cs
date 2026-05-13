// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IBuild.cs
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

namespace Alis.Core.Aspect.Fluent
{
    /// <summary>
    ///     Defines a builder terminal operation that constructs and returns the final object of type
    ///     <typeparamref name="TOrigin"/>.
    /// </summary>
    /// <typeparam name="TOrigin">The type of the object produced by the build operation.</typeparam>
    public interface IBuild<TOrigin>
    {
        /// <summary>
        ///     Constructs and returns the final <typeparamref name="TOrigin"/> instance.
        /// </summary>
        /// <returns>The fully constructed <typeparamref name="TOrigin"/> instance.</returns>
        TOrigin Build();
    }
}