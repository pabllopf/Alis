// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TriangulationUtil.cs
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

namespace Alis.Core.Systems.Physics2D.Tools.Triangulation.Delaunay
{
    /**
     * @author Thomas Åhlén, thahlen@gmail.com
     */
    internal class TriangulationUtil
    {
        /// <summary>
        ///     The epsilon
        /// </summary>
        public static double Epsilon = 1e-12;

        /// <summary>
        ///     Requirements:
        ///     1. a,b and c form a triangle.
        ///     2. a and d is know to be on opposite side of bc
        ///     <code>
        ///                a
        ///                +
        ///               / \
        ///              /   \
        ///            b/     \c
        ///            +-------+ 
        ///           /    B    \  
        ///          /           \ 
        /// </code>
        ///     Facts:
        ///     d has to be in area B to have a chance to be inside the circle formed by a,b and c
        ///     d is outside B if orient2d(a,b,d) or orient2d(c,a,d) is CW
        ///     This preknowledge gives us a way to optimize the incircle test
        /// </summary>
        /// <param name="pa">triangle point, opposite d</param>
        /// <param name="pb">triangle point</param>
        /// <param name="pc">triangle point</param>
        /// <param name="pd">point opposite a</param>
        /// <returns>true if d is inside circle, false if on circle edge</returns>
        public static bool SmartIncircle(TriangulationPoint pa, TriangulationPoint pb, TriangulationPoint pc,
            TriangulationPoint pd)
        {
            double pdx = pd.X;
            double pdy = pd.Y;
            double adx = pa.X - pdx;
            double ady = pa.Y - pdy;
            double bdx = pb.X - pdx;
            double bdy = pb.Y - pdy;

            double adxbdy = adx * bdy;
            double bdxady = bdx * ady;
            double oabd = adxbdy - bdxady;

            //        oabd = orient2d(pa,pb,pd);
            if (oabd <= 0)
            {
                return false;
            }

            double cdx = pc.X - pdx;
            double cdy = pc.Y - pdy;

            double cdxady = cdx * ady;
            double adxcdy = adx * cdy;
            double ocad = cdxady - adxcdy;

            //      ocad = orient2d(pc,pa,pd);
            if (ocad <= 0)
            {
                return false;
            }

            double bdxcdy = bdx * cdy;
            double cdxbdy = cdx * bdy;

            double alift = adx * adx + ady * ady;
            double blift = bdx * bdx + bdy * bdy;
            double clift = cdx * cdx + cdy * cdy;

            double det = alift * (bdxcdy - cdxbdy) + blift * ocad + clift * oabd;

            return det > 0;
        }
        /*
        public static bool InScanArea(TriangulationPoint pa, TriangulationPoint pb, TriangulationPoint pc,
                                      TriangulationPoint pd)
        {
            double pdx = pd.X;
            double pdy = pd.Y;
            double adx = pa.X - pdx;
            double ady = pa.Y - pdy;
            double bdx = pb.X - pdx;
            double bdy = pb.Y - pdy;

            double adxbdy = adx*bdy;
            double bdxady = bdx*ady;
            double oabd = adxbdy - bdxady;
            //        oabd = orient2d(pa,pb,pd);
            if (oabd <= 0)
            {
                return false;
            }

            double cdx = pc.X - pdx;
            double cdy = pc.Y - pdy;

            double cdxady = cdx*ady;
            double adxcdy = adx*cdy;
            double ocad = cdxady - adxcdy;
            //      ocad = orient2d(pc,pa,pd);
            if (ocad <= 0)
            {
                return false;
            }
            return true;
        }
        */

        /// <summary>
        ///     Describes whether in scan area
        /// </summary>
        /// <param name="pa">The pa</param>
        /// <param name="pb">The pb</param>
        /// <param name="pc">The pc</param>
        /// <param name="pd">The pd</param>
        /// <returns>The bool</returns>
        public static bool InScanArea(TriangulationPoint pa, TriangulationPoint pb, TriangulationPoint pc,
            TriangulationPoint pd)
        {
            double oadb = (pa.X - pb.X) * (pd.Y - pb.Y) - (pd.X - pb.X) * (pa.Y - pb.Y);
            if (oadb >= -Epsilon)
            {
                return false;
            }

            double oadc = (pa.X - pc.X) * (pd.Y - pc.Y) - (pd.X - pc.X) * (pa.Y - pc.Y);
            if (oadc <= Epsilon)
            {
                return false;
            }

            return true;
        }

        /// Forumla to calculate signed area
        /// Positive if CCW
        /// Negative if CW
        /// 0 if collinear
        /// A[P1,P2,P3]  =  (x1*y2 - y1*x2) + (x2*y3 - y2*x3) + (x3*y1 - y3*x1)
        /// =  (x1-x3)*(y2-y3) - (y1-y3)*(x2-x3)
        public static Orientation Orient2d(TriangulationPoint pa, TriangulationPoint pb, TriangulationPoint pc)
        {
            double detleft = (pa.X - pc.X) * (pb.Y - pc.Y);
            double detright = (pa.Y - pc.Y) * (pb.X - pc.X);
            double val = detleft - detright;
            if (val > -Epsilon && val < Epsilon)
            {
                return Orientation.Collinear;
            }

            if (val > 0)
            {
                return Orientation.Ccw;
            }

            return Orientation.Cw;
        }
    }
}