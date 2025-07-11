using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Encapsulates a check for an gameObject, used to filter queries
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public struct Rule : IEquatable<Rule>
    {
        /// <summary>
        ///     The rule state
        /// </summary>
        private RuleState _ruleState;

        /// <summary>
        ///     The custom
        /// </summary>
        private Func<GameObjectType, bool> _custom;

        /// <summary>
        ///     The comp id
        /// </summary>
        private ComponentId _compId;

        /// <summary>
        ///     The tag id
        /// </summary>
        private TagId _tagId;

        /// <summary>
        ///     Rules the applies using the specified archetype id
        /// </summary>
        /// <param name="archetypeId">The archetype id</param>
        /// <returns>The bool</returns>
        internal bool RuleApplies(GameObjectType archetypeId)
        {
            return _ruleState switch
            {
                RuleState.NotComponent => !archetypeId.HasComponent(_compId),
                RuleState.HasComponent => archetypeId.HasComponent(_compId),
                RuleState.NotTag => !archetypeId.HasTag(_tagId),
                RuleState.HasTag => archetypeId.HasTag(_tagId),
                RuleState.CustomDelegate => _custom!(archetypeId),
                RuleState.IncludeDisabled => true,
                _ => throw new InvalidDataException("Rule not initialized correctly. Use one of the factory methods.")
            };
        }

        /// <summary>
        ///     Creates a custom delegate-based rule.
        /// </summary>
        /// <param name="rule">The custom delegate to determine rule applicability.</param>
        /// <returns>A <see cref="Rule" /> configured with the custom delegate.</returns>
        public static Rule Delegate(Func<GameObjectType, bool> rule)
        {
            return new Rule
            {
                _ruleState = RuleState.CustomDelegate,
                _custom = rule
            };
        }

        /// <summary>
        ///     Creates a rule that applies when an archetype has the specified component.
        /// </summary>
        /// <param name="compId">The ID of the component to check for.</param>
        /// <returns>A <see cref="Rule" /> that checks for the presence of a component.</returns>
        public static Rule HasComponent(ComponentId compId)
        {
            return new Rule
            {
                _ruleState = RuleState.HasComponent,
                _compId = compId
            };
        }

        /// <summary>
        ///     Creates a rule that applies when an archetype does not have the specified component.
        /// </summary>
        /// <param name="compId">The ID of the component to check for absence.</param>
        /// <returns>A <see cref="Rule" /> that checks for the absence of a component.</returns>
        public static Rule NotComponent(ComponentId compId)
        {
            return new Rule
            {
                _ruleState = RuleState.NotComponent,
                _compId = compId
            };
        }

        /// <summary>
        ///     Creates a rule that applies when an archetype has the specified tag.
        /// </summary>
        /// <param name="tagId">The ID of the tag to check for.</param>
        /// <returns>A <see cref="Rule" /> that checks for the presence of a tag.</returns>
        public static Rule HasTag(TagId tagId)
        {
            return new Rule
            {
                _ruleState = RuleState.HasTag,
                _tagId = tagId
            };
        }

        /// <summary>
        ///     Creates a rule that applies when an archetype does not have the specified tag.
        /// </summary>
        /// <param name="tagId">The ID of the tag to check for absence.</param>
        /// <returns>A <see cref="Rule" /> that checks for the absence of a tag.</returns>
        public static Rule NotTag(TagId tagId)
        {
            return new Rule
            {
                _ruleState = RuleState.NotTag,
                _tagId = tagId
            };
        }

        /// <summary>
        ///     Determines whether this <see cref="Rule" /> is equal to another <see cref="Rule" />.
        /// </summary>
        /// <param name="other">The <see cref="Rule" /> to compare against.</param>
        /// <returns><see langword="true" /> if the rules are equal, <see langword="false" /> otherwise.</returns>
        public bool Equals(Rule other)
        {
            return _ruleState == other._ruleState &&
                   _custom == other._custom &&
                   _compId.Equals(other._compId) &&
                   _tagId.Equals(other._tagId);
        }

        /// <summary>
        ///     Determines whether this <see cref="Rule" /> is equal to an object.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>
        ///     <see langword="true" /> if the object is a <see cref="Rule" /> and they are equal, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Rule other && Equals(other);
        }

        /// <summary>
        ///     Gets a hash code for this <see cref="Rule" />.
        /// </summary>
        /// <returns>A hash code representing this <see cref="Rule" />.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_ruleState, _custom, _compId, _tagId);
        }

        /// <summary>
        ///     Determines whether two <see cref="Rule" /> instances are equal.
        /// </summary>
        /// <param name="left">The first rule to compare.</param>
        /// <param name="right">The second rule to compare.</param>
        /// <returns><see langword="true" /> if the rules are equal, <see langword="false" /> otherwise.</returns>
        public static bool operator ==(Rule left, Rule right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two <see cref="Rule" /> instances are not equal.
        /// </summary>
        /// <param name="left">The first rule to compare.</param>
        /// <param name="right">The second rule to compare.</param>
        /// <returns><see langword="true" /> if the rules are not equal, <see langword="false" /> otherwise.</returns>
        public static bool operator !=(Rule left, Rule right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     The rule state enum
        /// </summary>
        private enum RuleState
        {
            /// <summary>
            ///     The none rule state
            /// </summary>
            None = 0,

            /// <summary>
            ///     The custom delegate rule state
            /// </summary>
            CustomDelegate,

            /// <summary>
            ///     The has component rule state
            /// </summary>
            HasComponent,

            /// <summary>
            ///     The not component rule state
            /// </summary>
            NotComponent,

            /// <summary>
            ///     The has tag rule state
            /// </summary>
            HasTag,

            /// <summary>
            ///     The not tag rule state
            /// </summary>
            NotTag,

            /// <summary>
            ///     The include disabled rule state
            /// </summary>
            IncludeDisabled
        }

        /// <summary>
        ///     Using this rule will include disabled entities in a query.
        /// </summary>
        public static readonly Rule IncludeDisabledRule = new Rule { _ruleState = RuleState.IncludeDisabled };
    }
}