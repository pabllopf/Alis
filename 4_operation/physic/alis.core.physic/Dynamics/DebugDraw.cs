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

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Dynamics
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
        protected DrawFlags DrawFlags;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugDraw" /> class
        /// </summary>
        public DebugDraw()
        {
            DrawFlags = 0;
        }

        /// <summary>
        ///     Gets or sets the value of the flags
        /// </summary>
        public DrawFlags Flags
        {
            get => DrawFlags;
            set => DrawFlags = value;
        }

        /// <summary>
        ///     Append flags to the current flags.
        /// </summary>
        public void AppendFlags(DrawFlags flags)
        {
            DrawFlags |= flags;
        }

        /// <summary>
        ///     Clear flags from the current flags.
        /// </summary>
        public void ClearFlags(DrawFlags flags)
        {
            DrawFlags &= ~flags;
        }

        /// <summary>
        ///     Draw a closed polygon provided in CCW order.
        /// </summary>
        public abstract void DrawPolygon(Vector2[] vertices, int vertexCount, Color color);

        /// <summary>
        ///     Draw a solid closed polygon provided in CCW order.
        /// </summary>
        public abstract void DrawSolidPolygon(Vector2[] vertices, int vertexCount, Color color);

        /// <summary>
        ///     Draw a circle.
        /// </summary>
        public abstract void DrawCircle(Vector2 center, float radius, Color color);

        /// <summary>
        ///     Draw a solid circle.
        /// </summary>
        public abstract void DrawSolidCircle(Vector2 center, float radius, Vector2 axis, Color color);

        /// <summary>
        ///     Draw a line segment.
        /// </summary>
        public abstract void DrawSegment(Vector2 p1, Vector2 p2, Color color);

        /// <summary>
        ///     Draw a transform. Choose your own length scale.
        /// </summary>
        /// <param name="xf">A transform.</param>
        public abstract void DrawXForm(XForm xf);
    }
}