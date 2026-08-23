// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateLoopEmptyRunTests.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     The update loop empty run tests class
    /// </summary>
    public class UpdateLoopEmptyRunTests
    {
        /// <summary>
        ///     Tests that the update loop run with zero length returns for arity 0
        /// </summary>
        [Fact]
        public void Run_Arity0_WithZeroLength_Returns()
        {
            using (new Scene())
            {
                GameObject gameObject = default;
                GameObjectIdOnly entityIds = new GameObjectIdOnly(0, 0);
                UpdateComponent comp = new UpdateComponent {CallCount = 0};

                UpdateLoop.Run(ref entityIds, ref comp, 0, gameObject);

                Assert.Equal(0, comp.CallCount);
            }
        }

        /// <summary>
        ///     Tests that the update loop run with zero length returns for arity 2
        /// </summary>
        [Fact]
        public void Run_Arity2_WithZeroLength_Returns()
        {
            using (new Scene())
            {
                GameObject gameObject = default;
                GameObjectIdOnly entityIds = new GameObjectIdOnly(0, 0);
                Update2Component comp = new Update2Component {CallCount = 0};
                Position arg1 = new Position {X = 1, Y = 2};
                Velocity arg2 = new Velocity {X = 3, Y = 4};

                UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, 0, gameObject);

                Assert.Equal(0, comp.CallCount);
            }
        }

        /// <summary>
        ///     Tests that the update loop run with zero length returns for arity 3
        /// </summary>
        [Fact]
        public void Run_Arity3_WithZeroLength_Returns()
        {
            using (new Scene())
            {
                GameObject gameObject = default;
                GameObjectIdOnly entityIds = new GameObjectIdOnly(0, 0);
                Update3Component comp = new Update3Component {CallCount = 0};
                Position arg1 = new Position {X = 1, Y = 2};
                Velocity arg2 = new Velocity {X = 3, Y = 4};
                Health arg3 = new Health {Value = 5};

                UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, 0, gameObject);

                Assert.Equal(0, comp.CallCount);
            }
        }

        /// <summary>
        ///     Tests that the update loop run with zero length returns for arity 4
        /// </summary>
        [Fact]
        public void Run_Arity4_WithZeroLength_Returns()
        {
            using (new Scene())
            {
                GameObject gameObject = default;
                GameObjectIdOnly entityIds = new GameObjectIdOnly(0, 0);
                Update4Component comp = new Update4Component {CallCount = 0};
                Position arg1 = new Position {X = 1, Y = 2};
                Velocity arg2 = new Velocity {X = 3, Y = 4};
                Health arg3 = new Health {Value = 5};
                Armor arg4 = new Armor {Value = 6};

                UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, 0, gameObject);

                Assert.Equal(0, comp.CallCount);
            }
        }

        /// <summary>
        ///     Tests that the update loop run with zero length returns for arity 6
        /// </summary>
        [Fact]
        public void Run_Arity6_WithZeroLength_Returns()
        {
            using (new Scene())
            {
                GameObject gameObject = default;
                GameObjectIdOnly entityIds = new GameObjectIdOnly(0, 0);
                Update6Component comp = new Update6Component {CallCount = 0};
                Position arg1 = new Position {X = 1, Y = 2};
                Velocity arg2 = new Velocity {X = 3, Y = 4};
                Health arg3 = new Health {Value = 5};
                Armor arg4 = new Armor {Value = 6};
                Damage arg5 = new Damage {Value = 7};
                Transform arg6 = new Transform {X = 8, Y = 9};

                UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, 0, gameObject);

                Assert.Equal(0, comp.CallCount);
            }
        }

        /// <summary>
        ///     Tests that the update loop run with zero length returns for arity 7
        /// </summary>
        [Fact]
        public void Run_Arity7_WithZeroLength_Returns()
        {
            using (new Scene())
            {
                GameObject gameObject = default;
                GameObjectIdOnly entityIds = new GameObjectIdOnly(0, 0);
                Update7Component comp = new Update7Component {CallCount = 0};
                Position arg1 = new Position {X = 1, Y = 2};
                Velocity arg2 = new Velocity {X = 3, Y = 4};
                Health arg3 = new Health {Value = 5};
                Armor arg4 = new Armor {Value = 6};
                Damage arg5 = new Damage {Value = 7};
                Transform arg6 = new Transform {X = 8, Y = 9};
                TestComponent arg7 = new TestComponent {Value = 10};

                UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7, 0, gameObject);

                Assert.Equal(0, comp.CallCount);
            }
        }

        /// <summary>
        ///     Tests that the update loop run with zero length returns for arity 8
        /// </summary>
        [Fact]
        public void Run_Arity8_WithZeroLength_Returns()
        {
            using (new Scene())
            {
                GameObject gameObject = default;
                GameObjectIdOnly entityIds = new GameObjectIdOnly(0, 0);
                Update8Component comp = new Update8Component {CallCount = 0};
                Position arg1 = new Position {X = 1, Y = 2};
                Velocity arg2 = new Velocity {X = 3, Y = 4};
                Health arg3 = new Health {Value = 5};
                Armor arg4 = new Armor {Value = 6};
                Damage arg5 = new Damage {Value = 7};
                Transform arg6 = new Transform {X = 8, Y = 9};
                TestComponent arg7 = new TestComponent {Value = 10};
                AnotherComponent arg8 = new AnotherComponent {Data = 11};

                UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7, ref arg8, 0, gameObject);

                Assert.Equal(0, comp.CallCount);
            }
        }
    }
}
