namespace Alis.Core.SFML
{
    using System;
    using Alis.Tools;

    /// <summary>Define the input</summary>
    public class InputSFML : Input
    {
        /// <summary>Initializes a new instance of the <see cref="InputSFML" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public InputSFML(Config config) : base(config)
        {
        }

        /// <summary>Awakes this instance.</summary>
        /// <returns>Return none</returns>
        public override void Awake()
        {
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        public override void Start()
        {
        }

        

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        public override void Update()
        {
            if (RenderSFML.CurrentRenderSFML.RenderWindow != null)
            {
                foreach (Keyboard keylog in Enum.GetValues(typeof(Keyboard)))
                {
                    global::SFML.Window.Keyboard.Key TEST = (global::SFML.Window.Keyboard.Key)Enum.Parse(typeof(global::SFML.Window.Keyboard.Key), keylog.ToString());

                    if (TEST != null)
                    {
                        if (global::SFML.Window.Keyboard.IsKeyPressed(TEST))
                        {
                            if (!Keys.Contains(keylog))
                            {
                                Keys.Add(keylog);
                            }

                            PressKey(keylog);
                        }

                        if (!global::SFML.Window.Keyboard.IsKeyPressed(TEST) && Keys.Contains(keylog))
                        {
                            Keys.Remove(keylog);
                            ReleaseKey(keylog);
                        }
                    }
                }
            }

            if (RenderSFML.CurrentRenderSFML.RenderTexture != null)
            {
                foreach (Keyboard keylog in Enum.GetValues(typeof(Keyboard)))
                {
                    global::SFML.Window.Keyboard.Key TEST = (global::SFML.Window.Keyboard.Key)Enum.Parse(typeof(global::SFML.Window.Keyboard.Key), keylog.ToString());

                    if (TEST != null)
                    {
                        if (global::SFML.Window.Keyboard.IsKeyPressed(TEST))
                        {
                            if (!Keys.Contains(keylog))
                            {
                                Keys.Add(keylog);
                            }

                            PressKey(keylog);
                        }

                        if (!global::SFML.Window.Keyboard.IsKeyPressed(TEST) && Keys.Contains(keylog))
                        {
                            Keys.Remove(keylog);
                            ReleaseKey(keylog);
                        }
                    }
                }
            }

        }

        
        /// <summary>Fixed the update.</summary>
        /// <returns>Return none</returns>
        public override void FixedUpdate()
        {
        }

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        public override void Stop()
        {
        }

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        public override void Exit()
        {
        }
    }
}