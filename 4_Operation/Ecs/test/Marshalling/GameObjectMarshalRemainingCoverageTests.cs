// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectMarshalRemainingCoverageTests.cs
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

using Alis.Core.Ecs.Marshalling;
using Xunit;

namespace Alis.Core.Ecs.Test.Marshalling
{
    /// <summary>
    ///     Tests the remaining uncovered methods of <see cref="GameObjectMarshal" /> class.
    /// </summary>
    public class GameObjectMarshalRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that <see cref="GameObjectMarshal.EntityId" /> returns the correct <see cref="GameObject.EntityID" />.
        /// </summary>
        [Fact]
        public void EntityId_ReturnsEntityID()
        {
            GameObject go = new GameObject();
            go.EntityID = 55;

            Assert.Equal(55, GameObjectMarshal.EntityId(go));
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectMarshal.EntityId" /> returns zero for a default <see cref="GameObject" />.
        /// </summary>
        [Fact]
        public void EntityId_DefaultGameObject_ReturnsZero()
        {
            Assert.Equal(0, GameObjectMarshal.EntityId(default(GameObject)));
        }
    }
}
