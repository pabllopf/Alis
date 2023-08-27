using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui payload
    /// </summary>
    public unsafe struct ImGuiPayload
    {
        /// <summary>
        /// The data
        /// </summary>
        public void* Data;
        /// <summary>
        /// The data size
        /// </summary>
        public int DataSize;
        /// <summary>
        /// The source id
        /// </summary>
        public uint SourceId;
        /// <summary>
        /// The source parent id
        /// </summary>
        public uint SourceParentId;
        /// <summary>
        /// The data frame count
        /// </summary>
        public int DataFrameCount;
        /// <summary>
        /// The data type
        /// </summary>
        public fixed byte DataType[33];
        /// <summary>
        /// The preview
        /// </summary>
        public byte Preview;
        /// <summary>
        /// The delivery
        /// </summary>
        public byte Delivery;
    }
}
