// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderBuilder.cs
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

using System.Collections.ObjectModel;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Component.Collider;

namespace Alis.Builder.Core.Component.Collider
{
    /// <summary>
    ///     The box collider builder class
    /// </summary>
    public class BoxColliderBuilder: 
        IBuild<BoxCollider>,
        IIsDynamic<BoxColliderBuilder, bool>,
        ISize<BoxColliderBuilder, float, float>
    {
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider boxCollider = new BoxCollider();
        /// <summary>
        /// Builds this instance
        /// </summary>
        /// <returns>The box collider</returns>
        public BoxCollider Build() => boxCollider;

        /// <summary>
        /// Ises the dynamic
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsDynamic()
        {
            boxCollider.IsDynamic = true;
            return this;
        }

        /// <summary>
        /// Ises the dynamic using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsDynamic(bool value)
        {
            boxCollider.IsDynamic = value;
            return this;
        }

        /// <summary>
        /// Sizes the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Size(float x, float y)
        {
            boxCollider.Width = x;
            boxCollider.Height = y;
            return this;
        }

        /// <summary>
        /// Autoes the till using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder AutoTill(bool value)
        {
            boxCollider.AutoTilling = value;
            return this;
        }
    }
}