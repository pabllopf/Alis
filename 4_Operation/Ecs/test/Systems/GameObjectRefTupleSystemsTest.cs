// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRefTupleSystemsTest.cs
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
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The game object ref tuple systems test class
    /// </summary>
    public class GameObjectRefTupleSystemsTest
    {
        /// <summary>
        ///     Tests that game object field can be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndRetrieveGameObjectField()
        {
            Scene scene = new Scene();
            GameObject gameObject = scene.CreateGameObject();
            int[] buffer = [42];

            GameObjectRefTuple<int> tuple = new GameObjectRefTuple<int>
            {
                GameObject = gameObject,
                Item1 = new Ref<int>(buffer, 0)
            };

            Assert.Equal(gameObject, tuple.GameObject);
        }

        /// <summary>
        ///     Tests that deconstruct outputs correct game object
        /// </summary>
        [Fact]
        public void ShouldDeconstructWithCorrectGameObject()
        {
            Scene scene = new Scene();
            GameObject gameObject = scene.CreateGameObject();
            int[] buffer = [42];

            GameObjectRefTuple<int> tuple = new GameObjectRefTuple<int>
            {
                GameObject = gameObject,
                Item1 = new Ref<int>(buffer, 0)
            };

            tuple.Deconstruct(out GameObject outGo, out Ref<int> outRef);

            Assert.Equal(gameObject, outGo);
        }

        /// <summary>
        ///     Tests that deconstruct outputs correct ref value
        /// </summary>
        [Fact]
        public void ShouldDeconstructWithCorrectRefValue()
        {
            Scene scene = new Scene();
            GameObject gameObject = scene.CreateGameObject();
            int[] buffer = [42];

            GameObjectRefTuple<int> tuple = new GameObjectRefTuple<int>
            {
                GameObject = gameObject,
                Item1 = new Ref<int>(buffer, 0)
            };

            tuple.Deconstruct(out GameObject outGo, out Ref<int> outRef);

            Assert.Equal(42, outRef.Value);
        }

        /// <summary>
        ///     Tests that ref value modification affects original buffer
        /// </summary>
        [Fact]
        public void ShouldModifyOriginalBufferThroughRefValue()
        {
            Scene scene = new Scene();
            GameObject gameObject = scene.CreateGameObject();
            int[] buffer = [42];

            GameObjectRefTuple<int> tuple = new GameObjectRefTuple<int>
            {
                GameObject = gameObject,
                Item1 = new Ref<int>(buffer, 0)
            };

            tuple.Item1.Value = 100;

            Assert.Equal(100, buffer[0]);
        }
    }
}
