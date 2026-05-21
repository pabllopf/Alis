

using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     The constant test class
    /// </summary>
    public class ConstantTest
    {
        /// <summary>
        ///     Tests that constant epsilon should be correct
        /// </summary>
        [Fact]
        public void Constant_Epsilon_ShouldBeCorrect()
        {
            Assert.Equal(1.192092896e-07f, Constant.Epsilon);
        }

        /// <summary>
        ///     Tests that constant euler should be correct
        /// </summary>
        [Fact]
        public void Constant_Euler_ShouldBeCorrect()
        {
            Assert.Equal(2.7182818284590452354f, Constant.Euler);
        }

        /// <summary>
        ///     Tests that constant e should be correct
        /// </summary>
        [Fact]
        public void Constant_E_ShouldBeCorrect()
        {
            Assert.Equal((float) System.Math.E, Constant.E);
        }

        /// <summary>
        ///     Tests that constant log 10 e should be correct
        /// </summary>
        [Fact]
        public void Constant_Log10E_ShouldBeCorrect()
        {
            Assert.Equal(0.4342945f, Constant.Log10E);
        }

        /// <summary>
        ///     Tests that constant log 2 e should be correct
        /// </summary>
        [Fact]
        public void Constant_Log2E_ShouldBeCorrect()
        {
            Assert.Equal(1.442695f, Constant.Log2E);
        }

        /// <summary>
        ///     Tests that constant pi should be correct
        /// </summary>
        [Fact]
        public void Constant_Pi_ShouldBeCorrect()
        {
            Assert.Equal((float) System.Math.PI, Constant.Pi);
        }

        /// <summary>
        ///     Tests that constant pi over 2 should be correct
        /// </summary>
        [Fact]
        public void Constant_PiOver2_ShouldBeCorrect()
        {
            Assert.Equal((float) (System.Math.PI / 2.0), Constant.PiOver2);
        }

        /// <summary>
        ///     Tests that constant pi over 4 should be correct
        /// </summary>
        [Fact]
        public void Constant_PiOver4_ShouldBeCorrect()
        {
            Assert.Equal((float) (System.Math.PI / 4.0), Constant.PiOver4);
        }

        /// <summary>
        ///     Tests that constant two pi should be correct
        /// </summary>
        [Fact]
        public void Constant_TwoPi_ShouldBeCorrect()
        {
            Assert.Equal((float) (System.Math.PI * 2.0), Constant.TwoPi);
        }

        /// <summary>
        ///     Tests that constant tau should be correct
        /// </summary>
        [Fact]
        public void Constant_Tau_ShouldBeCorrect()
        {
            Assert.Equal(Constant.TwoPi, Constant.Tau);
        }
    }
}