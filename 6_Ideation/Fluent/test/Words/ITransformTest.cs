// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ITransformTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the ITransform interface.
    ///     Tests the Transform method for coordinate system transformations.
    /// </summary>
    public class ITransformTest
    {
        /// <summary>
        ///     Helper builder class for transform.
        /// </summary>
        private class TransformBuilder
        {
            public string TransformOperation { get; set; }
        }

        /// <summary>
        ///     Helper implementation of ITransform.
        /// </summary>
        private class TransformBuilderImpl : ITransform<TransformBuilder, string>
        {
            private readonly TransformBuilder _builder = new TransformBuilder();

            public TransformBuilder Transform(string value)
            {
                _builder.TransformOperation = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that ITransform can be implemented.
        /// </summary>
        [Fact]
        public void ITransform_CanBeImplemented()
        {
            var builder = new TransformBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ITransform<TransformBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Transform sets operation correctly.
        /// </summary>
        [Fact]
        public void Transform_SetsOperationCorrectly()
        {
            var builder = new TransformBuilderImpl();
            var result = builder.Transform("Rotate90");
            Assert.Equal("Rotate90", result.TransformOperation);
        }

        /// <summary>
        ///     Tests that Transform returns builder.
        /// </summary>
        [Fact]
        public void Transform_ReturnsBuilder()
        {
            var builder = new TransformBuilderImpl();
            var result = builder.Transform("Scale2x");
            Assert.NotNull(result);
            Assert.IsType<TransformBuilder>(result);
        }

        /// <summary>
        ///     Tests Transform with various operations.
        /// </summary>
        [Theory]
        [InlineData("Translate")]
        [InlineData("Rotate")]
        [InlineData("Scale")]
        [InlineData("Shear")]
        public void Transform_WithVariousOperations(string operation)
        {
            var builder = new TransformBuilderImpl();
            var result = builder.Transform(operation);
            Assert.Equal(operation, result.TransformOperation);
        }
    }
}

