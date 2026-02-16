using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.King.Platform.Web
{
    /// <summary>
    /// The game class
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// Creates
        /// </summary>
        /// <returns>The video game</returns>
        public static VideoGame Create()
        {
            return VideoGame.Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("King Game")
                        .Author("Pablo Perdomo Falcón")
                        .Description("King platform 2d game.")
                        .Debug(false)
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(640, 480)
                        .BackgroundColor(Color.Cyan)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene

                        // PLAYER
                        .Add<GameObject>(player => player
                            .Transform(transform => transform
                                .Position(0, 2)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .WithComponent<Sprite>(sprite => sprite
                                .Depth(1)
                                .SetTexture("tile023.bmp")
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .Size(1, 1)
                                .Mass(1.0f)
                                .Restitution(0.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .WithComponent<Camera>(camera => camera
                                .Resolution(640, 480))
                            .Build())

                        // FLOOR
                        .Add<GameObject>(gameObject => gameObject
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(20, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build();
        }
    }
}

