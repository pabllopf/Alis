//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Application.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using System;
    using NUnit.Framework;

    /// <summary>Test this. </summary>
    internal class Application
    {
        #region Setup

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        #endregion

        #region Default Test

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Default() => Assert.True(true);

        #endregion

        /// <summary>Tests the desktop folder.</summary>
        [Test]
        public void Test_DesktopFolder()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(Alis.Tools.Application.DesktopFolder);
                Assert.AreEqual(Alis.Tools.Application.DesktopFolder, Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace("\\", "/"));
            });
        }

        /// <summary>Tests the documents folder.</summary>
        [Test]
        public void Test_DocumentsFolder()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(Alis.Tools.Application.DocumentsFolder);
                Assert.AreEqual(Alis.Tools.Application.DocumentsFolder, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/"));
            });
        }

        /// <summary>Tests the assets folder.</summary>
        [Test]
        public void Test_AssetsFolder()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(Alis.Tools.Application.AssetsFolder);
                Assert.AreEqual(Alis.Tools.Application.AssetsFolder, (Environment.CurrentDirectory + "/Assets").Replace("\\", "/"));
            });
        }

        /// <summary>Tests the project folder.</summary>
        [Test]
        public void Test_ProjectFolder()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(Alis.Tools.Application.ProjectFolder);
                Assert.AreEqual(Alis.Tools.Application.ProjectFolder, Environment.CurrentDirectory.Replace("\\", "/"));
            });
        }

        /// <summary>Tests the persistence data folder.</summary>
        [Test]
        public void Test_PersistenceDataFolder()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(Alis.Tools.Application.PersistenceDataFolder);
                Assert.AreEqual(Alis.Tools.Application.PersistenceDataFolder, (Environment.SystemDirectory + "/Data").Replace("\\", "/"));
            });
        }

        /// <summary>Tests the temporary data folder.</summary>
        [Test]
        public void Test_TempDataFolder()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(Alis.Tools.Application.TempDataFolder);
                Assert.AreEqual(Alis.Tools.Application.TempDataFolder, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("\\", "/"));
            });
        }
    }
}