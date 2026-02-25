using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Numeric types as struct
    /// </summary>
    public struct NumericTypesStruct : IJsonSerializable, IJsonDesSerializable<NumericTypesStruct>
    {
        public int IntValue { get; set; }
        public double DoubleValue { get; set; }
        public float FloatValue { get; set; }
        public decimal DecimalValue { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(IntValue), IntValue.ToString());
            yield return (nameof(DoubleValue), DoubleValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(FloatValue), FloatValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(DecimalValue), DecimalValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        public NumericTypesStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new NumericTypesStruct();
            if (properties.TryGetValue(nameof(IntValue), out var v) && int.TryParse(v, out var val)) obj.IntValue = val;
            if (properties.TryGetValue(nameof(DoubleValue), out v) && double.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var val2)) obj.DoubleValue = val2;
            if (properties.TryGetValue(nameof(FloatValue), out v) && float.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var val3)) obj.FloatValue = val3;
            if (properties.TryGetValue(nameof(DecimalValue), out v) && decimal.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var val4)) obj.DecimalValue = val4;
            return obj;
        }
    }
}