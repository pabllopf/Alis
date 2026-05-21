

using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Dino.Desktop
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            VideoGame
                .Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("T-Rex Dino Game")
                        .Author("Pablo Perdomo Falcón")
                        .Description("T-Rex Dino Game")
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(800, 600)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(soundTrack => soundTrack
                            .Build())
                        .Build())
                    .Build())
                .Build()
                .Run();
        }
    }
}