

using System;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Audio.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        private static void Main(string[] args)
        {
            Player player = new Player();

            while (true)
            {
                Logger.Info("Write command 'play' | 'stop' | 'resume' | exit ");
                string command = Console.ReadLine();
                try
                {
                    switch (command)
                    {
                        case "play":
                            _ = player.Play("sample.wav");
                            break;
                        case "stop":
                            _ = player.Stop();
                            break;
                        case "resume":
                            _ = player.Resume();
                            break;
                    }

                    if (command == "exit")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while playing audio", ex);
                }
            }
        }
    }
}