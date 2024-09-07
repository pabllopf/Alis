// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Trapezoid.cs
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
    internal class Trapezoid
    {
        public Edge Bottom;
        public bool Inside;
        public Point LeftPoint;

        // Neighbor pointers
        public Trapezoid LowerLeft;
        public Trapezoid LowerRight;

        public Point RightPoint;
        public Sink Sink;

        public Edge Top;
        public Trapezoid UpperLeft;
        public Trapezoid UpperRight;

        public Trapezoid(Point leftPoint, Point rightPoint, Edge top, Edge bottom)
        {
            LeftPoint = leftPoint;
            RightPoint = rightPoint;
            Top = top;
            Bottom = bottom;
            UpperLeft = null;
            UpperRight = null;
            LowerLeft = null;
            LowerRight = null;
            Inside = true;
            Sink = null;
        }

        // Update neighbors to the left
        public void UpdateLeft(Trapezoid ul, Trapezoid ll)
        {
            UpperLeft = ul;
            if (ul != null) ul.UpperRight = this;
            LowerLeft = ll;
            if (ll != null) ll.LowerRight = this;
        }

        // Update neighbors to the right
        public void UpdateRight(Trapezoid ur, Trapezoid lr)
        {
            UpperRight = ur;
            if (ur != null) ur.UpperLeft = this;
            LowerRight = lr;
            if (lr != null) lr.LowerLeft = this;
        }

        // Update neighbors on both sides
        public void UpdateLeftRight(Trapezoid ul, Trapezoid ll, Trapezoid ur, Trapezoid lr)
        {
            UpperLeft = ul;
            if (ul != null) ul.UpperRight = this;
            LowerLeft = ll;
            if (ll != null) ll.LowerRight = this;
            UpperRight = ur;
            if (ur != null) ur.UpperLeft = this;
            LowerRight = lr;
            if (lr != null) lr.LowerLeft = this;
        }

        // Recursively trim outside neighbors
        public void TrimNeighbors()
        {
            if (Inside)
            {
                Inside = false;
                if (UpperLeft != null) UpperLeft.TrimNeighbors();
                if (LowerLeft != null) LowerLeft.TrimNeighbors();
                if (UpperRight != null) UpperRight.TrimNeighbors();
                if (LowerRight != null) LowerRight.TrimNeighbors();
            }
        }

        // Determines if this point lies inside the trapezoid
        public bool Contains(Point point) => (point.X > LeftPoint.X) && (point.X < RightPoint.X) && Top.IsAbove(point) && Bottom.IsBelow(point);

        public List<Point> GetVertices()
        {
            List<Point> verts = new List<Point>(4);
            verts.Add(LineIntersect(Top, LeftPoint.X));
            verts.Add(LineIntersect(Bottom, LeftPoint.X));
            verts.Add(LineIntersect(Bottom, RightPoint.X));
            verts.Add(LineIntersect(Top, RightPoint.X));
            return verts;
        }

        private Point LineIntersect(Edge edge, float x)
        {
            float y = edge.Slope * x + edge.B;
            return new Point(x, y);
        }

        // Add points to monotone mountain
        public void AddPoints()
        {
            if (LeftPoint != Bottom.P)
            {
                Bottom.AddMpoint(LeftPoint);
            }

            if (RightPoint != Bottom.Q)
            {
                Bottom.AddMpoint(RightPoint);
            }

            if (LeftPoint != Top.P)
            {
                Top.AddMpoint(LeftPoint);
            }

            if (RightPoint != Top.Q)
            {
                Top.AddMpoint(RightPoint);
            }
        }
    }
}