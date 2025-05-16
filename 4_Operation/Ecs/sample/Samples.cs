using System;
using System.Threading;
using Alis.Core.Ecs.Sample.Components;
using Alis;
using Alis.Core;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample
{
    internal class Samples
    {
    
        [Sample]
        public static void Update_Component()
        {
            using World world = new World();

            //Create three entities
            for (int i = 0; i < 3; i++)
            {
                world.Create<string, ConsoleText>("Hello, World!", new(ConsoleColor.Blue));
            }

            //Update the three entities
            world.Update();
        }
    
    
        [Sample]
        public static void Update_Systems()
        {
            using World world = new World();

            //Create three entities
            for (int i = 0; i < 3; i++)
            {
                world.Create<string, ConsoleText>("Hello, World!", new(ConsoleColor.Blue));
            }

            foreach (RefTuple<string> stringsRefTuple in world.Query<With<string>>().Enumerate<string>())
            {
                //Get the string reference
                Ref<string> strRef = stringsRefTuple.Item1;

                //Update the string value
                strRef.Value += "!!!!! <> !!!!!";
            }
        
            world.Update();
        }
  


        [Sample]
        public static void Uniforms_And_Entities()
        {
            DefaultUniformProvider uniforms = new DefaultUniformProvider();
            //add delta time as a float
            uniforms.Add(0.5f);

            using World world = new World(uniforms);

            world.Create<Vel, Pos>(default, default);
            world.Create<Pos>(default);

            world.Update();
        }
    
        [Sample]
        public static void Uniforms_And_Entities_initeable()
        {
            DefaultUniformProvider uniforms = new DefaultUniformProvider();
            //add delta time as a float
            uniforms.Add(0.5f);
    
            using World world = new World(uniforms);
        
            world.Create<Pos2>(default);
            world.Create<Pos2, Vel2>(default, default);
    
            world.Update();
        }
    
        [Sample]
        public static void Simple_Game()
        {
            World world = new World();

            //create
            Entity entity = world.Create<Position, Velocity, Character>(new(4, 6), new(2, 0), new('@'));

            //simulate 20 frames
            for (int i = 0; i < 20; i++)
            {
                world.Update();
                Thread.Sleep(100);
                Console.Clear();
            }

            Position finalPos = entity.Get<Position>();
            Console.WriteLine($"Position: X: {finalPos.X} Y: {finalPos.Y}");
        }
    
    
    
        [Sample]
        public static void Queries()
        {
            DefaultUniformProvider provider = new DefaultUniformProvider();
            provider.Add<byte>(5);
            using World world = new World(provider);

            for (int i = 0; i < 5; i++)
                world.Create<int>(i);

            world.Query<With<int>>().Delegate((ref int x) => Console.Write($"{x++}, "));
            Console.WriteLine();
        
            world.Query<With<int>>().Inline<WriteAction, int>(default);
        }

        internal struct WriteAction : IAction<int>
        {
            public void Run(ref int arg)
            {
                Console.Write($"{arg} ");
            }
        }
        
        [Sample]
        public static void Entities()
        {
            using World world = new World();
            Entity ent = world.Create<int, double, float>(69, 3.14, 2.71f);
            //true
            Console.WriteLine(ent.IsAlive);
            //true
            Console.WriteLine(ent.Has<int>());
            //false
            Console.WriteLine(ent.Has<bool>());
            //You can also add and remove components
            ent.Add<string>("I like Frent");

            if (ent.TryGet<string>(out Ref<string> strRef))
            {
                Console.WriteLine(strRef);
                //reassign the string value
                strRef.Value = "Do you like Frent?";
            }

            //If we didn't add a string earlier, this would throw instead
            Console.WriteLine(ent.Get<string>());

            //You can also deconstruct components from the entity to reassign many at once
            ent.Deconstruct(out Ref<double> d, out Ref<int> i, out Ref<float> f, out Ref<string> str);
            d.Value = 4;
            str.Value = "Hello, World!";
        
            Console.WriteLine(str);
        }
    }
}
