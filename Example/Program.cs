using System;
using Alis.Core;
using Alis.Tools;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace SFML
{
    class Program
    {
        //private static RenderWindow _window;

        //static RenderWindow renderWindow;

        static void Main(string[] args)
        {
            new VideoGame(
                new ConfigGame("Example"),
                    new Scene("MainMenu", 
                        new GameObject("Player", new Alis.Core.Sprite("Caramelo.png", Application.DesktopPath + ""))
                
                    )
                
                ).Run();

            /*renderWindow = new RenderWindow(new VideoMode(630, 380), "Prueba");
            renderWindow.Closed += RenderWindow_Closed;


            SFML.Graphics.Texture texture = new Texture(Application.DesktopPath + "/Caramelo.png");
            texture.Smooth = true;
            SFML.Graphics.Sprite sprite = new Graphics.Sprite(texture);
            sprite.Scale = new System.Vector2f(2f, 2f);

            while (renderWindow.IsOpen) 
            {
                renderWindow.Clear();

                renderWindow.Draw(sprite);

                renderWindow.Display();
            }
           */
        }

        /*private static void RenderWindow_Closed(object sender, EventArgs e)
        {
            renderWindow.Close();
        }*/




        /*
        _window = new RenderWindow(new VideoMode(800, 600), "SFML window");
        _window.SetVisible(true);
        _window.Closed += new EventHandler(OnClosed);
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            _window.Clear(Color.Red);
            _window.Display();
        }

        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    private static void OnClosed(object sender, EventArgs e)
    {
        _window.Close();
    }*/
    }
}
