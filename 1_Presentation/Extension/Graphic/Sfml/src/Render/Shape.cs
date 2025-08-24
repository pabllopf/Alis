using System;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    
    /// <summary>
    /// Base class for textured shapes with outline
    /// </summary>
    
    public abstract class Shape : Transformable, Drawable
    {
        
        /// <summary>
        /// Source texture of the shape
        /// </summary>
        
        public Texture Texture
        {
            get { return myTexture; }
            set { myTexture = value; sfShape_setTexture(CPointer, value != null ? value.CPointer : IntPtr.Zero, false); }
        }

        
        /// <summary>
        /// Sub-rectangle of the texture that the shape will display
        /// </summary>
        
        public IntRect TextureRect
        {
            get { return sfShape_getTextureRect(CPointer); }
            set { sfShape_setTextureRect(CPointer, value); }
        }

        
        /// <summary>
        /// Fill color of the shape
        /// </summary>
        
        public Color FillColor
        {
            get { return sfShape_getFillColor(CPointer); }
            set { sfShape_setFillColor(CPointer, value); }
        }

        
        /// <summary>
        /// Outline color of the shape
        /// </summary>
        
        public Color OutlineColor
        {
            get { return sfShape_getOutlineColor(CPointer); }
            set { sfShape_setOutlineColor(CPointer, value); }
        }

        
        /// <summary>
        /// Thickness of the shape's outline
        /// </summary>
        
        public float OutlineThickness
        {
            get { return sfShape_getOutlineThickness(CPointer); }
            set { sfShape_setOutlineThickness(CPointer, value); }
        }

        
        /// <summary>
        /// Get the total number of points of the shape
        /// </summary>
        /// <returns>The total point count</returns>
        
        public abstract uint GetPointCount();

        
        /// <summary>
        /// Get the position of a point
        ///
        /// The returned point is in local coordinates, that is,
        /// the shape's transforms (position, rotation, scale) are
        /// not taken into account.
        /// The result is undefined if index is out of the valid range.
        /// </summary>
        /// <param name="index">Index of the point to get, in range [0 .. PointCount - 1]</param>
        /// <returns>index-th point of the shape</returns>
        
        public abstract Vector2f GetPoint(uint index);

        
        /// <summary>
        /// Get the local bounding rectangle of the entity.
        ///
        /// The returned rectangle is in local coordinates, which means
        /// that it ignores the transformations (translation, rotation,
        /// scale, ...) that are applied to the entity.
        /// In other words, this function returns the bounds of the
        /// entity in the entity's coordinate system.
        /// </summary>
        /// <returns>Local bounding rectangle of the entity</returns>
        
        public FloatRect GetLocalBounds()
        {
            return sfShape_getLocalBounds(CPointer);
        }

        
        /// <summary>
        /// Get the global bounding rectangle of the entity.
        ///
        /// The returned rectangle is in global coordinates, which means
        /// that it takes in account the transformations (translation,
        /// rotation, scale, ...) that are applied to the entity.
        /// In other words, this function returns the bounds of the
        /// sprite in the global 2D world's coordinate system.
        /// </summary>
        /// <returns>Global bounding rectangle of the entity</returns>
        
        public FloatRect GetGlobalBounds()
        {
            // we don't use the native getGlobalBounds function,
            // because we override the object's transform
            return Transform.TransformRect(GetLocalBounds());
        }

        
        /// <summary>
        /// Draw the shape to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawShape(( (RenderWindow)target ).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawShape(( (RenderTexture)target ).CPointer, CPointer, ref marshaledStates);
            }
        }

        
        /// <summary>
        /// Default constructor
        /// </summary>
        
        protected Shape() :
            base(IntPtr.Zero)
        {
            myGetPointCountCallback = new GetPointCountCallbackType(InternalGetPointCount);
            myGetPointCallback = new GetPointCallbackType(InternalGetPoint);
            CPointer = sfShape_create(myGetPointCountCallback, myGetPointCallback, IntPtr.Zero);
        }

        
        /// <summary>
        /// Construct the shape from another shape
        /// </summary>
        /// <param name="copy">Shape to copy</param>
        
        public Shape(Shape copy) :
            base(IntPtr.Zero)
        {
            myGetPointCountCallback = new GetPointCountCallbackType(InternalGetPointCount);
            myGetPointCallback = new GetPointCallbackType(InternalGetPoint);
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

        
        /// <summary>
        /// Recompute the internal geometry of the shape.
        ///
        /// This function must be called by the derived class everytime
        /// the shape's points change (ie. the result of either
        /// PointCount or GetPoint is different).
        /// </summary>
        
        protected void Update()
        {
            sfShape_update(CPointer);
        }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            sfShape_destroy(CPointer);
        }

        
        /// <summary>
        /// Callback passed to the C API
        /// </summary>
        
        private uint InternalGetPointCount(IntPtr userData)
        {
            return GetPointCount();
        }

        
        /// <summary>
        /// Callback passed to the C API
        /// </summary>
        
        private Vector2f InternalGetPoint(uint index, IntPtr userData)
        {
            return GetPoint(index);
        }

        /// <summary>
        /// The get point count callback type
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GetPointCountCallbackType(IntPtr UserData);

        /// <summary>
        /// The get point callback type
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Vector2f GetPointCallbackType(uint index, IntPtr UserData);

        /// <summary>
        /// The my get point count callback
        /// </summary>
        private readonly GetPointCountCallbackType myGetPointCountCallback;
        /// <summary>
        /// The my get point callback
        /// </summary>
        private readonly GetPointCallbackType myGetPointCallback;

        /// <summary>
        /// The my texture
        /// </summary>
        private Texture myTexture = null;

        #region Imports
        /// <summary>
        /// Sfs the shape create using the specified get point count
        /// </summary>
        /// <param name="getPointCount">The get point count</param>
        /// <param name="getPoint">The get point</param>
        /// <param name="userData">The user data</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfShape_create(GetPointCountCallbackType getPointCount, GetPointCallbackType getPoint, IntPtr userData);

        /// <summary>
        /// Sfs the shape copy using the specified shape
        /// </summary>
        /// <param name="Shape">The shape</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfShape_copy(IntPtr Shape);

        /// <summary>
        /// Sfs the shape destroy using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfShape_destroy(IntPtr CPointer);

        /// <summary>
        /// Sfs the shape set texture using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Texture">The texture</param>
        /// <param name="AdjustToNewSize">The adjust to new size</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfShape_setTexture(IntPtr CPointer, IntPtr Texture, bool AdjustToNewSize);

        /// <summary>
        /// Sfs the shape set texture rect using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Rect">The rect</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfShape_setTextureRect(IntPtr CPointer, IntRect Rect);

        /// <summary>
        /// Sfs the shape get texture rect using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The int rect</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntRect sfShape_getTextureRect(IntPtr CPointer);

        /// <summary>
        /// Sfs the shape set fill color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Color">The color</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfShape_setFillColor(IntPtr CPointer, Color Color);

        /// <summary>
        /// Sfs the shape get fill color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Color sfShape_getFillColor(IntPtr CPointer);

        /// <summary>
        /// Sfs the shape set outline color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Color">The color</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfShape_setOutlineColor(IntPtr CPointer, Color Color);

        /// <summary>
        /// Sfs the shape get outline color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Color sfShape_getOutlineColor(IntPtr CPointer);

        /// <summary>
        /// Sfs the shape set outline thickness using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Thickness">The thickness</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfShape_setOutlineThickness(IntPtr CPointer, float Thickness);

        /// <summary>
        /// Sfs the shape get outline thickness using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern float sfShape_getOutlineThickness(IntPtr CPointer);

        /// <summary>
        /// Sfs the shape get local bounds using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern FloatRect sfShape_getLocalBounds(IntPtr CPointer);

        /// <summary>
        /// Sfs the shape update using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfShape_update(IntPtr CPointer);

        /// <summary>
        /// Sfs the render window draw shape using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Shape">The shape</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderWindow_drawShape(IntPtr CPointer, IntPtr Shape, ref RenderStates.MarshalData states);

        /// <summary>
        /// Sfs the render texture draw shape using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Shape">The shape</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderTexture_drawShape(IntPtr CPointer, IntPtr Shape, ref RenderStates.MarshalData states);
        #endregion
    }
}
