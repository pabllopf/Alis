using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Product entity class
    /// </summary>
    public class ProductClass : IJsonSerializable, IJsonDesSerializable<ProductClass>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public DateTime AddedDate { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(ProductId), ProductId.ToString());
            yield return (nameof(ProductName), ProductName);
            yield return (nameof(Price), Price.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(InStock), InStock.ToString());
            yield return (nameof(AddedDate), AddedDate.ToString("O"));
        }

        public ProductClass CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new ProductClass();
            if (properties.TryGetValue(nameof(ProductId), out var v) && int.TryParse(v, out var val)) obj.ProductId = val;
            if (properties.TryGetValue(nameof(ProductName), out v)) obj.ProductName = v;
            if (properties.TryGetValue(nameof(Price), out v) && decimal.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var val2)) obj.Price = val2;
            if (properties.TryGetValue(nameof(InStock), out v) && bool.TryParse(v, out var val3)) obj.InStock = val3;
            if (properties.TryGetValue(nameof(AddedDate), out v) && DateTime.TryParse(v, out var val4)) obj.AddedDate = val4;
            return obj;
        }
    }
}