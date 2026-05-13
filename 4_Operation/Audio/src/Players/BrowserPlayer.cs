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
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     Audio player implementation for browser (WebAssembly) environments using OpenAL.
    ///     Loads WAV audio files from embedded resources and plays them through the OpenAL subsystem.
    /// </summary>
    /// <seealso cref="IPlayer" />
    internal class BrowserPlayer : IPlayer
    {
        /// <summary>
        ///     The OpenAL buffer identifier used to store the audio sample data.
        /// </summary>
        private readonly uint _buffer;

        /// <summary>
        ///     The OpenAL context pointer for audio rendering.
        /// </summary>
        private readonly IntPtr _context;

        /// <summary>
        ///     The OpenAL device pointer opened during initialization.
        /// </summary>
        private readonly IntPtr _device;

        /// <summary>
        ///     The OpenAL source identifier used for playback control.
        /// </summary>
        private readonly uint _source;

        /// <summary>
        ///     Indicates whether playback is currently paused.
        /// </summary>
        private bool _paused;

        /// <summary>
        ///     Indicates whether playback is currently active.
        /// </summary>
        private bool _playing;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BrowserPlayer" /> class.
        ///     Opens the default OpenAL device, creates an audio context, and generates a source and buffer.
        /// </summary>
        /// <exception cref="Exception">Thrown when the OpenAL device cannot be opened.</exception>
        /// <exception cref="Exception">Thrown when the OpenAL context cannot be created.</exception>
        /// <exception cref="Exception">Thrown when the OpenAL context cannot be made current.</exception>
        public BrowserPlayer()
        {
            Console.WriteLine("[BrowserPlayer] Inicializando OpenAL...");
            _device = OpenAl.alcOpenDevice(null);
            Console.WriteLine($"[BrowserPlayer] Dispositivo OpenAL: {_device}");
            if (_device == IntPtr.Zero)
            {
                throw new Exception("No se pudo abrir el dispositivo OpenAL");
            }

            _context = OpenAl.alcCreateContext(_device, IntPtr.Zero);
            Console.WriteLine($"[BrowserPlayer] Contexto OpenAL: {_context}");
            if (_context == IntPtr.Zero)
            {
                throw new Exception("No se pudo crear el contexto OpenAL");
            }

            if (!OpenAl.alcMakeContextCurrent(_context))
            {
                throw new Exception("No se pudo activar el contexto OpenAL");
            }

            OpenAl.alGenSources(1, out _source);
            Console.WriteLine($"[BrowserPlayer] Source generado: {_source}");
            OpenAl.alGenBuffers(1, out _buffer);
            Console.WriteLine($"[BrowserPlayer] Buffer generado: {_buffer}");
        }

        /// <summary>
        ///     Gets a value indicating whether audio playback is currently in progress.
        /// </summary>
        public bool Playing => _playing;

        /// <summary>
        ///     Gets a value indicating whether audio playback is currently paused.
        /// </summary>
        public bool Paused => _paused;

        /// <summary>
        ///     Occurs when the current audio playback has finished.
        /// </summary>
        public event EventHandler PlaybackFinished;

        /// <summary>
        ///     Loads a WAV file from an embedded resource and starts OpenAL playback.
        ///     Parses the WAV header, uploads PCM data to an OpenAL buffer, and issues a play command.
        /// </summary>
        /// <param name="fileName">The name of the embedded WAV resource to play.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the specified resource cannot be found.</exception>
        /// <exception cref="Exception">Thrown when the WAV format is not supported (e.g., compressed or unknown format).</exception>
        public async Task Play(string fileName)
        {
            Console.WriteLine($"[BrowserPlayer] Play: {fileName}");
            byte[] wavData = null;
            using (MemoryStream stream = AssetRegistry.GetResourceMemoryStreamByName(fileName))
            {
                if (stream == null)
                {
                    Console.WriteLine($"[BrowserPlayer] Recurso no encontrado: {fileName}");
                    throw new FileNotFoundException(fileName);
                }

                wavData = new byte[stream.Length];
                int bytesRead = await stream.ReadAsync(wavData, 0, (int) stream.Length);
                if (bytesRead != stream.Length)
                {
                    Console.WriteLine($"[BrowserPlayer] Incomplete read: {bytesRead} of {stream.Length} bytes");
                }
                Console.WriteLine($"[BrowserPlayer] Tamaño del recurso: {wavData.Length}");
            }

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
                OpenAl.alSourcei(_source, 0x1009 /* AL_BUFFER */, (int) _buffer);
                Console.WriteLine("[BrowserPlayer] alSourcei ejecutado");
                OpenAl.alSourcePlay(_source);
                Console.WriteLine("[BrowserPlayer] alSourcePlay ejecutado");
                _playing = true;
                _paused = false;
            }
            finally
            {
                handle.Free();
                PlaybackFinished?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     Starts playback of the specified audio file with optional looping.
        ///     Currently, looping is not implemented; it delegates to <see cref="Play" /> for single playback.
        /// </summary>
        /// <param name="fileName">The name of the embedded WAV resource to play.</param>
        /// <param name="loop">If <c>true</c>, the audio should loop; currently ignored.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        public Task PlayLoop(string fileName, bool loop) =>
            // No implementado: se puede usar alSourcei(_source, AL_LOOPING, 1)
            Play(fileName);

        /// <summary>
        ///     Pauses the currently playing audio by stopping the OpenAL source.
        ///     Sets the paused flag to <c>true</c> and the playing flag to <c>false</c>.
        /// </summary>
        /// <returns>A task that represents the asynchronous pause operation.</returns>
        public Task Pause()
        {
            OpenAl.alSourceStop(_source);
            _paused = true;
            _playing = false;
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Resumes playback of a previously paused audio file by restarting the OpenAL source.
        ///     Sets the paused flag to <c>false</c> and the playing flag to <c>true</c>.
        /// </summary>
        /// <returns>A task that represents the asynchronous resume operation.</returns>
        public Task Resume()
        {
            OpenAl.alSourcePlay(_source);
            _paused = false;
            _playing = true;
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Stops the current audio playback by stopping the OpenAL source.
        ///     Resets both the playing and paused flags to <c>false</c>.
        /// </summary>
        /// <returns>A task that represents the asynchronous stop operation.</returns>
        public Task Stop()
        {
            OpenAl.alSourceStop(_source);
            _playing = false;
            _paused = false;
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Sets the audio playback volume.
        ///     Currently not implemented; can be extended using <c>alSourcef(_source, AL_GAIN, percent/100f)</c>.
        /// </summary>
        /// <param name="percent">The volume level from 0 to 100.</param>
        /// <returns>A task that represents the asynchronous volume change operation.</returns>
        public Task SetVolume(byte percent) =>
            // No implementado: se puede usar alSourcef(_source, AL_GAIN, percent/100f)
            Task.CompletedTask;

        /// <summary>
        ///     Attempts to parse a WAV file's header and extract audio format information.
        ///     Supports PCM 8-bit and 16-bit mono/stereo formats. Validates RIFF/WAVE headers and the 'fmt ' and 'data' chunks.
        /// </summary>
        /// <param name="wav">The raw WAV file data as a byte array.</param>
        /// <param name="dataOffset">When this method returns, contains the offset in bytes to the start of the PCM data.</param>
        /// <param name="dataSize">When this method returns, contains the size in bytes of the PCM data.</param>
        /// <param name="freq">When this method returns, contains the sample frequency in Hertz.</param>
        /// <param name="format">When this method returns, contains the OpenAL format constant.</param>
        /// <returns><c>true</c> if the WAV file was successfully parsed; otherwise, <c>false</c>.</returns>
        private bool TryParseWav(byte[] wav, out int dataOffset, out int dataSize, out int freq, out int format)
        {
            // Parser WAV extendido: muestra todos los campos fmt, chunks, y sugiere conversión si es comprimido
            dataOffset = 0;
            dataSize = 0;
            freq = 0;
            format = 0;
            if (wav.Length < 44)
            {
                Console.WriteLine($"[WAV] Archivo demasiado pequeño: {wav.Length} bytes");
                return false;
            }

            if (wav[0] != 'R' || wav[1] != 'I' || wav[2] != 'F' || wav[3] != 'F')
            {
                Console.WriteLine("[WAV] No es un archivo RIFF");
                return false;
            }

            if (wav[8] != 'W' || wav[9] != 'A' || wav[10] != 'V' || wav[11] != 'E')
            {
                Console.WriteLine("[WAV] No es un archivo WAVE");
                return false;
            }

            // Buscar chunk 'fmt '
            int fmtPos = 12;
            int fmtSize = 0;
            while (fmtPos < wav.Length - 8)
            {
                string chunkId = Encoding.ASCII.GetString(wav, fmtPos, 4);
                int chunkSize = BitConverter.ToInt32(wav, fmtPos + 4);
                if (chunkId == "fmt ")
                {
                    fmtSize = chunkSize;
                    break;
                }

                fmtPos += 8 + chunkSize;
            }

            if (fmtSize == 0)
            {
                Console.WriteLine("[WAV] No se encontró chunk 'fmt '");
                return false;
            }

            int audioFormat = BitConverter.ToInt16(wav, fmtPos + 8);
            int channels = BitConverter.ToInt16(wav, fmtPos + 10);
            freq = BitConverter.ToInt32(wav, fmtPos + 12);
            int byteRate = BitConverter.ToInt32(wav, fmtPos + 16);
            int blockAlign = BitConverter.ToInt16(wav, fmtPos + 20);
            int bits = BitConverter.ToInt16(wav, fmtPos + 22);
            int extraSize = fmtSize > 16 ? BitConverter.ToInt16(wav, fmtPos + 24) : 0;
            Console.WriteLine($"[WAV] audioFormat: {audioFormat}, Canales: {channels}, Frecuencia: {freq}, Bits: {bits}, ByteRate: {byteRate}, BlockAlign: {blockAlign}, ExtraSize: {extraSize}");
            if (audioFormat != 1)
            {
                Console.WriteLine($"[WAV] Formato comprimido no soportado: {audioFormat} (solo PCM=1)");
                Console.WriteLine("[WAV] SUGERENCIA: Convierte el archivo WAV a PCM 16 bits usando Audacity, ffmpeg o sox.");
                return false;
            }

            // Buscar chunk 'data', ignorando chunks extra
            int pos = fmtPos + 8 + fmtSize;
            while (pos < wav.Length - 8)
            {
                string chunkId = Encoding.ASCII.GetString(wav, pos, 4);
                int chunkSize = BitConverter.ToInt32(wav, pos + 4);
                Console.WriteLine($"[WAV] Chunk: {chunkId}, Size: {chunkSize}, Pos: {pos}");
                if (chunkId == "data")
                {
                    dataOffset = pos + 8;
                    dataSize = chunkSize;
                    break;
                }

                pos += 8 + chunkSize;
            }

            if (dataOffset == 0 || dataSize == 0)
            {
                Console.WriteLine("[WAV] No se encontró chunk 'data'");
                return false;
            }

            // Soportar PCM 8/16 bits
            if (bits == 16)
            {
                if (channels == 1)
                {
                    format = 0x1101; // AL_FORMAT_MONO16
                }
                else if (channels == 2)
                {
                    format = 0x1103; // AL_FORMAT_STEREO16
                }
                else
                {
                    Console.WriteLine($"[WAV] Canales no soportados: {channels}");
                    return false;
                }
            }
            else if (bits == 8)
            {
                if (channels == 1)
                {
                    format = 0x1100; // AL_FORMAT_MONO8
                }
                else if (channels == 2)
                {
                    format = 0x1102; // AL_FORMAT_STEREO8
                }
                else
                {
                    Console.WriteLine($"[WAV] Canales no soportados: {channels}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"[WAV] Bits no soportados: {bits}");
                Console.WriteLine("[WAV] SUGERENCIA: Convierte el archivo WAV a PCM 16 bits usando Audacity, ffmpeg o sox.");
                return false;
            }

            Console.WriteLine($"[WAV] dataOffset={dataOffset}, dataSize={dataSize}, format={format}");
            return true;
        }
    }
}
