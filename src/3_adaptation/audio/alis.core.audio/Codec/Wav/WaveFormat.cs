// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WaveFormat.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;

namespace Alis.Core.Audio.Codec.Wav
{
    public enum WaveFormatType : ushort
    {
        Pcm = 0x01,
        DviAdpcm = 0x11
    }

    public struct RiffHeader
    {
        public string ChunkId;
        public uint ChunkSize;
        public string Format;

        public static RiffHeader Parse(BinaryReader reader)
        {
            RiffHeader header = new RiffHeader();
            header.ChunkId = reader.ReadFourCc();
            header.ChunkSize = reader.ReadUInt32();
            header.Format = reader.ReadFourCc();

            if (header.ChunkId != "RIFF" ||
                header.Format != "WAVE")
            {
                throw new InvalidDataException("Invalid or missing .wav file header!");
            }

            return header;
        }
    }

    public struct WaveFormat
    {
        public string SubChunkID;
        public uint SubChunkSize;
        public WaveFormatType AudioFormat;
        public ushort NumChannels;
        public uint SampleRate;
        public uint ByteRate;
        public ushort BlockAlign;
        public ushort BitsPerSample;
        public ushort ExtraBytesSize; // Only used in certain compressed formats
        public byte[] ExtraBytes; // Only used in certain compressed formats

        public static WaveFormat Parse(BinaryReader reader)
        {
            WaveFormat format = new WaveFormat();
            format.SubChunkID = reader.ReadFourCc();
            if (format.SubChunkID != "fmt ")
            {
                throw new InvalidDataException("Invalid or missing .wav file format chunk!");
            }

            format.SubChunkSize = reader.ReadUInt32();
            format.AudioFormat = (WaveFormatType) reader.ReadUInt16();
            format.NumChannels = reader.ReadUInt16();
            format.SampleRate = reader.ReadUInt32();
            format.ByteRate = reader.ReadUInt32();
            format.BlockAlign = reader.ReadUInt16();
            format.BitsPerSample = reader.ReadUInt16();

            if (format.SubChunkSize == 18)
            {
                reader.ReadInt16();
            }

            switch (format.AudioFormat)
            {
                case WaveFormatType.Pcm:
                    format.ExtraBytesSize = 0;
                    format.ExtraBytes = new byte[0];
                    break;
                case WaveFormatType.DviAdpcm:
                    if (format.NumChannels != 1)
                    {
                        throw new NotSupportedException(
                            "Only single channel DVI ADPCM compressed .wavs are supported.");
                    }

                    format.ExtraBytesSize = reader.ReadUInt16();
                    if (format.ExtraBytesSize != 2)
                    {
                        throw new InvalidDataException("Invalid .wav DVI ADPCM format!");
                    }

                    format.ExtraBytes = reader.ReadBytes(format.ExtraBytesSize);
                    break;
                default:
                    throw new NotSupportedException("Invalid or unknown .wav compression format!");
            }

            return format;
        }
    }

    internal struct WaveFact
    {
        public string SubChunkID;

        public uint SubChunkSize;

        // Technically this chunk could contain arbitrary data. But in practice
        // it only ever contains a single UInt32 representing the number of
        // samples.
        public uint NumSamples;

        public static WaveFact Parse(BinaryReader reader)
        {
            WaveFact fact = new WaveFact();
            fact.SubChunkID = reader.ReadFourCc();
            if (fact.SubChunkID != "fact")
            {
                throw new InvalidDataException("Invalid or missing .wav file fact chunk!");
            }

            fact.SubChunkSize = reader.ReadUInt32();
            if (fact.SubChunkSize != 4)
            {
                throw new NotSupportedException("Invalid or unknown .wav compression format!");
            }

            fact.NumSamples = reader.ReadUInt32();
            return fact;
        }
    }

    internal struct WaveData
    {
        public string SubChunkID; // should contain the word data
        public uint SubChunkSize; // Stores the size of the data block

        public static WaveData Parse(BinaryReader reader)
        {
            WaveData data = new WaveData();
            data.SubChunkID = reader.ReadFourCc();
            if (data.SubChunkID != "data")
            {
                throw new InvalidDataException("Invalid or missing .wav file data chunk!");
            }

            data.SubChunkSize = reader.ReadUInt32();
            return data;
        }
    }
}