// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectIniterNullBranchCoverageTest.cs
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

using System;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Coverage tests for the null-conditional initer branches on multi-component add
    ///     overloads and the event record exists branches on subscribe/unsubscribe.
    /// </summary>
    public class GameObjectIniterNullBranchCoverageTest
    {
        /// <summary>
        ///     Tests that add arity 2 with plain components covers the null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity2_PlainComponents_CoversNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
        }

        /// <summary>
        ///     Tests that add arity 3 with plain components covers the null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity3_PlainComponents_CoversNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
        }

        /// <summary>
        ///     Tests that add arity 4 with plain components covers the null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity4_PlainComponents_CoversNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new PlainCompD {Value = 4});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<PlainCompD>());
        }

        /// <summary>
        ///     Tests that add arity 4 with an init component at the fourth position covers the non-null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity4_InitComponentAtFourthPosition_CoversNonNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new Position {X = 1, Y = 2});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that add arity 5 with plain components covers the null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity5_PlainComponents_CoversNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new PlainCompD {Value = 4}, new PlainCompE {Value = 5});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<PlainCompD>());
            Assert.True(entity.Has<PlainCompE>());
        }

        /// <summary>
        ///     Tests that add arity 5 with an init component at the fourth position covers the non-null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity5_InitComponentAtFourthPosition_CoversNonNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new Position {X = 1, Y = 2}, new PlainCompE {Value = 5});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<PlainCompE>());
        }

        /// <summary>
        ///     Tests that add arity 6 with plain components covers the null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity6_PlainComponents_CoversNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new PlainCompD {Value = 4}, new PlainCompE {Value = 5}, new PlainCompF {Value = 6});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<PlainCompD>());
            Assert.True(entity.Has<PlainCompE>());
            Assert.True(entity.Has<PlainCompF>());
        }

        /// <summary>
        ///     Tests that add arity 6 with an init component at the fourth position covers the non-null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity6_InitComponentAtFourthPosition_CoversNonNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new Position {X = 1, Y = 2}, new PlainCompE {Value = 5}, new PlainCompF {Value = 6});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<PlainCompE>());
            Assert.True(entity.Has<PlainCompF>());
        }

        /// <summary>
        ///     Tests that add arity 7 with plain components covers the null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity7_PlainComponents_CoversNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new PlainCompD {Value = 4}, new PlainCompE {Value = 5}, new PlainCompF {Value = 6},
                new PlainCompG {Value = 7});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<PlainCompD>());
            Assert.True(entity.Has<PlainCompE>());
            Assert.True(entity.Has<PlainCompF>());
            Assert.True(entity.Has<PlainCompG>());
        }

        /// <summary>
        ///     Tests that add arity 7 with an init component at the fourth position covers the non-null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity7_InitComponentAtFourthPosition_CoversNonNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new Position {X = 1, Y = 2}, new PlainCompE {Value = 5}, new PlainCompF {Value = 6},
                new PlainCompG {Value = 7});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<PlainCompE>());
            Assert.True(entity.Has<PlainCompF>());
            Assert.True(entity.Has<PlainCompG>());
        }

        /// <summary>
        ///     Tests that add arity 8 with plain components covers the null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity8_PlainComponents_CoversNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new PlainCompD {Value = 4}, new PlainCompE {Value = 5}, new PlainCompF {Value = 6},
                new PlainCompG {Value = 7}, new PlainCompH {Value = 8});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<PlainCompD>());
            Assert.True(entity.Has<PlainCompE>());
            Assert.True(entity.Has<PlainCompF>());
            Assert.True(entity.Has<PlainCompG>());
            Assert.True(entity.Has<PlainCompH>());
        }

        /// <summary>
        ///     Tests that add arity 8 with an init component at the fourth position covers the non-null initer branch
        /// </summary>
        [Fact]
        public void Add_Arity8_InitComponentAtFourthPosition_CoversNonNullIniterBranch()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new PlainCompA {Value = 1}, new PlainCompB {Value = 2}, new PlainCompC {Value = 3},
                new Position {X = 1, Y = 2}, new PlainCompE {Value = 5}, new PlainCompF {Value = 6},
                new PlainCompG {Value = 7}, new PlainCompH {Value = 8});

            Assert.True(entity.Has<PlainCompA>());
            Assert.True(entity.Has<PlainCompB>());
            Assert.True(entity.Has<PlainCompC>());
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<PlainCompE>());
            Assert.True(entity.Has<PlainCompF>());
            Assert.True(entity.Has<PlainCompG>());
            Assert.True(entity.Has<PlainCompH>());
        }

        /// <summary>
        ///     Tests that subscribing twice on the same entity reuses the existing event record
        /// </summary>
        [Fact]
        public void OnDelete_SubscribeTwice_ReusesExistingEventRecord()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int calls = 0;
            void Handler(GameObject _) => calls++;

            entity.OnDelete += Handler;
            entity.OnDelete += Handler;

            entity.Delete();

            Assert.Equal(2, calls);
        }

        /// <summary>
        ///     Tests that unsubscribing without a prior subscribe uses the default event record path
        /// </summary>
        [Fact]
        public void OnDelete_UnsubscribeWithoutSubscribe_UsesDefaultEventRecord()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            void Handler(GameObject _)
            {
            }

            entity.OnDelete -= Handler;

            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that equals returns false when the object is not a game object
        /// </summary>
        [Fact]
        public void Equals_NonGameObject_ReturnsFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Assert.False(entity.Equals(new object()));
            Assert.False(entity.Equals(42));
            Assert.False(entity.Equals("not a game object"));
        }

        /// <summary>
        ///     Tests that equals returns true when the objects refer to the same entity
        /// </summary>
        [Fact]
        public void Equals_SameEntity_ReturnsTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Assert.True(entity.Equals((object) entity));
        }

        /// <summary>
        ///     Tests that accessing a deleted entity throws
        /// </summary>
        [Fact]
        public void DeletedEntity_Access_Throws()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Delete();

            Assert.ThrowsAny<Exception>(() => entity.Add(new PlainCompA {Value = 1}));
            Assert.ThrowsAny<Exception>(() => entity.Get<PlainCompA>());
        }

        /// <summary>
        ///     The plain comp a struct
        /// </summary>
        internal struct PlainCompA
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The plain comp b struct
        /// </summary>
        internal struct PlainCompB
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The plain comp c struct
        /// </summary>
        internal struct PlainCompC
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The plain comp d struct
        /// </summary>
        internal struct PlainCompD
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The plain comp e struct
        /// </summary>
        internal struct PlainCompE
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The plain comp f struct
        /// </summary>
        internal struct PlainCompF
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The plain comp g struct
        /// </summary>
        internal struct PlainCompG
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The plain comp h struct
        /// </summary>
        internal struct PlainCompH
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }
    }
}
