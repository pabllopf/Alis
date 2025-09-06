using System;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Ecs.Sample.Components;
using Alis;
using Alis.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample
{
    /// <summary>
    /// The samples class
    /// </summary>
    internal class Samples
    {
    
        /// <summary>
        /// Updates the component
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
        /// Updates the systems
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
        /// Uniformses the and entities
        /// </summary>
        
        public static void Uniforms_And_Entities()
        {
            using Scene scene = new Scene();

            scene.Create<Vel, Pos>(default, default);
            scene.Create<Pos>(default);

            scene.Update();
        }
    
        /// <summary>
        /// Uniformses the and entities initeable
        /// </summary>
        
        public static void Uniforms_And_Entities_initeable()
        {
            using Scene scene = new Scene();
        
            scene.Create<Pos2>(default);
            scene.Create<Pos2, Vel2>(default, default);
    
            scene.Update();
        }
    
        /// <summary>
        /// Simples the game
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
        /// Querieses
        /// </summary>
        
        public static void Queries()
        {
            using Scene scene = new Scene();

            for (int i = 0; i < 5; i++)
                scene.Create<int>(i);

            scene.Query<With<int>>().Delegate((ref int x) => Console.Write($"{x++}, "));
            Logger.Trace("");
        
            scene.Query<With<int>>().Inline<WriteAction, int>(default);
        }

        /// <summary>
        /// The write action
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct WriteAction : IAction<int>
        {
            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref int arg)
            {
                Console.Write($"{arg} ");
            }
        }
        
        /// <summary>
        /// Entitieses
        /// </summary>
        
        public static void Entities()
        {
            using Scene scene = new Scene();
            GameObject ent = scene.Create<int, double, float>(69, 3.14, 2.71f);
            //true
            Logger.Info(ent.IsAlive.ToString());
            //true
            Logger.Info(ent.Has<int>().ToString());
            //false
            Logger.Info(ent.Has<bool>().ToString());
            //You can also add and remove components
            ent.Add<string>("I like Alis");

            if (ent.TryGet<string>(out Ref<string> strRef))
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
    }
}
