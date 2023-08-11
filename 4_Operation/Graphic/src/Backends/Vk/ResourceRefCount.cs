using System;
using System.Threading;

namespace Veldrid.Vk
{
    /// <summary>
    /// The resource ref count class
    /// </summary>
    internal class ResourceRefCount
    {
        /// <summary>
        /// The dispose action
        /// </summary>
        private readonly Action _disposeAction;
        /// <summary>
        /// The ref count
        /// </summary>
        private int _refCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceRefCount"/> class
        /// </summary>
        /// <param name="disposeAction">The dispose action</param>
        public ResourceRefCount(Action disposeAction)
        {
            _disposeAction = disposeAction;
            _refCount = 1;
        }

        /// <summary>
        /// Increments this instance
        /// </summary>
        /// <returns>The ret</returns>
        public int Increment()
        {
            int ret = Interlocked.Increment(ref _refCount);
#if VALIDATE_USAGE
            if (ret == 0)
            {
                throw new VeldridException("An attempt was made to reference a disposed resource.");
            }
#endif
            return ret;
        }

        /// <summary>
        /// Decrements this instance
        /// </summary>
        /// <returns>The ret</returns>
        public int Decrement()
        {
            int ret = Interlocked.Decrement(ref _refCount);
            if (ret == 0)
            {
                _disposeAction();
            }

            return ret;
        }
    }
}
