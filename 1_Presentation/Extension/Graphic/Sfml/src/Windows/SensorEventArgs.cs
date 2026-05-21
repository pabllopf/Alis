

using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Sensor event parameters
    /// </summary>
    public class SensorEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the type of the sensor
        /// </summary>
        public Sensor.Type Type { get; set; }

        /// <summary>
        ///     Gets or sets the current value of the sensor on X axis
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     Gets or sets the current value of the sensor on Y axis
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        ///     Gets or sets the current value of the sensor on Z axis
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        ///     Construct the sensor arguments from a sensor event
        /// </summary>
        /// <param name="e">Sensor event</param>
        public SensorEventArgs(SensorEvent e)
        {
            Type = e.Type;
            X = e.X;
            Y = e.Y;
            Z = e.Z;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[SensorEventArgs]" +
                                             " Type(" + Type + ")" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")" +
                                             " Z(" + Z + ")";
    }
}