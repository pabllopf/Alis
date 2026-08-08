// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensionsPrivateGetCompTest.cs
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
using System.Reflection;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The game object extensions private get comp test class
    /// </summary>
    public class GameObjectExtensionsPrivateGetCompTest
    {
        /// <summary>
        /// Tests that private get comp byte array overload throws on ref struct box
        /// </summary>
        [Fact]
        public void PrivateGetCompByteArrayOverload_ThrowsOnRefStructBox()
        {
            using Scene scene = new Scene();
            Position pos = new Position { X = 10f, Y = 20f };
            GameObject entity = scene.Create(pos);

            object location = InvokeAssertIsAlive(entity);
            object archetype = GetField(location, "Archetype");
            int index = (int)GetField(location, "Index");
            byte[] tagTable = (byte[])GetField(archetype, "ComponentTagTable");
            ComponentStorageBase[] components = (ComponentStorageBase[])GetField(archetype, "Components");

            MethodInfo getCompMethod = typeof(GameObjectExtensions).GetMethod(
                "GetComp",
                BindingFlags.Static | BindingFlags.NonPublic,
                null,
                new[] { typeof(byte[]), typeof(ComponentStorageBase[]), typeof(int) },
                null)!.MakeGenericMethod(typeof(Position));

            _ = Assert.Throws<NotSupportedException>(() =>
                getCompMethod.Invoke(null, new object[] { tagTable, components, index }));
        }

        /// <summary>
        /// Invokes the assert is alive using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The object</returns>
        private static object InvokeAssertIsAlive(GameObject entity)
        {
            MethodInfo assertIsAlive = typeof(GameObject).GetMethod(
                "AssertIsAlive",
                BindingFlags.Instance | BindingFlags.NonPublic)!;

            return assertIsAlive.Invoke(entity, new object[] { null! })!;
        }

        /// <summary>
        /// Gets the field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="name">The name</param>
        /// <returns>The object</returns>
        private static object GetField(object obj, string name) =>
            obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(obj)!;
    }
}
