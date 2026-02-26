using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Order item struct
    /// </summary>
    public struct OrderItemStruct : IJsonSerializable, IJsonDesSerializable<OrderItemStruct>
    {
        /// <summary>
        /// Gets or sets the value of the product id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Gets or sets the value of the quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the value of the unit price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(ProductId), ProductId.ToString());
            yield return (nameof(Quantity), Quantity.ToString());
            yield return (nameof(UnitPrice), UnitPrice.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public OrderItemStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            OrderItemStruct obj = new OrderItemStruct();
            if (properties.TryGetValue(nameof(ProductId), out string v) && int.TryParse(v, out int val)) obj.ProductId = val;
            if (properties.TryGetValue(nameof(Quantity), out v) && int.TryParse(v, out int val2)) obj.Quantity = val2;
            if (properties.TryGetValue(nameof(UnitPrice), out v) && decimal.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal val3)) obj.UnitPrice = val3;
            return obj;
        }
    }
}