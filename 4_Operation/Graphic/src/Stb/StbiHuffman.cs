using System;
        
        namespace Alis.Core.Graphic.Stb
        {
            /// <summary>
            ///     The stbi huffman
            /// </summary>
            public struct StbiHuffman
            {
                /// <summary>
                ///     The fast
                /// </summary>
                public byte[] Fast;
        
                /// <summary>
                ///     The code
                /// </summary>
                public ushort[] Code;
        
                /// <summary>
                ///     The values
                /// </summary>
                public byte[] Values;
        
                /// <summary>
                ///     The size
                /// </summary>
                public byte[] Size;
        
                /// <summary>
                ///     The maxcode
                /// </summary>
                public uint[] Maxcode;
        
                /// <summary>
                ///     The delta
                /// </summary>
                public int[] Delta;
        
                /// <summary>
                ///     Initializes a new instance of the <see cref="StbiHuffman"/> struct.
                /// </summary>
                public StbiHuffman()
                {
                    Fast = new byte[512];
                    Code = new ushort[256];
                    Values = new byte[256];
                    Size = new byte[257];
                    Maxcode = new uint[18];
                    Delta = new int[17];
                }
            }
        }