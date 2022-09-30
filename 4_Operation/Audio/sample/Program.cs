

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Audio.NativeExample;
using Alis.Core.Audio.SFML;

namespace Alis.Core.Audio.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            Console.WriteLine("You can manipulate the player with the following commands:");
            Console.WriteLine("sfml - test the sfml integration");
            Console.WriteLine("native - test the native integration");
            Console.WriteLine("exit");
            
            while (true)
            {
                var command = Console.ReadLine();

                try
                {
                    switch (command)
                    {
                        case "sfml":
                            TestSFMLAudio();
                            break;
                        case "native":
                            TestNativeAudio();
                            break;
                    }

                    if (command == "exit") break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
        
        /// <summary>
        /// Tests the sfml audio
        /// </summary>
        private static void TestSFMLAudio()
        {
            ShowInstruction();
            string fileName = "./Assets/menu.wav";
            Music music = new Music(fileName);
            while (true)
            {
                var command = Console.ReadLine();

                try
                {
                    switch (command)
                    {
                        case "play":
                            Console.WriteLine($"Playing {fileName}");
                            music.Play();
                            Console.WriteLine(music.Status == SoundStatus.Playing ? "Playback started" : "Could not start the playback");
                            break;
                        case "pause":
                            music.Pause();
                            Console.WriteLine(music.Status == SoundStatus.Paused ? "Playback paused" : "Could not pause playback");
                            break;
                        case "resume":
                            music.Play();
                            Console.WriteLine(music.Status == SoundStatus.Playing  ? "Playback resumed" : "Could not resume playback");
                            break;
                        case "stop":
                            music.Stop();
                            Console.WriteLine(music.Status == SoundStatus.Stopped ? "Playback stopped" : "Could not stop the playback");
                            break;
                        case "volume":
                            Console.WriteLine("Enter new volume in percent");
                            float volume = Convert.ToSingle(Console.ReadLine());
                            music.Volume = volume;
                            ShowInstruction();
                            break;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Haven't got a clue, mate!");
                            break;
                    }

                    if (command == "exit") break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
        
        
        /// <summary>
        /// Tests the native audio
        /// </summary>
        private static void TestNativeAudio()
        {
            var player = new Player();
            player.PlaybackFinished += OnPlaybackFinished;

            Console.WriteLine("Welcome to the demo of NetCoreAudio package");
            ShowFileEntryPrompt();
            var fileName = "./Assets/menu.wav";
            ShowInstruction();

            while (true)
            {
                var command = Console.ReadLine();

                try
                {
                    switch (command)
                    {
                        case "play":
                            Console.WriteLine($"Playing {fileName}");
                            player.Play(fileName).Wait();
                            Console.WriteLine(player.Playing ? "Playback started" : "Could not start the playback");
                            break;
                        case "pause":
                            player.Pause().Wait();
                            Console.WriteLine(player.Paused ? "Playback paused" : "Could not pause playback");
                            break;
                        case "resume":
                            player.Resume().Wait();
                            Console.WriteLine(player.Playing && !player.Paused ? "Playback resumed" : "Could not resume playback");
                            break;
                        case "stop":
                            player.Stop().Wait();
                            Console.WriteLine(!player.Playing ? "Playback stopped" : "Could not stop the playback");
                            break;
                        case "change":
                            player.Stop().Wait();
                            ShowFileEntryPrompt();
                            fileName = Console.ReadLine();
                            ShowInstruction();
                            break;
                        case "volume":
                            Console.WriteLine("Enter new volume in percent");
                            byte volume = Convert.ToByte(Console.ReadLine());
                            player.SetVolume(volume).Wait();
                            ShowInstruction();
                            break;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Haven't got a clue, mate!");
                            break;
                    }

                    if (command == "exit") break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        

        /// <summary>
        /// Shows the file entry prompt
        /// </summary>
        private static void ShowFileEntryPrompt()
        {
            Console.WriteLine("Please enter the full path to the file you would like to play:");
        }

        /// <summary>
        /// Shows the instruction
        /// </summary>
        private static void ShowInstruction()
        {
            Console.WriteLine("You can manipulate the player with the following commands:");
            Console.WriteLine("play - Play the specified file from the start");
            Console.WriteLine("pause - Pause the playback");
            Console.WriteLine("resume - Resume the playback");
            Console.WriteLine("stop - Stop the playback");
            Console.WriteLine("volume - Set the volume");
            Console.WriteLine("exit - Exit the app");
        }

        /// <summary>
        /// Ons the playback finished using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void OnPlaybackFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Playback finished");
        }
    }
}
