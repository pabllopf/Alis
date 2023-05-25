// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderWindow.cs
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
using System.Text;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Math.Figures.D2.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.SFML.Windows;

namespace Alis.Core.Graphic.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Simple wrapper for Window that allows easy
    ///     2D rendering
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class RenderWindow : Window, IRenderTarget
    {
        /// <summary>
        ///     The my default view
        /// </summary>
        private View myDefaultView;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the window with default style and creation settings
        /// </summary>
        /// <param name="mode">Video mode to use</param>
        /// <param name="title">Title of the window</param>
        ////////////////////////////////////////////////////////////
        public RenderWindow(VideoMode mode, string title) :
            this(mode, title, Styles.Default, new ContextSettings(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the window with default creation settings
        /// </summary>
        /// <param name="mode">Video mode to use</param>
        /// <param name="title">Title of the window</param>
        /// <param name="style">Window style (Resize | Close by default)</param>
        ////////////////////////////////////////////////////////////
        public RenderWindow(VideoMode mode, string title, Styles style) :
            this(mode, title, style, new ContextSettings(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the window
        /// </summary>
        /// <param name="mode">Video mode to use</param>
        /// <param name="title">Title of the window</param>
        /// <param name="style">Window style (Resize | Close by default)</param>
        /// <param name="settings">Creation parameters</param>
        ////////////////////////////////////////////////////////////
        public RenderWindow(VideoMode mode, string title, Styles style, ContextSettings settings) :
            base(IntPtr.Zero, 0)
        {
            // Copy the string to a null-terminated UTF-32 byte array
            byte[] titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

            unsafe
            {
                fixed (byte* titlePtr = titleAsUtf32)
                {
                    CPointer = sfRenderWindow_createUnicode(mode, (IntPtr) titlePtr, style, ref settings);
                }
            }

            Initialize();
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the window from an existing control with default creation settings
        /// </summary>
        /// <param name="handle">Platform-specific handle of the control</param>
        ////////////////////////////////////////////////////////////
        public RenderWindow(IntPtr handle) :
            this(handle, new ContextSettings(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the window from an existing control
        /// </summary>
        /// <param name="handle">Platform-specific handle of the control</param>
        /// <param name="settings">Creation parameters</param>
        ////////////////////////////////////////////////////////////
        public RenderWindow(IntPtr handle, ContextSettings settings) :
            base(sfRenderWindow_createFromHandle(handle, ref settings), 0)
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Tell whether or not the window is opened (ie. has been created).
        ///     Note that a hidden window (Show(false))
        ///     will still return true
        /// </summary>
        /// <returns>True if the window is opened</returns>
        ////////////////////////////////////////////////////////////
        public override bool IsOpen => sfRenderWindow_isOpen(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Creation settings of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public override ContextSettings Settings => sfRenderWindow_getSettings(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Position of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public override Vector2I Position
        {
            get => sfRenderWindow_getPosition(CPointer);
            set => sfRenderWindow_setPosition(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     OS-specific handle of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public override IntPtr SystemHandle => sfRenderWindow_getSystemHandle(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Size of the rendering region of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public override Vector2U Size
        {
            get => sfRenderWindow_getSize(CPointer);
            set => sfRenderWindow_setSize(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Clear the entire window with black color
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Clear()
        {
            sfRenderWindow_clear(CPointer, Color.Black);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Clear the entire window with a single color
        /// </summary>
        /// <param name="color">Color to use to clear the window</param>
        ////////////////////////////////////////////////////////////
        public void Clear(Color color)
        {
            sfRenderWindow_clear(CPointer, color);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the current active view
        /// </summary>
        /// <param name="view">New view</param>
        ////////////////////////////////////////////////////////////
        public void SetView(View view)
        {
            sfRenderWindow_setView(CPointer, view.CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Return the current active view
        /// </summary>
        /// <returns>The current view</returns>
        ////////////////////////////////////////////////////////////
        public View GetView() => new View(sfRenderWindow_getView(CPointer));

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default view of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public View DefaultView => new View(myDefaultView);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the viewport of a view applied to this target
        /// </summary>
        /// <param name="view">Target view</param>
        /// <returns>Viewport rectangle, expressed in pixels in the current target</returns>
        ////////////////////////////////////////////////////////////
        public RectangleI GetViewport(View view) => sfRenderWindow_getViewport(CPointer, view.CPointer);

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
        public Vector2F MapPixelToCoords(Vector2I point, View view) => sfRenderWindow_mapPixelToCoords(CPointer, point, view != null ? view.CPointer : IntPtr.Zero);

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
        public Vector2I MapCoordsToPixel(Vector2F point, View view) => sfRenderWindow_mapCoordsToPixel(CPointer, point, view != null ? view.CPointer : IntPtr.Zero);

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
                    sfRenderWindow_drawPrimitives(CPointer, vertexPtr + start, count, type, ref marshaledStates);
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Save the current OpenGL render states and matrices.
        /// </summary>
        /// <example>
        ///     // OpenGL code here...
        ///     window.PushGLStates();
        ///     window.Draw(...);
        ///     window.Draw(...);
        ///     window.PopGLStates();
        ///     // OpenGL code here...
        /// </example>
        /// <remarks>
        ///     <para>
        ///         This function can be used when you mix SFML drawing
        ///         and direct OpenGL rendering. Combined with PopGLStates,
        ///         it ensures that:
        ///     </para>
        ///     <para>SFML's internal states are not messed up by your OpenGL code</para>
        ///     <para>Your OpenGL states are not modified by a call to a SFML function</para>
        ///     <para>
        ///         More specifically, it must be used around code that
        ///         calls Draw functions.
        ///     </para>
        ///     <para>
        ///         Note that this function is quite expensive: it saves all the
        ///         possible OpenGL states and matrices, even the ones you
        ///         don't care about. Therefore it should be used wisely.
        ///         It is provided for convenience, but the best results will
        ///         be achieved if you handle OpenGL states yourself (because
        ///         you know which states have really changed, and need to be
        ///         saved and restored). Take a look at the <seealso cref="ResetGlStates" />
        ///         function if you do so.
        ///     </para>
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public void PushGlStates()
        {
            sfRenderWindow_pushGLStates(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Restore the previously saved OpenGL render states and matrices.
        ///     See the description of <seealso cref="PushGlStates" /> to get a detailed
        ///     description of these functions.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void PopGlStates()
        {
            sfRenderWindow_popGLStates(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Reset the internal OpenGL states so that the target is ready for drawing.
        /// </summary>
        /// <remarks>
        ///     This function can be used when you mix SFML drawing
        ///     and direct OpenGL rendering, if you choose not to use
        ///     PushGLStates/PopGLStates. It makes sure that all OpenGL
        ///     states needed by SFML are set, so that subsequent Draw()
        ///     calls will work as expected.
        /// </remarks>
        /// <example>
        ///     // OpenGL code here...
        ///     glPushAttrib(...);
        ///     window.ResetGLStates();
        ///     window.Draw(...);
        ///     window.Draw(...);
        ///     glPopAttrib(...);
        ///     // OpenGL code here...
        /// </example>
        ////////////////////////////////////////////////////////////
        public void ResetGlStates()
        {
            sfRenderWindow_resetGLStates(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Close (destroy) the window.
        ///     The Window instance remains valid and you can call
        ///     Create to recreate the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public override void Close()
        {
            sfRenderWindow_close(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the title of the window
        /// </summary>
        /// <param name="title">New title</param>
        ////////////////////////////////////////////////////////////
        public override void SetTitle(string title)
        {
            // Copy the title to a null-terminated UTF-32 byte array
            byte[] titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

            unsafe
            {
                fixed (byte* titlePtr = titleAsUtf32)
                {
                    sfRenderWindow_setUnicodeTitle(CPointer, (IntPtr) titlePtr);
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the window's icon
        /// </summary>
        /// <param name="width">Icon's width, in pixels</param>
        /// <param name="height">Icon's height, in pixels</param>
        /// <param name="pixels">Array of pixels, format must be RGBA 32 bits</param>
        ////////////////////////////////////////////////////////////
        public override void SetIcon(uint width, uint height, byte[] pixels)
        {
            unsafe
            {
                fixed (byte* pixelsPtr = pixels)
                {
                    sfRenderWindow_setIcon(CPointer, width, height, pixelsPtr);
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Show or hide the window
        /// </summary>
        /// <param name="visible">True to show the window, false to hide it</param>
        ////////////////////////////////////////////////////////////
        public override void SetVisible(bool visible)
        {
            sfRenderWindow_setVisible(CPointer, visible);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Enable / disable vertical synchronization
        /// </summary>
        /// <param name="enable">True to enable v-sync, false to deactivate</param>
        ////////////////////////////////////////////////////////////
        public override void SetVerticalSyncEnabled(bool enable)
        {
            sfRenderWindow_setVerticalSyncEnabled(CPointer, enable);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Show or hide the mouse cursor
        /// </summary>
        /// <param name="visible">True to show, false to hide</param>
        ////////////////////////////////////////////////////////////
        public override void SetMouseCursorVisible(bool visible)
        {
            sfRenderWindow_setMouseCursorVisible(CPointer, visible);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Grab or release the mouse cursor
        /// </summary>
        /// <param name="grabbed">True to grab, false to release</param>
        /// <remarks>
        ///     If set, grabs the mouse cursor inside this window's client
        ///     area so it may no longer be moved outside its bounds.
        ///     Note that grabbing is only active while the window has
        ///     focus and calling this function for fullscreen windows
        ///     won't have any effect (fullscreen windows always grab the
        ///     cursor).
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public override void SetMouseCursorGrabbed(bool grabbed)
        {
            sfRenderWindow_setMouseCursorGrabbed(CPointer, grabbed);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Set the displayed cursor to a native system cursor
        /// </summary>
        /// <param name="cursor">Native system cursor type to display</param>
        ////////////////////////////////////////////////////////////
        public override void SetMouseCursor(Cursor cursor)
        {
            sfRenderWindow_setMouseCursor(CPointer, cursor.CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Enable or disable automatic key-repeat.
        ///     Automatic key-repeat is enabled by default
        /// </summary>
        /// <param name="enable">True to enable, false to disable</param>
        ////////////////////////////////////////////////////////////
        public override void SetKeyRepeatEnabled(bool enable)
        {
            sfRenderWindow_setKeyRepeatEnabled(CPointer, enable);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Limit the framerate to a maximum fixed frequency
        /// </summary>
        /// <param name="limit">Framerate limit, in frames per seconds (use 0 to disable limit)</param>
        ////////////////////////////////////////////////////////////
        public override void SetFramerateLimit(uint limit)
        {
            sfRenderWindow_setFramerateLimit(CPointer, limit);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the joystick threshold, ie. the value below which
        ///     no move event will be generated
        /// </summary>
        /// <param name="threshold">New threshold, in range [0, 100]</param>
        ////////////////////////////////////////////////////////////
        public override void SetJoystickThreshold(float threshold)
        {
            sfRenderWindow_setJoystickThreshold(CPointer, threshold);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Activate of deactivate the window as the current target
        ///     for rendering
        /// </summary>
        /// <param name="active">True to activate, false to deactivate (true by default)</param>
        /// <returns>True if operation was successful, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public override bool SetActive(bool active) => sfRenderWindow_setActive(CPointer, active);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Request the current window to be made the active
        ///     foreground window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public override void RequestFocus()
        {
            sfRenderWindow_requestFocus(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check whether the window has the input focus
        /// </summary>
        /// <returns>True if the window has focus, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public override bool HasFocus() => sfRenderWindow_hasFocus(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Display the window on screen
        /// </summary>
        ////////////////////////////////////////////////////////////
        public override void Display()
        {
            sfRenderWindow_display(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Capture the current contents of the window into an image.
        /// </summary>
        /// <remarks>
        ///     Deprecated. Use <see cref="Texture" /> and <see cref="Texture.Update(RenderWindow)" />
        ///     instead:
        ///     <code>
        ///    Texture texture = new Texture(window.Size);
        ///    texture.update(window);
        ///    Image img = texture.CopyToImage();
        ///    </code>
        /// </remarks>
        ////////////////////////////////////////////////////////////
        [Obsolete("Capture is deprecated, please see remarks for preferred method")]
        public Image Capture() => new Image(sfRenderWindow_capture(CPointer));

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[RenderWindow]" +
                                             " Size(" + Size + ")" +
                                             " Position(" + Position + ")" +
                                             " Settings(" + Settings + ")" +
                                             " DefaultView(" + DefaultView + ")" +
                                             " View(" + GetView() + ")";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to get the next event
        /// </summary>
        /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
        /// <returns>True if there was an event, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        protected override bool PollEvent(out Event eventToFill) => sfRenderWindow_pollEvent(CPointer, out eventToFill);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to get the next event (blocking)
        /// </summary>
        /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
        /// <returns>False if any error occured</returns>
        ////////////////////////////////////////////////////////////
        protected override bool WaitEvent(out Event eventToFill) => sfRenderWindow_waitEvent(CPointer, out eventToFill);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to get the mouse position relative to the window.
        ///     This function is protected because it is called by another class,
        ///     it is not meant to be called by users.
        /// </summary>
        /// <returns>Relative mouse position</returns>
        ////////////////////////////////////////////////////////////
        public override Vector2I InternalGetMousePosition() => sfMouse_getPositionRenderWindow(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to set the mouse position relative to the window.
        ///     This function is protected because it is called by another class,
        ///     it is not meant to be called by users.
        /// </summary>
        /// <param name="position">Relative mouse position</param>
        ////////////////////////////////////////////////////////////
        protected internal override void InternalSetMousePosition(Vector2I position)
        {
            sfMouse_setPositionRenderWindow(position, CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to get the touch position relative to the window.
        ///     This function is protected because it is called by another class of
        ///     another module, it is not meant to be called by users.
        /// </summary>
        /// <param name="finger">Finger index</param>
        /// <returns>Relative touch position</returns>
        ////////////////////////////////////////////////////////////
        protected internal override Vector2I InternalGetTouchPosition(uint finger) => sfTouch_getPositionRenderWindow(finger, CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfRenderWindow_destroy(CPointer);

            if (disposing)
            {
                myDefaultView.Dispose();
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Do common initializations
        /// </summary>
        ////////////////////////////////////////////////////////////
        private void Initialize()
        {
            myDefaultView = new View(sfRenderWindow_getDefaultView(CPointer));
            GC.SuppressFinalize(myDefaultView);
        }

        /// <summary>
        ///     Sfs the render window create using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="title">The title</param>
        /// <param name="style">The style</param>
        /// <param name="params">The params</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderWindow_create(VideoMode mode, string title, Styles style,
            ref ContextSettings @params);

        /// <summary>
        ///     Sfs the render window create unicode using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="title">The title</param>
        /// <param name="style">The style</param>
        /// <param name="params">The params</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderWindow_createUnicode(VideoMode mode, IntPtr title, Styles style,
            ref ContextSettings @params);

        /// <summary>
        ///     Sfs the render window create from handle using the specified handle
        /// </summary>
        /// <param name="handle">The handle</param>
        /// <param name="params">The params</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderWindow_createFromHandle(IntPtr handle, ref ContextSettings @params);

        /// <summary>
        ///     Sfs the render window destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_destroy(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window close using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_close(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render window is open
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderWindow_isOpen(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window get settings using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The context settings</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern ContextSettings sfRenderWindow_getSettings(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render window poll event
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="evt">The evt</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderWindow_pollEvent(IntPtr cPointer, out Event evt);

        /// <summary>
        ///     Describes whether sf render window wait event
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="evt">The evt</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderWindow_waitEvent(IntPtr cPointer, out Event evt);

        /// <summary>
        ///     Sfs the render window get position using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfRenderWindow_getPosition(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window set position using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="position">The position</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setPosition(IntPtr cPointer, Vector2I position);

        /// <summary>
        ///     Sfs the render window get size using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2u</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2U sfRenderWindow_getSize(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window set size using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="size">The size</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setSize(IntPtr cPointer, Vector2U size);

        /// <summary>
        ///     Sfs the render window set title using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="title">The title</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setTitle(IntPtr cPointer, string title);

        /// <summary>
        ///     Sfs the render window set unicode title using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="title">The title</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setUnicodeTitle(IntPtr cPointer, IntPtr title);

        /// <summary>
        ///     Sfs the render window set icon using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="pixels">The pixels</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe void
            sfRenderWindow_setIcon(IntPtr cPointer, uint width, uint height, byte* pixels);

        /// <summary>
        ///     Sfs the render window set visible using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="visible">The visible</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setVisible(IntPtr cPointer, bool visible);

        /// <summary>
        ///     Sfs the render window set vertical sync enabled using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="enable">The enable</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setVerticalSyncEnabled(IntPtr cPointer, bool enable);

        /// <summary>
        ///     Sfs the render window set mouse cursor visible using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="visible">The visible</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setMouseCursorVisible(IntPtr cPointer, bool visible);

        /// <summary>
        ///     Sfs the render window set mouse cursor grabbed using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setMouseCursorGrabbed(IntPtr cPointer, bool grabbed);

        /// <summary>
        ///     Sfs the render window set mouse cursor using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="cursor">The cursor</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setMouseCursor(IntPtr window, IntPtr cursor);

        /// <summary>
        ///     Sfs the render window set key repeat enabled using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="enable">The enable</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setKeyRepeatEnabled(IntPtr cPointer, bool enable);

        /// <summary>
        ///     Sfs the render window set framerate limit using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="limit">The limit</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setFramerateLimit(IntPtr cPointer, uint limit);

        /// <summary>
        ///     Sfs the render window set joystick threshold using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="threshold">The threshold</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setJoystickThreshold(IntPtr cPointer, float threshold);

        /// <summary>
        ///     Describes whether sf render window set active
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="active">The active</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderWindow_setActive(IntPtr cPointer, bool active);

        /// <summary>
        ///     Sfs the render window request focus using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_requestFocus(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render window has focus
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderWindow_hasFocus(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window display using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_display(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window get system handle using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderWindow_getSystemHandle(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window clear using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="clearColor">The clear color</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_clear(IntPtr cPointer, Color clearColor);

        /// <summary>
        ///     Sfs the render window set view using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="view">The view</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_setView(IntPtr cPointer, IntPtr view);

        /// <summary>
        ///     Sfs the render window get view using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderWindow_getView(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window get default view using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderWindow_getDefaultView(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window get viewport using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="targetView">The target view</param>
        /// <returns>The int rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleI sfRenderWindow_getViewport(IntPtr cPointer, IntPtr targetView);

        /// <summary>
        ///     Sfs the render window map pixel to coords using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="point">The point</param>
        /// <param name="view">The view</param>
        /// <returns>The vector 2f</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2F sfRenderWindow_mapPixelToCoords(IntPtr cPointer, Vector2I point, IntPtr view);

        /// <summary>
        ///     Sfs the render window map coords to pixel using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="point">The point</param>
        /// <param name="view">The view</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfRenderWindow_mapCoordsToPixel(IntPtr cPointer, Vector2F point, IntPtr view);

        /// <summary>
        ///     Sfs the render window draw primitives using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertexPtr">The vertex ptr</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="type">The type</param>
        /// <param name="renderStates">The render states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe void sfRenderWindow_drawPrimitives(IntPtr cPointer, Vertex* vertexPtr,
            uint vertexCount, PrimitiveType type, ref RenderStates.MarshalData renderStates);

        /// <summary>
        ///     Sfs the render window push gl states using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_pushGLStates(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window pop gl states using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_popGLStates(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window reset gl states using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_resetGLStates(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window capture using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfRenderWindow_capture(IntPtr cPointer);

        /// <summary>
        ///     Sfs the mouse get position render window using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfMouse_getPositionRenderWindow(IntPtr cPointer);

        /// <summary>
        ///     Sfs the mouse set position render window using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMouse_setPositionRenderWindow(Vector2I position, IntPtr cPointer);

        /// <summary>
        ///     Sfs the touch get position render window using the specified finger
        /// </summary>
        /// <param name="finger">The finger</param>
        /// <param name="relativeTo">The relative to</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfTouch_getPositionRenderWindow(uint finger, IntPtr relativeTo);

        /// <summary>
        ///     Describes whether sf render window save gl states
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderWindow_saveGLStates(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf render window restore gl states
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfRenderWindow_restoreGLStates(IntPtr cPointer);

        /// <summary>
        ///     Sfs the render window get frame time using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfRenderWindow_getFrameTime(IntPtr cPointer);
    }
}