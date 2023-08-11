namespace Veldrid
{
    /// <summary>
    /// The key event
    /// </summary>
    public struct KeyEvent
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public Key Key { get; }
        /// <summary>
        /// Gets the value of the down
        /// </summary>
        public bool Down { get; }
        /// <summary>
        /// Gets the value of the modifiers
        /// </summary>
        public ModifierKeys Modifiers { get; }
        /// <summary>
        /// Gets the value of the repeat
        /// </summary>
        public bool Repeat { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEvent"/> class
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        /// <param name="modifiers">The modifiers</param>
        public KeyEvent(Key key, bool down, ModifierKeys modifiers)
        : this(key, down, modifiers, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEvent"/> class
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="down">The down</param>
        /// <param name="modifiers">The modifiers</param>
        /// <param name="repeat">The repeat</param>
        public KeyEvent(Key key, bool down, ModifierKeys modifiers, bool repeat)
        {
            Key = key;
            Down = down;
            Modifiers = modifiers;
            Repeat = repeat;
        }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => $"{Key} {(Down ? "Down" : "Up")} [{Modifiers}] (repeat={Repeat})";
    }

    /// <summary>
    /// The key enum
    /// </summary>
    public enum Key
    {
        //
        // Summary:
        //     A key outside the known keys.
        /// <summary>
        /// The unknown key
        /// </summary>
        Unknown = 0,
        //
        // Summary:
        //     The left shift key.
        /// <summary>
        /// The shift left key
        /// </summary>
        ShiftLeft = 1,
        //
        // Summary:
        //     The left shift key (equivalent to ShiftLeft).
        /// <summary>
        /// The shift key
        /// </summary>
        LShift = 1,
        //
        // Summary:
        //     The right shift key.
        /// <summary>
        /// The shift right key
        /// </summary>
        ShiftRight = 2,
        //
        // Summary:
        //     The right shift key (equivalent to ShiftRight).
        /// <summary>
        /// The shift key
        /// </summary>
        RShift = 2,
        //
        // Summary:
        //     The left control key.
        /// <summary>
        /// The control left key
        /// </summary>
        ControlLeft = 3,
        //
        // Summary:
        //     The left control key (equivalent to ControlLeft).
        /// <summary>
        /// The control key
        /// </summary>
        LControl = 3,
        //
        // Summary:
        //     The right control key.
        /// <summary>
        /// The control right key
        /// </summary>
        ControlRight = 4,
        //
        // Summary:
        //     The right control key (equivalent to ControlRight).
        /// <summary>
        /// The control key
        /// </summary>
        RControl = 4,
        //
        // Summary:
        //     The left alt key.
        /// <summary>
        /// The alt left key
        /// </summary>
        AltLeft = 5,
        //
        // Summary:
        //     The left alt key (equivalent to AltLeft.
        /// <summary>
        /// The alt key
        /// </summary>
        LAlt = 5,
        //
        // Summary:
        //     The right alt key.
        /// <summary>
        /// The alt right key
        /// </summary>
        AltRight = 6,
        //
        // Summary:
        //     The right alt key (equivalent to AltRight).
        /// <summary>
        /// The alt key
        /// </summary>
        RAlt = 6,
        //
        // Summary:
        //     The left win key.
        /// <summary>
        /// The win left key
        /// </summary>
        WinLeft = 7,
        //
        // Summary:
        //     The left win key (equivalent to WinLeft).
        /// <summary>
        /// The win key
        /// </summary>
        LWin = 7,
        //
        // Summary:
        //     The right win key.
        /// <summary>
        /// The win right key
        /// </summary>
        WinRight = 8,
        //
        // Summary:
        //     The right win key (equivalent to WinRight).
        /// <summary>
        /// The win key
        /// </summary>
        RWin = 8,
        //
        // Summary:
        //     The menu key.
        /// <summary>
        /// The menu key
        /// </summary>
        Menu = 9,
        //
        // Summary:
        //     The F1 key.
        /// <summary>
        /// The  key
        /// </summary>
        F1 = 10,
        //
        // Summary:
        //     The F2 key.
        /// <summary>
        /// The  key
        /// </summary>
        F2 = 11,
        //
        // Summary:
        //     The F3 key.
        /// <summary>
        /// The  key
        /// </summary>
        F3 = 12,
        //
        // Summary:
        //     The F4 key.
        /// <summary>
        /// The  key
        /// </summary>
        F4 = 13,
        //
        // Summary:
        //     The F5 key.
        /// <summary>
        /// The  key
        /// </summary>
        F5 = 14,
        //
        // Summary:
        //     The F6 key.
        /// <summary>
        /// The  key
        /// </summary>
        F6 = 15,
        //
        // Summary:
        //     The F7 key.
        /// <summary>
        /// The  key
        /// </summary>
        F7 = 16,
        //
        // Summary:
        //     The F8 key.
        /// <summary>
        /// The  key
        /// </summary>
        F8 = 17,
        //
        // Summary:
        //     The F9 key.
        /// <summary>
        /// The  key
        /// </summary>
        F9 = 18,
        //
        // Summary:
        //     The F10 key.
        /// <summary>
        /// The 10 key
        /// </summary>
        F10 = 19,
        //
        // Summary:
        //     The F11 key.
        /// <summary>
        /// The 11 key
        /// </summary>
        F11 = 20,
        //
        // Summary:
        //     The F12 key.
        /// <summary>
        /// The 12 key
        /// </summary>
        F12 = 21,
        //
        // Summary:
        //     The F13 key.
        /// <summary>
        /// The 13 key
        /// </summary>
        F13 = 22,
        //
        // Summary:
        //     The F14 key.
        /// <summary>
        /// The 14 key
        /// </summary>
        F14 = 23,
        //
        // Summary:
        //     The F15 key.
        /// <summary>
        /// The 15 key
        /// </summary>
        F15 = 24,
        //
        // Summary:
        //     The F16 key.
        /// <summary>
        /// The 16 key
        /// </summary>
        F16 = 25,
        //
        // Summary:
        //     The F17 key.
        /// <summary>
        /// The 17 key
        /// </summary>
        F17 = 26,
        //
        // Summary:
        //     The F18 key.
        /// <summary>
        /// The 18 key
        /// </summary>
        F18 = 27,
        //
        // Summary:
        //     The F19 key.
        /// <summary>
        /// The 19 key
        /// </summary>
        F19 = 28,
        //
        // Summary:
        //     The F20 key.
        /// <summary>
        /// The 20 key
        /// </summary>
        F20 = 29,
        //
        // Summary:
        //     The F21 key.
        /// <summary>
        /// The 21 key
        /// </summary>
        F21 = 30,
        //
        // Summary:
        //     The F22 key.
        /// <summary>
        /// The 22 key
        /// </summary>
        F22 = 31,
        //
        // Summary:
        //     The F23 key.
        /// <summary>
        /// The 23 key
        /// </summary>
        F23 = 32,
        //
        // Summary:
        //     The F24 key.
        /// <summary>
        /// The 24 key
        /// </summary>
        F24 = 33,
        //
        // Summary:
        //     The F25 key.
        /// <summary>
        /// The 25 key
        /// </summary>
        F25 = 34,
        //
        // Summary:
        //     The F26 key.
        /// <summary>
        /// The 26 key
        /// </summary>
        F26 = 35,
        //
        // Summary:
        //     The F27 key.
        /// <summary>
        /// The 27 key
        /// </summary>
        F27 = 36,
        //
        // Summary:
        //     The F28 key.
        /// <summary>
        /// The 28 key
        /// </summary>
        F28 = 37,
        //
        // Summary:
        //     The F29 key.
        /// <summary>
        /// The 29 key
        /// </summary>
        F29 = 38,
        //
        // Summary:
        //     The F30 key.
        /// <summary>
        /// The 30 key
        /// </summary>
        F30 = 39,
        //
        // Summary:
        //     The F31 key.
        /// <summary>
        /// The 31 key
        /// </summary>
        F31 = 40,
        //
        // Summary:
        //     The F32 key.
        /// <summary>
        /// The 32 key
        /// </summary>
        F32 = 41,
        //
        // Summary:
        //     The F33 key.
        /// <summary>
        /// The 33 key
        /// </summary>
        F33 = 42,
        //
        // Summary:
        //     The F34 key.
        /// <summary>
        /// The 34 key
        /// </summary>
        F34 = 43,
        //
        // Summary:
        //     The F35 key.
        /// <summary>
        /// The 35 key
        /// </summary>
        F35 = 44,
        //
        // Summary:
        //     The up arrow key.
        /// <summary>
        /// The up key
        /// </summary>
        Up = 45,
        //
        // Summary:
        //     The down arrow key.
        /// <summary>
        /// The down key
        /// </summary>
        Down = 46,
        //
        // Summary:
        //     The left arrow key.
        /// <summary>
        /// The left key
        /// </summary>
        Left = 47,
        //
        // Summary:
        //     The right arrow key.
        /// <summary>
        /// The right key
        /// </summary>
        Right = 48,
        //
        // Summary:
        //     The enter key.
        /// <summary>
        /// The enter key
        /// </summary>
        Enter = 49,
        //
        // Summary:
        //     The escape key.
        /// <summary>
        /// The escape key
        /// </summary>
        Escape = 50,
        //
        // Summary:
        //     The space key.
        /// <summary>
        /// The space key
        /// </summary>
        Space = 51,
        //
        // Summary:
        //     The tab key.
        /// <summary>
        /// The tab key
        /// </summary>
        Tab = 52,
        //
        // Summary:
        //     The backspace key.
        /// <summary>
        /// The back space key
        /// </summary>
        BackSpace = 53,
        //
        // Summary:
        //     The backspace key (equivalent to BackSpace).
        /// <summary>
        /// The back key
        /// </summary>
        Back = 53,
        //
        // Summary:
        //     The insert key.
        /// <summary>
        /// The insert key
        /// </summary>
        Insert = 54,
        //
        // Summary:
        //     The delete key.
        /// <summary>
        /// The delete key
        /// </summary>
        Delete = 55,
        //
        // Summary:
        //     The page up key.
        /// <summary>
        /// The page up key
        /// </summary>
        PageUp = 56,
        //
        // Summary:
        //     The page down key.
        /// <summary>
        /// The page down key
        /// </summary>
        PageDown = 57,
        //
        // Summary:
        //     The home key.
        /// <summary>
        /// The home key
        /// </summary>
        Home = 58,
        //
        // Summary:
        //     The end key.
        /// <summary>
        /// The end key
        /// </summary>
        End = 59,
        //
        // Summary:
        //     The caps lock key.
        /// <summary>
        /// The caps lock key
        /// </summary>
        CapsLock = 60,
        //
        // Summary:
        //     The scroll lock key.
        /// <summary>
        /// The scroll lock key
        /// </summary>
        ScrollLock = 61,
        //
        // Summary:
        //     The print screen key.
        /// <summary>
        /// The print screen key
        /// </summary>
        PrintScreen = 62,
        //
        // Summary:
        //     The pause key.
        /// <summary>
        /// The pause key
        /// </summary>
        Pause = 63,
        //
        // Summary:
        //     The num lock key.
        /// <summary>
        /// The num lock key
        /// </summary>
        NumLock = 64,
        //
        // Summary:
        //     The clear key (Keypad5 with NumLock disabled, on typical keyboards).
        /// <summary>
        /// The clear key
        /// </summary>
        Clear = 65,
        //
        // Summary:
        //     The sleep key.
        /// <summary>
        /// The sleep key
        /// </summary>
        Sleep = 66,
        //
        // Summary:
        //     The keypad 0 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad0 = 67,
        //
        // Summary:
        //     The keypad 1 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad1 = 68,
        //
        // Summary:
        //     The keypad 2 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad2 = 69,
        //
        // Summary:
        //     The keypad 3 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad3 = 70,
        //
        // Summary:
        //     The keypad 4 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad4 = 71,
        //
        // Summary:
        //     The keypad 5 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad5 = 72,
        //
        // Summary:
        //     The keypad 6 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad6 = 73,
        //
        // Summary:
        //     The keypad 7 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad7 = 74,
        //
        // Summary:
        //     The keypad 8 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad8 = 75,
        //
        // Summary:
        //     The keypad 9 key.
        /// <summary>
        /// The keypad key
        /// </summary>
        Keypad9 = 76,
        //
        // Summary:
        //     The keypad divide key.
        /// <summary>
        /// The keypad divide key
        /// </summary>
        KeypadDivide = 77,
        //
        // Summary:
        //     The keypad multiply key.
        /// <summary>
        /// The keypad multiply key
        /// </summary>
        KeypadMultiply = 78,
        //
        // Summary:
        //     The keypad subtract key.
        /// <summary>
        /// The keypad subtract key
        /// </summary>
        KeypadSubtract = 79,
        //
        // Summary:
        //     The keypad minus key (equivalent to KeypadSubtract).
        /// <summary>
        /// The keypad minus key
        /// </summary>
        KeypadMinus = 79,
        //
        // Summary:
        //     The keypad add key.
        /// <summary>
        /// The keypad add key
        /// </summary>
        KeypadAdd = 80,
        //
        // Summary:
        //     The keypad plus key (equivalent to KeypadAdd).
        /// <summary>
        /// The keypad plus key
        /// </summary>
        KeypadPlus = 80,
        //
        // Summary:
        //     The keypad decimal key.
        /// <summary>
        /// The keypad decimal key
        /// </summary>
        KeypadDecimal = 81,
        //
        // Summary:
        //     The keypad period key (equivalent to KeypadDecimal).
        /// <summary>
        /// The keypad period key
        /// </summary>
        KeypadPeriod = 81,
        //
        // Summary:
        //     The keypad enter key.
        /// <summary>
        /// The keypad enter key
        /// </summary>
        KeypadEnter = 82,
        //
        // Summary:
        //     The A key.
        /// <summary>
        /// The  key
        /// </summary>
        A = 83,
        //
        // Summary:
        //     The B key.
        /// <summary>
        /// The  key
        /// </summary>
        B = 84,
        //
        // Summary:
        //     The C key.
        /// <summary>
        /// The  key
        /// </summary>
        C = 85,
        //
        // Summary:
        //     The D key.
        /// <summary>
        /// The  key
        /// </summary>
        D = 86,
        //
        // Summary:
        //     The E key.
        /// <summary>
        /// The  key
        /// </summary>
        E = 87,
        //
        // Summary:
        //     The F key.
        /// <summary>
        /// The  key
        /// </summary>
        F = 88,
        //
        // Summary:
        //     The G key.
        /// <summary>
        /// The  key
        /// </summary>
        G = 89,
        //
        // Summary:
        //     The H key.
        /// <summary>
        /// The  key
        /// </summary>
        H = 90,
        //
        // Summary:
        //     The I key.
        /// <summary>
        /// The  key
        /// </summary>
        I = 91,
        //
        // Summary:
        //     The J key.
        /// <summary>
        /// The  key
        /// </summary>
        J = 92,
        //
        // Summary:
        //     The K key.
        /// <summary>
        /// The  key
        /// </summary>
        K = 93,
        //
        // Summary:
        //     The L key.
        /// <summary>
        /// The  key
        /// </summary>
        L = 94,
        //
        // Summary:
        //     The M key.
        /// <summary>
        /// The  key
        /// </summary>
        M = 95,
        //
        // Summary:
        //     The N key.
        /// <summary>
        /// The  key
        /// </summary>
        N = 96,
        //
        // Summary:
        //     The O key.
        /// <summary>
        /// The  key
        /// </summary>
        O = 97,
        //
        // Summary:
        //     The P key.
        /// <summary>
        /// The  key
        /// </summary>
        P = 98,
        //
        // Summary:
        //     The Q key.
        /// <summary>
        /// The  key
        /// </summary>
        Q = 99,
        //
        // Summary:
        //     The R key.
        /// <summary>
        /// The  key
        /// </summary>
        R = 100,
        //
        // Summary:
        //     The S key.
        /// <summary>
        /// The  key
        /// </summary>
        S = 101,
        //
        // Summary:
        //     The T key.
        /// <summary>
        /// The  key
        /// </summary>
        T = 102,
        //
        // Summary:
        //     The U key.
        /// <summary>
        /// The  key
        /// </summary>
        U = 103,
        //
        // Summary:
        //     The V key.
        /// <summary>
        /// The  key
        /// </summary>
        V = 104,
        //
        // Summary:
        //     The W key.
        /// <summary>
        /// The  key
        /// </summary>
        W = 105,
        //
        // Summary:
        //     The X key.
        /// <summary>
        /// The  key
        /// </summary>
        X = 106,
        //
        // Summary:
        //     The Y key.
        /// <summary>
        /// The  key
        /// </summary>
        Y = 107,
        //
        // Summary:
        //     The Z key.
        /// <summary>
        /// The  key
        /// </summary>
        Z = 108,
        //
        // Summary:
        //     The number 0 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number0 = 109,
        //
        // Summary:
        //     The number 1 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number1 = 110,
        //
        // Summary:
        //     The number 2 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number2 = 111,
        //
        // Summary:
        //     The number 3 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number3 = 112,
        //
        // Summary:
        //     The number 4 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number4 = 113,
        //
        // Summary:
        //     The number 5 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number5 = 114,
        //
        // Summary:
        //     The number 6 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number6 = 115,
        //
        // Summary:
        //     The number 7 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number7 = 116,
        //
        // Summary:
        //     The number 8 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number8 = 117,
        //
        // Summary:
        //     The number 9 key.
        /// <summary>
        /// The number key
        /// </summary>
        Number9 = 118,
        //
        // Summary:
        //     The tilde key.
        /// <summary>
        /// The tilde key
        /// </summary>
        Tilde = 119,
        //
        // Summary:
        //     The grave key (equivaent to Tilde).
        /// <summary>
        /// The grave key
        /// </summary>
        Grave = 119,
        //
        // Summary:
        //     The minus key.
        /// <summary>
        /// The minus key
        /// </summary>
        Minus = 120,
        //
        // Summary:
        //     The plus key.
        /// <summary>
        /// The plus key
        /// </summary>
        Plus = 121,
        //
        // Summary:
        //     The left bracket key.
        /// <summary>
        /// The bracket left key
        /// </summary>
        BracketLeft = 122,
        //
        // Summary:
        //     The left bracket key (equivalent to BracketLeft).
        /// <summary>
        /// The bracket key
        /// </summary>
        LBracket = 122,
        //
        // Summary:
        //     The right bracket key.
        /// <summary>
        /// The bracket right key
        /// </summary>
        BracketRight = 123,
        //
        // Summary:
        //     The right bracket key (equivalent to BracketRight).
        /// <summary>
        /// The bracket key
        /// </summary>
        RBracket = 123,
        //
        // Summary:
        //     The semicolon key.
        /// <summary>
        /// The semicolon key
        /// </summary>
        Semicolon = 124,
        //
        // Summary:
        //     The quote key.
        /// <summary>
        /// The quote key
        /// </summary>
        Quote = 125,
        //
        // Summary:
        //     The comma key.
        /// <summary>
        /// The comma key
        /// </summary>
        Comma = 126,
        //
        // Summary:
        //     The period key.
        /// <summary>
        /// The period key
        /// </summary>
        Period = 127,
        //
        // Summary:
        //     The slash key.
        /// <summary>
        /// The slash key
        /// </summary>
        Slash = 128,
        //
        // Summary:
        //     The backslash key.
        /// <summary>
        /// The back slash key
        /// </summary>
        BackSlash = 129,
        //
        // Summary:
        //     The secondary backslash key.
        /// <summary>
        /// The non us back slash key
        /// </summary>
        NonUSBackSlash = 130,
        //
        // Summary:
        //     Indicates the last available keyboard key.
        /// <summary>
        /// The last key key
        /// </summary>
        LastKey = 131
    }
}