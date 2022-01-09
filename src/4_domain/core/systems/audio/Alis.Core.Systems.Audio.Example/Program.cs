using System;
using System.IO;
using Alis.Core.Systems.Audio.Codec;

namespace Alis.Core.Systems.Audio.Example
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            AudioEngine engine = AudioEngine.CreateDefault();
            SoundStream soundStream = new SoundStream(File.OpenRead("test.wav"), engine);

            soundStream.Volume = 0.5f;
            soundStream.Play();

            Console.WriteLine("Press any key to exit...");
            Console.Read();
            soundStream.Stop();
        }
    }
}