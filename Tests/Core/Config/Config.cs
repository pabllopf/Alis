//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Config.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Core
{
    using NUnit.Framework;

    internal class Config
    {
        #region Variables


        #endregion


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
    }
}
