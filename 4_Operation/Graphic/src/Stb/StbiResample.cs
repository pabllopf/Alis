using System;

namespace Alis.Core.Graphic.Stb
        {
            /// <summary>
            ///     La clase stbi resample
            /// </summary>
            public class StbiResample
            {
                /// <summary>
                ///     El hs
                /// </summary>
                public int Hs;
        
                /// <summary>
                ///     La línea 0
                /// </summary>
                public IntPtr Line0;
        
                /// <summary>
                ///     La línea 1
                /// </summary>
                public IntPtr Line1;
        
                /// <summary>
                ///     El resample
                /// </summary>
                public StbImage.Delegate2 Resample;
        
                /// <summary>
                ///     El vs
                /// </summary>
                public int Vs;
        
                /// <summary>
                ///     El lores
                /// </summary>
                public int WLores;
        
                /// <summary>
                ///     El ypos
                /// </summary>
                public int Ypos;
        
                /// <summary>
                ///     El ystep
                /// </summary>
                public int Ystep;
            }
        }