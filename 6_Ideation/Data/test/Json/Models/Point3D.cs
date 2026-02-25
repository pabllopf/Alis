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
            var x = 0.0;
            var y = 0.0;
            var z = 0.0;
            if (properties.TryGetValue(nameof(X), out var xStr) && double.TryParse(xStr, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var xVal)) x = xVal;
            if (properties.TryGetValue(nameof(Y), out var yStr) && double.TryParse(yStr, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var yVal)) y = yVal;
            if (properties.TryGetValue(nameof(Z), out var zStr) && double.TryParse(zStr, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var zVal)) z = zVal;
            return new Point3D(x, y, z);
        }
    }
}