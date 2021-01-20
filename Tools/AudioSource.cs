
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Alis.Tools
{
    public class AudioSource
    {


        private Sound audio;

        private bool playonawake;

        public AudioSource()
        {
        
        }

        

        public void Play() 
        {
            Music music = new Music(Environment.CurrentDirectory + "/Resources/Example.wav");

            // Display music informations
            Console.WriteLine("lepidoptera.ogg :");
            Console.WriteLine(" " + music.Duration + " sec");
            Console.WriteLine(" " + music.SampleRate + " samples / sec");
            Console.WriteLine(" " + music.ChannelCount + " channels");

            // Play it
            music.Play();

            // Loop while the music is playing
            while (music.Status == SoundStatus.Playing)
            {
                // Display the playing position
                Console.CursorLeft = 0;
                Console.Write("Playing... " + music.PlayingOffset + " sec     ");

                // Leave some CPU time for other processes
                Thread.Sleep(100);
            }
        }

    }
}
