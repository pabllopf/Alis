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
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

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
        public static void Update_Component()
        {
            using Scene scene = new Scene();

            //Create three entities
            for (int i = 0; i < 3; i++)
            {
                scene.Create<string, ConsoleText>("Hello, Scene!", new(ConsoleColor.Blue));
            }

            //Update the three entities
            scene.Update();
        }


        /// <summary>
        ///     Updates the systems
        /// </summary>
        public static void Update_Systems()
        {
            using Scene scene = new Scene();

            //Create three entities
            for (int i = 0; i < 3; i++)
            {
                scene.Create<string, ConsoleText>("Hello, Scene!", new(ConsoleColor.Blue));
            }

            foreach (RefTuple<string> stringsRefTuple in scene.Query<With<string>>().Enumerate<string>())
            {
                //Get the string reference
                Ref<string> strRef = stringsRefTuple.Item1;

                //Update the string value
                strRef.Value += "!!!!! <> !!!!!";
            }

            scene.Update();
        }


        /// <summary>
        ///     Uniformses the and entities
        /// </summary>
        public static void Uniforms_And_Entities()
        {
            using Scene scene = new Scene();

            scene.Create<Vel, Pos>(default(Vel), default(Pos));
            scene.Create<Pos>(default(Pos));

            scene.Update();
        }

        /// <summary>
        ///     Uniformses the and entities initeable
        /// </summary>
        public static void Uniforms_And_Entities_initeable()
        {
            using Scene scene = new Scene();

            scene.Create<Pos2>(default(Pos2));
            scene.Create<Pos2, Vel2>(default(Pos2), default(Vel2));

            scene.Update();
        }

        /// <summary>
        ///     Simples the game
        /// </summary>
        public static void Simple_Game()
        {
            Scene scene = new Scene();

            //create
            GameObject gameObject = scene.Create<Position, Velocity, Character>(new(4, 6), new(2, 0), new('@'));

            //simulate 20 frames
            for (int i = 0; i < 20; i++)
            {
                scene.Update();
                Thread.Sleep(100);
            }

            Position finalPos = gameObject.Get<Position>();
            Logger.Info($"Position: X: {finalPos.X} Y: {finalPos.Y}");
        }


        /// <summary>
        ///     Querieses
        /// </summary>
        public static void Queries()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 5; i++)
            {
                scene.Create(i);
            }

            scene.Query<With<int>>().Delegate((ref int x) => Console.Write($"{x++}, "));
            Logger.Trace("");

            scene.Query<With<int>>().Inline<WriteAction, int>(default(WriteAction));
        }

        /// <summary>
        ///     Entitieses
        /// </summary>
        public static void Entities()
        {
            using Scene scene = new Scene();
            GameObject ent = scene.Create(69, 3.14, 2.71f);
            //true
            Logger.Info(ent.IsAlive.ToString());
            //true
            Logger.Info(ent.Has<int>().ToString());
            //false
            Logger.Info(ent.Has<bool>().ToString());
            //You can also add and remove components
            ent.Add("I like Alis");

            if (ent.TryGet(out Ref<string> strRef))
            {
                Logger.Info(strRef);
                //reassign the string value
                strRef.Value = "Do you like Alis?";
            }

            //If we didn't add a string earlier, this would throw instead
            Logger.Info(ent.Get<string>());

            //You can also deconstruct components from the gameObject to reassign many at once
            ent.Deconstruct(out Ref<double> d, out Ref<int> i, out Ref<float> f, out Ref<string> str);
            d.Value = 4;
            str.Value = "Hello, Scene!";

            Logger.Info(str);
        }

        /// <summary>
        ///     The write action
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct WriteAction : IAction<int>
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
}