using System;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    public class ITypeIdTest
    {
        [Fact]
        public void ExplicitInterface_Type_ReturnsExpectedType()
        {
            var id = new TestTypeId(typeof(int), 1);
            ITypeId typedId = id;
            Assert.Equal(typeof(int), typedId.Type);
        }

        [Fact]
        public void ExplicitInterface_Value_ReturnsExpectedValue()
        {
            var id = new TestTypeId(typeof(string), 42);
            ITypeId typedId = id;
            Assert.Equal((ushort)42, typedId.Value);
        }

        [Fact]
        public void ExplicitInterface_DefaultValue_ReturnsZero()
        {
            var id = new TestTypeId(typeof(double), 0);
            ITypeId typedId = id;
            Assert.Equal((ushort)0, typedId.Value);
        }

        private readonly struct TestTypeId : ITypeId
        {
            public TestTypeId(Type type, ushort value)
            {
                Type = type;
                Value = value;
            }

            public Type Type { get; }
            public ushort Value { get; }
        }
    }
}
