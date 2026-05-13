// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnUpdate.3.cs
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
    ///     3 additional component references of types <typeparamref name="TArg1"/>, <typeparamref name="TArg2"/>, <typeparamref name="TArg3"/>.
    /// </summary>
    /// <typeparam name="TArg1">The type of the 1st additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg2">The type of the 2nd additional component or data argument passed to the update method.</typeparam>
    /// <typeparam name="TArg3">The type of the 3rd additional component or data argument passed to the update method.</typeparam>

    /// <seealso cref="IComponentBase" />
    /// <seealso cref="IComponentBase" />
    public partial interface IOnUpdate<TArg1, TArg2, TArg3> : IComponentBase
    {
        /// <summary>
        ///     Invokes the update logic with the owning entity and 3 component references.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        /// <param name="arg1">The 1st additional component reference of type <typeparamref name="TArg1"/>.</param>
        /// <param name="arg2">The 2nd additional component reference of type <typeparamref name="TArg2"/>.</param>
        /// <param name="arg3">The 3rd additional component reference of type <typeparamref name="TArg3"/>.</param>
        void Update(IGameObject self, ref TArg1 arg1, ref TArg2 arg2, ref TArg3 arg3);
    }
}