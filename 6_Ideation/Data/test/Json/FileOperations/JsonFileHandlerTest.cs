// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonFileHandlerTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Json.Deserialization;
using Alis.Core.Aspect.Data.Json.FileOperations;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Alis.Core.Aspect.Data.Json.Serialization;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.FileOperations
{
    /// <summary>
    /// The json file handler test class
    /// </summary>
    public class JsonFileHandlerTest
    {
        /// <summary>
        /// The file handler
        /// </summary>
        private readonly JsonFileHandler _fileHandler;
        /// <summary>
        /// The test directory
        /// </summary>
        private readonly string _testDirectory;

        /// <summary>
        /// The test object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestObject}"/>
        private class TestObject : IJsonSerializable, IJsonDesSerializable<TestObject>
        {
            /// <summary>
            /// Gets or sets the value of the name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", Name);
                yield return ("Value", Value.ToString());
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The test object</returns>
            public TestObject CreateFromProperties(Dictionary<string, string> properties)
            {
                return new TestObject
                {
                    Name = properties.TryGetValue("Name", out string name) ? name : null,
                    Value = properties.TryGetValue("Value", out string value) && int.TryParse(value, out int v) ? v : 0
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonFileHandlerTest"/> class
        /// </summary>
        public JsonFileHandlerTest()
        {
            EscapeSequenceHandler escapeHandler = new EscapeSequenceHandler();
            JsonParser parser = new JsonParser(escapeHandler);
            JsonSerializer serializer = new JsonSerializer();
            JsonDeserializer deserializer = new JsonDeserializer(parser);
            
            _fileHandler = new JsonFileHandler(serializer, deserializer);
            _testDirectory = Path.Combine(Path.GetTempPath(), "JsonFileHandlerTests");
        }

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        private void Cleanup()
        {
            if (Directory.Exists(_testDirectory))
            {
                Directory.Delete(_testDirectory, true);
            }
        }

        /// <summary>
        /// Tests that serialize to file with valid object creates file
        /// </summary>
        [Fact]
        public void SerializeToFile_WithValidObject_CreatesFile()
        {
            try
            {
                TestObject obj = new TestObject { Name = "Test", Value = 42 };
                string relativePath = Path.Combine("JsonFileHandlerTests", "subdir");
                
                _fileHandler.SerializeToFile(obj, "testfile", relativePath);

                string expectedPath = Path.Combine(Environment.CurrentDirectory, relativePath, "testfile.json");
                Assert.True(File.Exists(expectedPath));
            }
            finally
            {
                Cleanup();
            }
        }

        /// <summary>
        /// Tests that serialize to file with null instance throws argument null exception
        /// </summary>
        [Fact]
        public void SerializeToFile_WithNullInstance_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _fileHandler.SerializeToFile<TestObject>(null, "test", "path"));
        }

        /// <summary>
        /// Tests that serialize to file with null file name throws argument null exception
        /// </summary>
        [Fact]
        public void SerializeToFile_WithNullFileName_ThrowsArgumentNullException()
        {
            TestObject obj = new TestObject { Name = "Test", Value = 42 };
            Assert.Throws<ArgumentNullException>(() => _fileHandler.SerializeToFile(obj, null, "path"));
        }

        /// <summary>
        /// Tests that serialize to file with null relative path throws argument null exception
        /// </summary>
        [Fact]
        public void SerializeToFile_WithNullRelativePath_ThrowsArgumentNullException()
        {
            TestObject obj = new TestObject { Name = "Test", Value = 42 };
            Assert.Throws<ArgumentNullException>(() => _fileHandler.SerializeToFile(obj, "test", null));
        }

        /// <summary>
        /// Tests that deserialize from file with missing file throws file not found exception
        /// </summary>
        [Fact]
        public void DeserializeFromFile_WithMissingFile_ThrowsFileNotFoundException()
        {
            string relativePath = Path.Combine("JsonFileHandlerTests", "nonexistent");
            
            Assert.Throws<FileNotFoundException>(() => 
                _fileHandler.DeserializeFromFile<TestObject>("missing", relativePath));
        }

        /// <summary>
        /// Tests that serialize to file creates directory if not exists
        /// </summary>
        [Fact]
        public void SerializeToFile_CreatesDirectoryIfNotExists()
        {
            try
            {
                TestObject obj = new TestObject { Name = "Test", Value = 42 };
                string relativePath = Path.Combine("JsonFileHandlerTests", "newdir", "subdir");
                
                _fileHandler.SerializeToFile(obj, "testfile", relativePath);

                string dirPath = Path.Combine(Environment.CurrentDirectory, relativePath);
                Assert.True(Directory.Exists(dirPath));
            }
            finally
            {
                Cleanup();
            }
        }

        /// <summary>
        /// Tests that deserialize from file with valid file returns object
        /// </summary>
        [Fact]
        public void DeserializeFromFile_WithValidFile_ReturnsObject()
        {
            try
            {
                TestObject obj = new TestObject { Name = "John", Value = 100 };
                string relativePath = Path.Combine("JsonFileHandlerTests", "read");
                
                _fileHandler.SerializeToFile(obj, "testread", relativePath);
                TestObject result = _fileHandler.DeserializeFromFile<TestObject>("testread", relativePath);

                Assert.NotNull(result);
                Assert.Equal("John", result.Name);
                Assert.Equal(100, result.Value);
            }
            finally
            {
                Cleanup();
            }
        }

        /// <summary>
        /// Tests that serialize to file overwrites existing file
        /// </summary>
        [Fact]
        public void SerializeToFile_OverwritesExistingFile()
        {
            try
            {
                TestObject obj1 = new TestObject { Name = "First", Value = 1 };
                TestObject obj2 = new TestObject { Name = "Second", Value = 2 };
                string relativePath = Path.Combine("JsonFileHandlerTests", "overwrite");
                
                _fileHandler.SerializeToFile(obj1, "testfile", relativePath);
                _fileHandler.SerializeToFile(obj2, "testfile", relativePath);

                TestObject result = _fileHandler.DeserializeFromFile<TestObject>("testfile", relativePath);
                Assert.Equal("Second", result.Name);
                Assert.Equal(2, result.Value);
            }
            finally
            {
                Cleanup();
            }
        }
    }
}

