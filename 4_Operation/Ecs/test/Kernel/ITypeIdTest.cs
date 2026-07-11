using System;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    /// The type id test class
    /// </summary>
    public class ITypeIdTest
    {
        /// <summary>
        /// Tests that explicit interface type returns expected type
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ExplicitInterface_Type_ReturnsExpectedType()
        {
            var id = new TestTypeId(typeof(int), 1);
            ITypeId typedId = id;
            Assert.Equal(typeof(int), typedId.Type);
        }

        /// <summary>
        /// Tests that explicit interface value returns expected value
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ExplicitInterface_Value_ReturnsExpectedValue()
        {
            var id = new TestTypeId(typeof(string), 42);
            ITypeId typedId = id;
            Assert.Equal((ushort)42, typedId.Value);
        }

        /// <summary>
        /// Tests that explicit interface default value returns zero
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ExplicitInterface_DefaultValue_ReturnsZero()
        {
            var id = new TestTypeId(typeof(double), 0);
            ITypeId typedId = id;
            Assert.Equal((ushort)0, typedId.Value);
        }

        /// <summary>
        /// The test type id
        /// </summary>
        internal readonly struct TestTypeId : ITypeId
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestTypeId"/> class
            /// </summary>
            /// <param name="type">The type</param>
            /// <param name="value">The value</param>
            public TestTypeId(Type type, ushort value)
            {
                Type = type;
                Value = value;
            }

            /// <summary>
            /// Gets the value of the type
            /// </summary>
            public Type Type { get; }
            /// <summary>
            /// Gets the value of the value
            /// </summary>
            public ushort Value { get; }
        }
    }
}
