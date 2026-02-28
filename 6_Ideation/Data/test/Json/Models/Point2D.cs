// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Point2D.cs
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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     2D Point struct
    /// </summary>
    public struct Point2D : IJsonSerializable, IJsonDesSerializable<Point2D>
    {
        /// <summary>
        ///     Gets or sets the value of the x
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the value of the y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Point2D" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(X), X.ToString());
            yield return (nameof(Y), Y.ToString());
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The point</returns>
        public Point2D CreateFromProperties(Dictionary<string, string> properties)
        {
            int x = 0;
            int y = 0;
            if (properties.TryGetValue(nameof(X), out string xStr) && int.TryParse(xStr, out int xVal))
            {
                x = xVal;
            }

            if (properties.TryGetValue(nameof(Y), out string yStr) && int.TryParse(yStr, out int yVal))
            {
                y = yVal;
            }

            return new Point2D(x, y);
        }
    }
}