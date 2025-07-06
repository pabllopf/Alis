using System;
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
        public static Action Gen2CollectionOccured;

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
        private Gen2GcCallback(Func<bool> callback)
        {
            _callback0 = callback;
        }

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
            // Create a unreachable object that remembers the callback function and target object.
            Gen2GcCallback gcCallback = new Gen2GcCallback(callback);
        }

        /// <summary>
        ///     Schedule 'callback' to be called in the next GC.  If the callback returns true it is
        ///     rescheduled for the next Gen 2 GC.  Otherwise the callbacks stop.
        ///     NOTE: This callback will be kept alive until either the callback function returns false,
        ///     or the target object dies.
        /// </summary>
        public static void Register(Func<object, bool> callback, object targetObj)
        {
            // Create a unreachable object that remembers the callback function and target object.
            Gen2GcCallback gcCallback = new Gen2GcCallback(callback, targetObj);
        }

        ~Gen2GcCallback()
        {
            if (_weakTargetObj.IsAllocated)
            {
                // Check to see if the target object is still alive.
                object targetObj = _weakTargetObj.Target;
                if (targetObj == null)
                {
                    // The target object is dead, so this callback object is no longer needed.
                    _weakTargetObj.Free();
                    return;
                }

                // Execute the callback method.
                try
                {
                    if (!_callback1(targetObj))
                    {
                        // If the callback returns false, this callback object is no longer needed.
                        _weakTargetObj.Free();
                        return;
                    }
                }
                catch
                {
                    // Ensure that we still get a chance to resurrect this object, even if the callback throws an exception.
#if DEBUG
                // Except in DEBUG, as we really shouldn't be hitting any exceptions here.
                throw;
#endif
                }
            }
            else
            {
                // Execute the callback method.
                try
                {
                    if (!_callback0())
                        // If the callback returns false, this callback object is no longer needed.
                        return;
                }
                catch
                {
                    // Ensure that we still get a chance to resurrect this object, even if the callback throws an exception.
#if DEBUG
                // Except in DEBUG, as we really shouldn't be hitting any exceptions here.
                throw;
#endif
                }
            }

            // Resurrect ourselves by re-registering for finalization.
            GC.ReRegisterForFinalize(this);
        }
    }
}