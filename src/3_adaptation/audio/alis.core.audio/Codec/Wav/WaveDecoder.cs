// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WaveDecoder.cs
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
    public abstract class WavParser
    {
        public abstract int BitsPerSample { get; }

        public abstract byte[] Parse(BinaryReader reader, int size, WaveFormat format);

        public static WavParser GetParser(WaveFormatType type)
        {
            switch (type)
            {
                case WaveFormatType.Pcm: return new PcmParser();
                case WaveFormatType.DviAdpcm: return new DviAdpcmParser();
                default: throw new NotSupportedException("Invalid or unknown .wav compression format!");
            }
        }
    }

    public class WaveDecoder : Decoder
    {
        private readonly WaveData _data;
        public byte[] _decodedData;
        private WaveFact _fact;
        private readonly WaveFormat _format;
        private RiffHeader _header;
        private int _samplesLeft;

        public WaveDecoder(Stream s)
        {
            using (BinaryReader br = new BinaryReader(s))
            {
                _header = RiffHeader.Parse(br);
                _format = WaveFormat.Parse(br);

                if (_format.AudioFormat != WaveFormatType.Pcm)
                {
                    _fact = WaveFact.Parse(br);
                }

                _data = WaveData.Parse(br);
                WavParser variant = WavParser.GetParser(_format.AudioFormat);

                _decodedData = variant.Parse(br, (int) _data.SubChunkSize, _format);

                _audioFormat.BitsPerSample = variant.BitsPerSample;
                _audioFormat.Channels = _format.NumChannels;
                _audioFormat.SampleRate = (int) _format.SampleRate;

                _numSamples = _samplesLeft = _decodedData.Length / _audioFormat.BytesPerSample;
            }
        }

        public override bool IsFinished => _samplesLeft == 0;

        public override TimeSpan Position => TimeSpan.MinValue;

        public override bool HasPosition { get; } = false;

        public override long GetSamples(int samples, ref byte[] data)
        {
            int numSamples = Math.Min(samples, _samplesLeft);
            long byteSize = _audioFormat.BytesPerSample * numSamples;
            long byteOffset = (_numSamples - _samplesLeft) * _audioFormat.BytesPerSample;

            data = _decodedData.AsSpan().Slice((int) byteOffset, (int) byteSize).ToArray();
            _samplesLeft -= numSamples;

            return numSamples;
        }
    }
}