//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Language.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using NUnit.Framework;

    /// <summary>Test this</summary>
    internal class Language
    {
        #region SetUp

        /// <summary>Setups this instance.</summary>
        [SetUp]
        public void Setup()
        {
        }

        #endregion

        #region Default Test

        /// <summary>Trues this instance.</summary>
        [Test]
        public void Default()
        {
            Assert.True(true);
        }

        #endregion

        [Test]
        public void Test_Load_Sentence()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNull(Alis.Tools.Asset.Load(string.Empty));
            });
        }
    }
}