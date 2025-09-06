using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    
    /// <summary>
    /// Give access to the real-time state of sensors
    /// </summary>
    
    public static class Sensor
    {
        
        /// <summary>
        /// Sensor types
        /// </summary>
        
        public enum Type
        {
            /// <summary>Measures the raw acceleration (m/s^2)</summary>
            Accelerometer,

            /// <summary>Measures the raw rotation rates (degrees/s)</summary>
            Gyroscope,

            /// <summary>Measures the ambient magnetic field (micro-teslas)</summary>
            Magnetometer,

            /// <summary>Measures the direction and intensity of gravity, independent of device acceleration (m/s^2)</summary>
            Gravity,

            /// <summary>Measures the direction and intensity of device acceleration, independent of the gravity (m/s^2)</summary>
            UserAcceleration,

            /// <summary>Measures the absolute 3D orientation (degrees)</summary>
            Orientation,

            /// <summary>Keep last -- the total number of sensor types</summary>
            TypeCount
        };

        
        /// <summary>
        /// Check if a sensor is available on the underlying platform
        /// </summary>
        /// <param name="sensor">Sensor to check</param>
        /// <returns>True if the sensor is available, false otherwise</returns>
        
        public static bool IsAvailable(Type sensor)
        {
            return sfSensor_isAvailable(sensor);
        }

        
        /// <summary>
        /// Enable or disable a sensor
        /// </summary>
        /// <param name="sensor">Sensor to check</param>
        /// <param name="enabled">True to enable, false to disable</param>
        
        public static void SetEnabled(Type sensor, bool enabled)
        {
            sfSensor_setEnabled(sensor, enabled);
        }

        
        /// <summary>
        /// Get the current sensor value
        /// </summary>
        /// <param name="sensor">Sensor to check</param>
        /// <returns>The current sensor value</returns>
        
        public static Vector3F GetValue(Type sensor)
        {
            return sfSensor_getValue(sensor);
        }

        #region Imports
        /// <summary>
        /// Sfs the sensor is available using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfSensor_isAvailable(Type sensor);

        /// <summary>
        /// Sfs the sensor set enabled using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="enabled">The enabled</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfSensor_setEnabled(Type sensor, bool enabled);

        /// <summary>
        /// Sfs the sensor get value using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The vector 3f</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Vector3F sfSensor_getValue(Type sensor);
        #endregion
    }
}
