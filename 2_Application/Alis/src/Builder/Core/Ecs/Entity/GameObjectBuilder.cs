using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Builder.Core.Ecs.Component;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Operations;
using Alis.Core.Physic.Dynamics;

namespace Alis.Builder.Core.Ecs.Entity
{
   /// <summary>
   ///     The game object builder class
   /// </summary>
   public class GameObjectBuilder : IBuild<Dictionary<Type, IEntityComponent>>
   {
       private Dictionary<Type, IEntityComponent> components = new Dictionary<Type, IEntityComponent>();

       private Transform transform = new Transform();

       /// <summary>
       ///     Builds this instance
       /// </summary>
       /// <returns>The dictionary of components</returns>
       public Dictionary<Type, IEntityComponent> Build()
       {
           Dictionary<Type, IEntityComponent> temp = new Dictionary<Type, IEntityComponent>();
           temp.Add(typeof(Transform), transform);
           foreach (KeyValuePair<Type, IEntityComponent> component in components)
           {
               if (component.Key == typeof(Transform))
               {
                   continue;
               }

               temp.Add(component.Key, component.Value);
           }

           return temp;
       }

       public GameObjectBuilder Transform(Action<TransformBuilder> config)
       {
           TransformBuilder transformBuilder = new TransformBuilder();
           config(transformBuilder);
           this.transform = transformBuilder.Build();
           return this;
       }
       
       /// <summary>
       /// Adds the component using the specified config
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <param name="config">The config</param>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>(CameraConfig<T> config) where T : ICamera, new()
       {
           CameraBuilder cameraBuilder = new CameraBuilder();
           config(cameraBuilder);
           Camera camera = cameraBuilder.Build();
           components.Add(typeof(Camera), camera);
           return this;
       }

       /// <summary>
       /// Adds the component using the specified config
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <param name="config">The config</param>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>(SpriteConfig<T> config) where T : ISprite, new()
       {
           SpriteBuilder spriteBuilder = new SpriteBuilder();
           config(spriteBuilder);
           Sprite sprite = spriteBuilder.Build();
              components.Add(typeof(Sprite), sprite);
           return this;
       }

       /// <summary>
       /// Adds the component using the specified config
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <param name="config">The config</param>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>(Action<T> config) where T : IEntityComponent, new()
       {
           T component = new T();
           config(component);
           components.Add(typeof(T), component);
           return this;
       }
       
       /// <summary>
       /// Adds the component
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>() where T : IEntityComponent, new()
       {
              T component = new T();
              components.Add(typeof(T), component);
           return this;
       }

       /// <summary>
       /// Adds the component using the specified component
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <param name="component">The component</param>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>(T component) where T : IEntityComponent, new()
       {
           components.Add(typeof(T), component);
           return this;
       }
   }
}