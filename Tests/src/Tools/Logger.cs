//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Logger.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Tools
{
    using System;
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

        /// <summary>Tests the information.</summary>
        [Test]
        public void Test_Info()
        {
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => Alis.Tools.Logger.Info());
            });
        }

        /// <summary>Tests the log.</summary>
        [Test]
        public void Test_Log()
        {
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => Alis.Tools.Logger.Log("Example"));
            });
        }

        /// <summary>Tests the log.</summary>
        [Test]
        public void Test_Warning()
        {
            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => Alis.Tools.Logger.Warning("Example"));
            });
        }

        /// <summary>Tests the error.</summary>
        [Test]
        public void Test_Error()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<Exception>(() => throw Alis.Tools.Logger.Error("Example"));
            });
        }
    }
}
