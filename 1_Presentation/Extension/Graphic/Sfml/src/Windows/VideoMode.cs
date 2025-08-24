using System;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    
    /// <summary>
    /// VideoMode defines a video mode (width, height, bpp, frequency)
    /// and provides static functions for getting modes supported
    /// by the display device
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct VideoMode
    {
        
        /// <summary>
        /// Construct the video mode with its width and height
        /// </summary>
        /// <param name="width">Video mode width</param>
        /// <param name="height">Video mode height</param>
        
        public VideoMode(uint width, uint height) :
            this(width, height, 32)
        {
        }

        
        /// <summary>
        /// Construct the video mode with its width, height and depth
        /// </summary>
        /// <param name="width">Video mode width</param>
        /// <param name="height">Video mode height</param>
        /// <param name="bpp">Video mode depth (bits per pixel)</param>
        
        public VideoMode(uint width, uint height, uint bpp)
        {
            Width = width;
            Height = height;
            BitsPerPixel = bpp;
        }

        
        /// <summary>
        /// Tell whether or not the video mode is supported
        /// </summary>
        /// <returns>True if the video mode is valid, false otherwise</returns>
        
        public bool IsValid()
        {
            return sfVideoMode_isValid(this);
        }

        
        /// <summary>
        /// Get the list of all the supported fullscreen video modes
        /// </summary>
        
        public static VideoMode[] FullscreenModes
        {
            get
            {
                uint count;
                IntPtr modesPtr = sfVideoMode_getFullscreenModes_v2(out count);
                
                VideoMode[] modes = new VideoMode[count];
                int size = Marshal.SizeOf(typeof(VideoMode));
                for (uint i = 0; i < count; ++i)
                {
                    IntPtr currentPtr = IntPtr.Add(modesPtr, (int)(i * size));
                    modes[i] = Marshal.PtrToStructure<VideoMode>(currentPtr);
                }
                return modes;
            }
        }

        
        /// <summary>
        /// Get the current desktop video mode
        /// </summary>
        
        public static VideoMode DesktopMode
        {
            get { return sfVideoMode_getDesktopMode(); }
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[VideoMode]" +
                   " Width(" + Width + ")" +
                   " Height(" + Height + ")" +
                   " BitsPerPixel(" + BitsPerPixel + ")";
        }

        /// <summary>Video mode width, in pixels</summary>
        public uint Width;

        /// <summary>Video mode height, in pixels</summary>
        public uint Height;

        /// <summary>Video mode depth, in bits per pixel</summary>
        public uint BitsPerPixel;

        #region Imports
        /// <summary>
        /// Sfs the video mode get desktop mode
        /// </summary>
        /// <returns>The video mode</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern VideoMode sfVideoMode_getDesktopMode();

        /// <summary>
        /// Sfs the video mode get fullscreen modes using the specified count
        /// </summary>
        /// <param name="Count">The count</param>
        /// <returns>The video mode</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern VideoMode sfVideoMode_getFullscreenModes(out int Count);

        /// <summary>
        /// Sfs the video mode get fullscreen modes v 2 using the specified count
        /// </summary>
        /// <param name="Count">The count</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sfVideoMode_getFullscreenModes") , SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfVideoMode_getFullscreenModes_v2(out uint Count);
        
        /// <summary>
        /// Sfs the video mode is valid using the specified mode
        /// </summary>
        /// <param name="Mode">The mode</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfVideoMode_isValid(VideoMode Mode);
        #endregion
    }
}
