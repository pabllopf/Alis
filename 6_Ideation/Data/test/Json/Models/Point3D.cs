using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     3D Point struct
    /// </summary>
    public struct Point3D : IJsonSerializable, IJsonDesSerializable<Point3D>
    {
        /// <summary>
        /// Gets or sets the value of the x
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the value of the y
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the value of the z
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(X), X.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(Y), Y.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(Z), Z.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The point</returns>
        public Point3D CreateFromProperties(Dictionary<string, string> properties)
        {
            double x = 0.0;
            double y = 0.0;
            double z = 0.0;
            if (properties.TryGetValue(nameof(X), out string xStr) && double.TryParse(xStr, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double xVal)) x = xVal;
            if (properties.TryGetValue(nameof(Y), out string yStr) && double.TryParse(yStr, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double yVal)) y = yVal;
            if (properties.TryGetValue(nameof(Z), out string zStr) && double.TryParse(zStr, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double zVal)) z = zVal;
            return new Point3D(x, y, z);
        }
    }
}