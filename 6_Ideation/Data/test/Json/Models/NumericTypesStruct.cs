using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Numeric types as struct
    /// </summary>
    public struct NumericTypesStruct : IJsonSerializable, IJsonDesSerializable<NumericTypesStruct>
    {
        /// <summary>
        /// Gets or sets the value of the int value
        /// </summary>
        public int IntValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the double value
        /// </summary>
        public double DoubleValue { get; set; }
        /// <summary>
        /// Gets or sets the value of the float value
        /// </summary>
        public float FloatValue { get; set; }
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
            yield return (nameof(IntValue), IntValue.ToString());
            yield return (nameof(DoubleValue), DoubleValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(FloatValue), FloatValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
            yield return (nameof(DecimalValue), DecimalValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public NumericTypesStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            NumericTypesStruct obj = new NumericTypesStruct();
            if (properties.TryGetValue(nameof(IntValue), out string v) && int.TryParse(v, out int val)) obj.IntValue = val;
            if (properties.TryGetValue(nameof(DoubleValue), out v) && double.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double val2)) obj.DoubleValue = val2;
            if (properties.TryGetValue(nameof(FloatValue), out v) && float.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float val3)) obj.FloatValue = val3;
            if (properties.TryGetValue(nameof(DecimalValue), out v) && decimal.TryParse(v, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal val4)) obj.DecimalValue = val4;
            return obj;
        }
    }
}