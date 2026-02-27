// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IDeleteTest.cs
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
    ///     Unit tests for the IDelete interface.
    ///     Tests the Delete method for removal operations.
    /// </summary>
    public class IDeleteTest
    {
        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder
        {
            public bool IsDeleted { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IDelete.
        /// </summary>
        private class DeleteBuilder : IDelete<Builder>
        {
            private readonly Builder _builder = new Builder();

            public Builder Delete()
            {
                _builder.IsDeleted = true;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IDelete can be implemented.
        /// </summary>
        [Fact]
        public void IDelete_CanBeImplemented()
        {
            DeleteBuilder builder = new DeleteBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IDelete<Builder>>(builder);
        }

        /// <summary>
        ///     Tests that Delete returns builder.
        /// </summary>
        [Fact]
        public void Delete_ReturnsBuilder()
        {
            DeleteBuilder builder = new DeleteBuilder();
            Builder result = builder.Delete();
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that Delete marks object as deleted.
        /// </summary>
        [Fact]
        public void Delete_MarksObjectAsDeleted()
        {
            DeleteBuilder builder = new DeleteBuilder();
            Builder result = builder.Delete();
            Assert.True(result.IsDeleted);
        }

        /// <summary>
        ///     Tests Delete can be called multiple times.
        /// </summary>
        [Fact]
        public void Delete_CanBeCalledMultipleTimes()
        {
            DeleteBuilder builder = new DeleteBuilder();
            Builder result1 = builder.Delete();
            Assert.True(result1.IsDeleted);
        }
    }
}

