using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// Exhaustive tests for QueryIterationExtensions delegate and inline overloads (arities 1..8).
    /// </summary>
    public class QueryIterationExtensionsTest
    {
        /// <summary>
        /// Tests that delegate arity 1 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity1_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new AnotherComponent2 {Data = 5});
            GameObject notMatch = scene.Create(new Health {Value = 99});

            Query query = scene.Query<With<Position>>();
            int calls = 0;

            query.Delegate<Position>((ref Position p) =>
            {
                calls++;
                p.X += 2;
                p.Y += 3;
            });

            Assert.Equal(2, calls);
            Assert.Equal(3, e1.Get<Position>().X);
            Assert.Equal(4, e1.Get<Position>().Y);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(13, e2.Get<Position>().Y);
            Assert.Equal(99, notMatch.Get<Health>().Value);
        }

        /// <summary>
        /// Tests that delegate arity 2 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity2_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 2});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 3, Y = 4}, new AnotherComponent2 {Data = 5});
            GameObject notMatch = scene.Create(new Position {X = 100, Y = 100});

            Query query = scene.Query<With<Position>, With<Velocity>>();
            int calls = 0;

            query.Delegate<Position, Velocity>((ref Position p, ref Velocity v) =>
            {
                calls++;
                p.X += v.X;
                p.Y += v.Y;
                v.X += 1;
                v.Y += 1;
            });

            Assert.Equal(2, calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(3, e1.Get<Position>().Y);
            Assert.Equal(2, e1.Get<Velocity>().X);
            Assert.Equal(3, e1.Get<Velocity>().Y);
            Assert.Equal(13, e2.Get<Position>().X);
            Assert.Equal(14, e2.Get<Position>().Y);
            Assert.Equal(4, e2.Get<Velocity>().X);
            Assert.Equal(5, e2.Get<Velocity>().Y);
            Assert.Equal(100, notMatch.Get<Position>().X);
        }

        /// <summary>
        /// Tests that delegate arity 3 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity3_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1}, new Health {Value = 10});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new Health {Value = 20}, new AnotherComponent2 {Data = 5});
            GameObject notMatch = scene.Create(new Position {X = 50, Y = 50}, new Velocity {X = 5, Y = 5});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int calls = 0;

            query.Delegate<Position, Velocity, Health>((ref Position p, ref Velocity v, ref Health h) =>
            {
                calls++;
                p.X += v.X;
                p.Y += v.Y;
                h.Value += 2;
            });

            Assert.Equal(2, calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(2, e1.Get<Position>().Y);
            Assert.Equal(12, e1.Get<Health>().Value);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(13, e2.Get<Position>().Y);
            Assert.Equal(22, e2.Get<Health>().Value);
            Assert.Equal(50, notMatch.Get<Position>().X);
        }

        /// <summary>
        /// Tests that delegate arity 4 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity4_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 10},
                new Armor {Value = 20}
            );
            GameObject e2 = scene.Create(
                new Position {X = 10, Y = 10},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 30},
                new Armor {Value = 40},
                new AnotherComponent2 {Data = 5}
            );
            GameObject notMatch = scene.Create(new Position {X = 99, Y = 99}, new Velocity {X = 9, Y = 9}, new Health {Value = 9});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>();
            int calls = 0;

            query.Delegate<Position, Velocity, Health, Armor>((ref Position p, ref Velocity v, ref Health h, ref Armor a) =>
            {
                calls++;
                p.X += 1;
                p.Y += 1;
                h.Value -= 1;
                a.Value += 2;
            });

            Assert.Equal(2, calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(9, e1.Get<Health>().Value);
            Assert.Equal(22, e1.Get<Armor>().Value);
            Assert.Equal(11, e2.Get<Position>().X);
            Assert.Equal(29, e2.Get<Health>().Value);
            Assert.Equal(42, e2.Get<Armor>().Value);
            Assert.Equal(99, notMatch.Get<Position>().X);
        }

        /// <summary>
        /// Tests that delegate arity 5 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity5_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 10},
                new Armor {Value = 20},
                new Damage {Value = 3}
            );
            GameObject e2 = scene.Create(
                new Position {X = 10, Y = 10},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 30},
                new Armor {Value = 40},
                new Damage {Value = 4},
                new AnotherComponent2 {Data = 5}
            );
            GameObject notMatch = scene.Create(new Position {X = 9, Y = 9}, new Velocity {X = 9, Y = 9}, new Health {Value = 9}, new Armor {Value = 9});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>();
            int calls = 0;

            query.Delegate<Position, Velocity, Health, Armor, Damage>((ref Position p, ref Velocity v, ref Health h, ref Armor a, ref Damage d) =>
            {
                calls++;
                p.X += v.X;
                h.Value += d.Value;
                a.Value += 1;
                d.Value += 2;
            });

            Assert.Equal(2, calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(13, e1.Get<Health>().Value);
            Assert.Equal(21, e1.Get<Armor>().Value);
            Assert.Equal(5, e1.Get<Damage>().Value);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(34, e2.Get<Health>().Value);
            Assert.Equal(41, e2.Get<Armor>().Value);
            Assert.Equal(6, e2.Get<Damage>().Value);
            Assert.Equal(9, notMatch.Get<Position>().X);
        }

        /// <summary>
        /// Tests that delegate arity 6 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity6_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 10},
                new Armor {Value = 20},
                new Damage {Value = 3},
                new Transform {X = 4, Y = 5, Rotation = 6}
            );
            GameObject e2 = scene.Create(
                new Position {X = 10, Y = 10},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 30},
                new Armor {Value = 40},
                new Damage {Value = 4},
                new Transform {X = 7, Y = 8, Rotation = 9},
                new AnotherComponent2 {Data = 5}
            );
            GameObject notMatch = scene.Create(new Position {X = 8, Y = 8}, new Velocity {X = 8, Y = 8}, new Health {Value = 8}, new Armor {Value = 8}, new Damage {Value = 8});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>();
            int calls = 0;

            query.Delegate<Position, Velocity, Health, Armor, Damage, Transform>((ref Position p, ref Velocity v, ref Health h, ref Armor a, ref Damage d, ref Transform t) =>
            {
                calls++;
                p.X += 1;
                h.Value += 1;
                a.Value += 1;
                d.Value += 1;
                t.Rotation += 10;
            });

            Assert.Equal(2, calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(11, e1.Get<Health>().Value);
            Assert.Equal(21, e1.Get<Armor>().Value);
            Assert.Equal(4, e1.Get<Damage>().Value);
            Assert.Equal(16, e1.Get<Transform>().Rotation);
            Assert.Equal(11, e2.Get<Position>().X);
            Assert.Equal(31, e2.Get<Health>().Value);
            Assert.Equal(41, e2.Get<Armor>().Value);
            Assert.Equal(5, e2.Get<Damage>().Value);
            Assert.Equal(19, e2.Get<Transform>().Rotation);
            Assert.Equal(8, notMatch.Get<Position>().X);
        }

        /// <summary>
        /// Tests that delegate arity 7 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity7_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 10},
                new Armor {Value = 20},
                new Damage {Value = 3},
                new Transform {X = 4, Y = 5, Rotation = 6},
                new TestComponent {Value = 7}
            );
            GameObject e2 = scene.Create(
                new Position {X = 10, Y = 10},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 30},
                new Armor {Value = 40},
                new Damage {Value = 4},
                new Transform {X = 7, Y = 8, Rotation = 9},
                new TestComponent {Value = 11},
                new AnotherComponent2 {Data = 5}
            );
            GameObject notMatch = scene.Create(new Position {X = 5, Y = 5}, new Velocity {X = 5, Y = 5}, new Health {Value = 5}, new Armor {Value = 5}, new Damage {Value = 5}, new Transform {X = 5, Y = 5, Rotation = 5});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>();
            int calls = 0;

            query.Delegate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>((ref Position p, ref Velocity v, ref Health h, ref Armor a, ref Damage d, ref Transform t, ref TestComponent tc) =>
            {
                calls++;
                p.X += v.X;
                tc.Value += 3;
                h.Value -= 2;
                t.X += 1;
            });

            Assert.Equal(2, calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(10, e1.Get<TestComponent>().Value);
            Assert.Equal(8, e1.Get<Health>().Value);
            Assert.Equal(5, e1.Get<Transform>().X);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(14, e2.Get<TestComponent>().Value);
            Assert.Equal(28, e2.Get<Health>().Value);
            Assert.Equal(8, e2.Get<Transform>().X);
            Assert.Equal(5, notMatch.Get<Position>().X);
        }

        /// <summary>
        /// Tests that delegate arity 8 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity8_UpdatesAllMatchingAcrossArchetypes()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 10},
                new Armor {Value = 20},
                new Damage {Value = 3},
                new Transform {X = 4, Y = 5, Rotation = 6},
                new TestComponent {Value = 7},
                new AnotherComponent {Data = 2, Y = 3}
            );
            GameObject e2 = scene.Create(
                new Position {X = 10, Y = 10},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 30},
                new Armor {Value = 40},
                new Damage {Value = 4},
                new Transform {X = 7, Y = 8, Rotation = 9},
                new TestComponent {Value = 11},
                new AnotherComponent {Data = 5, Y = 6}
            );
            e2.Add(new AnotherComponent2 {Data = 9});
            GameObject notMatch = scene.Create(
                new Position {X = 5, Y = 5},
                new Velocity {X = 5, Y = 5},
                new Health {Value = 5},
                new Armor {Value = 5},
                new Damage {Value = 5},
                new Transform {X = 5, Y = 5, Rotation = 5},
                new TestComponent {Value = 5}
            );

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
            int calls = 0;

            query.Delegate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>((ref Position p, ref Velocity v, ref Health h, ref Armor a, ref Damage d, ref Transform t, ref TestComponent tc, ref AnotherComponent ac) =>
            {
                calls++;
                p.Y += v.Y;
                h.Value += 1;
                a.Value += 1;
                d.Value += 1;
                t.Rotation += 1;
                tc.Value += 1;
                ac.Data += 1;
                ac.Y += 2;
            });

            Assert.Equal(2, calls);
            Assert.Equal(2, e1.Get<Position>().Y);
            Assert.Equal(11, e1.Get<Health>().Value);
            Assert.Equal(21, e1.Get<Armor>().Value);
            Assert.Equal(4, e1.Get<Damage>().Value);
            Assert.Equal(7, e1.Get<Transform>().Rotation);
            Assert.Equal(8, e1.Get<TestComponent>().Value);
            Assert.Equal(3, e1.Get<AnotherComponent>().Data);
            Assert.Equal(5, e1.Get<AnotherComponent>().Y);

            Assert.Equal(13, e2.Get<Position>().Y);
            Assert.Equal(31, e2.Get<Health>().Value);
            Assert.Equal(41, e2.Get<Armor>().Value);
            Assert.Equal(5, e2.Get<Damage>().Value);
            Assert.Equal(10, e2.Get<Transform>().Rotation);
            Assert.Equal(12, e2.Get<TestComponent>().Value);
            Assert.Equal(6, e2.Get<AnotherComponent>().Data);
            Assert.Equal(8, e2.Get<AnotherComponent>().Y);

            Assert.Equal(5, notMatch.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that delegate all arities do nothing on empty query
        /// </summary>
        [Fact]
        public void Delegate_AllArities_DoNothingOnEmptyQuery()
        {
            using Scene scene = new Scene();

            int c1 = 0;
            int c2 = 0;
            int c3 = 0;
            int c4 = 0;
            int c5 = 0;
            int c6 = 0;
            int c7 = 0;
            int c8 = 0;

            scene.Query<With<Position>>().Delegate<Position>((ref Position _) => c1++);
            scene.Query<With<Position>, With<Velocity>>().Delegate<Position, Velocity>((ref Position _, ref Velocity _) => c2++);
            scene.Query<With<Position>, With<Velocity>, With<Health>>().Delegate<Position, Velocity, Health>((ref Position _, ref Velocity _, ref Health _) => c3++);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>().Delegate<Position, Velocity, Health, Armor>((ref Position _, ref Velocity _, ref Health _, ref Armor _) => c4++);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>().Delegate<Position, Velocity, Health, Armor, Damage>((ref Position _, ref Velocity _, ref Health _, ref Armor _, ref Damage _) => c5++);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>().Delegate<Position, Velocity, Health, Armor, Damage, Transform>((ref Position _, ref Velocity _, ref Health _, ref Armor _, ref Damage _, ref Transform _) => c6++);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>().Delegate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>((ref Position _, ref Velocity _, ref Health _, ref Armor _, ref Damage _, ref Transform _, ref TestComponent _) => c7++);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>().Delegate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>((ref Position _, ref Velocity _, ref Health _, ref Armor _, ref Damage _, ref Transform _, ref TestComponent _, ref AnotherComponent _) => c8++);

            Assert.Equal(0, c1);
            Assert.Equal(0, c2);
            Assert.Equal(0, c3);
            Assert.Equal(0, c4);
            Assert.Equal(0, c5);
            Assert.Equal(0, c6);
            Assert.Equal(0, c7);
            Assert.Equal(0, c8);
        }

        /// <summary>
        /// Tests that inline arity 1 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity1_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction1.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new AnotherComponent2 {Data = 5});

            scene.Query<With<Position>>().Inline<InlineAction1, Position>(default);

            Assert.Equal(2, InlineAction1.Calls);
            Assert.Equal(3, e1.Get<Position>().X);
            Assert.Equal(4, e1.Get<Position>().Y);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(13, e2.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that inline arity 2 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity2_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction2.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 2});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 3, Y = 4}, new AnotherComponent2 {Data = 5});

            scene.Query<With<Position>, With<Velocity>>().Inline<InlineAction2, Position, Velocity>(default);

            Assert.Equal(2, InlineAction2.Calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(3, e1.Get<Position>().Y);
            Assert.Equal(13, e2.Get<Position>().X);
            Assert.Equal(14, e2.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that inline arity 3 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity3_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction3.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1}, new Health {Value = 10});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new Health {Value = 20}, new AnotherComponent2 {Data = 5});

            scene.Query<With<Position>, With<Velocity>, With<Health>>().Inline<InlineAction3, Position, Velocity, Health>(default);

            Assert.Equal(2, InlineAction3.Calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(12, e1.Get<Health>().Value);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(22, e2.Get<Health>().Value);
        }

        /// <summary>
        /// Tests that inline arity 4 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity4_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction4.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1}, new Health {Value = 10}, new Armor {Value = 20});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new Health {Value = 30}, new Armor {Value = 40}, new AnotherComponent2 {Data = 5});

            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>().Inline<InlineAction4, Position, Velocity, Health, Armor>(default);

            Assert.Equal(2, InlineAction4.Calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(9, e1.Get<Health>().Value);
            Assert.Equal(22, e1.Get<Armor>().Value);
            Assert.Equal(11, e2.Get<Position>().X);
            Assert.Equal(29, e2.Get<Health>().Value);
            Assert.Equal(42, e2.Get<Armor>().Value);
        }

        /// <summary>
        /// Tests that inline arity 5 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity5_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction5.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1}, new Health {Value = 10}, new Armor {Value = 20}, new Damage {Value = 3});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new Health {Value = 30}, new Armor {Value = 40}, new Damage {Value = 4}, new AnotherComponent2 {Data = 5});

            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>().Inline<InlineAction5, Position, Velocity, Health, Armor, Damage>(default);

            Assert.Equal(2, InlineAction5.Calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(13, e1.Get<Health>().Value);
            Assert.Equal(21, e1.Get<Armor>().Value);
            Assert.Equal(5, e1.Get<Damage>().Value);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(34, e2.Get<Health>().Value);
            Assert.Equal(41, e2.Get<Armor>().Value);
            Assert.Equal(6, e2.Get<Damage>().Value);
        }

        /// <summary>
        /// Tests that inline arity 6 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity6_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction6.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1}, new Health {Value = 10}, new Armor {Value = 20}, new Damage {Value = 3}, new Transform {X = 4, Y = 5, Rotation = 6});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new Health {Value = 30}, new Armor {Value = 40}, new Damage {Value = 4}, new Transform {X = 7, Y = 8, Rotation = 9}, new AnotherComponent2 {Data = 5});

            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>().Inline<InlineAction6, Position, Velocity, Health, Armor, Damage, Transform>(default);

            Assert.Equal(2, InlineAction6.Calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(11, e1.Get<Health>().Value);
            Assert.Equal(21, e1.Get<Armor>().Value);
            Assert.Equal(4, e1.Get<Damage>().Value);
            Assert.Equal(16, e1.Get<Transform>().Rotation);
            Assert.Equal(11, e2.Get<Position>().X);
            Assert.Equal(31, e2.Get<Health>().Value);
            Assert.Equal(41, e2.Get<Armor>().Value);
            Assert.Equal(5, e2.Get<Damage>().Value);
            Assert.Equal(19, e2.Get<Transform>().Rotation);
        }

        /// <summary>
        /// Tests that inline arity 7 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity7_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction7.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1}, new Health {Value = 10}, new Armor {Value = 20}, new Damage {Value = 3}, new Transform {X = 4, Y = 5, Rotation = 6}, new TestComponent {Value = 7});
            GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new Health {Value = 30}, new Armor {Value = 40}, new Damage {Value = 4}, new Transform {X = 7, Y = 8, Rotation = 9}, new TestComponent {Value = 11}, new AnotherComponent2 {Data = 5});

            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>().Inline<InlineAction7, Position, Velocity, Health, Armor, Damage, Transform, TestComponent>(default);

            Assert.Equal(2, InlineAction7.Calls);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(10, e1.Get<TestComponent>().Value);
            Assert.Equal(8, e1.Get<Health>().Value);
            Assert.Equal(5, e1.Get<Transform>().X);
            Assert.Equal(12, e2.Get<Position>().X);
            Assert.Equal(14, e2.Get<TestComponent>().Value);
            Assert.Equal(28, e2.Get<Health>().Value);
            Assert.Equal(8, e2.Get<Transform>().X);
        }

        /// <summary>
        /// Tests that inline arity 8 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity8_UpdatesAllMatchingAcrossArchetypes()
        {
            InlineAction8.Reset();

            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 10},
                new Armor {Value = 20},
                new Damage {Value = 3},
                new Transform {X = 4, Y = 5, Rotation = 6},
                new TestComponent {Value = 7},
                new AnotherComponent {Data = 2, Y = 3}
            );
            GameObject e2 = scene.Create(
                new Position {X = 10, Y = 10},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 30},
                new Armor {Value = 40},
                new Damage {Value = 4},
                new Transform {X = 7, Y = 8, Rotation = 9},
                new TestComponent {Value = 11},
                new AnotherComponent {Data = 5, Y = 6}
            );
            e2.Add(new AnotherComponent2 {Data = 9});

            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>().Inline<InlineAction8, Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>(default);

            Assert.Equal(2, InlineAction8.Calls);
            Assert.Equal(2, e1.Get<Position>().Y);
            Assert.Equal(11, e1.Get<Health>().Value);
            Assert.Equal(21, e1.Get<Armor>().Value);
            Assert.Equal(4, e1.Get<Damage>().Value);
            Assert.Equal(7, e1.Get<Transform>().Rotation);
            Assert.Equal(8, e1.Get<TestComponent>().Value);
            Assert.Equal(3, e1.Get<AnotherComponent>().Data);
            Assert.Equal(5, e1.Get<AnotherComponent>().Y);

            Assert.Equal(13, e2.Get<Position>().Y);
            Assert.Equal(31, e2.Get<Health>().Value);
            Assert.Equal(41, e2.Get<Armor>().Value);
            Assert.Equal(5, e2.Get<Damage>().Value);
            Assert.Equal(10, e2.Get<Transform>().Rotation);
            Assert.Equal(12, e2.Get<TestComponent>().Value);
            Assert.Equal(6, e2.Get<AnotherComponent>().Data);
            Assert.Equal(8, e2.Get<AnotherComponent>().Y);
        }

        /// <summary>
        /// Tests that inline all arities do nothing on empty query
        /// </summary>
        [Fact]
        public void Inline_AllArities_DoNothingOnEmptyQuery()
        {
            InlineAction1.Reset();
            InlineAction2.Reset();
            InlineAction3.Reset();
            InlineAction4.Reset();
            InlineAction5.Reset();
            InlineAction6.Reset();
            InlineAction7.Reset();
            InlineAction8.Reset();

            using Scene scene = new Scene();

            scene.Query<With<Position>>().Inline<InlineAction1, Position>(default);
            scene.Query<With<Position>, With<Velocity>>().Inline<InlineAction2, Position, Velocity>(default);
            scene.Query<With<Position>, With<Velocity>, With<Health>>().Inline<InlineAction3, Position, Velocity, Health>(default);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>>().Inline<InlineAction4, Position, Velocity, Health, Armor>(default);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>>().Inline<InlineAction5, Position, Velocity, Health, Armor, Damage>(default);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>>().Inline<InlineAction6, Position, Velocity, Health, Armor, Damage, Transform>(default);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>>().Inline<InlineAction7, Position, Velocity, Health, Armor, Damage, Transform, TestComponent>(default);
            scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>().Inline<InlineAction8, Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>(default);

            Assert.Equal(0, InlineAction1.Calls);
            Assert.Equal(0, InlineAction2.Calls);
            Assert.Equal(0, InlineAction3.Calls);
            Assert.Equal(0, InlineAction4.Calls);
            Assert.Equal(0, InlineAction5.Calls);
            Assert.Equal(0, InlineAction6.Calls);
            Assert.Equal(0, InlineAction7.Calls);
            Assert.Equal(0, InlineAction8.Calls);
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction1 : IAction<Position>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            public void Run(ref Position arg1)
            {
                Calls++;
                arg1.X += 2;
                arg1.Y += 3;
            }
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction2 : Alis.Core.Aspect.Fluent.Components.IAction<Position, Velocity>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            public void Run(ref Position arg1, ref Velocity arg2)
            {
                Calls++;
                arg1.X += arg2.X;
                arg1.Y += arg2.Y;
                arg2.X += 1;
                arg2.Y += 1;
            }
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction3 : Alis.Core.Aspect.Fluent.Components.IAction<Position, Velocity, Health>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            public void Run(ref Position arg1, ref Velocity arg2, ref Health arg3)
            {
                Calls++;
                arg1.X += arg2.X;
                arg1.Y += arg2.Y;
                arg3.Value += 2;
            }
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction4 : Alis.Core.Aspect.Fluent.Components.IAction<Position, Velocity, Health, Armor>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            public void Run(ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4)
            {
                Calls++;
                arg1.X += 1;
                arg1.Y += 1;
                arg3.Value -= 1;
                arg4.Value += 2;
            }
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction5 : Alis.Core.Aspect.Fluent.Components.IAction<Position, Velocity, Health, Armor, Damage>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            public void Run(ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4, ref Damage arg5)
            {
                Calls++;
                arg1.X += arg2.X;
                arg3.Value += arg5.Value;
                arg4.Value += 1;
                arg5.Value += 2;
            }
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction6 : Alis.Core.Aspect.Fluent.Components.IAction<Position, Velocity, Health, Armor, Damage, Transform>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            /// <param name="arg6">The arg</param>
            public void Run(ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4, ref Damage arg5, ref Transform arg6)
            {
                Calls++;
                arg1.X += 1;
                arg3.Value += 1;
                arg4.Value += 1;
                arg5.Value += 1;
                arg6.Rotation += 10;
            }
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction7 : Alis.Core.Aspect.Fluent.Components.IAction<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            /// <param name="arg6">The arg</param>
            /// <param name="arg7">The arg</param>
            public void Run(ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4, ref Damage arg5, ref Transform arg6, ref TestComponent arg7)
            {
                Calls++;
                arg1.X += arg2.X;
                arg7.Value += 3;
                arg3.Value -= 2;
                arg6.X += 1;
            }
        }

        /// <summary>
        /// The inline action
        /// </summary>
        private struct InlineAction8 : Alis.Core.Aspect.Fluent.Components.IAction<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>
        {
            /// <summary>
            /// The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            /// Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            /// Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            /// <param name="arg6">The arg</param>
            /// <param name="arg7">The arg</param>
            /// <param name="arg8">The arg</param>
            public void Run(ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4, ref Damage arg5, ref Transform arg6, ref TestComponent arg7, ref AnotherComponent arg8)
            {
                Calls++;
                arg1.Y += arg2.Y;
                arg3.Value += 1;
                arg4.Value += 1;
                arg5.Value += 1;
                arg6.Rotation += 1;
                arg7.Value += 1;
                arg8.Data += 1;
                arg8.Y += 2;
            }
        }
    }
}

