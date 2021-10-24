using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Alis.Core.Test
{
    class GameObjectTests
    {
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

        [Test]
        public void Constructor_With_Null_Name()
        {
            GameObject gameObject = new GameObject(null);
            Assert.AreEqual(gameObject.Name, "Default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        [Test]
        public void Constructor_With_Custom_Transform()
        {
            GameObject gameObject = new GameObject("test_name", new Transform(new Vector3(2,2,2)));
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(2, 2, 2));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }

        [Test]
        public void Constructor_With_Null_Transform()
        {
            GameObject gameObject = new GameObject("test_name", null);
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Scale, new Vector3(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3(0, 0, 0));
        }
    }
}
