// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Thread.Attributes;
using Alis.Extension.Thread.Builder;
using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Integration;
using Alis.Extension.Thread.Interfaces;

namespace Alis.Extension.Thread.Sample
{
    /// <summary>
    ///     Simple parallel-safe component for velocity
    /// </summary>
    [ParallelSafe(64)]
    public struct VelocityComponent : IParallelCapable
    {
        /// <summary>
        ///     The
        /// </summary>
        public float X;

        /// <summary>
        ///     The
        /// </summary>
        public float Y;

        /// <summary>
        ///     The
        /// </summary>
        public float Z;

        /// <summary>
        ///     Applies the damping using the specified damping
        /// </summary>
        /// <param name="damping">The damping</param>
        public void ApplyDamping(float damping)
        {
            X *= damping;
            Y *= damping;
            Z *= damping;
        }
    }

    /// <summary>
    ///     Parallel-safe position component
    /// </summary>
    [ParallelSafe(128)]
    public struct PositionComponent : IParallelCapable
    {
        /// <summary>
        ///     The
        /// </summary>
        public float X;

        /// <summary>
        ///     The
        /// </summary>
        public float Y;

        /// <summary>
        ///     The
        /// </summary>
        public float Z;

        /// <summary>
        ///     Applies the velocity using the specified velocity
        /// </summary>
        /// <param name="velocity">The velocity</param>
        /// <param name="deltaTime">The delta time</param>
        public void ApplyVelocity(VelocityComponent velocity, float deltaTime)
        {
            X += velocity.X * deltaTime;
            Y += velocity.Y * deltaTime;
            Z += velocity.Z * deltaTime;
        }
    }

    /// <summary>
    ///     Component for physics calculations (heavy computation)
    /// </summary>
    [ParallelSafe(32)]
    public struct PhysicsComponent : IParallelCapable
    {
        /// <summary>
        ///     The mass
        /// </summary>
        public float Mass;

        /// <summary>
        ///     The friction
        /// </summary>
        public float Friction;

        /// <summary>
        ///     The restitution
        /// </summary>
        public float Restitution;

        /// <summary>
        ///     Calculates the force using the specified acceleration
        /// </summary>
        /// <param name="acceleration">The acceleration</param>
        /// <returns>The float</returns>
        public float CalculateForce(float acceleration) => Mass * acceleration;
    }

    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            Logger.Info("╔═══════════════════════════════════════════════════════════════╗");
            Logger.Info("║        ALIS THREAD EXTENSION - PARALLEL ECS DEMO             ║");
            Logger.Info("╚═══════════════════════════════════════════════════════════════╝\n");

            // Demo 1: Basic parallel execution
            DemoBasicParallelExecution();
            WaitForKey("\nPress any key for configuration demo...");

            // Demo 2: Custom configuration
            DemoCustomConfiguration();
            WaitForKey("\nPress any key for ECS integration demo...");

            // Demo 3: ECS component parallelization
            DemoEcsIntegration();
            WaitForKey("\nPress any key for performance comparison...");

            // Demo 4: Performance benchmarks
            DemoPerformanceComparison();
            WaitForKey("\nPress any key for advanced scenarios...");

            // Demo 5: Advanced scenarios
            DemoAdvancedScenarios();

