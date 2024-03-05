using System;
using System.IO;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Extension.FFMeg.Audio;
using Alis.Core.Extension.FFMeg.Encoding.Builders;
using Alis.Core.Extension.FFMeg.Video;

namespace Alis.Core.Extension.FFMeg.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        static void Main(string[] args)
        {
            string input = AssetManager.Find("sample.mp4");
            string output = Path.Combine(Directory.GetCurrentDirectory(), "sample_out.mp4");

            //SdlController.Run();
            
            var player = new VideoPlayer(input);
            player.Play();
            
            //ConvertVideo(input, output);

            //ReadWriteAudio(input, output);
            
            //ReadPlayAudio(input, output);
            
            SaveVideoFrame(input);
            
            Console.WriteLine($"Press any key to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// Reads the write audio using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        static void ReadWriteAudio(string input, string output)
        {
            AudioReader audio = new AudioReader(input);
            audio.LoadMetadataAsync().Wait();
            audio.Load();

            using (AudioWriter writer = new AudioWriter(output, audio.Metadata.Channels, audio.Metadata.SampleRate))
            {
                writer.OpenWrite(true);

                AudioFrame frame = new AudioFrame(1);
                while (true)
                {
                    // read next sample
                    AudioFrame f = audio.NextFrame(frame);
                    if (f == null) break;

                    writer.WriteFrame(frame);
                }
            }
        }

        /// <summary>
        /// Reads the play audio using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        static void ReadPlayAudio(string input, string output)
        {
            AudioReader audio = new AudioReader(input);
            audio.LoadMetadataAsync().Wait();
            audio.Load();

            using (AudioPlayer player = new AudioPlayer())
            {
                player.OpenWrite(audio.Metadata.SampleRate, audio.Metadata.Channels, showWindow: false);

                // For simple playing, can just use "CopyTo"
                // audio.CopyTo(player);

                AudioFrame frame = new AudioFrame(audio.Metadata.Channels);
                while (true)
                {
                    // read next frame
                    AudioFrame f = audio.NextFrame(frame);
                    if (f == null) break;

                    try
                    {
                        player.WriteFrame(frame);
                    }
                    catch (IOException) { break; }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Saves the video frame using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        static void SaveVideoFrame(string input)
        {
            VideoReader video = new VideoReader(input);
            video.LoadMetadataAsync().Wait();
            video.Load(3);

            VideoFrame fr = video.NextFrame();
            fr.Save("test.png");
            Console.WriteLine("Frame saved");
        }

        /// <summary>
        /// Converts the video using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        static void ConvertVideo(string input, string output)
        {
            VP9Encoder encoder = new VP9Encoder();
            encoder.RowBasedMultithreading = true;
            encoder.SetCQP(31);

            using (VideoReader reader = new VideoReader(input))
            {
                reader.LoadMetadata();
                reader.Load();

                using (VideoWriter writer = new VideoWriter(output,
                    reader.Metadata.Width,
                    reader.Metadata.Height,
                    reader.Metadata.AvgFramerate,
                    encoder.Create()))
                {
                    writer.OpenWrite(true);
                    reader.CopyTo(writer);
                }
            }
        }
    }
}
