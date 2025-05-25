using System;
        using System.IO;
        using System.Runtime.InteropServices;
        using Alis.Core.Graphic.Stb.Hebron.Runtime;
        
        namespace Alis.Core.Graphic.Stb
        {
            public class ImageResultFloat
            {
                public int Width { get; set; }
                public int Height { get; set; }
                public ColorComponents SourceComp { get; set; }
                public ColorComponents Comp { get; set; }
                public float[] Data { get; set; }
        
                internal static ImageResultFloat FromResult(IntPtr result, int width, int height, ColorComponents comp, ColorComponents reqComp)
                {
                    if (result == IntPtr.Zero)
                    {
                        throw new InvalidOperationException(StbImage.StbiGFailureReason);
                    }
        
                    ImageResultFloat image = new ImageResultFloat
                    {
                        Width = width,
                        Height = height,
                        SourceComp = comp,
                        Comp = reqComp == ColorComponents.Default ? comp : reqComp
                    };
        
                    image.Data = new float[width * height * (int)image.Comp];
                    Marshal.Copy(result, image.Data, 0, image.Data.Length);
        
                    return image;
                }
        
                public static ImageResultFloat FromStream(Stream stream, ColorComponents requiredComponents = ColorComponents.Default)
                {
                    IntPtr result = IntPtr.Zero;
        
                    try
                    {
                        int x = 0, y = 0, comp = 0;
        
                        StbImage.StbiContext context = new StbImage.StbiContext(stream);
        
                        result = StbImage.StbiLoadfMain(context, ref x, ref y, ref comp, (int)requiredComponents);
        
                        return FromResult(result, x, y, (ColorComponents)comp, requiredComponents);
                    }
                    finally
                    {
                        if (result != IntPtr.Zero)
                        {
                            CRuntime.Free(result);
                        }
                    }
                }
        
                public static ImageResultFloat FromMemory(byte[] data, ColorComponents requiredComponents = ColorComponents.Default)
                {
                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        return FromStream(stream, requiredComponents);
                    }
                }
            }
        }