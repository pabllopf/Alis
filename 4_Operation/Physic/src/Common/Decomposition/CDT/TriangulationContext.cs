// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationContext.cs
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

/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

/* Poly2Tri
 * Copyright (c) 2009-2010, Poly2Tri Contributors
 * http://code.google.com/p/poly2tri/
 *
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 *
 * * Redistributions of source code must retain the above copyright notice,
 *   this list of conditions and the following disclaimer.
 * * Redistributions in binary form must reproduce the above copyright notice,
 *   this list of conditions and the following disclaimer in the documentation
 *   and/or other materials provided with the distribution.
 * * Neither the name of Poly2Tri nor the names of its contributors may be
 *   used to endorse or promote products derived from this software without specific
 *   prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
 * A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 * EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 * PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;

namespace Alis.Core.Physic.Common.Decomposition.CDT
{
    /// <summary>
    /// The triangulation context class
    /// </summary>
    internal abstract class TriangulationContext
    {
        /// <summary>
        /// The triangulation point
        /// </summary>
        public readonly List<TriangulationPoint> Points = new List<TriangulationPoint>(200);
        /// <summary>
        /// The delaunay triangle
        /// </summary>
        public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangulationContext"/> class
        /// </summary>
        public TriangulationContext() => Terminated = false;

        /// <summary>
        /// Gets or sets the value of the triangulation mode
        /// </summary>
        public TriangulationMode TriangulationMode { get; protected set; }
        /// <summary>
        /// Gets or sets the value of the triangulatable
        /// </summary>
        public Triangulatable Triangulatable { get; private set; }

        /// <summary>
        /// Gets the value of the wait until notified
        /// </summary>
        public bool WaitUntilNotified { get; }
        /// <summary>
        /// Gets or sets the value of the terminated
        /// </summary>
        public bool Terminated { get; set; }

        /// <summary>
        /// Gets or sets the value of the step count
        /// </summary>
        public int StepCount { get; private set; }

        /// <summary>
        /// Dones this instance
        /// </summary>
        public void Done()
        {
            StepCount++;
        }

        /// <summary>
        /// Prepares the triangulation using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public virtual void PrepareTriangulation(Triangulatable t)
        {
            Triangulatable = t;
            TriangulationMode = t.TriangulationMode;
            t.PrepareTriangulation(this);
        }

        /// <summary>
        /// News the constraint using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The triangulation constraint</returns>
        public abstract TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b);

        /// <summary>
        /// Clears this instance
        /// </summary>
        public virtual void Clear()
        {
            Points.Clear();
            Terminated = false;
            StepCount = 0;
        }
    }
}