// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Polygon.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Figure
{
    /// <summary>
    ///     The polygon class
    /// </summary>
    public static class Polygon
    {
        /// <summary>
        ///     Creates the rectangle using the specified hx
        /// </summary>
        /// <param name="hx">The hx</param>
        /// <param name="hy">The hy</param>
        /// <returns>The vertices</returns>
        public static Vertices CreateRectangle(float hx, float hy) =>
            new Vertices(4)
            {
                new Vector2(-hx, -hy),
                new Vector2(hx, -hy),
                new Vector2(hx, hy),
                new Vector2(-hx, hy)
            };
        
        
        /// <summary>
        ///     Creates the rectangle using the specified hx
        /// </summary>
        /// <param name="hx">The hx</param>
        /// <param name="hy">The hy</param>
        /// <param name="center">The center</param>
        /// <param name="angle">The angle</param>
        /// <returns>The vertices</returns>
        public static Vertices CreateRectangle(float hx, float hy, Vector2 center, float angle)
        {
            Vertices vertices = CreateRectangle(hx, hy);
            TransformVertices(vertices, center, angle);
            return vertices;
        }
        
        /// <summary>
        /// Transforms the vertices using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="center">The center</param>
        /// <param name="angle">The angle</param>
        internal static void TransformVertices(Vertices vertices, Vector2 center, float angle)
        {
            Transform xf = new Transform
            {
                Position = center
            };
            xf.Rotation.Set(angle);
            
            for (int i = 0; i < vertices.Count; ++i)
            {
                vertices[i] = MathUtils.Mul(ref xf, vertices[i]);
            }
        }
        
        
        /// <summary>
        ///     Creates the rounded rectangle using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="segments">The segments</param>
        /// <exception>Rounding amount can't be more than half the height and width respectively.</exception>
        /// <exception>Segments must be zero or more.</exception>
        /// <returns>The vertices</returns>
        public static Vertices CreateRoundedRectangle(float width, float height, float xRadius, float yRadius, int segments)
        {
            ValidateRoundedRectangleParameters(width, height, xRadius, yRadius, segments);
            
            Vertices vertices = new Vertices();
            if (segments == 0)
            {
                CreateRectangleWithoutSegments(vertices, width, height, xRadius, yRadius);
            }
            else
            {
                CreateRectangleWithSegments(vertices, width, height, xRadius, yRadius, segments);
            }
            
            return vertices;
        }
        
        /// <summary>
        /// Validates the rounded rectangle parameters using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="segments">The segments</param>
        /// <exception cref="System.Exception">Rounding amount can't be more than half the height and width respectively.</exception>
        /// <exception cref="System.Exception">Segments must be zero or more.</exception>
        internal static void ValidateRoundedRectangleParameters(float width, float height, float xRadius, float yRadius, int segments)
        {
            if (yRadius > height / 2 || xRadius > width / 2)
            {
                throw new System.Exception("Rounding amount can't be more than half the height and width respectively.");
            }
            
            if (segments < 0)
            {
                throw new System.Exception("Segments must be zero or more.");
            }
        }
        
        /// <summary>
        /// Creates the rectangle without segments using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        internal static void CreateRectangleWithoutSegments(Vertices vertices, float width, float height, float xRadius, float yRadius)
        {
            vertices.Add(new Vector2(width * .5f - xRadius, -height * .5f));
            vertices.Add(new Vector2(width * .5f, -height * .5f + yRadius));
            
            vertices.Add(new Vector2(width * .5f, height * .5f - yRadius));
            vertices.Add(new Vector2(width * .5f - xRadius, height * .5f));
            
            vertices.Add(new Vector2(-width * .5f + xRadius, height * .5f));
            vertices.Add(new Vector2(-width * .5f, height * .5f - yRadius));
            
            vertices.Add(new Vector2(-width * .5f, -height * .5f + yRadius));
            vertices.Add(new Vector2(-width * .5f + xRadius, -height * .5f));
        }
        
        /// <summary>
        /// Creates the rectangle with segments using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="segments">The segments</param>
        internal static void CreateRectangleWithSegments(Vertices vertices, float width, float height, float xRadius, float yRadius, int segments)
        {
            int numberOfEdges = segments * 4 + 8;
            
            float stepSize = Constant.TwoPi / (numberOfEdges - 4);
            int perPhase = numberOfEdges / 4;
            
            Vector2 posOffset = new Vector2(width / 2 - xRadius, height / 2 - yRadius);
            vertices.Add(posOffset + new Vector2(xRadius, -yRadius + yRadius));
            short phase = 0;
            for (int i = 1; i < numberOfEdges; i++)
            {
                if (i - perPhase == 0 || i - perPhase * 3 == 0)
                {
                    posOffset = new Vector2(posOffset.X * -1, posOffset.Y);
                    phase--;
                }
                
                vertices.Add(posOffset + new Vector2(xRadius * (float) CustomMathF.Cos(stepSize * -(i + phase)),
                    -yRadius * (float) CustomMathF.Sin(stepSize * -(i + phase))));
            }
        }
        
        /// <summary>
        ///     Creates the line using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The vertices</returns>
        public static Vertices CreateLine(Vector2 start, Vector2 end)
        {
            Vertices vertices = new Vertices(2)
            {
                start,
                end
            };
            
            return vertices;
        }
        
        
        /// <summary>
        ///     Creates the circle using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="numberOfEdges">The number of edges</param>
        /// <returns>The vertices</returns>
        public static Vertices CreateCircle(float radius, int numberOfEdges) =>
            CreateEllipse(radius, radius, numberOfEdges);
        
        
        /// <summary>
        ///     Creates the ellipse using the specified x radius
        /// </summary>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="numberOfEdges">The number of edges</param>
        /// <returns>The vertices</returns>
        public static Vertices CreateEllipse(float xRadius, float yRadius, int numberOfEdges)
        {
            Vertices vertices = new Vertices();
            
            float stepSize = Constant.TwoPi / numberOfEdges;
            
            vertices.Add(new Vector2(xRadius, 0));
            for (int i = numberOfEdges - 1; i > 0; --i)
            {
                vertices.Add(new Vector2(xRadius * (float) CustomMathF.Cos(stepSize * i),
                    -yRadius * (float) CustomMathF.Sin(stepSize * i)));
            }
            
            return vertices;
        }
        
        
        /// <summary>
        ///     Creates the arc using the specified radians
        /// </summary>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <returns>The vertices</returns>
        public static Vertices CreateArc(float radians, int sides, float radius)
        {
            Vertices vertices = new Vertices();
            
            float stepSize = radians / sides;
            for (int i = sides - 1; i > 0; i--)
            {
                vertices.Add(new Vector2(radius * (float) CustomMathF.Cos(stepSize * i),
                    radius * (float) CustomMathF.Sin(stepSize * i)));
            }
            
            return vertices;
        }
        
        
        /// <summary>
        ///     Creates the capsule using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="endRadius">The end radius</param>
        /// <param name="edges">The edges</param>
        /// <exception>
        ///     The radius must be lower than height / 2. Higher values of radius would create a
        ///     circle, and not a half circle.
        /// </exception>
        /// <returns>The vertices</returns>
        public static Vertices CreateCapsule(float height, float endRadius, int edges)
        {
            if (endRadius >= height / 2)
            {
                throw new System.ArgumentException(
                    "The radius must be lower than height / 2. Higher values of radius would create a circle, and not a half circle.",
                    nameof(endRadius));
            }
            
            return CreateCapsule(height, endRadius, edges, endRadius, edges);
        }
        
        
        /// <summary>
        ///     Creates the capsule using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="topRadius">The top radius</param>
        /// <param name="topEdges">The top edges</param>
        /// <param name="bottomRadius">The bottom radius</param>
        /// <param name="bottomEdges">The bottom edges</param>
        /// <exception>Bottom edges must be more than 0 </exception>
        /// <exception>Height must be longer than 0 </exception>
        /// <exception>
        ///     The bottom radius must be lower than height / 2. Higher values of bottom radius
        ///     would create a circle, and not a half circle.
        /// </exception>
        /// <exception>The bottom radius must be more than 0 </exception>
        /// <exception>
        ///     The top radius must be lower than height / 2. Higher values of top radius would
        ///     create a circle, and not a half circle.
        /// </exception>
        /// <exception>The top radius must be more than 0 </exception>
        /// <exception>Top edges must be more than 0 </exception>
        /// <returns>The vertices</returns>
        public static Vertices CreateCapsule(float height, float topRadius, int topEdges, float bottomRadius, int bottomEdges)
        {
            ValidateCapsuleParameters(height, topRadius, topEdges, bottomRadius, bottomEdges);
            
            Vertices vertices = new Vertices();
            float newHeight = (height - topRadius - bottomRadius) * 0.5f;
            
            CreateCapsuleTop(vertices, topRadius, newHeight, topEdges);
            CreateCapsuleBottom(vertices, bottomRadius, newHeight, bottomEdges);
            
            return vertices;
        }
        
        /// <summary>
        /// Validates the capsule parameters using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="topRadius">The top radius</param>
        /// <param name="topEdges">The top edges</param>
        /// <param name="bottomRadius">The bottom radius</param>
        /// <param name="bottomEdges">The bottom edges</param>
        /// <exception cref="System.ArgumentException">Bottom edges must be more than 0 </exception>
        /// <exception cref="System.ArgumentException">Height must be longer than 0 </exception>
        /// <exception cref="System.ArgumentException">The bottom radius must be lower than height / 2. Higher values of bottom radius would create a circle, and not a half circle. </exception>
        /// <exception cref="System.ArgumentException">The bottom radius must be more than 0 </exception>
        /// <exception cref="System.ArgumentException">The top radius must be lower than height / 2. Higher values of top radius would create a circle, and not a half circle. </exception>
        /// <exception cref="System.ArgumentException">The top radius must be more than 0 </exception>
        /// <exception cref="System.ArgumentException">Top edges must be more than 0 </exception>
        internal static void ValidateCapsuleParameters(float height, float topRadius, int topEdges, float bottomRadius, int bottomEdges)
        {
            ValidateHeight(height);
            ValidateRadius(topRadius, height, "top");
            ValidateEdges(topEdges, "top");
            ValidateRadius(bottomRadius, height, "bottom");
            ValidateEdges(bottomEdges, "bottom");
        }
        
        /// <summary>
        /// Validates the height using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <exception cref="System.ArgumentException">Height must be longer than 0 </exception>
        internal static void ValidateHeight(float height)
        {
            if (height <= 0)
            {
                throw new System.ArgumentException("Height must be longer than 0", nameof(height));
            }
        }
        
        /// <summary>
        /// Validates the radius using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="height">The height</param>
        /// <param name="position">The position</param>
        /// <exception cref="System.ArgumentException">The {position} radius must be lower than height / 2. Higher values of {position} radius would create a circle, and not a half circle. {position}Radius</exception>
        /// <exception cref="System.ArgumentException">The {position} radius must be more than 0 {position}Radius</exception>
        internal static void ValidateRadius(float radius, float height, string position)
        {
            ValidateRadiusIsPositive(radius, position);
            ValidateRadiusIsLessThanHalfHeight(radius, height, position);
        }
        
        /// <summary>
        /// Validates the radius is positive using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="position">The position</param>
        /// <exception cref="System.ArgumentException">The {position} radius must be more than 0 {position}Radius</exception>
        internal static void ValidateRadiusIsPositive(float radius, string position)
        {
            if (radius <= 0)
            {
                throw new System.ArgumentException($"The {position} radius must be more than 0", $"{position}Radius");
            }
        }
        
        /// <summary>
        /// Validates the radius is less than half height using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="height">The height</param>
        /// <param name="position">The position</param>
        /// <exception cref="System.ArgumentException">The {position} radius must be lower than height / 2. Higher values of {position} radius would create a circle, and not a half circle. {position}Radius</exception>
        internal static void ValidateRadiusIsLessThanHalfHeight(float radius, float height, string position)
        {
            if (radius >= height / 2)
            {
                throw new System.ArgumentException(
                    $"The {position} radius must be lower than height / 2. Higher values of {position} radius would create a circle, and not a half circle.",
                    $"{position}Radius");
            }
        }
        
        /// <summary>
        /// Validates the edges using the specified edges
        /// </summary>
        /// <param name="edges">The edges</param>
        /// <param name="position">The position</param>
        /// <exception cref="System.ArgumentException">{position} edges must be more than 0 {position}Edges</exception>
        internal static void ValidateEdges(int edges, string position)
        {
            if (edges <= 0)
            {
                throw new System.ArgumentException($"{position} edges must be more than 0", $"{position}Edges");
            }
        }
        
        /// <summary>
        /// Creates the capsule top using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="topRadius">The top radius</param>
        /// <param name="newHeight">The new height</param>
        /// <param name="topEdges">The top edges</param>
        internal static void CreateCapsuleTop(Vertices vertices, float topRadius, float newHeight, int topEdges)
        {
            vertices.Add(new Vector2(topRadius, newHeight));
            
            float stepSize = Constant.Pi / topEdges;
            for (int i = 1; i < topEdges; i++)
            {
                vertices.Add(new Vector2(topRadius * (float) CustomMathF.Cos(stepSize * i),
                    topRadius * (float) CustomMathF.Sin(stepSize * i) + newHeight));
            }
            
            vertices.Add(new Vector2(-topRadius, newHeight));
        }
        
        /// <summary>
        /// Creates the capsule bottom using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="bottomRadius">The bottom radius</param>
        /// <param name="newHeight">The new height</param>
        /// <param name="bottomEdges">The bottom edges</param>
        internal static void CreateCapsuleBottom(Vertices vertices, float bottomRadius, float newHeight, int bottomEdges)
        {
            vertices.Add(new Vector2(-bottomRadius, -newHeight));
            
            float stepSize = Constant.Pi / bottomEdges;
            for (int i = 1; i < bottomEdges; i++)
            {
                vertices.Add(new Vector2(-bottomRadius * (float) CustomMathF.Cos(stepSize * i),
                    -bottomRadius * (float) CustomMathF.Sin(stepSize * i) - newHeight));
            }
            
            vertices.Add(new Vector2(bottomRadius, -newHeight));
        }
        
        
        /// <summary>
        ///     Creates the gear using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="numberOfTeeth">The number of teeth</param>
        /// <param name="tipPercentage">The tip percentage</param>
        /// <param name="toothHeight">The tooth height</param>
        /// <returns>The vertices</returns>
        public static Vertices CreateGear(float radius, int numberOfTeeth, float tipPercentage, float toothHeight)
        {
            Vertices vertices = new Vertices();
            
            float stepSize = Constant.TwoPi / numberOfTeeth;
            tipPercentage /= 100f;
            Helper.Clamp(tipPercentage, 0f, 1f);
            float toothTipStepSize = stepSize / 2f * tipPercentage;
            
            float toothAngleStepSize = (stepSize - toothTipStepSize * 2f) / 2f;
            
            for (int i = numberOfTeeth - 1; i >= 0; --i)
            {
                if (toothTipStepSize > 0f)
                {
                    vertices.Add(
                        new Vector2(radius *
                                    (float) CustomMathF.Cos(stepSize * i + toothAngleStepSize * 2f + toothTipStepSize),
                            -radius *
                            (float) CustomMathF.Sin(stepSize * i + toothAngleStepSize * 2f + toothTipStepSize)));
                    
                    vertices.Add(
                        new Vector2((radius + toothHeight) *
                                    (float) CustomMathF.Cos(stepSize * i + toothAngleStepSize + toothTipStepSize),
                            -(radius + toothHeight) *
                            (float) CustomMathF.Sin(stepSize * i + toothAngleStepSize + toothTipStepSize)));
                }
                
                vertices.Add(new Vector2((radius + toothHeight) *
                                         (float) CustomMathF.Cos(stepSize * i + toothAngleStepSize),
                    -(radius + toothHeight) *
                    (float) CustomMathF.Sin(stepSize * i + toothAngleStepSize)));
                
                vertices.Add(new Vector2(radius * (float) CustomMathF.Cos(stepSize * i),
                    -radius * (float) CustomMathF.Sin(stepSize * i)));
            }
            
            return vertices;
        }
    }
}