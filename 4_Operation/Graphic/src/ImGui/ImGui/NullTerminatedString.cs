using System.Text;

namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The null terminated string
    /// </summary>
    public unsafe struct NullTerminatedString
    {
        /// <summary>
        /// The data
        /// </summary>
        public readonly byte* Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullTerminatedString"/> class
        /// </summary>
        /// <param name="data">The data</param>
        public NullTerminatedString(byte* data)
        {
            Data = data;
        }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            int length = 0;
            byte* ptr = Data;
            while (*ptr != 0)
            {
                length += 1;
                ptr += 1;
            }

            return Encoding.ASCII.GetString(Data, length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nts"></param>
        /// <returns></returns>
        public static implicit operator string(NullTerminatedString nts) => nts.ToString();
    }
}
