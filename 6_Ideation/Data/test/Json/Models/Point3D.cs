// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Point3D.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     3D Point struct
    /// </summary>
    public struct Point3D : IJsonSerializable, IJsonDesSerializable<Point3D>
    {
        /// <summary>
        ///     Gets or sets the value of the x
        /// </summary>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the value of the y
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        ///     Gets or sets the value of the z
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Point3D" /> class
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
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(X), X.ToString(CultureInfo.InvariantCulture));
            yield return (nameof(Y), Y.ToString(CultureInfo.InvariantCulture));
            yield return (nameof(Z), Z.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The point</returns>
        public Point3D CreateFromProperties(Dictionary<string, string> properties)
        {
            double x = 0.0;
            double y = 0.0;
            double z = 0.0;
            if (properties.TryGetValue(nameof(X), out string xStr) && double.TryParse(xStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double xVal))
            {
                x = xVal;
            }

            if (properties.TryGetValue(nameof(Y), out string yStr) && double.TryParse(yStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double yVal))
            {
                y = yVal;
            }

            if (properties.TryGetValue(nameof(Z), out string zStr) && double.TryParse(zStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double zVal))
            {
                z = zVal;
            }

            return new Point3D(x, y, z);
        }
    }
}