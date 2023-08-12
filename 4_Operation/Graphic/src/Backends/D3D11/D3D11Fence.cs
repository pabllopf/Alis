using System;
using System.Threading;

namespace Alis.Core.Graphic.Backends.D3D11
{
    /// <summary>
    /// The 11 fence class
    /// </summary>
    /// <seealso cref="Fence"/>
    internal class D3D11Fence : Fence
    {
        /// <summary>
        /// The mre
        /// </summary>
        private readonly ManualResetEvent _mre;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Fence"/> class
        /// </summary>
        /// <param name="signaled">The signaled</param>
        public D3D11Fence(bool signaled)
        {
            _mre = new ManualResetEvent(signaled);
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Gets the value of the reset event
        /// </summary>
        public ManualResetEvent ResetEvent => _mre;

        /// <summary>
        /// Sets this instance
        /// </summary>
        public void Set() => _mre.Set();
        /// <summary>
        /// Resets this instance
        /// </summary>
        public override void Reset() => _mre.Reset();
        /// <summary>
        /// Gets the value of the signaled
        /// </summary>
        public override bool Signaled => _mre.WaitOne(0);
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _mre.Dispose();
                _disposed = true;
            }
        }

        /// <summary>
        /// Describes whether this instance wait
        /// </summary>
        /// <param name="nanosecondTimeout">The nanosecond timeout</param>
        /// <returns>The bool</returns>
        internal bool Wait(ulong nanosecondTimeout)
        {
            ulong timeout = Math.Min(int.MaxValue, nanosecondTimeout / 1_000_000);
            return _mre.WaitOne((int)timeout);
        }
    }
}