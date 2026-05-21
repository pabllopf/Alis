

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IWhere interface.
    ///     Tests the Where method for conditional fluent queries.
    /// </summary>
    public class IWhereTest
    {
        /// <summary>
        ///     Tests that IWhere can be implemented.
        /// </summary>
        [Fact]
        public void IWhere_CanBeImplemented()
        {
            WhereBuilder builder = new WhereBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IWhere<QueryBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Where returns builder.
        /// </summary>
        [Fact]
        public void Where_ReturnsBuilder()
        {
            WhereBuilder builder = new WhereBuilder();
            QueryBuilder result = builder.Where("condition");
            Assert.NotNull(result);
            Assert.IsType<QueryBuilder>(result);
        }

        /// <summary>
        ///     Tests that Where stores condition correctly.
        /// </summary>
        [Fact]
        public void Where_StoresConditionCorrectly()
        {
            WhereBuilder builder = new WhereBuilder();
            QueryBuilder result = builder.Where("id > 5");
            Assert.Equal("id > 5", result.Condition);
        }

        /// <summary>
        ///     Tests query building with Where.
        /// </summary>
        [Fact]
        public void Where_SupportsQueryBuilding()
        {
            WhereBuilder whereBuilder = new WhereBuilder();
            QueryBuilder result = whereBuilder.Where("name = 'test'");
            Assert.Equal("name = 'test'", result.Condition);
        }

        /// <summary>
        ///     Tests IWhere with integer conditions.
        /// </summary>
        [Fact]
        public void IWhere_WithIntegerCondition()
        {
            IntWhereBuilder builder = new IntWhereBuilder();
            IntQueryBuilder result = builder.Where(10);
            Assert.Equal(10, result.MinValue);
        }

        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class QueryBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the condition
            /// </summary>
            public string Condition { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IWhere.
        /// </summary>
        private class WhereBuilder : IWhere<QueryBuilder, string>
        {
            /// <summary>
            ///     The query builder
            /// </summary>
            private readonly QueryBuilder _builder = new QueryBuilder();

            /// <summary>
            ///     Wheres the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public QueryBuilder Where(string value)
            {
                _builder.Condition = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Helper builder with integer.
        /// </summary>
        private class IntQueryBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the min value
            /// </summary>
            public int MinValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation with integer condition.
        /// </summary>
        private class IntWhereBuilder : IWhere<IntQueryBuilder, int>
        {
            /// <summary>
            ///     The int query builder
            /// </summary>
            private readonly IntQueryBuilder _builder = new IntQueryBuilder();

            /// <summary>
            ///     Wheres the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public IntQueryBuilder Where(int value)
            {
                _builder.MinValue = value;
                return _builder;
            }
        }
    }
}