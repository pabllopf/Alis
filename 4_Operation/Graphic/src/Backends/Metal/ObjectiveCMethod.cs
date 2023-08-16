using System;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The objective method
    /// </summary>
    public struct ObjectiveCMethod
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveCMethod"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public ObjectiveCMethod(IntPtr ptr) => NativePtr = ptr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ObjectiveCMethod method) => method.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static implicit operator ObjectiveCMethod(IntPtr ptr) => new ObjectiveCMethod(ptr);

        /// <summary>
        /// Gets the selector
        /// </summary>
        /// <returns>The selector</returns>
        public Selector GetSelector() => ObjectiveCRuntime.method_getName(this);
        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>The string</returns>
        public string GetName() => GetSelector().Name;
    }
}