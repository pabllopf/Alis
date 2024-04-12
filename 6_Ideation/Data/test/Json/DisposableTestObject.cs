using System;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The disposable test object class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class DisposableTestObject : IDisposable
    {
        /// <summary>
        /// Gets or sets the value of the is disposed
        /// </summary>
        public bool IsDisposed { get; private set; }
        
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}