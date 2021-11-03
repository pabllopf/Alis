// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GameObjectTests.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region

using System.Numerics;
using Alis.Core.Entities;
using NUnit.Framework;

#endregion

namespace Alis.Core.Test
{
    /// <summary>
    ///     The game object tests class
    /// </summary>
    internal class GameObjectTests
    {
        /// <summary>
        ///     Tests that constructor default
        /// </summary>
        [Test]
        public void Constructor_Default()
        {
            GameObject gameObject = new GameObject();
            Assert.AreEqual(gameObject.Name, "Default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        ///     Tests that constructor with name
        /// </summary>
        [Test]
        public void Constructor_With_Name()
        {
            GameObject gameObject = new GameObject("test_default");
            Assert.AreEqual(gameObject.Name, "test_default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        ///     Tests that constructor with null name
        /// </summary>
        [Test]
        public void Constructor_With_Null_Name()
        {
            GameObject gameObject = new GameObject();
            Assert.AreEqual(gameObject.Name, "Default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        ///     Tests that constructor with custom transform
        /// </summary>
        [Test]
        public void Constructor_With_Custom_Transform()
        {
            GameObject gameObject = new GameObject();
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(2, 2, 2));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        ///     Tests that constructor with null transform
        /// </summary>
        [Test]
        public void Constructor_With_Null_Transform()
        {
            GameObject gameObject = new GameObject();
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }
    }
}