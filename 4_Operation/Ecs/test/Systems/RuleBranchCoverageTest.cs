using System;
using System.IO;
using System.Reflection;
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
        /// Tests that rule applies custom delegate with null delegate throws null reference exception
        /// </summary>
        [Fact]
        public void RuleApplies_CustomDelegateWithNullDelegate_ThrowsNullReferenceException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObjectType archetypeType = entity.Type;

            Rule rule = default;
            FieldInfo ruleStateField = typeof(Rule).GetField("_ruleState", BindingFlags.Instance | BindingFlags.NonPublic);

            object boxed = rule;
            ruleStateField.SetValue(boxed, 1);
            rule = (Rule)boxed;

            Assert.Throws<NullReferenceException>(() => { rule.RuleApplies(archetypeType); });
        }
    }
}
