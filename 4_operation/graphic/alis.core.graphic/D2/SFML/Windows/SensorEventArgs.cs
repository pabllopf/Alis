using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Sensor event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class SensorEventArgs : EventArgs
    {
        /// <summary>Type of the sensor</summary>
        public Sensor.Type Type;

        /// <summary>Current value of the sensor on X axis</summary>
        public float X;

        /// <summary>Current value of the sensor on Y axis</summary>
        public float Y;

        /// <summary>Current value of the sensor on Z axis</summary>
        public float Z;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the sensor arguments from a sensor event
        /// </summary>
        /// <param name="e">Sensor event</param>
        ////////////////////////////////////////////////////////////
        public SensorEventArgs(SensorEvent e)
        {
            Type = e.Type;
            X = e.X;
            Y = e.Y;
            Z = e.Z;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return "[SensorEventArgs]" +
                   " Type(" + Type + ")" +
                   " X(" + X + ")" +
                   " Y(" + Y + ")" +
                   " Z(" + Z + ")";
        }
    }
}