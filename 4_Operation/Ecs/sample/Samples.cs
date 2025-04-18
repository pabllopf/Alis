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
using Alis.Core.Aspect.Fluent;
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
        ///     The id
        /// </summary>
        private static readonly EntityType _entityAlisType = GameObject.EntityTypeOf([Component<Component1>.ID], []);

        /// <summary>
        ///     Updates the component
        /// </summary>
        [Sample]
        public static void Update_Component()
        {
            using Scene scene = new Scene();

            //Create three entities
            for (int i = 0; i < 3; i++)
            {
                scene.Create<ConsoleText>(new(ConsoleColor.Blue));
            }

            //Update the three entities
            scene.Update();
        }

        /// <summary>
        ///     Updates the component
        /// </summary>
        [Sample]
        public static void Create_Component()
        {
            using Scene scene = new Scene();

            //Create three entities
            for (int i = 0; i < 100_000; i++)
            {
                scene.Create<ConsoleText>(new(ConsoleColor.Blue));
            }
        }

        /// <summary>
        ///     Creates the entity
        /// </summary>
        [Sample]
        public static void Create_Entity()
        {
            using Scene scene = new Scene();

            scene.EnsureCapacity(_entityAlisType, 1000);

            for (int i = 0; i < 1000; i++)
            {
                GameObject gameObject = scene.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11), default(Component12), default(Component13), default(Component14), default(Component15),
                    default(Component16));
                Console.WriteLine(gameObject.EntityID);
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

            using Scene scene = new Scene(uniforms);

            scene.Create(default(Vel), default(Pos));
            scene.Create(default(Pos));

            scene.Update();
        }


        /// <summary>
        ///     Querieses
        /// </summary>
        [Sample]
        public static void Queries()
        {
            DefaultUniformProvider provider = new DefaultUniformProvider();
            provider.Add<byte>(5);
            using Scene scene = new Scene(provider);

            for (int i = 0; i < 5; i++)
            {
                scene.Create(i);
            }

            scene.Query<With<int>>().Delegate((ref int x) => Console.Write($"{x++}, "));
            Console.WriteLine();
        }


        /// <summary>
        ///     Entitieses
        /// </summary>
        [Sample]
        public static void Entities()
        {
            using Scene scene = new Scene();
            GameObject ent = scene.Create<double>(2);
            //true
            Console.WriteLine(ent.IsAlive);
            //true
            Console.WriteLine(ent.Has<int>());
            //false
            Console.WriteLine(ent.Has<bool>());
            //You can also add and remove components
            ent.Add("I like Alis");

            if (ent.TryGet(out Ref<string> strRef))
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
        ///     Simples the game
        /// </summary>
        [Sample]
        public static void SimpleGame()
        {
            Scene scene = new Scene();

            //create
            GameObject gameObject = scene.Create<Position, Velocity, Character>(new(4, 6), new(2, 0), new('@'));

            //simulate 20 frames
            for (int i = 0; i < 20; i++)
            {
                scene.Update();
                Thread.Sleep(100);
                Console.Clear();
            }

            Position finalPos = gameObject.Get<Position>();
            Console.WriteLine($"Position: X: {finalPos.X} Y: {finalPos.Y}");
        }


        /// <summary>
        ///     The position
        /// </summary>
        private struct Position(int x, int y)
        {
            /// <summary>
            ///     The
            /// </summary>
            public int X = x;

            /// <summary>
            ///     The
            /// </summary>
            public int Y = y;
        }

        /// <summary>
        ///     The velocity
        /// </summary>
        private struct Velocity(int dx, int dy) : IEntityComponent, IInitable
        {
            /// <summary>
            ///     The dx
            /// </summary>
            public readonly int DX = dx;

            /// <summary>
            ///     The dy
            /// </summary>
            public readonly int DY = dy;

            /// <summary>
            /// Inits the self
            /// </summary>
            /// <param name="self">The self</param>
            public void Init(IGameObject self)
            {
                Console.WriteLine("Init");
            }

            /// <summary>
            /// Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            public void Update(IGameObject self)
            {
                self.Get<Position>().X += DX;
                self.Get<Position>().Y += DY;
            }
        }

        /// <summary>
        ///     The character
        /// </summary>
        private struct Character(char c) : IEntityComponent
        {
            /// <summary>
            ///     The
            /// </summary>
            public readonly char Char = c;

            /// <summary>
            /// Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            public void Update(IGameObject self)
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
        /// <param name="IGameObject">The entity</param>
        public void Update(IGameObject gameObject)
        {
            Console.WriteLine(gameObject.Has<Vel>() ? "I have velocity!" : "No velocity here!");
        }
    }

    internal record struct Vel(float DX) : IInitable, IEntityComponent
    {
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
            Console.WriteLine("entity update:" + self.EntityID);
        }

        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(IGameObject self)
        {
            Console.WriteLine("entiti init vel: " + self.EntityID);
        }
    }

    /// <summary>
    ///     The console text
    /// </summary>
    internal struct ConsoleText(ConsoleColor Color) : IEntityComponent
    {
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
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