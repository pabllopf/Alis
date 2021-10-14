namespace Alis.Core.Example
{
    using System;
    using System.Numerics;

    public class Program
    {
        static void Main(string[] args)
        {

            GameObject gameObject = new GameObject("Player");
            gameObject.Add(new Sprite());
            gameObject.Add(new Particle());

            Console.WriteLine($"Gameobject {gameObject.Name} has {gameObject.Components.Length} component");

            gameObject.Remove<Sprite>();
            gameObject.Remove<Sprite>();

            Console.WriteLine($"Gameobject {gameObject.Name} has {gameObject.Components.Length} component");


            Vector3 vector1 = new(1, 1, 1);
            Vector3 vector2 = new(1, 1, 1);

            Console.WriteLine(vector2 - vector1);

            var gameObject1 =
                GameObject.Create()
                    .WithName("Alfredo")
                .Build();


            GameObject gameObject2 =
                GameObject.Create()
                .Build();


            Console.WriteLine($"Player 1={gameObject1.Name.Value} tag={gameObject1.Tag.Value} Length={gameObject1.Components.Length} | Player 2 = {gameObject2.Name.Value} tag={gameObject2.Tag.Value} Length={gameObject2.Components.Length}");


            Console.WriteLine("process end");
            Console.ReadKey();
        }
    }
}
