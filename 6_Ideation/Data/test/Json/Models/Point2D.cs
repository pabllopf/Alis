using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     2D Point struct
    /// </summary>
    public struct Point2D : IJsonSerializable, IJsonDesSerializable<Point2D>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(X), X.ToString());
            yield return (nameof(Y), Y.ToString());
        }

        public Point2D CreateFromProperties(Dictionary<string, string> properties)
        {
            int x = 0;
            int y = 0;
            if (properties.TryGetValue(nameof(X), out string xStr) && int.TryParse(xStr, out int xVal)) x = xVal;
            if (properties.TryGetValue(nameof(Y), out string yStr) && int.TryParse(yStr, out int yVal)) y = yVal;
            return new Point2D(x, y);
        }
    }
}