            Logger.Info("\n╔═══════════════════════════════════════════════════════════════╗");
            Logger.Info("║                     DEMO COMPLETED                            ║");
            Logger.Info("╚═══════════════════════════════════════════════════════════════╝");
            WaitForKey("\nPress any key to exit...");
        }

        /// <summary>
        ///     Demonstrates basic parallel execution
        /// </summary>
        private static void DemoBasicParallelExecution()
        {
            Logger.Info("─── 1. BASIC PARALLEL EXECUTION ───\n");

            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .EnableParallelExecution()
                       .WithAutoThreadCount()
                       .BuildManager())
            {
                const int itemCount = 5000;
                int[] data = new int[itemCount];

                Logger.Info($"Processing {itemCount} items in parallel...");

                Stopwatch sw = Stopwatch.StartNew();
                manager.ParallelExecutor.ExecuteUpdate(itemCount, (start, length) =>
                {
                    for (int i = start; i < start + length; i++)
                    {
                        data[i] = ComputeExpensiveOperation(i);
                    }
                }, true, 64);
                sw.Stop();

                Logger.Info($"✓ Completed in {sw.ElapsedMilliseconds}ms");
                Logger.Info($"  Sample results: data[0]={data[0]}, data[100]={data[100]}, data[1000]={data[1000]}");
            }
        }

        /// <summary>
        ///     Demonstrates custom configuration
        /// </summary>
        private static void DemoCustomConfiguration()
        {
            Logger.Info("\n─── 2. CUSTOM CONFIGURATION ───\n");

            // Configuration with builder
            ParallelExtensionConfiguration config = new ParallelExtensionConfigurationBuilder()
                .WithParallelExecution(true)
                .WithMaxDegreeOfParallelism(4)
                .WithMinBatchSizePerThread(32)
                .WithDefaultMinBatchSize(64)
                .Build();

            using (ThreadManager manager = new ThreadManager(config))
            {
                Logger.Info("Configuration:");
                Logger.Info($"  - Parallel Execution: {config.EnableParallelExecution}");
                Logger.Info($"  - Max Threads: {config.MaxDegreeOfParallelism}");
                Logger.Info($"  - Min Batch Size: {config.MinBatchSizePerThread}");

                int[] data = new int[2000];
                manager.ParallelExecutor.ExecuteUpdate(data.Length, (start, length) =>
                {
                    for (int i = start; i < start + length; i++)
                    {
                        data[i] = i * 2;
                    }
                }, true);

                Logger.Info($"✓ Processed {data.Length} items with custom configuration");
            }
        }

        /// <summary>
        ///     Demonstrates ECS integration
        /// </summary>
        private static void DemoEcsIntegration()
        {
            Logger.Info("\n─── 3. ECS COMPONENT INTEGRATION ───\n");

            ComponentUpdateParallelizer parallelizer = ParallelExtensionBuilder.Create()
                .EnableParallelExecution()
                .WithMaxThreads(Environment.ProcessorCount)
                .BuildParallelizer();

            const int entityCount = 10000;
            VelocityComponent[] velocities = new VelocityComponent[entityCount];
            PositionComponent[] positions = new PositionComponent[entityCount];
            PhysicsComponent[] physics = new PhysicsComponent[entityCount];

            // Initialize components
            for (int i = 0; i < entityCount; i++)
            {
                velocities[i] = new VelocityComponent {X = i * 0.1f, Y = i * 0.2f, Z = i * 0.3f};
                positions[i] = new PositionComponent {X = 0, Y = 0, Z = 0};
                physics[i] = new PhysicsComponent {Mass = 1.0f + i * 0.001f, Friction = 0.5f, Restitution = 0.8f};
            }

            Logger.Info($"Simulating {entityCount} entities with 3 components each...");
            Stopwatch sw = Stopwatch.StartNew();

            const float deltaTime = 0.016f; // 60 FPS

            // Update physics (parallel)
            Span<PhysicsComponent> physicsSpan = physics.AsSpan();
            parallelizer.ExecuteComponentUpdate(physicsSpan, index =>
            {
                float force = physics[index].CalculateForce(9.81f);
                velocities[index].Y += force / physics[index].Mass * deltaTime;
            });

            // Apply damping to velocities (parallel)
            Span<VelocityComponent> velocitySpan = velocities.AsSpan();
            parallelizer.ExecuteComponentUpdate(velocitySpan, index => { velocities[index].ApplyDamping(0.99f); });

            // Update positions (parallel with range action)
            parallelizer.ExecuteRangeUpdate<PositionComponent>(entityCount, (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    positions[i].ApplyVelocity(velocities[i], deltaTime);
                }
            });

            sw.Stop();
            Logger.Info($"✓ ECS update completed in {sw.ElapsedMilliseconds}ms");
            Logger.Info($"  Entity 0 - Position: ({positions[0].X:F3}, {positions[0].Y:F3}, {positions[0].Z:F3})");
            Logger.Info($"  Entity 500 - Position: ({positions[500].X:F3}, {positions[500].Y:F3}, {positions[500].Z:F3})");
        }

        /// <summary>
        ///     Demonstrates performance comparison
        /// </summary>
        private static void DemoPerformanceComparison()
        {
            Logger.Info("\n─── 4. PERFORMANCE COMPARISON ───\n");

            const int iterations = 3;
            const int dataSize = 20000;

            // Sequential baseline
            Logger.Info("Running sequential baseline...");
            long sequentialTime = 0;
            for (int iter = 0; iter < iterations; iter++)
            {
                int[] data = new int[dataSize];
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < dataSize; i++)
                {
                    data[i] = ComputeExpensiveOperation(i);
                }

                sw.Stop();
                sequentialTime += sw.ElapsedMilliseconds;
            }

            sequentialTime /= iterations;
            Logger.Info($"  Average: {sequentialTime}ms");

            // Parallel execution
            Logger.Info("\nRunning parallel execution...");
            long parallelTime = 0;
            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .EnableParallelExecution()
                       .WithMaxThreads(Environment.ProcessorCount)
                       .BuildManager())
            {
                for (int iter = 0; iter < iterations; iter++)
                {
                    int[] data = new int[dataSize];
                    Stopwatch sw = Stopwatch.StartNew();
                    manager.ParallelExecutor.ExecuteUpdate(dataSize, (start, length) =>
                    {
                        for (int i = start; i < start + length; i++)
                        {
                            data[i] = ComputeExpensiveOperation(i);
                        }
                    }, true, 64);
                    sw.Stop();
                    parallelTime += sw.ElapsedMilliseconds;
                }
            }

            parallelTime /= iterations;
            Logger.Info($"  Average: {parallelTime}ms");

            double speedup = (double) sequentialTime / parallelTime;
            Logger.Info($"\n✓ Speedup: {speedup:F2}x faster");
            Logger.Info($"  Efficiency: {speedup / Environment.ProcessorCount * 100:F1}%");
        }

        /// <summary>
        ///     Demonstrates advanced scenarios
        /// </summary>
        private static void DemoAdvancedScenarios()
        {
            Logger.Info("\n─── 5. ADVANCED SCENARIOS ───\n");

            // Scenario 1: Adaptive batch sizing
            Logger.Info("Scenario 1: Adaptive batch sizing");
            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .WithMinBatchSize(32)
                       .BuildManager())
            {
                VelocityComponent[] smallDataset = new VelocityComponent[100];
                VelocityComponent[] largeDataset = new VelocityComponent[10000];

                Span<VelocityComponent> smallSpan = smallDataset.AsSpan();
                Span<VelocityComponent> largeSpan = largeDataset.AsSpan();

                ComponentUpdateParallelizer parallelizer = new ComponentUpdateParallelizer(manager.ParallelExecutor);

                // Small dataset - likely sequential
                parallelizer.ExecuteComponentUpdate(smallSpan, i => smallDataset[i].X = i);
                Logger.Info($"  ✓ Small dataset ({smallDataset.Length} items) processed");

                // Large dataset - parallel
                parallelizer.ExecuteComponentUpdate(largeSpan, i => largeDataset[i].X = i);
                Logger.Info($"  ✓ Large dataset ({largeDataset.Length} items) processed");
            }

            // Scenario 2: Mixed component updates
            Logger.Info("\nScenario 2: Mixed sequential and parallel updates");
            using (ThreadManager manager = new ThreadManager())
            {
                const int count = 5000;
                float[] criticalData = new float[count]; // Sequential
                int[] normalData = new int[count]; // Parallel

                // Critical section - sequential
                for (int i = 0; i < count; i++)
                {
                    criticalData[i] = (float) Math.Sin(i * 0.01);
                }

                // Normal processing - parallel
                manager.ParallelExecutor.ExecuteUpdate(count, (start, length) =>
                {
                    for (int i = start; i < start + length; i++)
                    {
                        normalData[i] = (int) (criticalData[i] * 1000);
                    }
                }, true);

                Logger.Info("  ✓ Mixed update completed");
            }

            // Scenario 3: Disabled parallelism for debugging
            Logger.Info("\nScenario 3: Debugging mode (parallel disabled)");
            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .DisableParallelExecution()
                       .BuildManager())
            {
                int[] data = new int[1000];
                manager.ParallelExecutor.ExecuteUpdate(data.Length, (start, length) =>
                {
                    for (int i = start; i < start + length; i++)
                    {
                        data[i] = i;
                    }
                });
                Logger.Info("  ✓ Debug mode: sequential execution verified");
            }
        }

        /// <summary>
        ///     Simulates an expensive computation
        /// </summary>
        private static int ComputeExpensiveOperation(int input)
        {
            int result = input;
            for (int i = 0; i < 150; i++)
            {
                result = (result * 31 + i) % 1000000;
            }

            return result;
        }

        /// <summary>
        ///     Waits for user key press
        /// </summary>
        private static void WaitForKey(string message)
        {
            Logger.Info(message);
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}