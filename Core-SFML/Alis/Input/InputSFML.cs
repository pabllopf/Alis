namespace Alis.Core.SFML
{
    using System.Threading.Tasks;

    public class InputSFML : Input
    {
        public InputSFML(Config config) : base(config)
        {
        }

        public override Task Awake()
        {
            return Task.Run(()=> { });
        }

        public override Task FixedUpdate()
        {
            return Task.Run(() => { });
        }

        public override Task Start()
        {
            return Task.Run(() => { });
        }

        public override Task Update()
        {
            return Task.Run(() => { });
        }
    }
}


/*
 /// <summary>The keys</summary>
        private static List<Keyboard> keys = new List<Keyboard>();

        /// <summary>Occurs when [on press key].</summary>
        public static event EventHandler<Keyboard> OnPressKey;

        /// <summary>Occurs when [on press once].</summary>
        public static event EventHandler<Keyboard> OnPressKeyOnce;

        public Input(Config config)
        {
        }

        internal Task Awake() 
        {
            return Task.Run(() => 
            {
            });
        }

        internal Task Start()
        {
            return Task.Run(() =>
            {
            });
        }

        internal Task Update() 
        {
            return Task.Run(() =>
            {
                PollEvents();
            });
        }

        internal Task FixedUpdate()
        {
            return Task.Run(() =>
            {
            });
        }

        internal Task Exit()
        {
            return Task.Run(() =>
            {
            });
        }

        /// <summary>Polls the events.</summary>
        internal void PollEvents()
        {
            foreach (Keyboard key in Enum.GetValues(typeof(Keyboard)))
            {
                if (IsKeyPressed(key) && !keys.Contains(key))
                {
                    keys.Add(key);
                    OnPressKeyOnce?.Invoke(key, key);
                }

                if (IsKeyPressed(key))
                {
                    OnPressKey?.Invoke(key, key);
                }
               
                if (!IsKeyPressed(key) && keys.Contains(key))
                {
                    keys.Remove(key);
                }
            }
        }

        internal abstract bool IsKeyPressed(Keyboard key);

        internal Task Stop()
        {
            return Task.Run(() =>
            {
            });
        }
 
 */
