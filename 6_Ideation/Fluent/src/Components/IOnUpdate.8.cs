// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnUpdate.8.cs
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

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook invoked each frame during the update loop, providing the owning entity and
    ///     8 additional component references of types <typeparamref name="TArg1"/>, <typeparamref name="TArg2"/>, <typeparamref name="TArg3"/>, <typeparamref name="TArg4"/>, <typeparamref name="TArg5"/>, <typeparamref name="TArg6"/>, <typeparamref name="TArg7"/>, <typeparamref name="TArg8"/>.
    /// </summary>
    /// <typeparam name="TArg1">The type of the 1st additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg2">The type of the 2nd additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg3">The type of the 3rd additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg4">The type of the 4th additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg5">The type of the 5th additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg6">The type of the 6th additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg7">The type of the 7th additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg8">The type of the 8th additional component or data argument passed to the update method.</typeparam>

    /// <seealso cref="IComponentBase" />
    /// <seealso cref="IComponentBase" />
    public partial interface IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : IComponentBase
    {
        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="arg7">The arg</param>
        /// <param name="arg8">The arg</param>
        void Update(IGameObject self, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3, ref TArg4 arg4, ref TArg5 arg5,
            ref TArg6 arg6, ref TArg7 arg7, ref TArg8 arg8);
    }
}