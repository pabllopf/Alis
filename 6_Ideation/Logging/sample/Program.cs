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
using System.IO;
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
            Console.WriteLine("=== Alis Logging Framework - Complete Sample Suite ===\n");

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
            Console.WriteLine("\n---\n");

            // Example 11: File logging with rotation
            FileLoggingExample();
            Console.WriteLine("\n---\n");

            // Example 12: Async logging for performance
            AsyncLoggingExample();
            Console.WriteLine("\n---\n");

            // Example 13: Debug output for IDE integration
            DebugOutputExample();
            Console.WriteLine("\n---\n");

            // Example 14: Advanced filtering - Sampling
            SamplingFilterExample();
            Console.WriteLine("\n---\n");

            // Example 15: Advanced filtering - Conditional
            ConditionalFilterExample();
            Console.WriteLine("\n---\n");

            // Example 16: Advanced filtering - Composite
            CompositeFilterExample();
            Console.WriteLine("\n---\n");

            // Example 17: IsEnabled performance optimization
            IsEnabledExample();
            Console.WriteLine("\n---\n");

            // Example 18: Complex structured logging
            ComplexStructuredLoggingExample();
            Console.WriteLine("\n---\n");

            // Example 19: Multi-level scopes
            MultiLevelScopesExample();
            Console.WriteLine("\n---\n");

            // Example 20: Mixed log levels and filtering
            MixedLevelsFilteringExample();
            Console.WriteLine("\n---\n");

            // Example 21: Performance testing scenario
            PerformanceTestingExample();
            Console.WriteLine("\n---\n");

            // Example 22: Custom properties in log entries
            CustomPropertiesExample();
            Console.WriteLine("\n---\n");

            // Example 23: All formatters comparison
            AllFormattersComparisonExample();
            Console.WriteLine("\n---\n");

            // Example 24: Real-world game scenario
            RealWorldGameScenarioExample();
            Console.WriteLine("\n---\n");

            // Example 25: Error handling and resilience
            ErrorHandlingExample();

            Console.WriteLine("\n=== All 25 Examples Completed Successfully ===");
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

        /// <summary>
        ///     Example 11: File logging with multiple files.
        /// </summary>
        private static void FileLoggingExample()
        {
            Console.WriteLine("Example 11: File Logging");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Create logs directory
                string logsDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");
                string appLogPath = Path.Combine(logsDir, "application.log");
                string errorLogPath = Path.Combine(logsDir, "errors.log");

                // General application log
                factory.AddOutput(new FileLogOutput(appLogPath, new SimpleLogFormatter()));
                
                // Error-only log with JSON format
                factory.AddOutput(new FileLogOutput(errorLogPath, new JsonLogFormatter()));
                factory.AddFilter(new LogLevelFilter(LogLevel.Error));

                // Also output to console
                factory.AddOutput(new ConsoleLogOutput(new CompactLogFormatter()));

                ILogger logger = factory.CreateLogger("FileLogging.App");

                logger.LogInfo("Application started - logs written to files");
                logger.LogInfo($"Log directory: {logsDir}");
                logger.LogDebug("This is a debug message");
                logger.LogWarning("This is a warning");
                logger.LogError("This is an error - written to both logs");
                
                Console.WriteLine($"Logs written to: {logsDir}");
                Console.WriteLine($"  - {Path.GetFileName(appLogPath)} (all levels)");
                Console.WriteLine($"  - {Path.GetFileName(errorLogPath)} (errors only, JSON format)");
            }
        }

        /// <summary>
        ///     Example 12: Async logging for high-performance scenarios.
        /// </summary>
        private static void AsyncLoggingExample()
        {
            Console.WriteLine("Example 12: Async Logging");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Wrap file output in async wrapper for better performance
                string logPath = Path.Combine(Directory.GetCurrentDirectory(), "logs", "async.log");
                FileLogOutput fileOutput = new FileLogOutput(logPath, new SimpleLogFormatter());
                AsyncLogOutput asyncOutput = new AsyncLogOutput(fileOutput, maxQueueSize: 1000);
                
                factory.AddOutput(asyncOutput);
                factory.AddOutput(new ConsoleLogOutput(new CompactLogFormatter()));

                ILogger logger = factory.CreateLogger("AsyncLogging.Performance");

                logger.LogInfo("Starting high-frequency logging simulation");

                // Simulate high-frequency logging (e.g., from game loop)
                for (int i = 0; i < 50; i++)
                {
                    logger.LogTrace($"Frame {i}: Update started");
                    logger.LogDebug($"Frame {i}: Objects processed");
                    
                    if (i % 10 == 0)
                    {
                        logger.LogInfo($"Checkpoint: Frame {i} completed");
                    }
                }

                logger.LogInfo("High-frequency logging completed");
                
                // Flush ensures all queued entries are written
                asyncOutput.Flush();
                Console.WriteLine("All async logs flushed to disk");
            }
        }

        /// <summary>
        ///     Example 13: Debug output for IDE integration.
        /// </summary>
        private static void DebugOutputExample()
        {
            Console.WriteLine("Example 13: Debug Output");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Add debug output - only writes when debugger attached
                factory.AddOutput(new DebugLogOutput(new SimpleLogFormatter()));
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                ILogger logger = factory.CreateLogger("DebugOutput.IDE");

                logger.LogInfo("This message appears in IDE debug output");
                logger.LogWarning("Check your IDE's debug/output window");
                logger.LogError("Debug output is perfect for development");

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.WriteLine("Debugger detected - messages sent to debug output");
                }
                else
                {
                    Console.WriteLine("No debugger attached - debug output inactive");
                }
            }
        }

        /// <summary>
        ///     Example 14: Sampling filter for high-frequency logs.
        /// </summary>
        private static void SamplingFilterExample()
        {
            Console.WriteLine("Example 14: Sampling Filter");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new CompactLogFormatter()));
                
                // Only log 1 out of every 5 entries
                factory.AddFilter(new SamplingLogFilter(sampleRate: 5));

                ILogger logger = factory.CreateLogger("Sampling.HighFrequency");

                logger.LogInfo("Simulating high-frequency logging...");
                
                // Log 25 messages, but only ~5 should appear
                for (int i = 1; i <= 25; i++)
                {
                    logger.LogDebug($"High-frequency event #{i}");
                }

                Console.WriteLine("Only 1 in 5 messages were logged (sampling)");
            }
        }

        /// <summary>
        ///     Example 15: Conditional filter with custom logic.
        /// </summary>
        private static void ConditionalFilterExample()
        {
            Console.WriteLine("Example 15: Conditional Filter");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                // Only log messages containing "important" or "critical"
                factory.AddFilter(new ConditionalLogFilter(
                    entry => entry.Message.Contains("important", StringComparison.OrdinalIgnoreCase) ||
                             entry.Message.Contains("critical", StringComparison.OrdinalIgnoreCase),
                    "ImportantOnlyFilter"
                ));

                ILogger logger = factory.CreateLogger("Conditional.Filter");

                logger.LogInfo("This is a normal message"); // Won't appear
                logger.LogInfo("This is an IMPORTANT message"); // Will appear
                logger.LogWarning("Just a warning"); // Won't appear
                logger.LogError("Critical system failure detected"); // Will appear
                logger.LogDebug("Important: check this out"); // Will appear

                Console.WriteLine("Only messages with 'important' or 'critical' were logged");
            }
        }

        /// <summary>
        ///     Example 16: Composite filter with AND/OR logic.
        /// </summary>
        private static void CompositeFilterExample()
        {
            Console.WriteLine("Example 16: Composite Filter");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                // Combine multiple filters with AND logic
                List<ILogFilter> filters = new List<ILogFilter>
                {
                    new LogLevelFilter(LogLevel.Warning), // Must be Warning or above
                    new LoggerNameFilter(new[] { "Critical" }, inclusive: true) // Must be from Critical logger
                };
                
                factory.AddFilter(new CompositeLogFilter(filters, requireAll: true));

                ILogger criticalLogger = factory.CreateLogger("Critical.System");
                ILogger normalLogger = factory.CreateLogger("Normal.System");

                criticalLogger.LogInfo("Info from critical"); // Won't appear (level too low)
                criticalLogger.LogWarning("Warning from critical"); // Will appear
                criticalLogger.LogError("Error from critical"); // Will appear
                normalLogger.LogError("Error from normal"); // Won't appear (wrong logger name)

                Console.WriteLine("Only Warning+ from Critical logger appeared (AND logic)");
            }

            Console.WriteLine();

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                // Combine filters with OR logic
                List<ILogFilter> filters = new List<ILogFilter>
                {
                    new LogLevelFilter(LogLevel.Error), // Errors from anyone
                    new LoggerNameFilter(new[] { "Important" }, inclusive: true) // Or anything from Important
                };
                
                factory.AddFilter(new CompositeLogFilter(filters, requireAll: false));

                ILogger importantLogger = factory.CreateLogger("Important.Module");
                ILogger normalLogger = factory.CreateLogger("Normal.Module");

                importantLogger.LogInfo("Info from important"); // Will appear
                normalLogger.LogInfo("Info from normal"); // Won't appear
                normalLogger.LogError("Error from normal"); // Will appear (error level)

                Console.WriteLine("Errors OR anything from Important appeared (OR logic)");
            }
        }

        /// <summary>
        ///     Example 17: Using IsEnabled to avoid expensive operations.
        /// </summary>
        private static void IsEnabledExample()
        {
            Console.WriteLine("Example 17: IsEnabled Performance Optimization");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new CompactLogFormatter()));
                factory.SetMinimumLevel(LogLevel.Warning); // Only Warning and above

                ILogger logger = factory.CreateLogger("Performance.Optimized");

                // Check before doing expensive operations
                if (logger.IsEnabled(LogLevel.Debug))
                {
                    // This expensive operation won't run
                    string expensiveDebugInfo = ComputeExpensiveDebugInfo();
                    logger.LogDebug(expensiveDebugInfo);
                }
                else
                {
                    Console.WriteLine("Debug logging disabled - skipped expensive computation");
                }

                if (logger.IsEnabled(LogLevel.Warning))
                {
                    // This will run
                    logger.LogWarning("Warning logging is enabled");
                }

                // Without IsEnabled check - string formatting happens regardless
                logger.LogDebug($"Expensive: {ComputeExpensiveDebugInfo()}"); // String still formatted!

                Console.WriteLine("IsEnabled helps avoid unnecessary work");
            }
        }

        /// <summary>
        ///     Example 18: Complex structured logging with nested objects.
        /// </summary>
        private static void ComplexStructuredLoggingExample()
        {
            Console.WriteLine("Example 18: Complex Structured Logging");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new JsonLogFormatter()));
                factory.AddOutput(new MemoryLogOutput());

                ILogger logger = factory.CreateLogger("Game.Analytics");

                // Complex game event with many properties
                Dictionary<string, object> gameSessionData = new Dictionary<string, object>
                {
                    { "SessionId", Guid.NewGuid() },
                    { "PlayerId", 12345 },
                    { "PlayerName", "HeroWarrior" },
                    { "Level", 42 },
                    { "Class", "Warrior" },
                    { "Health", 850 },
                    { "MaxHealth", 1000 },
                    { "Mana", 200 },
                    { "Experience", 500000 },
                    { "Gold", 15750 },
                    { "PlayTime", TimeSpan.FromHours(25.5).ToString() },
                    { "QuestsCompleted", 87 },
                    { "AchievementsUnlocked", 23 },
                    { "Deaths", 5 },
                    { "LastLocation", "Dragon's Lair" },
                    { "Timestamp", DateTime.UtcNow }
                };

                logger.LogStructured(LogLevel.Info, "Game session snapshot", gameSessionData);

                // Combat event
                Dictionary<string, object> combatData = new Dictionary<string, object>
                {
                    { "EventType", "Combat" },
                    { "Attacker", "HeroWarrior" },
                    { "AttackerLevel", 42 },
                    { "Defender", "Ancient Dragon" },
                    { "DefenderLevel", 50 },
                    { "AttackType", "Power Strike" },
                    { "BaseDamage", 150 },
                    { "CriticalHit", true },
                    { "CriticalMultiplier", 2.5 },
                    { "FinalDamage", 375 },
                    { "DefenderHealthRemaining", 2125 },
                    { "CombatDuration", TimeSpan.FromSeconds(45).ToString() }
                };

                logger.LogStructured(LogLevel.Info, "Combat event recorded", combatData);

                Console.WriteLine("Complex structured data logged in JSON format");
            }
        }

        /// <summary>
        ///     Example 19: Multi-level nested scopes.
        /// </summary>
        private static void MultiLevelScopesExample()
        {
            Console.WriteLine("Example 19: Multi-Level Scopes");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                ILogger logger = factory.CreateLogger("Game.LoadingSystem");

                logger.LogInfo("Game initialization started");

                using (logger.BeginScope("Phase:Initialization"))
                {
                    logger.LogInfo("Loading core systems");

                    using (logger.BeginScope("System:Graphics"))
                    {
                        logger.LogInfo("Initializing renderer");
                        
                        using (logger.BeginScope("Module:Shaders"))
                        {
                            logger.LogDebug("Compiling vertex shaders");
                            logger.LogDebug("Compiling fragment shaders");
                        }
                        
                        using (logger.BeginScope("Module:Textures"))
                        {
                            logger.LogDebug("Loading texture atlas");
                            logger.LogDebug("Generating mipmaps");
                        }
                    }

                    using (logger.BeginScope("System:Audio"))
                    {
                        logger.LogInfo("Initializing audio engine");
                        
                        using (logger.BeginScope("Module:SoundEffects"))
                        {
                            logger.LogDebug("Loading sound bank");
                        }
                        
                        using (logger.BeginScope("Module:Music"))
                        {
                            logger.LogDebug("Streaming background music");
                        }
                    }

                    using (logger.BeginScope("System:Physics"))
                    {
                        logger.LogInfo("Initializing physics engine");
                        logger.LogDebug("Building collision meshes");
                    }
                }

                logger.LogInfo("Game initialization completed");
            }
        }

        /// <summary>
        ///     Example 20: Mixed log levels with intelligent filtering.
        /// </summary>
        private static void MixedLevelsFilteringExample()
        {
            Console.WriteLine("Example 20: Mixed Levels & Filtering");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Console gets everything at Info or above
                ConsoleLogOutput consoleOutput = new ConsoleLogOutput(new CompactLogFormatter());
                factory.AddOutput(consoleOutput);
                factory.AddFilter(new LogLevelFilter(LogLevel.Info));

                // Memory captures everything for debugging
                MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 100);

                ILogger logger = factory.CreateLogger("Mixed.Levels");

                logger.LogTrace("Detailed trace - only in memory");
                logger.LogDebug("Debug info - only in memory");
                logger.LogInfo("Info message - console and memory");
                logger.LogWarning("Warning - console and memory");
                logger.LogError("Error - console and memory");
                logger.LogCritical("Critical - console and memory");

                // Now add memory output and re-test
                factory.AddOutput(memoryOutput);
                
                ILogger logger2 = factory.CreateLogger("Mixed.Levels2");
                logger2.LogTrace("This trace goes to memory");
                logger2.LogInfo("This info goes everywhere");

                Console.WriteLine($"Memory captured all {memoryOutput.GetEntries().Count} entries");
                Console.WriteLine("Console only showed Info and above");
            }
        }

        /// <summary>
        ///     Example 21: Performance testing with high-volume logging.
        /// </summary>
        private static void PerformanceTestingExample()
        {
            Console.WriteLine("Example 21: Performance Testing");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Use memory output to avoid I/O overhead
                MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 10000);
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("Performance.Test");

                logger.LogInfo("Starting performance test");

                System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

                // Log 1000 messages
                for (int i = 0; i < 1000; i++)
                {
                    logger.LogInfo($"Performance test message #{i}");
                }

                stopwatch.Stop();

                logger.LogInfo("Performance test completed");

                double msPerLog = stopwatch.Elapsed.TotalMilliseconds / 1000.0;
                Console.WriteLine($"Logged 1000 messages in {stopwatch.ElapsedMilliseconds}ms");
                Console.WriteLine($"Average: {msPerLog:F4}ms per log");
                Console.WriteLine($"Memory contains {memoryOutput.GetEntries().Count} entries");
            }

            // Test with sampling
            Console.WriteLine("\nWith sampling (1:10):");
            
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 10000);
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new SamplingLogFilter(10));

                ILogger logger = factory.CreateLogger("Performance.Sampled");

                System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

                for (int i = 0; i < 1000; i++)
                {
                    logger.LogInfo($"Sampled message #{i}");
                }

                stopwatch.Stop();

                double msPerLog = stopwatch.Elapsed.TotalMilliseconds / 1000.0;
                Console.WriteLine($"Logged 1000 messages in {stopwatch.ElapsedMilliseconds}ms");
                Console.WriteLine($"Average: {msPerLog:F4}ms per log");
                Console.WriteLine($"Memory contains {memoryOutput.GetEntries().Count} entries (sampling applied)");
            }
        }

        /// <summary>
        ///     Example 22: Custom properties throughout log lifecycle.
        /// </summary>
        private static void CustomPropertiesExample()
        {
            Console.WriteLine("Example 22: Custom Properties");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new JsonLogFormatter()));

                ILogger logger = factory.CreateLogger("CustomProps.Demo");

                // Log with custom properties for business logic
                Dictionary<string, object> userActionProps = new Dictionary<string, object>
                {
                    { "ActionType", "Login" },
                    { "UserId", "user_12345" },
                    { "IPAddress", "192.168.1.100" },
                    { "UserAgent", "Mozilla/5.0" },
                    { "SessionId", Guid.NewGuid().ToString() },
                    { "LoginMethod", "OAuth" },
                    { "Provider", "Google" },
                    { "Success", true },
                    { "Duration", 1250 },
                    { "Timestamp", DateTime.UtcNow.ToString("o") }
                };

                logger.LogStructured(LogLevel.Info, "User login event", userActionProps);

                // E-commerce transaction
                Dictionary<string, object> transactionProps = new Dictionary<string, object>
                {
                    { "TransactionId", "TXN_67890" },
                    { "UserId", "user_12345" },
                    { "Amount", 149.99m },
                    { "Currency", "USD" },
                    { "PaymentMethod", "CreditCard" },
                    { "CardLast4", "4242" },
                    { "ItemCount", 3 },
                    { "ShippingAddress", "123 Main St" },
                    { "Status", "Completed" },
                    { "ProcessingTime", 3421 }
                };

                logger.LogStructured(LogLevel.Info, "Transaction completed", transactionProps);

                Console.WriteLine("Custom properties enable rich analytics");
            }
        }

        /// <summary>
        ///     Example 23: All formatters side-by-side comparison.
        /// </summary>
        private static void AllFormattersComparisonExample()
        {
            Console.WriteLine("Example 23: All Formatters Comparison");

            Dictionary<string, object> props = new Dictionary<string, object>
            {
                { "PlayerId", 12345 },
                { "Health", 75 },
                { "Location", "Boss Arena" }
            };

            LogEntry sampleEntry = new LogEntry(
                LogLevel.Warning,
                "Sample warning message with important data",
                "Game.CombatSystem",
                exception: null,
                correlationId: "CORR-ABC123",
                properties: props,
                scopes: new List<object> { "Combat", "BossArena" }
            );

            Console.WriteLine("═══ SimpleLogFormatter ═══");
            SimpleLogFormatter simpleFormatter = new SimpleLogFormatter();
            Console.WriteLine(simpleFormatter.Format(sampleEntry));

            Console.WriteLine("\n═══ CompactLogFormatter ═══");
            CompactLogFormatter compactFormatter = new CompactLogFormatter();
            Console.WriteLine(compactFormatter.Format(sampleEntry));

            Console.WriteLine("\n═══ JsonLogFormatter ═══");
            JsonLogFormatter jsonFormatter = new JsonLogFormatter();
            Console.WriteLine(jsonFormatter.Format(sampleEntry));

            Console.WriteLine("\nEach formatter serves different purposes:");
            Console.WriteLine("  • Simple: Human-readable, detailed");
            Console.WriteLine("  • Compact: Minimal, fast scanning");
            Console.WriteLine("  • JSON: Machine-parseable, structured");
        }

        /// <summary>
        ///     Example 24: Real-world game scenario with all features.
        /// </summary>
        private static void RealWorldGameScenarioExample()
        {
            Console.WriteLine("Example 24: Real-World Game Scenario");

            using (LoggerFactory factory = new LoggerFactory())
            {
                // Setup comprehensive logging for a game
                string logsDir = Path.Combine(Directory.GetCurrentDirectory(), "logs");
                
                // Console for development
                factory.AddOutput(new ConsoleLogOutput(new CompactLogFormatter()));
                
                // General game log
                factory.AddOutput(new FileLogOutput(
                    Path.Combine(logsDir, "game.log"),
                    new SimpleLogFormatter()
                ));
                
                // Analytics in JSON
                factory.AddOutput(new FileLogOutput(
                    Path.Combine(logsDir, "analytics.json"),
                    new JsonLogFormatter()
                ));

                // Memory for in-game debugging
                MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 500);
                factory.AddOutput(memoryOutput);

                factory.SetMinimumLevel(LogLevel.Debug);

                // Create specialized loggers for different systems
                ILogger engineLogger = factory.CreateLogger("Engine.Core");
                ILogger renderLogger = factory.CreateLogger("Engine.Renderer");
                ILogger physicsLogger = factory.CreateLogger("Engine.Physics");
                ILogger gameplayLogger = factory.CreateLogger("Game.Gameplay");
                ILogger networkLogger = factory.CreateLogger("Network.Multiplayer");

                // Simulate game startup
                string sessionId = Guid.NewGuid().ToString("N").Substring(0, 8);
                engineLogger.SetCorrelationId(sessionId);
                renderLogger.SetCorrelationId(sessionId);
                physicsLogger.SetCorrelationId(sessionId);
                gameplayLogger.SetCorrelationId(sessionId);
                networkLogger.SetCorrelationId(sessionId);

                engineLogger.LogInfo($"Game session started [ID: {sessionId}]");

                using (engineLogger.BeginScope("Startup"))
                {
                    renderLogger.LogInfo("Graphics engine initialized");
                    renderLogger.LogDebug("Resolution: 1920x1080, VSync: ON");
                    
                    physicsLogger.LogInfo("Physics engine initialized");
                    physicsLogger.LogDebug("Gravity: -9.81, Fixed timestep: 0.02s");
                    
                    networkLogger.LogInfo("Connecting to multiplayer server...");
                    networkLogger.LogWarning("Server latency: 85ms (acceptable)");
                }

                using (gameplayLogger.BeginScope("Level:BossFight"))
                {
                    gameplayLogger.LogInfo("Level loaded: Boss Arena");
                    
                    // Simulate combat
                    for (int turn = 1; turn <= 3; turn++)
                    {
                        Dictionary<string, object> combatData = new Dictionary<string, object>
                        {
                            { "Turn", turn },
                            { "PlayerHealth", 100 - (turn * 15) },
                            { "BossHealth", 500 - (turn * 80) },
                            { "DamageDealt", 80 },
                            { "DamageTaken", 15 }
                        };
                        
                        gameplayLogger.LogStructured(LogLevel.Info, $"Combat turn {turn}", combatData);
                    }
                    
                    gameplayLogger.LogInfo("Boss defeated!");
                }

                engineLogger.LogInfo("Game session ended normally");
                
                Console.WriteLine($"\nSession summary:");
                Console.WriteLine($"  • Session ID: {sessionId}");
                Console.WriteLine($"  • Logs directory: {logsDir}");
                Console.WriteLine($"  • Memory buffer: {memoryOutput.GetEntries().Count} entries");
                Console.WriteLine($"  • Systems logged: Engine, Renderer, Physics, Gameplay, Network");
            }
        }

        /// <summary>
        ///     Example 25: Error handling and resilience.
        /// </summary>
        private static void ErrorHandlingExample()
        {
            Console.WriteLine("Example 25: Error Handling & Resilience");

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));

                ILogger logger = factory.CreateLogger("ErrorHandling.Test");

                // Test 1: Exception with context
                try
                {
                    ThrowExampleException();
                }
                catch (Exception ex)
                {
                    logger.LogError("Caught exception during operation", ex);
                    logger.LogInfo("Application continues after error");
                }

                // Test 2: Critical exception
                try
                {
                    ThrowCriticalException();
                }
                catch (Exception ex)
                {
                    logger.LogCritical("Critical system failure", ex);
                    
                    // Log recovery attempt
                    Dictionary<string, object> recoveryInfo = new Dictionary<string, object>
                    {
                        { "ErrorType", ex.GetType().Name },
                        { "RecoveryAction", "Restart subsystem" },
                        { "RecoveryStatus", "Initiated" },
                        { "Timestamp", DateTime.UtcNow }
                    };
                    
                    logger.LogStructured(LogLevel.Warning, "Attempting recovery", recoveryInfo);
                }

                // Test 3: Nested exceptions
                try
                {
                    ThrowNestedExceptions();
                }
                catch (Exception ex)
                {
                    logger.LogError("Nested exception chain detected", ex);
                    
                    Exception inner = ex.InnerException;
                    int depth = 1;
                    while (inner != null)
                    {
                        logger.LogDebug($"  Inner exception #{depth}: {inner.Message}");
                        inner = inner.InnerException;
                        depth++;
                    }
                }

                logger.LogInfo("Error handling test completed - system stable");
            }
        }

        // Helper methods for examples

        /// <summary>
        ///     Simulates an expensive computation for IsEnabled example.
        /// </summary>
        private static string ComputeExpensiveDebugInfo()
        {
            // Simulate expensive operation
            System.Threading.Thread.Sleep(10);
            return $"Expensive debug data: {Guid.NewGuid()}";
        }

        /// <summary>
        ///     Throws a sample exception for testing.
        /// </summary>
        private static void ThrowExampleException()
        {
            throw new InvalidOperationException("This is a test exception with details");
        }

        /// <summary>
        ///     Throws a critical exception for testing.
        /// </summary>
        private static void ThrowCriticalException()
        {
            throw new SystemException("Critical system component failed");
        }

        /// <summary>
        ///     Throws nested exceptions for testing.
        /// </summary>
        private static void ThrowNestedExceptions()
        {
            try
            {
                try
                {
                    throw new ArgumentException("Inner-most exception");
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Middle exception", ex);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Outer exception", ex);
            }
        }
    }
}

