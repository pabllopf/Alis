

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
