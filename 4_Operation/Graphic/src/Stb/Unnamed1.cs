using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The unnamed
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Unnamed1
    {
        /// <summary>
        ///     The id
        /// </summary>
        public int id;

        /// <summary>
        ///     The
        /// </summary>
        public int h;

        /// <summary>
        ///     The
        /// </summary>
        public int v;

        /// <summary>
        ///     The tq
        /// </summary>
        public int tq;

        /// <summary>
        ///     The hd
        /// </summary>
        public int hd;

        /// <summary>
        ///     The ha
        /// </summary>
        public int ha;

        /// <summary>
        ///     The dc pred
        /// </summary>
        public int dcpred;

        /// <summary>
        ///     The
        /// </summary>
        public int x;

        /// <summary>
        ///     The
        /// </summary>
        public int y;

        /// <summary>
        ///     The
        /// </summary>
        public int w2;

        /// <summary>
        ///     The
        /// </summary>
        public int h2;

        /// <summary>
        ///     The data
        /// </summary>
        public byte* data;

        /// <summary>
        ///     The raw data
        /// </summary>
        public void* rawdata;

        /// <summary>
        ///     The raw coeff
        /// </summary>
        public void* rawcoeff;

        /// <summary>
        ///     The linebuf
        /// </summary>
        public byte* linebuf;

        /// <summary>
        ///     The coeff
        /// </summary>
        public short* coeff;

        /// <summary>
        ///     The coeff
        /// </summary>
        public int coeffw;

        /// <summary>
        ///     The coeff
        /// </summary>
        public int coeffh;
    }
}