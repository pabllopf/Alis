

using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The poly clip error test class
    /// </summary>
    public class PolyClipErrorTest
    {
        /// <summary>
        ///     Tests that none should have value zero
        /// </summary>
        [Fact]
        public void None_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int) PolyClipError.None);
        }

        /// <summary>
        ///     Tests that degenerated output should have value one
        /// </summary>
        [Fact]
        public void DegeneratedOutput_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int) PolyClipError.DegeneratedOutput);
        }

        /// <summary>
        ///     Tests that non simple input should have value two
        /// </summary>
        [Fact]
        public void NonSimpleInput_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int) PolyClipError.NonSimpleInput);
        }

        /// <summary>
        ///     Tests that broken result should have value three
        /// </summary>
        [Fact]
        public void BrokenResult_ShouldHaveValueThree()
        {
            Assert.Equal(3, (int) PolyClipError.BrokenResult);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            PolyClipError[] values = new[]
            {
                PolyClipError.None,
                PolyClipError.DegeneratedOutput,
                PolyClipError.NonSimpleInput,
                PolyClipError.BrokenResult
            };

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that values should be sequential
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            Assert.Equal(0, (int) PolyClipError.None);
            Assert.Equal(1, (int) PolyClipError.DegeneratedOutput);
            Assert.Equal(2, (int) PolyClipError.NonSimpleInput);
            Assert.Equal(3, (int) PolyClipError.BrokenResult);
        }
    }
}