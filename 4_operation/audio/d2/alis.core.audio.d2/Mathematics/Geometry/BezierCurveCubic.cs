// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BezierCurveCubic.cs
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
using Alis.Core.Audio.D2.Mathematics.Vector;

namespace Alis.Core.Audio.D2.Mathematics.Geometry
{
    /// <summary>
    ///     Represents a cubic bezier curve with two anchor and two control points.
    /// </summary>
    [Serializable]
    public struct BezierCurveCubic
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
        ///     First control point, controls the direction of the curve start.
        /// </summary>
        public Vector2 FirstControlPoint;

        /// <summary>
        ///     Second control point, controls the direction of the curve end.
        /// </summary>
        public Vector2 SecondControlPoint;

        /// <summary>
        ///     Gets or sets the parallel value.
        /// </summary>
        /// <remarks>
        ///     This value defines whether the curve should be calculated as a
        ///     parallel curve to the original bezier curve. A value of 0.0f represents
        ///     the original curve, 5.0f i.e. stands for a curve that has always a distance
        ///     of 5.f to the orignal curve at any point.
        /// </remarks>
        public float Parallel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BezierCurveCubic" /> struct.
        /// </summary>
        /// <param name="startAnchor">The start anchor point.</param>
        /// <param name="endAnchor">The end anchor point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        public BezierCurveCubic
        (
            Vector2 startAnchor,
            Vector2 endAnchor,
            Vector2 firstControlPoint,
            Vector2 secondControlPoint
        )
        {
            StartAnchor = startAnchor;
            EndAnchor = endAnchor;
            FirstControlPoint = firstControlPoint;
            SecondControlPoint = secondControlPoint;
            Parallel = 0.0f;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BezierCurveCubic" /> struct.
        /// </summary>
        /// <param name="parallel">The parallel value.</param>
        /// <param name="startAnchor">The start anchor point.</param>
        /// <param name="endAnchor">The end anchor point.</param>
        /// <param name="firstControlPoint">The first control point.</param>
        /// <param name="secondControlPoint">The second control point.</param>
        public BezierCurveCubic
        (
            float parallel,
            Vector2 startAnchor,
            Vector2 endAnchor,
            Vector2 firstControlPoint,
            Vector2 secondControlPoint
        )
        {
            Parallel = parallel;
            StartAnchor = startAnchor;
            EndAnchor = endAnchor;
            FirstControlPoint = firstControlPoint;
            SecondControlPoint = secondControlPoint;
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

            float x = StartAnchor.X * c * c * c + FirstControlPoint.X * 3 * t * c * c +
                      SecondControlPoint.X * 3 * t * t * c + EndAnchor.X * t * t * t;

            float y = StartAnchor.Y * c * c * c + FirstControlPoint.Y * 3 * t * c * c +
                      SecondControlPoint.Y * 3 * t * t * c + EndAnchor.Y * t * t * t;

            Vector2 r = new Vector2(x, y);

            if (Parallel == 0.0f)
            {
                return r;
            }

            Vector2 perpendicular;

            if (t == 0.0f)
            {
                perpendicular = FirstControlPoint - StartAnchor;
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
            float c = 1.0f - t;
            Vector2 r = new Vector2
            (
                c * c * StartAnchor.X + 2 * t * c * FirstControlPoint.X + t * t * SecondControlPoint.X,
                c * c * StartAnchor.Y + 2 * t * c * FirstControlPoint.Y + t * t * SecondControlPoint.Y
            );

            return r;
        }

        /// <summary>
        ///     Calculates the length of this bezier curve.
        /// </summary>
        /// <param name="precision">The precision.</param>
        /// <returns>Length of the curve.</returns>
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