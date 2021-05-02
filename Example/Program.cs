//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Main.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Example
{
    using Alis.Core;
    using Alis.Core.SFML;
    using System;
    using System.Linq;
    using System.Net;
    using System.Numerics;
    using System.Reflection;


    /// <summary>Example of videogame.</summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            


        

            
            VideoGame.Builder()
                .Config(Config.Builder()
                            .Name("Alis Game")
                            .Author("Pablo Perdomo Falcón")
                            .Time(Time.Builder()
                                .TimeStep(0.01f)
                                .TimeScale(1.0f)
                                .LimitFrameRate(false)
                                .Build())
                            .Window(WindowManager.Builder()
                                    .Resolution(1024, 640)
                                    .WindowState(WindowState.Normal)
                                    .Build())
                            .Build())

                .SceneManager(SceneManager.Builder()
                                .Scene(Scene.Builder()
                                            .Name("MainScene")
                                            .GameObject(GameObject.Builder()
                                                            .Name("player")
                                                            .Transform(new Transform(new Vector3(-5.0f), new Vector3(0.0f), new Vector3(2.0f)))
                                                            .Component(new Sprite("tile000.png"))
                                                            .Component(new AudioSource("menu.wav"))
                                                            .Component(new Collision(new Vector2(30, 55), false))
                                                            .Component(new Animator(0,
                                                                        new Animation("MoveDown", 0, 0.1f, "tile000.png", "tile001.png", "tile002.png", "tile003.png"),
                                                                        new Animation("MoveRight", 1, 0.1f, "tile017.png", "tile018.png", "tile019.png", "tile020.png"),
                                                                        new Animation("MoveUp", 2, 0.1f, "tile034.png", "tile035.png", "tile036.png", "tile037.png"),
                                                                        new Animation("MoveLeft", 3, 0.1f, "tile051.png", "tile052.png", "tile053.png", "tile054.png")
                                                            ))

                                                            .Component(new Move())
                                                            .Component(new Camera(new Vector2(0f), new Vector2(640, 380)))
                                                            .Build())

                                            .GameObject(GameObject.Builder()
                                                            .Name("enemy")
                                                            .Transform(new Transform(new Vector3(45.0f), new Vector3(0.0f), new Vector3(2.0f)))
                                                            .Component(new Sprite("tile001.png"))
                                                            .Component(new Collision(new Vector2(30, 55), false))
                                                            .Build())
                                            .Build())

                                .Scene(Scene.Builder().Name("SecondScene")
                                    .GameObject(GameObject.Builder()
                                                            .Name("enemy4")
                                                            .Transform(new Transform(new Vector3(45.0f), new Vector3(0.0f), new Vector3(2.0f)))
                                                            .Component(new Sprite("tile001.png"))
                                                            .Component(new Collision(new Vector2(30, 55), false))
                                                            .Build())

                                .Build())
                  .Build())
            .Run();
        }
    }
}