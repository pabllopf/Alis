// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Shape.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Math.Figures.D2.Rectangle;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Base class for textured shapes with outline
    /// </summary>
    ////////////////////////////////////////////////////////////
    public abstract class Shape : Transformable, IDrawable
    {
        /// <summary>
        ///     The my get point callback
        /// </summary>
        private readonly GetPointCallbackType myGetPointCallback;

        /// <summary>
        ///     The my get point count callback
        /// </summary>
        private readonly GetPointCountCallbackType myGetPointCountCallback;

        /// <summary>
        ///     The my texture
        /// </summary>
        private Texture myTexture;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        protected Shape() :
            base(IntPtr.Zero)
        {
            myGetPointCountCallback = InternalGetPointCount;
            myGetPointCallback = InternalGetPoint;
            CPointer = sfShape_create(myGetPointCountCallback, myGetPointCallback, IntPtr.Zero);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the shape from another shape
        /// </summary>
        /// <param name="copy">Shape to copy</param>
        ////////////////////////////////////////////////////////////
        public Shape(Shape copy) :
            base(IntPtr.Zero)
        {
            myGetPointCountCallback = InternalGetPointCount;
            myGetPointCallback = InternalGetPoint;
            CPointer = sfShape_create(myGetPointCountCallback, myGetPointCallback, IntPtr.Zero);

            Origin = copy.Origin;
            Position = copy.Position;
            Rotation = copy.Rotation;
            Scale = copy.Scale;

            Texture = copy.Texture;
            TextureRect = copy.TextureRect;
            FillColor = copy.FillColor;
            OutlineColor = copy.OutlineColor;
            OutlineThickness = copy.OutlineThickness;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Source texture of the shape
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Texture Texture
        {
            get => myTexture;
            set
            {
                myTexture = value;
                sfShape_setTexture(CPointer, value != null ? value.CPointer : IntPtr.Zero, false);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Sub-rectangle of the texture that the shape will display
        /// </summary>
        ////////////////////////////////////////////////////////////
        public RectangleI TextureRect
        {
            get => sfShape_getTextureRect(CPointer);
            set => sfShape_setTextureRect(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Fill color of the shape
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Color FillColor
        {
            get => sfShape_getFillColor(CPointer);
            set => sfShape_setFillColor(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Outline color of the shape
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Color OutlineColor
        {
            get => sfShape_getOutlineColor(CPointer);
            set => sfShape_setOutlineColor(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Thickness of the shape's outline
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float OutlineThickness
        {
            get => sfShape_getOutlineThickness(CPointer);
            set => sfShape_setOutlineThickness(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw the shape to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        ////////////////////////////////////////////////////////////
        public void Draw(IRenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawShape(((RenderWindow) target).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawShape(((RenderTexture) target).CPointer, CPointer, ref marshaledStates);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the total number of points of the shape
        /// </summary>
        /// <returns>The total point count</returns>
        ////////////////////////////////////////////////////////////
        public abstract uint GetPointCount();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the position of a point
        ///     The returned point is in local coordinates, that is,
        ///     the shape's transforms (position, rotation, scale) are
        ///     not taken into account.
        ///     The result is undefined if index is out of the valid range.
        /// </summary>
        /// <param name="index">Index of the point to get, in range [0 .. PointCount - 1]</param>
        /// <returns>index-th point of the shape</returns>
        ////////////////////////////////////////////////////////////
        public abstract Vector2F GetPoint(uint index);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the local bounding rectangle of the entity.
        ///     The returned rectangle is in local coordinates, which means
        ///     that it ignores the transformations (translation, rotation,
        ///     scale, ...) that are applied to the entity.
        ///     In other words, this function returns the bounds of the
        ///     entity in the entity's coordinate system.
        /// </summary>
        /// <returns>Local bounding rectangle of the entity</returns>
        ////////////////////////////////////////////////////////////
        public RectangleF GetLocalBounds() => sfShape_getLocalBounds(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the global bounding rectangle of the entity.
        ///     The returned rectangle is in global coordinates, which means
        ///     that it takes in account the transformations (translation,
        ///     rotation, scale, ...) that are applied to the entity.
        ///     In other words, this function returns the bounds of the
        ///     sprite in the global 2D world's coordinate system.
        /// </summary>
        /// <returns>Global bounding rectangle of the entity</returns>
        ////////////////////////////////////////////////////////////
        public RectangleF GetGlobalBounds() =>
            // because we override the object's transform
            // we don't use the native getGlobalBounds function,
            Transform.TransformRect(GetLocalBounds());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Recompute the internal geometry of the shape.
        ///     This function must be called by the derived class everytime
        ///     the shape's points change (ie. the result of either
        ///     PointCount or GetPoint is different).
        /// </summary>
        ////////////////////////////////////////////////////////////
        protected void Update()
        {
            sfShape_update(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfShape_destroy(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Callback passed to the C API
        /// </summary>
        ////////////////////////////////////////////////////////////
        private uint InternalGetPointCount(IntPtr userData) => GetPointCount();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Callback passed to the C API
        /// </summary>
        ////////////////////////////////////////////////////////////
        private Vector2F InternalGetPoint(uint index, IntPtr userData) => GetPoint(index);

        /// <summary>
        ///     Sfs the shape create using the specified get point count
        /// </summary>
        /// <param name="getPointCount">The get point count</param>
        /// <param name="getPoint">The get point</param>
        /// <param name="userData">The user data</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfShape_create(GetPointCountCallbackType getPointCount,
            GetPointCallbackType getPoint, IntPtr userData);

        /// <summary>
        ///     Sfs the shape copy using the specified shape
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfShape_copy(IntPtr shape);

        /// <summary>
        ///     Sfs the shape destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShape_destroy(IntPtr cPointer);

        /// <summary>
        ///     Sfs the shape set texture using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="texture">The texture</param>
        /// <param name="adjustToNewSize">The adjust to new size</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShape_setTexture(IntPtr cPointer, IntPtr texture, bool adjustToNewSize);

        /// <summary>
        ///     Sfs the shape set texture rect using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="rect">The rect</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShape_setTextureRect(IntPtr cPointer, RectangleI rect);

        /// <summary>
        ///     Sfs the shape get texture rect using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleI sfShape_getTextureRect(IntPtr cPointer);

        /// <summary>
        ///     Sfs the shape set fill color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="color">The color</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShape_setFillColor(IntPtr cPointer, Color color);

        /// <summary>
        ///     Sfs the shape get fill color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Color sfShape_getFillColor(IntPtr cPointer);

        /// <summary>
        ///     Sfs the shape set outline color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="color">The color</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShape_setOutlineColor(IntPtr cPointer, Color color);

        /// <summary>
        ///     Sfs the shape get outline color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Color sfShape_getOutlineColor(IntPtr cPointer);

        /// <summary>
        ///     Sfs the shape set outline thickness using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShape_setOutlineThickness(IntPtr cPointer, float thickness);

        /// <summary>
        ///     Sfs the shape get outline thickness using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfShape_getOutlineThickness(IntPtr cPointer);

        /// <summary>
        ///     Sfs the shape get local bounds using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleF sfShape_getLocalBounds(IntPtr cPointer);

        /// <summary>
        ///     Sfs the shape update using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfShape_update(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window draw shape using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="shape">The shape</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_drawShape(IntPtr cPointer, IntPtr shape,
            ref RenderStates.MarshalData states);

        /// <summary>
        ///     Sfs the render texture draw shape using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="shape">The shape</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_drawShape(IntPtr cPointer, IntPtr shape,
            ref RenderStates.MarshalData states);

        /// <summary>
        ///     The get point count callback type
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GetPointCountCallbackType(IntPtr userData);

        /// <summary>
        ///     The get point callback type
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Vector2F GetPointCallbackType(uint index, IntPtr userData);
    }
}