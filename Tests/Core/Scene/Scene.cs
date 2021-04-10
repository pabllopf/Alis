//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Scene.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Core
{
    using NUnit.Framework;

    /// <summary>Define test of scenes.</summary>
    internal class Scene
    {
        #region Variables

        /// <summary>The scene default</summary>
        private Alis.Core.Scene sceneDefault;

        /// <summary>The scene with one game object</summary>
        private Alis.Core.Scene sceneWithOneGameobject;

        /// <summary>The game object</summary>
        private Alis.Core.GameObject gameObject;

        /// <summary>The scene to add element</summary>
        private Alis.Core.Scene sceneToAddElement;

        /// <summary>The scene to delete game object</summary>
        private Alis.Core.Scene sceneToDeleteGameobject;

        #endregion

        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
            gameObject = new Alis.Core.GameObject("Player");

            sceneDefault = new Alis.Core.Scene("Example");

            sceneWithOneGameobject = new Alis.Core.Scene("Example2", gameObject);

            sceneToAddElement = new Alis.Core.Scene("example3", new Alis.Core.GameObject("enemy"));

            sceneToDeleteGameobject = new Alis.Core.Scene("Example5", gameObject);
        }

        #endregion

        #region Default

        /// <summary>Checks the maximum size.</summary>
        [Test]
        public void Default_Test() => Assert.IsTrue(true);

        #endregion

        #region Name

        /// <summary>Tries the name of the get.</summary>
        [Test]
        public void Try_Get_Name() => Assert.AreEqual("Example", sceneDefault.Name);

        /// <summary>Tries the name of the set.</summary>
        [Test]
        public void Try_Set_Name()
        {
            Assert.Multiple(() => 
            { 
                sceneDefault.Name = "Example2"; 
                Assert.AreEqual("Example2", sceneDefault.Name);
            });
        }

        #endregion

        #region GameObjects

        /// <summary>Numbers the game object with default constructor.</summary>
        [Test]
        public void Num_Gameobject_With_Default_Constructor()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1024, sceneDefault.GameObjects.Length);
            });
        }

        /// <summary>Scenes the with one game object.</summary>
        [Test]
        public void Scene_With_One_Gameobject()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Player", sceneWithOneGameobject.Find("Player").Name);
            });
        }

        #endregion

        #region Find

        /// <summary>Finds the a game object.</summary>
        [Test]
        public void Find_A_Gameobjects()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(gameObject, sceneWithOneGameobject.Find("Player"));
            });
        }

        #endregion

        #region Add

        /// <summary>Adds a game object.</summary>
        [Test]
        public void Add_A_Gameobject()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.GameObject enemy = new Alis.Core.GameObject("Enemy2");
                sceneToAddElement.Add(enemy);
                Assert.IsTrue(sceneToAddElement.Contains(enemy));
            });
        }

        #endregion

        #region Delete

        /// <summary>Deletes a game object.</summary>
        [Test]
        public void Delete_A_Gameobject()
        {
            Assert.Multiple(() =>
            {
                sceneToDeleteGameobject.Remove(gameObject);
                Assert.IsFalse(sceneToDeleteGameobject.Contains(gameObject));
            });
        }

        #endregion

        #region Active 

        /// <summary>Checks the is active.</summary>
        [Test]
        public void Check_Is_Active()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(sceneDefault.IsActive);
            });
        }

        /// <summary>Checks the is not active.</summary>
        [Test]
        public void Check_Is_NOT_Active()
        {
            Assert.Multiple(() =>
            {
                sceneDefault.IsActive = false;
                Assert.IsFalse(sceneDefault.IsActive);
            });
        }

        #endregion
    }
}
