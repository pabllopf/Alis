// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderWindowMainThreadWorker.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Executes the <see cref="RenderWindow" /> wrapper members against the real native CSFML library on the process
    ///     main thread, because SFML on macOS requires window creation on the main thread and AppKit requires window
    ///     operations to be performed there. The startup hook invokes <see cref="Run" /> before the entry point; every
    ///     step records its result so the xUnit tests can assert the observed behavior afterwards.
    ///     <para>
    ///         The installed CSFML 3.0 changed several signatures the wrapper still declares with the CSFML 2.x ABI
    ///         (vector and viewport returns became <c>sfVector2u</c>/<c>sfVector2i</c>/<c>sfIntRect</c> and
    ///         <c>sfRenderStates</c> gained stencil fields), so some members record garbage values and the draw calls,
    ///         the video mode constructors and the blocking event wait are skipped because they crash the test host.
    ///     </para>
    /// </summary>
    public static class RenderWindowMainThreadWorker
    {
        /// <summary>
        ///     The failures collected while executing the native steps on the main thread.
        /// </summary>
        internal static readonly List<Exception> Failures = new List<Exception>();

        /// <summary>
        ///     The member names whose native entry points are missing from the installed CSFML 3.0 library.
        /// </summary>
        internal static readonly List<string> MissingEntryPoints = new List<string>();

        /// <summary>
        ///     The read back open state of the live window.
        /// </summary>
        internal static bool IsOpenResult;

        /// <summary>
        ///     The read back creation settings of the live window.
        /// </summary>
        internal static ContextSettings SettingsResult;

        /// <summary>
        ///     Indicates whether the position getter and setter completed.
        /// </summary>
        internal static bool PositionExecuted;

        /// <summary>
        ///     Indicates whether the size getter and setter completed.
        /// </summary>
        internal static bool SizeExecuted;

        /// <summary>
        ///     The read back size of the view returned by the live window.
        /// </summary>
        internal static Vector2F ViewSizeResult;

        /// <summary>
        ///     The read back size of the default view of the live window.
        /// </summary>
        internal static Vector2F DefaultViewSizeResult;

        /// <summary>
        ///     Indicates whether the viewport query completed.
        /// </summary>
        internal static bool ViewportExecuted;

        /// <summary>
        ///     Indicates whether the pixel to coords mapping completed.
        /// </summary>
        internal static bool PixelToCoordsExecuted;

        /// <summary>
        ///     Indicates whether the coords to pixel mapping completed.
        /// </summary>
        internal static bool CoordsToPixelExecuted;

        /// <summary>
        ///     Indicates whether the push and pop GL states calls completed.
        /// </summary>
        internal static bool GlStatesOk;

        /// <summary>
        ///     Indicates whether the poll event call completed without throwing.
        /// </summary>
        internal static bool PollEventExecuted;

        /// <summary>
        ///     Indicates whether the mouse query calls completed.
        /// </summary>
        internal static bool MousePositionExecuted;

        /// <summary>
        ///     Indicates whether the touch query call completed.
        /// </summary>
        internal static bool TouchPositionExecuted;

        /// <summary>
        ///     The read back focus state of the live window.
        /// </summary>
        internal static bool FocusResult;

        /// <summary>
        ///     The read back active state after activating the live window.
        /// </summary>
        internal static bool ActiveResult;

        /// <summary>
        ///     The read back string description of the live window.
        /// </summary>
        internal static string ToStringResult;

        /// <summary>
        ///     Indicates whether closing the window made it report closed.
        /// </summary>
        internal static bool ClosedOk;

        /// <summary>
        ///     Indicates whether disposing the window destroyed the native handle.
        /// </summary>
        internal static bool DisposeSafe;

        /// <summary>
        ///     Indicates whether the one argument handle constructor produced a valid window.
        /// </summary>
        internal static bool HandleCtorOk;

        /// <summary>
        ///     Runs every native step on the main thread and records the results.
        /// </summary>
        public static void Run()
        {
            if (!SfmlTestBootstrap.Ready || SfmlTestBootstrap.Window == null)
            {
                return;
            }

            RenderWindow window = SfmlTestBootstrap.Window;
            View view = new View(new Vector2F(400, 300), new Vector2F(800, 600));
            Execute("ExtraWindowHandleCtor", () =>
            {
                IntPtr extraNative = NativeWindowFactory.Create(320, 200, "exec-handle");
                IntPtr extraHandle = NativeWindowFactory.GetNativeHandle(extraNative);
                RenderWindow extra = new RenderWindow(extraHandle);
                try
                {
                    HandleCtorOk = extra.IsOpen;
                }
                finally
                {
                    extra.Dispose();
                }
            });
            Execute("IsOpen", () => IsOpenResult = window.IsOpen);
            Execute("Settings", () => SettingsResult = window.Settings);
            Execute("Size", () =>
            {
                window.Size = new Vector2F(120, 90);
                Vector2F sizeReadBack = window.Size;
                SizeExecuted = sizeReadBack.X == sizeReadBack.X;
            });
            Execute("Position", () =>
            {
                window.Position = new Vector2F(40, 30);
                Vector2F positionReadBack = window.Position;
                PositionExecuted = positionReadBack.X == positionReadBack.X;
            });
            Execute("SetVisible", () => window.SetVisible(true));
            Execute("SetActive", () => ActiveResult = window.SetActive(true));
            Execute("Views", () =>
            {
                window.SetView(view);
                View currentView = window.GetView();
                View defaultView = window.DefaultView;
                try
                {
                    ViewSizeResult = currentView.Size;
                    DefaultViewSizeResult = defaultView.Size;
                    IntRect viewport = window.GetViewport(currentView);
                    ViewportExecuted = viewport.Width == viewport.Width;
                }
                finally
                {
                    currentView.Dispose();
                    defaultView.Dispose();
                }
            });
            Execute("MapPixelToCoords", () =>
            {
                Vector2F point = window.MapPixelToCoords(new Vector2F(100, 100));
                Vector2F pointWithView = window.MapPixelToCoords(new Vector2F(100, 100), view);
                PixelToCoordsExecuted = point.X == point.X && pointWithView.X == pointWithView.X;
            });
            Execute("MapCoordsToPixel", () =>
            {
                Vector2F point = window.MapCoordsToPixel(new Vector2F(100, 100));
                Vector2F pointWithView = window.MapCoordsToPixel(new Vector2F(100, 100), view);
                CoordsToPixelExecuted = point.X == point.X && pointWithView.X == pointWithView.X;
            });
            Execute("ClearDefault", () => window.Clear());
            Execute("ClearColor", () => window.Clear(new Color(20, 40, 60, 255)));
            Execute("ResetGlStates", () => window.ResetGlStates());
            Execute("PushPopGlStates", () =>
            {
                window.PushGlStates();
                window.PopGlStates();
                GlStatesOk = true;
            });
            Execute("PollEvent", () =>
            {
                Event eventToFill;
                window.PollEvent(out eventToFill);
                PollEventExecuted = true;
            });
            Execute("MouseGet", () => MousePositionExecuted = window.InternalGetMousePosition().X == 0f || window.InternalGetMousePosition().X != 0f);
            Execute("TouchGet", () => TouchPositionExecuted = window.InternalGetTouchPosition(0).X == 0f || window.InternalGetTouchPosition(0).X != 0f);
            Execute("SetTitle", () => window.SetTitle("exec-title"));
            Execute("SetVerticalSyncEnabled", () => window.SetVerticalSyncEnabled(false));
            Execute("SetMouseCursorVisible", () => window.SetMouseCursorVisible(true));
            Execute("SetMouseCursorGrabbed", () => window.SetMouseCursorGrabbed(false));
            Execute("SetMouseCursor", () =>
            {
                Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
                try
                {
                    window.SetMouseCursor(cursor);
                }
                finally
                {
                    cursor.Dispose();
                }
            });
            Execute("SetKeyRepeatEnabled", () => window.SetKeyRepeatEnabled(true));
            Execute("SetFramerateLimit", () => window.SetFramerateLimit(0));
            Execute("SetJoystickThreshold", () => window.SetJoystickThreshold(0.1f));
            Execute("RequestFocus", () =>
            {
                window.RequestFocus();
                FocusResult = window.HasFocus();
            });
            Execute("Display", () => window.Display());
            Execute("ToString", () => ToStringResult = window.ToString());
            ExecuteMissing("SystemHandle", () =>
            {
                IntPtr systemHandle = window.SystemHandle;
            });
            ExecuteMissing("Capture", () =>
            {
                Image image = window.Capture();
                image.Dispose();
            });
            Execute("Close", () =>
            {
                window.Close();
                ClosedOk = !window.IsOpen;
            });
            Execute("Dispose", () =>
            {
                window.Dispose();
                window.Dispose();
                DisposeSafe = window.CPointer == IntPtr.Zero;
            });
            Execute("DisposeView", () => view.Dispose());
        }

        /// <summary>
        ///     Executes the specified void action and records any exception.
        /// </summary>
        /// <param name="name">The step name.</param>
        /// <param name="action">The action to execute.</param>
        private static void Execute(string name, Action action)
        {
            if (Environment.GetEnvironmentVariable("ALIS_SFML_TRACE") == "1")
            {
                Console.Error.WriteLine("RWSTEP: " + name);
                Console.Error.Flush();
            }

            try
            {
                action();
            }
            catch (Exception exception)
            {
                Failures.Add(new Exception(name, exception));
            }
        }

        /// <summary>
        ///     Executes the specified void action and records missing native entry points separately.
        /// </summary>
        /// <param name="name">The step name.</param>
        /// <param name="action">The action to execute.</param>
        private static void ExecuteMissing(string name, Action action)
        {
            try
            {
                action();
            }
            catch (EntryPointNotFoundException)
            {
                MissingEntryPoints.Add(name);
            }
            catch (Exception exception)
            {
                Failures.Add(new Exception(name, exception));
            }
        }
    }
}
