// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Edge.cs
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

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    internal class Edge
    {
        // Pointers used for building trapezoidal map
        public Trapezoid Above;
        public float B;
        public Trapezoid Below;

        // Montone mountain points
        public HashSet<Point> MPoints;
        public Point P;
        public Point Q;

        // Slope of the line (m)
        public float Slope;


        public Edge(Point p, Point q)
        {
            P = p;
            Q = q;

            if (q.X - p.X != 0)
                Slope = (q.Y - p.Y) / (q.X - p.X);
            else
                Slope = 0;

            B = p.Y - p.X * Slope;
            Above = null;
            Below = null;
            MPoints = new HashSet<Point>();
            MPoints.Add(p);
            MPoints.Add(q);
        }

        public bool IsAbove(Point point) => P.Orient2D(Q, point) < 0;

        public bool IsBelow(Point point) => P.Orient2D(Q, point) > 0;

        public void AddMpoint(Point point)
        {
            foreach (Point mp in MPoints)
            {
                if (!mp.Neq(point))
                    return;
            }

            MPoints.Add(point);
        }
    }
}