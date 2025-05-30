﻿using System;
        using System.Runtime.InteropServices;
        
        namespace Alis.Core.Graphic.Stb
        {
            /// <summary>
            ///     The unnamed
            /// </summary>
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct Unnamed1
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
                public int dc_pred;
        
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
                public IntPtr data;
        
                /// <summary>
                ///     The raw data
                /// </summary>
                public IntPtr raw_data;
        
                /// <summary>
                ///     The raw coeff
                /// </summary>
                public IntPtr raw_coeff;
        
                /// <summary>
                ///     The linebuf
                /// </summary>
                public IntPtr linebuf;
        
                /// <summary>
                ///     The coeff
                /// </summary>
                public IntPtr coeff;
        
                /// <summary>
                ///     The coeff width
                /// </summary>
                public int coeff_w;
        
                /// <summary>
                ///     The coeff height
                /// </summary>
                public int coeff_h;
            }
        }