//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Asset.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using System;
    using System.IO;
    using NUnit.Framework;

    /// <summary>Define test for assets</summary>
    internal class Asset
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
        public void Default()
        {
            Assert.True(true);
        }

        #endregion

        #region  Load 

        /// <summary>Tries the load path file.</summary>
        [Test]
        public void Try_Load_Path_File_Dont_Exits() 
        {
            Assert.Multiple(() =>
            {
                Assert.IsNull(Alis.Tools.Asset.Load(string.Empty));
            });
        }

        /// <summary>Tries the load path file.</summary>
        [Test]
        public void Try_Load_Path_File()
        {
            Assert.Multiple(() =>
            {
                string path = (Environment.CurrentDirectory + "/Assets/").Replace("\\", "/");

                if (!Directory.Exists(path)) 
                {
                    Directory.CreateDirectory(path);
                }

                string file = path + "exampletest.json";

                if (!File.Exists(file)) 
                {
                    File.Create(file);
                }

                Assert.IsNotNull(Alis.Tools.Asset.Load("exampletest.json"));
                Assert.AreEqual(path + "exampletest.json", Alis.Tools.Asset.Load("exampletest.json"));
            });
        }

        #endregion
    }
}
