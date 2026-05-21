

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The null terminated string
    /// </summary>
    public readonly struct NullTerminatedString
    {
        /// <summary>
        ///     The data
        /// </summary>
        public readonly IntPtr Data;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NullTerminatedString" /> class
        /// </summary>
        /// <param name="data">The data</param>
        public NullTerminatedString(IntPtr data) => Data = data;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NullTerminatedString" /> class
        /// </summary>
        /// <param name="data">The data</param>
        public NullTerminatedString(byte[] data)
        {
            Data = Marshal.AllocHGlobal(data.Length + 1);
            Marshal.Copy(data, 0, Data, data.Length);
            Marshal.WriteByte(Data + data.Length, 0);
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            if (Data == IntPtr.Zero)
            {
                return string.Empty;
            }

            int length = 0;
            while (Marshal.ReadByte(Data, length) != 0)
            {
                length++;
            }

            if (length == 0)
            {
                return string.Empty;
            }

            byte[] buffer = new byte[length];
            Marshal.Copy(Data, buffer, 0, length);
            return Encoding.UTF8.GetString(buffer);
        }

        /// <summary>
        /// </summary>
        /// <param name="nts"></param>
        /// <returns></returns>
        public static implicit operator string(NullTerminatedString nts) => nts.ToString();
    }
}