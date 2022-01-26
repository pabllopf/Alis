// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BezierCurveQuadric.cs
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
using System.Diagnostics.Contracts;
using Alis.Core.Audio.Mathematics.Vector;

namespace Alis.Core.Audio.Mathematics.Geometry
{
    /// <summary>
    ///     Represents a quadric bezier curve with two anchor and one control point.
    /// </summary>
    [Serializable]
    public struct BezierCurveQuadric
    {
        /// <summary>
        ///     Start anchor point.
        /// </summary>
        public Vector2 StartAnchor;

        /// <summary>
        ///     End anchor point.
        /// </summary>
        public Vector2 EndAnchor;

        /// <summary>
        ///     Control point, controls the direction of both endings of the curve.
        /// </summary>
        public Vector2 ControlPoint;

        /// <summary>
        ///     The parallel value.
        /// </summary>
        /// <remarks>
        ///     This value defines whether the curve should be calculated as a
        ///     parallel curve to the original bezier curve. A value of 0.0f represents
        ///     the original curve, 5.0f i.e. stands for a curve that has always a distance
        ///     of 5.f to the orignal curve at any point.
        /// </remarks>
        public float Parallel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BezierCurveQuadric" /> struct.
        /// </summary>
        /// <param name="startAnchor">The start anchor.</param>
        /// <param name="endAnchor">The end anchor.</param>
        /// <param name="controlPoint">The control point.</param>
        public BezierCurveQuadric(Vector2 startAnchor, Vector2 endAnchor, Vector2 controlPoint)
        {
            StartAnchor = startAnchor;
            EndAnchor = endAnchor;
            ControlPoint = controlPoint;
            Parallel = 0.0f;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BezierCurveQuadric" /> struct.
        /// </summary>
        /// <param name="parallel">The parallel value.</param>
        /// <param name="startAnchor">The start anchor.</param>
        /// <param name="endAnchor">The end anchor.</param>
        /// <param name="controlPoint">The control point.</param>
        public BezierCurveQuadric(float parallel, Vector2 startAnchor, Vector2 endAnchor, Vector2 controlPoint)
        {
            Parallel = parallel;
            StartAnchor = startAnchor;
            EndAnchor = endAnchor;
            ControlPoint = controlPoint;
        }

        /// <summary>
        ///     Calculates the point with the specified t.
        /// </summary>
        /// <param name="t">The t value, between 0.0f and 1.0f.</param>
        /// <returns>Resulting point.</returns>
        [Pure]
        public Vector2 CalculatePoint(float t)
        {
            float c = 1.0f - t;
            Vector2 r = new Vector2
            (
                c * c * StartAnchor.X + 2 * t * c * ControlPoint.X + t * t * EndAnchor.X,
                c * c * StartAnchor.Y + 2 * t * c * ControlPoint.Y + t * t * EndAnchor.Y
            );

            if (Parallel == 0.0f)
            {
                return r;
            }

            Vector2 perpendicular;

            if (t == 0.0f)
            {
                perpendicular = ControlPoint - StartAnchor;
            }
            else
            {
                perpendicular = r - CalculatePointOfDerivative(t);
            }

            return r + Vector2.Normalize(perpendicular).PerpendicularRight * Parallel;
        }

        /// <summary>
        ///     Calculates the point with the specified t of the derivative of this function.
        /// </summary>
        /// <param name="t">The t, value between 0.0f and 1.0f.</param>
        /// <returns>Resulting point.</returns>
        [Pure]
        private Vector2 CalculatePointOfDerivative(float t)
        {
            Vector2 r = new Vector2
            {
                X = (1.0f - t) * StartAnchor.X + t * ControlPoint.X,
                Y = (1.0f - t) * StartAnchor.Y + t * ControlPoint.Y
            };

            return r;
        }

        /// <summary>
        ///     Calculates the length of this bezier curve.
        /// </summary>
        /// <param name="precision">The precision.</param>
        /// <returns>Length of curve.</returns>
        /// <remarks>
        ///     The precision gets better when the <paramref name="precision" />
        ///     value gets smaller.
        /// </remarks>
        [Pure]
        public float CalculateLength(float precision)
        {
            float length = 0.0f;
            Vector2 old = CalculatePoint(0.0f);

            for (float i = precision; i < 1.0f + precision; i += precision)
            {
                Vector2 n = CalculatePoint(i);
                length += (n - old).Length;
                old = n;
            }

            return length;
        }
    }
}