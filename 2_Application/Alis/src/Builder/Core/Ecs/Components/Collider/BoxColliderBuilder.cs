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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Physic.Dynamics;

namespace Alis.Builder.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider builder class
    /// </summary>
    public class BoxColliderBuilder :
        IBuild<BoxCollider>,
        IIsActive<BoxColliderBuilder, bool>,
        IBodyType<BoxColliderBuilder, BodyType>,
        ISize<BoxColliderBuilder, float>,
        IMass<BoxColliderBuilder, float>,
        IAutoTilling<BoxColliderBuilder, bool>,
        IFixedRotation<BoxColliderBuilder, bool>,
        IFriction<BoxColliderBuilder, float>,
        IRotation<BoxColliderBuilder, float>,
        IRelativePosition<BoxColliderBuilder, float>,
        IRestitution<BoxColliderBuilder, float>,
        IIsTrigger<BoxColliderBuilder, bool>,
        ILinearVelocity<BoxColliderBuilder, float>,
        IAngularVelocity<BoxColliderBuilder, float>
    {
        /// <summary>
        ///     The box collider
        /// </summary>
        private readonly BoxCollider boxCollider = new BoxCollider();

        /// <summary>
        ///     Angular the velocity using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder AngularVelocity(float value)
        {
            boxCollider.AngularVelocity = value;
            return this;
        }

        /// <summary>
        ///     Auto the tilling using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder AutoTilling(bool value)
        {
            boxCollider.AutoTilling = value;
            return this;
        }

        /// <summary>
        ///     Bodies the type using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder BodyType(BodyType value)
        {
            boxCollider.BodyType = value;
            return this;
        }


        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The box collider</returns>
        public BoxCollider Build() => boxCollider;

        /// <summary>
        ///     Fixed the rotation using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder FixedRotation(bool value)
        {
            boxCollider.FixedRotation = value;
            return this;
        }

        /// <summary>
        ///     Frictions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Friction(float value)
        {
            boxCollider.Friction = value;
            return this;
        }

        /// <summary>
        ///     Is the active using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsActive(bool value)
        {
            return this;
        }

        /// <summary>
        ///     Is the trigger
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsTrigger() => this;

        /// <summary>
        ///     Is the trigger using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IsTrigger(bool value) => this;

        /// <summary>
        ///     Linear the velocity using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder LinearVelocity(float x, float y)
        {
            boxCollider.LinearVelocity = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Masses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Mass(float value)
        {
            boxCollider.Mass = value;
            return this;
        }

        /// <summary>
        ///     Relatives the position using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder RelativePosition(float x, float y)
        {
            boxCollider.RelativePosition = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Restitutions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Restitution(float value)
        {
            boxCollider.Restitution = value;
            return this;
        }

        /// <summary>
        ///     Rotations the angle
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Rotation(float angle)
        {
            boxCollider.Rotation = angle;
            return this;
        }

        /// <summary>
        ///     Sizes the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Size(float x, float y)
        {
            boxCollider.SizeOfTexture = new Vector2F(x, y);
            return this;
        }


        /// <summary>
        ///     Ignores the gravity using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder IgnoreGravity(bool value)
        {
            boxCollider.IgnoreGravity = value;
            return this;
        }
    }
}