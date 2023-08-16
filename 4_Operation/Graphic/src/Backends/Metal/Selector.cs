using System;
using System.Text;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The selector
    /// </summary>
    public unsafe struct Selector
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public Selector(IntPtr ptr)
        {
            NativePtr = ptr;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class
        /// </summary>
        /// <param name="name">The name</param>
        public Selector(string name)
        {
            int byteCount = Encoding.UTF8.GetMaxByteCount(name.Length);
            byte* utf8BytesPtr = stackalloc byte[byteCount];
            fixed (char* namePtr = name)
            {
                Encoding.UTF8.GetBytes(namePtr, name.Length, utf8BytesPtr, byteCount);
            }

            NativePtr = ObjectiveCRuntime.sel_registerName(utf8BytesPtr);
        }

        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public string Name
        {
            get
            {
                byte* name = ObjectiveCRuntime.sel_getName(NativePtr);
                return MTLUtil.GetUtf8String(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static implicit operator Selector(string s) => new Selector(s);
    }
}