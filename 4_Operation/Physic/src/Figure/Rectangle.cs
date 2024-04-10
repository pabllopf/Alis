// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Rectangle.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Tools;

namespace Alis.Core.Physic.Figure
{
    /// <summary>
    ///     The rectangle class
    /// </summary>
    /// <seealso />
    public class Rectangle : Body
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Rectangle" /> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="position">The position</param>
        /// <param name="linearVelocity">The linear velocity</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="angle">The angle</param>
        /// <param name="angularVelocity">The angular velocity</param>
        /// <param name="linearDamping">The linear damping</param>
        /// <param name="angularDamping">The angular damping</param>
        /// <param name="allowSleep">The allow sleep</param>
        /// <param name="awake">The awake</param>
        /// <param name="fixedRotation">The fixed rotation</param>
        /// <param name="isBullet">The is bullet</param>
        /// <param name="enabled">The enabled</param>
        /// <param name="gravityScale">The gravity scale</param>
        public Rectangle(
            float width,
            float height,
            Vector2 position,
            Vector2 linearVelocity,
            BodyType bodyType = BodyType.Static,
            float angle = 0,
            float angularVelocity = 0,
            float linearDamping = 0,
            float angularDamping = 0,
            bool allowSleep = true,
            bool awake = true,
            bool fixedRotation = false,
            bool isBullet = false,
            bool enabled = true,
            float gravityScale = 1) : base(position, linearVelocity, bodyType, angle, angularVelocity, linearDamping, angularDamping, allowSleep, awake, fixedRotation, isBullet, enabled, gravityScale)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), @"Width must be more than 0");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), @"Height must be more than 0");
            }

            Vertices rectangleVertices = Polygon.CreateRectangle(width / 2, height / 2);

            if (rectangleVertices.Count <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rectangleVertices), "Too few points to be a polygon");
            }

            AddFixture(new PolygonShape(rectangleVertices, 1));
        }
    }
}