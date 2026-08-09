using System;
using System.IO;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// The rule branch coverage test class
    /// </summary>
    public class RuleBranchCoverageTest
    {
        /// <summary>
        /// Tests that rule applies has component returns true when archetype has component
        /// </summary>
        [Fact]
        public void RuleApplies_HasComponent_ReturnsTrueWhenArchetypeHasComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Rule rule = Rule.HasComponent(Component<Position>.Id);
            Assert.True(rule.RuleApplies(archetypeType));
        }

        /// <summary>
        /// Tests that rule applies has component returns false when archetype lacks component
        /// </summary>
        [Fact]
        public void RuleApplies_HasComponent_ReturnsFalseWhenArchetypeLacksComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Rule rule = Rule.HasComponent(Component<Velocity>.Id);
            Assert.False(rule.RuleApplies(archetypeType));
        }

        /// <summary>
        /// Tests that rule applies not component returns true when archetype lacks component
        /// </summary>
        [Fact]
        public void RuleApplies_NotComponent_ReturnsTrueWhenArchetypeLacksComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Rule rule = Rule.NotComponent(Component<Velocity>.Id);
            Assert.True(rule.RuleApplies(archetypeType));
        }

        /// <summary>
        /// Tests that rule applies not component returns false when archetype has component
        /// </summary>
        [Fact]
        public void RuleApplies_NotComponent_ReturnsFalseWhenArchetypeHasComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Rule rule = Rule.NotComponent(Component<Position>.Id);
            Assert.False(rule.RuleApplies(archetypeType));
        }

        /// <summary>
        /// Tests that rule applies delegate returns true when function returns true
        /// </summary>
        [Fact]
        public void RuleApplies_Delegate_ReturnsTrueWhenFunctionReturnsTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Rule rule = Rule.Delegate(_ => true);
            Assert.True(rule.RuleApplies(archetypeType));
        }

        /// <summary>
        /// Tests that rule applies delegate returns false when function returns false
        /// </summary>
        [Fact]
        public void RuleApplies_Delegate_ReturnsFalseWhenFunctionReturnsFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Rule rule = Rule.Delegate(_ => false);
            Assert.False(rule.RuleApplies(archetypeType));
        }

        /// <summary>
        /// Tests that rule applies include disabled returns true
        /// </summary>
        [Fact]
        public void RuleApplies_IncludeDisabled_ReturnsTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Assert.True(Rule.IncludeDisabledRule.RuleApplies(archetypeType));
        }

        /// <summary>
        /// Tests that rule applies default throws invalid data exception
        /// </summary>
        [Fact]
        public void RuleApplies_Default_ThrowsInvalidDataException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;
            Rule defaultRule = default;
            Assert.Throws<InvalidDataException>(() => { defaultRule.RuleApplies(archetypeType); });
        }

        /// <summary>
        /// Tests that Equals returns true for two rules with same component id
        /// </summary>
        [Fact]
        public void Equals_SameComponentId_ReturnsTrue()
        {
            ComponentId compId = Component<Position>.Id;
            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.HasComponent(compId);

            Assert.True(rule1.Equals(rule2));
        }

        /// <summary>
        /// Tests that Equals returns false for rules with different component ids
        /// </summary>
        [Fact]
        public void Equals_DifferentComponentIds_ReturnsFalse()
        {
            Rule rule1 = Rule.HasComponent(Component<Position>.Id);
            Rule rule2 = Rule.HasComponent(Component<Velocity>.Id);

            Assert.False(rule1.Equals(rule2));
        }

        /// <summary>
        /// Tests that Equals returns false for has vs not component with same id
        /// </summary>
        [Fact]
        public void Equals_DifferentRuleStates_ReturnsFalse()
        {
            ComponentId compId = Component<Position>.Id;
            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.NotComponent(compId);

            Assert.False(rule1.Equals(rule2));
        }

        /// <summary>
        /// Tests that Equals returns true when comparing with same delegate reference
        /// </summary>
        [Fact]
        public void Equals_SameDelegate_ReturnsTrue()
        {
            Func<GameObjectType, bool> func = _ => true;
            Rule rule1 = Rule.Delegate(func);
            Rule rule2 = Rule.Delegate(func);

            Assert.True(rule1.Equals(rule2));
        }

        /// <summary>
        /// Tests that Equals returns false when comparing with different delegate references
        /// </summary>
        [Fact]
        public void Equals_DifferentDelegates_ReturnsFalse()
        {
            Rule rule1 = Rule.Delegate(_ => true);
            Rule rule2 = Rule.Delegate(_ => true);

            Assert.False(rule1.Equals(rule2));
        }

        /// <summary>
        /// Tests that Equals(object) returns true when obj is a matching Rule
        /// </summary>
        [Fact]
        public void Equals_ObjectWithSameRule_ReturnsTrue()
        {
            ComponentId compId = Component<Position>.Id;
            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.HasComponent(compId);

            Assert.True(rule1.Equals((object)rule2));
        }

        /// <summary>
        /// Tests that Equals(object) returns false when obj is not a Rule
        /// </summary>
        [Fact]
        public void Equals_ObjectWithNonRule_ReturnsFalse()
        {
            Rule rule = Rule.HasComponent(Component<Position>.Id);

            Assert.False(rule.Equals("string"));
        }

        /// <summary>
        /// Tests that Equals(object) returns false when obj is null
        /// </summary>
        [Fact]
        public void Equals_ObjectWithNull_ReturnsFalse()
        {
            Rule rule = Rule.HasComponent(Component<Position>.Id);

            Assert.False(rule.Equals(null));
        }

        /// <summary>
        /// Tests that GetHashCode returns consistent values for the same rule
        /// </summary>
        [Fact]
        public void GetHashCode_IsConsistent()
        {
            Rule rule = Rule.HasComponent(Component<Position>.Id);

            int hash1 = rule.GetHashCode();
            int hash2 = rule.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        /// Tests that GetHashCode returns same value for equal rules
        /// </summary>
        [Fact]
        public void GetHashCode_EqualRules_ReturnSameHash()
        {
            ComponentId compId = Component<Position>.Id;
            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.HasComponent(compId);

            Assert.Equal(rule1.GetHashCode(), rule2.GetHashCode());
        }

        /// <summary>
        /// Tests that operator == returns true for equal rules
        /// </summary>
        [Fact]
        public void OperatorEquals_EqualRules_ReturnsTrue()
        {
            ComponentId compId = Component<Position>.Id;
            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.HasComponent(compId);

            Assert.True(rule1 == rule2);
        }

        /// <summary>
        /// Tests that operator == returns false for different rules
        /// </summary>
        [Fact]
        public void OperatorEquals_DifferentRules_ReturnsFalse()
        {
            Rule rule1 = Rule.HasComponent(Component<Position>.Id);
            Rule rule2 = Rule.HasComponent(Component<Velocity>.Id);

            Assert.False(rule1 == rule2);
        }

        /// <summary>
        /// Tests that operator != returns false for equal rules
        /// </summary>
        [Fact]
        public void OperatorNotEquals_EqualRules_ReturnsFalse()
        {
            ComponentId compId = Component<Position>.Id;
            Rule rule1 = Rule.HasComponent(compId);
            Rule rule2 = Rule.HasComponent(compId);

            Assert.False(rule1 != rule2);
        }

        /// <summary>
        /// Tests that operator != returns true for different rules
        /// </summary>
        [Fact]
        public void OperatorNotEquals_DifferentRules_ReturnsTrue()
        {
            Rule rule1 = Rule.HasComponent(Component<Position>.Id);
            Rule rule2 = Rule.HasComponent(Component<Velocity>.Id);

            Assert.True(rule1 != rule2);
        }

        /// <summary>
        /// Tests that IncludeDisabledRule is included in equality comparison
        /// </summary>
        [Fact]
        public void IncludeDisabledRule_EqualsItself()
        {
            Rule rule = Rule.IncludeDisabledRule;

            Assert.True(rule.Equals(Rule.IncludeDisabledRule));
            Assert.True(rule == Rule.IncludeDisabledRule);
        }

        /// <summary>
        /// Tests that NotComponent and HasComponent with same id are not equal via object Equals
        /// </summary>
        [Fact]
        public void Equals_ObjectHasComponentVsNotComponent_ReturnsFalse()
        {
            ComponentId compId = Component<Position>.Id;
            Rule hasRule = Rule.HasComponent(compId);
            Rule notRule = Rule.NotComponent(compId);

            Assert.False(hasRule.Equals((object)notRule));
        }
    }
}
