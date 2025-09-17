using System;
using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Physic;
using Alis.Core.Physic.Dynamics;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    ///     The game object builder class
    /// </summary>
    public class GameObjectBuilder : IBuild<GameObject>
    {
        /// <summary>
        /// The scene
        /// </summary>
        private readonly Scene scene;

        /// <summary>
        /// The game object
        /// </summary>
        private GameObject gameObject;

        private Info info = new Info
        {
            Name = "GameObject",
            Tag = "Untagged",
            Id = 0,
            IsActive = true,
            IsStatic = false
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectBuilder"/> class
        /// </summary>
        /// <param name="scene">The scene</param>
        public GameObjectBuilder(Scene scene)
        {
            this.scene = scene;
            this.gameObject = scene.Create();
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The dictionary of components</returns>
        public GameObject Build()
        {
            return gameObject;
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
            gameObject.Add<Alis.Core.Ecs.Components.Transform>(transformBuilder.Build());
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
            gameObject.Add<Animator>(builder.Build());
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
            gameObject.Add<Camera>(cameraBuilder.Build());
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
            gameObject.Add<Sprite>(spriteBuilder.Build());
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
            gameObject.Add<AudioSource>(audio);
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
            gameObject.Add<BoxCollider>(boxCollider);
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
            gameObject.Add<T>(component);
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
            gameObject.Add<T>(component);
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
            gameObject.Add<T>(component);
            return this;
        }

        /// <summary>
        /// Names the camera
        /// </summary>
        /// <param name="name">The camera</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Name(string name)
        {
            info.Name = name;
            
            if (gameObject.Has<Info>())
            {
                ref Info i = ref gameObject.Get<Info>();
                i.Name = name;
            }
            else
            {
                gameObject.Add<Info>(info);
            }
            
            return this;
        }

        public GameObjectBuilder Tag(string tag)
        {
            info.Tag = tag;
            if (gameObject.Has<Info>())
            {
                ref Info i = ref gameObject.Get<Info>();
                i.Tag = tag;
            }
            else
            {
                gameObject.Add<Info>(info);
            }
            return this;
        }

        public GameObjectBuilder Id(int id)
        {
            info.Id = id;
            return this;
        }

        public GameObjectBuilder IsActive(bool isActive)
        {
            info.IsActive = isActive;
            if (gameObject.Has<Info>())
            {
                ref Info i = ref gameObject.Get<Info>();
                i.IsActive = isActive;
            }
            else
            {
                gameObject.Add<Info>(info);
            }
            return this;
        }
        
        public GameObjectBuilder IsActive()
        {
            info.IsActive = true;
            
            if (gameObject.Has<Info>())
            {
                ref Info i = ref gameObject.Get<Info>();
                i.IsActive = true;
            }
            else
            {
                gameObject.Add<Info>(info);
            }
            return this;
        }

        public GameObjectBuilder IsStatic(bool isStatic)
        {
            info.IsStatic = isStatic;
            if (gameObject.Has<Info>())
            {
                ref Info i = ref gameObject.Get<Info>();
                i.IsStatic = isStatic;
            }
            else
            {
                gameObject.Add<Info>(info);
            }
            return this;
        }
        
        public GameObjectBuilder IsStatic()
        {
            info.IsStatic = true;
            if (gameObject.Has<Info>())
            {
                ref Info i = ref gameObject.Get<Info>();
                i.IsStatic = true;
            }
            else
            {
                gameObject.Add<Info>(info);
            }
            return this;
        }

        
    }
}