using System;
        using System.IO;
        using System.Runtime.InteropServices;
        using Alis.Core.Graphic.Stb.Hebron.Runtime;
        
        namespace Alis.Core.Graphic.Stb
        {
            /// <summary>
            ///     The stb image class
            /// </summary>
            public static partial class StbImage
            {
                public static string StbiGFailureReason;
        
                public static readonly char[] StbiParsePngFileInvalidChunk = new char[25];
        
                public static int NativeAllocations => MemoryStats.Allocations;
        
                private static int stbi__err(string str)
                {
                    StbiGFailureReason = str;
                    return 0;
                }
        
                public static byte stbi__get8(StbiContext s)
                {
                    int b = s.Stream.ReadByte();
                    if (b == -1)
                    {
                        return 0;
                    }
        
                    return (byte)b;
                }
        
                public static void stbi__skip(StbiContext s, int skip)
                {
                    s.Stream.Seek(skip, SeekOrigin.Current);
                }
        
                public static void Stbirewind(StbiContext s)
                {
                    s.Stream.Seek(0, SeekOrigin.Begin);
                }
        
                public static int stbi__at_eof(StbiContext s) => s.Stream.Position == s.Stream.Length ? 1 : 0;
        
                public static int stbi__getn(StbiContext s, IntPtr buf, int size)
                {
                    if (s.TempBuffer == null || s.TempBuffer.Length < size)
                    {
                        s.TempBuffer = new byte[size * 2];
                    }
        
                    int result = s.Stream.Read(s.TempBuffer, 0, size);
                    Marshal.Copy(s.TempBuffer, 0, buf, result);
        
                    return result;
                }
        
                public class StbiContext
                {
                    private readonly Stream _stream;
        
                    public byte[] TempBuffer;
        
                    public int ImgN = 0;
        
                    public int ImgOutN = 0;
        
                    public uint ImgX = 0;
        
                    public uint ImgY = 0;
        
                    public StbiContext(Stream stream)
                    {
                        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
                    }
        
                    public Stream Stream => _stream;
                }
            }
        }