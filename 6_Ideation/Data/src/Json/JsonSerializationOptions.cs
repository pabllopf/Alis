// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonSerializationOptions.cs
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

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Define options for JSON serialization.
    /// </summary>
    [Flags]
    public enum JsonSerializationOptions
    {
        /// <summary>
        ///     No option.
        ///     Use Type Descriptor (including custom ones) when serializing custom objects.
        /// </summary>
        None = 0x0,
        
        /// <summary>
        ///     Use pure reflection when serializing custom objects.
        /// </summary>
        UseReflection = 0x1,
        
        /// <summary>
        ///     Avoid fields and properties marked with the XmlIgnore attribute.
        /// </summary>
        UseXmlIgnore = 0x2,
        
        /// <summary>
        ///     Use the format defined in the DateTimeFormat property of the JsonOptions class.
        /// </summary>
        DateFormatCustom = 0x4,
        
        /// <summary>
        ///     Serializes fields.
        /// </summary>
        SerializeFields = 0x8,
        
        /// <summary>
        ///     Use the ISerializable interface.
        /// </summary>
        UseISerializable = 0x10,
        
        /// <summary>
        ///     Use the [new Date(utc milliseconds)] format.
        ///     Note this format is not generally supported by browsers native JSON parsers.
        /// </summary>
        DateFormatJs = 0x20,
        
        /// <summary>
        ///     Use the ISO 8601 string format ('s' DateTime format).
        /// </summary>
        DateFormatIso8601 = 0x40,
        
        /// <summary>
        ///     Avoid fields and properties marked with the ScriptIgnore attribute.
        /// </summary>
        UseScriptIgnore = 0x80,
        
        /// <summary>
        ///     Use the ISO 8601 roundtrip string format ('o' DateTime format).
        /// </summary>
        DateFormatRoundtripUtc = 0x100,
        
        /// <summary>
        ///     Serialize enum values as text.
        /// </summary>
        EnumAsText = 0x200,
        
        /// <summary>
        ///     Continue serialization if a cycle was detected.
        /// </summary>
        ContinueOnCycle = 0x400,
        
        /// <summary>
        ///     Continue serialization if getting a value throws error.
        /// </summary>
        ContinueOnValueError = 0x800,
        
        /// <summary>
        ///     Don't serialize properties with a null value.
        /// </summary>
        SkipNullPropertyValues = 0x1000,
        
        /// <summary>
        ///     Use the format defined in the DateTimeOffsetFormat property of the JsonOptions class.
        /// </summary>
        DateTimeOffsetFormatCustom = 0x2000,
        
        /// <summary>
        ///     Don't serialize null date time values.
        /// </summary>
        SkipNullDateTimeValues = 0x4000,
        
        /// <summary>
        ///     Automatically parse date time.
        /// </summary>
        AutoParseDateTime = 0x8000,
        
        /// <summary>
        ///     Write dictionary keys without quotes.
        /// </summary>
        WriteKeysWithoutQuotes = 0x10000,
        
        /// <summary>
        ///     Serializes byte arrays as base 64 strings.
        /// </summary>
        ByteArrayAsBase64 = 0x20000,
        
        /// <summary>
        ///     Serializes streams as base 64 strings.
        /// </summary>
        StreamsAsBase64 = 0x40000,
        
        /// <summary>
        ///     Don't serialize value type with a zero value.
        /// </summary>
        SkipZeroValueTypes = 0x80000,
        
        /// <summary>
        ///     Use the JSON attribute.
        /// </summary>
        UseJsonAttribute = 0x100000,
        
        /// <summary>
        ///     Don't serialize values equal to the default member (property, field) value, if defined.
        /// </summary>
        SkipDefaultValues = 0x200000,
        
        /// <summary>
        ///     Serialize TimeSpan values as text.
        /// </summary>
        TimeSpanAsText = 0x400000,
        
        /// <summary>
        ///     Skip members with get only method.
        /// </summary>
        SkipGetOnly = 0x800000,
        
        /// <summary>
        ///     The default value.
        /// </summary>
        Default =  UseISerializable | SerializeFields | AutoParseDateTime | UseJsonAttribute | ContinueOnCycle
    }
}