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
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    [CollectionDefinition("Gen2GcCallbackTest", DisableParallelization = true)]
    public class Gen2GcCallbackTestDefinition
    {
    }

    [Collection("Gen2GcCallbackTest")]
    public class Gen2GcCallbackTest
    {
        [Fact]
        public void Register_FuncBool_DoesNotThrow()
        {
            Exception exception = Record.Exception(() => Gen2GcCallback.Register(() => false));

            Assert.Null(exception);
        }

        [Fact]
        public void Register_FuncObjectBool_DoesNotThrow()
        {
            object target = new object();

            Exception exception = Record.Exception(() => Gen2GcCallback.Register(obj => false, target));

            Assert.Null(exception);
        }

        [Fact]
        public void Register_WithNullTarget_DoesNotThrow()
        {
            Exception exception = Record.Exception(() => Gen2GcCallback.Register(obj => false, null));

            Assert.Null(exception);
        }

        [Fact]
        public void FuncBoolReturningFalse_ExecutesOnceAfterFinalization()
        {
            int callCount = 0;
            Gen2GcCallback.Register(() =>
            {
                callCount++;
                return false;
            });
            ClearRegisteredCallbacks();

            ForceGc();

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void FuncBoolReturningTrue_ReschedulesAfterFinalization()
        {
            int callCount = 0;
            Gen2GcCallback.Register(() =>
            {
                callCount++;
                return true;
            });
            ClearRegisteredCallbacks();

            ForceGc();
            ForceGc();
            ForceGc();

            Assert.True(callCount >= 2, $"Expected at least 2 invocations, got {callCount}");
        }

        [Fact]
        public void ObjectCallbackWithAliveTargetReturningFalse_ExecutesOnce()
        {
            int callCount = 0;
            object target = new object();
            Gen2GcCallback.Register(obj =>
            {
                callCount++;
                return false;
            }, target);
            ClearRegisteredCallbacks();

            ForceGc();

            Assert.Equal(1, callCount);
            GC.KeepAlive(target);
        }

        [Fact]
        public void ObjectCallbackWithAliveTargetReturningTrue_Reschedules()
        {
            int callCount = 0;
            object target = new object();
            Gen2GcCallback.Register(obj =>
            {
                callCount++;
                return true;
            }, target);
            ClearRegisteredCallbacks();

            ForceGc();
            ForceGc();
            ForceGc();

            Assert.True(callCount >= 2, $"Expected at least 2 invocations, got {callCount}");
            GC.KeepAlive(target);
        }

        [Fact]
        public void ObjectCallbackWithDeadTarget_FreesHandleWithoutCallback()
        {
            Boolean[] callbackCalled = { false };
            RegisterWithDeadTarget(callbackCalled);
            ClearRegisteredCallbacks();

            ForceGc();
            ForceGc();
            ForceGc();

            Assert.False(callbackCalled[0], "Callback should not execute when target is dead");
        }

        [Fact]
        public void StaticEvent_FiresAfterGCFinalization()
        {
            bool eventFired = false;
            Action original = Gen2GcCallback.Gen2CollectionOccured;

            try
            {
                Gen2GcCallback.Gen2CollectionOccured = () => { eventFired = true; };
                ClearRegisteredCallbacks();

                ForceGc();
                ForceGc();
                ForceGc();

                Assert.True(eventFired, "Static event should fire after GC finalization");
            }
            finally
            {
                Gen2GcCallback.Gen2CollectionOccured = original;
            }
        }

        [Fact]
        public void MultipleCallbacks_AllExecuteAfterFinalization()
        {
            int callCount1 = 0;
            int callCount2 = 0;

            Gen2GcCallback.Register(() =>
            {
                callCount1++;
                return false;
            });
            Gen2GcCallback.Register(() =>
            {
                callCount2++;
                return false;
            });
            ClearRegisteredCallbacks();

            ForceGc();

            Assert.Equal(1, callCount1);
            Assert.Equal(1, callCount2);
        }

        [Fact]
        public void RapidSuccessiveRegistrations_DoNotThrow()
        {
            Exception exception = Record.Exception(() =>
            {
                for (Int32 i = 0; i < 100; i++)
                {
                    Gen2GcCallback.Register(() => false);
                }
            });

            Assert.Null(exception);
        }

        private static void ForceGc()
        {
            GC.Collect(2, GCCollectionMode.Forced, blocking: true);
            GC.WaitForPendingFinalizers();
        }

        private static void RegisterWithDeadTarget(Boolean[] callbackCalled)
        {
            object target = new object();
            Gen2GcCallback.Register(obj =>
            {
                callbackCalled[0] = true;
                return false;
            }, target);
        }

        private static void ClearRegisteredCallbacks()
        {
            FieldInfo field = typeof(Gen2GcCallback).GetField(
                "_registeredCallbacks",
                BindingFlags.Static | BindingFlags.NonPublic);

            if (field?.GetValue(null) is List<Gen2GcCallback> list)
            {
                list.Clear();
            }
        }
    }
}
