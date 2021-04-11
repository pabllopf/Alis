//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Core
{
    using NUnit.Framework;

    /// <summary>Test Scene Manager</summary>
    internal class SceneManager
    {
        #region Variables

        /// <summary>The scene</summary>
        private Alis.Core.Scene scene;

        /// <summary>The scene2</summary>
        private Alis.Core.Scene scene2;

        /// <summary>The scene manager</summary>
        private Alis.Core.SceneManager sceneManager;

        #endregion

        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
            scene = new Alis.Core.Scene("Exampe");
            scene2 = new Alis.Core.Scene("Exampe2");
            sceneManager = new Alis.Core.SceneManager(new Alis.Core.Scene[] { scene, scene2 });
        }

        #endregion

        #region Check Generals Cases

        /// <summary>Checks the maximum size.</summary>
        [Test]
        public void Default_Test() => Assert.IsTrue(true);

        #endregion

        #region current Scene

        /// <summary>Tries the get current scene.</summary>
        [Test]
        public void Try_Get_Current_Scene()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(scene, sceneManager.CurrentScene);
            });
        }

        /// <summary>Tries the change current scene.</summary>
        [Test]
        public void Try_Change_Current_Scene()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SceneManager.Load("Exampe2");
                Assert.AreEqual(scene2, sceneManager.CurrentScene);
            });
        }

        /// <summary>Haves the 100 scenes.</summary>
        [Test]
        public void Have_100_scenes()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(100, sceneManager.Scenes.Length);
            });
        }

        #endregion
    }
}