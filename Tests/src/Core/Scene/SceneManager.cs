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

        /// <summary>The video game</summary>
        private Alis.Core.SFML.VideoGame videoGame;

        /// <summary>The scene</summary>
        private Alis.Core.Scene scene;

        /// <summary>The scene2</summary>
        private Alis.Core.Scene scene2;

        #endregion

        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
            scene = new Alis.Core.Scene("Exampe");
            scene2 = new Alis.Core.Scene("Exampe2");

            videoGame = Alis.Core.SFML.VideoGame.Builder()
                .SceneManager(new Alis.Core.SceneManager(scene, scene2))
                .Build();
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
                Assert.AreEqual(scene.Name, Alis.Core.SceneManager.Current.CurrentScene.Name);
            });
        }

        /// <summary>Tries the change current scene.</summary>
        [Test]
        public void Try_Change_Current_Scene()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(scene.Name, videoGame.SceneManager.CurrentScene.Name);
            });
        }

        /// <summary>Haves the 100 scenes.</summary>
        [Test]
        public void Have_100_scenes()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, Alis.Core.SceneManager.Current.Scenes.Count);
            });
        }

        #endregion
    }
}