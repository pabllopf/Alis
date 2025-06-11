using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi jpeg class
    /// </summary>
    public class Stbijpeg
    {
        /// <summary>
        ///     The app14 color transform
        /// </summary>
        public int App14Colortransform;

        /// <summary>
        ///     The code bits
        /// </summary>
        public int Codebits;

        /// <summary>
        ///     The code buffer
        /// </summary>
        public uint Codebuffer;

        /// <summary>
        ///     The create array
        /// </summary>
        public ushort[][] Dequant = Utility.CreateArray<ushort>(4, 64);

        /// <summary>
        ///     The eob run
        /// </summary>
        public int Eobrun;

        /// <summary>
        ///     The create array
        /// </summary>
        public short[][] Fastac = Utility.CreateArray<short>(4, 512);

        /// <summary>
        ///     The stbi huffman
        /// </summary>
        public Stbihuffman[] Huffac = new Stbihuffman[4];

        /// <summary>
        ///     The stbi huffman
        /// </summary>
        public Stbihuffman[] Huffdc = new Stbihuffman[4];

        /// <summary>
        ///     The idct block kernel
        /// </summary>
        public Delegate0 Idctblockkernel;

        /// <summary>
        ///     The unnamed
        /// </summary>
        public Unnamed1[] Imgcomp = new Unnamed1[4];

        /// <summary>
        ///     The img max
        /// </summary>
        public int Imghmax;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int Imgmcuh;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int Imgmcuw;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int Imgmcux;

        /// <summary>
        ///     The img mcu
        /// </summary>
        public int Imgmcuy;

        /// <summary>
        ///     The img max
        /// </summary>
        public int Imgvmax;

        /// <summary>
        ///     The jfif
        /// </summary>
        public int Jfif;

        /// <summary>
        ///     The marker
        /// </summary>
        public byte Marker;

        /// <summary>
        ///     The nomore
        /// </summary>
        public int Nomore;

        /// <summary>
        ///     The order
        /// </summary>
        public int[] Order = new int[4];

        /// <summary>
        ///     The progressive
        /// </summary>
        public int Progressive;

        /// <summary>
        ///     The resample row hv kernel
        /// </summary>
        public Delegate2 Resamplerowhv2Kernel;

        /// <summary>
        ///     The restart interval
        /// </summary>
        public int Restartinterval;

        /// <summary>
        ///     The rgb
        /// </summary>
        public int Rgb;

        /// <summary>
        ///     The
        /// </summary>
        public Stbicontext S;

        /// <summary>
        ///     The scan
        /// </summary>
        public int Scann;

        /// <summary>
        ///     The spec end
        /// </summary>
        public int Specend;

        /// <summary>
        ///     The spec start
        /// </summary>
        public int Specstart;

        /// <summary>
        ///     The succ high
        /// </summary>
        public int Succhigh;

        /// <summary>
        ///     The succ low
        /// </summary>
        public int Succlow;

        /// <summary>
        ///     The todo
        /// </summary>
        public int Todo;

        /// <summary>
        ///     The ycbcr to rgb kernel
        /// </summary>
        public Delegate1 YCbCrtoRgBkernel;
    }
}