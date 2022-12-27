// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Transformable.cs
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
using Alis.Core.Aspect.Base;
using Alis.Core.Aspect.Math;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Decomposed transform defined by a position, a rotation and a scale
    /// </summary>
    /// <remarks>
    ///     A note on coordinates and undistorted rendering:
    ///     By default, SFML (or more exactly, OpenGL) may interpolate drawable objects
    ///     such as sprites or texts when rendering. While this allows transitions
    ///     like slow movements or rotations to appear smoothly, it can lead to
    ///     unwanted results in some cases, for example blurred or distorted objects.
    ///     In order to render a SFML.Graphics.Drawable object pixel-perfectly, make sure
    ///     the involved coordinates allow a 1:1 mapping of pixels in the window
    ///     to texels (pixels in the texture). More specifically, this means:
    ///     * The object's position, origin and scale have no fractional part
    ///     * The object's and the view's rotation are a multiple of 90 degrees
    ///     * The view's center and size have no fractional part
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public class Transformable : ObjectBase
    {
        /// <summary>
        ///     The my inverse need update
        /// </summary>
        private bool myInverseNeedUpdate = true;

        /// <summary>
        ///     The my inverse transform
        /// </summary>
        private Transform myInverseTransform;

        /// <summary>
        ///     The vector 2f
        /// </summary>
        private Vector2F myOrigin = new Vector2F(0, 0);

        /// <summary>
        ///     The vector 2f
        /// </summary>
        private Vector2F myPosition = new Vector2F(0, 0);

        /// <summary>
        ///     The my rotation
        /// </summary>
        private float myRotation;

        /// <summary>
        ///     The vector 2f
        /// </summary>
        private Vector2F myScale = new Vector2F(1, 1);

        /// <summary>
        ///     The my transform
        /// </summary>
        private Transform myTransform;

        /// <summary>
        ///     The my transform need update
        /// </summary>
        private bool myTransformNeedUpdate = true;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Transformable() :
            base(IntPtr.Zero)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the transformable from another transformable
        /// </summary>
        /// <param name="transformable">Transformable to copy</param>
        ////////////////////////////////////////////////////////////
        public Transformable(Transformable transformable) :
            base(IntPtr.Zero)
        {
            Origin = transformable.Origin;
            Position = transformable.Position;
            Rotation = transformable.Rotation;
            Scale = transformable.Scale;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the object from its internal C pointer
        /// </summary>
        /// <param name="cPointer">Pointer to the object in the C library</param>
        ////////////////////////////////////////////////////////////
        protected Transformable(IntPtr cPointer) :
            base(cPointer)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Position of the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2F Position
        {
            get => myPosition;
            set
            {
                myPosition = value;
                myTransformNeedUpdate = true;
                myInverseNeedUpdate = true;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Rotation of the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float Rotation
        {
            get => myRotation;
            set
            {
                myRotation = value;
                myTransformNeedUpdate = true;
                myInverseNeedUpdate = true;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Scale of the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2F Scale
        {
            get => myScale;
            set
            {
                myScale = value;
                myTransformNeedUpdate = true;
                myInverseNeedUpdate = true;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The origin of an object defines the center point for
        ///     all transformations (position, scale, rotation).
        ///     The coordinates of this point must be relative to the
        ///     top-left corner of the object, and ignore all
        ///     transformations (position, scale, rotation).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2F Origin
        {
            get => myOrigin;
            set
            {
                myOrigin = value;
                myTransformNeedUpdate = true;
                myInverseNeedUpdate = true;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The combined transform of the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Transform Transform
        {
            get
            {
                if (myTransformNeedUpdate)
                {
                    myTransformNeedUpdate = false;

                    float angle = -myRotation * 3.141592654F / 180.0F;
                    float cosine = (float) Math.Cos(angle);
                    float sine = (float) Math.Sin(angle);
                    float sxc = myScale.X * cosine;
                    float syc = myScale.Y * cosine;
                    float sxs = myScale.X * sine;
                    float sys = myScale.Y * sine;
                    float tx = -myOrigin.X * sxc - myOrigin.Y * sys + myPosition.X;
                    float ty = myOrigin.X * sxs - myOrigin.Y * syc + myPosition.Y;

                    myTransform = new Transform(sxc, sys, tx,
                        -sxs, syc, ty,
                        0.0F, 0.0F, 1.0F);
                }

                return myTransform;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The combined transform of the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Transform InverseTransform
        {
            get
            {
                if (myInverseNeedUpdate)
                {
                    myInverseTransform = Transform.GetInverse();
                    myInverseNeedUpdate = false;
                }

                return myInverseTransform;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            // Does nothing, this instance is either pure C# (if created by the user)
            // or not the final object (if used as a base for a drawable class)
        }
    }
}