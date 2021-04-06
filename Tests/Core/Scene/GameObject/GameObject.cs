//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="GameObject.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Core
{
    using System;
    using Alis.Core.SFML;
    using NUnit.Framework;

    /// <summary>Define test for gameobject.</summary>
    internal class GameObject
    {
        #region Variables

        /// <summary>The game object empty</summary>
        private Alis.Core.GameObject gameObjectDefault;

        /// <summary>The game object empty</summary>
        private Alis.Core.GameObject gameObjectEmpty;

        /// <summary>The game object with one element</summary>
        private Alis.Core.GameObject gameObjectWithOneElement;

        /// <summary>The game object to add element</summary>
        private Alis.Core.GameObject gameObjectToAddElement;

        /// <summary>The game object to delete element</summary>
        private Alis.Core.GameObject gameObjectToDeleteElement;

        /// <summary>The sprite</summary>
        private Sprite sprite;

        #endregion

        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
            sprite = new Sprite("");

            gameObjectDefault = new Alis.Core.GameObject("GameObject");

            gameObjectEmpty = new Alis.Core.GameObject("GameObject 1");

            gameObjectWithOneElement = new Alis.Core.GameObject("GameObject 4");
            gameObjectWithOneElement.Add(sprite);

            gameObjectToAddElement = new Alis.Core.GameObject("GameObject 5");

            gameObjectToDeleteElement = new Alis.Core.GameObject("GameObject 6");
            gameObjectToDeleteElement.Add(sprite);
        }

        #endregion

        #region Check Generals Cases

        /// <summary>Checks the maximum size.</summary>
        [Test]
        public void Check_The_Max_Size() => Assert.AreEqual(10, gameObjectEmpty.Components.Length);

        #endregion

        #region Name Gameobject 

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Check_Name() => Assert.AreEqual("GameObject", gameObjectDefault.Name);

        #endregion

        #region Add Component

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Add_A_Component() => Assert.Multiple(() => { Assert.DoesNotThrow(() => gameObjectToAddElement.Add(new Sprite(""))); Assert.IsTrue(gameObjectToAddElement.Contains<Sprite>()); });

        #endregion

        #region Remove Component

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Delete_A_Component() => Assert.Multiple(() => { Assert.DoesNotThrow(() => gameObjectToDeleteElement.Remove<Sprite>()); Assert.IsFalse(gameObjectToDeleteElement.Contains<Sprite>()); });

        #endregion

        #region Get Component

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Get_A_Component() => Assert.AreEqual(sprite, gameObjectWithOneElement.Get<Sprite>());

        /// <summary>Gets a component dont exits.</summary>
        [Test]
        public void Get_A_Component_Dont_Exits() => Assert.IsNull(gameObjectEmpty.Get<Sprite>());

        #endregion

        #region Contains Component

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Contains_A_Component() => Assert.IsTrue(gameObjectWithOneElement.Contains<Sprite>());

        /// <summary>Donts the contains a component.</summary>
        [Test]
        public void Dont_Contains_A_Component() => Assert.IsFalse(gameObjectEmpty.Contains<Sprite>());

        #endregion

        #region IsActive

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Check_Is_Active_When_Create() => Assert.IsTrue(gameObjectDefault.IsActive);


        #endregion

        #region IsStatic 

        /// <summary>Determines whether [contains a component].</summary>
        [Test]
        public void Check_Is_Static_When_Use_Default_Contruct() => Assert.IsTrue(gameObjectDefault.IsStatic);

        #endregion

        #region Check Exceptions

        /// <summary>Tries to add component.</summary>
        [Test]
        public void Try_To_Add_Component() => Assert.DoesNotThrow(() => gameObjectDefault.Add(new Sprite("")));

        /// <summary>Tries to add component that exits.</summary>
        [Test]
        public void Try_To_Add_Component_That_Exits() => Assert.Throws<ArgumentException>(() => gameObjectWithOneElement.Add(new Sprite("")));

        #endregion
    }
}