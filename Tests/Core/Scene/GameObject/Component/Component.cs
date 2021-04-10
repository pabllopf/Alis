//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Component.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Core
{
    using Alis.Core.SFML;
    using NUnit.Framework;

    /// <summary>Define components Test</summary>
    internal class Component
    {
        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        #endregion

        #region Check Generals Cases

        /// <summary>Checks the maximum size.</summary>
        [Test]
        public void Default_Test() => Assert.IsTrue(true);

        #endregion

        #region Active 

        /// <summary>Checks the is active.</summary>
        [Test]
        public void Check_Is_Active()
        {
            Assert.Multiple(() =>
            {
                Sprite sprite = new Sprite(string.Empty);
                Assert.IsTrue(sprite.IsActive);
            });
        }

        /// <summary>Checks the is not active.</summary>
        [Test]
        public void Check_Is_NOT_Active()
        {
            Assert.Multiple(() =>
            {
                Sprite sprite = new Sprite(string.Empty);
                sprite.IsActive = false;
                Assert.IsFalse(sprite.IsActive);
            });
        }

        #endregion

        #region GameObject

        /// <summary>attach game object.</summary>
        [Test]
        public void Try_Attach_Gameobject()
        {
            Assert.Multiple(() =>
            {
                Sprite sprite = new Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform(), sprite);
                Assert.AreEqual(gameObject, sprite.GameObject);
            });
        }

        #endregion
    }
}
