namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi png class
    /// </summary>
    public unsafe class Stbipng
    {
        /// <summary>
        ///     The depth
        /// </summary>
        public int Depth;

        /// <summary>
        ///     The expanded
        /// </summary>
        public byte* Expanded;

        /// <summary>
        ///     The idata
        /// </summary>
        public byte* Idata;

        /// <summary>
        ///     The @out
        /// </summary>
        public byte* @out;

        /// <summary>
        ///     The
        /// </summary>
        public Stbicontext S;
    }
}