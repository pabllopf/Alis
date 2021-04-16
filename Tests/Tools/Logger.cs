//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Logger.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using NUnit.Framework;

    /// <summary>Test this. </summary>
    internal class Logger
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
    }
}
