using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl library
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLLibrary
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLLibrary"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLLibrary(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// News the function with name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The mtl function</returns>
        public MTLFunction newFunctionWithName(string name)
        {
            NSString nameNSS = NSString.New(name);
            IntPtr function = IntPtr_objc_msgSend(NativePtr, sel_newFunctionWithName, nameNSS);
            release(nameNSS.NativePtr);
            return new MTLFunction(function);
        }

        /// <summary>
        /// News the function with name constant values using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="constantValues">The constant values</param>
        /// <exception cref="Exception">Failed to create MTLFunction: {error.localizedDescription}</exception>
        /// <returns>The mtl function</returns>
        public MTLFunction newFunctionWithNameConstantValues(string name, MTLFunctionConstantValues constantValues)
        {
            NSString nameNSS = NSString.New(name);
            IntPtr function = IntPtr_objc_msgSend(
                NativePtr,
                sel_newFunctionWithNameConstantValues,
                nameNSS.NativePtr,
                constantValues.NativePtr,
                out NSError error);
            release(nameNSS.NativePtr);

            if (function == IntPtr.Zero)
            {
                throw new Exception($"Failed to create MTLFunction: {error.localizedDescription}");
            }

            return new MTLFunction(function);
        }

        /// <summary>
        /// The sel newfunctionwithname
        /// </summary>
        private static readonly Selector sel_newFunctionWithName = "newFunctionWithName:";
        /// <summary>
        /// The sel newfunctionwithnameconstantvalues
        /// </summary>
        private static readonly Selector sel_newFunctionWithNameConstantValues = "newFunctionWithName:constantValues:error:";
    }
}