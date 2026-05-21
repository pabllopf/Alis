

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The with test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="With{T}" /> struct which specifies that a query
    ///     should include entities that have a specific component type.
    /// </remarks>
    public class WithTest
    {
        /// <summary>
        ///     Tests that with implements rule provider
        /// </summary>
        /// <remarks>
        ///     Verifies that With implements IRuleProvider interface.
        /// </remarks>
        [Fact]
        public void With_ImplementsRuleProvider()
        {
            With<Position> with = default(With<Position>);

            Assert.IsAssignableFrom<IRuleProvider>(with);
        }

        /// <summary>
        ///     Tests that with rule returns has component rule
        /// </summary>
        /// <remarks>
        ///     Validates that With.Rule returns a rule for HasComponent.
        /// </remarks>
        [Fact]
        public void With_RuleReturnsHasComponentRule()
        {
            With<Position> with = default(With<Position>);

            Rule rule = with.Rule;

            Assert.NotEqual(default(Rule), rule);
        }

        /// <summary>
        ///     Tests that with can be used in query
        /// </summary>
        /// <remarks>
        ///     Validates that With can be used in Scene.Query.
        /// </remarks>
        [Fact]
        public void With_CanBeUsedInQuery()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that with filters entities correctly
        /// </summary>
        /// <remarks>
        ///     Tests that With only includes entities with the specified component.
        /// </remarks>
        [Fact]
        public void With_FiltersEntitiesCorrectly()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Velocity {X = 1, Y = 1}); // No Position

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that multiple with filters work together
        /// </summary>
        /// <remarks>
        ///     Validates that multiple With filters can be combined in a query.
        /// </remarks>
        [Fact]
        public void MultipleWithFilters_WorkTogether()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1});
            scene.Create(new Position {X = 2, Y = 2});

            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that with default instance has valid rule
        /// </summary>
        /// <remarks>
        ///     Validates that default With instance produces a valid rule.
        /// </remarks>
        [Fact]
        public void With_DefaultInstanceHasValidRule()
        {
            With<Position> with1 = default(With<Position>);
            With<Position> with2 = new With<Position>();

            Rule rule1 = with1.Rule;
            Rule rule2 = with2.Rule;

            Assert.Equal(rule1, rule2);
        }

        /// <summary>
        ///     Tests that with for different types creates different rules
        /// </summary>
        /// <remarks>
        ///     Validates that With for different component types creates different rules.
        /// </remarks>
        [Fact]
        public void With_ForDifferentTypes_CreatesDifferentRules()
        {
            With<Position> withPos = default(With<Position>);
            With<Velocity> withVel = default(With<Velocity>);

            Rule rulePos = withPos.Rule;
            Rule ruleVel = withVel.Rule;

            Assert.NotEqual(rulePos, ruleVel);
        }
    }
}