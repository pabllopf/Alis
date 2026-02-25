using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with all numeric types
    /// </summary>
    public class NumericTypesClass : IJsonSerializable, IJsonDesSerializable<NumericTypesClass>
    {
        public byte ByteValue { get; set; }
        public sbyte SByteValue { get; set; }
        public short ShortValue { get; set; }
        public ushort UShortValue { get; set; }
        public int IntValue { get; set; }
        public uint UIntValue { get; set; }
        public long LongValue { get; set; }
        public ulong ULongValue { get; set; }
        public float FloatValue { get; set; }
        public double DoubleValue { get; set; }
        public decimal DecimalValue { get; set; }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(ByteValue), ByteValue.ToString());
            yield return (nameof(SByteValue), SByteValue.ToString());
            yield return (nameof(ShortValue), ShortValue.ToString());
            yield return (nameof(UShortValue), UShortValue.ToString());
            yield return (nameof(IntValue), IntValue.ToString());
            yield return (nameof(UIntValue), UIntValue.ToString());
            yield return (nameof(LongValue), LongValue.ToString());
            yield return (nameof(ULongValue), ULongValue.ToString());
            yield return (nameof(FloatValue), FloatValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(DoubleValue), DoubleValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(DecimalValue), DecimalValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        public NumericTypesClass CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new NumericTypesClass();
            if (properties.TryGetValue(nameof(ByteValue), out var v) && byte.TryParse(v, out var val)) obj.ByteValue = val;
            if (properties.TryGetValue(nameof(SByteValue), out v) && sbyte.TryParse(v, out var val2)) obj.SByteValue = val2;
            if (properties.TryGetValue(nameof(ShortValue), out v) && short.TryParse(v, out var val3)) obj.ShortValue = val3;
            if (properties.TryGetValue(nameof(UShortValue), out v) && ushort.TryParse(v, out var val4)) obj.UShortValue = val4;
            if (properties.TryGetValue(nameof(IntValue), out v) && int.TryParse(v, out var val5)) obj.IntValue = val5;
            if (properties.TryGetValue(nameof(UIntValue), out v) && uint.TryParse(v, out var val6)) obj.UIntValue = val6;
            if (properties.TryGetValue(nameof(LongValue), out v) && long.TryParse(v, out var val7)) obj.LongValue = val7;
            if (properties.TryGetValue(nameof(ULongValue), out v) && ulong.TryParse(v, out var val8)) obj.ULongValue = val8;
            if (properties.TryGetValue(nameof(FloatValue), out v) && float.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var val9)) obj.FloatValue = val9;
            if (properties.TryGetValue(nameof(DoubleValue), out v) && double.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var val10)) obj.DoubleValue = val10;
            if (properties.TryGetValue(nameof(DecimalValue), out v) && decimal.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var val11)) obj.DecimalValue = val11;
            return obj;
        }
    }
}