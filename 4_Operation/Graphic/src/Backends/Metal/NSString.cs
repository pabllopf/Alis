using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The ns string
    /// </summary>
    public unsafe struct NSString
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="NSString"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public NSString(IntPtr ptr) => NativePtr = ptr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nss"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(NSString nss) => nss.NativePtr;

        /// <summary>
        /// News the s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The ns string</returns>
        public static NSString New(string s)
        {
            var nss = s_class.Alloc<NSString>();

            fixed (char* utf16Ptr = s)
            {
                UIntPtr length = (UIntPtr)s.Length;
                IntPtr newString = IntPtr_objc_msgSend(nss, sel_initWithCharacters, (IntPtr)utf16Ptr, length);
                return new NSString(newString);
            }
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        /// <returns>The string</returns>
        public string GetValue()
        {
            byte* utf8Ptr = bytePtr_objc_msgSend(NativePtr, sel_utf8String);
            return MTLUtil.GetUtf8String(utf8Ptr);
        }

        /// <summary>
        /// The ns string
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(NSString));
        /// <summary>
        /// The sel initwithcharacters
        /// </summary>
        private static readonly Selector sel_initWithCharacters = "initWithCharacters:length:";
        /// <summary>
        /// The sel utf8string
        /// </summary>
        private static readonly Selector sel_utf8String = "UTF8String";
    }
}