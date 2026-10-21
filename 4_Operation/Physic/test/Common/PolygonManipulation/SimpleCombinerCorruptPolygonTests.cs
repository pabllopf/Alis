// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleCombinerCorruptPolygonTests.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The simple combiner corrupt polygon tests class
    /// </summary>
    public class SimpleCombinerCorruptPolygonTests
    {
        /// <summary>
        ///     Tests that a triangle with only two vertices is reported as a corrupt polygon and skipped.
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WhenTriangleHasTwoVertices_SkipsCorruptPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0f, 0f), new Vector2F(1f, 0f) }
            };

            RecordingLogger logger = new RecordingLogger();
            Logger.SetDefaultLogger(logger);
            try
            {
                List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

                Assert.Empty(result);
                Assert.Contains("Skipping corrupt poly.", logger.Messages);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        ///     Tests that an empty entry is reported as a corrupt polygon and skipped.
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WhenTriangleIsEmpty_SkipsCorruptPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices()
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that a corrupt polygon does not prevent the valid polygons from being returned.
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WhenCorruptTriangleIsMixedWithValidOne_KeepsValidPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0f, 0f), new Vector2F(1f, 0f) },
                new Vertices { new Vector2F(5f, 5f), new Vector2F(6f, 5f), new Vector2F(5f, 6f) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Single(result);
            Assert.Equal(3, result[0].Count);
            Assert.Equal(new Vector2F(5f, 5f), result[0][0]);
            Assert.Equal(new Vector2F(6f, 5f), result[0][1]);
            Assert.Equal(new Vector2F(5f, 6f), result[0][2]);
        }

        /// <summary>
        ///     Tests that when every entry is corrupt no polygon is returned at all.
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WhenEveryTriangleIsCorrupt_ReturnsEmpty()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices { new Vector2F(0f, 0f), new Vector2F(1f, 0f) },
                new Vertices { new Vector2F(5f, 5f), new Vector2F(6f, 5f) }
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.Empty(result);
        }

        /// <summary>
        ///     A logger that records every message written through the static logging facade.
        /// </summary>
        private sealed class RecordingLogger : ILogger
        {
            private readonly List<string> _messages = new List<string>();
            private string _correlationId;

            /// <summary>
            ///     Gets the recorded messages.
            /// </summary>
            public IReadOnlyList<string> Messages
            {
                get
                {
                    lock (_messages)
                    {
                        return _messages.ToArray();
                    }
                }
            }

            /// <summary>
            ///     Gets the logical name of the logger.
            /// </summary>
            public string Name => "RecordingLogger";

            /// <inheritdoc/>
            public void LogTrace(string message) => Record(message);

            /// <inheritdoc/>
            public void LogDebug(string message) => Record(message);

            /// <inheritdoc/>
            public void LogInfo(string message) => Record(message);

            /// <inheritdoc/>
            public void LogWarning(string message) => Record(message);

            /// <inheritdoc/>
            public void LogError(string message) => Record(message);

            /// <inheritdoc/>
            public void LogError(string message, Exception exception) => Record(message);

            /// <inheritdoc/>
            public void LogCritical(string message) => Record(message);

            /// <inheritdoc/>
            public void LogCritical(string message, Exception exception) => Record(message);

            /// <inheritdoc/>
            public void Log(LogLevel level, string message) => Record(message);

            /// <inheritdoc/>
            public void Log(LogLevel level, string message, Exception exception) => Record(message);

            /// <inheritdoc/>
            public void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties) => Record(message);

            /// <inheritdoc/>
            public void SetCorrelationId(string correlationId) => _correlationId = correlationId;

            /// <inheritdoc/>
            public string GetCorrelationId() => _correlationId;

            /// <inheritdoc/>
            public IDisposable BeginScope(object scope) => new Scope();

            /// <inheritdoc/>
            public bool IsEnabled(LogLevel level) => true;

            private void Record(string message)
            {
                lock (_messages)
                {
                    _messages.Add(message);
                }
            }

            /// <summary>
            ///     A scope that does nothing.
            /// </summary>
            private sealed class Scope : IDisposable
            {
                /// <inheritdoc/>
                public void Dispose()
                {
                }
            }
        }
    }
}
