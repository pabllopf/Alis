// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Program.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;

namespace Alis.Core.Aspect.Logging.Sample
{
    /// <summary>
    ///     Sample program demonstrating the modern logging framework.
    ///     Covers all major features and game engine integration patterns.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main entry point for the logging sample application.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Alis Logging Framework Sample ===\n");

            // Example 1: Basic logging with default factory
            BasicLoggingExample();
            Console.WriteLine("\n---\n");

            // Example 2: Structured logging
            StructuredLoggingExample();
            Console.WriteLine("\n---\n");

            // Example 3: Multiple output destinations
            MultipleOutputsExample();
            Console.WriteLine("\n---\n");

            // Example 4: Filtering and log levels
            FilteringExample();
            Console.WriteLine("\n---\n");

            // Example 5: Scoped contexts
            ScopedContextExample();
            Console.WriteLine("\n---\n");

            // Example 6: Correlation IDs for tracing
            CorrelationIdExample();
            Console.WriteLine("\n---\n");

            // Example 7: Exception logging
            ExceptionLoggingExample();
            Console.WriteLine("\n---\n");

            // Example 8: Different formatters
            FormattersExample();
            Console.WriteLine("\n---\n");

            // Example 9: Game engine-like scenario
            GameEngineScenarioExample();
            Console.WriteLine("\n---\n");

            // Example 10: Backward compatibility with static Logger
            BackwardCompatibilityExample();

