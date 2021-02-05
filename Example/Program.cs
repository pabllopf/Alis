using SFML.Graphics;
using System;
using SFML.Window;

namespace Example
{
    class Program
    {
        private static RenderWindow render;

        static void Main(string[] args)
        {
            render = new RenderWindow(new VideoMode(640, 480), "Hola");
            render.SetActive(true);
            render.SetVisible(true);

            CircleShape circle = new CircleShape(100);

            while (render.IsOpen) 
            {
                render.Clear(Color.Blue);
                render.Draw(circle);
                render.Display();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
