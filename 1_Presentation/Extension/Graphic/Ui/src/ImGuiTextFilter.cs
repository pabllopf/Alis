

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui text filter
    /// </summary>
    public struct ImGuiTextFilter
    {
        /// <summary>
        ///     The input buf
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        private byte[] inputBuf;

        /// <summary>
        ///     Gets or sets the input buf
        /// </summary>
        public byte[] InputBuf
        {
            get => inputBuf;
            set => inputBuf = value;
        }

        /// <summary>
        ///     Gets or sets the filters
        /// </summary>
        public ImVector Filters { get; set; }

        /// <summary>
        ///     Gets or sets the count grep
        /// </summary>
        public int CountGrep { get; set; }
    }
}