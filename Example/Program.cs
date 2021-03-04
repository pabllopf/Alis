using Alis.Core;
using Alis.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
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

            /*
            new VideoGame(
                new Config("Example"),
                    new Scene("MainMenu",
                        new GameObject("Player",
                            new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1)),
                            new Sprite("tile000.png", Application.ProjectPath, 1),
                            new Move(),
                            new Animator(0,
                                new Animation("MoveDown", 0, 0.1f, "tile000.png", "tile001.png", "tile002.png", "tile003.png"),
                                new Animation("MoveRight", 1, 0.1f, "tile017.png", "tile018.png", "tile019.png", "tile020.png"),
                                new Animation("MoveUp", 2, 0.1f, "tile034.png", "tile035.png", "tile036.png", "tile037.png"),
                                new Animation("MoveLeft", 3, 0.1f, "tile051.png", "tile052.png", "tile053.png", "tile054.png")
                            ),

                            new Camera(new System.Vector2f(0, 0), new System.Vector2f(640, 380))
                        ),
                         new GameObject("Player",
                            new Transform(new Vector3(4f), new Vector3(0f), new Vector3(1)),
                            new Sprite("tile000.png", Application.ProjectPath, 0)
                        ),

                        new GameObject("SoundTrack",
                            new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1)),
                            new AudioSource("menu.wav", Application.ProjectPath, true, 1f))
                    )
            );*/


            Config config = new Config("neame");
            config.Name = "trce";
            

            Console.ReadLine();
        }


    }


    /// <summary>
    ///   <br />
    /// </summary>
    public class Move : Component
    {
        private Transform transform;

        private Animator animator;


        private void Input_OnPressKey(object sender, Window.Keyboard.Key key)
        {
            if (key.Equals(Window.Keyboard.Key.S)) 
            {
                animator.State = 0;
                transform.Position += new Vector3(0, 0.1f, 0);
            }

            if (key.Equals(Window.Keyboard.Key.D))
            {
                animator.State = 1;
                transform.Position += new Vector3(0.1f, 0, 0);
            }

            if (key.Equals(Window.Keyboard.Key.W))
            {
                animator.State = 2;
                transform.Position += new Vector3(0, -0.1f, 0);
            }

            if (key.Equals(Window.Keyboard.Key.A))
            {
                animator.State = 3;
                transform.Position += new Vector3(-0.1f, 0, 0);
            }
        }

        /// <summary>Updates the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Update(GameObject gameObject)
        {
            //throw new global::System.NotImplementedException();
        }

        public override void Start()
        {
            Input.OnPressKey += Input_OnPressKey;

            //animator = (Animator)gameObject.Components.Find(i => i.GetType().Equals(typeof(Animator)));
            //transform = gameObject.Transform;

        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
