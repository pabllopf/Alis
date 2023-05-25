// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:View.cs
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

namespace Alis.Core.Input.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     This class defines a view (position, size, etc.) ;
    ///     you can consider it as a 2D camera
    /// </summary>
    /// <remarks>
    ///     See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public class View : ObjectBase
    {
        /// <summary>
        ///     The my external
        /// </summary>
        private readonly bool myExternal;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create a default view (1000x1000)
        /// </summary>
        ////////////////////////////////////////////////////////////
        public View() :
            base(sfView_create())
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the view from a rectangle
        /// </summary>
        /// <param name="viewRect">Rectangle defining the position and size of the view</param>
        ////////////////////////////////////////////////////////////
        public View(RectangleF viewRect) :
            base(sfView_createFromRect(viewRect))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the view from its center and size
        /// </summary>
        /// <param name="center">Center of the view</param>
        /// <param name="size">Size of the view</param>
        ////////////////////////////////////////////////////////////
        public View(Vector2F center, Vector2F size) :
            base(sfView_create())
        {
            Center = center;
            Size = size;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the view from another view
        /// </summary>
        /// <param name="copy">View to copy</param>
        ////////////////////////////////////////////////////////////
        public View(View copy) :
            base(sfView_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal constructor for other classes which need to manipulate raw views
        /// </summary>
        /// <param name="cPointer">Direct pointer to the view object in the C library</param>
        ////////////////////////////////////////////////////////////
        internal View(IntPtr cPointer) :
            base(cPointer)
            => myExternal = true;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Center of the view
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2F Center
        {
            get => sfView_getCenter(CPointer);
            set => sfView_setCenter(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Half-size of the view
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2F Size
        {
            get => sfView_getSize(CPointer);
            set => sfView_setSize(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Rotation of the view, in degrees
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float Rotation
        {
            get => sfView_getRotation(CPointer);
            set => sfView_setRotation(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Target viewport of the view, defined as a factor of the
        ///     size of the target to which the view is applied
        /// </summary>
        ////////////////////////////////////////////////////////////
        public RectangleF Viewport
        {
            get => sfView_getViewport(CPointer);
            set => sfView_setViewport(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Rebuild the view from a rectangle
        /// </summary>
        /// <param name="rectangle">Rectangle defining the position and size of the view</param>
        ////////////////////////////////////////////////////////////
        public void Reset(RectangleF rectangle)
        {
            sfView_reset(CPointer, rectangle);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Move the view
        /// </summary>
        /// <param name="offset">Offset to move the view</param>
        ////////////////////////////////////////////////////////////
        public void Move(Vector2F offset)
        {
            sfView_move(CPointer, offset);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Rotate the view
        /// </summary>
        /// <param name="angle">Angle of rotation, in degrees</param>
        ////////////////////////////////////////////////////////////
        public void Rotate(float angle)
        {
            sfView_rotate(CPointer, angle);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Resize the view rectangle to simulate a zoom / unzoom effect
        /// </summary>
        /// <param name="factor">Zoom factor to apply, relative to the current zoom</param>
        ////////////////////////////////////////////////////////////
        public void Zoom(float factor)
        {
            sfView_zoom(CPointer, factor);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[View]" +
                                             " Center(" + Center + ")" +
                                             " Size(" + Size + ")" +
                                             " Rotation(" + Rotation + ")" +
                                             " Viewport(" + Viewport + ")";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            if (!myExternal)
            {
                sfView_destroy(CPointer);
            }
        }

        /// <summary>
        ///     Sfs the view create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfView_create();

        /// <summary>
        ///     Sfs the view create from rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfView_createFromRect(RectangleF rect);

        /// <summary>
        ///     Sfs the view copy using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfView_copy(IntPtr view);

        /// <summary>
        ///     Sfs the view destroy using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_destroy(IntPtr view);

        /// <summary>
        ///     Sfs the view set center using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="center">The center</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_setCenter(IntPtr view, Vector2F center);

        /// <summary>
        ///     Sfs the view set size using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="size">The size</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_setSize(IntPtr view, Vector2F size);

        /// <summary>
        ///     Sfs the view set rotation using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="angle">The angle</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_setRotation(IntPtr view, float angle);

        /// <summary>
        ///     Sfs the view set viewport using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="viewport">The viewport</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_setViewport(IntPtr view, RectangleF viewport);

        /// <summary>
        ///     Sfs the view reset using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="rectangle">The rectangle</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_reset(IntPtr view, RectangleF rectangle);

        /// <summary>
        ///     Sfs the view get center using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The vector 2f</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2F sfView_getCenter(IntPtr view);

        /// <summary>
        ///     Sfs the view get size using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The vector 2f</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2F sfView_getSize(IntPtr view);

        /// <summary>
        ///     Sfs the view get rotation using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfView_getRotation(IntPtr view);

        /// <summary>
        ///     Sfs the view get viewport using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The float rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleF sfView_getViewport(IntPtr view);

        /// <summary>
        ///     Sfs the view move using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="offset">The offset</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_move(IntPtr view, Vector2F offset);

        /// <summary>
        ///     Sfs the view rotate using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="angle">The angle</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_rotate(IntPtr view, float angle);

        /// <summary>
        ///     Sfs the view zoom using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="factor">The factor</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfView_zoom(IntPtr view, float factor);
    }
}