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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Scope;

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
            Dictionary<Type, IGameObjectComponent> components = gameObjectBuilder.Build();
            
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
            
            if (components.Count == 3)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);

                // Obtén el método genérico Scene.Create<T, U, V>() con tres parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 3);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 });
            }
            
            if (components.Count == 4)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);

                // Obtén el método genérico Scene.Create<T, U, V, W>() con cuatro parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 4);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3, component4 });
            }
            
            
            if (components.Count == 5)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);

                // Obtén el método genérico Scene.Create<T, U, V, W, X>() con cinco parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 5);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3, component4, component5 });
            }
            
            
            if (components.Count == 6)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);

                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y>() con seis parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 6);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3, component4, component5, component6 });
            }
            
            
            if (components.Count == 7)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);

                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z>() con siete parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 7);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3, component4, component5, component6, component7 });
            }
            
            if (components.Count == 8)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);

                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A>() con ocho parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 8);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3, component4, component5, component6, component7, component8 });
            }
            
            if (components.Count == 9)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);

                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A, B>() con nueve parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 9);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3, component4, component5, component6, component7, component8, component9 });
            }
            
            if (components.Count == 10)
            {
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                Type componentType10 = components.Keys.ElementAt(9);
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);
                object component10 = Convert.ChangeType(components[componentType10], componentType10);

                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A, B, C>() con diez parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 10);

                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9, componentType10);

                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 , component4, component5, component6, component7, component8, component9, component10 });
                
            }

            if (components.Count == 11)
            {
                
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                Type componentType10 = components.Keys.ElementAt(9);
                Type componentType11 = components.Keys.ElementAt(10);
                
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);
                object component10 = Convert.ChangeType(components[componentType10], componentType10);
                object component11 = Convert.ChangeType(components[componentType11], componentType11);
                
                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A, B, C, D>() con once parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 11);
                
                // Construye el método genérico con los tipos de los componentes
                
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9, componentType10, componentType11);
                
                // Invoca el método genérico con los componentes
                
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 , component4, component5, component6, component7, component8, component9, component10, component11 });
                
            }
            
            if (components.Count == 12)
            {
                
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                Type componentType10 = components.Keys.ElementAt(9);
                Type componentType11 = components.Keys.ElementAt(10);
                Type componentType12 = components.Keys.ElementAt(11);
                
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);
                object component10 = Convert.ChangeType(components[componentType10], componentType10);
                object component11 = Convert.ChangeType(components[componentType11], componentType11);
                object component12 = Convert.ChangeType(components[componentType12], componentType12);

                
                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A, B, C, D, E>() con doce parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 12);

                
                // Construye el método genérico con los tipos de los componentes
               
                
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9, componentType10, componentType11, componentType12);
                
                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 , component4, component5, component6, component7, component8, component9, component10, component11, component12 });
                
            }
            
            if (components.Count == 13)
            {
                
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                Type componentType10 = components.Keys.ElementAt(9);
                Type componentType11 = components.Keys.ElementAt(10);
                Type componentType12 = components.Keys.ElementAt(11);
                Type componentType13 = components.Keys.ElementAt(12);
                
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);
                object component10 = Convert.ChangeType(components[componentType10], componentType10);
                object component11 = Convert.ChangeType(components[componentType11], componentType11);
                object component12 = Convert.ChangeType(components[componentType12], componentType12);
                object component13 = Convert.ChangeType(components[componentType13], componentType13);

                
                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A, B, C, D, E, F>() con trece parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 13);
                
                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9, componentType10, componentType11, componentType12, componentType13);
                
                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 , component4, component5, component6, component7, component8, component9, component10, component11, component12, component13 });
                
            }
            
            if (components.Count == 14)
            {
                
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                Type componentType10 = components.Keys.ElementAt(9);
                Type componentType11 = components.Keys.ElementAt(10);
                Type componentType12 = components.Keys.ElementAt(11);
                Type componentType13 = components.Keys.ElementAt(12);
                Type componentType14 = components.Keys.ElementAt(13);
                
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);
                object component10 = Convert.ChangeType(components[componentType10], componentType10);
                object component11 = Convert.ChangeType(components[componentType11], componentType11);
                object component12 = Convert.ChangeType(components[componentType12], componentType12);
                object component13 = Convert.ChangeType(components[componentType13], componentType13);
                object component14 = Convert.ChangeType(components[componentType14], componentType14);

                
                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A, B, C, D, E, F, G>() con c
                // trece parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 14);
                
                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9, componentType10, componentType11, componentType12, componentType13, componentType14);
                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 , component4, component5, component6, component7, component8, component9, component10, component11, component12, component13, component14 });
                
            }
            
            if (components.Count == 15)
            {
                
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                Type componentType10 = components.Keys.ElementAt(9);
                Type componentType11 = components.Keys.ElementAt(10);
                Type componentType12 = components.Keys.ElementAt(11);
                Type componentType13 = components.Keys.ElementAt(12);
                Type componentType14 = components.Keys.ElementAt(13);
                Type componentType15 = components.Keys.ElementAt(14);
                
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);
                object component10 = Convert.ChangeType(components[componentType10], componentType10);
                object component11 = Convert.ChangeType(components[componentType11], componentType11);
                object component12 = Convert.ChangeType(components[componentType12], componentType12);
                object component13 = Convert.ChangeType(components[componentType13], componentType13);
                object component14 = Convert.ChangeType(components[componentType14], componentType14);
                object component15 = Convert.ChangeType(components[componentType15], componentType15);

                
                // Obtén el método genérico
                
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 15);
                
                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9, componentType10, componentType11, componentType12, componentType13, componentType14, componentType15);
                
                // Invoca el método genérico con los componentes
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 , component4, component5, component6, component7, component8, component9, component10, component11, component12, component13, component14, component15 });
                
            }
            
            if (components.Count == 16)
            {
                
                Type componentType1 = components.Keys.ElementAt(0);
                Type componentType2 = components.Keys.ElementAt(1);
                Type componentType3 = components.Keys.ElementAt(2);
                Type componentType4 = components.Keys.ElementAt(3);
                Type componentType5 = components.Keys.ElementAt(4);
                Type componentType6 = components.Keys.ElementAt(5);
                Type componentType7 = components.Keys.ElementAt(6);
                Type componentType8 = components.Keys.ElementAt(7);
                Type componentType9 = components.Keys.ElementAt(8);
                Type componentType10 = components.Keys.ElementAt(9);
                Type componentType11 = components.Keys.ElementAt(10);
                Type componentType12 = components.Keys.ElementAt(11);
                Type componentType13 = components.Keys.ElementAt(12);
                Type componentType14 = components.Keys.ElementAt(13);
                Type componentType15 = components.Keys.ElementAt(14);
                Type componentType16 = components.Keys.ElementAt(15);
                
                object component1 = Convert.ChangeType(components[componentType1], componentType1);
                object component2 = Convert.ChangeType(components[componentType2], componentType2);
                object component3 = Convert.ChangeType(components[componentType3], componentType3);
                object component4 = Convert.ChangeType(components[componentType4], componentType4);
                object component5 = Convert.ChangeType(components[componentType5], componentType5);
                object component6 = Convert.ChangeType(components[componentType6], componentType6);
                object component7 = Convert.ChangeType(components[componentType7], componentType7);
                object component8 = Convert.ChangeType(components[componentType8], componentType8);
                object component9 = Convert.ChangeType(components[componentType9], componentType9);
                object component10 = Convert.ChangeType(components[componentType10], componentType10);
                object component11 = Convert.ChangeType(components[componentType11], componentType11);
                object component12 = Convert.ChangeType(components[componentType12], componentType12);
                object component13 = Convert.ChangeType(components[componentType13], componentType13);
                object component14 = Convert.ChangeType(components[componentType14], componentType14);
                object component15 = Convert.ChangeType(components[componentType15], componentType15);
                object component16 = Convert.ChangeType(components[componentType16], componentType16);
                
                // Obtén el método genérico Scene.Create<T, U, V, W, X, Y, Z, A, B, C, D, E, F, G, H>() con dieciséis parámetros genéricos
                var createMethod = typeof(Scene).GetMethods()
                    .First(m => m.Name == "Create" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 16);
                
                // Construye el método genérico con los tipos de los componentes
                var genericCreateMethod = createMethod.MakeGenericMethod(componentType1, componentType2, componentType3, componentType4, componentType5, componentType6, componentType7, componentType8, componentType9, componentType10 , componentType11, componentType12, componentType13, componentType14, componentType15, componentType16);
                
                // Invoca el método genérico con los componentes
                
                genericCreateMethod.Invoke(Scene, new[] { component1, component2, component3 , component4, component5, component6, component7, component8, component9, component10, component11, component12, component13, component14, component15, component16 });
                
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