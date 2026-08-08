// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gen2GcCallbackCoverageTests.cs
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
using System.Reflection;
using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    /// The gen gc callback coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    [CollectionDefinition("Gen2GcCallbackCoverage", DisableParallelization = true)]
    public class Gen2GcCallbackCoverageTests : IDisposable
    {
        /// <summary>
        /// The non public
        /// </summary>
        private static readonly FieldInfo RegisteredCallbacksField =
            typeof(Gen2GcCallback).GetField("_registeredCallbacks", BindingFlags.Static | BindingFlags.NonPublic);

        /// <summary>
        /// The non public
        /// </summary>
        private static readonly FieldInfo Gen2CollectionLockField =
            typeof(Gen2GcCallback).GetField("Gen2CollectionLock", BindingFlags.Static | BindingFlags.NonPublic);

        /// <summary>
        /// Initializes a new instance of the <see cref="Gen2GcCallbackCoverageTests"/> class
        /// </summary>
        public Gen2GcCallbackCoverageTests()
        {
            ClearRegisteredCallbacks();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            ClearRegisteredCallbacks();
        }

        /// <summary>
        /// Clears the registered callbacks
        /// </summary>
        private static void ClearRegisteredCallbacks()
        {
            if (RegisteredCallbacksField?.GetValue(null) is System.Collections.IList list)
            {
                list.Clear();
            }
        }

        /// <summary>
        /// Registers the and release using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        private static void RegisterAndRelease(Func<bool> callback)
        {
            Gen2GcCallback.Register(callback);
            ClearRegisteredCallbacks();
        }

        /// <summary>
        /// Registers the and release using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="target">The target</param>
        private static void RegisterAndRelease(Func<object, bool> callback, object target)
        {
            Gen2GcCallback.Register(callback, target);
            ClearRegisteredCallbacks();
        }

        /// <summary>
        /// Forces the gc
        /// </summary>
        private static void ForceGC()
        {
            for (int i = 0; i < 5; i++)
            {
                GC.Collect(2, GCCollectionMode.Forced, blocking: true);
                GC.WaitForPendingFinalizers();
            }
        }

        /// <summary>
        /// Tests that finalizer simple callback returning false does not reschedule
        /// </summary>
        [Fact]
        public void Finalizer_SimpleCallbackReturningFalse_DoesNotReschedule()
        {
            bool called = false;
            RegisterAndRelease(() => { called = true; return false; });
            ForceGC();
            Assert.True(called);
        }

        /// <summary>
        /// Tests that finalizer simple callback returning true reschedules
        /// </summary>
        [Fact]
        public void Finalizer_SimpleCallbackReturningTrue_Reschedules()
        {
            int callCount = 0;
            RegisterAndRelease(() => { callCount++; return true; });
            ForceGC();
            Assert.True(callCount >= 1);
        }

        /// <summary>
        /// Tests that finalizer object callback target alive returning false frees handle
        /// </summary>
        [Fact]
        public void Finalizer_ObjectCallbackTargetAliveReturningFalse_FreesHandle()
        {
            bool called = false;
            object target = new object();
            RegisterAndRelease(obj => { called = true; return false; }, target);
            GC.KeepAlive(target);
            ForceGC();
            Assert.True(called);
        }

        /// <summary>
        /// Tests that finalizer object callback target alive returning true reschedules
        /// </summary>
        [Fact]
        public void Finalizer_ObjectCallbackTargetAliveReturningTrue_Reschedules()
        {
            int callCount = 0;
            object target = new object();
            RegisterAndRelease(obj => { callCount++; return true; }, target);
            GC.KeepAlive(target);
            ForceGC();
            Assert.True(callCount >= 1);
        }

        /// <summary>
        /// Tests that finalizer object callback target collected frees handle without invocation
        /// </summary>
        [Fact]
        public void Finalizer_ObjectCallbackTargetCollected_FreesHandleWithoutInvocation()
        {
            bool[] called = { false };
            WeakReference weakRef;

            void Scope()
            {
                object target = new object();
                weakRef = new WeakReference(target);
                Gen2GcCallback.Register(obj =>
                {
                    called[0] = true;
                    return false;
                }, target);
            }

            Scope();
            ClearRegisteredCallbacks();

            for (int i = 0; i < 5; i++)
            {
                GC.Collect(2, GCCollectionMode.Forced, blocking: true);
                GC.WaitForPendingFinalizers();
            }

            Assert.False(weakRef.IsAlive);
        }

        /// <summary>
        /// Tests that finalizer null target frees handle
        /// </summary>
        [Fact]
        public void Finalizer_NullTarget_FreesHandle()
        {
            bool called = false;
            RegisterAndRelease(obj =>
            {
                called = true;
                return false;
            }, null);
            ForceGC();
        }

        /// <summary>
        /// Tests that finalizer object callback target alive returning false no reschedule
        /// </summary>
        [Fact]
        public void Finalizer_ObjectCallbackTargetAliveReturningFalse_NoReschedule()
        {
            int callCount = 0;
            object target = new object();
            RegisterAndRelease(obj =>
            {
                callCount++;
                return false;
            }, target);
            GC.KeepAlive(target);
            ForceGC();
            Assert.True(callCount <= 1);
        }

        /// <summary>
        /// Tests that finalizer simple callback combined with object callback no throw
        /// </summary>
        [Fact]
        public void Finalizer_SimpleCallbackCombinedWithObjectCallback_NoThrow()
        {
            Gen2GcCallback.Register(() => true);
            Gen2GcCallback.Register(obj => true, new object());
            ClearRegisteredCallbacks();
            ForceGC();
        }

        /// <summary>
        /// Tests that finalizer static ctor registered callback executes gen 2 collection occured
        /// </summary>
        [Fact]
        public void Finalizer_StaticCtorRegisteredCallback_ExecutesGen2CollectionOccured()
        {
            bool eventFired = false;
            Action saved = Gen2GcCallback.Gen2CollectionOccured;
            Gen2GcCallback.Gen2CollectionOccured = () => eventFired = true;

            ClearRegisteredCallbacks();
            RegisterAndRelease(() =>
            {
                Gen2GcCallback.Gen2CollectionOccured?.Invoke();
                return false;
            });
            ForceGC();

            Gen2GcCallback.Gen2CollectionOccured = saved;
        }
    }
}
