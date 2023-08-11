using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;

using static Veldrid.Sdl2.Sdl2Native;
using System.ComponentModel;
using Veldrid;

namespace Veldrid.Sdl2
{
    /// <summary>
    /// The sdl window class
    /// </summary>
    public unsafe class Sdl2Window
    {
        /// <summary>
        /// The sdl event
        /// </summary>
        private readonly List<SDL_Event> _events = new List<SDL_Event>();
        /// <summary>
        /// The window
        /// </summary>
        private IntPtr _window;
        /// <summary>
        /// Gets or sets the value of the window id
        /// </summary>
        internal uint WindowID { get; private set; }
        /// <summary>
        /// The exists
        /// </summary>
        private bool _exists;

        /// <summary>
        /// The simple input snapshot
        /// </summary>
        private SimpleInputSnapshot _publicSnapshot = new SimpleInputSnapshot();
        /// <summary>
        /// The simple input snapshot
        /// </summary>
        private SimpleInputSnapshot _privateSnapshot = new SimpleInputSnapshot();
        /// <summary>
        /// The simple input snapshot
        /// </summary>
        private SimpleInputSnapshot _privateBackbuffer = new SimpleInputSnapshot();

        // Threaded Sdl2Window flags
        /// <summary>
        /// The threaded processing
        /// </summary>
        private readonly bool _threadedProcessing;

        /// <summary>
        /// The should close
        /// </summary>
        private bool _shouldClose;
        /// <summary>
        /// Gets or sets the value of the limit poll rate
        /// </summary>
        public bool LimitPollRate { get; set; }
        /// <summary>
        /// Gets or sets the value of the poll interval in ms
        /// </summary>
        public float PollIntervalInMs { get; set; }

        // Current input states
        /// <summary>
        /// The current mouse
        /// </summary>
        private int _currentMouseX;
        /// <summary>
        /// The current mouse
        /// </summary>
        private int _currentMouseY;
        /// <summary>
        /// The current mouse button states
        /// </summary>
        private bool[] _currentMouseButtonStates = new bool[13];
        /// <summary>
        /// The current mouse delta
        /// </summary>
        private Vector2 _currentMouseDelta;

