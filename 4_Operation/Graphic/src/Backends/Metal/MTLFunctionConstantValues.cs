using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl function constant values
    /// </summary>
    public struct MTLFunctionConstantValues
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// News
        /// </summary>
        /// <returns>The mtl function constant values</returns>
        public static MTLFunctionConstantValues New()
        {
            return s_class.AllocInit<MTLFunctionConstantValues>();
        }

        /// <summary>
        /// Sets the constant valuetypeat index using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="type">The type</param>
        /// <param name="index">The index</param>
        public unsafe void setConstantValuetypeatIndex(void* value, MTLDataType type, UIntPtr index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setConstantValuetypeatIndex, value, (uint)type, index);
        }

        /// <summary>
        /// The mtl function constant values
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(MTLFunctionConstantValues));
        /// <summary>
        /// The sel setconstantvaluetypeatindex
        /// </summary>
        private static readonly Selector sel_setConstantValuetypeatIndex = "setConstantValue:type:atIndex:";
    }
}
