using System;
        using System.Runtime.InteropServices;
        using Alis.Core.Graphic.Stb.Hebron.Runtime;

        namespace Alis.Core.Graphic.Stb
        {
            /// <summary>
            ///     The stbi png class
            /// </summary>
            public class StbiPng
            {
                /// <summary>
                ///     The out
                /// </summary>
                public IntPtr Out;
        
                /// <summary>
                ///     The depth
                /// </summary>
                public int Depth;
        
                /// <summary>
                ///     The expanded
                /// </summary>
                public IntPtr Expanded;
        
                /// <summary>
                ///     The idata
                /// </summary>
                public IntPtr Idata;
        
                /// <summary>
                ///     The
                /// </summary>
                public StbImage.StbiContext S;
        
                /// <summary>
                ///     Free unmanaged memory
                /// </summary>
                public void FreeMemory()
                {
                    if (Out != IntPtr.Zero)
                    {
                        CRuntime.Free(Out);
                        Out = IntPtr.Zero;
                    }
        
                    if (Expanded != IntPtr.Zero)
                    {
                        CRuntime.Free(Expanded);
                        Expanded = IntPtr.Zero;
                    }
        
                    if (Idata != IntPtr.Zero)
                    {
                        CRuntime.Free(Idata);
                        Idata = IntPtr.Zero;
                    }
                }
            }
        }