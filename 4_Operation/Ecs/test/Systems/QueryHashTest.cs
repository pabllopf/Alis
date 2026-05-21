

using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The query hash test class
    /// </summary>
    /// <remarks>
    ///     Tests the QueryHash struct that provides hash code generation for queries.
    ///     This is critical for query caching and performance optimization in the ECS.
    /// </remarks>
    public class QueryHashTest
    {
        /// <summary>
        ///     Tests that QueryHash can be created with default constructor
        /// </summary>
        /// <remarks>
        ///     Validates that QueryHash can be instantiated using default constructor.
        /// </remarks>
        [Fact]
        public void QueryHash_CanBeCreatedWithDefaultConstructor()
        {
            QueryHash hash = new QueryHash();

            Assert.NotEqual(0, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that QueryHash.New() creates a new instance
        /// </summary>
        /// <remarks>
        ///     Validates that the static New() method creates a valid QueryHash instance.
        /// </remarks>
        [Fact]
        public void QueryHash_NewMethod_CreatesInstance()
        {
            QueryHash hash = QueryHash.New();

            Assert.NotEqual(0, hash.ToHashCode());
        }

        /// <summary>
        ///     Tests that two new QueryHash instances have the same initial hash
        /// </summary>
        /// <remarks>
        ///     Validates that QueryHash instances start with the same initial state.
        /// </remarks>
        [Fact]
        public void QueryHash_TwoNewInstances_HaveSameInitialHash()
        {
            QueryHash hash1 = QueryHash.New();
            QueryHash hash2 = QueryHash.New();

            Assert.Equal(hash1.ToHashCode(), hash2.ToHashCode());
        }

        /// <summary>
        ///     Tests that QueryHash default value has valid hash
        /// </summary>
        /// <remarks>
        ///     Validates that default(QueryHash) produces a valid hash code.
        /// </remarks>
        [Fact]
        public void QueryHash_DefaultValue_HasValidHash()
        {
            QueryHash defaultHash = default(QueryHash);

            Assert.Equal(0, defaultHash.ToHashCode());
        }
    }
}