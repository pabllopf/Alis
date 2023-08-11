using System;
using System.Runtime.InteropServices;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The dispatch class
    /// </summary>
    public static unsafe class Dispatch
    {
        /// <summary>
        /// The libdispatch location
        /// </summary>
        private const string LibdispatchLocation = @"/usr/lib/system/libdispatch.dylib";

        /// <summary>
        /// Dispatches the get global queue using the specified identifier
        /// </summary>
        /// <param name="identifier">The identifier</param>
        /// <param name="flags">The flags</param>
        /// <returns>The dispatch queue</returns>
        [DllImport(LibdispatchLocation)]
        public static extern DispatchQueue dispatch_get_global_queue(QualityOfServiceLevel identifier, ulong flags);

        /// <summary>
        /// Dispatches the data create using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="size">The size</param>
        /// <param name="queue">The queue</param>
        /// <param name="destructorBlock">The destructor block</param>
        /// <returns>The dispatch data</returns>
        [DllImport(LibdispatchLocation)]
        public static extern DispatchData dispatch_data_create(
            void* buffer,
            UIntPtr size,
            DispatchQueue queue,
            IntPtr destructorBlock);

        /// <summary>
        /// Dispatches the release using the specified native ptr
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        [DllImport(LibdispatchLocation)]
        public static extern void dispatch_release(IntPtr nativePtr);
    }

    /// <summary>
    /// The quality of service level enum
    /// </summary>
    public enum QualityOfServiceLevel : long
    {
        /// <summary>
        /// The qos class user interactive quality of service level
        /// </summary>
        QOS_CLASS_USER_INTERACTIVE = 0x21,
        /// <summary>
        /// The qos class user initiated quality of service level
        /// </summary>
        QOS_CLASS_USER_INITIATED = 0x19,
        /// <summary>
        /// The qos class default quality of service level
        /// </summary>
        QOS_CLASS_DEFAULT = 0x15,
        /// <summary>
        /// The qos class utility quality of service level
        /// </summary>
        QOS_CLASS_UTILITY = 0x11,
        /// <summary>
        /// The qos class background quality of service level
        /// </summary>
        QOS_CLASS_BACKGROUND = 0x9,
        /// <summary>
        /// The qos class unspecified quality of service level
        /// </summary>
        QOS_CLASS_UNSPECIFIED = 0,
    }

    /// <summary>
    /// The dispatch queue
    /// </summary>
    public struct DispatchQueue
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
    }

    /// <summary>
    /// The dispatch data
    /// </summary>
    public struct DispatchData
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
    }
}