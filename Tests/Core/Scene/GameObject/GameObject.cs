//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Core
{
    using System;
    using NUnit.Framework;

    /// <summary>Define test for game object.</summary>
    internal class GameObject
    {
        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        #endregion

        #region Default

        [Test]
        public void True() => Assert.True(true);

        #endregion

        #region Check Generals Cases

        /// <summary>Checks the maximum size.</summary>
        [Test]
        public void Check_The_Max_Size()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player");
                Assert.AreEqual(10, gameObject.Components.Length);
            });
        }

        #endregion

        #region Name Gameobject 

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Check_Name()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player");
                Assert.AreEqual("Player", gameObject.Name);
            });
        }

        #endregion

        #region Add Component

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Add_A_Component()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SFML.Sprite sprite = new Alis.Core.SFML.Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform());
                Assert.DoesNotThrow(() => gameObject.Add(sprite));
            });
        }

        #endregion

        #region Remove Component

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Delete_A_Component()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SFML.Sprite sprite = new Alis.Core.SFML.Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform(), sprite);
                gameObject.Delete<Alis.Core.SFML.Sprite>();
                Assert.IsFalse(gameObject.Contains<Alis.Core.SFML.Sprite>());
            });
        }

        #endregion

        #region Get Component

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Get_A_Component()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SFML.Sprite sprite = new Alis.Core.SFML.Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform(), sprite);
                Assert.AreEqual(sprite, gameObject.Get<Alis.Core.SFML.Sprite>());
            });
        }

        /// <summary>Get a component with added.</summary>
        [Test]
        public void Get_A_Component_With_Added_Previus()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SFML.Sprite sprite = new Alis.Core.SFML.Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform());
                Assert.DoesNotThrow(() => gameObject.Add(sprite));
                Assert.AreEqual(sprite, gameObject.Get<Alis.Core.SFML.Sprite>());
            });
        }

        /// <summary>Gets a component don`t exits.</summary>
        [Test]
        public void Get_A_Component_Dont_Exits()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player");
                Assert.IsNull(gameObject.Get<Alis.Core.SFML.Sprite>());
            });
        }

        #endregion

        #region Contains Component

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Contains_A_Component()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SFML.Sprite sprite = new Alis.Core.SFML.Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform(), sprite);
                Assert.IsTrue(gameObject.Contains<Alis.Core.SFML.Sprite>());
            });
        }

        /// <summary>Don`t the contains a component.</summary>
        [Test]
        public void Dont_Contains_A_Component()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SFML.Sprite sprite = new Alis.Core.SFML.Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform());
                Assert.IsFalse(gameObject.Contains<Alis.Core.SFML.Sprite>());
            });
        }

        #endregion

        #region IsActive

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Check_Is_Active_When_Create() 
        {
            Assert.Multiple(() =>
            {
                Alis.Core.SFML.Sprite sprite = new Alis.Core.SFML.Sprite(string.Empty);
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform(), sprite);
                Assert.IsTrue(gameObject.IsActive);
            });
        }

        #endregion

        #region IsStatic 

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Check_Is_NOT_Static_When_Use_Default_Contruct()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player");
                Assert.IsFalse(gameObject.IsStatic);
            });
        }

        #endregion

        #region Check Exceptions

        /// <summary>Tries to add component.</summary>
        [Test]
        public void Try_To_Add_Component()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform());
                Assert.DoesNotThrow(() => gameObject.Add(new Alis.Core.SFML.Sprite(string.Empty)));
            });
        }

        /// <summary>Tries to add component that exits.</summary>
        [Test]
        public void Try_To_Add_Component_That_Exits()
        {
            Assert.Multiple(() =>
            {
                Alis.Core.GameObject gameObject = new Alis.Core.GameObject("Player", new Alis.Core.Transform(), new Alis.Core.SFML.Sprite(string.Empty));
                Assert.Throws<Exception>(() => gameObject.Add(new Alis.Core.SFML.Sprite(string.Empty)));
            });
        }

        #endregion
    }
}