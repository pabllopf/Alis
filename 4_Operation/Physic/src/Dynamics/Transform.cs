// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Transform.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     A transform contains translation and rotation. It is used to represent
    ///     the position and orientation of rigid frames.
    /// </summary>
    public struct Transform : IInitable, IGameObjectComponent
    {
        /// <summary>
        ///     The
        /// </summary>
        public Complex Rotation;

        /// <summary>
        ///     The
        /// </summary>
        public Vector2F Position;
        
        /// <summary>
        /// The scale
        /// </summary>
        public Vector2F Scale;

        /// <summary>
        ///     Gets the value of the identity
        /// </summary>
        public static Transform Identity { get; } = new Transform(Vector2F.Zero, Complex.One);

        /// <summary>
        ///     Initialize using a position vector and a Complex rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation</param>
        public Transform(Vector2F position, Complex rotation)
        {
            Rotation = rotation;
            Position = position;
            Scale = Vector2F.One; // Default scale is 1,1
            Logger.Log($"Transform: {Position} {Rotation} {Scale}");
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public Transform(Vector2F position, Complex rotation, Vector2F scale)
        {
            Rotation = rotation;
            Position = position;
            Scale = scale;
            
            Logger.Log($"Transform: {position} {rotation} {scale}");
        }

        /// <summary>
        ///     Initialize using a position vector and a rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The rotation angle</param>
        public Transform(Vector2F position, float angle)
            : this(position, Complex.FromAngle(angle))
        {
            Logger.Log($"Transform: {Position} {Rotation} {Scale}");
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="angle">The angle</param>
        /// <param name="scale">The scale</param>
        public Transform(Vector2F position, float angle, Vector2F scale)
            : this(position, Complex.FromAngle(angle), scale)
        {
            Logger.Log($"Transform: {Position} {Rotation} {Scale}");
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Multiply(Vector2F left, ref Transform right) => Multiply(ref left, ref right);

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Multiply(ref Vector2F left, ref Transform right) =>
            // Opt: var result = Complex.Multiply(left, right.q) + right.p;
            new Vector2F(
                left.X * right.Rotation.R - left.Y * right.Rotation.I + right.Position.X,
                left.Y * right.Rotation.R + left.X * right.Rotation.I + right.Position.Y);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Divide(Vector2F left, ref Transform right) => Divide(ref left, ref right);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Divide(ref Vector2F left, ref Transform right)
        {
            // Opt: var result = Complex.Divide(left - right.p, right);
            float px = left.X - right.Position.X;
            float py = left.Y - right.Position.Y;
            return new Vector2F(
                px * right.Rotation.R + py * right.Rotation.I,
                py * right.Rotation.R - px * right.Rotation.I);
        }

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(Vector2F left, ref Transform right, out Vector2F result)
        {
            // Opt: var result = Complex.Divide(left - right.p, right);
            float px = left.X - right.Position.X;
            float py = left.Y - right.Position.Y;
            result = new Vector2F(
                px * right.Rotation.R + py * right.Rotation.I,
                py * right.Rotation.R - px * right.Rotation.I);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Multiply(ref Transform left, ref Transform right) => new Transform(
            Complex.Multiply(ref left.Position, ref right.Rotation) + right.Position,
            Complex.Multiply(ref left.Rotation, ref right.Rotation));

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Divide(ref Transform left, ref Transform right) => new Transform(
            Complex.Divide(left.Position - right.Position, ref right.Rotation),
            Complex.Divide(ref left.Rotation, ref right.Rotation));

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, ref Transform right, out Transform result)
        {
            Complex.Divide(left.Position - right.Position, ref right.Rotation, out result.Position);
            Complex.Divide(ref left.Rotation, ref right.Rotation, out result.Rotation);
            result.Scale = left.Scale / right.Scale;
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Multiply(ref Transform left, Complex right, out Transform result)
        {
            result.Position = Complex.Multiply(ref left.Position, ref right);
            result.Rotation = Complex.Multiply(ref left.Rotation, ref right);
            result.Scale = Complex.Multiply(ref left.Scale, ref right);
        }

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, Complex right, out Transform result)
        {
            result.Position = Complex.Divide(ref left.Position, ref right);
            result.Rotation = Complex.Divide(ref left.Rotation, ref right);
            result.Scale = Complex.Divide(ref left.Scale, ref right);
        }

        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(IGameObject self)
        {
            
        }

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
            
        }
    }
}