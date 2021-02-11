using Alis.Core;
using Alis.Tools;
using System.Numerics;

namespace SFML
{
    /// <summary>Example of videogame.</summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            new VideoGame(
                new ConfigGame("Example"),
                    new Scene("MainMenu",
                        new GameObject("Player",
                            new Transform(new Vector3(0f), new Vector3(0f),new Vector3(1)), 
                            new Sprite("alis.png", Application.ProjectPath, 1)),

                          new GameObject("Player",
                            new Transform(new Vector3(100f), new Vector3(1f), new Vector3(1)),
                            new Sprite("alis.png", Application.ProjectPath, -1)),

                        new GameObject("SoundTrack",
                            new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1)),
                            new AudioSource("soundtrack.wav", Application.ProjectPath, true, 1f))
                    )
            ).Run();
        }
    }       
}
