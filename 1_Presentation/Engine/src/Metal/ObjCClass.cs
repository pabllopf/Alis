using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The obj
    /// </summary>
    public unsafe struct ObjCClass
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(ObjCClass c) => c.NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjCClass"/> class
        /// </summary>
        /// <param name="name">The name</param>
        public ObjCClass(string name)
        {
            int byteCount = Encoding.UTF8.GetMaxByteCount(name.Length);
            byte* utf8BytesPtr = stackalloc byte[byteCount];
            fixed (char* namePtr = name)
            {
                Encoding.UTF8.GetBytes(namePtr, name.Length, utf8BytesPtr, byteCount);
            }

            NativePtr = ObjectiveCRuntime.objc_getClass(utf8BytesPtr);
        }

        /// <summary>
        /// Gets the property using the specified property name
        /// </summary>
        /// <param name="propertyName">The property name</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetProperty(string propertyName)
        {
            int byteCount = Encoding.UTF8.GetMaxByteCount(propertyName.Length);
            byte* utf8BytesPtr = stackalloc byte[byteCount];
            fixed (char* namePtr = propertyName)
            {
                Encoding.UTF8.GetBytes(namePtr, propertyName.Length, utf8BytesPtr, byteCount);
            }

            return ObjectiveCRuntime.class_getProperty(this, utf8BytesPtr);
        }

        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public string Name => MTLUtil.GetUtf8String(ObjectiveCRuntime.class_getName(this));

        /// <summary>
        /// Allocs this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Alloc<T>() where T : struct
        {
            IntPtr value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.alloc);
            return Unsafe.AsRef<T>(&value);
        }

        /// <summary>
        /// Allocs the init
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T AllocInit<T>() where T : struct
        {
            IntPtr value = ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, Selectors.alloc);
            ObjectiveCRuntime.objc_msgSend(value, Selectors.init);
            return Unsafe.AsRef<T>(&value);
        }

        /// <summary>
        /// Classes the copy method list using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <returns>The objective method</returns>
        public ObjectiveCMethod* class_copyMethodList(out uint count)
        {
            return ObjectiveCRuntime.class_copyMethodList(this, out count);
        }
    }
}