using System.Collections.Immutable;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The query hash
    /// </summary>
    internal struct QueryHash
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHash"/> class
        /// </summary>
        public QueryHash() { }
        /// <summary>
        /// The state
        /// </summary>
        private int _state = 12582917;

        /// <summary>
        /// News
        /// </summary>
        /// <returns>The query hash</returns>
        public static QueryHash New() => new QueryHash();
        /// <summary>
        /// News the rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The hash</returns>
        public static QueryHash New(ImmutableArray<Rule> rules)
        {
            var hash = new QueryHash();
            foreach (var rule in rules)
            {
                hash.AddRule(rule);
            }
            return hash;
        }

        /// <summary>
        /// Adds the rule using the specified rule
        /// </summary>
        /// <param name="rule">The rule</param>
        /// <returns>The query hash</returns>
        public QueryHash AddRule(Rule rule)
        {
            _state *= rule.GetHashCode();
            return this;
        }

        /// <summary>
        /// Returns the hash code
        /// </summary>
        /// <returns>The int</returns>
        public int ToHashCode() => _state;
    }
}