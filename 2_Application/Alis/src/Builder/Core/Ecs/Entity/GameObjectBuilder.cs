using System;
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
   public class GameObjectBuilder : IBuild<TempGameObject>
   {
       private TempGameObject tempGameObject = new TempGameObject();
       
       /// <summary>
       ///     Builds this instance
       /// </summary>
       /// <returns>The dictionary of components</returns>
       public TempGameObject Build() => tempGameObject;

       public GameObjectBuilder Transform(Action<TransformBuilder> config)
       {
           TransformBuilder transformBuilder = new TransformBuilder();
           config(transformBuilder);
           Transform transform = transformBuilder.Build();
           tempGameObject.transform = new Transform(transform.Position, transform.Rotation, transform.Scale);
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
           tempGameObject.components[typeof(Camera)] = camera;
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
           tempGameObject.components[typeof(Sprite)] = sprite;
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
           tempGameObject.components[typeof(T)] = component;
           return this;
       }
       
       /// <summary>
       /// Adds the component
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>() where T : IEntityComponent, new()
       {
           tempGameObject.components[typeof(T)] = new T();
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
           tempGameObject.components[typeof(T)] = component;
           return this;
       }
   }
}