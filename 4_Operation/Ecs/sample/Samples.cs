// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Samples.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Frent.Components;
using Frent.Core;
using Frent.Systems;

namespace Frent.Sample
{
    /// <summary>
    ///     The samples class
    /// </summary>
    internal class Samples
    {
        /// <summary>
        ///     Updates the component
        /// </summary>
        [Sample]
        public static void Update_Component()
        {
            using World world = new World();

            //Create three entities
            for (int i = 0; i < 3; i++)
            {
                world.Create<ConsoleText>(new(ConsoleColor.Blue));
            }

            //Update the three entities
            world.Update();
        }


        /// <summary>
        ///     Uniformses the and entities
        /// </summary>
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


        /// <summary>
        ///     Querieses
        /// </summary>
        [Sample]
        public static void Queries()
        {
            DefaultUniformProvider provider = new DefaultUniformProvider();
            provider.Add<byte>(5);
            using World world = new World(provider);

            for (int i = 0; i < 5; i++)
                world.Create(i);

            world.Query<With<int>>().Delegate((ref int x) => Console.Write($"{x++}, "));
            Console.WriteLine();

            world.Query<With<int>>().Inline<WriteAction, int>(default);
        }


        /// <summary>
        ///     Entitieses
        /// </summary>
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

        /// <summary>
        ///     The write action
        /// </summary>
        internal struct WriteAction : IAction<int>
        {
            /// <summary>
            ///     Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref int arg)
            {
                Console.Write($"{arg} ");
            }
        }
    }

    internal record struct Pos(float X) : IEntityComponent
    {
        /// <summary>
        ///     Updates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        public void Update(Entity entity)
        {
            Console.WriteLine(entity.Has<Vel>() ? "I have velocity!" : "No velocity here!");
        }
    }

    internal record struct Vel(float DX) : IUniformComponent<float, Pos>
    {
        /// <summary>
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="pos">The pos</param>
        public void Update(float dt, ref Pos pos)
        {
            pos.X += DX * dt;
        }
    }

    /// <summary>
    ///     The console text
    /// </summary>
    internal struct ConsoleText(ConsoleColor Color) : IComponent<string>
    {
        /// <summary>
        ///     Updates the str
        /// </summary>
        /// <param name="str">The str</param>
        public void Update(ref string str)
        {
            Console.ForegroundColor = Color;
            Console.Write(str);
        }
    }

    /// <summary>
    ///     The write action
    /// </summary>
    internal struct WriteAction : IAction<int>
    {
        /// <summary>
        ///     Runs the x
        /// </summary>
        /// <param name="x">The </param>
        public void Run(ref int x) => Console.Write($"{x++}, ");
    }
}