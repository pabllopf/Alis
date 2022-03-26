// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DebugDraw.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;

namespace Alis.Core.Physics2D.World.Callbacks
{
    /// <summary>
    ///     Implement and register this class with a b2World to provide debug drawing of physics
    ///     entities in your game.
    /// </summary>
    public abstract class DebugDraw
    {
        /// <summary>
        ///     The draw flags
        /// </summary>
        protected DrawFlags _drawFlags;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugDraw" /> class
        /// </summary>
        public DebugDraw() => _drawFlags = 0;

        /// <summary>
        ///     Gets or sets the value of the flags
        /// </summary>
        public DrawFlags Flags
        {
            get => _drawFlags;
            set => _drawFlags = value;
        }

        /// <summary>
        ///     Append flags to the current flags.
        /// </summary>
        public void AppendFlags(DrawFlags flags)
        {
            _drawFlags |= flags;
        }

        /// <summary>
        ///     Clear flags from the current flags.
        /// </summary>
        public void ClearFlags(DrawFlags flags)
        {
            _drawFlags &= ~flags;
        }

        /// <summary>
        ///     Draw a transform. Choose your own length scale.
        /// </summary>
        /// <param name="xf">A transform.</param>
        public abstract void DrawTransform(in Transform xf);

        /// <summary>
        ///     Draws the point using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="size">The size</param>
        /// <param name="color">The color</param>
        public abstract void DrawPoint(in Vector2 position, float size, in Color color);

        /// <summary>
        ///     Draw a closed polygon provided in CCW order.
        /// </summary>
#pragma warning disable 618
        [Obsolete("Look out for new calls using Vector2")]
        public abstract void DrawPolygon(in Vec2[] vertices, int vertexCount, in Color color);

        /// <summary>
        ///     Draw a solid closed polygon provided in CCW order.
        /// </summary>
        [Obsolete("Look out for new calls using Vector2")]
        public abstract void DrawSolidPolygon(in Vec2[] vertices, int vertexCount, in Color color);

        /// <summary>
        ///     Draw a circle.
        /// </summary>
        [Obsolete("Look out for new calls using Vector2")]
        public abstract void DrawCircle(in Vec2 center, float radius, in Color color);

        /// <summary>
        ///     Draw a solid circle.
        /// </summary>
        [Obsolete("Look out for new calls using Vector2")]
        public abstract void DrawSolidCircle(in Vec2 center, float radius, in Vec2 axis, in Color color);

        /// <summary>
        ///     Draw a line segment.
        /// </summary>
        [Obsolete("Look out for new calls using Vector2")]
        public abstract void DrawSegment(in Vec2 p1, in Vec2 p2, in Color color);
#pragma warning restore 618
    }
}