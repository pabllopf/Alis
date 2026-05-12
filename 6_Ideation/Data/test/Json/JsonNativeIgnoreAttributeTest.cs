// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonNativeIgnoreAttributeTest.cs
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
using System.Reflection;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     Tests for JsonNativeIgnoreAttribute metadata and usage.
    /// </summary>
    public class JsonNativeIgnoreAttributeTest
    {
        /// <summary>
        ///     Tests that the ignore attribute inherits from Attribute.
        /// </summary>
        [Fact]
        public void JsonNativeIgnoreAttribute_InheritsFromAttribute()
        {
            Assert.True(typeof(JsonNativeIgnoreAttribute).IsSubclassOf(typeof(Attribute)));
        }

        /// <summary>
        ///     Tests that the ignore attribute can be attached to a property.
        /// </summary>
        [Fact]
        public void JsonNativeIgnoreAttribute_CanBeAppliedToProperty()
        {
            PropertyInfo propertyInfo = typeof(IgnoredModel).GetProperty(nameof(IgnoredModel.Secret));
            JsonNativeIgnoreAttribute attribute = propertyInfo?.GetCustomAttribute<JsonNativeIgnoreAttribute>();

            Assert.NotNull(propertyInfo);
            Assert.NotNull(attribute);
        }

        /// <summary>
        ///     Tests that the ignore attribute targets properties only.
        /// </summary>
        [Fact]
        public void JsonNativeIgnoreAttribute_TargetsPropertiesOnly()
        {
            AttributeUsageAttribute usage = typeof(JsonNativeIgnoreAttribute).GetCustomAttribute<AttributeUsageAttribute>();

            Assert.NotNull(usage);
            Assert.Equal(AttributeTargets.Property, usage.ValidOn);
        }

        /// <summary>
        ///     Tests that the ignore attribute can be instantiated.
        /// </summary>
        [Fact]
        public void JsonNativeIgnoreAttribute_CanBeInstantiated()
        {
            JsonNativeIgnoreAttribute attribute = new JsonNativeIgnoreAttribute();

            Assert.NotNull(attribute);
        }

        /// <summary>
        ///     Model used by attribute tests.
        /// </summary>
        private sealed class IgnoredModel
        {
            /// <summary>
            ///     Gets or sets a property intentionally ignored by serialization.
            /// </summary>
            [JsonNativeIgnore]
            public string Secret { get; set; } = string.Empty;
        }
    }
}
