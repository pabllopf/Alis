

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IHas interface.
    ///     Tests the Has method for checking object existence.
    /// </summary>
    public class IHasTest
    {
        /// <summary>
        ///     Tests that IHas can be implemented.
        /// </summary>
        [Fact]
        public void IHas_CanBeImplemented()
        {
            HasBuilder builder = new HasBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IHas<Builder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Has returns builder.
        /// </summary>
        [Fact]
        public void Has_ReturnsBuilder()
        {
            HasBuilder builder = new HasBuilder();
            Builder result = builder.Has("property");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that Has sets property correctly.
        /// </summary>
        [Fact]
        public void Has_SetsPropertyCorrectly()
        {
            HasBuilder builder = new HasBuilder();
            Builder result = builder.Has("test_prop");
            Assert.Equal("test_prop", result.HasProperty);
        }

        /// <summary>
        ///     Tests IHas with object argument.
        /// </summary>
        [Fact]
        public void IHas_WithObjectArgument()
        {
            ObjectHasBuilder builder = new ObjectHasBuilder();
            object obj = new object();
            ObjectBuilder result = builder.Has(obj);
            Assert.Same(obj, result.HasObject);
        }

        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder
        {
            /// <summary>
            ///     Gets or sets the value of the has property
            /// </summary>
            public string HasProperty { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IHas.
        /// </summary>
        private class HasBuilder : IHas<Builder, string>
        {
            /// <summary>
            ///     The builder
            /// </summary>
            private readonly Builder _builder = new Builder();

            /// <summary>
            ///     Hases the obj
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The builder</returns>
            public Builder Has(string obj)
            {
                _builder.HasProperty = obj;
                return _builder;
            }
        }

        /// <summary>
        ///     Helper builder with object.
        /// </summary>
        private class ObjectBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the has object
            /// </summary>
            public object HasObject { get; set; }
        }

        /// <summary>
        ///     Helper implementation with object.
        /// </summary>
        private class ObjectHasBuilder : IHas<ObjectBuilder, object>
        {
            /// <summary>
            ///     The object builder
            /// </summary>
            private readonly ObjectBuilder _builder = new ObjectBuilder();

            /// <summary>
            ///     Hases the obj
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The builder</returns>
            public ObjectBuilder Has(object obj)
            {
                _builder.HasObject = obj;
                return _builder;
            }
        }
    }
}