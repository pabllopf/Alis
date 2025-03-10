// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputMode.cs
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

namespace Alis.Core.Graphic.GlfwLib.Enums
{
    /// <summary>
    ///     Strongly-typed values for getting/setting the input mode hints.
    /// </summary>
    public enum InputMode
    {
        /// <summary>
        ///     If specified, enables setting the mouse behavior.
        ///     <para>See <see cref="CursorMode" /> for possible values.</para>
        /// </summary>
        Cursor = 0x00033001,

        /// <summary>
        ///     If specified, enables setting sticky keys, where <see cref="Glfw.GetKey" /> will return
        ///     <see cref="InputState.Press" /> the first time you call it for a key that was pressed, even if that key has already
        ///     been released.
        /// </summary>
        StickyKeys = 0x00033002,

        /// <summary>
        ///     If specified, enables setting sticky mouse buttons, where <see cref="Glfw.GetMouseButton" /> will return
        ///     <see cref="InputState.Press" /> the first time you call it for a mouse button that was pressed, even if that mouse
        ///     button has already been released.
        /// </summary>
        StickyMouseButton = 0x00033003,

        /// <summary>
        ///     When this input mode is enabled, any callback that receives modifier bits will have the
        ///     <see cref="ModifierKeys.CapsLock" /> bit set if caps lock was on when the event occurred and the
        ///     <see cref="ModifierKeys.NumLock" /> bit set if num lock was on.
        /// </summary>
        LockKeyMods = 0x00033004,

        /// <summary>
        ///     When the cursor is disabled, raw (unscaled and unaccelerated) mouse motion can be enabled if available.
        ///     <seealso cref="Glfw.RawMouseMotionSupported" />
        /// </summary>
        RawMouseMotion = 0x00033005
    }
}