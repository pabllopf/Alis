using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Audio.Players
{
    internal static class OpenAl
    {
        // Device management
        [DllImport("openal32", EntryPoint = "alcOpenDevice")]
        public static extern IntPtr alcOpenDevice(string devicename);

        [DllImport("openal32", EntryPoint = "alcCreateContext")]
        public static extern IntPtr alcCreateContext(IntPtr device, IntPtr attrlist);

        [DllImport("openal32", EntryPoint = "alcMakeContextCurrent")]
        public static extern bool alcMakeContextCurrent(IntPtr context);

        [DllImport("openal32", EntryPoint = "alcCloseDevice")]
        public static extern bool alcCloseDevice(IntPtr device);

        // Source management
        [DllImport("openal32", EntryPoint = "alGenSources")]
        public static extern void alGenSources(int n, out uint sources);

        [DllImport("openal32", EntryPoint = "alDeleteSources")]
        public static extern void alDeleteSources(int n, ref uint sources);

        [DllImport("openal32", EntryPoint = "alSourcePlay")]
        public static extern void alSourcePlay(uint source);

        [DllImport("openal32", EntryPoint = "alSourceStop")]
        public static extern void alSourceStop(uint source);

        // Buffer management
        [DllImport("openal32", EntryPoint = "alGenBuffers")]
        public static extern void alGenBuffers(int n, out uint buffers);

        [DllImport("openal32", EntryPoint = "alDeleteBuffers")]
        public static extern void alDeleteBuffers(int n, ref uint buffers);

        [DllImport("openal32", EntryPoint = "alBufferData")]
        public static extern void alBufferData(uint buffer, int format, IntPtr data, int size, int freq);

        [DllImport("openal32", EntryPoint = "alSourcei")]
        public static extern void alSourcei(uint source, int param, int value);

        [DllImport("openal32", EntryPoint = "alSourceQueueBuffers")]
        public static extern void alSourceQueueBuffers(uint source, int nb, ref uint buffers);
    }
}
