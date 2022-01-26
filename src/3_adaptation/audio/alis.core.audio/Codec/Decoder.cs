// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Decoder.cs
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

namespace Alis.Core.Audio.Codec
{
    public abstract class Decoder : IDisposable
    {
        protected AudioFormat _audioFormat;
        protected int _numSamples = 0;
        protected int _readSize;

        /// <summary>
        ///     The format of the decoded data
        /// </summary>
        public AudioFormat Format => _audioFormat;

        /// <summary>
        ///     Specifies the length of the decoded data. If not available returns 0
        /// </summary>
        public virtual TimeSpan Duration =>
            TimeSpan.FromSeconds((float) _numSamples / (_audioFormat.SampleRate * _audioFormat.Channels));

        /// <summary>
        ///     Specifies the current position of the decoded data. If not available returns 0
        /// </summary>
        public abstract TimeSpan Position { get; }

        /// <summary>
        ///     Specifies if the decoder can return track position data or not.
        /// </summary>
        public abstract bool HasPosition { get; }

        /// <summary>
        ///     Wether or not the decoder reached the end of data
        /// </summary>
        public abstract bool IsFinished { get; }

        public virtual void Dispose()
        {
        }

        /// <summary>
        ///     Reads the specified amount of samples
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract long GetSamples(int samples, ref byte[] data);

        /// <summary>
        ///     Read all samples from this stream
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public long GetSamples(ref byte[] data) => GetSamples(_numSamples, ref data);

        /// <summary>
        ///     Reads the specified amount of samples
        /// </summary>
        /// <param name="span"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public long GetSamples(TimeSpan span, ref byte[] data)
        {
            int numSamples = (int) (span.TotalSeconds * Format.SampleRate * Format.Channels);

            return GetSamples(numSamples, ref data);
        }

        public bool Probe(ref byte[] fourcc) => false;

        public virtual bool TrySeek(TimeSpan time) => false;
    }
}