// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationUtil.cs
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

namespace Alis.Extension.Math.PathGenerator.Triangulation.Delaunay
{
    /// <summary>
    ///     The triangulation util class
    /// </summary>
    internal static class TriangulationUtil
    {
        /// <summary>
        ///     The epsilon
        /// </summary>
        public static readonly double Epsilon = 1e-12;
        
        
        /// <summary>
        ///     Describes whether smart in circle
        /// </summary>
        /// <param name="pa">The pa</param>
        /// <param name="pb">The pb</param>
        /// <param name="pc">The pc</param>
        /// <param name="pd">The pd</param>
        /// <returns>The bool</returns>
        public static bool SmartInCircle(TriangulationPoint pa, TriangulationPoint pb, TriangulationPoint pc,
            TriangulationPoint pd)
        {
            double pdx = pd.X;
            double pdy = pd.Y;
            double adx = pa.X - pdx;
            double ady = pa.Y - pdy;
            double bdx = pb.X - pdx;
            double bdy = pb.Y - pdy;
            
            double aBdy = adx * bdy;
            double bAdy = bdx * ady;
            double oAbd = aBdy - bAdy;
            
            if (oAbd <= 0)
            {
                return false;
            }
            
            double cdx = pc.X - pdx;
            double cdy = pc.Y - pdy;
            
            double cAdy = cdx * ady;
            double aCdy = adx * cdy;
            double oCad = cAdy - aCdy;
            
            if (oCad <= 0)
            {
                return false;
            }
            
            double xCdy = bdx * cdy;
            double cCdy = cdx * bdy;
            
            double aLift = adx * adx + ady * ady;
            double bLift = bdx * bdx + bdy * bdy;
            double cLift = cdx * cdx + cdy * cdy;
            
            double det = aLift * (xCdy - cCdy) + bLift * oCad + cLift * oAbd;
            
            return det > 0;
        }
        
        
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
            double adb = (pa.X - pb.X) * (pd.Y - pb.Y) - (pd.X - pb.X) * (pa.Y - pb.Y);
            if (adb >= -Epsilon)
            {
                return false;
            }
            
            double adc = (pa.X - pc.X) * (pd.Y - pc.Y) - (pd.X - pc.X) * (pa.Y - pc.Y);
            return !(adc <= Epsilon);
        }
        
        
        /// <summary>
        ///     Orients the 2d using the specified pa
        /// </summary>
        /// <param name="pa">The pa</param>
        /// <param name="pb">The pb</param>
        /// <param name="pc">The pc</param>
        /// <returns>The orientation</returns>
        public static Orientation Orient2d(TriangulationPoint pa, TriangulationPoint pb, TriangulationPoint pc)
        {
            double detLeft = (pa.X - pc.X) * (pb.Y - pc.Y);
            double detRight = (pa.Y - pc.Y) * (pb.X - pc.X);
            double val = detLeft - detRight;
            if ((val > -Epsilon) && (val < Epsilon))
            {
                return Orientation.Collinear;
            }
            
            return val > 0 ? Orientation.Ccw : Orientation.Cw;
        }
    }
}