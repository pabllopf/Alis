// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OrderItemStruct.cs
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
    ///     Order item struct
    /// </summary>
    public struct OrderItemStruct : IJsonSerializable, IJsonDesSerializable<OrderItemStruct>
    {
        /// <summary>
        ///     Gets or sets the value of the product id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///     Gets or sets the value of the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the unit price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(ProductId), ProductId.ToString());
            yield return (nameof(Quantity), Quantity.ToString());
            yield return (nameof(UnitPrice), UnitPrice.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public OrderItemStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            OrderItemStruct obj = new OrderItemStruct();
            if (properties.TryGetValue(nameof(ProductId), out string v) && int.TryParse(v, out int val))
            {
                obj.ProductId = val;
            }

            if (properties.TryGetValue(nameof(Quantity), out v) && int.TryParse(v, out int val2))
            {
                obj.Quantity = val2;
            }

            if (properties.TryGetValue(nameof(UnitPrice), out v) && decimal.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal val3))
            {
                obj.UnitPrice = val3;
            }

            return obj;
        }
    }
}