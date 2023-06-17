// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Listener.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Audio.SFML
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     The audio listener is the point in the scene
    ///     from where all the sounds are heard
    /// </summary>
    ////////////////////////////////////////////////////////////
    internal class Listener
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The volume is a number between 0 and 100; it is combined with
        ///     the individual volume of each sound / music.
        ///     The default value for the volume is 100 (maximum).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static float GlobalVolume
        {
            get => sfListener_getGlobalVolume();
            set => sfListener_setGlobalVolume(value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     3D position of the listener (default is (0, 0, 0))
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Vector3F Position
        {
            get => sfListener_getPosition();
            set => sfListener_setPosition(value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The direction (also called "at vector") is the vector
        ///     pointing forward from the listener's perspective. Together
        ///     with the up vector, it defines the 3D orientation of the
        ///     listener in the scene. The direction vector doesn't
        ///     have to be normalized.
        ///     The default listener's direction is (0, 0, -1).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Vector3F Direction
        {
            get => sfListener_getDirection();
            set => sfListener_setDirection(value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The up vector is the vector that points upward from the
        ///     listener's perspective. Together with the direction, it
        ///     defines the 3D orientation of the listener in the scene.
        ///     The up vector doesn't have to be normalized.
        ///     The default listener's up vector is (0, 1, 0). It is usually
        ///     not necessary to change it, especially in 2D scenarios.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Vector3F UpVector
        {
            get => sfListener_getUpVector();
            set => sfListener_setUpVector(value);
        }

        /// <summary>
        ///     Sfs the listener set global volume using the specified volume
        /// </summary>
        /// <param name="volume">The volume</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setGlobalVolume(float volume);

        /// <summary>
        ///     Sfs the listener get global volume
        /// </summary>
        /// <returns>The float</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfListener_getGlobalVolume();

        /// <summary>
        ///     Sfs the listener set position using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setPosition(Vector3F position);

        /// <summary>
        ///     Sfs the listener get position
        /// </summary>
        /// <returns>The vector 3f</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3F sfListener_getPosition();

        /// <summary>
        ///     Sfs the listener set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setDirection(Vector3F direction);

        /// <summary>
        ///     Sfs the listener get direction
        /// </summary>
        /// <returns>The vector 3f</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3F sfListener_getDirection();

        /// <summary>
        ///     Sfs the listener set up vector using the specified up vector
        /// </summary>
        /// <param name="upVector">The up vector</param>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setUpVector(Vector3F upVector);

        /// <summary>
        ///     Sfs the listener get up vector
        /// </summary>
        /// <returns>The vector 3f</returns>
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3F sfListener_getUpVector();
    }
}