// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TriangulationContext.cs
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

using System.Collections.Generic;
using Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay
{
    /// <summary>
    ///     The triangulation context class
    /// </summary>
    internal abstract class TriangulationContext
    {
        /// <summary>
        ///     The triangulation point
        /// </summary>
        public readonly List<TriangulationPoint> Points = new List<TriangulationPoint>(200);

        /// <summary>
        ///     The delaunay triangle
        /// </summary>
        public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="TriangulationContext" /> class
        /// </summary>
        protected TriangulationContext() => Terminated = false;

        /// <summary>
        ///     Gets or sets the value of the triangulation mode
        /// </summary>
        public TriangulationMode TriangulationMode { get; protected set; }

        /// <summary>
        ///     Gets or sets the value of the triangulatable
        /// </summary>
        public ITriangulatable Triangulatable { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the terminated
        /// </summary>
        public bool Terminated { get; set; }

        /// <summary>
        ///     Gets or sets the value of the step count
        /// </summary>
        public int StepCount { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the is debug enabled
        /// </summary>
        public bool IsDebugEnabled { get; protected set; }

        /// <summary>
        ///     Dones this instance
        /// </summary>
        public void Done()
        {
            StepCount++;
        }

        /// <summary>
        ///     Prepares the triangulation using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public virtual void PrepareTriangulation(ITriangulatable t)
        {
            Triangulatable = t;
            TriangulationMode = t.TriangulationMode;
            t.PrepareTriangulation(this);
        }

        /// <summary>
        ///     News the constraint using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The triangulation constraint</returns>
        public abstract TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b);

        /// <summary>
        ///     Updates the message
        /// </summary>
        /// <param name="message">The message</param>
        public void Update(string message)
        {
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public virtual void Clear()
        {
            Points.Clear();
            Terminated = false;
            StepCount = 0;
        }
    }
}