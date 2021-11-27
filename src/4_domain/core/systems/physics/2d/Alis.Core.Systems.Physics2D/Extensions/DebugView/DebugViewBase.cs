// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DebugViewBase.cs
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

using System.Drawing;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Shared;

namespace Alis.Core.Systems.Physics2D.Extensions.DebugView
{
    /// <summary>Implement and register this class with a World to provide debug drawing of physics entities in your game.</summary>
    public abstract class DebugViewBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugViewBase" /> class
        /// </summary>
        /// <param name="world">The world</param>
        protected DebugViewBase(World world) => World = world;

        /// <summary>
        ///     Gets the value of the world
        /// </summary>
        protected World World { get; }

        /// <summary>Gets or sets the debug view flags.</summary>
        /// <value>The flags.</value>
        public DebugViewFlags Flags { get; set; }

        /// <summary>Append flags to the current flags.</summary>
        /// <param name="flags">The flags.</param>
        public void AppendFlags(DebugViewFlags flags)
        {
            Flags |= flags;
        }

        /// <summary>Remove flags from the current flags.</summary>
        /// <param name="flags">The flags.</param>
        public void RemoveFlags(DebugViewFlags flags)
        {
            Flags &= ~flags;
        }

        /// <summary>Draw a closed polygon provided in CCW order.</summary>
        public abstract void DrawPolygon(Vector2[] vertices, int count, Color color, bool closed = true);

        /// <summary>Draw a solid closed polygon provided in CCW order.</summary>
        public abstract void DrawSolidPolygon(Vector2[] vertices, int count, Color color, bool outline = true);

        /// <summary>Draw a circle.</summary>
        public abstract void DrawCircle(Vector2 center, float radius, Color color);

        /// <summary>Draw a solid circle.</summary>
        public abstract void DrawSolidCircle(Vector2 center, float radius, Vector2 axis, Color color);

        /// <summary>Draw a line segment.</summary>
        public abstract void DrawSegment(Vector2 start, Vector2 end, Color color);

        /// <summary>Draw a transform. Choose your own length scale.</summary>
        /// <param name="transform">The transform.</param>
        public abstract void DrawTransform(ref Transform transform);
    }
}