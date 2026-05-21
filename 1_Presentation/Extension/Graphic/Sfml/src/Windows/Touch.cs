

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Give access to the real-time state of the touches
    /// </summary>
    public static class Touch
    {
        /// <summary>
        ///     Check if a touch event is currently down
        /// </summary>
        /// <param name="finger">Finger index</param>
        /// <returns>True if the finger is currently touching the screen, false otherwise</returns>
        public static bool IsDown(uint finger) => sfTouch_isDown(finger);


        /// <summary>
        ///     This function returns the current touch position
        /// </summary>
        /// <param name="finger">Finger index</param>
        /// <returns>Current position of the finger</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F GetPosition(uint finger) => GetPosition(finger, null);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     This function returns the current touch position
        ///     relative to the given window
        /// </summary>
        /// <param name="finger">Finger index</param>
        /// <param name="relativeTo">Reference window</param>
        /// <returns>Current position of the finger</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F GetPosition(uint finger, Window relativeTo)
        {
            if (relativeTo != null)
            {
                return relativeTo.InternalGetTouchPosition(finger);
            }

            return sfTouch_getPosition(finger, IntPtr.Zero);
        }


        /// <summary>
        ///     Sfs the touch is down using the specified finger
        /// </summary>
        /// <param name="finger">The finger</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern bool sfTouch_isDown(uint finger);

        /// <summary>
        ///     Sfs the touch get position using the specified finger
        /// </summary>
        /// <param name="finger">The finger</param>
        /// <param name="relativeTo">The relative to</param>
        /// <returns>The vector 2i</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern Vector2F sfTouch_getPosition(uint finger, IntPtr relativeTo);
    }
}