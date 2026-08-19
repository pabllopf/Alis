// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gen2GcCallbackRemainingCoverageTests.cs
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
    ///     The gen 2 gc callback remaining coverage tests class
    /// </summary>
    public class Gen2GcCallbackRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that finalizer with func bool false returns without reregister
        /// </summary>
        [Fact]
        public void Finalizer_WithFuncBoolFalse_ReturnsWithoutReregister()
        {
            RegisterUnreferencedFuncBool(false);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        ///     Tests that finalizer with func bool true reregisters
        /// </summary>
        [Fact]
        public void Finalizer_WithFuncBoolTrue_Reregisters()
        {
            RegisterUnreferencedFuncBool(true);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        ///     Tests that finalizer with func object bool false frees weak handle
        /// </summary>
        [Fact]
        public void Finalizer_WithFuncObjectBoolFalse_FreesWeakHandle()
        {
            RegisterUnreferencedFuncObjectBool(false);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        ///     Tests that finalizer with dead target returns without callback
        /// </summary>
        [Fact]
        public void Finalizer_WithDeadTarget_ReturnsWithoutCallback()
        {
            RegisterUnreferencedFuncObjectBoolWithDeadTarget();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        ///     Registers the unreferenced func bool
        /// </summary>
        /// <param name="result">The result</param>
        private static void RegisterUnreferencedFuncBool(bool result)
        {
            Gen2GcCallback.Register(() => result);
        }

        /// <summary>
        ///     Registers the unreferenced func object bool
        /// </summary>
        /// <param name="result">The result</param>
        private static void RegisterUnreferencedFuncObjectBool(bool result)
        {
            object target = new object();
            Gen2GcCallback.Register(_ => result, target);
        }

        /// <summary>
        ///     Registers the unreferenced func object bool with dead target
        /// </summary>
        private static void RegisterUnreferencedFuncObjectBoolWithDeadTarget()
        {
            object target = new object();
            Gen2GcCallback.Register(targetObj => targetObj != null, target);
            target = null;
        }
    }
}
