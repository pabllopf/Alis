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
using Alis.Core.Aspect.Math;
using Alis.Core.Component.Collider;

namespace Alis.Builder.Core.Component.Collider
{
    /// <summary>
    ///     The box collider builder class
    /// </summary>
    public class BoxColliderBuilder: 
        IBuild<BoxCollider>,
        IIsActive<BoxColliderBuilder, bool>,
        IIsDynamic<BoxColliderBuilder, bool>,
        ISize<BoxColliderBuilder, float, float>,
        IMass<BoxColliderBuilder, float>,
        IAutoTilling<BoxColliderBuilder, bool>,
        IFixedRotation<BoxColliderBuilder, bool>,
        IGravityScale<BoxColliderBuilder, float>,
        IFriction<BoxColliderBuilder, float>,
        IDensity<BoxColliderBuilder, float>,
        IRotation<BoxColliderBuilder, float>,
        IRelativePosition<BoxColliderBuilder, float, float>,
        IRestitution<BoxColliderBuilder, float>,
        IIsTrigger<BoxColliderBuilder, bool>
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
        /// Fixeds the rotation using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder FixedRotation(bool value)
        {
            boxCollider.FixedRotation = value;
            return this;
        }

        /// <summary>
        /// Autoes the tilling using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder AutoTilling(bool value)
        {
            boxCollider.AutoTilling = value;
            return this;
        }

        /// <summary>
        /// Gravities the scale using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder GravityScale(float value)
        {
            boxCollider.GravityScale = value;
            return this;
        }

        /// <summary>
        /// Masses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Mass(float value)
        {
            boxCollider.Mass = value;
            return this;
        }

        /// <summary>
        /// Frictions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Friction(float value)
        {
            boxCollider.Friction = value;
            return this;
        }

        /// <summary>
        /// Densities the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Density(float value)
        {
            boxCollider.Density = value;
            return this;
        }

        /// <summary>
        /// Rotations the angle
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Rotation(float angle)
        {
            boxCollider.Rotation = angle;
            return this;
        }

        /// <summary>
        /// Relatives the position using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder RelativePosition(float x, float y)
        {
            boxCollider.RelativePosition = new Vector2(x, y);
            return this;
        }

        /// <summary>
        /// Restitutions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Restitution(float value)
        {
            boxCollider.Restitution = value;
            return this;
        }

        /// <summary>
        /// Ises the trigger
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsTrigger()
        {
            boxCollider.IsTrigger = true;
            return this;
        }

        /// <summary>
        /// Ises the trigger using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsTrigger(bool value)
        {
            boxCollider.IsTrigger = value;
            return this;
        }

        /// <summary>
        /// Ises the active using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsActive(bool value)
        {
            boxCollider.IsActive = value;
            return this;
        }
    }
}