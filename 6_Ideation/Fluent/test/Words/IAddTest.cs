using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IAdd interface.
    ///     Ensures the Add method can be implemented and returns the correct builder type.
    /// </summary>
    public class IAddTest
    {
        private class DummyBuilder { public int Value; }
        private class DummyAdd : Alis.Core.Aspect.Fluent.Words.IAdd<DummyBuilder, int>
        {
            public DummyBuilder Add(int value) => new DummyBuilder { Value = value };
        }

        /// <summary>
        ///     Ensures Add returns a builder with the correct value.
        /// </summary>
        [Fact]
        public void Add_ReturnsBuilderWithCorrectValue()
        {
            DummyAdd add = new DummyAdd();
            DummyBuilder builder = add.Add(123);
            Assert.NotNull(builder);
            Assert.Equal(123, builder.Value);
        }
    }
}

