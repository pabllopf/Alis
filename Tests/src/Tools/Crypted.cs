//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Crypted.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using NUnit.Framework;

    /// <summary>Test this. </summary>
    internal class Crypted
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

        /// <summary>Encrypts the simple variable.</summary>
        [Test]
        public void Encrypt_Simple_Var() 
        {
            Assert.Multiple(() =>
            {
                Alis.Tools.Crypted<string> passwd = new Alis.Tools.Crypted<string>("12345");
                Assert.AreEqual("12345", passwd.Get());
            });
        }

        /// <summary>Decrypts the simple variable.</summary>
        [Test]
        public void Decrypt_Simple_Var()
        {
            Assert.Multiple(() =>
            {
                Alis.Tools.Crypted<string> passwd = new Alis.Tools.Crypted<string>("12345");
                passwd.Set("hola");
                Assert.AreEqual("hola", passwd.Get());
            });
        }

        /// <summary>Decrypts the complex variable.</summary>
        [Test]
        public void Decrypt_Complex_Var()
        {
            Assert.Multiple(() =>
            {
                Alis.Tools.Crypted<string> passwd = new Alis.Tools.Crypted<string>(Alis.Tools.Application.AssetsFolder);
                passwd.Set(Alis.Tools.Application.DesktopFolder);
                Assert.AreEqual(Alis.Tools.Application.DesktopFolder, passwd.Get());
            });
        }


        /// <summary>Decrypts the complex variable.</summary>
        [Test]
        public void Encrypt_Complex_Var()
        {
            Assert.Multiple(() =>
            {
                Alis.Tools.Crypted<string> passwd = new Alis.Tools.Crypted<string>(Alis.Tools.Application.AssetsFolder);
                Assert.AreEqual(Alis.Tools.Application.AssetsFolder, passwd.Get());
            });
        }
    }
}