// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProductClass.cs
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

using System;
using System.Collections.Generic;
using System.Globalization;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Product entity class
    /// </summary>
    public class ProductClass : IJsonSerializable, IJsonDesSerializable<ProductClass>
    {
        /// <summary>
        ///     Gets or sets the value of the product id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        ///     Gets or sets the value of the in stock
        /// </summary>
        public bool InStock { get; set; }

        /// <summary>
        ///     Gets or sets the value of the added date
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public ProductClass CreateFromProperties(Dictionary<string, string> properties)
        {
            ProductClass obj = new ProductClass();
            if (properties.TryGetValue(nameof(ProductId), out string v) && int.TryParse(v, out int val))
            {
                obj.ProductId = val;
            }

            if (properties.TryGetValue(nameof(ProductName), out v))
            {
                obj.ProductName = v;
            }

            if (properties.TryGetValue(nameof(Price), out v) && decimal.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal val2))
            {
                obj.Price = val2;
            }

            if (properties.TryGetValue(nameof(InStock), out v) && bool.TryParse(v, out bool val3))
            {
                obj.InStock = val3;
            }

            if (properties.TryGetValue(nameof(AddedDate), out v) && DateTime.TryParse(v, out DateTime val4))
            {
                obj.AddedDate = val4;
            }

            return obj;
        }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(ProductId), ProductId.ToString());
            yield return (nameof(ProductName), ProductName);
            yield return (nameof(Price), Price.ToString(CultureInfo.InvariantCulture));
            yield return (nameof(InStock), InStock.ToString());
            yield return (nameof(AddedDate), AddedDate.ToString("O"));
        }
    }
}