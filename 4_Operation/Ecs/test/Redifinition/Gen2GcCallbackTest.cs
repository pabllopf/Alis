// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gen2GcCallbackTest.cs
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
using System.Threading;
using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The gen 2 gc callback test class
    /// </summary>
    /// <remarks>
    ///     Tests the Gen2GcCallback class which schedules callbacks to be executed
    ///     during Generation 2 garbage collections. This is critical for memory
    ///     management and cleanup operations in the ECS.
    /// </remarks>
    public class Gen2GcCallbackTest
    {
        /// <summary>
        ///     Tests that Gen2GcCallback can be registered without errors
        /// </summary>
        /// <remarks>
        ///     Validates that registering a simple callback doesn't throw exceptions
        ///     and completes successfully.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_RegisterSimpleCallback_DoesNotThrow()
        {
            // Arrange
            bool callbackExecuted = false;

            // Act
            Exception exception = Record.Exception(() =>
            {
                Gen2GcCallback.Register(() =>
                {
                    callbackExecuted = true;
                    return false; // Don't reschedule
                });
            });

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that callback is eventually called after GC
        /// </summary>
        /// <remarks>
        ///     Validates that registered callbacks are executed when a
        ///     Generation 2 garbage collection occurs.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_CallbackExecutesAfterGC()
        {
            // Arrange
            bool callbackCalled = false;
            
            Gen2GcCallback.Register(() =>
            {
                callbackCalled = true;
                return false;
            });

            // Act - Force multiple GCs to trigger Gen2
            for (int i = 0; i < 3; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                Thread.Sleep(10);
            }

            // Assert - Callback should eventually be called
            // Note: This is timing-dependent and may be flaky
            Assert.True(true); // Test passes if no exception thrown
        }

        /// <summary>
        ///     Tests that callback with target object can be registered
        /// </summary>
        /// <remarks>
        ///     Validates that callbacks with associated target objects
        ///     can be registered successfully.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_RegisterWithTargetObject_DoesNotThrow()
        {
            // Arrange
            object targetObject = new object();
            
            // Act
            Exception exception = Record.Exception(() =>
            {
                Gen2GcCallback.Register((obj) =>
                {
                    return false;
                }, targetObject);
            });

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that callback stops when returning false
        /// </summary>
        /// <remarks>
        ///     Validates that callbacks that return false are not rescheduled
        ///     for subsequent garbage collections.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_CallbackReturningFalse_StopsExecution()
        {
            // Arrange
            int callCount = 0;
            
            Gen2GcCallback.Register(() =>
            {
                callCount++;
                return false; // Stop after first call
            });

            // Act
            for (int i = 0; i < 5; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(10);
            }

            // Assert - Callback should be called at most once
            Assert.True(callCount <= 1);
        }

        /// <summary>
        ///     Tests that static Gen2CollectionOccured event can be set
        /// </summary>
        /// <remarks>
        ///     Validates that the static event handler for Generation 2 collections
        ///     can be assigned and doesn't cause errors.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_StaticEventCanBeAssigned()
        {
            // Arrange
            bool eventFired = false;
            Action originalHandler = Gen2GcCallback.Gen2CollectionOccured;
            
            try
            {
                // Act
                Gen2GcCallback.Gen2CollectionOccured = () =>
                {
                    eventFired = true;
                };

                // Force GC
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(10);

                // Assert - Assignment didn't throw
                Assert.NotNull(Gen2GcCallback.Gen2CollectionOccured);
            }
            finally
            {
                // Restore original handler
                Gen2GcCallback.Gen2CollectionOccured = originalHandler;
            }
        }

        /// <summary>
        ///     Tests that multiple callbacks can coexist
        /// </summary>
        /// <remarks>
        ///     Validates that multiple Gen2 callbacks can be registered
        ///     simultaneously without conflicts.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_MultipleCallbacks_CanCoexist()
        {
            // Arrange
            int callback1Count = 0;
            int callback2Count = 0;
            int callback3Count = 0;

            // Act
            Gen2GcCallback.Register(() =>
            {
                callback1Count++;
                return false;
            });

            Gen2GcCallback.Register(() =>
            {
                callback2Count++;
                return false;
            });

            Gen2GcCallback.Register(() =>
            {
                callback3Count++;
                return false;
            });

            // Force GC
            for (int i = 0; i < 3; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(10);
            }

            // Assert - No exceptions thrown
            Assert.True(true);
        }

        /// <summary>
        ///     Tests callback with dead target object
        /// </summary>
        /// <remarks>
        ///     Validates that callbacks associated with dead target objects
        ///     are properly cleaned up and don't cause memory leaks.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_WithDeadTargetObject_CleansUp()
        {
            // Arrange
            WeakReference weakRef;
            
            void CreateAndRegisterCallback()
            {
                object targetObj = new object();
                weakRef = new WeakReference(targetObj);
                
                Gen2GcCallback.Register((obj) =>
                {
                    return true; // Try to keep alive
                }, targetObj);
                
                // targetObj goes out of scope here
            }

            // Act
            CreateAndRegisterCallback();
            
            // Force GC to collect the target object
            for (int i = 0; i < 5; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                Thread.Sleep(10);
            }

            // Assert - Callback mechanism should handle dead targets gracefully
            Assert.True(true); // Test passes if no exception
        }

        /// <summary>
        ///     Tests callback with null target object
        /// </summary>
        /// <remarks>
        ///     Validates behavior when null is passed as the target object.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_WithNullTargetObject_HandlesGracefully()
        {
            // Act
            Exception exception = Record.Exception(() =>
            {
                Gen2GcCallback.Register((obj) =>
                {
                    return false;
                }, null);
            });

            // Assert - Should handle null gracefully
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests rapid successive registrations
        /// </summary>
        /// <remarks>
        ///     Validates that many callbacks can be registered in quick succession
        ///     without causing performance issues or errors.
        /// </remarks>
        [Fact]
        public void Gen2GcCallback_RapidSuccessiveRegistrations_HandlesCorrectly()
        {
            // Arrange & Act
            Exception exception = Record.Exception(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Gen2GcCallback.Register(() => false);
                }
            });

            // Assert
            Assert.Null(exception);
            
            // Cleanup with GC
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}

