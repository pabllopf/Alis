// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gen2GcCallback.cs
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
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Redifinition
{
    /// <summary>
    ///     Schedules a callback roughly every gen 2 GC (you may see a Gen 0 an Gen 1 but only once)
    ///     (We can fix this by capturing the Gen 2 count at startup and testing, but I mostly don't care)
    /// </summary>
    public sealed class Gen2GcCallback : CriticalFinalizerObject
    {
        /// <summary>
        ///     The gen collection occured
        /// </summary>
        public static Action Gen2CollectionOccured { get; set; }

        /// <summary>
        ///     The callback
        /// </summary>
        private readonly Func<bool> _callback0;

        /// <summary>
        ///     The callback
        /// </summary>
        private readonly Func<object, bool> _callback1;

        /// <summary>
        ///     The weak target obj
        /// </summary>
        private GCHandle _weakTargetObj;

        /// <summary>
        ///     Static list to keep references alive until finalizer runs
        /// </summary>
        private static readonly List<Gen2GcCallback> _registeredCallbacks = new();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Gen2GcCallback" /> class
        /// </summary>
        static Gen2GcCallback()
        {
            Register(() =>
            {
                Gen2CollectionOccured?.Invoke();
                return true;
            });
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Gen2GcCallback" /> class
        /// </summary>
        /// <param name="callback">The callback</param>
        private Gen2GcCallback(Func<bool> callback) => _callback0 = callback;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Gen2GcCallback" /> class
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="targetObj">The target obj</param>
        private Gen2GcCallback(Func<object, bool> callback, object targetObj)
        {
            _callback1 = callback;
            _weakTargetObj = GCHandle.Alloc(targetObj, GCHandleType.Weak);
        }

        /// <summary>
        ///     Schedule 'callback' to be called in the next GC.  If the callback returns true it is
        ///     rescheduled for the next Gen 2 GC.  Otherwise the callbacks stop.
        /// </summary>
        public static void Register(Func<bool> callback)
        {
            Gen2GcCallback instance = new Gen2GcCallback(callback);
            _registeredCallbacks.Add(instance);
        }

        /// <summary>
        ///     Schedule 'callback' to be called in the next GC.  If the callback returns true it is
        ///     rescheduled for the next Gen 2 GC.  Otherwise the callbacks stop.
        ///     NOTE: This callback will be kept alive until either the callback function returns false,
        ///     or the target object dies.
        /// </summary>
        public static void Register(Func<object, bool> callback, object targetObj)
        {
            Gen2GcCallback instance = new Gen2GcCallback(callback, targetObj);
            _registeredCallbacks.Add(instance);
        }

        /// <summary>
        /// </summary>
        ~Gen2GcCallback()
        {
            _registeredCallbacks.Remove(this);

            if (_weakTargetObj.IsAllocated)
            {
                object targetObj = _weakTargetObj.Target;
                if (targetObj == null)
                {
                    _weakTargetObj.Free();
                    return;
                }

                if (!_callback1(targetObj))
                {
                    _weakTargetObj.Free();
                    return;
                }
            }
            else
            {
                if (!_callback0())
                {
                    return;
                }
            }

            GC.ReRegisterForFinalize(this);
        }
    }
}