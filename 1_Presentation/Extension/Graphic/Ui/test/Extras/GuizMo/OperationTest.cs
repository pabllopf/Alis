using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    /// Provides unit coverage for <see cref="Operation"/> flag composition.
    /// </summary>
    public class OperationTest
    {
        /// <summary>
        /// Verifies that translate is the composition of X, Y and Z translate flags.
        /// </summary>
        [Fact]
        public void Translate_ShouldCombineTranslateAxes()
        {
            Operation expected = Operation.TranslateX | Operation.TranslateY | Operation.TranslateZ;

            Assert.Equal(expected, Operation.Translate);
        }

        /// <summary>
        /// Verifies that rotate is the composition of all rotate flags.
        /// </summary>
        [Fact]
        public void Rotate_ShouldCombineRotateAxes()
        {
            Operation expected = Operation.RotateX | Operation.RotateY | Operation.RotateZ | Operation.RotateScreen;

            Assert.Equal(expected, Operation.Rotate);
        }

        /// <summary>
        /// Verifies that scale is the composition of all scale flags.
        /// </summary>
        [Fact]
        public void Scale_ShouldCombineScaleAxes()
        {
            Operation expected = Operation.ScaleX | Operation.ScaleY | Operation.ScaleZ;

            Assert.Equal(expected, Operation.Scale);
        }
    }
}

