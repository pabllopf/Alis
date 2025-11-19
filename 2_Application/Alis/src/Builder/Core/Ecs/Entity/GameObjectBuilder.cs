// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectBuilder.cs
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
using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    ///     The game object builder class
    /// </summary>
    public class GameObjectBuilder : IBuild<GameObject>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene scene;

        /// <summary>
        ///     The game object
        /// </summary>
        private GameObject gameObject;

        /// <summary>
        ///     The is static
        /// </summary>
        private Info info = new Info
        {
            Name = "GameObject",
            Tag = "Untagged",
            Id = 0,
            IsActive = true,
            IsStatic = false
        };


        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectBuilder" /> class
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="context">The context</param>
        public GameObjectBuilder(Scene scene, Context context)
        {
            this.scene = scene;
            gameObject = scene.Create();
            this.context = context;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The dictionary of components</returns>
        public GameObject Build() => gameObject;

        /// <summary>
        ///     Transforms the config
        /// </summary>
        /// <param name="config">The config</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Transform(Action<TransformBuilder> config)
        {
            TransformBuilder transformBuilder = new TransformBuilder();
            config(transformBuilder);
            gameObject.Add(transformBuilder.Build());
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>(AnimatorConfig<T> config) where T : IAnimator, new()
        {
            AnimatorBuilder builder = new AnimatorBuilder(context);
            config(builder);
            gameObject.Add(builder.Build());
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>(CameraConfig<T> config) where T : ICamera, new()
        {
            CameraBuilder cameraBuilder = new CameraBuilder(context);
            config(cameraBuilder);
            gameObject.Add(cameraBuilder.Build());
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>(SpriteConfig<T> config) where T : ISprite, new()
        {
            SpriteBuilder spriteBuilder = new SpriteBuilder(context);
            config(spriteBuilder);
            gameObject.Add(spriteBuilder.Build());
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>(AudioSourceConfig<T> config) where T : IAudioSource, new()
        {
            AudioSourceBuilder audioBuilder = new AudioSourceBuilder(context);
            config(audioBuilder);
            AudioSource audio = audioBuilder.Build();
            gameObject.Add(audio);
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>(BoxColliderConfig<T> config) where T : IBoxCollider, new()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder(context);
            config(boxColliderBuilder);
            BoxCollider boxCollider = boxColliderBuilder.Build();
            gameObject.Add(boxCollider);
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>(Action<T> config) where T : IOnUpdate, new()
        {
            T component = new T();

            // if component has interface IHasContext<Context>, set the context:
            if (component is IHasContext<Context> hasContext)
            {
                hasContext.Context = context;
            }

            config(component);
            gameObject.Add(component);
            return this;
        }

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>() where T : IOnUpdate, new()
        {
            T component = new T();

            // if component has interface IHasContext<Context>, set the context:
            if (component is IHasContext<Context> hasContext)
            {
                hasContext.Context = context;
            }

            gameObject.Add(component);
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithComponent<T>(T component) where T : IOnUpdate, new()
        {
            if (component is IHasContext<Context> hasContext)
            {
                hasContext.Context = context;
            }

            gameObject.Add(component);
            return this;
        }

        /// <summary>
        ///     Names the camera
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
                gameObject.Add(info);
            }

            return this;
        }

        /// <summary>
        ///     Tags the tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The game object builder</returns>
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
                gameObject.Add(info);
            }

            return this;
        }

        /// <summary>
        ///     Ids the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Id(int id)
        {
            info.Id = id;
            return this;
        }

        /// <summary>
        ///     Ises the active using the specified is active
        /// </summary>
        /// <param name="isActive">The is active</param>
        /// <returns>The game object builder</returns>
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
                gameObject.Add(info);
            }

            return this;
        }

        /// <summary>
        ///     Ises the active
        /// </summary>
        /// <returns>The game object builder</returns>
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
                gameObject.Add(info);
            }

            return this;
        }

        /// <summary>
        ///     Ises the static using the specified is static
        /// </summary>
        /// <param name="isStatic">The is static</param>
        /// <returns>The game object builder</returns>
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
                gameObject.Add(info);
            }

            return this;
        }

        /// <summary>
        ///     Ises the static
        /// </summary>
        /// <returns>The game object builder</returns>
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
                gameObject.Add(info);
            }

            return this;
        }
    }
}