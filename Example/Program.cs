using Alis.Core;
using Alis.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace SFML
{
    /// <summary>Example of videogame.</summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();

            new VideoGame(
                new Config("Example"),
                    new Scene("First",
                       new GameObject("Player24724", new Transform(new Vector3(10f, 10f, 0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite(),
                            new Collision()
                        ),

                        new GameObject("Player", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite(),
                            new Animator(0,
                                new Animation("MoveDown", 0, 0.1f, "tile000.png", "tile001.png", "tile002.png", "tile003.png"),
                                new Animation("MoveRight", 1, 0.1f, "tile017.png", "tile018.png", "tile019.png", "tile020.png"),
                                new Animation("MoveUp", 2, 0.1f, "tile034.png", "tile035.png", "tile036.png", "tile037.png"),
                                new Animation("MoveLeft", 3, 0.1f, "tile051.png", "tile052.png", "tile053.png", "tile054.png")
                            ),
                            new Move(),
                            new Camera(new System.Vector2f(0, 0), new System.Vector2f(640, 380)),
                            new Collision()
                        ),

                       new GameObject("SoundTrack", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new AudioSource()
                        ),
                        new GameObject("Player2474", new Transform(new Vector3(-5f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                            
                        )
                    )
            ).Run();

            watch.Stop();
            Console.WriteLine($"RESULT: Videogame Time: " + watch.ElapsedMilliseconds + " ms \n");


            Thread.Sleep(1000);
            Console.WriteLine("RUN TEST TASK vs NORMAL: ");
            
            string name = Test_Normal(100);
            string name2 = await Test_Task(100);

            Console.WriteLine(name);
            Console.WriteLine(name2);
            
            Console.ReadLine();
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

        public override void Start()
        {
            Input.OnPressKey += Input_OnPressKey;

            animator = GetGameObject().GetComponent<Animator>();
            transform = GetGameObject().Transform;
        }

        public override void Update()
        {
        }

        private void Input_OnPressKey(object sender, Window.Keyboard.Key key)
        {
            if (key.Equals(Window.Keyboard.Key.S))
            {
                //Console.WriteLine("Press s");
                animator.State = 0;
                transform.Position += new Vector3(0, 1, 0);
            }

            if (key.Equals(Window.Keyboard.Key.D))
            {
                //Console.WriteLine("Press d");
                animator.State = 1;
                transform.Position += new Vector3(1f, 0, 0);
            }

            if (key.Equals(Window.Keyboard.Key.W))
            {
                //Console.WriteLine("Press w");
                animator.State = 2;
                transform.Position += new Vector3(0, -1f, 0);
            }

            if (key.Equals(Window.Keyboard.Key.A))
            {
                //Console.WriteLine("Press a");
                animator.State = 3;
                transform.Position += new Vector3(-1f, 0, 0);
            }
        }
    }

}
