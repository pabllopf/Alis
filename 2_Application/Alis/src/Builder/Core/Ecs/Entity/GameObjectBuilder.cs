using System;
using System.Collections.Generic;
using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Physic.Dynamics;

namespace Alis.Builder.Core.Ecs.Entity
{
   /// <summary>
   ///     The game object builder class
   /// </summary>
   public class GameObjectBuilder : IBuild<Dictionary<Type, IGameObjectComponent>>
   {
       /// <summary>
       /// The entity component
       /// </summary>
       private Dictionary<Type, IGameObjectComponent> components = new Dictionary<Type, IGameObjectComponent>();

       /// <summary>
       /// The transform
       /// </summary>
       private Transform transform = new Transform();

       /// <summary>
       ///     Builds this instance
       /// </summary>
       /// <returns>The dictionary of components</returns>
       public Dictionary<Type, IGameObjectComponent> Build()
       {
           Dictionary<Type, IGameObjectComponent> temp = new Dictionary<Type, IGameObjectComponent>();
           temp.Add(typeof(Transform), transform);
           foreach (KeyValuePair<Type, IGameObjectComponent> component in components)
           {
               if (component.Key == typeof(Transform))
               {
                   continue;
               }

               temp.Add(component.Key, component.Value);
           }

           return temp;
       }

       /// <summary>
       /// Transforms the config
       /// </summary>
       /// <param name="config">The config</param>
       /// <returns>The game object builder</returns>
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
       public GameObjectBuilder WithComponent<T>(AnimatorConfig<T> config) where T : IAnimator, new()
       {
           AnimatorBuilder builder = new AnimatorBuilder();
           config(builder);
           Animator animator = builder.Build();
           components.Add(typeof(Animator), animator);
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
       public GameObjectBuilder WithComponent<T>(AudioSourceConfig<T> config) where T : IAudioSource, new()
       {
           AudioSourceBuilder audioBuilder = new AudioSourceBuilder();
           config(audioBuilder);
           AudioSource audio = audioBuilder.Build();
           components.Add(typeof(AudioSource), audio);
           return this;
       }
       
       /// <summary>
       /// Adds the component using the specified config
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <param name="config">The config</param>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>(BoxColliderConfig<T> config) where T : IBoxCollider, new()
       {
           BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
           config(boxColliderBuilder);
           BoxCollider boxCollider = boxColliderBuilder.Build();
           components.Add(typeof(BoxCollider), boxCollider);
           return this;
       }

       /// <summary>
       /// Adds the component using the specified config
       /// </summary>
       /// <typeparam name="T">The </typeparam>
       /// <param name="config">The config</param>
       /// <returns>The game object builder</returns>
       public GameObjectBuilder WithComponent<T>(Action<T> config) where T : IGameObjectComponent, new()
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
       public GameObjectBuilder WithComponent<T>() where T : IGameObjectComponent, new()
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
       public GameObjectBuilder WithComponent<T>(T component) where T : IGameObjectComponent, new()
       {
           components.Add(typeof(T), component);
           return this;
       }
   }
}