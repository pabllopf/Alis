using System;
using System.IO;
using System.Threading.Tasks;

using CryMediaAPI;
using CryMediaAPI.Audio;
using CryMediaAPI.Encoding.Builders;
using CryMediaAPI.Video;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Path.Combine(Directory.GetCurrentDirectory(), "sample.mp4");
            string output = Path.Combine(Directory.GetCurrentDirectory(), "sample_out.mp4");

            //var player = new VideoPlayer(input);
            //player.Play();
            
            ConvertVideo(input, output);

            // ReadWriteAudio(input, output);
            // ReadWriteVideo(input, output);

            // ReadPlayAudio(input, output);
            // ReadPlayVideo(input, output);

            SaveVideoFrame(input);
            
            Console.WriteLine($"Press any key to exit");
            Console.ReadKey();
        }

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

        static void ReadWriteVideo(string input, string output)
        {
            VideoReader video = new VideoReader(input);
            video.LoadMetadataAsync().Wait();
            video.Load();

            using (VideoWriter writer = new VideoWriter(File.Create(output),
                video.Metadata.Width, video.Metadata.Height, video.Metadata.AvgFramerate,
                new H264Encoder() { Format = "flv" }.Create()))
            {
                writer.OpenWrite(true);
                //video.CopyTo(writer);

                VideoFrame frame = new VideoFrame(video.Metadata.Width, video.Metadata.Height);
                while (true)
                {
                    // read next frame
                    VideoFrame f = video.NextFrame(frame);
                    if (f == null) break;


                    for (int i = 0; i < 100; i++)
                        for (int j = 0; j < 100; j++)
                        {
                            Span<byte> px = frame.GetPixels(i, j).Span;
                            px[0] = 255;
                            px[1] = 0;
                            px[2] = 0;
                        }

                    writer.WriteFrame(frame);
                }
            }
        }

        static void ReadPlayVideo(string input, string output)
        {
            VideoReader video = new VideoReader(input);
            video.LoadMetadataAsync().Wait();
            video.Load();

            using (VideoPlayer player = new VideoPlayer())
            {
                player.OpenWrite(video.Metadata.Width, video.Metadata.Height, video.Metadata.AvgFramerateText);

                // For simple playing, can just use "CopyTo"
                // video.CopyTo(player);

                VideoFrame frame = new VideoFrame(video.Metadata.Width, video.Metadata.Height);
                while (true)
                {
                    // read next frame
                    VideoFrame f = video.NextFrame(frame);
                    if (f == null) break;


                    for (int i = 0; i < 100; i++)
                        for (int j = 0; j < 100; j++)
                        {
                            Span<byte> px = frame.GetPixels(i, j).Span;
                            px[0] = 255;
                            px[1] = 0;
                            px[2] = 0;
                        }

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

        static void SaveVideoFrame(string input)
        {
            VideoReader video = new VideoReader(input);
            video.LoadMetadataAsync().Wait();
            video.Load(30);

            VideoFrame fr = video.NextFrame();
            fr.Save("test.png");
            Console.WriteLine("Frame saved");
        }

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
