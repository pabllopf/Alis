// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayer.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;

namespace Alis.Core.Audio.Players
{
    internal class BrowserPlayer : IPlayer
    {
        private IntPtr _device;
        private IntPtr _context;
        private uint _source;
        private uint _buffer;
        private bool _playing;
        private bool _paused;

        public bool Playing => _playing;
        public bool Paused => _paused;
        public event EventHandler PlaybackFinished;

        public BrowserPlayer()
        {
            Console.WriteLine("[BrowserPlayer] Inicializando OpenAL...");
            _device = OpenAl.alcOpenDevice(null);
            Console.WriteLine($"[BrowserPlayer] Dispositivo OpenAL: {_device}");
            if (_device == IntPtr.Zero)
                throw new Exception("No se pudo abrir el dispositivo OpenAL");
            _context = OpenAl.alcCreateContext(_device, IntPtr.Zero);
            Console.WriteLine($"[BrowserPlayer] Contexto OpenAL: {_context}");
            if (_context == IntPtr.Zero)
                throw new Exception("No se pudo crear el contexto OpenAL");
            if (!OpenAl.alcMakeContextCurrent(_context))
                throw new Exception("No se pudo activar el contexto OpenAL");
            OpenAl.alGenSources(1, out _source);
            Console.WriteLine($"[BrowserPlayer] Source generado: {_source}");
            OpenAl.alGenBuffers(1, out _buffer);
            Console.WriteLine($"[BrowserPlayer] Buffer generado: {_buffer}");
        }

        public async Task Play(string fileName)
        {
            Console.WriteLine($"[BrowserPlayer] Play: {fileName}");
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"[BrowserPlayer] Archivo no encontrado: {fileName}");
                throw new FileNotFoundException(fileName);
            }
            byte[] wavData = File.ReadAllBytes(fileName);
            Console.WriteLine($"[BrowserPlayer] Tamaño del archivo: {wavData.Length}");
            int dataOffset, dataSize, freq, format;
            if (!TryParseWav(wavData, out dataOffset, out dataSize, out freq, out format))
            {
                Console.WriteLine("[BrowserPlayer] Formato WAV no soportado");
                throw new Exception("Formato WAV no soportado");
            }
            Console.WriteLine($"[BrowserPlayer] WAV: offset={dataOffset}, size={dataSize}, freq={freq}, format={format}");
            GCHandle handle = GCHandle.Alloc(wavData, GCHandleType.Pinned);
            try
            {
                IntPtr dataPtr = IntPtr.Add(handle.AddrOfPinnedObject(), dataOffset);
                OpenAl.alBufferData(_buffer, format, dataPtr, dataSize, freq);
                Console.WriteLine("[BrowserPlayer] alBufferData ejecutado");
                OpenAl.alSourcei(_source, 0x1009 /* AL_BUFFER */, (int)_buffer);
                Console.WriteLine("[BrowserPlayer] alSourcei ejecutado");
                OpenAl.alSourcePlay(_source);
                Console.WriteLine("[BrowserPlayer] alSourcePlay ejecutado");
                _playing = true;
                _paused = false;
            }
            finally
            {
                handle.Free();
            }
        }

        public Task PlayLoop(string fileName, bool loop)
        {
            // No implementado: se puede usar alSourcei(_source, AL_LOOPING, 1)
            return Play(fileName);
        }

        public Task Pause()
        {
            OpenAl.alSourceStop(_source);
            _paused = true;
            _playing = false;
            return Task.CompletedTask;
        }

        public Task Resume()
        {
            OpenAl.alSourcePlay(_source);
            _paused = false;
            _playing = true;
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            OpenAl.alSourceStop(_source);
            _playing = false;
            _paused = false;
            return Task.CompletedTask;
        }

        public Task SetVolume(byte percent)
        {
            // No implementado: se puede usar alSourcef(_source, AL_GAIN, percent/100f)
            return Task.CompletedTask;
        }

        private bool TryParseWav(byte[] wav, out int dataOffset, out int dataSize, out int freq, out int format)
        {
            // Simple WAV PCM 16bit mono/stereo parser
            dataOffset = 0; dataSize = 0; freq = 0; format = 0;
            if (wav.Length < 44) return false;
            if (wav[0] != 'R' || wav[1] != 'I' || wav[2] != 'F' || wav[3] != 'F') return false;
            if (wav[8] != 'W' || wav[9] != 'A' || wav[10] != 'V' || wav[11] != 'E') return false;
            int channels = BitConverter.ToInt16(wav, 22);
            freq = BitConverter.ToInt32(wav, 24);
            int bits = BitConverter.ToInt16(wav, 34);
            int pos = 12;
            while (pos < wav.Length - 8)
            {
                string chunkId = System.Text.Encoding.ASCII.GetString(wav, pos, 4);
                int chunkSize = BitConverter.ToInt32(wav, pos + 4);
                if (chunkId == "data")
                {
                    dataOffset = pos + 8;
                    dataSize = chunkSize;
                    break;
                }
                pos += 8 + chunkSize;
            }
            if (dataOffset == 0 || dataSize == 0) return false;
            if (bits == 16)
            {
                if (channels == 1) format = 0x1101; // AL_FORMAT_MONO16
                else if (channels == 2) format = 0x1103; // AL_FORMAT_STEREO16
                else return false;
            }
            else return false;
            return true;
        }
    }
}