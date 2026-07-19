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

        [Fact]
        public void Register_FuncBoolCallback_WithFalse_DoesNotThrow()
        {
            Gen2GcCallback.Register(() => false);
        }

        [Fact]
        public void Register_FuncObjectBool_DoesNotThrow()
        {
            object target = new object();
            bool called = false;
            Gen2GcCallback.Register((obj) =>
            {
                called = true;
                return true;
            }, target);
        }

        [Fact]
        public void Register_FuncObjectBool_WithNullTarget_DoesNotThrow()
        {
            Gen2GcCallback.Register((obj) => true, null);
        }

        [Fact]
        public void Register_FuncObjectBool_WithFalse_DoesNotThrow()
        {
            object target = new object();
            Gen2GcCallback.Register((obj) => false, target);
        }

        [Fact]
        public void Gen2CollectionOccured_CanBeSubscribed()
        {
            bool invoked = false;
            Gen2GcCallback.Gen2CollectionOccured += () => invoked = true;
            Gen2GcCallback.Gen2CollectionOccured?.Invoke();
            Assert.True(invoked);
            Gen2GcCallback.Gen2CollectionOccured -= () => invoked = true;
        }

        [Fact]
        public void Register_MultipleCallbacks_DoesNotThrow()
        {
            for (int i = 0; i < 10; i++)
            {
                int captured = i;
                Gen2GcCallback.Register(() => captured >= 0);
            }
        }

        [Fact]
        public void Register_MultipleObjectCallbacks_DoesNotThrow()
        {
            for (int i = 0; i < 10; i++)
            {
                object target = new object();
                Gen2GcCallback.Register((obj) => obj != null, target);
            }
        }
    }
}
