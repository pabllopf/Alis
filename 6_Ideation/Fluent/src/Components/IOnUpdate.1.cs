// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnUpdate.1.cs
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
    ///     1 additional component reference of type <typeparamref name="TArg"/>.
    /// </summary>
    /// <typeparam name="TArg">The type of the additional component or data argument passed to the update method.</typeparam>
    /// <remarks>Components should only implement one "Update" method.</remarks>
    public partial interface IOnUpdate<TArg> : IComponentBase
    {
        /// <summary>
        ///     Invokes the update logic with the owning entity and the additional component reference.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        /// <param name="arg">The additional component reference of type <typeparamref name="TArg"/>.</param>
        void Update(IGameObject self, ref TArg arg);
    }
}
