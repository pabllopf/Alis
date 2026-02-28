// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NumericTypesStruct.cs
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
    ///     Numeric types as struct
    /// </summary>
    public struct NumericTypesStruct : IJsonSerializable, IJsonDesSerializable<NumericTypesStruct>
    {
        /// <summary>
        ///     Gets or sets the value of the int value
        /// </summary>
        public int IntValue { get; set; }

        /// <summary>
        ///     Gets or sets the value of the double value
        /// </summary>
        public double DoubleValue { get; set; }

        /// <summary>
        ///     Gets or sets the value of the float value
        /// </summary>
        public float FloatValue { get; set; }

        /// <summary>
        ///     Gets or sets the value of the decimal value
        /// </summary>
        public decimal DecimalValue { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(IntValue), IntValue.ToString());
            yield return (nameof(DoubleValue), DoubleValue.ToString(CultureInfo.InvariantCulture));
            yield return (nameof(FloatValue), FloatValue.ToString(CultureInfo.InvariantCulture));
            yield return (nameof(DecimalValue), DecimalValue.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public NumericTypesStruct CreateFromProperties(Dictionary<string, string> properties)
        {
            NumericTypesStruct obj = new NumericTypesStruct();
            if (properties.TryGetValue(nameof(IntValue), out string v) && int.TryParse(v, out int val))
            {
                obj.IntValue = val;
            }

            if (properties.TryGetValue(nameof(DoubleValue), out v) && double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out double val2))
            {
                obj.DoubleValue = val2;
            }

            if (properties.TryGetValue(nameof(FloatValue), out v) && float.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out float val3))
            {
                obj.FloatValue = val3;
            }

            if (properties.TryGetValue(nameof(DecimalValue), out v) && decimal.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal val4))
            {
                obj.DecimalValue = val4;
            }

            return obj;
        }
    }
}