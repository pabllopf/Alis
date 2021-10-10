using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(gameObject.Transform.Size, new Vector3D(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3D(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3D(0, 0, 0));
        }

        [Test]
        public void Constructor_With_Name()
        {
            GameObject gameObject = new GameObject("test_default");
            Assert.AreEqual(gameObject.Name, "test_default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Size, new Vector3D(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3D(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3D(0, 0, 0));
        }

        [Test]
        public void Constructor_With_Null_Name()
        {
            GameObject gameObject = new GameObject(null);
            Assert.AreEqual(gameObject.Name, "Default");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Size, new Vector3D(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3D(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3D(0, 0, 0));
        }

        [Test]
        public void Constructor_With_Custom_Transform()
        {
            GameObject gameObject = new GameObject("test_name", new Transform(new Vector3D(2,2,2)));
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Size, new Vector3D(2, 2, 2));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3D(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3D(0, 0, 0));
        }

        [Test]
        public void Constructor_With_Null_Transform()
        {
            GameObject gameObject = new GameObject("test_name", null);
            Assert.AreEqual(gameObject.Name, "test_name");
            Assert.AreEqual(gameObject.Components.Length, 0);
            Assert.AreEqual(gameObject.Transform.Size, new Vector3D(1, 1, 1));
            Assert.AreEqual(gameObject.Transform.Position, new Vector3D(0, 0, 0));
            Assert.AreEqual(gameObject.Transform.Rotation, new Vector3D(0, 0, 0));
        }


        [Test]
        public void Add_Component()
        {
            GameObject gameObject = new GameObject("test");
            Assert.DoesNotThrow(() => gameObject.Add(new Sprite()));
            Assert.AreEqual(gameObject.Components.Length, 1);
        }

        [Test]
        public void Add_Component_Is_Null() 
        {
            GameObject gameObject = new GameObject("test");
            Assert.Throws<NullReferenceException>(() => gameObject.Add<Sprite>(null));
            Assert.AreEqual(gameObject.Components.Length, 0);
        }

        [Test]
        public void Add_Component_That_Alredy_Exits() 
        {
            GameObject gameObject = new GameObject("test");
            Assert.DoesNotThrow(() => gameObject.Add(new Sprite()));
            Assert.Throws<Exception>(() => gameObject.Add(new Sprite()));
            Assert.AreEqual(gameObject.Components.Length, 1);
        }

        [Test]
        public void Add_Component_Where_Components_Is_Null()
        {
            GameObject gameObject = new GameObject("test", true, false, new Transform(), null);
            
            Assert.AreEqual(gameObject.Components.Length, 0);
            
            Assert.DoesNotThrow(() => gameObject.Add(new Sprite()));
            Assert.AreEqual(gameObject.Components.Length, 1);
        }

        [Test]
        public void Remove_Component()
        {
            GameObject gameObject = new GameObject("test");
            
            Assert.DoesNotThrow(() => gameObject.Add(new Sprite()));
            Assert.DoesNotThrow(() => gameObject.Remove<Sprite>());
            
            Assert.DoesNotThrow(() => gameObject.Add(new Sprite()));
            Assert.IsTrue(gameObject.Remove<Sprite>());
            
            Assert.AreEqual(gameObject.Components.Length, 0);
        }

        [Test]
        public void Remove_Components_Where_Components_Is_Null()
        {
            GameObject gameObject = new GameObject("test", true, false, new Transform(), null);
            Assert.AreEqual(gameObject.Components.Length, 0);

            Assert.DoesNotThrow(() => gameObject.Add(new Sprite()));
            Assert.AreEqual(gameObject.Components.Length, 1);

            Assert.DoesNotThrow(() => gameObject.Remove<Sprite>());
            Assert.AreEqual(gameObject.Components.Length, 0);
        }
    }
}
