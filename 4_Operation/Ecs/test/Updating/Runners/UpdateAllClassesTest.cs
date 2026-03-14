// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:UpdateAllClassesTest.cs
//
//  --------------------------------------------------------------------------

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    /// Covers every Update<T...> class implemented in Update.cs.
    /// </summary>
    public class UpdateAllClassesTest
    {
        /// <summary>
        /// Tests that update arity 0 run updates every entity
        /// </summary>
        [Fact]
        public void Update_Arity0_Run_UpdatesEveryEntity()
        {
            using Scene scene = new Scene();
            GameObject first = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject second = scene.Create(new UpdateComponent {CallCount = 0});

            scene.Update();

            Assert.Equal(1, first.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, second.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that update arity 2 run mutates arguments by reference
        /// </summary>
        [Fact]
        public void Update_Arity2_Run_MutatesArgumentsByReference()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update2Component {CallCount = 0},
                new Position {X = 2, Y = 3},
                new Velocity {X = 4, Y = 5}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update2Component>().CallCount);
            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(8, entity.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that update arity 3 run mutates all expected components
        /// </summary>
        [Fact]
        public void Update_Arity3_Run_MutatesAllExpectedComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update3Component {CallCount = 0},
                new Position {X = 10, Y = 20},
                new Velocity {X = 1, Y = 2},
                new Health {Value = 50}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update3Component>().CallCount);
            Assert.Equal(11, entity.Get<Position>().X);
            Assert.Equal(22, entity.Get<Position>().Y);
            Assert.Equal(49, entity.Get<Health>().Value);
        }

        /// <summary>
        /// Tests that update arity 4 run invokes component and keeps expected state
        /// </summary>
        [Fact]
        public void Update_Arity4_Run_InvokesComponentAndKeepsExpectedState()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update4Component {CallCount = 0},
                new Position {X = 0, Y = 1},
                new Velocity {X = 7, Y = 9},
                new Health {Value = 30},
                new Armor {Value = 12}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update4Component>().CallCount);
            Assert.Equal(7, entity.Get<Position>().X);
            Assert.Equal(10, entity.Get<Position>().Y);
            Assert.Equal(30, entity.Get<Health>().Value);
            Assert.Equal(12, entity.Get<Armor>().Value);
        }

        /// <summary>
        /// Tests that update arity 6 run mutates all expected components
        /// </summary>
        [Fact]
        public void Update_Arity6_Run_MutatesAllExpectedComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update6Component {CallCount = 0},
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 100},
                new Armor {Value = 20},
                new Damage {Value = 5},
                new Transform {X = 0, Y = 0, Rotation = 0}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update6Component>().CallCount);
            Assert.Equal(4, entity.Get<Position>().X);
            Assert.Equal(6, entity.Get<Position>().Y);
            Assert.Equal(95, entity.Get<Health>().Value);
            Assert.Equal(21, entity.Get<Armor>().Value);
            Assert.Equal(7, entity.Get<Damage>().Value);
            Assert.Equal(1, entity.Get<Transform>().Rotation);
        }

        /// <summary>
        /// Tests that update arity 7 run mutates all expected components
        /// </summary>
        [Fact]
        public void Update_Arity7_Run_MutatesAllExpectedComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update7Component {CallCount = 0},
                new Position {X = 5, Y = 6},
                new Velocity {X = 1, Y = 2},
                new Health {Value = 80},
                new Armor {Value = 10},
                new Damage {Value = 4},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 9}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update7Component>().CallCount);
            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(8, entity.Get<Position>().Y);
            Assert.Equal(79, entity.Get<Health>().Value);
            Assert.Equal(14, entity.Get<Armor>().Value);
            Assert.Equal(1, entity.Get<Transform>().X);
            Assert.Equal(12, entity.Get<TestComponent>().Value);
        }

        /// <summary>
        /// Tests that update arity 8 run mutates all expected components
        /// </summary>
        [Fact]
        public void Update_Arity8_Run_MutatesAllExpectedComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Update8Component {CallCount = 0});
            entity.Add(
                new Position {X = 8, Y = 10},
                new Velocity {X = 2, Y = 3},
                new Health {Value = 40},
                new Armor {Value = 7},
                new Damage {Value = 6},
                new Transform {X = 1, Y = 2, Rotation = 3},
                new TestComponent {Value = 11},
                new AnotherComponent {Data = 1, Y = 2}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update8Component>().CallCount);
            Assert.Equal(10, entity.Get<Position>().X);
            Assert.Equal(13, entity.Get<Position>().Y);
            Assert.Equal(39, entity.Get<Health>().Value);
            Assert.Equal(9, entity.Get<Armor>().Value);
            Assert.Equal(7, entity.Get<Damage>().Value);
            Assert.Equal(5, entity.Get<Transform>().Rotation);
            Assert.Equal(22, entity.Get<TestComponent>().Value);
            Assert.Equal(2, entity.Get<AnotherComponent>().Data);
            Assert.Equal(3, entity.Get<AnotherComponent>().Y);
        }
    }
}


