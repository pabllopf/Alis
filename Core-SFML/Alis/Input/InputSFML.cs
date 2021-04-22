namespace Alis.Core.SFML
{
    using global::SFML.Window;
    using System;
    using System.Threading.Tasks;

    /// <summary>Define the input</summary>
    public class InputSFML : Input
    {
        /// <summary>Initializes a new instance of the <see cref="InputSFML" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public InputSFML(Config config) : base(config)
        {
            Console.WriteLine("Define the input sfml");
        }

        /// <summary>Awakes this instance.</summary>
        /// <returns>Return none</returns>
        public override Task Awake()
        {
            return Task.Run(() =>
            {

            });
        }


        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        public override Task Start()
        {
            return Task.Run(() =>
            {

            });
        }


        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        public override Task Update()
        {
            return Task.Run(() =>
            {
                PollEvents();
            });
        }

        /// <summary>Fixed the update.</summary>
        /// <returns>Return none</returns>
        public override Task FixedUpdate()
        {
            return Task.Run(() =>
            {

            });
        }

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        public override Task Stop()
        {
            return Task.Run(() =>
            {

            });
        }

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        public override Task Exit()
        {
            return Task.Run(()=> 
            {
            
            });
        }

        /// <summary>Polls the events.</summary>
        public override void PollEvents()
        {
            foreach (Core.Keyboard key in Enum.GetValues(typeof(Core.Keyboard)))
            {
                var test = (Keyboard.Key)Enum.Parse(typeof(Keyboard.Key), key.ToString());
                if (Keyboard.IsKeyPressed(test))
                {
                    Keys.Add(key);
                    PressKeyOnce(key);
                }

                if (Keyboard.IsKeyPressed(test))
                {
                    PressKey(key);
                }

                if (!Keyboard.IsKeyPressed(test) && Keys.Contains(key))
                {
                    while (Keys.Contains(key)) 
                    {
                        Keys.Remove(key);
                    }

                    ReleaseKey(key);
                }
            }
        }
    }
}