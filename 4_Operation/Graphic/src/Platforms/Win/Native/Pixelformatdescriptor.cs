#if WIN

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Pixelformatdescriptor
    {
        
        /// <summary>
        /// 
        /// </summary>
        public ushort nSize;
        
        /// <summary>
        /// 
        /// </summary>
        public ushort nVersion;
        
        /// <summary>
        /// 
        /// </summary>
        public uint dwFlags;
        
        /// <summary>
        /// 
        /// </summary>
        public byte iPixelType;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cColorBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cRedBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cRedShift;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cGreenBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cGreenShift;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cBlueBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cBlueShift;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAlphaBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAlphaShift;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAccumBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAccumRedBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAccumGreenBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAccumBlueBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAccumAlphaBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cDepthBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cStencilBits;
        
        /// <summary>
        /// 
        /// </summary>
        public byte cAuxBuffers;
        
        /// <summary>
        /// 
        /// </summary>
        public byte iLayerType;
        
        /// <summary>
        /// 
        /// </summary>
        public byte bReserved;
        
        /// <summary>
        /// 
        /// </summary>
        public uint dwLayerMask;
        
        /// <summary>
        /// 
        /// </summary>
        public uint dwVisibleMask;
        
        /// <summary>
        /// 
        /// </summary>
        public uint dwDamageMask;
    }
}

#endif