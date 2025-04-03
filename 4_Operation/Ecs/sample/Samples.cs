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
using System.Threading;
using Alis.Core.Ecs.Comps;
using Alis.Core.Ecs.Operations;
using Alis.Core.Ecs.Sample.Components;

namespace Alis.Core.Ecs.Sample
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
        ///     Updates the component
        /// </summary>
        [Sample]
        public static void Create_Component()
        {
            using World world = new World();

            //Create three entities
            for (int i = 0; i < 100_000; i++)
            {
                world.Create<ConsoleText>(new(ConsoleColor.Blue));
            }
        }
        
        /// <summary>
        /// The id
        /// </summary>
        private static readonly EntityType _entityAlisType = Entity.EntityTypeOf([Component<Component1>.ID], []);
        
        /// <summary>
        /// Creates the entity
        /// </summary>
        [Sample]
        public static void Create_Entity()
        {
            using World world = new World();
            
            world.EnsureCapacity(_entityAlisType, 1000);

            for (int i = 0; i < 1000; i++)
            {
                Entity entity = world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11), default(Component12), default(Component13), default(Component14), default(Component15), default(Component16));
                Console.WriteLine(entity.EntityID);
            }
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

            world.Create<Vel, Pos>(default(Vel), default(Pos));
            world.Create<Pos>(default(Pos));

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
            {
                world.Create(i);
            }

            world.Query<With<int>>().Delegate((ref int x) => Console.Write($"{x++}, "));
            Console.WriteLine();

            world.Query<With<int>>().Inline<WriteAction, int>(default(WriteAction));
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
            ent.Add<string>("I like Alis");

            if (ent.TryGet<string>(out Ref<string> strRef))
            {
                Console.WriteLine(strRef);
                //reassign the string value
                strRef.Value = "Do you like Alis?";
            }

            //If we didn't add a string earlier, this would throw instead
            Console.WriteLine(ent.Get<string>());

            //You can also deconstruct components from the entity to reassign many at once
            ent.Deconstruct(out Ref<double> d);
            d.Value = 4;
            Console.WriteLine(d.Value);
        }

        /// <summary>
        /// Simples the game
        /// </summary>
        [Sample]
        public static void SimpleGame()
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


        /// <summary>
        /// The position
        /// </summary>
        struct Position(int x, int y)
        {
            /// <summary>
            /// The 
            /// </summary>
            public int X = x;
            /// <summary>
            /// The 
            /// </summary>
            public int Y = y;
        }

        /// <summary>
        /// The velocity
        /// </summary>
        struct Velocity(int dx, int dy) : IEntityComponent, IInitable
        {
            /// <summary>
            /// The dx
            /// </summary>
            public int DX = dx;
            /// <summary>
            /// The dy
            /// </summary>
            public int DY = dy;

            public void Init(Entity self)
            {
                Console.WriteLine("Init");
            }

            public void Update(Entity self)
            {
                self.Get<Position>().X += DX;
                self.Get<Position>().Y += DY;
            }
        }

        /// <summary>
        /// The character
        /// </summary>
        struct Character(char c) : IEntityComponent
        {
            /// <summary>
            /// The 
            /// </summary>
            public char Char = c;
            
            public void Update(Entity self)
            {
                Position pos = self.Get<Position>();
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write(Char);
            }
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

    internal record struct Vel(float DX) : IInitable, IEntityComponent
    {
        public void Update(Entity self)
        {
           Console.WriteLine("entity update:" + self.EntityID);
        }

        public void Init(Entity self)
        {
            Console.WriteLine("entiti init vel: " + self.EntityID);
        }
    }

    /// <summary>
    ///     The console text
    /// </summary>
    internal struct ConsoleText(ConsoleColor Color) : IEntityComponent
    {

        public void Update(Entity self)
        {
            Console.ForegroundColor = Color;
            Console.Write(self.Get<string>());
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