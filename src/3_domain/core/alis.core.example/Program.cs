namespace Alis.Core.Example
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {

            GameObject gameObject = new GameObject("Player");
            gameObject.Add(new Sprite());
            gameObject.Add(new Particle());

            Console.WriteLine($"Gameobject {gameObject.Name} has {gameObject.NumOfComponents} component");

            gameObject.Remove<Sprite>();
            gameObject.Remove<Sprite>();

            Console.WriteLine($"Gameobject {gameObject.Name} has {gameObject.NumOfComponents} component");

            Console.WriteLine("process end");
            Console.ReadKey();
        }
    }
}
