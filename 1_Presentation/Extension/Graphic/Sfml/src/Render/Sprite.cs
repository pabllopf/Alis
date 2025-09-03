using System;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    
    /// <summary>
    /// This class defines a sprite : texture, transformations,
    /// color, and draw on screen
    /// </summary>
    /// <remarks>
    /// See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    
    public class Sprite : Transformable, IDrawable
    {
        
        /// <summary>
        /// Default constructor
        /// </summary>
        
        public Sprite() :
            base(sfSprite_create())
        {
        }

        
        /// <summary>
        /// Construct the sprite from a source texture
        /// </summary>
        /// <param name="texture">Source texture to assign to the sprite</param>
        
        public Sprite(Texture texture) :
            base(sfSprite_create())
        {
            Texture = texture;
        }

        
        /// <summary>
        /// Construct the sprite from a source texture
        /// </summary>
        /// <param name="texture">Source texture to assign to the sprite</param>
        /// <param name="rectangle">Sub-rectangle of the texture to assign to the sprite</param>
        
        public Sprite(Texture texture, IntRect rectangle) :
            base(sfSprite_create())
        {
            Texture = texture;
            TextureRect = rectangle;
        }

        
        /// <summary>
        /// Construct the sprite from another sprite
        /// </summary>
        /// <param name="copy">Sprite to copy</param>
        
        public Sprite(Sprite copy) :
            base(sfSprite_copy(copy.CPointer))
        {
            Origin = copy.Origin;
            Position = copy.Position;
            Rotation = copy.Rotation;
            Scale = copy.Scale;
            Texture = copy.Texture;
        }

        
        /// <summary>
        /// Global color of the object
        /// </summary>
        
        public Color Color
        {
            get { return sfSprite_getColor(CPointer); }
            set { sfSprite_setColor(CPointer, value); }
        }

        
        /// <summary>
        /// Source texture displayed by the sprite
        /// </summary>
        
        public Texture Texture
        {
            get { return myTexture; }
            set { myTexture = value; sfSprite_setTexture(CPointer, value != null ? value.CPointer : IntPtr.Zero, false); }
        }

        
        /// <summary>
        /// Sub-rectangle of the source image displayed by the sprite
        /// </summary>
        
        public IntRect TextureRect
        {
            get { return sfSprite_getTextureRect(CPointer); }
            set { sfSprite_setTextureRect(CPointer, value); }
        }

        
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
            return sfSprite_getLocalBounds(CPointer);
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
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString() => $"[Sprite] Color({Color}) Texture({Texture}) TextureRect({TextureRect})";

        
        /// <summary>
        /// Draw the sprite to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        
        public void Draw(IRenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawSprite(( (RenderWindow)target ).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawSprite(( (RenderTexture)target ).CPointer, CPointer, ref marshaledStates);
            }
        }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            sfSprite_destroy(CPointer);
        }

        /// <summary>
        /// The my texture
        /// </summary>
        private Texture myTexture = null;

        #region Imports

        /// <summary>
        /// Sfs the sprite create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSprite_create();

        /// <summary>
        /// Sfs the sprite copy using the specified sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfSprite_copy(IntPtr sprite);

        /// <summary>
        /// Sfs the sprite destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfSprite_destroy(IntPtr cPointer);

        /// <summary>
        /// Sfs the sprite set color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="color">The color</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfSprite_setColor(IntPtr cPointer, Color color);

        /// <summary>
        /// Sfs the sprite get color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Color sfSprite_getColor(IntPtr cPointer);

        /// <summary>
        /// Sfs the render window draw sprite using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="sprite">The sprite</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderWindow_drawSprite(IntPtr cPointer, IntPtr sprite, ref RenderStates.MarshalData states);

        /// <summary>
        /// Sfs the render texture draw sprite using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="sprite">The sprite</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderTexture_drawSprite(IntPtr cPointer, IntPtr sprite, ref RenderStates.MarshalData states);

        /// <summary>
        /// Sfs the sprite set texture using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="texture">The texture</param>
        /// <param name="adjustToNewSize">The adjust to new size</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfSprite_setTexture(IntPtr cPointer, IntPtr texture, bool adjustToNewSize);

        /// <summary>
        /// Sfs the sprite set texture rect using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="rect">The rect</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfSprite_setTextureRect(IntPtr cPointer, IntRect rect);

        /// <summary>
        /// Sfs the sprite get texture rect using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntRect sfSprite_getTextureRect(IntPtr cPointer);

        /// <summary>
        /// Sfs the sprite get local bounds using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern FloatRect sfSprite_getLocalBounds(IntPtr cPointer);
        #endregion
    }
}
