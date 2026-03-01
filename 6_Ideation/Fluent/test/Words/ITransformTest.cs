// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ITransformTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
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
        ///     Tests that ITransform can be implemented.
        /// </summary>
        [Fact]
        public void ITransform_CanBeImplemented()
        {
            TransformBuilderImpl builder = new TransformBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ITransform<TransformBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Transform sets operation correctly.
        /// </summary>
        [Fact]
        public void Transform_SetsOperationCorrectly()
        {
            TransformBuilderImpl builder = new TransformBuilderImpl();
            TransformBuilder result = builder.Transform("Rotate90");
            Assert.Equal("Rotate90", result.TransformOperation);
        }

        /// <summary>
        ///     Tests that Transform returns builder.
        /// </summary>
        [Fact]
        public void Transform_ReturnsBuilder()
        {
            TransformBuilderImpl builder = new TransformBuilderImpl();
            TransformBuilder result = builder.Transform("Scale2x");
            Assert.NotNull(result);
            Assert.IsType<TransformBuilder>(result);
        }

        /// <summary>
        ///     Tests Transform with various operations.
        /// </summary>
        [Theory, InlineData("Translate"), InlineData("Rotate"), InlineData("Scale"), InlineData("Shear")]
        public void Transform_WithVariousOperations(string operation)
        {
            TransformBuilderImpl builder = new TransformBuilderImpl();
            TransformBuilder result = builder.Transform(operation);
            Assert.Equal(operation, result.TransformOperation);
        }

        /// <summary>
        ///     Helper builder class for transform.
        /// </summary>
        private class TransformBuilder
        {
            /// <summary>
            /// Gets or sets the value of the transform operation
            /// </summary>
            public string TransformOperation { get; set; }
        }

        /// <summary>
        ///     Helper implementation of ITransform.
        /// </summary>
        private class TransformBuilderImpl : ITransform<TransformBuilder, string>
        {
            /// <summary>
            /// The transform builder
            /// </summary>
            private readonly TransformBuilder _builder = new TransformBuilder();

            /// <summary>
            /// Transforms the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public TransformBuilder Transform(string value)
            {
                _builder.TransformOperation = value;
                return _builder;
            }
        }
    }
}