// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonOptionsTest.cs
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

using System;
using System.Globalization;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The json options test class
    /// </summary>
    public class JsonOptionsTest
    {
        /// <summary>
        ///     Tests that test constructor
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            JsonOptions options = new JsonOptions();
            Assert.NotNull(options);
        }

        /// <summary>
        ///     Tests that test throw exceptions property
        /// </summary>
        [Fact]
        public void TestThrowExceptionsProperty()
        {
            JsonOptions options = new JsonOptions
            {
                ThrowExceptions = true
            };
            Assert.True(options.ThrowExceptions);
        }

        /// <summary>
        ///     Tests that test maximum exceptions count property
        /// </summary>
        [Fact]
        public void TestMaximumExceptionsCountProperty()
        {
            JsonOptions options = new JsonOptions
            {
                MaximumExceptionsCount = 100
            };
            Assert.Equal(100, options.MaximumExceptionsCount);
        }

        /// <summary>
        ///     Tests that test json p callback property
        /// </summary>
        [Fact]
        public void TestJsonPCallbackProperty()
        {
            JsonOptions options = new JsonOptions
            {
                JsonPCallback = "callback"
            };
            Assert.Equal("callback", options.JsonPCallback);
        }

        /// <summary>
        ///     Tests that test guid format property
        /// </summary>
        [Fact]
        public void TestGuidFormatProperty()
        {
            JsonOptions options = new JsonOptions
            {
                GuidFormat = "D"
            };
            Assert.Equal("D", options.GuidFormat);
        }

        /// <summary>
        ///     Tests that test date time format property
        /// </summary>
        [Fact]
        public void TestDateTimeFormatProperty()
        {
            JsonOptions options = new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd"
            };
            Assert.Equal("yyyy-MM-dd", options.DateTimeFormat);
        }

        /// <summary>
        ///     Tests that test date time offset format property
        /// </summary>
        [Fact]
        public void TestDateTimeOffsetFormatProperty()
        {
            JsonOptions options = new JsonOptions
            {
                DateTimeOffsetFormat = "yyyy-MM-dd"
            };
            Assert.Equal("yyyy-MM-dd", options.DateTimeOffsetFormat);
        }

        /// <summary>
        ///     Tests that test date time styles property
        /// </summary>
        [Fact]
        public void TestDateTimeStylesProperty()
        {
            JsonOptions options = new JsonOptions
            {
                DateTimeStyles = DateTimeStyles.AssumeUniversal
            };
            Assert.Equal(DateTimeStyles.AssumeUniversal, options.DateTimeStyles);
        }

        /// <summary>
        ///     Tests that test streaming buffer chunk size property
        /// </summary>
        [Fact]
        public void TestStreamingBufferChunkSizeProperty()
        {
            JsonOptions options = new JsonOptions
            {
                StreamingBufferChunkSize = 512
            };
            Assert.Equal(512, options.StreamingBufferChunkSize);
        }

        /// <summary>
        ///     Tests that test formatting tab property
        /// </summary>
        [Fact]
        public void TestFormattingTabProperty()
        {
            JsonOptions options = new JsonOptions
            {
                FormattingTab = " "
            };
            Assert.Equal(" ", options.FormattingTab);
        }

        /// <summary>
        ///     Tests that test add exception method
        /// </summary>
        [Fact]
        public void TestAddExceptionMethod()
        {
            JsonOptions options = new JsonOptions();
            Exception ex = new Exception("Test exception");
            options.AddException(ex);
            Assert.Contains(ex, options.Exceptions);
        }

        /// <summary>
        ///     Tests that test clone method
        /// </summary>
        [Fact]
        public void TestCloneMethod()
        {
            JsonOptions options = new JsonOptions();
            JsonOptions clone = options.Clone();
            Assert.NotEqual(options, clone);
        }

        /// <summary>
        ///     Tests that test get cache key method
        /// </summary>
        [Fact]
        public void TestGetCacheKeyMethod()
        {
            JsonOptions options = new JsonOptions();
            string cacheKey = options.GetCacheKey();
            Assert.NotNull(cacheKey);
        }

        /// <summary>
        ///     Tests that test max method
        /// </summary>
        [Fact]
        public void TestMaxMethod()
        {
            // Arrange
            int val1 = 5;
            int val2 = 10;

            // Act
            int result = JsonOptions.Max(val1, val2);

            // Assert
            Assert.Equal(val2, result);
        }

        /// <summary>
        ///     Tests that test final streaming buffer chunk size property
        /// </summary>
        [Fact]
        public void TestFinalStreamingBufferChunkSizeProperty()
        {
            // Arrange
            JsonOptions options = new JsonOptions
            {
                StreamingBufferChunkSize = 600
            };

            // Act
            int result = options.FinalStreamingBufferChunkSize;

            // Assert
            Assert.Equal(600, result);
        }


        /// <summary>
        ///     Tests that test add exception method with valid exception
        /// </summary>
        [Fact]
        public void TestAddExceptionMethodWithValidException()
        {
            // Arrange
            JsonOptions options = new JsonOptions();
            Exception ex = new Exception("Test exception");

            // Act
            options.AddException(ex);

            // Assert
            Assert.Contains(ex, options.Exceptions);
        }

        /// <summary>
        ///     Tests that test add exception method with null exception
        /// </summary>
        [Fact]
        public void TestAddExceptionMethodWithNullException()
        {
            // Arrange
            JsonOptions options = new JsonOptions();
            Exception ex = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => options.AddException(ex));
        }

        /// <summary>
        ///     Tests that test add exception method with maximum exceptions count exceeded
        /// </summary>
        [Fact]
        public void TestAddExceptionMethodWithMaximumExceptionsCountExceeded()
        {
            // Arrange
            JsonOptions options = new JsonOptions
            {
                MaximumExceptionsCount = 1
            };
            Exception ex1 = new Exception("Test exception 1");
            Exception ex2 = new Exception("Test exception 2");

            // Act
            options.AddException(ex1);

            // Assert
            Assert.Throws<JsonException>(() => options.AddException(ex2));
        }
    }
}