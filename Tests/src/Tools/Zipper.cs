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

        /// <summary>Uns the zip simple file.</summary>
        [Test]
        public void Zip_Simple_File()
        {
            Assert.Multiple(() =>
            {
                string zipName = "/Zip.zip";
                string fileZip = Environment.CurrentDirectory + "/temp1/" + zipName;
                string pathWork = Environment.CurrentDirectory + "/temp1/" + "/Zip";

                if (!Directory.Exists(pathWork))
                {
                    Directory.CreateDirectory(pathWork);
                }

                Thread.Sleep(1000);

                if (File.Exists(fileZip))
                {
                    File.Delete(fileZip);
                }

                Thread.Sleep(1000);

                string fileToWork = Environment.CurrentDirectory + "/temp1/" + "/Zip/" + "Test3.json";
                using (var stream = File.Create(fileToWork))
                {
                    // Use stream
                }

                Thread.Sleep(1000);

                Alis.Tools.Zipper.Zip(pathWork);

                Assert.IsTrue(File.Exists(fileZip));
            });
        }

        #endregion


        /// <summary>Uns the zip simple file.</summary>
        [Test]
        public void UnZip_Simple_File()
        {
            Assert.Multiple(() =>
            {
                string zipName = "/uZip.zip";
                string fileZip = Environment.CurrentDirectory + zipName;
                string pathWork = Environment.CurrentDirectory + "/uZip";

                if (!Directory.Exists(pathWork))
                {
                    Directory.CreateDirectory(pathWork);
                }

                Thread.Sleep(1500);

                if (File.Exists(fileZip))
                {
                    File.Delete(fileZip);
                }

                Thread.Sleep(1500);

                string fileToWork = Environment.CurrentDirectory  + "/uZip/" + "Test11.json";
                using (var stream = File.Create(fileToWork))
                {
                    // Use stream
                }

                Thread.Sleep(500);

                Thread.Sleep(1500);

                Alis.Tools.Zipper.Zip(pathWork);

                Assert.IsTrue(File.Exists(fileZip));
            });
        }


        [Test]
        public void UnZip_Multiple_Files()
        {
            Assert.Multiple(() =>
            {
                string zipName = "/uZip.zip";
                string fileZip = Environment.CurrentDirectory + "/temp3/" + zipName;
                string pathWork = Environment.CurrentDirectory + "/temp3/" + "/uZip";

                if (!Directory.Exists(pathWork))
                {
                    Directory.CreateDirectory(pathWork);
                }

                Thread.Sleep(500);

                if (File.Exists(fileZip))
                {
                    File.Delete(fileZip);
                }

                Thread.Sleep(500);

                string fileToWork = Environment.CurrentDirectory + "/temp3/" + "/uZip/" + "Test11.json";
                using (var stream = File.Create(fileToWork))
                {
                    // Use stream
                }

                Thread.Sleep(500);

                string fileToWork2 = Environment.CurrentDirectory + "/temp3/" + "/uZip/" + "Test22.json";
                using (var stream = File.Create(fileToWork2))
                {
                    // Use stream
                }

                Thread.Sleep(500);

                Alis.Tools.Zipper.Zip(pathWork);

                Assert.IsTrue(File.Exists(fileZip));
            });
        }
    }
}