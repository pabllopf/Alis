using System;
using System.Collections.Generic;
using Alis.Builder.Core.Ecs.Component;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Comps;
using Alis.Core.Ecs.Operations;

namespace Alis.Builder.Core.Ecs.Entity
{
   /// <summary>
   ///     The game object builder class
   /// </summary>
   public class GameObjectBuilder : IBuild<Dictionary<Type, IEntityComponent>>
   {
       /// <summary>
       ///     Stores the components as a dictionary
       /// </summary>
       private readonly Dictionary<Type, IEntityComponent> components = new Dictionary<Type, IEntityComponent>();

       /// <summary>
       ///     Builds this instance
       /// </summary>
       /// <returns>The dictionary of components</returns>
       public Dictionary<Type, IEntityComponent> Build() => components;
       
       public GameObjectBuilder WithComponent<T>(CameraConfig<T> config) where T : ICamera, new()
       {
           CameraBuilder cameraBuilder = new CameraBuilder();
           config(cameraBuilder);
           Camera camera = cameraBuilder.Build();
           components[typeof(Camera)] = camera;
           return this;
       }

       public GameObjectBuilder WithComponent<T>(SpriteConfig<T> config) where T : ISprite, new()
       {
           SpriteBuilder spriteBuilder = new SpriteBuilder();
           config(spriteBuilder);
           Sprite sprite = spriteBuilder.Build();
           components[typeof(Sprite)] = sprite;
           return this;
       }

       public GameObjectBuilder WithComponent<T>(Action<T> config) where T : IEntityComponent, new()
       {
           T component = new T();
           config(component);
           components[typeof(T)] = component;
           return this;
       }
       
       public GameObjectBuilder WithComponent<T>() where T : IEntityComponent, new()
       {
           components[typeof(T)] = new T();
           return this;
       }

       public GameObjectBuilder WithComponent<T>(T component) where T : IEntityComponent, new()
       {
           components[typeof(T)] = component;
           return this;
       }
   }
}