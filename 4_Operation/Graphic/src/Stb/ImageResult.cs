using System;
        using System.IO;
        using System.Runtime.InteropServices;
        using Alis.Core.Graphic.Stb.Hebron.Runtime;
        
        namespace Alis.Core.Graphic.Stb
        {
            public class ImageResult
            {
                public int Width { get; set; }
                public int Height { get; set; }
                public ColorComponents SourceComp { get; set; }
                public ColorComponents Comp { get; set; }
                public byte[] Data { get; set; }
        
                internal static ImageResult FromResult(IntPtr result, int width, int height, ColorComponents comp, ColorComponents reqComp)
                {
                    if (result == IntPtr.Zero)
                    {
                        throw new InvalidOperationException(StbImage.StbiGFailureReason);
                    }
        
                    ImageResult image = new ImageResult
                    {
                        Width = width,
                        Height = height,
                        SourceComp = comp,
                        Comp = reqComp == ColorComponents.Default ? comp : reqComp
                    };
        
                    image.Data = new byte[width * height * (int)image.Comp];
                    Marshal.Copy(result, image.Data, 0, image.Data.Length);
        
                    return image;
                }
        
                public static ImageResult FromStream(Stream stream, ColorComponents requiredComponents = ColorComponents.Default)
                {
                    IntPtr result = IntPtr.Zero;
        
                    try
                    {
                        int x = 0, y = 0, comp = 0;
        
                        StbImage.StbiContext context = new StbImage.StbiContext(stream);
        
                        result = StbImage.StbiLoadAndPostprocess8Bit(context,  out x, out y, out comp, (int)requiredComponents);
        
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
        
                public static ImageResult FromMemory(byte[] data, ColorComponents requiredComponents = ColorComponents.Default)
                {
                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        return FromStream(stream, requiredComponents);
                    }
                }
            }
        }