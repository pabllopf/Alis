using System;
using System.Runtime.InteropServices;
using System.Security;
using SFML.System;

namespace SFML.Window
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Give access to the real-time state of the joysticks
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static class Joystick
    {
        /// <summary>Maximum number of supported joysticks</summary>
        public static readonly uint Count = 8;

        /// <summary>Maximum number of supported buttons</summary>
        public static readonly uint ButtonCount = 32;

        /// <summary>Maximum number of supported axes</summary>
        public static readonly uint AxisCount = 8;

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Axes supported by SFML joysticks
        /// </summary>
        ////////////////////////////////////////////////////////////
        public enum Axis
        {
            /// <summary>The X axis</summary>
            X,

            /// <summary>The Y axis</summary>
            Y,

            /// <summary>The Z axis</summary>
            Z,

            /// <summary>The R axis</summary>
            R,

            /// <summary>The U axis</summary>
            U,

            /// <summary>The V axis</summary>
            V,

            /// <summary>The X axis of the point-of-view hat</summary>
            PovX,

            /// <summary>TheY axis of the point-of-view hat</summary>
            PovY
        };

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Check if a joystick is connected
        /// </summary>
        /// <param name="joystick">Index of the joystick to check</param>
        /// <returns>True if the joystick is connected, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public static bool IsConnected(uint joystick)
        {
            return sfJoystick_isConnected(joystick);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the number of buttons supported by a joystick
        /// </summary>
        /// If the joystick is not connected, this function returns 0.
        /// <param name="joystick">Index of the joystick</param>
        /// <returns>Number of buttons supported by the joystick</returns>
        ////////////////////////////////////////////////////////////
        public static uint GetButtonCount(uint joystick)
        {
            return sfJoystick_getButtonCount(joystick);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Check if a joystick supports a given axis
        /// </summary>
        /// If the joystick is not connected, this function returns false.
        /// <param name="joystick">Index of the joystick</param>
        /// <param name="axis">Axis to check</param>
        /// <returns>True if the joystick supports the axis, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public static bool HasAxis(uint joystick, Axis axis)
        {
            return sfJoystick_hasAxis(joystick, axis);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Check if a joystick button is pressed
        /// </summary>
        /// If the joystick is not connected, this function returns false.
        /// <param name="joystick">Index of the joystick</param>
        /// <param name="button">Button to check</param>
        /// <returns>True if the button is pressed, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public static bool IsButtonPressed(uint joystick, uint button)
        {
            return sfJoystick_isButtonPressed(joystick, button);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the current position of a joystick axis
        /// </summary>
        /// If the joystick is not connected, this function returns 0.
        /// <param name="joystick">Index of the joystick</param>
        /// <param name="axis">Axis to check</param>
        /// <returns>Current position of the axis, in range [-100 .. 100]</returns>
        ////////////////////////////////////////////////////////////
        public static float GetAxisPosition(uint joystick, Axis axis)
        {
            return sfJoystick_getAxisPosition(joystick, axis);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Update the states of all joysticks
        /// </summary>
        /// This function is used internally by SFML, so you normally
        /// don't have to call it explicitly. However, you may need to
        /// call it if you have no window yet (or no window at all):
        /// in this case the joysticks states are not updated automatically.
        ////////////////////////////////////////////////////////////
        public static void Update()
        {
            sfJoystick_update();
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the joystick information
        /// </summary>
        /// <param name="joystick">Index of the joystick</param>
        /// <returns>Structure containing joystick information</returns>
        ////////////////////////////////////////////////////////////
        public static Identification GetIdentification(uint joystick)
        {
            IdentificationMarshalData identification = sfJoystick_getIdentification(joystick);
            Identification retIdentification = new Identification();

            retIdentification.Name = Marshal.PtrToStringAnsi(identification.Name);
            retIdentification.VendorId = identification.VendorId;
            retIdentification.ProductId = identification.ProductId;

            return retIdentification;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Identification holds a joystick's identification
        /// </summary>
        ////////////////////////////////////////////////////////////
        public struct Identification
        {
            /// <summary>Name of the joystick</summary>
            public string Name;

            /// <summary>Manufacturer identifier</summary>
            public uint VendorId;

            /// <summary>Product identifier</summary>
            public uint ProductId;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Internal struct used for marshaling the joystick
        /// identification struct from unmanaged code.
        /// </summary>
        ////////////////////////////////////////////////////////////
        [StructLayout(LayoutKind.Sequential)]
        internal struct IdentificationMarshalData
        {
            public IntPtr Name;
            public uint VendorId;
            public uint ProductId;
        }

        #region Imports
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfJoystick_isConnected(uint joystick);

        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfJoystick_getButtonCount(uint joystick);

        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfJoystick_hasAxis(uint joystick, Axis axis);

        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfJoystick_isButtonPressed(uint joystick, uint button);

        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern float sfJoystick_getAxisPosition(uint joystick, Axis axis);

        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfJoystick_update();

        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IdentificationMarshalData sfJoystick_getIdentification(uint joystick);
        #endregion
    }
}
