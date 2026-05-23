// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepConstraint.cs
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

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep constraint class
    /// </summary>
    /// <seealso cref="TriangulationConstraint" />
    internal class DtSweepConstraint : TriangulationConstraint
    {
        /// <summary>
        ///     Give two points in any order. Will always be ordered so
        ///     that q.y > p.y and q.x > p.x if same y value
        /// </summary>
        public DtSweepConstraint(TriangulationPoint p1, TriangulationPoint p2)
        {
            P = p1;
            Q = p2;
            if (p1.Y > p2.Y)
            {
                Q = p1;
                P = p2;
            }
            else if (Math.Abs(p1.Y - p2.Y) < float.Epsilon)
            {
                if (p1.X > p2.X)
                {
                    Q = p1;
                    P = p2;
                }
            }

            Q.AddEdge(this);
        }
    }
}