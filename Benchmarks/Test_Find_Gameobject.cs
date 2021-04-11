using Alis.Core;
using Alis.Tools;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks
{
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MedianColumn, IterationsColumn]
    public class Test_Find_Gameobject
    {
        [Params(1024)]
        public int numOfGameobjects = 1024;

        public Scene scene;

        private GameObject gameObject;

        private readonly string name = "GameObject0";

        private List<GameObject> gameObjects;

        [GlobalSetup]
        public void Setup()
        {
            gameObjects = new List<GameObject>();
            for(int i = 0; i < numOfGameobjects; i++) 
            {
                gameObjects.Add(new GameObject("GameObject" + i));
            }

            scene = new Scene("Example", gameObjects.ToArray());
        }

        /// <summary>Tests the find simple for.</summary>
        [Benchmark]
        public void Test_Find_Simple_For()
        {
            for (int i = 0; i < gameObjects.Count; i++) 
            {
                if (gameObjects[i] != null && name.Equals(gameObjects[i].Name) && gameObjects[i].IsActive)  
                {
                    gameObject = gameObjects[i];
                    Console.WriteLine("Find the gameobject: '" + gameObject.Name + "' on " + "scene '" + this.name + "'" + "(CASE: find by search)");
                    return;
                }
            }

            Console.WriteLine("Scene '" + this.name + "'" + " dont`t contains " + name + " (CASE: didn't find anything)");
        }

        /// <summary>Tests the custom find.</summary>
        [Benchmark]
        public void Test_Custom_Find()
        {
            scene.Find(name);
        }
    }
}
