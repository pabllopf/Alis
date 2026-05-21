

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui payload
    /// </summary>
    public struct ImGuiPayload
    {
        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        ///     The data size
        /// </summary>
        public int DataSize { get; set; }

        /// <summary>
        ///     The source id
        /// </summary>
        public uint SourceId { get; set; }

        /// <summary>
        ///     The source parent id
        /// </summary>
        public uint SourceParentId { get; set; }

        /// <summary>
        ///     The data frame count
        /// </summary>
        public int DataFrameCount { get; set; }

        /// <summary>
        ///     The data type
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        private byte[] dataType;

        /// <summary>
        ///     Gets or sets the data type
        /// </summary>
        public byte[] DataType
        {
            get => dataType;
            set => dataType = value;
        }

        /// <summary>
        ///     The preview
        /// </summary>
        public byte Preview { get; set; }

        /// <summary>
        ///     The delivery
        /// </summary>
        public byte Delivery { get; set; }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear() => ImGuiNative.ImGuiPayload_Clear(ref this);

        /// <summary>
        ///     Describes whether this instance is data type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public bool IsDataType(string type) => ImGuiNative.ImGuiPayload_IsDataType(ref this, Encoding.UTF8.GetBytes(type)) != 0;

        /// <summary>
        ///     Describes whether this instance is delivery
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsDelivery() => ImGuiNative.ImGuiPayload_IsDelivery(ref this) != 0;

        /// <summary>
        ///     Describes whether this instance is preview
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsPreview() => ImGuiNative.ImGuiPayload_IsPreview(ref this) != 0;
    }
}