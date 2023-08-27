using System;
using System.Text;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui payload ptr
    /// </summary>
    public unsafe struct ImGuiPayloadPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiPayload* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPayloadPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPayloadPtr(ImGuiPayload* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPayloadPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPayloadPtr(IntPtr nativePtr) => NativePtr = (ImGuiPayload*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPayloadPtr(ImGuiPayload* nativePtr) => new ImGuiPayloadPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPayload* (ImGuiPayloadPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPayloadPtr(IntPtr nativePtr) => new ImGuiPayloadPtr(nativePtr);
        
        /// <summary>
        /// Gets or sets the value of the data
        /// </summary>
        public IntPtr Data { get => (IntPtr)NativePtr->Data; set => NativePtr->Data = (void*)value; }
        /// <summary>
        /// Gets the value of the data size
        /// </summary>
        public ref int DataSize => ref Unsafe.AsRef<int>(&NativePtr->DataSize);
        /// <summary>
        /// Gets the value of the source id
        /// </summary>
        public ref uint SourceId => ref Unsafe.AsRef<uint>(&NativePtr->SourceId);
        /// <summary>
        /// Gets the value of the source parent id
        /// </summary>
        public ref uint SourceParentId => ref Unsafe.AsRef<uint>(&NativePtr->SourceParentId);
        /// <summary>
        /// Gets the value of the data frame count
        /// </summary>
        public ref int DataFrameCount => ref Unsafe.AsRef<int>(&NativePtr->DataFrameCount);
        /// <summary>
        /// Gets the value of the data type
        /// </summary>
        public RangeAccessor<byte> DataType => new RangeAccessor<byte>(NativePtr->DataType, 33);
        /// <summary>
        /// Gets the value of the preview
        /// </summary>
        public ref bool Preview => ref Unsafe.AsRef<bool>(&NativePtr->Preview);
        /// <summary>
        /// Gets the value of the delivery
        /// </summary>
        public ref bool Delivery => ref Unsafe.AsRef<bool>(&NativePtr->Delivery);
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImGuiPayload_Clear((ImGuiPayload*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPayload_destroy((ImGuiPayload*)(NativePtr));
        }
        /// <summary>
        /// Describes whether this instance is data type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public bool IsDataType(string type)
        {
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }
                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else { nativeType = null; }
            byte ret = ImGuiNative.ImGuiPayload_IsDataType((ImGuiPayload*)(NativePtr), nativeType);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }
            return ret != 0;
        }
        /// <summary>
        /// Describes whether this instance is delivery
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsDelivery()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsDelivery((ImGuiPayload*)(NativePtr));
            return ret != 0;
        }
        /// <summary>
        /// Describes whether this instance is preview
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsPreview()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsPreview((ImGuiPayload*)(NativePtr));
            return ret != 0;
        }
    }
}