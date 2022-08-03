using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Enumeration of the different types of events
    /// </summary>
    ////////////////////////////////////////////////////////////
    public enum EventType
    {
        /// <summary>Event triggered when a window is manually closed</summary>
        Closed,

        /// <summary>Event triggered when a window is resized</summary>
        Resized,

        /// <summary>Event triggered when a window loses the focus</summary>
        LostFocus,

        /// <summary>Event triggered when a window gains the focus</summary>
        GainedFocus,

        /// <summary>Event triggered when a valid character is entered</summary>
        TextEntered,

        /// <summary>Event triggered when a keyboard key is pressed</summary>
        KeyPressed,

        /// <summary>Event triggered when a keyboard key is released</summary>
        KeyReleased,

        /// <summary>Event triggered when the mouse wheel is scrolled (deprecated)</summary>
        [Obsolete("MouseWheelMoved is deprecated, please use MouseWheelScrolled instead")]
        MouseWheelMoved,

        /// <summary>Event triggered when a mouse wheel is scrolled</summary>
        MouseWheelScrolled,

        /// <summary>Event triggered when a mouse button is pressed</summary>
        MouseButtonPressed,

        /// <summary>Event triggered when a mouse button is released</summary>
        MouseButtonReleased,

        /// <summary>Event triggered when the mouse moves within the area of a window</summary>
        MouseMoved,

        /// <summary>Event triggered when the mouse enters the area of a window</summary>
        MouseEntered,

        /// <summary>Event triggered when the mouse leaves the area of a window</summary>
        MouseLeft,

        /// <summary>Event triggered when a joystick button is pressed</summary>
        JoystickButtonPressed,

        /// <summary>Event triggered when a joystick button is released</summary>
        JoystickButtonReleased,

        /// <summary>Event triggered when a joystick axis moves</summary>
        JoystickMoved,

        /// <summary>Event triggered when a joystick is connected</summary>
        JoystickConnected,

        /// <summary>Event triggered when a joystick is disconnected</summary>
        JoystickDisconnected,

        /// <summary>Event triggered when a touch begins</summary>
        TouchBegan,

        /// <summary>Event triggered when a touch is moved</summary>
        TouchMoved,

        /// <summary>Event triggered when a touch is ended</summary>
        TouchEnded,

        /// <summary>Event triggered when a sensor is changed</summary>
        SensorChanged
    }
}