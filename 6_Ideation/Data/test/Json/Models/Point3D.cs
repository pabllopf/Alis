using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     3D Point struct
    /// </summary>
    public struct Point3D : IJsonSerializable, IJsonDesSerializable<Point3D>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(X), X.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(Y), Y.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(Z), Z.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

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