            Console.WriteLine("\n=== All Examples Completed ===");
        }

        /// <summary>
        ///     Example 1: Basic logging with console and memory outputs.
        /// </summary>
        private static void BasicLoggingExample()
        {
            Console.WriteLine("Example 1: Basic Logging");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Add console output
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                ILogger logger = factory.CreateLogger("MyGame.Engine");

                logger.LogTrace("This is a trace message");
                logger.LogDebug("Debug information");
                logger.LogInfo("Application started");
                logger.LogWarning("This is a warning");
                logger.LogError("An error occurred");
                logger.LogCritical("Critical system failure");
            }
        }

        /// <summary>
        ///     Example 2: Structured logging with contextual properties.
        /// </summary>
        private static void StructuredLoggingExample()
        {
            Console.WriteLine("Example 2: Structured Logging");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new JsonLogFormatter()));

                ILogger logger = factory.CreateLogger("MyGame.Player");

                // Log with structured data
                Dictionary<string, object> playerProperties = new Dictionary<string, object>
                {
                    { "PlayerId", 12345 },
                    { "PlayerName", "Hero" },
                    { "Level", 42 },
                    { "Experience", 500000 },
                    { "Health", 100 }
                };

                logger.LogStructured(LogLevel.Info, "Player logged in", playerProperties);

                // Another structured log
                Dictionary<string, object> attackProperties = new Dictionary<string, object>
                {
                    { "Attacker", "Hero" },
                    { "Defender", "Goblin" },
                    { "Damage", 25 },
                    { "Critical", true }
                };

                logger.LogStructured(LogLevel.Info, "Attack executed", attackProperties);
            }
        }

        /// <summary>
        ///     Example 3: Multiple output destinations simultaneously.
        /// </summary>
        private static void MultipleOutputsExample()
        {
            Console.WriteLine("Example 3: Multiple Outputs");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Add console output with color
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                // Add memory output for inspection
                MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 1000);
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("MyGame.Physics");

                logger.LogInfo("Physics engine initialized");
                logger.LogInfo("Gravity: 9.81 m/s²");
                logger.LogWarning("High physics object count detected");

                // Inspect memory output
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Console.WriteLine($"[MemoryOutput] Captured {entries.Count} log entries");
                foreach (ILogEntry entry in entries)
                {
                    Console.WriteLine($"  - [{entry.Level}] {entry.Message}");
                }
            }
        }

        /// <summary>
        ///     Example 4: Filtering based on level and logger name.
        /// </summary>
        private static void FilteringExample()
        {
            Console.WriteLine("Example 4: Filtering");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new CompactLogFormatter()));

                // Only accept Warning and above
                factory.AddFilter(new LogLevelFilter(LogLevel.Warning));

                // Only allow specific loggers
                factory.AddFilter(new LoggerNameFilter(
                    new[] { "MyGame.Critical", "MyGame.Security" },
                    inclusive: true
                ));

                ILogger criticalLogger = factory.CreateLogger("MyGame.Critical");
                ILogger normalLogger = factory.CreateLogger("MyGame.Normal");
                ILogger securityLogger = factory.CreateLogger("MyGame.Security");

                criticalLogger.LogWarning("This will show (Critical + Warning)");
                normalLogger.LogError("This will NOT show (filtered by name)");
                securityLogger.LogError("This will show (Security + Error)");
            }
        }

        /// <summary>
        ///     Example 5: Using scopes for context grouping.
        /// </summary>
        private static void ScopedContextExample()
        {
            Console.WriteLine("Example 5: Scoped Context");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                ILogger logger = factory.CreateLogger("MyGame.Scene");

                logger.LogInfo("Starting scene load");

                using (logger.BeginScope("Scene:MainMenu"))
                {
                    logger.LogInfo("Loading assets");

                    using (logger.BeginScope("Asset:Textures"))
                    {
                        logger.LogInfo("Loaded texture: background.png");
                        logger.LogInfo("Loaded texture: button.png");
                    }

                    using (logger.BeginScope("Asset:Audio"))
                    {
                        logger.LogInfo("Loaded sound: click.wav");
                    }
                }

                logger.LogInfo("Scene load complete");
            }
        }

        /// <summary>
        ///     Example 6: Correlation IDs for request tracing.
        /// </summary>
        private static void CorrelationIdExample()
        {
            Console.WriteLine("Example 6: Correlation IDs");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                ILogger logger = factory.CreateLogger("MyGame.Network");

                // Simulate a game session with a unique correlation ID
                string sessionId = Guid.NewGuid().ToString("N").Substring(0, 8);
                logger.SetCorrelationId(sessionId);

                logger.LogInfo("Player session started");
                logger.LogInfo("Loading player data");
                logger.LogInfo("Synchronizing with server");

                // All messages now carry the same correlation ID for tracing
                Console.WriteLine($"[Session ID: {logger.GetCorrelationId()}]");
            }
        }

        /// <summary>
        ///     Example 7: Exception logging with stack traces.
        /// </summary>
        private static void ExceptionLoggingExample()
        {
            Console.WriteLine("Example 7: Exception Logging");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                ILogger logger = factory.CreateLogger("MyGame.SaveSystem");

                try
                {
                    // Simulate an error
                    int result = 10 / int.Parse("0");
                }
                catch (DivideByZeroException ex)
                {
                    logger.LogError("Failed to calculate game statistics", ex);
                }
                catch (FormatException ex)
                {
                    logger.LogCritical("Invalid configuration value", ex);
                }
            }
        }

        /// <summary>
        ///     Example 8: Different output formatters.
        /// </summary>
        private static void FormattersExample()
        {
            Console.WriteLine("Example 8: Different Formatters");

            LogEntry entry = new LogEntry(LogLevel.Info, "Sample game event", "MyGame.Gameplay");

            Console.WriteLine("Simple Format:");
            SimpleLogFormatter simpleFormatter = new SimpleLogFormatter();
            Console.WriteLine(simpleFormatter.Format(entry));

            Console.WriteLine("\nCompact Format:");
            CompactLogFormatter compactFormatter = new CompactLogFormatter();
            Console.WriteLine(compactFormatter.Format(entry));

            Console.WriteLine("\nJSON Format:");
            JsonLogFormatter jsonFormatter = new JsonLogFormatter();
            Console.WriteLine(jsonFormatter.Format(entry));
        }

        /// <summary>
        ///     Example 9: Game engine-like scenario with render loop.
        /// </summary>
        private static void GameEngineScenarioExample()
        {
            Console.WriteLine("Example 9: Game Engine Scenario");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new CompactLogFormatter()));
                factory.SetMinimumLevel(LogLevel.Info);

                ILogger engineLogger = factory.CreateLogger("Engine.Core");
                ILogger rendererLogger = factory.CreateLogger("Engine.Renderer");
                ILogger physicsLogger = factory.CreateLogger("Engine.Physics");

                engineLogger.LogInfo("Engine initialized");

                // Simulate a few frames of a game loop
                for (int frame = 1; frame <= 3; frame++)
                {
                    using (engineLogger.BeginScope($"Frame:{frame}"))
                    {
                        rendererLogger.LogDebug("Rendering scene");
                        physicsLogger.LogDebug("Updating physics");
                        engineLogger.LogDebug("Processing input");

                        if (frame == 2)
                        {
                            rendererLogger.LogWarning("Frame rate dropped");
                        }
                    }
                }

                engineLogger.LogInfo("Engine shutdown");
            }
        }

        /// <summary>
        ///     Example 10: Backward compatibility with static Logger class.
        /// </summary>
        private static void BackwardCompatibilityExample()
        {
            Console.WriteLine("Example 10: Backward Compatibility");

            // Static Logger class still works for legacy code
            Logger.Info("Using legacy static Logger API");
            Logger.Warning("This uses the default logger instance");
            Logger.Log("All static methods still function");

            Console.WriteLine("(No exceptions thrown - backward compatible)");
        }
    }
}

