// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sprite.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Figures.D2.Rectangle;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     This class defines a sprite : texture, transformations,
    ///     color, and draw on screen
    /// </summary>
    /// <remarks>
    ///     See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public class Sprite : Transformable, IDrawable
    {
        /// <summary>
        ///     The my texture
        /// </summary>
        private Texture myTexture;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Sprite() :
            base(sfSprite_create())
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the sprite from a source texture
        /// </summary>
        /// <param name="texture">Source texture to assign to the sprite</param>
        ////////////////////////////////////////////////////////////
        public Sprite(Texture texture) :
            base(sfSprite_create())
            => Texture = texture;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the sprite from a source texture
        /// </summary>
        /// <param name="texture">Source texture to assign to the sprite</param>
        /// <param name="rectangle">Sub-rectangle of the texture to assign to the sprite</param>
        ////////////////////////////////////////////////////////////
        public Sprite(Texture texture, RectangleI rectangle) :
            base(sfSprite_create())
        {
            Texture = texture;
            TextureRect = rectangle;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the sprite from another sprite
        /// </summary>
        /// <param name="copy">Sprite to copy</param>
        ////////////////////////////////////////////////////////////
        public Sprite(Sprite copy) :
            base(sfSprite_copy(copy.CPointer))
        {
            Origin = copy.Origin;
            Position = copy.Position;
            Rotation = copy.Rotation;
            Scale = copy.Scale;
            Texture = copy.Texture;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Global color of the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Color Color
        {
            get => sfSprite_getColor(CPointer);
            set => sfSprite_setColor(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Source texture displayed by the sprite
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Texture Texture
        {
            get => myTexture;
            set
            {
                myTexture = value;
                sfSprite_setTexture(CPointer, value != null ? value.CPointer : IntPtr.Zero, false);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Sub-rectangle of the source image displayed by the sprite
        /// </summary>
        ////////////////////////////////////////////////////////////
        public RectangleI TextureRect
        {
            get => sfSprite_getTextureRect(CPointer);
            set => sfSprite_setTextureRect(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw the sprite to a render target
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
                sfRenderWindow_drawSprite(((RenderWindow) target).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawSprite(((RenderTexture) target).CPointer, CPointer, ref marshaledStates);
            }
        }

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
        public RectangleF GetLocalBounds() => sfSprite_getLocalBounds(CPointer);

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
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Sprite] Color({Color}) Texture({Texture}) TextureRect({TextureRect})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfSprite_destroy(CPointer);
        }

        /// <summary>
        ///     Sfs the sprite create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSprite_create();

        /// <summary>
        ///     Sfs the sprite copy using the specified sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfSprite_copy(IntPtr sprite);

        /// <summary>
        ///     Sfs the sprite destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSprite_destroy(IntPtr cPointer);

        /// <summary>
        ///     Sfs the sprite set color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="color">The color</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSprite_setColor(IntPtr cPointer, Color color);

        /// <summary>
        ///     Sfs the sprite get color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Color sfSprite_getColor(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window draw sprite using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="sprite">The sprite</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_drawSprite(IntPtr cPointer, IntPtr sprite,
            ref RenderStates.MarshalData states);

        /// <summary>
        ///     Sfs the render texture draw sprite using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="sprite">The sprite</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_drawSprite(IntPtr cPointer, IntPtr sprite,
            ref RenderStates.MarshalData states);

        /// <summary>
        ///     Sfs the sprite set texture using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="texture">The texture</param>
        /// <param name="adjustToNewSize">The adjust to new size</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSprite_setTexture(IntPtr cPointer, IntPtr texture, bool adjustToNewSize);

        /// <summary>
        ///     Sfs the sprite set texture rect using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="rect">The rect</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfSprite_setTextureRect(IntPtr cPointer, RectangleI rect);

        /// <summary>
        ///     Sfs the sprite get texture rect using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleI sfSprite_getTextureRect(IntPtr cPointer);

        /// <summary>
        ///     Sfs the sprite get local bounds using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleF sfSprite_getLocalBounds(IntPtr cPointer);
    }
}