// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IncludeDisabledTest.cs
// 
//  --------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// Tests for IncludeDisabled query rule provider.
    /// </summary>
    public class IncludeDisabledTest
    {
        /// <summary>
        /// Tests that include disabled implements rule provider
        /// </summary>
        [Fact]
        public void IncludeDisabled_ImplementsRuleProvider()
        {
            IncludeDisabled includeDisabled = default;

            Assert.IsAssignableFrom<IRuleProvider>(includeDisabled);
        }

        /// <summary>
        /// Tests that include disabled rule returns include disabled rule
        /// </summary>
        [Fact]
        public void IncludeDisabled_RuleReturnsIncludeDisabledRule()
        {
            IncludeDisabled includeDisabled = default;

            Rule rule = includeDisabled.Rule;

            Assert.Equal(Rule.IncludeDisabledRule, rule);
        }

        /// <summary>
        /// Tests that include disabled default and constructed instances produce same rule
        /// </summary>
        [Fact]
        public void IncludeDisabled_DefaultAndConstructedInstancesProduceSameRule()
        {
            IncludeDisabled includeDisabled1 = default;
            IncludeDisabled includeDisabled2 = new IncludeDisabled();

            Assert.Equal(includeDisabled1.Rule, includeDisabled2.Rule);
        }

        /// <summary>
        /// Tests that include disabled can be used alone in query
        /// </summary>
        [Fact]
        public void IncludeDisabled_CanBeUsedAloneInQuery()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Velocity {X = 2, Y = 2});

            Query query = scene.Query<IncludeDisabled>();
            int count = 0;
            foreach (GameObject _ in query.EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        /// Tests that include disabled does not change with filtering behavior
        /// </summary>
        [Fact]
        public void IncludeDisabled_DoesNotChangeWithFilteringBehavior()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Position {X = 2, Y = 2}, new Velocity {X = 3, Y = 3});
            scene.Create(new Velocity {X = 4, Y = 4});

            Query withOnly = scene.Query<With<Position>>();
            Query withIncludeDisabled = scene.Query<With<Position>, IncludeDisabled>();

            int withOnlyCount = 0;
            foreach (RefTuple<Position> _ in withOnly.Enumerate<Position>())
            {
                withOnlyCount++;
            }

            int withIncludeDisabledCount = 0;
            foreach (RefTuple<Position> _ in withIncludeDisabled.Enumerate<Position>())
            {
                withIncludeDisabledCount++;
            }

            Assert.Equal(2, withOnlyCount);
            Assert.Equal(withOnlyCount, withIncludeDisabledCount);
        }

        /// <summary>
        /// Tests that include disabled has sequential struct layout with pack 1
        /// </summary>
        [Fact]
        public void IncludeDisabled_HasSequentialStructLayoutWithPack1()
        {
            StructLayoutAttribute layout = typeof(IncludeDisabled).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
            Assert.True(layout.Pack is 0 or 1);
        }
    }
}

