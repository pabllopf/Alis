using System.Numerics;
using Alis.Core.Entities;
using NUnit.Framework;

namespace Alis.Core.Test
{
    /// <summary>
    /// The game object tests class
    /// </summary>
    internal class GameObjectTests
    {
        /// <summary>
        /// Tests that constructor default
        /// </summary>
        [Test]
        public void Constructor_Default()
        {
            var gameObject = new GameObject();
            Assert.AreEqual(gameObject.Name, "Default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        /// Tests that constructor with name
        /// </summary>
        [Test]
        public void Constructor_With_Name()
        {
            var gameObject = new GameObject("test_default");
            Assert.AreEqual(gameObject.Name, "test_default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        /// Tests that constructor with null name
        /// </summary>
        [Test]
        public void Constructor_With_Null_Name()
        {
            var gameObject = new GameObject(null);
            Assert.AreEqual(gameObject.Name, "Default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        /// Tests that constructor with custom transform
        /// </summary>
        [Test]
        public void Constructor_With_Custom_Transform()
        {
            var gameObject = new GameObject();
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(2, 2, 2));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        /// <summary>
        /// Tests that constructor with null transform
        /// </summary>
        [Test]
        public void Constructor_With_Null_Transform()
        {
            var gameObject = new GameObject();
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }
    }
}