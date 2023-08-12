using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl pumpevents
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_PumpEvents_t();
        /// <summary>
        /// The sdl pumpevents
        /// </summary>
        private static SDL_PumpEvents_t s_sdl_pumpEvents = LoadFunction<SDL_PumpEvents_t>("SDL_PumpEvents");
        /// <summary>
        /// Sdls the pump events
        /// </summary>
        public static void SDL_PumpEvents() => s_sdl_pumpEvents();

        /// <summary>
        /// The sdl pollevent
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_PollEvent_t(SDL_Event* @event);
        /// <summary>
        /// The sdl pollevent
        /// </summary>
        private static SDL_PollEvent_t s_sdl_pollEvent = LoadFunction<SDL_PollEvent_t>("SDL_PollEvent");
        /// <summary>
        /// Sdls the poll event using the specified event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        public static int SDL_PollEvent(SDL_Event* @event) => s_sdl_pollEvent(@event);

        /// <summary>
        /// The sdl addeventwatch
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_AddEventWatch_t(SDL_EventFilter filter, void* userdata);
        /// <summary>
        /// The sdl addeventwatch
        /// </summary>
        private static SDL_AddEventWatch_t s_sdl_addEventWatch = LoadFunction<SDL_AddEventWatch_t>("SDL_AddEventWatch");
        /// <summary>
        /// Sdls the add event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        public static void SDL_AddEventWatch(SDL_EventFilter filter, void* userdata) => s_sdl_addEventWatch(filter, userdata);

        /// <summary>
        /// The sdl seteventfilter
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetEventFilter_t(SDL_EventFilter filter, void* userdata);
        /// <summary>
        /// The sdl seteventfilter
        /// </summary>
        private static SDL_SetEventFilter_t s_sdl_setEventFilter = LoadFunction<SDL_SetEventFilter_t>("SDL_SetEventFilter");
        /// <summary>
        /// Sdls the set event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        public static void SDL_SetEventFilter(SDL_EventFilter filter, void* userdata) => s_sdl_setEventFilter(filter, userdata);

        /// <summary>
        /// The sdl filterevents
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FilterEvents_t(SDL_EventFilter filter, void* userdata);
        /// <summary>
        /// The sdl filterevents
        /// </summary>
        private static SDL_FilterEvents_t s_sdl_filterEvents = LoadFunction<SDL_FilterEvents_t>("SDL_FilterEvents");
        /// <summary>
        /// Sdls the filter events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        public static void SDL_FilterEvents(SDL_EventFilter filter, void* userdata) => s_sdl_filterEvents(filter, userdata);
    }

    /// <summary>
    /// The sdl eventfilter
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int SDL_EventFilter(void* userdata, SDL_Event* @event);

    /// <summary>
    /// The sdl event
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_Event
    {
        /// <summary>
        /// The type
        /// </summary>
        [FieldOffset(0)]
        public SDL_EventType type;
        /// <summary>
        /// The timestamp
        /// </summary>
        [FieldOffset(4)]
        public uint timestamp;
        /// <summary>
        /// The window id
        /// </summary>
        [FieldOffset(8)]
        public uint windowID;
        /// <summary>
        /// The padding
        /// </summary>
        [FieldOffset(0)]
        private Bytex56 __padding;
        /// <summary>
        /// The bytex 56
        /// </summary>
        private unsafe struct Bytex56 { /// <summary>
 /// The bytes
 /// </summary>
 private fixed byte bytes[56]; }
    }

    /// <summary>
    /// The sdl windowevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_WindowEvent
    {
        /// <summary>
        /// SDL_WINDOWEVENT
        /// </summary>
        public SDL_EventType type;
        /// <summary>
        /// The timestamp
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The associated Sdl2Window
        /// </summary>
        public uint windowID;
        /// <summary>
        /// SDL_WindowEventID
        /// </summary>
        public SDL_WindowEventID @event;
        /// <summary>
        /// The padding
        /// </summary>
        private byte padding1;
        /// <summary>
        /// The padding
        /// </summary>
        private byte padding2;
        /// <summary>
        /// The padding
        /// </summary>
        private byte padding3;
        /// <summary>
        /// event dependent data
        /// </summary>
        public int data1;
        /// <summary>
        /// event dependent data
        /// </summary>
        public int data2;
    }

    /// <summary>
    /// The sdl windoweventid enum
    /// </summary>
    public enum SDL_WindowEventID : byte
    {
        /// <summary>
        /// Never used.
        /// </summary>
        None,
        /// <summary>
        /// Sdl2Window has been shown.
        /// </summary>
        Shown,
        /// <summary>
        /// Sdl2Window has been hidden.
        /// </summary>
        Hidden,
        /// <summary>
        /// Sdl2Window has been exposed and should be redrawn.
        /// </summary>
        Exposed,
        /// <summary>
        /// Sdl2Window has been moved to data1, data2.
        /// </summary>
        Moved,
        /// <summary>
        /// Sdl2Window has been resized to data1xdata2.
        /// </summary>
        Resized,
        /// <summary>
        /// The Sdl2Window size has changed, either as a result of an API call or through the system or user changing the Sdl2Window size.
        /// </summary>
        SizeChanged,
        /// <summary>
        /// Sdl2Window has been minimized.
        /// </summary>
        Minimized,
        /// <summary>
        /// Sdl2Window has been maximized.
        /// </summary>
        Maximized,
        /// <summary>
        /// Sdl2Window has been restored to normal size and position.
        /// </summary>
        Restored,
        /// <summary>
        /// Sdl2Window has gained mouse focus.
        /// </summary>
        Enter,
        /// <summary>
        /// Sdl2Window has lost mouse focus.
        /// </summary>
        Leave,
        /// <summary>
        /// Sdl2Window has gained keyboard focus.
        /// </summary>
        FocusGained,
        /// <summary>
        /// Sdl2Window has lost keyboard focus
        /// </summary>
        FocusLost,
        /// <summary>
        /// The Sdl2Window manager requests that the Sdl2Window be closed.
        /// </summary>
        Close,
        /// <summary>
        /// Sdl2Window is being offered a focus (should SetWindowInputFocus() on itself or a subwindow, or ignore).
        /// </summary>
        TakeFocus,
        /// <summary>
        /// Sdl2Window had a hit test that wasn't SDL_HITTEST_NORMAL.
        /// </summary>
        HitTest
    }

    /// <summary>
    /// The types of events that can be delivered.
    /// </summary>
    public enum SDL_EventType
    {
        /// <summary>
        /// The first event sdl eventtype
        /// </summary>
        FirstEvent = 0,

        /* Application events */

        /// <summary>
        /// User-requested quit.
        /// </summary>
        Quit = 0x100,

        /// <summary>
        /// The application is being terminated by the OS.
        /// Called on iOS in applicationWillTerminate()
        /// Called on Android in onDestroy()
        /// </summary>
        Terminating,

        /// <summary>
        /// The application is low on memory, free memory if possible.
        /// Called on iOS in applicationDidReceiveMemoryWarning()
        /// Called on Android in onLowMemory()
        /// </summary>
        LowMemory,

        /// <summary>
        /// The application is about to enter the background.
        /// Called on iOS in applicationWillResignActive().
        /// Called on Android in onPause()
        /// </summary>
        WillEnterBackground,
        /// <summary>
        /// The application did enter the background and may not get CPU for some time.
        /// Called on iOS in applicationDidEnterBackground().
        /// Called on Android in onPause()
        /// </summary>
        DidEnterBackground,
        /// <summary>
        /// The application is about to enter the foreground
        /// Called on iOS in applicationWillEnterForeground()
        /// Called on Android in onResume()
        /// </summary>
        WillEnterForeground,
        /// <summary>
        /// The application is now interactive
        /// Called on iOS in applicationDidBecomeActive()
        /// Called on Android in onResume()
        /// </summary>
        DidEnterForeground,

        /* Sdl2Window events */
        /// <summary>
        /// Sdl2Window state change
        /// </summary>
        WindowEvent = 0x200,
        /// <summary>
        /// System specific event
        /// </summary>
        SysWMEvent,

        /* Keyboard events */
        /// <summary>
        /// Key pressed
        /// </summary>
        KeyDown = 0x300,
        /// <summary>
        /// Key released
        /// </summary>
        KeyUp,
        /// <summary>
        /// Keyboard text editing (composition)
        /// </summary>
        TextEditing,
        /// <summary>
        /// Keyboard text input
        /// </summary>
        TextInput,
        /// <summary>
        /// Keymap changed due to a system event such as an input language or keyboard layout change.
        /// </summary>
        KeyMapChanged,

        /* Mouse events */
        /// <summary>
        /// Mouse moved
        /// </summary>
        MouseMotion = 0x400,
        /// <summary>
        /// The mouse button down sdl eventtype
        /// </summary>
        MouseButtonDown,
        /// <summary>
        /// Mouse button released
        /// </summary>
        MouseButtonUp,
        /// <summary>
        /// Mouse wheel motion
        /// </summary>
        MouseWheel,

        /* Joystick events */
        /// <summary>
        /// Joystick axis motion
        /// </summary>
        JoyAxisMotion = 0x600,
        /// <summary>
        /// Joystick trackball motion
        /// </summary>
        JoyBallMotion,
        /// <summary>
        /// Joystick hat position change
        /// </summary>
        JoyHatMotion,
        /// <summary>
        /// Joystick button pressed
        /// </summary>
        JoyButtonDown,
        /// <summary>
        /// Joystick button released
        /// </summary>
        JoyButtonUp,
        /// <summary>
        /// A new joystick has been inserted into the system
        /// </summary>
        JoyDeviceAdded,
        /// <summary>
        /// An opened joystick has been removed
        /// </summary>
        JoyDeviceRemoved,

        /* Game controller events */
        /// <summary>
        /// Game controller axis motion
        /// </summary>
        ControllerAxisMotion = 0x650,
        /// <summary>
        /// Game controller button pressed
        /// </summary>
        ControllerButtonDown,
        /// <summary>
        /// Game controller button released
        /// </summary>
        ControllerButtonUp,
        /// <summary>
        /// A new Game controller has been inserted into the system
        /// </summary>
        ControllerDeviceAdded,
        /// <summary>
        /// An opened Game controller has been removed
        /// </summary>
        ControllerDeviceRemoved,
        /// <summary>
        /// The controller mapping was updated
        /// </summary>
        ControllerDeviceRemapped,

        /* Touch events */
        /// <summary>
        /// The finger down sdl eventtype
        /// </summary>
        FingerDown = 0x700,
        /// <summary>
        /// The finger up sdl eventtype
        /// </summary>
        FingerUp,
        /// <summary>
        /// The finger motion sdl eventtype
        /// </summary>
        FingerMotion,

        /* Gesture events */
        /// <summary>
        /// The dollar gesture sdl eventtype
        /// </summary>
        DollarGesture = 0x800,
        /// <summary>
        /// The dollar record sdl eventtype
        /// </summary>
        DollarRecord,
        /// <summary>
        /// The multi gesture sdl eventtype
        /// </summary>
        MultiGesture,

        /* Clipboard events */
        /// <summary>
        /// The clipboard changed
        /// </summary>
        ClipboardUpdate = 0x900,

        /* Drag and drop events */
        /// <summary>
        /// The system requests a file open
        /// </summary>
        DropFile = 0x1000,
        /// <summary>
        /// text/plain drag-and-drop event
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DropTest,
        /// <summary>
        /// text/plain drag-and-drop event
        /// </summary>
        DropText = DropTest,
        /// <summary>
        /// A new set of drops is beginning (NULL filename) 
        /// </summary>
        DropBegin,
        /// <summary>
        /// Current set of drops is now complete (NULL filename)
        /// </summary>
        DropComplete,

        /* Audio hotplug events */
        /// <summary>
        /// A new audio device is available
        /// </summary>
        AudioDeviceAdded = 0x1100,
        /// <summary>
        /// An audio device has been removed.
        /// </summary>
        AudioDeviceRemoved,

        /* Render events */
        /// <summary>
        /// The render targets have been reset and their contents need to be updated
        /// </summary>
        RenderTargetsReset = 0x2000,
        /// <summary>
        /// The device has been reset and all textures need to be recreated
        /// </summary>
        RenderDeviceReset,

        /// <summary>
        /// Events ::SDL_USEREVENT through ::SDL_LASTEVENT are for your use,
        /// *  and should be allocated with SDL_RegisterEvents()
        /// </summary>
        UserEvent = 0x8000,

        /// <summary>
        /// The last event sdl eventtype
        /// </summary>
        LastEvent = 0xFFFF
    }

    /// <summary>
    /// Mouse motion event structure (event.motion.*)
    /// </summary>
    public struct SDL_MouseMotionEvent
    {
        /// <summary>
        /// The type
        /// </summary>
        public SDL_EventType type;
        /// <summary>
        /// The timestamp
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with mouse focus, if any.
        /// </summary>
        public uint windowID;
        /// <summary>
        /// The mouse instance id, or SDL_TOUCH_MOUSEID.
        /// </summary>
        public uint which;
        /// <summary>
        /// The current button state.
        /// </summary>
        public ButtonState state;
        /// <summary>
        /// X coordinate, relative to Sdl2Window.
        /// </summary>
        public int x;
        /// <summary>
        /// Y coordinate, relative to Sdl2Window.
        /// </summary>
        public int y;
        /// <summary>
        /// The relative motion in the X direction.
        /// </summary>
        public int xrel;
        /// <summary>
        /// The relative motion in the Y direction.
        /// </summary>
        public int yrel;
    }

    /// <summary>
    /// Mouse button event structure (event.button.*)
    /// </summary>
    public struct SDL_MouseButtonEvent
    {
        /// <summary>
        /// SDL_MOUSEBUTTONDOWN or ::SDL_MOUSEBUTTONUP.
        /// </summary>
        public SDL_EventType type;
        /// <summary>
        /// The timestamp
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with mouse focus, if any.
        /// </summary>
        public uint windowID;
        /// <summary>
        /// The mouse instance id, or SDL_TOUCH_MOUSEID.
        /// </summary>
        public uint which;
        /// <summary>
        /// The mouse button index.
        /// </summary>
        public SDL_MouseButton button;
        /// <summary>
        /// Pressed (1) or Released (0).
        /// </summary>
        public byte state;
        /// <summary>
        /// 1 for single-click, 2 for double-click, etc.
        /// </summary>
        public byte clicks;
        /// <summary>
        /// The padding
        /// </summary>
        public byte padding1;
        /// <summary>
        /// X coordinate, relative to Sdl2Window.
        /// </summary>
        public int x;
        /// <summary>
        /// Y coordinate, relative to Sdl2Window
        /// </summary>
        public int y;
    }

    /// <summary>
    /// Mouse wheel event structure (event.wheel.*).
    /// </summary>
    public struct SDL_MouseWheelEvent
    {
        /// <summary>
        /// SDL_MOUSEWHEEL.
        /// </summary>
        public SDL_EventType type;
        /// <summary>
        /// The timestamp
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with mouse focus, if any.
        /// </summary>
        public uint windowID;
        /// <summary>
        /// The mouse instance id, or SDL_TOUCH_MOUSEID.
        /// </summary>
        public uint which;
        /// <summary>
        /// The amount scrolled horizontally, positive to the right and negative to the left.
        /// </summary>
        public int x;
        /// <summary>
        /// The amount scrolled vertically, positive away from the user and negative toward the user.
        /// </summary>
        public int y;
        /// <summary>
        /// Set to one of the SDL_MOUSEWHEEL_* defines. When FLIPPED the values in X and Y will be opposite. Multiply by -1 to change them back.
        /// </summary>
        public uint direction;
    }


    /// <summary>
    /// The button state enum
    /// </summary>
    [Flags]
    public enum ButtonState : uint
    {
        /// <summary>
        /// The left button state
        /// </summary>
        Left = 1 << 0,
        /// <summary>
        /// The middle button state
        /// </summary>
        Middle = 1 << 1,
        /// <summary>
        /// The right button state
        /// </summary>
        Right = 1 << 2,
        /// <summary>
        /// The  button state
        /// </summary>
        X1 = 1 << 3,
        /// <summary>
        /// The  button state
        /// </summary>
        X2 = 1 << 4,
    }

    /// <summary>
    /// Keyboard button event structure (event.key.*).
    /// </summary>
    public struct SDL_KeyboardEvent
    {
        /// <summary>
        /// SDL_KEYDOWN or SDL_KEYUP
        /// </summary>
        public SDL_EventType type;
        /// <summary>
        /// The timestamp
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with keyboard focus, if any
        /// </summary>
        public uint windowID;
        /// <summary>
        /// Pressed (1) or Released (0).
        /// </summary>
        public byte state;
        /// <summary>
        /// Non-zero if this is a key repeat
        /// </summary>
        public byte repeat;
        /// <summary>
        /// The padding
        /// </summary>
        public byte padding2;
        /// <summary>
        /// The padding
        /// </summary>
        public byte padding3;
        /// <summary>
        /// The key that was pressed or released
        /// </summary>
        public SDL_Keysym keysym;
    }

    /// <summary>
    /// The sdl keysym
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Keysym
    {
        /// <summary>
        /// SDL physical key code.
        /// </summary>
        public SDL_Scancode scancode;
        /// <summary>
        /// SDL virtual key code.
        /// </summary>
        public SDL_Keycode sym;
        /// <summary>
        /// current key modifiers.
        /// </summary>
        public SDL_Keymod mod;
        /// <summary>
        /// The unused
        /// </summary>
        private uint __unused;
    }

    /// <summary>
    /// The sdl mousebutton enum
    /// </summary>
    public enum SDL_MouseButton : byte
    {
        /// <summary>
        /// The left sdl mousebutton
        /// </summary>
        Left = 1,
        /// <summary>
        /// The middle sdl mousebutton
        /// </summary>
        Middle = 2,
        /// <summary>
        /// The right sdl mousebutton
        /// </summary>
        Right = 3,
        /// <summary>
        /// The  sdl mousebutton
        /// </summary>
        X1 = 4,
        /// <summary>
        /// The  sdl mousebutton
        /// </summary>
        X2 = 5,
    }

    /// <summary>
    /// Keyboard text input event structure (event.text.*)
    /// </summary>
    public unsafe struct SDL_TextInputEvent
    {
        /// <summary>
        /// The max text size
        /// </summary>
        public const int MaxTextSize = 32;

        /// <summary>
        /// SDL_TEXTINPUT.
        /// </summary>
        public SDL_EventType type;
        /// <summary>
        /// The timestamp
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with keyboard focus, if any.
        /// </summary>
        public uint windowID;
        /// <summary>
        /// The input text.
        /// </summary>
        public fixed byte text[MaxTextSize];
    }

    /// <summary>
    /// The sdl dropevent
    /// </summary>
    public unsafe struct SDL_DropEvent
    {
        /// <summary>
        /// SDL_DROPFILE, SDL_DROPTEXT, SDL_DROPBEGIN, or SDL_DROPCOMPLETE.
        /// </summary>
        public SDL_EventType type;
        /// <summary>timestamp of the event.</summary>
        public uint timestamp;
        /// <summary>the file name, which should be freed with SDL_free(), is NULL on BEGIN/COMPLETE</summary>
        public byte* file;
        /// <summary>the window that was dropped on, if any</summary>
        public uint windowID;
    }
}
