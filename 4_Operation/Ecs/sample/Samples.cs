﻿using System;
using Frent.Components;
using Frent.Core;
using Frent.Systems;

namespace Frent.Sample
{
    internal class Samples
    {
        #region Cookbook 1
        [Sample]
        public static void Update_Component()
        {
            using World world = new World();

            //Create three entities
            for (int i = 0; i < 3; i++)
            {
                world.Create<ConsoleText>( new(ConsoleColor.Blue));
            }

            //Update the three entities
            world.Update();
        }
        #endregion

        #region Cookbook 2
        [Sample]
        public static void Uniforms_And_Entities()
        {
            DefaultUniformProvider uniforms = new DefaultUniformProvider();
            //add delta time as a float
            uniforms.Add(0.5f);

            using World world = new World(uniforms);

            world.Create<Vel>(default);
            world.Create<Pos>(default);

            world.Update();
        }
        #endregion

        #region Cookbook 3
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
        #endregion

        #region Cookbook 4
        [Sample]
        public static void Entities()
        {
            using World world = new World();
            Entity ent = world.Create<double>(2);
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
            ent.Deconstruct(out Ref<double> d);
            d.Value = 4;
            Console.WriteLine(d.Value);
        }
        #endregion
    }
    record struct Pos(float X) : IEntityComponent
    {
        public void Update(Entity entity)
        {
            Console.WriteLine(entity.Has<Vel>() ?
                "I have velocity!" :
                "No velocity here!");
        }
    }

    record struct Vel(float DX) : IUniformComponent<float, Pos>
    {
        public void Update(float dt, ref Pos pos)
        {
            pos.X += DX * dt;
        }
    }

    struct ConsoleText(ConsoleColor Color) : IComponent<string>
    {
        public void Update(ref string str)
        {
            Console.ForegroundColor = Color;
            Console.Write(str);
        }
    }

    internal struct WriteAction : IAction<int>
    {
        public void Run(ref int x) => Console.Write($"{x++}, ");
    }
}