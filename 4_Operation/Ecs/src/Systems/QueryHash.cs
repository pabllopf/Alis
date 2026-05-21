

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Computes and stores a hash value for a query based on its component rules.
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: 4 bytes total (single int).
    ///     Pack = 1 for minimal memory footprint.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct QueryHash
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryHash"/> struct.
        /// </summary>
        public QueryHash()
        {
        }

        /// <summary>
        ///     The internal hash state used for computing the final hash.
        /// </summary>
        private int _state = 12582917;

        /// <summary>
        ///     Creates a new empty <see cref="QueryHash"/> instance.
        /// </summary>
        /// <returns>A new <see cref="QueryHash"/> ready for rule additions.</returns>
        public static QueryHash New() => new QueryHash();

        /// <summary>
        ///     Creates a new <see cref="QueryHash"/> pre-populated with the specified rules.
        /// </summary>
        /// <param name="rules">The rules to include in the hash computation.</param>
        /// <returns>A <see cref="QueryHash"/> containing the combined hash of all rules.</returns>
        public static QueryHash New(FastImmutableArray<Rule> rules)
        {
            QueryHash hash = new QueryHash();
            foreach (Rule rule in rules)
            {
                hash.AddRule(rule);
            }

            return hash;
        }

        /// <summary>
        ///     Adds a rule's hash code into this <see cref="QueryHash"/>.
        /// </summary>
        /// <param name="rule">The rule to incorporate into the hash.</param>
        /// <returns>This <see cref="QueryHash"/> after the rule has been added, for method chaining.</returns>
        public QueryHash AddRule(Rule rule)
        {
            _state *= rule.GetHashCode();
            return this;
        }

        /// <summary>
        ///     Produces the final hash code from the accumulated rules.
        /// </summary>
        /// <returns>The computed hash code as an integer.</returns>
        public int ToHashCode() => _state;
    }
}