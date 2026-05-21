

using System.Runtime.Serialization;
using Alis.Core.Aspect.Math.Definition;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Definition
{
    /// <summary>
    ///     The depth tests class
    /// </summary>
    public class DepthTests
    {
        /// <summary>
        ///     Tests that constructor sets value correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsValueCorrectly()
        {
            const int expectedValue = 10;

            Depth depth = new Depth(expectedValue);

            Assert.Equal(expectedValue, depth.Value);
        }

        /// <summary>
        ///     Tests that GetObjectData serializes the value correctly
        /// </summary>
        [Fact]
        public void GetObjectData_WritesSerializedValue()
        {
            Depth depth = new Depth(42);
            SerializationInfo info = new SerializationInfo(typeof(Depth), new FormatterConverter());

            depth.GetObjectData(info, default(StreamingContext));

            Assert.Equal(42, info.GetInt32("value"));
        }
    }
}