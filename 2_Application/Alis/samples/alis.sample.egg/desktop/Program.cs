

using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Egg.Desktop
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
                        .Name("The Egg")
                        .Author("Pablo Perdomo Falcón")
                        .Description("T-Rex Dino Game")
                        .License("GNU General Public License v3.0")
                        .Icon("app.ico")
                    )
                    .Audio(audio => audio
                        .Volume(50)
                    )
                    .Graphic(graphic => graphic
                        .Resolution(800, 600)
                    )
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                    )
                )
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(soundTrack => soundTrack
                            .Name("Sound Track")
                        )
                    )
                )
                .Run();
        }
    }
}