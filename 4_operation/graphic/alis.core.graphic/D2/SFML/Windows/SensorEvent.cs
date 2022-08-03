using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Sensor event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct SensorEvent
    {
        /// <summary>Type of the sensor</summary>
        public Sensor.Type Type;

        /// <summary>Current value of the sensor on X axis</summary>
        public float X;

        /// <summary>Current value of the sensor on Y axis</summary>
        public float Y;

        /// <summary>Current value of the sensor on Z axis</summary>
        public float Z;
    }
}