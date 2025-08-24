using System;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    
    /// <summary>
    /// This class defines a view (position, size, etc.) ;
    /// you can consider it as a 2D camera
    /// </summary>
    /// <remarks>
    /// See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    
    public class View : ObjectBase
    {
        
        /// <summary>
        /// Create a default view (1000x1000)
        /// </summary>
        
        public View() :
            base(sfView_create())
        {
        }

        
        /// <summary>
        /// Construct the view from a rectangle
        /// </summary>
        /// <param name="viewRect">Rectangle defining the position and size of the view</param>
        
        public View(FloatRect viewRect) :
            base(sfView_createFromRect(viewRect))
        {
        }

        
        /// <summary>
        /// Construct the view from its center and size
        /// </summary>
        /// <param name="center">Center of the view</param>
        /// <param name="size">Size of the view</param>
        
        public View(Vector2f center, Vector2f size) :
            base(sfView_create())
        {
            Center = center;
            Size = size;
        }

        
        /// <summary>
        /// Construct the view from another view
        /// </summary>
        /// <param name="copy">View to copy</param>
        
        public View(View copy) :
            base(sfView_copy(copy.CPointer))
        {
        }

        
        /// <summary>
        /// Center of the view
        /// </summary>
        
        public Vector2f Center
        {
            get { return sfView_getCenter(CPointer); }
            set { sfView_setCenter(CPointer, value); }
        }

        
        /// <summary>
        /// Half-size of the view
        /// </summary>
        
        public Vector2f Size
        {
            get { return sfView_getSize(CPointer); }
            set { sfView_setSize(CPointer, value); }
        }

        
        /// <summary>
        /// Rotation of the view, in degrees
        /// </summary>
        
        public float Rotation
        {
            get { return sfView_getRotation(CPointer); }
            set { sfView_setRotation(CPointer, value); }
        }

        
        /// <summary>
        /// Target viewport of the view, defined as a factor of the
        /// size of the target to which the view is applied
        /// </summary>
        
        public FloatRect Viewport
        {
            get { return sfView_getViewport(CPointer); }
            set { sfView_setViewport(CPointer, value); }
        }

        
        /// <summary>
        /// Rebuild the view from a rectangle
        /// </summary>
        /// <param name="rectangle">Rectangle defining the position and size of the view</param>
        
        public void Reset(FloatRect rectangle)
        {
            sfView_reset(CPointer, rectangle);
        }

        
        /// <summary>
        /// Move the view
        /// </summary>
        /// <param name="offset">Offset to move the view</param>
        
        public void Move(Vector2f offset)
        {
            sfView_move(CPointer, offset);
        }

        
        /// <summary>
        /// Rotate the view
        /// </summary>
        /// <param name="angle">Angle of rotation, in degrees</param>
        
        public void Rotate(float angle)
        {
            sfView_rotate(CPointer, angle);
        }

        
        /// <summary>
        /// Resize the view rectangle to simulate a zoom / unzoom effect
        /// </summary>
        /// <param name="factor">Zoom factor to apply, relative to the current zoom</param>
        
        public void Zoom(float factor)
        {
            sfView_zoom(CPointer, factor);
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[View]" +
                   " Center(" + Center + ")" +
                   " Size(" + Size + ")" +
                   " Rotation(" + Rotation + ")" +
                   " Viewport(" + Viewport + ")";
        }

        
        /// <summary>
        /// Internal constructor for other classes which need to manipulate raw views
        /// </summary>
        /// <param name="cPointer">Direct pointer to the view object in the C library</param>
        
        internal View(IntPtr cPointer) :
            base(cPointer)
        {
            myExternal = true;
        }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            if (!myExternal)
            {
                sfView_destroy(CPointer);
            }
        }

        /// <summary>
        /// The my external
        /// </summary>
        private readonly bool myExternal = false;

        #region Imports
        /// <summary>
        /// Sfs the view create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfView_create();

        /// <summary>
        /// Sfs the view create from rect using the specified rect
        /// </summary>
        /// <param name="Rect">The rect</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfView_createFromRect(FloatRect Rect);

        /// <summary>
        /// Sfs the view copy using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfView_copy(IntPtr View);

        /// <summary>
        /// Sfs the view destroy using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_destroy(IntPtr View);

        /// <summary>
        /// Sfs the view set center using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="center">The center</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_setCenter(IntPtr View, Vector2f center);

        /// <summary>
        /// Sfs the view set size using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="size">The size</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_setSize(IntPtr View, Vector2f size);

        /// <summary>
        /// Sfs the view set rotation using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="Angle">The angle</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_setRotation(IntPtr View, float Angle);

        /// <summary>
        /// Sfs the view set viewport using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="Viewport">The viewport</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_setViewport(IntPtr View, FloatRect Viewport);

        /// <summary>
        /// Sfs the view reset using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="Rectangle">The rectangle</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_reset(IntPtr View, FloatRect Rectangle);

        /// <summary>
        /// Sfs the view get center using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <returns>The vector 2f</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Vector2f sfView_getCenter(IntPtr View);

        /// <summary>
        /// Sfs the view get size using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <returns>The vector 2f</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Vector2f sfView_getSize(IntPtr View);

        /// <summary>
        /// Sfs the view get rotation using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern float sfView_getRotation(IntPtr View);

        /// <summary>
        /// Sfs the view get viewport using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <returns>The float rect</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern FloatRect sfView_getViewport(IntPtr View);

        /// <summary>
        /// Sfs the view move using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="offset">The offset</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_move(IntPtr View, Vector2f offset);

        /// <summary>
        /// Sfs the view rotate using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="Angle">The angle</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_rotate(IntPtr View, float Angle);

        /// <summary>
        /// Sfs the view zoom using the specified view
        /// </summary>
        /// <param name="View">The view</param>
        /// <param name="Factor">The factor</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfView_zoom(IntPtr View, float Factor);
        #endregion
    }
}
