// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectFlagsParametrizedTest.cs
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

using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Parametrized tests for GameObject flags and state management
    /// </summary>
    public class GameObjectFlagsParametrizedTest
    {
        /// <summary>
        ///     Tests that game object flags new entity is alive
        /// </summary>
        [Fact] public void GameObjectFlags_NewEntity_IsAlive()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                Assert.True(entity.IsAlive);
            }
        }

        /// <summary>
        ///     Tests that game object flags new entity is not null
        /// </summary>
        [Fact] public void GameObjectFlags_NewEntity_IsNotNull()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                Assert.False(entity.IsNull);
            }
        }

        /// <summary>
        ///     Tests that game object flags deleted entity is not alive
        /// </summary>
        [Fact] public void GameObjectFlags_DeletedEntity_IsNotAlive()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Delete();

                Assert.False(entity.IsAlive);
            }
        }

    
        /// <summary>
        ///     Tests that game object flags null constant is null
        /// </summary>
        [Fact] public void GameObjectFlags_NullConstant_IsNull()
        {
            GameObject nullEntity = GameObject.Null;

            Assert.True(nullEntity.IsNull);
            Assert.False(nullEntity.IsAlive);
        }

        /// <summary>
        ///     Tests that game object flags default game object is null
        /// </summary>
        [Fact] public void GameObjectFlags_DefaultGameObject_IsNull()
        {
            GameObject defaultEntity = new GameObject();

            Assert.True(defaultEntity.IsNull);
        }

        

        /// <summary>
        ///     Tests that game object flags compare deleted with null both not alive
        /// </summary>
        [Fact] public void GameObjectFlags_CompareDeletedWithNull_BothNotAlive()
        {
            using (Scene scene = new Scene())
            {
                GameObject created = scene.Create();
                GameObject nullGo = GameObject.Null;

                created.Delete();

                Assert.False(created.IsAlive);
                Assert.False(nullGo.IsAlive);
            }
        }

       
    }
}