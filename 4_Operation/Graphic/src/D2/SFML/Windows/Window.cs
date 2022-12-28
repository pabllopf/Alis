// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Window.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Window is a rendering window ; it can create a new window
    ///     or connect to an existing one
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Window : ObjectBase
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the window with default style and creation settings
        /// </summary>
        /// <param name="mode">Video mode to use</param>
        /// <param name="title">Title of the window</param>
        ////////////////////////////////////////////////////////////
        public Window(VideoMode mode, string title) :
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
        public Window(VideoMode mode, string title, Styles style) :
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
        public Window(VideoMode mode, string title, Styles style, ContextSettings settings) :
            base(IntPtr.Zero)
        {
            // Copy the title to a null-terminated UTF-32 byte array
            byte[] titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

            unsafe
            {
                fixed (byte* titlePtr = titleAsUtf32)
                {
                    CPointer = sfWindow_createUnicode(mode, (IntPtr) titlePtr, style, ref settings);
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create the window from an existing control with default creation settings
        /// </summary>
        /// <param name="handle">Platform-specific handle of the control</param>
        ////////////////////////////////////////////////////////////
        public Window(IntPtr handle) :
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
        public Window(IntPtr handle, ContextSettings settings) :
            base(sfWindow_createFromHandle(handle, ref settings))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Constructor for derived classes
        /// </summary>
        /// <param name="cPointer">Pointer to the internal object in the C API</param>
        /// <param name="dummy">Internal hack :)</param>
        ////////////////////////////////////////////////////////////
        protected Window(IntPtr cPointer, int dummy) :
            base(cPointer)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Tell whether or not the window is opened (ie. has been created).
        ///     Note that a hidden window (Show(false))
        ///     will still return true
        /// </summary>
        /// <returns>True if the window is opened</returns>
        ////////////////////////////////////////////////////////////
        public virtual bool IsOpen => sfWindow_isOpen(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Creation settings of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual ContextSettings Settings => sfWindow_getSettings(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Position of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual Vector2I Position
        {
            get => sfWindow_getPosition(CPointer);
            set => sfWindow_setPosition(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Size of the rendering region of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual Vector2U Size
        {
            get => sfWindow_getSize(CPointer);
            set => sfWindow_setSize(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     OS-specific handle of the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual IntPtr SystemHandle => sfWindow_getSystemHandle(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Close (destroy) the window.
        ///     The Window instance remains valid and you can call
        ///     Create to recreate the window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual void Close()
        {
            sfWindow_close(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Display the window on screen
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual void Display()
        {
            sfWindow_display(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the title of the window
        /// </summary>
        /// <param name="title">New title</param>
        ////////////////////////////////////////////////////////////
        public virtual void SetTitle(string title)
        {
            // Copy the title to a null-terminated UTF-32 byte array
            byte[] titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

            unsafe
            {
                fixed (byte* titlePtr = titleAsUtf32)
                {
                    sfWindow_setUnicodeTitle(CPointer, (IntPtr) titlePtr);
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
        public virtual void SetIcon(uint width, uint height, byte[] pixels)
        {
            unsafe
            {
                fixed (byte* pixelsPtr = pixels)
                {
                    sfWindow_setIcon(CPointer, width, height, pixelsPtr);
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Show or hide the window
        /// </summary>
        /// <param name="visible">True to show the window, false to hide it</param>
        ////////////////////////////////////////////////////////////
        public virtual void SetVisible(bool visible)
        {
            sfWindow_setVisible(CPointer, visible);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Show or hide the mouse cursor
        /// </summary>
        /// <param name="show">True to show, false to hide</param>
        ////////////////////////////////////////////////////////////
        public virtual void SetMouseCursorVisible(bool show)
        {
            sfWindow_setMouseCursorVisible(CPointer, show);
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
        public virtual void SetMouseCursorGrabbed(bool grabbed)
        {
            sfWindow_setMouseCursorGrabbed(CPointer, grabbed);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Set the displayed cursor to a native system cursor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual void SetMouseCursor(Cursor cursor)
        {
            sfWindow_setMouseCursor(CPointer, cursor.CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Enable / disable vertical synchronization
        /// </summary>
        /// <param name="enable">True to enable v-sync, false to deactivate</param>
        ////////////////////////////////////////////////////////////
        public virtual void SetVerticalSyncEnabled(bool enable)
        {
            sfWindow_setVerticalSyncEnabled(CPointer, enable);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Enable or disable automatic key-repeat.
        ///     Automatic key-repeat is enabled by default
        /// </summary>
        /// <param name="enable">True to enable, false to disable</param>
        ////////////////////////////////////////////////////////////
        public virtual void SetKeyRepeatEnabled(bool enable)
        {
            sfWindow_setKeyRepeatEnabled(CPointer, enable);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Activate the window as the current target
        ///     for rendering
        /// </summary>
        /// <returns>True if operation was successful, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public virtual bool SetActive() => SetActive(true);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Activate of deactivate the window as the current target
        ///     for rendering
        /// </summary>
        /// <param name="active">True to activate, false to deactivate (true by default)</param>
        /// <returns>True if operation was successful, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public virtual bool SetActive(bool active) => sfWindow_setActive(CPointer, active);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Limit the framerate to a maximum fixed frequency
        /// </summary>
        /// <param name="limit">Framerate limit, in frames per seconds (use 0 to disable limit)</param>
        ////////////////////////////////////////////////////////////
        public virtual void SetFramerateLimit(uint limit)
        {
            sfWindow_setFramerateLimit(CPointer, limit);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the joystick threshold, ie. the value below which
        ///     no move event will be generated
        /// </summary>
        /// <param name="threshold">New threshold, in range [0, 100]</param>
        ////////////////////////////////////////////////////////////
        public virtual void SetJoystickThreshold(float threshold)
        {
            sfWindow_setJoystickThreshold(CPointer, threshold);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Wait for a new event and dispatch it to the corresponding
        ///     event handler
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void WaitAndDispatchEvents()
        {
            Event e;
            if (WaitEvent(out e))
            {
                CallEventHandler(e);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Call the event handlers for each pending event
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void DispatchEvents()
        {
            Event e;
            while (PollEvent(out e))
            {
                CallEventHandler(e);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Request the current window to be made the active
        ///     foreground window
        /// </summary>
        ////////////////////////////////////////////////////////////
        public virtual void RequestFocus()
        {
            sfWindow_requestFocus(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check whether the window has the input focus
        /// </summary>
        /// <returns>True if the window has focus, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public virtual bool HasFocus() => sfWindow_hasFocus(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[Window]" +
                                             " Size(" + Size + ")" +
                                             " Position(" + Position + ")" +
                                             " Settings(" + Settings + ")";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to get the next event (non-blocking)
        /// </summary>
        /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
        /// <returns>True if there was an event, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        protected virtual bool PollEvent(out Event eventToFill) => sfWindow_pollEvent(CPointer, out eventToFill);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to get the next event (blocking)
        /// </summary>
        /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
        /// <returns>False if any error occured</returns>
        ////////////////////////////////////////////////////////////
        protected virtual bool WaitEvent(out Event eventToFill) => sfWindow_waitEvent(CPointer, out eventToFill);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to get the mouse position relative to the window.
        ///     This function is protected because it is called by another class of
        ///     another module, it is not meant to be called by users.
        /// </summary>
        /// <returns>Relative mouse position</returns>
        ////////////////////////////////////////////////////////////
        public virtual Vector2I InternalGetMousePosition() => sfMouse_getPosition(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal function to set the mouse position relative to the window.
        ///     This function is protected because it is called by another class of
        ///     another module, it is not meant to be called by users.
        /// </summary>
        /// <param name="position">Relative mouse position</param>
        ////////////////////////////////////////////////////////////
        protected internal virtual void InternalSetMousePosition(Vector2I position)
        {
            sfMouse_setPosition(position, CPointer);
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
        protected internal virtual Vector2I InternalGetTouchPosition(uint finger) => sfTouch_getPosition(finger, CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfWindow_destroy(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Call the event handler for the given event
        /// </summary>
        /// <param name="e">Event to dispatch</param>
        ////////////////////////////////////////////////////////////
        private void CallEventHandler(Event e)
        {
            switch (e.Type)
            {
                case EventType.Closed:
                    if (Closed != null)
                    {
                        Closed(this, EventArgs.Empty);
                    }

                    break;

                case EventType.GainedFocus:
                    if (GainedFocus != null)
                    {
                        GainedFocus(this, EventArgs.Empty);
                    }

                    break;

                case EventType.JoystickButtonPressed:
                    if (JoystickButtonPressed != null)
                    {
                        JoystickButtonPressed(this, new JoystickButtonEventArgs(e.JoystickButton));
                    }

                    break;

                case EventType.JoystickButtonReleased:
                    if (JoystickButtonReleased != null)
                    {
                        JoystickButtonReleased(this, new JoystickButtonEventArgs(e.JoystickButton));
                    }

                    break;

                case EventType.JoystickMoved:
                    if (JoystickMoved != null)
                    {
                        JoystickMoved(this, new JoystickMoveEventArgs(e.JoystickMove));
                    }

                    break;

                case EventType.JoystickConnected:
                    if (JoystickConnected != null)
                    {
                        JoystickConnected(this, new JoystickConnectEventArgs(e.JoystickConnect));
                    }

                    break;

                case EventType.JoystickDisconnected:
                    if (JoystickDisconnected != null)
                    {
                        JoystickDisconnected(this, new JoystickConnectEventArgs(e.JoystickConnect));
                    }

                    break;

                case EventType.KeyPressed:
                    if (KeyPressed != null)
                    {
                        KeyPressed(this, new KeyEventArgs(e.Key));
                    }

                    break;

                case EventType.KeyReleased:
                    if (KeyReleased != null)
                    {
                        KeyReleased(this, new KeyEventArgs(e.Key));
                    }

                    break;

                case EventType.LostFocus:
                    if (LostFocus != null)
                    {
                        LostFocus(this, EventArgs.Empty);
                    }

                    break;

                case EventType.MouseButtonPressed:
                    if (MouseButtonPressed != null)
                    {
                        MouseButtonPressed(this, new MouseButtonEventArgs(e.MouseButton));
                    }

                    break;

                case EventType.MouseButtonReleased:
                    if (MouseButtonReleased != null)
                    {
                        MouseButtonReleased(this, new MouseButtonEventArgs(e.MouseButton));
                    }

                    break;

                case EventType.MouseEntered:
                    if (MouseEntered != null)
                    {
                        MouseEntered(this, EventArgs.Empty);
                    }

                    break;

                case EventType.MouseLeft:
                    if (MouseLeft != null)
                    {
                        MouseLeft(this, EventArgs.Empty);
                    }

                    break;

                case EventType.MouseMoved:
                    if (MouseMoved != null)
                    {
                        MouseMoved(this, new MouseMoveEventArgs(e.MouseMove));
                    }

                    break;
                
                case EventType.MouseWheelScrolled:
                    if (MouseWheelScrolled != null)
                    {
                        MouseWheelScrolled(this, new MouseWheelScrollEventArgs(e.MouseWheelScroll));
                    }

                    break;

                case EventType.Resized:
                    if (Resized != null)
                    {
                        Resized(this, new SizeEventArgs(e.Size));
                    }

                    break;

                case EventType.TextEntered:
                    if (TextEntered != null)
                    {
                        TextEntered(this, new TextEventArgs(e.Text));
                    }

                    break;

                case EventType.TouchBegan:
                    if (TouchBegan != null)
                    {
                        TouchBegan(this, new TouchEventArgs(e.Touch));
                    }

                    break;

                case EventType.TouchMoved:
                    if (TouchMoved != null)
                    {
                        TouchMoved(this, new TouchEventArgs(e.Touch));
                    }

                    break;

                case EventType.TouchEnded:
                    if (TouchEnded != null)
                    {
                        TouchEnded(this, new TouchEventArgs(e.Touch));
                    }

                    break;

                case EventType.SensorChanged:
                    if (SensorChanged != null)
                    {
                        SensorChanged(this, new SensorEventArgs(e.Sensor));
                    }

                    break;
            }
        }

        /// <summary>Event handler for the Closed event</summary>
        public event EventHandler Closed;

        /// <summary>Event handler for the Resized event</summary>
        public event EventHandler<SizeEventArgs> Resized;

        /// <summary>Event handler for the LostFocus event</summary>
        public event EventHandler LostFocus;

        /// <summary>Event handler for the GainedFocus event</summary>
        public event EventHandler GainedFocus;

        /// <summary>Event handler for the TextEntered event</summary>
        public event EventHandler<TextEventArgs> TextEntered;

        /// <summary>Event handler for the KeyPressed event</summary>
        public event EventHandler<KeyEventArgs> KeyPressed;

        /// <summary>Event handler for the KeyReleased event</summary>
        public event EventHandler<KeyEventArgs> KeyReleased;
        
        /// <summary>Event handler for the MouseWheelScrolled event</summary>
        public event EventHandler<MouseWheelScrollEventArgs> MouseWheelScrolled;

        /// <summary>Event handler for the MouseButtonPressed event</summary>
        public event EventHandler<MouseButtonEventArgs> MouseButtonPressed;

        /// <summary>Event handler for the MouseButtonReleased event</summary>
        public event EventHandler<MouseButtonEventArgs> MouseButtonReleased;

        /// <summary>Event handler for the MouseMoved event</summary>
        public event EventHandler<MouseMoveEventArgs> MouseMoved;

        /// <summary>Event handler for the MouseEntered event</summary>
        public event EventHandler MouseEntered;

        /// <summary>Event handler for the MouseLeft event</summary>
        public event EventHandler MouseLeft;

        /// <summary>Event handler for the JoystickButtonPressed event</summary>
        public event EventHandler<JoystickButtonEventArgs> JoystickButtonPressed;

        /// <summary>Event handler for the JoystickButtonReleased event</summary>
        public event EventHandler<JoystickButtonEventArgs> JoystickButtonReleased;

        /// <summary>Event handler for the JoystickMoved event</summary>
        public event EventHandler<JoystickMoveEventArgs> JoystickMoved;

        /// <summary>Event handler for the JoystickConnected event</summary>
        public event EventHandler<JoystickConnectEventArgs> JoystickConnected;

        /// <summary>Event handler for the JoystickDisconnected event</summary>
        public event EventHandler<JoystickConnectEventArgs> JoystickDisconnected;

        /// <summary>Event handler for the TouchBegan event</summary>
        public event EventHandler<TouchEventArgs> TouchBegan;

        /// <summary>Event handler for the TouchMoved event</summary>
        public event EventHandler<TouchEventArgs> TouchMoved;

        /// <summary>Event handler for the TouchEnded event</summary>
        public event EventHandler<TouchEventArgs> TouchEnded;

        /// <summary>Event handler for the SensorChanged event</summary>
        public event EventHandler<SensorEventArgs> SensorChanged;

        /// <summary>
        ///     Sfs the window create using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="title">The title</param>
        /// <param name="style">The style</param>
        /// <param name="params">The params</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfWindow_create(VideoMode mode, string title, Styles style,
            ref ContextSettings @params);

        /// <summary>
        ///     Sfs the window create unicode using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="title">The title</param>
        /// <param name="style">The style</param>
        /// <param name="params">The params</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfWindow_createUnicode(VideoMode mode, IntPtr title, Styles style,
            ref ContextSettings @params);

        /// <summary>
        ///     Sfs the window create from handle using the specified handle
        /// </summary>
        /// <param name="handle">The handle</param>
        /// <param name="params">The params</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfWindow_createFromHandle(IntPtr handle, ref ContextSettings @params);

        /// <summary>
        ///     Sfs the window destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_destroy(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf window is open
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfWindow_isOpen(IntPtr cPointer);

        /// <summary>
        ///     Sfs the window close using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_close(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf window poll event
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="evt">The evt</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfWindow_pollEvent(IntPtr cPointer, out Event evt);

        /// <summary>
        ///     Describes whether sf window wait event
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="evt">The evt</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfWindow_waitEvent(IntPtr cPointer, out Event evt);

        /// <summary>
        ///     Sfs the window display using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_display(IntPtr cPointer);

        /// <summary>
        ///     Sfs the window get settings using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The context settings</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern ContextSettings sfWindow_getSettings(IntPtr cPointer);

        /// <summary>
        ///     Sfs the window get position using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfWindow_getPosition(IntPtr cPointer);

        /// <summary>
        ///     Sfs the window set position using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="position">The position</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setPosition(IntPtr cPointer, Vector2I position);

        /// <summary>
        ///     Sfs the window get size using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2u</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2U sfWindow_getSize(IntPtr cPointer);

        /// <summary>
        ///     Sfs the window set size using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="size">The size</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setSize(IntPtr cPointer, Vector2U size);

        /// <summary>
        ///     Sfs the window set title using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="title">The title</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setTitle(IntPtr cPointer, string title);

        /// <summary>
        ///     Sfs the window set unicode title using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="title">The title</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setUnicodeTitle(IntPtr cPointer, IntPtr title);

        /// <summary>
        ///     Sfs the window set icon using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="pixels">The pixels</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe void sfWindow_setIcon(IntPtr cPointer, uint width, uint height, byte* pixels);

        /// <summary>
        ///     Sfs the window set visible using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="visible">The visible</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setVisible(IntPtr cPointer, bool visible);

        /// <summary>
        ///     Sfs the window set mouse cursor visible using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="show">The show</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setMouseCursorVisible(IntPtr cPointer, bool show);

        /// <summary>
        ///     Sfs the window set mouse cursor grabbed using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setMouseCursorGrabbed(IntPtr cPointer, bool grabbed);

        /// <summary>
        ///     Sfs the window set mouse cursor using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="cursor">The cursor</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setMouseCursor(IntPtr cPointer, IntPtr cursor);

        /// <summary>
        ///     Sfs the window set vertical sync enabled using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="enable">The enable</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setVerticalSyncEnabled(IntPtr cPointer, bool enable);

        /// <summary>
        ///     Sfs the window set key repeat enabled using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="enable">The enable</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setKeyRepeatEnabled(IntPtr cPointer, bool enable);

        /// <summary>
        ///     Describes whether sf window set active
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="active">The active</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfWindow_setActive(IntPtr cPointer, bool active);

        /// <summary>
        ///     Sfs the window set framerate limit using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="limit">The limit</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setFramerateLimit(IntPtr cPointer, uint limit);

        /// <summary>
        ///     Sfs the window get frame time using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfWindow_getFrameTime(IntPtr cPointer);

        /// <summary>
        ///     Sfs the window set joystick threshold using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="threshold">The threshold</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_setJoystickThreshold(IntPtr cPointer, float threshold);

        /// <summary>
        ///     Sfs the window get system handle using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfWindow_getSystemHandle(IntPtr cPointer);

        /// <summary>
        ///     Sfs the window request focus using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfWindow_requestFocus(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf window has focus
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfWindow_hasFocus(IntPtr cPointer);

        /// <summary>
        ///     Sfs the mouse get position using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfMouse_getPosition(IntPtr cPointer);

        /// <summary>
        ///     Sfs the mouse set position using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMouse_setPosition(Vector2I position, IntPtr cPointer);

        /// <summary>
        ///     Sfs the touch get position using the specified finger
        /// </summary>
        /// <param name="finger">The finger</param>
        /// <param name="relativeTo">The relative to</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2I sfTouch_getPosition(uint finger, IntPtr relativeTo);
    }
}