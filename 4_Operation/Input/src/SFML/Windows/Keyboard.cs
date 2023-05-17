// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Keyboard.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;

namespace Alis.Core.Input.SFML.Windows
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Give access to the real-time state of the keyboard
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static class Keyboard
    {
        ////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check if a key is pressed
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key is pressed, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public static bool IsKeyPressed(Key key) => sfKeyboard_isKeyPressed(key);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Enable/Disable visibility of the virtual keyboard
        /// </summary>
        /// <remarks>Applicable only on Android and iOS</remarks>
        /// <param name="visible">Whether to make the virtual keyboard visible (true) or not (false)</param>
        ////////////////////////////////////////////////////////////
        public static void SetVirtualKeyboardVisible(bool visible)
        {
            sfKeyboard_setVirtualKeyboardVisible(visible);
        }

        /// <summary>
        ///     Describes whether sf keyboard is key pressed
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfKeyboard_isKeyPressed(Key key);

        /// <summary>
        ///     Sfs the keyboard set virtual keyboard visible using the specified visible
        /// </summary>
        /// <param name="visible">The visible</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfKeyboard_setVirtualKeyboardVisible(bool visible);
    }
}