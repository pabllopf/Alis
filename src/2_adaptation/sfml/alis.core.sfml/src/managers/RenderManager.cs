using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Alis.Core.SFML
{
    public class RenderManager : RenderSystem
    {
        private Configuration configuration;

        private RenderWindow renderWindow;

        private VideoMode videoMode;

        private List<Sprite> sprites;

        private CircleShape circleShape;

        private Text text;

        public RenderManager(Configuration configuration) : base(configuration)
        {
            this.configuration = configuration;
            videoMode = new VideoMode(512, 320);
            renderWindow = new RenderWindow(videoMode, $"{configuration.General.Name} | {configuration.General.Author}", Styles.Default);
            renderWindow.Closed += RenderWindow_Closed;

            sprites = new List<Sprite>();
            circleShape = new CircleShape(70);
            circleShape.FillColor = Color.Cyan;

            text = new Text("Default", new Font(@"C:\Users\wwwam\Documents\Repos\Alis\src\1_presentation\editor\alis.editor\resources\Hack-Italic.ttf"));
            text.FillColor = Color.White;
            text.Position = new Vector2f(40, 0);
            text.CharacterSize = 100;

            Console.WriteLine("Init.RenderManager()");

            sprites.Add(new Sprite());
        }

        public override void Awake()
        {
        }

        public override void Start() 
        {
        
        }

        public override void Update()
        {
            if (renderWindow is not null)
            {
                renderWindow.Clear();

                if (sprites is not null)
                {
                    if (sprites.Count > 0)
                    {
                        for (int i = 0; i < sprites.Count; i++)
                        {
                            renderWindow.Draw(circleShape);
                            renderWindow.Draw(text);
                        }
                    }
                }

                renderWindow.Display();
            }
        }

        public override void FixedUpdate()
        {
            if (renderWindow is not null)
            {
                renderWindow.DispatchEvents();
                Console.WriteLine($"{configuration.Time.CurrentFrame}");
                //text.DisplayedString =;
            }
        }

        private void RenderWindow_Closed(object? sender, EventArgs e)
        {
            if (renderWindow is not null)
            {
                renderWindow.Close();
            }
        }
    }
}