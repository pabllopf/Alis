

using Alis.Core;
using Alis.Core.SFML;
using Alis.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Alis
{
    /// <summary>Example of videogame.</summary>
    public class Program
    {
        private static Crypted<string> passwd = new Crypted<string>("");


        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            VideoGame.Builder.Build().Run();



            /*VideoGame game = new VideoGame(new Config("name"), new Scene("Example"));
            LocalData.Save("Data", game);

            Thread.Sleep(2000);
            var gameloaded = LocalData.Load<VideoGame>("Data");

            //var configloaded = LocalData.Load<Config>("Data2");

            
            gameloaded.Run();*/


           /* VideoGame game = new VideoGame(
                new Config("Example33"),
                new Scene("First",
                    new GameObject("Player",
                        new Transform(new Vector3(0F), new Vector3(0f), new Vector3(2f)),
                        new AudioSource("menu.wav"),
                        new Sprite("tile000.png"),
                        new Collision(new Vector2(30, 55), false),

                        new Animator(0,
                                new Animation("MoveDown", 0, 0.1f, "tile000.png", "tile001.png", "tile002.png", "tile003.png"),
                                new Animation("MoveRight", 1, 0.1f, "tile017.png", "tile018.png", "tile019.png", "tile020.png"),
                                new Animation("MoveUp", 2, 0.1f, "tile034.png", "tile035.png", "tile036.png", "tile037.png"),
                                new Animation("MoveLeft", 3, 0.1f, "tile051.png", "tile052.png", "tile053.png", "tile054.png")
                        ),
                        new Move(),
                        new Camera(new Vector2(0f), new Vector2(640, 380))
                    ),

                    new GameObject("Player3",
                        new Transform(new Vector3(15f), new Vector3(0f), new Vector3(2f)),
                        new Sprite("tile001.png"),
                        new Collision(new Vector2(30, 55), false)
                    ),

                     new GameObject("Playere3",
                        new Transform(new Vector3(15f), new Vector3(0f), new Vector3(2f)),
                        new Sprite("tile001.png")
                        //new Collision()
                    )
                )
            );

            LocalData.Save("Example", game);
            Console.WriteLine("Saved game.");

            //game.Run();

            Thread.Sleep(2000);

            //Console.WriteLine("Loading game.");
            var gameloaded = LocalData.Load<VideoGame>("Example");

            //Console.WriteLine(gameloaded.Config.Name + ": nombre");

            gameloaded.Run();*/

            // Console.WriteLine("HHOLA");

            //Language.TranslateTo(Idiom.English);




            /*string decrypt = passwd.Get();
            passwd.Set("12345");


            var watch = new Stopwatch();
            watch.Start();

            var game = new VideoGame(
                new Config("Example"),
                new Scene("First",
                    new GameObject("Player",
                        new Transform(new Vector3(0F), new Vector3(0f), new Vector3(2f)),
                        new AudioSource("menu.wav"),
                        new Sprite("tile000.png"),
                        new Collision(),
                        new Camera(new System.Vector2f(0, 0), new System.Vector2f(640, 380)),

                        new Animator(0,
                                new Animation("MoveDown", 0, 0.1f, "tile000.png", "tile001.png", "tile002.png", "tile003.png"),
                                new Animation("MoveRight", 1, 0.1f, "tile017.png", "tile018.png", "tile019.png", "tile020.png"),
                                new Animation("MoveUp", 2, 0.1f, "tile034.png", "tile035.png", "tile036.png", "tile037.png"),
                                new Animation("MoveLeft", 3, 0.1f, "tile051.png", "tile052.png", "tile053.png", "tile054.png")
                        ),
                        new Move()
                    ),

                    new GameObject("Player3",
                        new Transform(new Vector3(15f), new Vector3(0f), new Vector3(2f)),
                        new Sprite("tile001.png"),
                        new Collision()
                    ),

                     new GameObject("Playere3",
                        new Transform(new Vector3(15f), new Vector3(0f), new Vector3(2f)),
                        new Sprite("tile001.png"),
                        new Collision()
                    )
                )
            ); 

            //game.Run();

            watch.Stop();
            Console.WriteLine($"RESULT: Videogame Time: " + watch.ElapsedMilliseconds + " ms \n");

            LocalData.Save("Example", game);



            Thread.Sleep(2000);

            Console.WriteLine("load game");

            var gameloaded = LocalData.Load<VideoGame>("Example");
            //gameloaded.Run();

            Thread.Sleep(1000);
            Console.WriteLine("RUN TEST TASK vs NORMAL: ");
            
            string name = Test_Normal(100);
            string name2 = await Test_Task(100);

            Console.WriteLine(name);
            Console.WriteLine(name2);

            Console.ReadLine();*/
        }

        private static async Task<string> Test_Task(int size)
        {
            var watch = new Stopwatch();
            watch.Start();

            await Task.WhenAll(GenerateTasks(size)); 
            
            watch.Stop();
            return $"Total Test_Task Time: " + watch.ElapsedMilliseconds + " ms";
        }

        private static List<Task> GenerateTasks(int size)
        {
            List<Task> result = new List<Task>();

            for (int i = 0; i < size; i++)
            {
                result.Add(ProcessAsync(i));
            }

            return result;
        }

        private static async Task ProcessAsync(int i ) 
        {
            await Task.Delay(new Random().Next(10, 100));
        }

        private static string Test_Normal(int size) 
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i =0; i < size;i++) 
            {
                Thread.Sleep(new Random().Next(10, 100));
            }

            watch.Stop();
            return $"Total Test_Normal Time: " + watch.ElapsedMilliseconds + " ms";
        }
    }

    
    /// <summary>
    ///   <br />
    /// </summary>
    public class Move : Component
    {
        private Transform transform;

        private Animator animator;

        private int speed = 1;

        /// <summary>Start this instance.</summary>
        public override void Start()
        {
            Input.OnPressKey += Input_OnPressKey1;

            animator = GameObject.Get<Animator>();
            transform = GameObject.Transform;
        }

        private void Input_OnPressKey1(object sender, Keyboard key)
        {
            if (key.Equals(Keyboard.S))
            {
                //Console.WriteLine("Press s");
                animator.State = 0;
                transform.YPos += 1 * speed;
            }

            if (key.Equals(Keyboard.D))
            {
                //Console.WriteLine("Press d");
                animator.State = 1;
                transform.XPos += 1 * speed;
            }

            if (key.Equals(Keyboard.W))
            {
                //Console.WriteLine("Press w");
                animator.State = 2;
                transform.YPos -= 1 * speed;
            }

            if (key.Equals(Keyboard.A))
            {
                //Console.WriteLine("Press a");
                animator.State = 3;
                transform.XPos -= 1 * speed;
            }
        }

        public override void Update()
        {
        }
    }

}
