using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Order item struct
    /// </summary>
    public struct OrderItemStruct : IJsonSerializable, IJsonDesSerializable<OrderItemStruct>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(ProductId), ProductId.ToString());
            yield return (nameof(Quantity), Quantity.ToString());
            yield return (nameof(UnitPrice), UnitPrice.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

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