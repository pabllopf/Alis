using Alis.FluentApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class Scene : IBuilder<SceneBuilder>
    {
        private Name name;

        private List<GameObject> gameObjects;

        public Scene()
        {
            name = new Name("Default Scene");
            gameObjects = new List<GameObject>();
        }

        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        
        public string Name { get => name.Value; set => name = new Name(value); }

        public void Start() 
        {
            gameObjects.ForEach(i =>
            {
                i.Start();
            });
        }

        public void Update()
        {
            gameObjects.ForEach(i =>
            {
                i.Update();
            });
        }
    }
}