

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Tests for Not{T} query rule provider.
    /// </summary>
    public class NotTest
    {
        /// <summary>
        ///     Tests that not implements rule provider
        /// </summary>
        [Fact]
        public void Not_ImplementsRuleProvider()
        {
            Not<Position> not = default(Not<Position>);

            Assert.IsAssignableFrom<IRuleProvider>(not);
        }

        /// <summary>
        ///     Tests that not rule returns not component rule
        /// </summary>
        [Fact]
        public void Not_RuleReturnsNotComponentRule()
        {
            Not<Position> not = default(Not<Position>);

            Rule rule = not.Rule;

            Assert.Equal(Rule.NotComponent(Component<Position>.Id), rule);
        }

        /// <summary>
        ///     Tests that not default and constructed instances produce same rule
        /// </summary>
        [Fact]
        public void Not_DefaultAndConstructedInstancesProduceSameRule()
        {
            Not<Position> not1 = default(Not<Position>);
            Not<Position> not2 = new Not<Position>();

            Assert.Equal(not1.Rule, not2.Rule);
        }

        /// <summary>
        ///     Tests that not for different types produces different rules
        /// </summary>
        [Fact]
        public void Not_ForDifferentTypes_ProducesDifferentRules()
        {
            Not<Position> notPos = default(Not<Position>);
            Not<Velocity> notVel = default(Not<Velocity>);

            Assert.NotEqual(notPos.Rule, notVel.Rule);
        }

        /// <summary>
        ///     Tests that not can be used in query
        /// </summary>
        [Fact]
        public void Not_CanBeUsedInQuery()
        {
            using Scene scene = new Scene();
            scene.Create(new Velocity {X = 1, Y = 1});
            scene.Create();

            Query query = scene.Query<Not<Position>>();
            int count = 0;
            foreach (GameObject _ in query.EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that not filters entities correctly
        /// </summary>
        [Fact]
        public void Not_FiltersEntitiesCorrectly()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Velocity {X = 2, Y = 2});
            scene.Create(new Velocity {X = 3, Y = 3}, new Health {Value = 10});

            Query query = scene.Query<Not<Position>, With<Velocity>>();
            int count = 0;
            foreach (RefTuple<Velocity> _ in query.Enumerate<Velocity>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that not can be combined with with rule
        /// </summary>
        [Fact]
        public void Not_CanBeCombinedWithWithRule()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1});
            scene.Create(new Velocity {X = 2, Y = 2});
            scene.Create(new Velocity {X = 3, Y = 3}, new Health {Value = 10});

            Query query = scene.Query<With<Velocity>, Not<Position>>();
            int count = 0;
            foreach (RefTuple<Velocity> _ in query.Enumerate<Velocity>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that not has sequential struct layout with pack 1
        /// </summary>
        [Fact]
        public void Not_HasSequentialStructLayoutWithPack1()
        {
            StructLayoutAttribute layout = typeof(Not<Position>).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
            Assert.True(layout.Pack is 0 or 1);
        }
    }
}
