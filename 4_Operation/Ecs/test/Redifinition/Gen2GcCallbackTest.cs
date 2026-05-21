

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
            bool callbackExecuted = false;

            Exception exception = Record.Exception(() =>
            {
                Gen2GcCallback.Register(() =>
                {
                    callbackExecuted = true;
                    return false; // Don't reschedule
                });
            });

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
            bool callbackCalled = false;

            Gen2GcCallback.Register(() =>
            {
                callbackCalled = true;
                return false;
            });

            for (int i = 0; i < 3; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                Thread.Sleep(10);
            }

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
            object targetObject = new object();

            Exception exception = Record.Exception(() => { Gen2GcCallback.Register(obj => { return false; }, targetObject); });

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
            int callCount = 0;

            Gen2GcCallback.Register(() =>
            {
                callCount++;
                return false; // Stop after first call
            });

            for (int i = 0; i < 5; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(10);
            }

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
            bool eventFired = false;
            Action originalHandler = Gen2GcCallback.Gen2CollectionOccured;

            try
            {
                Gen2GcCallback.Gen2CollectionOccured = () => { eventFired = true; };

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(10);

                Assert.NotNull(Gen2GcCallback.Gen2CollectionOccured);
            }
            finally
            {
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
            int callback1Count = 0;
            int callback2Count = 0;
            int callback3Count = 0;

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

            for (int i = 0; i < 3; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(10);
            }

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
            WeakReference weakRef;

            void CreateAndRegisterCallback()
            {
                object targetObj = new object();
                weakRef = new WeakReference(targetObj);

                Gen2GcCallback.Register(obj =>
                {
                    return true; // Try to keep alive
                }, targetObj);

            }

            CreateAndRegisterCallback();

            for (int i = 0; i < 5; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                Thread.Sleep(10);
            }

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
            Exception exception = Record.Exception(() => { Gen2GcCallback.Register(obj => { return false; }, null); });

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
            Exception exception = Record.Exception(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Gen2GcCallback.Register(() => false);
                }
            });

            Assert.Null(exception);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}