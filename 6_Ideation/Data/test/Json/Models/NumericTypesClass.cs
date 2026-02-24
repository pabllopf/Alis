using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with all numeric types
    /// </summary>
    public class NumericTypesClass : IJsonSerializable, IJsonDesSerializable<NumericTypesClass>
    {
        /// <summary>
        /// Gets or sets the value of the byte value
        /// </summary>
        public byte ByteValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the s byte value
        /// </summary>
        public sbyte SByteValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the short value
        /// </summary>
        public short ShortValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the u short value
        /// </summary>
        public ushort UShortValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the int value
        /// </summary>
        public int IntValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the u int value
        /// </summary>
        public uint UIntValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the long value
        /// </summary>
        public long LongValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the u long value
        /// </summary>
        public ulong ULongValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the float value
        /// </summary>
        public float FloatValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the double value
        /// </summary>
        public double DoubleValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the decimal value
        /// </summary>
        public decimal DecimalValue { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
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

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public NumericTypesClass CreateFromProperties(Dictionary<string, string> properties)
        {
            NumericTypesClass obj = new NumericTypesClass();
            if (properties.TryGetValue(nameof(ByteValue), out string v) && byte.TryParse(v, out byte val)) obj.ByteValue = val;
            if (properties.TryGetValue(nameof(SByteValue), out v) && sbyte.TryParse(v, out sbyte val2)) obj.SByteValue = val2;
            if (properties.TryGetValue(nameof(ShortValue), out v) && short.TryParse(v, out short val3)) obj.ShortValue = val3;
            if (properties.TryGetValue(nameof(UShortValue), out v) && ushort.TryParse(v, out ushort val4)) obj.UShortValue = val4;
            if (properties.TryGetValue(nameof(IntValue), out v) && int.TryParse(v, out int val5)) obj.IntValue = val5;
            if (properties.TryGetValue(nameof(UIntValue), out v) && uint.TryParse(v, out uint val6)) obj.UIntValue = val6;
            if (properties.TryGetValue(nameof(LongValue), out v) && long.TryParse(v, out long val7)) obj.LongValue = val7;
            if (properties.TryGetValue(nameof(ULongValue), out v) && ulong.TryParse(v, out ulong val8)) obj.ULongValue = val8;
            if (properties.TryGetValue(nameof(FloatValue), out v) && float.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float val9)) obj.FloatValue = val9;
            if (properties.TryGetValue(nameof(DoubleValue), out v) && double.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double val10)) obj.DoubleValue = val10;
            if (properties.TryGetValue(nameof(DecimalValue), out v) && decimal.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal val11)) obj.DecimalValue = val11;
            return obj;
        }
    }
}