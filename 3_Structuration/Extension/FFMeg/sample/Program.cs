// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Extension.FFMeg.Audio;
using Alis.Core.Extension.FFMeg.Encoding.Builders;
using Alis.Core.Extension.FFMeg.Video;

namespace Alis.Core.Extension.FFMeg.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
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

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        /// <summary>
        ///     Reads the write audio using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        private static void ReadWriteAudio(string input, string output)
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
        ///     Reads the play audio using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        private static void ReadPlayAudio(string input, string output)
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
                    catch (IOException)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Saves the video frame using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        private static void SaveVideoFrame(string input)
        {
            VideoReader video = new VideoReader(input);
            video.LoadMetadataAsync().Wait();
            video.Load(3);

            VideoFrame fr = video.NextFrame();
            fr.Save("test.png");
            Console.WriteLine("Frame saved");
        }

        /// <summary>
        ///     Converts the video using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        private static void ConvertVideo(string input, string output)
        {
            VP9Encoder encoder = new VP9Encoder();
            encoder.RowBasedMultithreading = true;
            encoder.SetCQP();

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