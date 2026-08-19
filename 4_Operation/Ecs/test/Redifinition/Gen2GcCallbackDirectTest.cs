// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gen2GcCallbackDirectTest.cs
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
using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     Tests the <see cref="Gen2GcCallback" /> Register methods without relying on GC finalization.
    /// </summary>
    public class Gen2GcCallbackDirectTest
    {
        /// <summary>
        /// Tests that register func bool does not throw
        /// </summary>
        [Fact]
        public void Register_FuncBool_DoesNotThrow()
        {
            bool called = false;
            Gen2GcCallback.Register(() =>
            {
                called = true;
                return true;
            });
        }

        /// <summary>
        /// Tests that register func bool callback with false does not throw
        /// </summary>
        [Fact]
        public void Register_FuncBoolCallback_WithFalse_DoesNotThrow()
        {
            Gen2GcCallback.Register(() => false);
        }

        /// <summary>
        /// Tests that register func object bool does not throw
        /// </summary>
        [Fact]
        public void Register_FuncObjectBool_DoesNotThrow()
        {
            object target = new object();
            bool called = false;
            Gen2GcCallback.Register((_) =>
            {
                called = true;
                return true;
            }, target);
        }

        /// <summary>
        /// Tests that register func object bool with null target does not throw
        /// </summary>
        [Fact]
        public void Register_FuncObjectBool_WithNullTarget_DoesNotThrow()
        {
            Gen2GcCallback.Register((_) => true, null);
        }

        /// <summary>
        /// Tests that register func object bool with false does not throw
        /// </summary>
        [Fact]
        public void Register_FuncObjectBool_WithFalse_DoesNotThrow()
        {
            object target = new object();
            Gen2GcCallback.Register((_) => false, target);
        }

        /// <summary>
        /// Tests that gen 2 collection occured can be subscribed
        /// </summary>
        [Fact]
        public void Gen2CollectionOccured_CanBeSubscribed()
        {
            bool invoked = false;
            Gen2GcCallback.Gen2CollectionOccured += () => invoked = true;
            Gen2GcCallback.Gen2CollectionOccured?.Invoke();
            Assert.True(invoked);
            Gen2GcCallback.Gen2CollectionOccured -= () => invoked = true;
        }

        /// <summary>
        /// Tests that register multiple callbacks does not throw
        /// </summary>
        [Fact]
        public void Register_MultipleCallbacks_DoesNotThrow()
        {
            for (int i = 0; i < 10; i++)
            {
                int captured = i;
                Gen2GcCallback.Register(() => captured >= 0);
            }
        }

        /// <summary>
        /// Tests that register multiple object callbacks does not throw
        /// </summary>
        [Fact]
        public void Register_MultipleObjectCallbacks_DoesNotThrow()
        {
            for (int i = 0; i < 10; i++)
            {
                object target = new object();
                Gen2GcCallback.Register((obj) => obj != null, target);
            }
        }

        /// <summary>
        /// Tests that register null func bool does not throw at registration
        /// </summary>
        [Fact]
        public void Register_NullFuncBool_DoesNotThrowAtRegistration()
        {
            Gen2GcCallback.Register((Func<bool>)null);
        }

        /// <summary>
        /// Tests that register null func object bool does not throw at registration
        /// </summary>
        [Fact]
        public void Register_NullFuncObjectBool_DoesNotThrowAtRegistration()
        {
            object target = new object();
            Gen2GcCallback.Register((Func<object, bool>)null, target);
        }

        /// <summary>
        /// Tests that gen 2 collection occured invoke when null does not throw
        /// </summary>
        [Fact]
        public void Gen2CollectionOccured_InvokeWhenNull_DoesNotThrow()
        {
            Action saved = Gen2GcCallback.Gen2CollectionOccured;
            try
            {
                Gen2GcCallback.Gen2CollectionOccured = null;
                Gen2GcCallback.Gen2CollectionOccured?.Invoke();
            }
            finally
            {
                Gen2GcCallback.Gen2CollectionOccured = saved;
            }
        }

        /// <summary>
        /// Tests that register with callback returning true does not throw
        /// </summary>
        [Fact]
        public void Register_WithCallbackReturningTrue_DoesNotThrow()
        {
            Gen2GcCallback.Register(() => true);
        }

        /// <summary>
        /// Tests that register with object callback returning true does not throw
        /// </summary>
        [Fact]
        public void Register_WithObjectCallbackReturningTrue_DoesNotThrow()
        {
            object target = new object();
            Gen2GcCallback.Register(_ => true, target);
        }
    }
}
