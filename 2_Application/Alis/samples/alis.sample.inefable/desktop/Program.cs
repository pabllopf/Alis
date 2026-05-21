

using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;

namespace Alis.Sample.Inefable.Desktop
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
                        .Name("Inefable")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Roguelike 2D multiplayer with RPG and arcade components")
                        .Debug(false)
                        .License("GNU General Public License v3.0")
                        .Icon("app.ico")
                        .Build()
                    )
                    .Audio(audio => audio
                        .Volume(100)
                    )
                    .Graphic(graphic => graphic
                        .Resolution(1024, 768)
                    )
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                    )
                )
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Name("Dungeon Entrance")
                        .Add<GameObject>(camera => camera
                            .Name("Main Camera")
                            .Transform(trasform => trasform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1.0f, 1.0f)
                            )
                            .WithComponent<Camera>(cam => cam
                                .Resolution(1024, 768)
                            )
                        )
                        .Add<GameObject>(background => background
                            .Name("Background")
                            .Tag("Environment")
                            .Transform(trasform => trasform
                                .Position(0, 0)
                                .Rotation(0)
                                .Scale(1.0f, 1.0f)
                            )
                            .WithComponent<Sprite>(sprite => sprite
                                .Depth(-3)
                                .SetTexture("Draw001.bmp")
                                .Build()
                            )
                        )
                    )
                )
                .Run();
        }
    }
}