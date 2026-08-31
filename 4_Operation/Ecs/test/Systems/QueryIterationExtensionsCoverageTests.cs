// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryIterationExtensionsCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The query iteration extensions coverage tests class
    /// </summary>
    public class QueryIterationExtensionsCoverageTests
    {
        /// <summary>
        ///     Tests that delegate arity 2 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity2_UpdatesAllMatchingAcrossArchetypes()
        {
            using (Scene scene = new Scene())
            {
                GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1});
                GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new AnotherComponent2 {Data = 5});
                GameObject notMatch = scene.Create(new Position {X = 50, Y = 50});

                Query query = scene.Query<With<Position>, With<Velocity>>();
                int calls = 0;

                query.Delegate((ref Position p, ref Velocity v) =>
                {
                    calls++;
                    p.X += v.X;
                    p.Y += v.Y;
                    v.X += 1;
                    v.Y += 1;
                });

                Assert.Equal(2, calls);
                Assert.Equal(2, e1.Get<Position>().X);
                Assert.Equal(2, e1.Get<Position>().Y);
                Assert.Equal(2, e1.Get<Velocity>().X);
                Assert.Equal(12, e2.Get<Position>().X);
                Assert.Equal(13, e2.Get<Position>().Y);
                Assert.Equal(3, e2.Get<Velocity>().X);
                Assert.Equal(50, notMatch.Get<Position>().X);
            }
        }

        /// <summary>
        ///     Tests that inline arity 2 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity2_UpdatesAllMatchingAcrossArchetypes()
        {
            CoverageInlineAction2.Reset();

            using (Scene scene = new Scene())
            {
                GameObject e1 = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1});
                GameObject e2 = scene.Create(new Position {X = 10, Y = 10}, new Velocity {X = 2, Y = 3}, new AnotherComponent2 {Data = 5});

                scene.Query<With<Position>, With<Velocity>>().Inline<CoverageInlineAction2, Position, Velocity>(default(CoverageInlineAction2));

                Assert.Equal(2, CoverageInlineAction2.Calls);
                Assert.Equal(2, e1.Get<Position>().X);
                Assert.Equal(2, e1.Get<Position>().Y);
                Assert.Equal(2, e1.Get<Velocity>().X);
                Assert.Equal(12, e2.Get<Position>().X);
                Assert.Equal(13, e2.Get<Position>().Y);
                Assert.Equal(3, e2.Get<Velocity>().X);
            }
        }

        /// <summary>
        ///     Tests that delegate arity 8 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Delegate_Arity8_UpdatesAllMatchingAcrossArchetypes()
        {
            using (Scene scene = new Scene())
            {
                GameObject e1 = scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 1, Y = 1},
                    new Health {Value = 10},
                    new Armor {Value = 20},
                    new Damage {Value = 3},
                    new Transform {X = 4, Y = 5, Rotation = 6},
                    new TestComponent {Value = 7},
                    new AnotherComponent {Name = "a", Data = 2, Y = 3}
                );
                GameObject e2 = scene.Create(
                    new Position {X = 10, Y = 10},
                    new Velocity {X = 2, Y = 3},
                    new Health {Value = 30},
                    new Armor {Value = 40},
                    new Damage {Value = 4},
                    new Transform {X = 7, Y = 8, Rotation = 9},
                    new TestComponent {Value = 11},
                    new AnotherComponent {Name = "b", Data = 5, Y = 6}
                );

                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
                int calls = 0;

                query.Delegate((ref Position p, ref Velocity v, ref Health h, ref Armor a, ref Damage d, ref Transform t, ref TestComponent tc, ref AnotherComponent ac) =>
                {
                    calls++;
                    p.X += v.X;
                    h.Value += 1;
                    a.Value += 2;
                    d.Value += 1;
                    t.Rotation += 10;
                    tc.Value += 3;
                    ac.Data += 4;
                });

                Assert.Equal(2, calls);
                Assert.Equal(2, e1.Get<Position>().X);
                Assert.Equal(11, e1.Get<Health>().Value);
                Assert.Equal(22, e1.Get<Armor>().Value);
                Assert.Equal(4, e1.Get<Damage>().Value);
                Assert.Equal(16, e1.Get<Transform>().Rotation);
                Assert.Equal(10, e1.Get<TestComponent>().Value);
                Assert.Equal(6, e1.Get<AnotherComponent>().Data);
                Assert.Equal(12, e2.Get<Position>().X);
                Assert.Equal(31, e2.Get<Health>().Value);
                Assert.Equal(42, e2.Get<Armor>().Value);
                Assert.Equal(5, e2.Get<Damage>().Value);
                Assert.Equal(19, e2.Get<Transform>().Rotation);
                Assert.Equal(14, e2.Get<TestComponent>().Value);
                Assert.Equal(9, e2.Get<AnotherComponent>().Data);
            }
        }

        /// <summary>
        ///     Tests that inline arity 8 updates all matching across archetypes
        /// </summary>
        [Fact]
        public void Inline_Arity8_UpdatesAllMatchingAcrossArchetypes()
        {
            CoverageInlineAction8.Reset();

            using (Scene scene = new Scene())
            {
                GameObject e1 = scene.Create(
                    new Position {X = 1, Y = 1},
                    new Velocity {X = 1, Y = 1},
                    new Health {Value = 10},
                    new Armor {Value = 20},
                    new Damage {Value = 3},
                    new Transform {X = 4, Y = 5, Rotation = 6},
                    new TestComponent {Value = 7},
                    new AnotherComponent {Name = "a", Data = 2, Y = 3}
                );
                GameObject e2 = scene.Create(
                    new Position {X = 10, Y = 10},
                    new Velocity {X = 2, Y = 3},
                    new Health {Value = 30},
                    new Armor {Value = 40},
                    new Damage {Value = 4},
                    new Transform {X = 7, Y = 8, Rotation = 9},
                    new TestComponent {Value = 11},
                    new AnotherComponent {Name = "b", Data = 5, Y = 6}
                );

                scene.Query<With<Position>, With<Velocity>, With<Health>, With<Armor>, With<Damage>, With<Transform>, With<TestComponent>, With<AnotherComponent>>()
                    .Inline<CoverageInlineAction8, Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>(default(CoverageInlineAction8));

                Assert.Equal(2, CoverageInlineAction8.Calls);
                Assert.Equal(2, e1.Get<Position>().X);
                Assert.Equal(11, e1.Get<Health>().Value);
                Assert.Equal(22, e1.Get<Armor>().Value);
                Assert.Equal(4, e1.Get<Damage>().Value);
                Assert.Equal(16, e1.Get<Transform>().Rotation);
                Assert.Equal(10, e1.Get<TestComponent>().Value);
                Assert.Equal(6, e1.Get<AnotherComponent>().Data);
                Assert.Equal(12, e2.Get<Position>().X);
                Assert.Equal(31, e2.Get<Health>().Value);
                Assert.Equal(42, e2.Get<Armor>().Value);
                Assert.Equal(5, e2.Get<Damage>().Value);
                Assert.Equal(19, e2.Get<Transform>().Rotation);
                Assert.Equal(14, e2.Get<TestComponent>().Value);
                Assert.Equal(9, e2.Get<AnotherComponent>().Data);
            }
        }

        /// <summary>
        ///     The inline action 2
        /// </summary>
        internal struct CoverageInlineAction2 : IAction<Position, Velocity>
        {
            /// <summary>
            ///     The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            ///     Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            ///     Runs the action
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
        ///     The inline action 8
        /// </summary>
        internal struct CoverageInlineAction8 : IAction<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>
        {
            /// <summary>
            ///     The calls
            /// </summary>
            public static int Calls;

            /// <summary>
            ///     Resets
            /// </summary>
            public static void Reset() => Calls = 0;

            /// <summary>
            ///     Runs the action
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
                arg1.X += arg2.X;
                arg3.Value += 1;
                arg4.Value += 2;
                arg5.Value += 1;
                arg6.Rotation += 10;
                arg7.Value += 3;
                arg8.Data += 4;
            }
        }
    }
}
