using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    

    

    

    

    

    

    

    

    

    

    

    

    

    
    /// <summary>
    /// Event defines a system event and its parameters
    /// </summary>
    
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    public struct Event
    {
        /// <summary>Type of event (see EventType enum)</summary>
        [FieldOffset(0)]
        public EventType Type;

        /// <summary>Arguments for size events (Resized)</summary>
        [FieldOffset(4)]
        public SizeEvent Size;

        /// <summary>Arguments for key events (KeyPressed, KeyReleased)</summary>
        [FieldOffset(4)]
        public KeyEvent Key;

        /// <summary>Arguments for text events (TextEntered)</summary>
        [FieldOffset(4)]
        public TextEvent Text;

        /// <summary>Arguments for mouse move events (MouseMoved)</summary>
        [FieldOffset(4)]
        public MouseMoveEvent MouseMove;

        /// <summary>Arguments for mouse button events (MouseButtonPressed, MouseButtonReleased)</summary>
        [FieldOffset(4)]
        public MouseButtonEvent MouseButton;

        /// <summary>Arguments for mouse wheel events (MouseWheelMoved)</summary>
        [FieldOffset(4)]
        [Obsolete("MouseWheel is deprecated, please use MouseWheelScroll instead")]
        public MouseWheelEvent MouseWheel;

        /// <summary>Arguments for mouse wheel scroll events (MouseWheelScrolled)</summary>
        [FieldOffset(4)]
        public MouseWheelScrollEvent MouseWheelScroll;

        /// <summary>Arguments for joystick axis events (JoystickMoved)</summary>
        [FieldOffset(4)]
        public JoystickMoveEvent JoystickMove;

        /// <summary>Arguments for joystick button events (JoystickButtonPressed, JoystickButtonReleased)</summary>
        [FieldOffset(4)]
        public JoystickButtonEvent JoystickButton;

        /// <summary>Arguments for joystick connect events (JoystickConnected, JoystickDisconnected)</summary>
        [FieldOffset(4)]
        public JoystickConnectEvent JoystickConnect;

        /// <summary>Arguments for touch events (TouchBegan, TouchMoved, TouchEnded)</summary>
        [FieldOffset(4)]
        public TouchEvent Touch;

        /// <summary>Arguments for sensor events (SensorChanged)</summary>
        [FieldOffset(4)]
        public SensorEvent Sensor;
    }
}
