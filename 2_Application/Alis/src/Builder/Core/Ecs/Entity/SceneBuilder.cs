// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneBuilder.cs
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
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Operations;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    ///     The scene builder class
    /// </summary>
    /// <seealso cref="IBuild{Scene}" />
    public class SceneBuilder :
        IBuild<Scene>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public SceneBuilder(Context context) => this.context = context;

        /// <summary>
        ///     Gets the value of the scene
        /// </summary>
        private Scene Scene { get; } = new Scene();
        
        /// <summary>
        /// Adds the config
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="config">The config</param>
        /// <returns>The scene builder</returns>
        public SceneBuilder Add<T>(Action<GameObjectBuilder> config) where T : IGameObject
        {
            GameObjectBuilder gameObjectBuilder = new GameObjectBuilder();
            config(gameObjectBuilder);
            TempGameObject tempGameObject = gameObjectBuilder.Build();
            Transform transform = tempGameObject.transform;

            var components = tempGameObject.components;

            if (components.Count == 0)
            {
                Scene.Create();
            }

            if (components.Count == 1)
            {
              Type componentType = components.Keys.ElementAt(0);
              object component = Convert.ChangeType(components[componentType], componentType);

              // Obtén el método genérico Scene.Create<T>() con un solo parámetro genérico
              var createMethod = typeof(Scene).GetMethods()
                  .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 1);

              // Construye el método genérico con el tipo del componente
              var genericCreateMethod = createMethod.MakeGenericMethod(componentType);

              // Invoca el método genérico con el componente
              genericCreateMethod.Invoke(Scene, new[] { component });
            }
          
            if (components.Count == 2)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);

                // Obtén el método genérico Scene.Create<T, U>() con dos parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 2);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2 });
            }
            
            return this;
        }
        

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The scene</returns>
        public Scene Build() => Scene;

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The scene builder</returns>
        public SceneBuilder Name(string value) => this;
    }
}