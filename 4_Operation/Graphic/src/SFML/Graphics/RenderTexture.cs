// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderTexture.cs
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
using Alis.Core.Graphic.SFML.Windows;

namespace Alis.Core.Graphic.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Target for off-screen 2D rendering into an texture
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class RenderTexture : ObjectBase, IRenderTarget
    {
        /// <summary>
        ///     The my default view
        /// </summary>
        private readonly View myDefaultView;

        /// <summary>
        ///     The my texture
        /// </summary>
        private readonly Texture myTexture;

        /*public RenderTexture(uint width, uint height) :
            this(width, height, false)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the render-texture with the given dimensions and
        ///     an optional depth-buffer attached
        /// </summary>
        /// <param name="width">Width of the render-texture</param>
        /// <param name="height">Height of the render-texture</param>
        /// <param name="depthBuffer">Do you want a depth-buffer attached?</param>
        ////////////////////////////////////////////////////////////
        [Obsolete(
            "Creating a RenderTexture with depthBuffer is deprecated. Use RenderTexture(width, height, contextSettings) instead.")]
        public RenderTexture(uint width, uint height, bool depthBuffer) :
            base(sfRenderTexture_create(width, height, depthBuffer))
        {
            myDefaultView = new View(sfRenderTexture_getDefaultView(CPointer));
            myTexture = new Texture(sfRenderTexture_getTexture(CPointer));
            GC.SuppressFinalize(myDefaultView);
            GC.SuppressFinalize(myTexture);
        }*/

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the render-texture with the given dimensions and
        ///     a ContextSettings.
        /// </summary>
        /// <param name="width">Width of the render-texture</param>
        /// <param name="height">Height of the render-texture</param>
        /// <param name="contextSettings"></param>
        ////////////////////////////////////////////////////////////
        public RenderTexture(uint width, uint height, ContextSettings contextSettings) :
            base(sfRenderTexture_createWithSettings(width, height, contextSettings))
        {
            myDefaultView = new View(sfRenderTexture_getDefaultView(CPointer));
            myTexture = new Texture(sfRenderTexture_getTexture(CPointer));
            GC.SuppressFinalize(myDefaultView);
            GC.SuppressFinalize(myTexture);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Enable or disable texture repeating
        /// </summary>
        /// <remarks>
        ///     This property is similar to <see />.
        ///     This parameter is disabled by default.
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public bool Repeated
        {
            get => sfRenderTexture_isRepeated(CPointer);
            set => sfRenderTexture_setRepeated(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Target texture of the render texture
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Texture Texture => myTexture;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The maximum anti-aliasing level supported by the system
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static uint MaximumAntialiasingLevel => sfRenderTexture_getMaximumAntialiasingLevel();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Control the smooth filter
        /// </summary>
        ////////////////////////////////////////////////////////////
        public bool Smooth
        {
            get => sfRenderTexture_isSmooth(CPointer);
            set => sfRenderTexture_setSmooth(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Size of the rendering region of the render texture
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2U Size => sfRenderTexture_getSize(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default view of the render texture
        /// </summary>
        ////////////////////////////////////////////////////////////
        public View DefaultView => new View(myDefaultView);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Return the current active view
        /// </summary>
        /// <returns>The current view</returns>
        ////////////////////////////////////////////////////////////
        public View GetView() => new View(sfRenderTexture_getView(CPointer));

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the current active view
        /// </summary>
        /// <param name="view">New view</param>
        ////////////////////////////////////////////////////////////
        public void SetView(View view)
        {
            sfRenderTexture_setView(CPointer, view.CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the viewport of a view applied to this target
        /// </summary>
        /// <param name="view">Target view</param>
        /// <returns>Viewport rectangle, expressed in pixels in the current target</returns>
        ////////////////////////////////////////////////////////////
        public RectangleI GetViewport(View view) => sfRenderTexture_getViewport(CPointer, view.CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Convert a point from target coordinates to world
        ///     coordinates, using the current view
        ///     This function is an overload of the MapPixelToCoords
        ///     function that implicitly uses the current view.
        ///     It is equivalent to:
        ///     target.MapPixelToCoords(point, target.GetView());
        /// </summary>
        /// <param name="point">Pixel to convert</param>
        /// <returns>The converted point, in "world" coordinates</returns>
        ////////////////////////////////////////////////////////////
        public Vector2F MapPixelToCoords(Vector2I point) => MapPixelToCoords(point, GetView());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Convert a point from target coordinates to world coordinates
        ///     This function finds the 2D position that matches the
        ///     given pixel of the render-target. In other words, it does
        ///     the inverse of what the graphics card does, to find the
        ///     initial position of a rendered pixel.
        ///     Initially, both coordinate systems (world units and target pixels)
        ///     match perfectly. But if you define a custom view or resize your
        ///     render-target, this assertion is not true anymore, ie. a point
        ///     located at (10, 50) in your render-target may map to the point
        ///     (150, 75) in your 2D world -- if the view is translated by (140, 25).
        ///     For render-windows, this function is typically used to find
        ///     which point (or object) is located below the mouse cursor.
        ///     This version uses a custom view for calculations, see the other
        ///     overload of the function if you want to use the current view of the
        ///     render-target.
        /// </summary>
        /// <param name="point">Pixel to convert</param>
        /// <param name="view">The view to use for converting the point</param>
        /// <returns>The converted point, in "world" coordinates</returns>
        ////////////////////////////////////////////////////////////
        public Vector2F MapPixelToCoords(Vector2I point, View view) => sfRenderTexture_mapPixelToCoords(CPointer, point, view != null ? view.CPointer : IntPtr.Zero);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Convert a point from world coordinates to target
        ///     coordinates, using the current view
        ///     This function is an overload of the mapCoordsToPixel
        ///     function that implicitly uses the current view.
        ///     It is equivalent to:
        ///     target.MapCoordsToPixel(point, target.GetView());
        /// </summary>
        /// <param name="point">Point to convert</param>
        /// <returns>The converted point, in target coordinates (pixels)</returns>
        ////////////////////////////////////////////////////////////
        public Vector2I MapCoordsToPixel(Vector2F point) => MapCoordsToPixel(point, GetView());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Convert a point from world coordinates to target coordinates
        ///     This function finds the pixel of the render-target that matches
        ///     the given 2D point. In other words, it goes through the same process
        ///     as the graphics card, to compute the final position of a rendered point.
        ///     Initially, both coordinate systems (world units and target pixels)
        ///     match perfectly. But if you define a custom view or resize your
        ///     render-target, this assertion is not true anymore, ie. a point
        ///     located at (150, 75) in your 2D world may map to the pixel
        ///     (10, 50) of your render-target -- if the view is translated by (140, 25).
        ///     This version uses a custom view for calculations, see the other
        ///     overload of the function if you want to use the current view of the
        ///     render-target.
        /// </summary>
        /// <param name="point">Point to convert</param>
        /// <param name="view">The view to use for converting the point</param>
        /// <returns>The converted point, in target coordinates (pixels)</returns>
        ////////////////////////////////////////////////////////////
        public Vector2I MapCoordsToPixel(Vector2F point, View view) => sfRenderTexture_mapCoordsToPixel(CPointer, point, view != null ? view.CPointer : IntPtr.Zero);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Clear the entire render texture with black color
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Clear()
        {
            sfRenderTexture_clear(CPointer, Color.Black);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Clear the entire render texture with a single color
        /// </summary>
        /// <param name="color">Color to use to clear the texture</param>
        ////////////////////////////////////////////////////////////
        public void Clear(Color color)
        {
            sfRenderTexture_clear(CPointer, color);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw a drawable object to the render-target, with default render states
        /// </summary>
        /// <param name="drawable">Object to draw</param>
        ////////////////////////////////////////////////////////////
        public void Draw(IDrawable drawable)
        {
            Draw(drawable, RenderStates.Default);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw a drawable object to the render-target
        /// </summary>
        /// <param name="drawable">Object to draw</param>
        /// <param name="states">Render states to use for drawing</param>
        ////////////////////////////////////////////////////////////
        public void Draw(IDrawable drawable, RenderStates states)
        {
            drawable.Draw(this, states);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw primitives defined by an array of vertices, with default render states
        /// </summary>
        /// <param name="vertices">Pointer to the vertices</param>
        /// <param name="type">Type of primitives to draw</param>
        ////////////////////////////////////////////////////////////
        public void Draw(Vertex[] vertices, PrimitiveType type)
        {
            Draw(vertices, type, RenderStates.Default);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw primitives defined by an array of vertices
        /// </summary>
        /// <param name="vertices">Pointer to the vertices</param>
        /// <param name="type">Type of primitives to draw</param>
        /// <param name="states">Render states to use for drawing</param>
        ////////////////////////////////////////////////////////////
        public void Draw(Vertex[] vertices, PrimitiveType type, RenderStates states)
        {
            Draw(vertices, 0, (uint) vertices.Length, type, states);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw primitives defined by a sub-array of vertices, with default render states
        /// </summary>
        /// <param name="vertices">Array of vertices to draw</param>
        /// <param name="start">Index of the first vertex to draw in the array</param>
        /// <param name="count">Number of vertices to draw</param>
        /// <param name="type">Type of primitives to draw</param>
        ////////////////////////////////////////////////////////////
        public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type)
        {
            Draw(vertices, start, count, type, RenderStates.Default);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw primitives defined by a sub-array of vertices
        /// </summary>
        /// <param name="vertices">Pointer to the vertices</param>
        /// <param name="start">Index of the first vertex to use in the array</param>
        /// <param name="count">Number of vertices to draw</param>
        /// <param name="type">Type of primitives to draw</param>
        /// <param name="states">Render states to use for drawing</param>
        ////////////////////////////////////////////////////////////
        public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type, RenderStates states)
        {
            RenderStates.MarshalData marshaledStates = states.Marshal();

            unsafe
            {
                fixed (Vertex* vertexPtr = vertices)
                {
                    sfRenderTexture_drawPrimitives(CPointer, vertexPtr + start, count, type, ref marshaledStates);
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Save the current OpenGL render states and matrices.
        ///     This function can be used when you mix SFML drawing
        ///     and direct OpenGL rendering. Combined with PopGLStates,
        ///     it ensures that:
        ///     \li SFML's internal states are not messed up by your OpenGL code
        ///     \li your OpenGL states are not modified by a call to a SFML function
        ///     More specifically, it must be used around code that
        ///     calls Draw functions. Example:
        ///     // OpenGL code here...
        ///     window.PushGLStates();
        ///     window.Draw(...);
        ///     window.Draw(...);
        ///     window.PopGLStates();
        ///     // OpenGL code here...
        ///     Note that this function is quite expensive: it saves all the
        ///     possible OpenGL states and matrices, even the ones you
        ///     don't care about. Therefore it should be used wisely.
        ///     It is provided for convenience, but the best results will
        ///     be achieved if you handle OpenGL states yourself (because
        ///     you know which states have really changed, and need to be
        ///     saved and restored). Take a look at the ResetGLStates
        ///     function if you do so.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void PushGlStates()
        {
            sfRenderTexture_pushGLStates(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Restore the previously saved OpenGL render states and matrices.
        ///     See the description of PushGLStates to get a detailed
        ///     description of these functions.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void PopGlStates()
        {
            sfRenderTexture_popGLStates(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Reset the internal OpenGL states so that the target is ready for drawing.
        ///     This function can be used when you mix SFML drawing
        ///     and direct OpenGL rendering, if you choose not to use
        ///     PushGLStates/PopGLStates. It makes sure that all OpenGL
        ///     states needed by SFML are set, so that subsequent Draw()
        ///     calls will work as expected.
        ///     Example:
        ///     // OpenGL code here...
        ///     glPushAttrib(...);
        ///     window.ResetGLStates();
        ///     window.Draw(...);
        ///     window.Draw(...);
        ///     glPopAttrib(...);
        ///     // OpenGL code here...
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void ResetGlStates()
        {
            sfRenderTexture_resetGLStates(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Activate of deactivate the render texture as the current target
        ///     for rendering
        /// </summary>
        /// <param name="active">True to activate, false to deactivate (true by default)</param>
        /// <returns>True if operation was successful, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public bool SetActive(bool active) => sfRenderTexture_setActive(CPointer, active);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Generate a mipmap using the current texture data
        /// </summary>
        /// <remarks>
        ///     This function is similar to <see /> and operates
        ///     on the texture used as the target for drawing.
        ///     Be aware that any draw operation may modify the base level image data.
        ///     For this reason, calling this function only makes sense after all
        ///     drawing is completed and display has been called. Not calling display
        ///     after subsequent drawing will lead to undefined behavior if a mipmap
        ///     had been previously generated.
        /// </remarks>
        /// <returns>True if mipmap generation was successful, false if unsuccessful</returns>
        ////////////////////////////////////////////////////////////
        public bool GenerateMipmap() => sfRenderTexture_generateMipmap(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Update the contents of the target texture
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Display()
        {
            sfRenderTexture_display(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[RenderTexture]" +
                                             " Size(" + Size + ")" +
                                             " Texture(" + Texture + ")" +
                                             " DefaultView(" + DefaultView + ")" +
                                             " View(" + GetView() + ")";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            if (!disposing)
            {
                Context.Global.SetActive(true);
            }

            sfRenderTexture_destroy(CPointer);

            if (disposing)
            {
                myDefaultView.Dispose();
                myTexture.Dispose();
            }

            if (!disposing)
            {
                Context.Global.SetActive(false);
            }
        }

        /// <summary>
        ///     Sfs the render texture create using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depthBuffer">The depth buffer</param>
        /// <returns>The int ptr</returns>
        [Obsolete("sfRenderTexture_create is obselete. Use sfRenderTexture_createWithSettings instead."), DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderTexture_create(uint width, uint height, bool depthBuffer);

        /// <summary>
        ///     Sfs the render texture create with settings using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="settings">The settings</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderTexture_createWithSettings(uint width, uint height,
            ContextSettings settings);

        /// <summary>
        ///     Sfs the render texture destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_destroy(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture clear using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="clearColor">The clear color</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_clear(IntPtr cPointer, Color clearColor);

        /// <summary>
        ///     Sfs the render texture get size using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2u</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2U sfRenderTexture_getSize(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render texture set active
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="active">The active</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderTexture_setActive(IntPtr cPointer, bool active);

        /// <summary>
        ///     Describes whether sf render texture save gl states
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderTexture_saveGLStates(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render texture restore gl states
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderTexture_restoreGLStates(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render texture display
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderTexture_display(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture set view using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="view">The view</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_setView(IntPtr cPointer, IntPtr view);

        /// <summary>
        ///     Sfs the render texture get view using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderTexture_getView(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture get default view using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderTexture_getDefaultView(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture get viewport using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="targetView">The target view</param>
        /// <returns>The int rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleI sfRenderTexture_getViewport(IntPtr cPointer, IntPtr targetView);

        /// <summary>
        ///     Sfs the render texture map coords to pixel using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="point">The point</param>
        /// <param name="view">The view</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfRenderTexture_mapCoordsToPixel(IntPtr cPointer, Vector2F point, IntPtr view);

        /// <summary>
        ///     Sfs the render texture map pixel to coords using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="point">The point</param>
        /// <param name="view">The view</param>
        /// <returns>The vector 2f</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2F sfRenderTexture_mapPixelToCoords(IntPtr cPointer, Vector2I point, IntPtr view);

        /// <summary>
        ///     Sfs the render texture get texture using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderTexture_getTexture(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture get maximum antialiasing level
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfRenderTexture_getMaximumAntialiasingLevel();

        /// <summary>
        ///     Sfs the render texture set smooth using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="smooth">The smooth</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_setSmooth(IntPtr cPointer, bool smooth);

        /// <summary>
        ///     Describes whether sf render texture is smooth
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderTexture_isSmooth(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture set repeated using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="repeated">The repeated</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_setRepeated(IntPtr cPointer, bool repeated);

        /// <summary>
        ///     Describes whether sf render texture is repeated
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderTexture_isRepeated(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render texture generate mipmap
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderTexture_generateMipmap(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture draw primitives using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertexPtr">The vertex ptr</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="type">The type</param>
        /// <param name="renderStates">The render states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe void sfRenderTexture_drawPrimitives(IntPtr cPointer, Vertex* vertexPtr,
            uint vertexCount, PrimitiveType type, ref RenderStates.MarshalData renderStates);

        /// <summary>
        ///     Sfs the render texture push gl states using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_pushGLStates(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture pop gl states using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_popGLStates(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render texture reset gl states using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_resetGLStates(IntPtr cPointer);
    }
}