        // Cached Sdl2Window state (for threaded processing)
        /// <summary>
        /// The point
        /// </summary>
        private BufferedValue<Point> _cachedPosition = new BufferedValue<Point>();
        /// <summary>
        /// The point
        /// </summary>
        private BufferedValue<Point> _cachedSize = new BufferedValue<Point>();
        /// <summary>
        /// The cached window title
        /// </summary>
        private string _cachedWindowTitle;
        /// <summary>
        /// The new window title received
        /// </summary>
        private bool _newWindowTitleReceived;
        /// <summary>
        /// The first mouse event
        /// </summary>
        private bool _firstMouseEvent = true;
        /// <summary>
        /// The close requested handler
        /// </summary>
        private Func<bool> _closeRequestedHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sdl2Window"/> class
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="flags">The flags</param>
        /// <param name="threadedProcessing">The threaded processing</param>
        public Sdl2Window(string title, int x, int y, int width, int height, SDL_WindowFlags flags, bool threadedProcessing)
        {
            SDL_SetHint("SDL_MOUSE_FOCUS_CLICKTHROUGH", "1");
            _threadedProcessing = threadedProcessing;
            if (threadedProcessing)
            {
                using (ManualResetEvent mre = new ManualResetEvent(false))
                {
                    WindowParams wp = new WindowParams()
                    {
                        Title = title,
                        X = x,
                        Y = y,
                        Width = width,
                        Height = height,
                        WindowFlags = flags,
                        ResetEvent = mre
                    };

                    Task.Factory.StartNew(WindowOwnerRoutine, wp, TaskCreationOptions.LongRunning);
                    mre.WaitOne();
                }
            }
            else
            {
                _window = SDL_CreateWindow(title, x, y, width, height, flags);
                WindowID = SDL_GetWindowID(_window);
                Sdl2WindowRegistry.RegisterWindow(this);
                PostWindowCreated(flags);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sdl2Window"/> class
        /// </summary>
        /// <param name="windowHandle">The window handle</param>
        /// <param name="threadedProcessing">The threaded processing</param>
        public Sdl2Window(IntPtr windowHandle, bool threadedProcessing)
        {
            _threadedProcessing = threadedProcessing;
            if (threadedProcessing)
            {
                using (ManualResetEvent mre = new ManualResetEvent(false))
                {
                    WindowParams wp = new WindowParams()
                    {
                        WindowHandle = windowHandle,
                        WindowFlags = 0,
                        ResetEvent = mre
                    };

                    Task.Factory.StartNew(WindowOwnerRoutine, wp, TaskCreationOptions.LongRunning);
                    mre.WaitOne();
                }
            }
            else
            {
                _window = SDL_CreateWindowFrom(windowHandle);
                WindowID = SDL_GetWindowID(_window);
                Sdl2WindowRegistry.RegisterWindow(this);
                PostWindowCreated(0);
            }
        }

        /// <summary>
        /// Gets or sets the value of the x
        /// </summary>
        public int X { get => _cachedPosition.Value.X; set => SetWindowPosition(value, Y); }
        /// <summary>
        /// Gets or sets the value of the y
        /// </summary>
        public int Y { get => _cachedPosition.Value.Y; set => SetWindowPosition(X, value); }

        /// <summary>
        /// Gets or sets the value of the width
        /// </summary>
        public int Width { get => GetWindowSize().X; set => SetWindowSize(value, Height); }
        /// <summary>
        /// Gets or sets the value of the height
        /// </summary>
        public int Height { get => GetWindowSize().Y; set => SetWindowSize(Width, value); }

        /// <summary>
        /// Gets the value of the handle
        /// </summary>
        public IntPtr Handle => GetUnderlyingWindowHandle();

        /// <summary>
        /// Gets or sets the value of the title
        /// </summary>
        public string Title { get => _cachedWindowTitle; set => SetWindowTitle(value); }

        /// <summary>
        /// Sets the window title using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        private void SetWindowTitle(string value)
        {
            _cachedWindowTitle = value;
            _newWindowTitleReceived = true;
        }

        /// <summary>
        /// Gets or sets the value of the window state
        /// </summary>
        public WindowState WindowState
        {
            get
            {
                SDL_WindowFlags flags = SDL_GetWindowFlags(_window);
                if (((flags & SDL_WindowFlags.FullScreenDesktop) == SDL_WindowFlags.FullScreenDesktop)
                    || ((flags & (SDL_WindowFlags.Borderless | SDL_WindowFlags.Fullscreen)) == (SDL_WindowFlags.Borderless | SDL_WindowFlags.Fullscreen)))
                {
                    return WindowState.BorderlessFullScreen;
                }
                else if ((flags & SDL_WindowFlags.Minimized) == SDL_WindowFlags.Minimized)
                {
                    return WindowState.Minimized;
                }
                else if ((flags & SDL_WindowFlags.Fullscreen) == SDL_WindowFlags.Fullscreen)
                {
                    return WindowState.FullScreen;
                }
                else if ((flags & SDL_WindowFlags.Maximized) == SDL_WindowFlags.Maximized)
                {
                    return WindowState.Maximized;
                }
                else if ((flags & SDL_WindowFlags.Hidden) == SDL_WindowFlags.Hidden)
                {
                    return WindowState.Hidden;
                }

                return WindowState.Normal;
            }
            set
            {
                switch (value)
                {
                    case WindowState.Normal:
                        SDL_SetWindowFullscreen(_window, SDL_FullscreenMode.Windowed);
                        break;
                    case WindowState.FullScreen:
                        SDL_SetWindowFullscreen(_window, SDL_FullscreenMode.Fullscreen);
                        break;
                    case WindowState.Maximized:
                        SDL_MaximizeWindow(_window);
                        break;
                    case WindowState.Minimized:
                        SDL_MinimizeWindow(_window);
                        break;
                    case WindowState.BorderlessFullScreen:
                        SDL_SetWindowFullscreen(_window, SDL_FullscreenMode.FullScreenDesktop);
                        break;
                    case WindowState.Hidden:
                        SDL_HideWindow(_window);
                        break;
                    default:
                        throw new InvalidOperationException("Illegal WindowState value: " + value);
                }
            }
        }

        /// <summary>
        /// Gets the value of the exists
        /// </summary>
        public bool Exists => _exists;

        /// <summary>
        /// Gets or sets the value of the visible
        /// </summary>
        public bool Visible
        {
            get => (SDL_GetWindowFlags(_window) & SDL_WindowFlags.Shown) != 0;
            set
            {
                if (value)
                {
                    SDL_ShowWindow(_window);
                }
                else
                {
                    SDL_HideWindow(_window);
                }
            }
        }

        /// <summary>
        /// Gets the value of the scale factor
        /// </summary>
        public Vector2 ScaleFactor => Vector2.One;

        /// <summary>
        /// Gets the value of the bounds
        /// </summary>
        public Rectangle Bounds => new Rectangle(_cachedPosition, GetWindowSize());

        /// <summary>
        /// Gets or sets the value of the cursor visible
        /// </summary>
        public bool CursorVisible
        {
            get
            {
                return SDL_ShowCursor(SDL_QUERY) == 1;
            }
            set
            {
                int toggle = value ? SDL_ENABLE : SDL_DISABLE;
                SDL_ShowCursor(toggle);
            }
        }

        /// <summary>
        /// Gets or sets the value of the opacity
        /// </summary>
        public float Opacity
        {
            get
            {
                float opacity = float.NaN;
                if (SDL_GetWindowOpacity(_window, &opacity) == 0)
                {
                    return opacity;
                }
                return float.NaN;
            }
            set
            {
                SDL_SetWindowOpacity(_window, value);
            }
        }

        /// <summary>
        /// Gets the value of the focused
        /// </summary>
        public bool Focused => (SDL_GetWindowFlags(_window) & SDL_WindowFlags.InputFocus) != 0;

        /// <summary>
        /// Gets or sets the value of the resizable
        /// </summary>
        public bool Resizable
        {
            get => (SDL_GetWindowFlags(_window) & SDL_WindowFlags.Resizable) != 0;
            set => SDL_SetWindowResizable(_window, value ? 1u : 0u);
        }

        /// <summary>
        /// Gets or sets the value of the border visible
        /// </summary>
        public bool BorderVisible
        {
            get => (SDL_GetWindowFlags(_window) & SDL_WindowFlags.Borderless) == 0;
            set => SDL_SetWindowBordered(_window, value ? 1u : 0u);
        }

        /// <summary>
        /// Gets the value of the sdl window handle
        /// </summary>
        public IntPtr SdlWindowHandle => _window;

        public event Action Resized;
        public event Action Closing;
        public event Action Closed;
        public event Action FocusLost;
        public event Action FocusGained;
        public event Action Shown;
        public event Action Hidden;
        public event Action MouseEntered;
        public event Action MouseLeft;
        public event Action Exposed;
        public event Action<Point> Moved;
        public event Action<MouseWheelEventArgs> MouseWheel;
        public event Action<MouseMoveEventArgs> MouseMove;
        public event Action<MouseEvent> MouseDown;
        public event Action<MouseEvent> MouseUp;
        public event Action<KeyEvent> KeyDown;
        public event Action<KeyEvent> KeyUp;
        public event Action<DragDropEvent> DragDrop;

        /// <summary>
        /// Clients the to screen using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The point</returns>
        public Point ClientToScreen(Point p)
        {
            Point position = _cachedPosition;
            return new Point(p.X + position.X, p.Y + position.Y);
        }

        /// <summary>
        /// Sets the mouse position using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        public void SetMousePosition(Vector2 position) => SetMousePosition((int)position.X, (int)position.Y);
        /// <summary>
        /// Sets the mouse position using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public void SetMousePosition(int x, int y)
        {
            if (_exists)
            {
                SDL_WarpMouseInWindow(_window, x, y);
                _currentMouseX = x;
                _currentMouseY = y;
            }
        }

        /// <summary>
        /// Gets the value of the mouse delta
        /// </summary>
        public Vector2 MouseDelta => _currentMouseDelta;

        /// <summary>
        /// Sets the close requested handler using the specified handler
        /// </summary>
        /// <param name="handler">The handler</param>
        public void SetCloseRequestedHandler(Func<bool> handler)
        {
            _closeRequestedHandler = handler;
        }

        /// <summary>
        /// Closes this instance
        /// </summary>
        public void Close()
        {
            if (_threadedProcessing)
            {
                _shouldClose = true;
            }
            else
            {
                CloseCore();
            }
        }

        /// <summary>
        /// Describes whether this instance close core
        /// </summary>
        /// <returns>The bool</returns>
        private bool CloseCore()
        {
            if (_closeRequestedHandler?.Invoke() ?? false)
            {
                _shouldClose = false;
                return false;
            }

            Sdl2WindowRegistry.RemoveWindow(this);
            Closing?.Invoke();
            SDL_DestroyWindow(_window);
            _exists = false;
            Closed?.Invoke();

            return true;
        }

        /// <summary>
        /// Windows the owner routine using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        private void WindowOwnerRoutine(object state)
        {
            WindowParams wp = (WindowParams)state;
            _window = wp.Create();
            WindowID = SDL_GetWindowID(_window);
            Sdl2WindowRegistry.RegisterWindow(this);
            PostWindowCreated(wp.WindowFlags);
            wp.ResetEvent.Set();

            double previousPollTimeMs = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (_exists)
            {
                if (_shouldClose && CloseCore())
                {
                    return;
                }

                double currentTick = sw.ElapsedTicks;
                double currentTimeMs = sw.ElapsedTicks * (1000.0 / Stopwatch.Frequency);
                if (LimitPollRate && currentTimeMs - previousPollTimeMs < PollIntervalInMs)
                {
                    Thread.Sleep(0);
                }
                else
                {
                    previousPollTimeMs = currentTimeMs;
                    ProcessEvents(null);
                }
            }
        }

        /// <summary>
        /// Posts the window created using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        private void PostWindowCreated(SDL_WindowFlags flags)
        {
            RefreshCachedPosition();
            RefreshCachedSize();
            if ((flags & SDL_WindowFlags.Shown) == SDL_WindowFlags.Shown)
            {
                SDL_ShowWindow(_window);
            }

            _exists = true;
        }

        // Called by Sdl2EventProcessor when an event for this window is encountered.
        /// <summary>
        /// Adds the event using the specified ev
        /// </summary>
        /// <param name="ev">The ev</param>
        internal void AddEvent(SDL_Event ev)
        {
            _events.Add(ev);
        }

        /// <summary>
        /// Pumps the events
        /// </summary>
        /// <returns>The public snapshot</returns>
        public InputSnapshot PumpEvents()
        {
            _currentMouseDelta = new Vector2();
            if (_threadedProcessing)
            {
                SimpleInputSnapshot snapshot = Interlocked.Exchange(ref _privateSnapshot, _privateBackbuffer);
                snapshot.CopyTo(_publicSnapshot);
                snapshot.Clear();
            }
            else
            {
                ProcessEvents(null);
                _privateSnapshot.CopyTo(_publicSnapshot);
                _privateSnapshot.Clear();
            }

            return _publicSnapshot;
        }

        /// <summary>
        /// Processes the events using the specified event handler
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        private void ProcessEvents(SDLEventHandler eventHandler)
        {
            CheckNewWindowTitle();

            Sdl2Events.ProcessEvents();
            for (int i = 0; i < _events.Count; i++)
            {
                SDL_Event ev = _events[i];
                if (eventHandler == null)
                {
                    HandleEvent(&ev);
                }
                else
                {
                    eventHandler(ref ev);
                }
            }
            _events.Clear();
        }

        /// <summary>
        /// Pumps the events using the specified event handler
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        public void PumpEvents(SDLEventHandler eventHandler)
        {
            ProcessEvents(eventHandler);
        }

        /// <summary>
        /// Handles the event using the specified ev
        /// </summary>
        /// <param name="ev">The ev</param>
        private unsafe void HandleEvent(SDL_Event* ev)
        {
            switch (ev->type)
            {
                case SDL_EventType.Quit:
                    Close();
                    break;
                case SDL_EventType.Terminating:
                    Close();
                    break;
                case SDL_EventType.WindowEvent:
                    SDL_WindowEvent windowEvent = Unsafe.Read<SDL_WindowEvent>(ev);
                    HandleWindowEvent(windowEvent);
                    break;
                case SDL_EventType.KeyDown:
                case SDL_EventType.KeyUp:
                    SDL_KeyboardEvent keyboardEvent = Unsafe.Read<SDL_KeyboardEvent>(ev);
                    HandleKeyboardEvent(keyboardEvent);
                    break;
                case SDL_EventType.TextEditing:
                    break;
                case SDL_EventType.TextInput:
                    SDL_TextInputEvent textInputEvent = Unsafe.Read<SDL_TextInputEvent>(ev);
                    HandleTextInputEvent(textInputEvent);
                    break;
                case SDL_EventType.KeyMapChanged:
                    break;
                case SDL_EventType.MouseMotion:
                    SDL_MouseMotionEvent mouseMotionEvent = Unsafe.Read<SDL_MouseMotionEvent>(ev);
                    HandleMouseMotionEvent(mouseMotionEvent);
                    break;
                case SDL_EventType.MouseButtonDown:
                case SDL_EventType.MouseButtonUp:
                    SDL_MouseButtonEvent mouseButtonEvent = Unsafe.Read<SDL_MouseButtonEvent>(ev);
                    HandleMouseButtonEvent(mouseButtonEvent);
                    break;
                case SDL_EventType.MouseWheel:
                    SDL_MouseWheelEvent mouseWheelEvent = Unsafe.Read<SDL_MouseWheelEvent>(ev);
                    HandleMouseWheelEvent(mouseWheelEvent);
                    break;
                case SDL_EventType.DropFile:
                case SDL_EventType.DropBegin:
                case SDL_EventType.DropTest:
                    SDL_DropEvent dropEvent = Unsafe.Read<SDL_DropEvent>(ev);
                    HandleDropEvent(dropEvent);
                    break;
                default:
                    // Ignore
                    break;
            }
        }

        /// <summary>
        /// Checks the new window title
        /// </summary>
        private void CheckNewWindowTitle()
        {
            if (WindowState != WindowState.Minimized && _newWindowTitleReceived)
            {
                _newWindowTitleReceived = false;
                SDL_SetWindowTitle(_window, _cachedWindowTitle);
            }
        }

        /// <summary>
        /// Handles the text input event using the specified text input event
        /// </summary>
        /// <param name="textInputEvent">The text input event</param>
        private void HandleTextInputEvent(SDL_TextInputEvent textInputEvent)
        {
            uint byteCount = 0;
            // Loop until the null terminator is found or the max size is reached.
            while (byteCount < SDL_TextInputEvent.MaxTextSize && textInputEvent.text[byteCount++] != 0)
            { }

            if (byteCount > 1)
            {
                // We don't want the null terminator.
                byteCount -= 1;
                int charCount = Encoding.UTF8.GetCharCount(textInputEvent.text, (int)byteCount);
                char* charsPtr = stackalloc char[charCount];
                Encoding.UTF8.GetChars(textInputEvent.text, (int)byteCount, charsPtr, charCount);
                for (int i = 0; i < charCount; i++)
                {
                    _privateSnapshot.KeyCharPressesList.Add(charsPtr[i]);
                }
            }
        }

        /// <summary>
        /// Handles the mouse wheel event using the specified mouse wheel event
        /// </summary>
        /// <param name="mouseWheelEvent">The mouse wheel event</param>
        private void HandleMouseWheelEvent(SDL_MouseWheelEvent mouseWheelEvent)
        {
            _privateSnapshot.WheelDelta += mouseWheelEvent.y;
            MouseWheel?.Invoke(new MouseWheelEventArgs(GetCurrentMouseState(), (float)mouseWheelEvent.y));
        }

        /// <summary>
        /// Handles the drop event using the specified drop event
        /// </summary>
        /// <param name="dropEvent">The drop event</param>
        private void HandleDropEvent(SDL_DropEvent dropEvent)
        {
            string file = Utilities.GetString(dropEvent.file);
            SDL_free(dropEvent.file);

            if (dropEvent.type == SDL_EventType.DropFile)
            {
                DragDrop?.Invoke(new DragDropEvent(file));
            }
        }

        /// <summary>
        /// Handles the mouse button event using the specified mouse button event
        /// </summary>
        /// <param name="mouseButtonEvent">The mouse button event</param>
        private void HandleMouseButtonEvent(SDL_MouseButtonEvent mouseButtonEvent)
        {
            MouseButton button = MapMouseButton(mouseButtonEvent.button);
            bool down = mouseButtonEvent.state == 1;
            _currentMouseButtonStates[(int)button] = down;
            _privateSnapshot.MouseDown[(int)button] = down;
            MouseEvent mouseEvent = new MouseEvent(button, down);
            _privateSnapshot.MouseEventsList.Add(mouseEvent);
            if (down)
            {
                MouseDown?.Invoke(mouseEvent);
            }
            else
            {
                MouseUp?.Invoke(mouseEvent);
            }
        }

        /// <summary>
        /// Maps the mouse button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The mouse button</returns>
        private MouseButton MapMouseButton(SDL_MouseButton button)
        {
            switch (button)
            {
                case SDL_MouseButton.Left:
                    return MouseButton.Left;
                case SDL_MouseButton.Middle:
                    return MouseButton.Middle;
                case SDL_MouseButton.Right:
                    return MouseButton.Right;
                case SDL_MouseButton.X1:
                    return MouseButton.Button1;
                case SDL_MouseButton.X2:
                    return MouseButton.Button2;
                default:
                    return MouseButton.Left;
            }
        }

        /// <summary>
        /// Handles the mouse motion event using the specified mouse motion event
        /// </summary>
        /// <param name="mouseMotionEvent">The mouse motion event</param>
        private void HandleMouseMotionEvent(SDL_MouseMotionEvent mouseMotionEvent)
        {
            Vector2 mousePos = new Vector2(mouseMotionEvent.x, mouseMotionEvent.y);
            Vector2 delta = new Vector2(mouseMotionEvent.xrel, mouseMotionEvent.yrel);
            _currentMouseX = (int)mousePos.X;
            _currentMouseY = (int)mousePos.Y;
            _privateSnapshot.MousePosition = mousePos;

            if (!_firstMouseEvent)
            {
                _currentMouseDelta += delta;
                MouseMove?.Invoke(new MouseMoveEventArgs(GetCurrentMouseState(), mousePos));
            }

            _firstMouseEvent = false;
        }

        /// <summary>
        /// Handles the keyboard event using the specified keyboard event
        /// </summary>
        /// <param name="keyboardEvent">The keyboard event</param>
        private void HandleKeyboardEvent(SDL_KeyboardEvent keyboardEvent)
        {
            SimpleInputSnapshot snapshot = _privateSnapshot;
            KeyEvent keyEvent = new KeyEvent(MapKey(keyboardEvent.keysym), keyboardEvent.state == 1, MapModifierKeys(keyboardEvent.keysym.mod), keyboardEvent.repeat == 1);
            snapshot.KeyEventsList.Add(keyEvent);
            if (keyboardEvent.state == 1)
            {
                KeyDown?.Invoke(keyEvent);
            }
            else
            {
                KeyUp?.Invoke(keyEvent);
            }
        }

        /// <summary>
        /// Maps the key using the specified keysym
        /// </summary>
        /// <param name="keysym">The keysym</param>
        /// <returns>The key</returns>
        private Key MapKey(SDL_Keysym keysym)
        {
            switch (keysym.scancode)
            {
                case SDL_Scancode.SDL_SCANCODE_A:
                    return Key.A;
                case SDL_Scancode.SDL_SCANCODE_B:
                    return Key.B;
                case SDL_Scancode.SDL_SCANCODE_C:
                    return Key.C;
                case SDL_Scancode.SDL_SCANCODE_D:
                    return Key.D;
                case SDL_Scancode.SDL_SCANCODE_E:
                    return Key.E;
                case SDL_Scancode.SDL_SCANCODE_F:
                    return Key.F;
                case SDL_Scancode.SDL_SCANCODE_G:
                    return Key.G;
                case SDL_Scancode.SDL_SCANCODE_H:
                    return Key.H;
                case SDL_Scancode.SDL_SCANCODE_I:
                    return Key.I;
                case SDL_Scancode.SDL_SCANCODE_J:
                    return Key.J;
                case SDL_Scancode.SDL_SCANCODE_K:
                    return Key.K;
                case SDL_Scancode.SDL_SCANCODE_L:
                    return Key.L;
                case SDL_Scancode.SDL_SCANCODE_M:
                    return Key.M;
                case SDL_Scancode.SDL_SCANCODE_N:
                    return Key.N;
                case SDL_Scancode.SDL_SCANCODE_O:
                    return Key.O;
                case SDL_Scancode.SDL_SCANCODE_P:
                    return Key.P;
                case SDL_Scancode.SDL_SCANCODE_Q:
                    return Key.Q;
                case SDL_Scancode.SDL_SCANCODE_R:
                    return Key.R;
                case SDL_Scancode.SDL_SCANCODE_S:
                    return Key.S;
                case SDL_Scancode.SDL_SCANCODE_T:
                    return Key.T;
                case SDL_Scancode.SDL_SCANCODE_U:
                    return Key.U;
                case SDL_Scancode.SDL_SCANCODE_V:
                    return Key.V;
                case SDL_Scancode.SDL_SCANCODE_W:
                    return Key.W;
                case SDL_Scancode.SDL_SCANCODE_X:
                    return Key.X;
                case SDL_Scancode.SDL_SCANCODE_Y:
                    return Key.Y;
                case SDL_Scancode.SDL_SCANCODE_Z:
                    return Key.Z;
                case SDL_Scancode.SDL_SCANCODE_1:
                    return Key.Number1;
                case SDL_Scancode.SDL_SCANCODE_2:
                    return Key.Number2;
                case SDL_Scancode.SDL_SCANCODE_3:
                    return Key.Number3;
                case SDL_Scancode.SDL_SCANCODE_4:
                    return Key.Number4;
                case SDL_Scancode.SDL_SCANCODE_5:
                    return Key.Number5;
                case SDL_Scancode.SDL_SCANCODE_6:
                    return Key.Number6;
                case SDL_Scancode.SDL_SCANCODE_7:
                    return Key.Number7;
                case SDL_Scancode.SDL_SCANCODE_8:
                    return Key.Number8;
                case SDL_Scancode.SDL_SCANCODE_9:
                    return Key.Number9;
                case SDL_Scancode.SDL_SCANCODE_0:
                    return Key.Number0;
                case SDL_Scancode.SDL_SCANCODE_RETURN:
                    return Key.Enter;
                case SDL_Scancode.SDL_SCANCODE_ESCAPE:
                    return Key.Escape;
                case SDL_Scancode.SDL_SCANCODE_BACKSPACE:
                    return Key.BackSpace;
                case SDL_Scancode.SDL_SCANCODE_TAB:
                    return Key.Tab;
                case SDL_Scancode.SDL_SCANCODE_SPACE:
                    return Key.Space;
                case SDL_Scancode.SDL_SCANCODE_MINUS:
                    return Key.Minus;
                case SDL_Scancode.SDL_SCANCODE_EQUALS:
                    return Key.Plus;
                case SDL_Scancode.SDL_SCANCODE_LEFTBRACKET:
                    return Key.BracketLeft;
                case SDL_Scancode.SDL_SCANCODE_RIGHTBRACKET:
                    return Key.BracketRight;
                case SDL_Scancode.SDL_SCANCODE_BACKSLASH:
                    return Key.BackSlash;
                case SDL_Scancode.SDL_SCANCODE_SEMICOLON:
                    return Key.Semicolon;
                case SDL_Scancode.SDL_SCANCODE_APOSTROPHE:
                    return Key.Quote;
                case SDL_Scancode.SDL_SCANCODE_GRAVE:
                    return Key.Grave;
                case SDL_Scancode.SDL_SCANCODE_COMMA:
                    return Key.Comma;
                case SDL_Scancode.SDL_SCANCODE_PERIOD:
                    return Key.Period;
                case SDL_Scancode.SDL_SCANCODE_SLASH:
                    return Key.Slash;
                case SDL_Scancode.SDL_SCANCODE_CAPSLOCK:
                    return Key.CapsLock;
                case SDL_Scancode.SDL_SCANCODE_F1:
                    return Key.F1;
                case SDL_Scancode.SDL_SCANCODE_F2:
                    return Key.F2;
                case SDL_Scancode.SDL_SCANCODE_F3:
                    return Key.F3;
                case SDL_Scancode.SDL_SCANCODE_F4:
                    return Key.F4;
                case SDL_Scancode.SDL_SCANCODE_F5:
                    return Key.F5;
                case SDL_Scancode.SDL_SCANCODE_F6:
                    return Key.F6;
                case SDL_Scancode.SDL_SCANCODE_F7:
                    return Key.F7;
                case SDL_Scancode.SDL_SCANCODE_F8:
                    return Key.F8;
                case SDL_Scancode.SDL_SCANCODE_F9:
                    return Key.F9;
                case SDL_Scancode.SDL_SCANCODE_F10:
                    return Key.F10;
                case SDL_Scancode.SDL_SCANCODE_F11:
                    return Key.F11;
                case SDL_Scancode.SDL_SCANCODE_F12:
                    return Key.F12;
                case SDL_Scancode.SDL_SCANCODE_PRINTSCREEN:
                    return Key.PrintScreen;
                case SDL_Scancode.SDL_SCANCODE_SCROLLLOCK:
                    return Key.ScrollLock;
                case SDL_Scancode.SDL_SCANCODE_PAUSE:
                    return Key.Pause;
                case SDL_Scancode.SDL_SCANCODE_INSERT:
                    return Key.Insert;
                case SDL_Scancode.SDL_SCANCODE_HOME:
                    return Key.Home;
                case SDL_Scancode.SDL_SCANCODE_PAGEUP:
                    return Key.PageUp;
                case SDL_Scancode.SDL_SCANCODE_DELETE:
                    return Key.Delete;
                case SDL_Scancode.SDL_SCANCODE_END:
                    return Key.End;
                case SDL_Scancode.SDL_SCANCODE_PAGEDOWN:
                    return Key.PageDown;
                case SDL_Scancode.SDL_SCANCODE_RIGHT:
                    return Key.Right;
                case SDL_Scancode.SDL_SCANCODE_LEFT:
                    return Key.Left;
                case SDL_Scancode.SDL_SCANCODE_DOWN:
                    return Key.Down;
                case SDL_Scancode.SDL_SCANCODE_UP:
                    return Key.Up;
                case SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR:
                    return Key.NumLock;
                case SDL_Scancode.SDL_SCANCODE_KP_DIVIDE:
                    return Key.KeypadDivide;
                case SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY:
                    return Key.KeypadMultiply;
                case SDL_Scancode.SDL_SCANCODE_KP_MINUS:
                    return Key.KeypadMinus;
                case SDL_Scancode.SDL_SCANCODE_KP_PLUS:
                    return Key.KeypadPlus;
                case SDL_Scancode.SDL_SCANCODE_KP_ENTER:
                    return Key.KeypadEnter;
                case SDL_Scancode.SDL_SCANCODE_KP_1:
                    return Key.Keypad1;
                case SDL_Scancode.SDL_SCANCODE_KP_2:
                    return Key.Keypad2;
                case SDL_Scancode.SDL_SCANCODE_KP_3:
                    return Key.Keypad3;
                case SDL_Scancode.SDL_SCANCODE_KP_4:
                    return Key.Keypad4;
                case SDL_Scancode.SDL_SCANCODE_KP_5:
                    return Key.Keypad5;
                case SDL_Scancode.SDL_SCANCODE_KP_6:
                    return Key.Keypad6;
                case SDL_Scancode.SDL_SCANCODE_KP_7:
                    return Key.Keypad7;
                case SDL_Scancode.SDL_SCANCODE_KP_8:
                    return Key.Keypad8;
                case SDL_Scancode.SDL_SCANCODE_KP_9:
                    return Key.Keypad9;
                case SDL_Scancode.SDL_SCANCODE_KP_0:
                    return Key.Keypad0;
                case SDL_Scancode.SDL_SCANCODE_KP_PERIOD:
                    return Key.KeypadPeriod;
                case SDL_Scancode.SDL_SCANCODE_NONUSBACKSLASH:
                    return Key.NonUSBackSlash;
                case SDL_Scancode.SDL_SCANCODE_KP_EQUALS:
                    return Key.KeypadPlus;
                case SDL_Scancode.SDL_SCANCODE_F13:
                    return Key.F13;
                case SDL_Scancode.SDL_SCANCODE_F14:
                    return Key.F14;
                case SDL_Scancode.SDL_SCANCODE_F15:
                    return Key.F15;
                case SDL_Scancode.SDL_SCANCODE_F16:
                    return Key.F16;
                case SDL_Scancode.SDL_SCANCODE_F17:
                    return Key.F17;
                case SDL_Scancode.SDL_SCANCODE_F18:
                    return Key.F18;
                case SDL_Scancode.SDL_SCANCODE_F19:
                    return Key.F19;
                case SDL_Scancode.SDL_SCANCODE_F20:
                    return Key.F20;
                case SDL_Scancode.SDL_SCANCODE_F21:
                    return Key.F21;
                case SDL_Scancode.SDL_SCANCODE_F22:
                    return Key.F22;
                case SDL_Scancode.SDL_SCANCODE_F23:
                    return Key.F23;
                case SDL_Scancode.SDL_SCANCODE_F24:
                    return Key.F24;
                case SDL_Scancode.SDL_SCANCODE_MENU:
                    return Key.Menu;
                case SDL_Scancode.SDL_SCANCODE_LCTRL:
                    return Key.ControlLeft;
                case SDL_Scancode.SDL_SCANCODE_LSHIFT:
                    return Key.ShiftLeft;
                case SDL_Scancode.SDL_SCANCODE_LALT:
                    return Key.AltLeft;
                case SDL_Scancode.SDL_SCANCODE_RCTRL:
                    return Key.ControlRight;
                case SDL_Scancode.SDL_SCANCODE_RSHIFT:
                    return Key.ShiftRight;
                case SDL_Scancode.SDL_SCANCODE_RALT:
                    return Key.AltRight;
                case SDL_Scancode.SDL_SCANCODE_LGUI:
                    return Key.LWin;
                case SDL_Scancode.SDL_SCANCODE_RGUI:
                    return Key.RWin;
                default:
                    return Key.Unknown;
            }
        }

        /// <summary>
        /// Maps the modifier keys using the specified mod
        /// </summary>
        /// <param name="mod">The mod</param>
        /// <returns>The mods</returns>
        private ModifierKeys MapModifierKeys(SDL_Keymod mod)
        {
            ModifierKeys mods = ModifierKeys.None;
            if ((mod & (SDL_Keymod.LeftShift | SDL_Keymod.RightShift)) != 0)
            {
                mods |= ModifierKeys.Shift;
            }
            if ((mod & (SDL_Keymod.LeftAlt | SDL_Keymod.RightAlt)) != 0)
            {
                mods |= ModifierKeys.Alt;
            }
            if ((mod & (SDL_Keymod.LeftControl | SDL_Keymod.RightControl)) != 0)
            {
                mods |= ModifierKeys.Control;
            }
            if ((mod & (SDL_Keymod.LeftGui | SDL_Keymod.RightGui)) != 0)
            {
                mods |= ModifierKeys.Gui;
            }

            return mods;
        }

        /// <summary>
        /// Handles the window event using the specified window event
        /// </summary>
        /// <param name="windowEvent">The window event</param>
        private void HandleWindowEvent(SDL_WindowEvent windowEvent)
        {
            switch (windowEvent.@event)
            {
                case SDL_WindowEventID.Resized:
                case SDL_WindowEventID.SizeChanged:
                case SDL_WindowEventID.Minimized:
                case SDL_WindowEventID.Maximized:
                case SDL_WindowEventID.Restored:
                    HandleResizedMessage();
                    break;
                case SDL_WindowEventID.FocusGained:
                    FocusGained?.Invoke();
                    break;
                case SDL_WindowEventID.FocusLost:
                    FocusLost?.Invoke();
                    break;
                case SDL_WindowEventID.Close:
                    Close();
                    break;
                case SDL_WindowEventID.Shown:
                    Shown?.Invoke();
                    break;
                case SDL_WindowEventID.Hidden:
                    Hidden?.Invoke();
                    break;
                case SDL_WindowEventID.Enter:
                    MouseEntered?.Invoke();
                    break;
                case SDL_WindowEventID.Leave:
                    MouseLeft?.Invoke();
                    break;
                case SDL_WindowEventID.Exposed:
                    Exposed?.Invoke();
                    break;
                case SDL_WindowEventID.Moved:
                    _cachedPosition.Value = new Point(windowEvent.data1, windowEvent.data2);
                    Moved?.Invoke(new Point(windowEvent.data1, windowEvent.data2));
                    break;
                default:
                    Debug.WriteLine("Unhandled SDL WindowEvent: " + windowEvent.@event);
                    break;
            }
        }

        /// <summary>
        /// Handles the resized message
        /// </summary>
        private void HandleResizedMessage()
        {
            RefreshCachedSize();
            Resized?.Invoke();
        }

        /// <summary>
        /// Refreshes the cached size
        /// </summary>
        private void RefreshCachedSize()
        {
            int w, h;
            SDL_GetWindowSize(_window, &w, &h);
            _cachedSize.Value = new Point(w, h);
        }

        /// <summary>
        /// Refreshes the cached position
        /// </summary>
        private void RefreshCachedPosition()
        {
            int x, y;
            SDL_GetWindowPosition(_window, &x, &y);
            _cachedPosition.Value = new Point(x, y);
        }

        /// <summary>
        /// Gets the current mouse state
        /// </summary>
        /// <returns>The mouse state</returns>
        private MouseState GetCurrentMouseState()
        {
            return new MouseState(
                _currentMouseX, _currentMouseY,
                _currentMouseButtonStates[0], _currentMouseButtonStates[1],
                _currentMouseButtonStates[2], _currentMouseButtonStates[3],
                _currentMouseButtonStates[4], _currentMouseButtonStates[5],
                _currentMouseButtonStates[6], _currentMouseButtonStates[7],
                _currentMouseButtonStates[8], _currentMouseButtonStates[9],
                _currentMouseButtonStates[10], _currentMouseButtonStates[11],
                _currentMouseButtonStates[12]);
        }

        /// <summary>
        /// Screens the to client using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The point</returns>
        public Point ScreenToClient(Point p)
        {
            Point position = _cachedPosition;
            return new Point(p.X - position.X, p.Y - position.Y);
        }

        /// <summary>
        /// Sets the window position using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        private void SetWindowPosition(int x, int y)
        {
            SDL_SetWindowPosition(_window, x, y);
            _cachedPosition.Value = new Point(x, y);
        }

        /// <summary>
        /// Gets the window size
        /// </summary>
        /// <returns>The cached size</returns>
        private Point GetWindowSize()
        {
            return _cachedSize;
        }

        /// <summary>
        /// Sets the window size using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void SetWindowSize(int width, int height)
        {
            SDL_SetWindowSize(_window, width, height);
            _cachedSize.Value = new Point(width, height);
        }

        /// <summary>
        /// Gets the underlying window handle
        /// </summary>
        /// <returns>The int ptr</returns>
        private IntPtr GetUnderlyingWindowHandle()
        {
            SDL_SysWMinfo wmInfo;
            SDL_GetVersion(&wmInfo.version);
            SDL_GetWMWindowInfo(_window, &wmInfo);
            switch (wmInfo.subsystem)
            {
                case SysWMType.Windows:
                    Win32WindowInfo win32Info = Unsafe.Read<Win32WindowInfo>(&wmInfo.info);
                    return win32Info.Sdl2Window;
                case SysWMType.X11:
                    X11WindowInfo x11Info = Unsafe.Read<X11WindowInfo>(&wmInfo.info);
                    return x11Info.Sdl2Window;
                case SysWMType.Wayland:
                    WaylandWindowInfo waylandInfo = Unsafe.Read<WaylandWindowInfo>(&wmInfo.info);
                    return waylandInfo.surface;
                case SysWMType.Cocoa:
                    CocoaWindowInfo cocoaInfo = Unsafe.Read<CocoaWindowInfo>(&wmInfo.info);
                    return cocoaInfo.Window;
                case SysWMType.Android:
                    AndroidWindowInfo androidInfo = Unsafe.Read<AndroidWindowInfo>(&wmInfo.info);
                    return androidInfo.window;
                default:
                    return _window;
            }
        }

        /// <summary>
        /// The simple input snapshot class
        /// </summary>
        /// <seealso cref="InputSnapshot"/>
        private class SimpleInputSnapshot : InputSnapshot
        {
            /// <summary>
            /// Gets or sets the value of the key events list
            /// </summary>
            public List<KeyEvent> KeyEventsList { get; private set; } = new List<KeyEvent>();
            /// <summary>
            /// Gets or sets the value of the mouse events list
            /// </summary>
            public List<MouseEvent> MouseEventsList { get; private set; } = new List<MouseEvent>();
            /// <summary>
            /// Gets or sets the value of the key char presses list
            /// </summary>
            public List<char> KeyCharPressesList { get; private set; } = new List<char>();

            /// <summary>
            /// Gets the value of the key events
            /// </summary>
            public IReadOnlyList<KeyEvent> KeyEvents => KeyEventsList;

            /// <summary>
            /// Gets the value of the mouse events
            /// </summary>
            public IReadOnlyList<MouseEvent> MouseEvents => MouseEventsList;

            /// <summary>
            /// Gets the value of the key char presses
            /// </summary>
            public IReadOnlyList<char> KeyCharPresses => KeyCharPressesList;

            /// <summary>
            /// Gets or sets the value of the mouse position
            /// </summary>
            public Vector2 MousePosition { get; set; }

            /// <summary>
            /// The mouse down
            /// </summary>
            private bool[] _mouseDown = new bool[13];
            /// <summary>
            /// Gets the value of the mouse down
            /// </summary>
            public bool[] MouseDown => _mouseDown;
            /// <summary>
            /// Gets or sets the value of the wheel delta
            /// </summary>
            public float WheelDelta { get; set; }

            /// <summary>
            /// Describes whether this instance is mouse down
            /// </summary>
            /// <param name="button">The button</param>
            /// <returns>The bool</returns>
            public bool IsMouseDown(MouseButton button)
            {
                return _mouseDown[(int)button];
            }

            /// <summary>
            /// Clears this instance
            /// </summary>
            internal void Clear()
            {
                KeyEventsList.Clear();
                MouseEventsList.Clear();
                KeyCharPressesList.Clear();
                WheelDelta = 0f;
            }

            /// <summary>
            /// Copies the to using the specified other
            /// </summary>
            /// <param name="other">The other</param>
            public void CopyTo(SimpleInputSnapshot other)
            {
                Debug.Assert(this != other);

                other.MouseEventsList.Clear();
                foreach (var me in MouseEventsList) { other.MouseEventsList.Add(me); }

                other.KeyEventsList.Clear();
                foreach (var ke in KeyEventsList) { other.KeyEventsList.Add(ke); }

                other.KeyCharPressesList.Clear();
                foreach (var kcp in KeyCharPressesList) { other.KeyCharPressesList.Add(kcp); }

                other.MousePosition = MousePosition;
                other.WheelDelta = WheelDelta;
                _mouseDown.CopyTo(other._mouseDown, 0);
            }
        }

        /// <summary>
        /// The window params class
        /// </summary>
        private class WindowParams
        {
            /// <summary>
            /// Gets or sets the value of the x
            /// </summary>
            public int X { get; set; }
            /// <summary>
            /// Gets or sets the value of the y
            /// </summary>
            public int Y { get; set; }
            /// <summary>
            /// Gets or sets the value of the width
            /// </summary>
            public int Width { get; set; }
            /// <summary>
            /// Gets or sets the value of the height
            /// </summary>
            public int Height { get; set; }
            /// <summary>
            /// Gets or sets the value of the title
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Gets or sets the value of the window flags
            /// </summary>
            public SDL_WindowFlags WindowFlags { get; set; }

            /// <summary>
            /// Gets or sets the value of the window handle
            /// </summary>
            public IntPtr WindowHandle { get; set; }

            /// <summary>
            /// Gets or sets the value of the reset event
            /// </summary>
            public ManualResetEvent ResetEvent { get; set; }

            /// <summary>
            /// Creates this instance
            /// </summary>
            /// <returns>The sdl window</returns>
            public SDL_Window Create()
            {
                if (WindowHandle != IntPtr.Zero)
                {
                    return SDL_CreateWindowFrom(WindowHandle);
                }
                else
                {
                    return SDL_CreateWindow(Title, X, Y, Width, Height, WindowFlags);
                }
            }
        }
    }

    /// <summary>
    /// The mouse state
    /// </summary>
    public struct MouseState
    {
        /// <summary>
        /// The 
        /// </summary>
        public readonly int X;
        /// <summary>
        /// The 
        /// </summary>
        public readonly int Y;

        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown0;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown1;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown2;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown3;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown4;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown5;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown6;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown7;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown8;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown9;
        /// <summary>
        /// The mouse down 10
        /// </summary>
        private bool _mouseDown10;
        /// <summary>
        /// The mouse down 11
        /// </summary>
        private bool _mouseDown11;
        /// <summary>
        /// The mouse down 12
        /// </summary>
        private bool _mouseDown12;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseState"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="mouse0">The mouse</param>
        /// <param name="mouse1">The mouse</param>
        /// <param name="mouse2">The mouse</param>
        /// <param name="mouse3">The mouse</param>
        /// <param name="mouse4">The mouse</param>
        /// <param name="mouse5">The mouse</param>
        /// <param name="mouse6">The mouse</param>
        /// <param name="mouse7">The mouse</param>
        /// <param name="mouse8">The mouse</param>
        /// <param name="mouse9">The mouse</param>
        /// <param name="mouse10">The mouse 10</param>
        /// <param name="mouse11">The mouse 11</param>
        /// <param name="mouse12">The mouse 12</param>
        public MouseState(
            int x, int y,
            bool mouse0, bool mouse1, bool mouse2, bool mouse3, bool mouse4, bool mouse5, bool mouse6,
            bool mouse7, bool mouse8, bool mouse9, bool mouse10, bool mouse11, bool mouse12)
        {
            X = x;
            Y = y;
            _mouseDown0 = mouse0;
            _mouseDown1 = mouse1;
            _mouseDown2 = mouse2;
            _mouseDown3 = mouse3;
            _mouseDown4 = mouse4;
            _mouseDown5 = mouse5;
            _mouseDown6 = mouse6;
            _mouseDown7 = mouse7;
            _mouseDown8 = mouse8;
            _mouseDown9 = mouse9;
            _mouseDown10 = mouse10;
            _mouseDown11 = mouse11;
            _mouseDown12 = mouse12;
        }

        /// <summary>
        /// Describes whether this instance is button down
        /// </summary>
        /// <param name="button">The button</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The bool</returns>
        public bool IsButtonDown(MouseButton button)
        {
            uint index = (uint)button;
            switch (index)
            {
                case 0:
                    return _mouseDown0;
                case 1:
                    return _mouseDown1;
                case 2:
                    return _mouseDown2;
                case 3:
                    return _mouseDown3;
                case 4:
                    return _mouseDown4;
                case 5:
                    return _mouseDown5;
                case 6:
                    return _mouseDown6;
                case 7:
                    return _mouseDown7;
                case 8:
                    return _mouseDown8;
                case 9:
                    return _mouseDown9;
                case 10:
                    return _mouseDown10;
                case 11:
                    return _mouseDown11;
                case 12:
                    return _mouseDown12;
            }

            throw new ArgumentOutOfRangeException(nameof(button));
        }
    }

    /// <summary>
    /// The mouse wheel event args
    /// </summary>
    public struct MouseWheelEventArgs
    {
        /// <summary>
        /// Gets the value of the state
        /// </summary>
        public MouseState State { get; }
        /// <summary>
        /// Gets the value of the wheel delta
        /// </summary>
        public float WheelDelta { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseWheelEventArgs"/> class
        /// </summary>
        /// <param name="mouseState">The mouse state</param>
        /// <param name="wheelDelta">The wheel delta</param>
        public MouseWheelEventArgs(MouseState mouseState, float wheelDelta)
        {
            State = mouseState;
            WheelDelta = wheelDelta;
        }
    }

    /// <summary>
    /// The mouse move event args
    /// </summary>
    public struct MouseMoveEventArgs
    {
        /// <summary>
        /// Gets the value of the state
        /// </summary>
        public MouseState State { get; }
        /// <summary>
        /// Gets the value of the mouse position
        /// </summary>
        public Vector2 MousePosition { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseMoveEventArgs"/> class
        /// </summary>
        /// <param name="mouseState">The mouse state</param>
        /// <param name="mousePosition">The mouse position</param>
        public MouseMoveEventArgs(MouseState mouseState, Vector2 mousePosition)
        {
            State = mouseState;
            MousePosition = mousePosition;
        }
    }

    /// <summary>
    /// The buffered value class
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplayString,nq}")]
    public class BufferedValue<T> where T : struct
    {
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public T Value
        {
            get => Current.Value;
            set
            {
                Back.Value = value;
                Back = Interlocked.Exchange(ref Current, Back);
            }
        }

        /// <summary>
        /// The value holder
        /// </summary>
        private ValueHolder Current = new ValueHolder();
        /// <summary>
        /// The value holder
        /// </summary>
        private ValueHolder Back = new ValueHolder();

        public static implicit operator T(BufferedValue<T> bv) => bv.Value;

        /// <summary>
        /// Gets the value of the debugger display string
        /// </summary>
        private string DebuggerDisplayString => $"{Current.Value}";

        /// <summary>
        /// The value holder class
        /// </summary>
        private class ValueHolder
        {
            /// <summary>
            /// The value
            /// </summary>
            public T Value;
        }
    }

    /// <summary>
    /// The sdl event handler
    /// </summary>
    public delegate void SDLEventHandler(ref SDL_Event ev);
}
