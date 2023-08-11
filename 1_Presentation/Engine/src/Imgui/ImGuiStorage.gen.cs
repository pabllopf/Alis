using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui storage
    /// </summary>
    public unsafe partial struct ImGuiStorage
    {
        /// <summary>
        /// The data
        /// </summary>
        public ImVector Data;
    }
    /// <summary>
    /// The im gui storage ptr
    /// </summary>
    public unsafe partial struct ImGuiStoragePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiStorage* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStoragePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePtr(ImGuiStorage* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiStoragePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePtr(IntPtr nativePtr) => NativePtr = (ImGuiStorage*)nativePtr;
        public static implicit operator ImGuiStoragePtr(ImGuiStorage* nativePtr) => new ImGuiStoragePtr(nativePtr);
        public static implicit operator ImGuiStorage* (ImGuiStoragePtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiStoragePtr(IntPtr nativePtr) => new ImGuiStoragePtr(nativePtr);
        /// <summary>
        /// Gets the value of the data
        /// </summary>
        public ImPtrVector<ImGuiStoragePairPtr> Data => new ImPtrVector<ImGuiStoragePairPtr>(NativePtr->Data, Unsafe.SizeOf<ImGuiStoragePair>());
        /// <summary>
        /// Builds the sort by key
        /// </summary>
        public void BuildSortByKey()
        {
            ImGuiNative.ImGuiStorage_BuildSortByKey((ImGuiStorage*)(NativePtr));
        }
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImGuiStorage_Clear((ImGuiStorage*)(NativePtr));
        }
        /// <summary>
        /// Describes whether this instance get bool
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public bool GetBool(uint key)
        {
            byte default_val = 0;
            byte ret = ImGuiNative.ImGuiStorage_GetBool((ImGuiStorage*)(NativePtr), key, default_val);
            return ret != 0;
        }
        /// <summary>
        /// Describes whether this instance get bool
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The bool</returns>
        public bool GetBool(uint key, bool default_val)
        {
            byte native_default_val = default_val ? (byte)1 : (byte)0;
            byte ret = ImGuiNative.ImGuiStorage_GetBool((ImGuiStorage*)(NativePtr), key, native_default_val);
            return ret != 0;
        }
        /// <summary>
        /// Gets the bool ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public byte* GetBoolRef(uint key)
        {
            byte default_val = 0;
            byte* ret = ImGuiNative.ImGuiStorage_GetBoolRef((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the bool ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The ret</returns>
        public byte* GetBoolRef(uint key, bool default_val)
        {
            byte native_default_val = default_val ? (byte)1 : (byte)0;
            byte* ret = ImGuiNative.ImGuiStorage_GetBoolRef((ImGuiStorage*)(NativePtr), key, native_default_val);
            return ret;
        }
        /// <summary>
        /// Gets the float using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public float GetFloat(uint key)
        {
            float default_val = 0.0f;
            float ret = ImGuiNative.ImGuiStorage_GetFloat((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the float using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The ret</returns>
        public float GetFloat(uint key, float default_val)
        {
            float ret = ImGuiNative.ImGuiStorage_GetFloat((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the float ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public float* GetFloatRef(uint key)
        {
            float default_val = 0.0f;
            float* ret = ImGuiNative.ImGuiStorage_GetFloatRef((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the float ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The ret</returns>
        public float* GetFloatRef(uint key, float default_val)
        {
            float* ret = ImGuiNative.ImGuiStorage_GetFloatRef((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the int using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public int GetInt(uint key)
        {
            int default_val = 0;
            int ret = ImGuiNative.ImGuiStorage_GetInt((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the int using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The ret</returns>
        public int GetInt(uint key, int default_val)
        {
            int ret = ImGuiNative.ImGuiStorage_GetInt((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the int ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public int* GetIntRef(uint key)
        {
            int default_val = 0;
            int* ret = ImGuiNative.ImGuiStorage_GetIntRef((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the int ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The ret</returns>
        public int* GetIntRef(uint key, int default_val)
        {
            int* ret = ImGuiNative.ImGuiStorage_GetIntRef((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the void ptr using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetVoidPtr(uint key)
        {
            void* ret = ImGuiNative.ImGuiStorage_GetVoidPtr((ImGuiStorage*)(NativePtr), key);
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the void ptr ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public void** GetVoidPtrRef(uint key)
        {
            void* default_val = null;
            void** ret = ImGuiNative.ImGuiStorage_GetVoidPtrRef((ImGuiStorage*)(NativePtr), key, default_val);
            return ret;
        }
        /// <summary>
        /// Gets the void ptr ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default_val">The default val</param>
        /// <returns>The ret</returns>
        public void** GetVoidPtrRef(uint key, IntPtr default_val)
        {
            void* native_default_val = (void*)default_val.ToPointer();
            void** ret = ImGuiNative.ImGuiStorage_GetVoidPtrRef((ImGuiStorage*)(NativePtr), key, native_default_val);
            return ret;
        }
        /// <summary>
        /// Sets the all int using the specified val
        /// </summary>
        /// <param name="val">The val</param>
        public void SetAllInt(int val)
        {
            ImGuiNative.ImGuiStorage_SetAllInt((ImGuiStorage*)(NativePtr), val);
        }
        /// <summary>
        /// Sets the bool using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetBool(uint key, bool val)
        {
            byte native_val = val ? (byte)1 : (byte)0;
            ImGuiNative.ImGuiStorage_SetBool((ImGuiStorage*)(NativePtr), key, native_val);
        }
        /// <summary>
        /// Sets the float using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetFloat(uint key, float val)
        {
            ImGuiNative.ImGuiStorage_SetFloat((ImGuiStorage*)(NativePtr), key, val);
        }
        /// <summary>
        /// Sets the int using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetInt(uint key, int val)
        {
            ImGuiNative.ImGuiStorage_SetInt((ImGuiStorage*)(NativePtr), key, val);
        }
        /// <summary>
        /// Sets the void ptr using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetVoidPtr(uint key, IntPtr val)
        {
            void* native_val = (void*)val.ToPointer();
            ImGuiNative.ImGuiStorage_SetVoidPtr((ImGuiStorage*)(NativePtr), key, native_val);
        }
    }
}
