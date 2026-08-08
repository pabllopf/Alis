// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectIdOnlyRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests the remaining uncovered methods of <see cref="GameObjectIdOnly" /> struct.
    /// </summary>
    public class GameObjectIdOnlyRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that <see cref="GameObjectIdOnly.Deconstruct" /> returns the correct ID and version values.
        /// </summary>
        [Fact]
        public void Deconstruct_ReturnsCorrectValues()
        {
            GameObjectIdOnly g = new GameObjectIdOnly(5, 3);
            g.Deconstruct(out int id, out ushort ver);

            Assert.Equal(5, id);
            Assert.Equal((ushort)3, ver);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectIdOnly.SetEntity" /> modifies the target <see cref="GameObject" /> correctly.
        /// </summary>
        [Fact]
        public void SetEntity_ModifiesGameObject()
        {
            GameObject go = new GameObject();
            go.EntityID = 0;
            go.EntityVersion = 0;
            GameObjectIdOnly g = new GameObjectIdOnly(42, 7);
            g.SetEntity(ref go);

            Assert.Equal(42, go.EntityID);
            Assert.Equal((ushort)7, go.EntityVersion);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectIdOnly.Init(GameObject)" /> copies values from a <see cref="GameObject" />.
        /// </summary>
        [Fact]
        public void Init_FromGameObject_CopiesValues()
        {
            GameObject go = new GameObject();
            go.EntityID = 100;
            go.EntityVersion = 5;
            GameObjectIdOnly g = new GameObjectIdOnly(0, 0);
            g.Init(go);

            Assert.Equal(100, g.ID);
            Assert.Equal((ushort)5, g.Version);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectIdOnly.Init(GameObjectIdOnly)" /> copies values from another
        ///     <see cref="GameObjectIdOnly" />.
        /// </summary>
        [Fact]
        public void Init_FromGameObjectIdOnly_CopiesValues()
        {
            GameObjectIdOnly src = new GameObjectIdOnly(77, 2);
            GameObjectIdOnly dst = new GameObjectIdOnly(0, 0);
            dst.Init(src);

            Assert.Equal(77, dst.ID);
            Assert.Equal((ushort)2, dst.Version);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectIdOnly.ToEntity" /> creates a <see cref="GameObject" /> with correct
        ///     scene ID, version, and entity ID.
        /// </summary>
        [Fact]
        public void ToEntity_CreatesGameObject_WithCorrectValues()
        {
            using Scene scene = new Scene();
            GameObjectIdOnly idOnly = new GameObjectIdOnly(25, 3);

            GameObject result = idOnly.ToEntity(scene);

            Assert.Equal(scene.Id, result.WorldID);
            Assert.Equal((ushort)3, result.EntityVersion);
            Assert.Equal(25, result.EntityID);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectIdOnly.ToEntity" /> works with default version and zero ID.
        /// </summary>
        [Fact]
        public void ToEntity_WithDefaultVersion_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObjectIdOnly idOnly = new GameObjectIdOnly(0, 0);

            GameObject result = idOnly.ToEntity(scene);

            Assert.Equal(scene.Id, result.WorldID);
            Assert.Equal((ushort)0, result.EntityVersion);
            Assert.Equal(0, result.EntityID);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectIdOnly.ToEntity" /> works with max ushort version.
        /// </summary>
        [Fact]
        public void ToEntity_WithMaxVersion_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObjectIdOnly idOnly = new GameObjectIdOnly(42, ushort.MaxValue);

            GameObject result = idOnly.ToEntity(scene);

            Assert.Equal(scene.Id, result.WorldID);
            Assert.Equal(ushort.MaxValue, result.EntityVersion);
            Assert.Equal(42, result.EntityID);
        }

        /// <summary>
        ///     Tests that calling <see cref="GameObjectIdOnly.ToEntity" /> on a default struct returns
        ///     a <see cref="GameObject" /> with zero values.
        /// </summary>
        [Fact]
        public void ToEntity_DefaultStruct_ReturnsZeroValues()
        {
            using Scene scene = new Scene();
            GameObjectIdOnly idOnly = default;

            GameObject result = idOnly.ToEntity(scene);

            Assert.Equal(scene.Id, result.WorldID);
            Assert.Equal((ushort)0, result.EntityVersion);
            Assert.Equal(0, result.EntityID);
        }
    }
}
