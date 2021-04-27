//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Zipper.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using NUnit.Framework;
    using System;
    using System.IO;
    using System.Threading;

    /// <summary>Test this</summary>
    internal class Zipper
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

        #region Zip

        /// <summary>Zips the simple file.</summary>
        [Test]
        public void Zip_Simple_File()
        {
            Assert.Multiple(() =>
            {
                if (File.Exists(Environment.CurrentDirectory + "/Zip.zip")) 
                {
                    File.Delete(Environment.CurrentDirectory + "/Zip.zip");
                }

                string path = Environment.CurrentDirectory + "/Zip/";

                if (!Directory.Exists(path)) 
                {
                    Directory.CreateDirectory(path);
                }

                string file = Environment.CurrentDirectory + "/Zip/" + "Test2.json";
                if (!File.Exists(file)) 
                {
                    File.Create(file);
                }

                Thread.Sleep(10);

                Alis.Tools.Zipper.Zip(path);

                Assert.IsTrue(File.Exists(Environment.CurrentDirectory + "/Zip.zip"));
            });
        }

        /// <summary>Uns the zip simple file.</summary>
        [Test]
        public void UnZip_Simple_File()
        {
            Assert.Multiple((TestDelegate)(() =>
            {
                if (File.Exists(Environment.CurrentDirectory + "/uZip.zip"))
                {
                    File.Delete(Environment.CurrentDirectory + "/uZip.zip");
                }

                string path = Environment.CurrentDirectory + "/uZip/";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string file = Environment.CurrentDirectory + "/uZip/" + "Test3.json";
                if (!File.Exists(file))
                {
                    File.Create(file);
                }

                Thread.Sleep(10);

                Alis.Tools.Zipper.Zip(path);

                string path2 = Environment.CurrentDirectory + "/UnZip/";

                if (Directory.Exists(path2)) 
                {
                    Directory.Delete(path2, true);
                }

                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }

                Alis.Tools.Zipper.UnZip(Environment.CurrentDirectory + "/uZip.zip", path2);

                Assert.IsTrue(File.Exists(Environment.CurrentDirectory + "/uZip/Test3.json"));
            }));
        }

        #endregion
    }
}