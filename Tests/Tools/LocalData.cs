//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="LocalData.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using System;
    using System.IO;
    using Alis.Core.SFML;
    using NUnit.Framework;

    /// <summary>Test this</summary>
    internal class LocalData
    {
        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        #endregion

        #region Default

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Default() => Assert.True(true);

        #endregion

        /// <summary>Loads the name of the string from file don`t exits with.</summary>
        [Test]
        public void Load_String_From_File_Dont_Exits_With_Name()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<FileNotFoundException>(() => Alis.Tools.LocalData.Load<string>("Example_1"));
            });
        }

        /// <summary>Loads the name of the string from file that exits with.</summary>
        [Test]
        public void Load_String_From_File_That_Exits_With_Name()
        {
            Assert.Multiple(() =>
            {
                Alis.Tools.LocalData.Save<string>("Example_2", "Hello");
                Assert.AreEqual("Hello", Alis.Tools.LocalData.Load<string>("Example_2"));
            });
        }

        /// <summary>Loads the name of the string from file that exits with.</summary>
        [Test]
        public void Load_Object_From_File_That_Exits_With_Name()
        {
            Assert.Multiple(() =>
            {
                AudioSource audio = new AudioSource();
                Alis.Tools.LocalData.Save("Audio", audio);
                Assert.AreEqual(audio, Alis.Tools.LocalData.Load<AudioSource>("Audio"));
            });
        }

        /// <summary>Loads the name of the object from file that dont exits with.</summary>
        [Test]
        public void Load_Object_File_Dont_Exits_With_Name()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<FileNotFoundException>(() => Alis.Tools.LocalData.Load<AudioSource>("Example_12"));
            });
        }
    }
}