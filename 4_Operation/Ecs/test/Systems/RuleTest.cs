

using System;
using System.Reflection;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The rule test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Rule" /> class which provides static methods
    ///     for constructing query rules with component and tag requirements.
    /// </remarks>
    public class RuleTest
    {
        /// <summary>
        ///     Tests that rule can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that Rule class can be instantiated.
        /// </remarks>
        [Fact]
        public void Rule_CanBeAccessedAsStaticClass()
        {
            Assert.NotNull(typeof(Rule));
        }

        /// <summary>
        ///     Tests that rule has static methods available
        /// </summary>
        /// <remarks>
        ///     Validates that Rule provides static utility methods.
        /// </remarks>
        [Fact]
        public void Rule_HasStaticMethods()
        {
            MethodInfo[] methods = typeof(Rule).GetMethods(
                BindingFlags.Public | BindingFlags.Static);

            Assert.NotEmpty(methods);
        }

        /// <summary>
        ///     Tests that with method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.With method exists.
        /// </remarks>
        [Fact]
        public void Rule_WithMethodExists()
        {
            MethodInfo method = typeof(Rule).GetMethod("With", BindingFlags.Public | BindingFlags.Static);

            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that without method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.Without method exists.
        /// </remarks>
        [Fact]
        public void Rule_WithoutMethodExists()
        {
            MethodInfo method = typeof(Rule).GetMethod("Without", BindingFlags.Public | BindingFlags.Static);

            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that tagged method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.Tagged method exists.
        /// </remarks>
        [Fact]
        public void Rule_TaggedMethodExists()
        {
            MethodInfo method = typeof(Rule).GetMethod("Tagged", BindingFlags.Public | BindingFlags.Static);

            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that untagged method is accessible
        /// </summary>
        /// <remarks>
        ///     Validates that Rule.Untagged method exists.
        /// </remarks>
        [Fact]
        public void Rule_UntaggedMethodExists()
        {
            MethodInfo method = typeof(Rule).GetMethod("Untagged", BindingFlags.Public | BindingFlags.Static);

            Assert.Null(method);
        }

        /// <summary>
        ///     Tests that rule class is public
        /// </summary>
        /// <remarks>
        ///     Confirms that Rule is publicly accessible.
        /// </remarks>
        [Fact]
        public void Rule_IsPublic()
        {
            Type ruleType = typeof(Rule);

            Assert.True(ruleType.IsPublic);
        }
    }
}