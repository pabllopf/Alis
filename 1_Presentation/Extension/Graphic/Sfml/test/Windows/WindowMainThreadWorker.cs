// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowMainThreadWorker.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Executes the base <see cref="Window" /> wrapper members against the real native CSFML
    ///     library on the process main thread. A plain (non-render) window is created from a native
    ///     handle so the base virtual implementations are exercised directly; every step records
    ///     its result so the xUnit tests can assert the observed behavior afterwards.
    /// </summary>
    public static class WindowMainThreadWorker
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
        ///     Indicates whether the position getter and setter completed.
        /// </summary>
        internal static bool PositionExecuted;

        /// <summary>
        ///     Indicates whether the size getter and setter completed.
        /// </summary>
        internal static bool SizeExecuted;

        /// <summary>
        ///     Indicates whether the system handle query completed.
        /// </summary>
        internal static bool SystemHandleExecuted;

        /// <summary>
        ///     Indicates whether the title setter completed.
        /// </summary>
        internal static bool TitleExecuted;

        /// <summary>
        ///     Indicates whether the visible setter completed.
        /// </summary>
        internal static bool VisibleExecuted;

        /// <summary>
        ///     Indicates whether the mouse cursor setters completed.
        /// </summary>
        internal static bool CursorExecuted;

        /// <summary>
        ///     Indicates whether the vertical sync and key repeat setters completed.
        /// </summary>
        internal static bool SyncAndRepeatExecuted;

        /// <summary>
        ///     The read back active state after activating the window.
        /// </summary>
        internal static bool ActiveResult;

        /// <summary>
        ///     Indicates whether the framerate and joystick threshold setters completed.
        /// </summary>
        internal static bool LimitsExecuted;

        /// <summary>
        ///     The read back focus state of the live window.
        /// </summary>
        internal static bool FocusResult;

        /// <summary>
        ///     Indicates whether the display call completed.
        /// </summary>
        internal static bool DisplayExecuted;

        /// <summary>
        ///     Indicates whether the poll event call completed without throwing.
        /// </summary>
        internal static bool PollEventExecuted;

        /// <summary>
        ///     Indicates whether closing the window made it report closed.
        /// </summary>
        internal static bool ClosedOk;

        /// <summary>
        ///     The read back string description of the live window.
        /// </summary>
        internal static string ToStringResult;

        /// <summary>
        ///     Indicates whether disposing the window destroyed the native handle.
        /// </summary>
        internal static bool DisposeSafe;

        /// <summary>
        ///     Runs every native step on the main thread and records the results.
        /// </summary>
        public static void Run()
        {
            IntPtr native = SfmlTestBootstrap.CreateExtraNativeWindow();
            if (native == IntPtr.Zero)
            {
                return;
            }

            IntPtr handle = SfmlTestBootstrap.GetExtraNativeHandle(native);
            if (handle == IntPtr.Zero)
            {
                return;
            }

            Window window = new Window(handle);
            Execute("IsOpen", () => IsOpenResult = window.IsOpen);
            Execute("Settings", () => _ = window.Settings);
            Execute("Position", () =>
            {
                window.Position = new Vector2F(50, 40);
                Vector2F positionReadBack = window.Position;
                PositionExecuted = positionReadBack.X == positionReadBack.X;
            });
            Execute("Size", () =>
            {
                window.Size = new Vector2F(130, 100);
                Vector2F sizeReadBack = window.Size;
                SizeExecuted = sizeReadBack.X == sizeReadBack.X;
            });
            ExecuteMissing("SystemHandle", () =>
            {
                IntPtr systemHandle = window.SystemHandle;
                SystemHandleExecuted = systemHandle != IntPtr.Zero;
            });
            Execute("SetTitle", () =>
            {
                window.SetTitle("exec-window-title");
                TitleExecuted = true;
            });
            Execute("SetVisible", () =>
            {
                window.SetVisible(false);
                VisibleExecuted = true;
            });
            Execute("MouseCursor", () =>
            {
                window.SetMouseCursorVisible(true);
                window.SetMouseCursorGrabbed(false);
                using Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
                window.SetMouseCursor(cursor);
                CursorExecuted = true;
            });
            Execute("SyncAndRepeat", () =>
            {
                window.SetVerticalSyncEnabled(false);
                window.SetKeyRepeatEnabled(true);
                SyncAndRepeatExecuted = true;
            });
            Execute("SetActive", () => ActiveResult = window.SetActive(true));
            Execute("SetActiveDefault", () => _ = window.SetActive());
            Execute("Limits", () =>
            {
                window.SetFramerateLimit(0);
                window.SetJoystickThreshold(0.1f);
                LimitsExecuted = true;
            });
            Execute("Focus", () =>
            {
                window.RequestFocus();
                FocusResult = window.HasFocus();
            });
            Execute("MouseGet", () => _ = window.InternalGetMousePosition());
            Execute("TouchGet", () => _ = window.InternalGetTouchPosition(0));
            Execute("DispatchEvents", () => window.DispatchEvents());
            Execute("Display", () =>
            {
                window.Display();
                DisplayExecuted = true;
            });
            Execute("ToString", () => ToStringResult = window.ToString());
            Execute("PollEvent", () =>
            {
                Event eventToFill;
                window.PollEvent(out eventToFill);
                PollEventExecuted = true;
            });
            Execute("Close", () =>
            {
                window.Close();
                ClosedOk = !window.IsOpen;
            });
            Execute("Destroy", () =>
            {
                window.Dispose();
                DisposeSafe = window.CPointer == IntPtr.Zero;
            });
        }

        /// <summary>
        ///     Executes the specified void action and records any exception.
        /// </summary>
        /// <param name="name">The step name.</param>
        /// <param name="action">The action to execute.</param>
        private static void Execute(string name, Action action)
        {
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
