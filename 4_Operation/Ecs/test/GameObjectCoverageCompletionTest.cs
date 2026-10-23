// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectCoverageCompletionTest.cs
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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Completes coverage of <see cref="GameObject" /> equality, component initializer and
    ///     event subscription branches.
    /// </summary>
    public partial class GameObjectCoverageCompletionTest
    {
        /// <summary>
        ///     Ensures the components used by these tests have their init delegates registered
        ///     before <see cref="Component{T}" /> caches them.
        /// </summary>
        private static void RegisterCoverageInitializers()
        {
            GenerationServices.RegisterInit<CoverageInitOne>();
            GenerationServices.RegisterInit<CoverageInitTwo>();
            GenerationServices.RegisterInit<CoverageInitThree>();
            GenerationServices.RegisterInit<CoverageInitFour>();
            GenerationServices.RegisterInit<CoverageInitFive>();
            GenerationServices.RegisterInit<CoverageInitSix>();
            GenerationServices.RegisterInit<CoverageInitSeven>();
            GenerationServices.RegisterInit<CoverageInitEight>();
        }

        /// <summary>
        ///     Tests that Equals(object) returns true when the boxed object is the same gameObject.
        /// </summary>
        [Fact]
        public void Equals_WhenObjectIsSameGameObject_ReturnsTrue()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position());
            object boxed = gameObject;

            bool equals = gameObject.Equals(boxed);

            Assert.True(equals);
        }

        /// <summary>
        ///     Tests that Equals(object) returns false when the boxed object is another gameObject.
        /// </summary>
        [Fact]
        public void Equals_WhenObjectIsDifferentGameObject_ReturnsFalse()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position());
            object other = scene.Create(new Position());

            bool equals = gameObject.Equals(other);

            Assert.False(equals);
        }

        /// <summary>
        ///     Tests that the single component Add overload invokes the component init delegate.
        /// </summary>
        [Fact]
        public void Add_WhenComponentHasInitializer_InvokesInitializer()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
        }

        /// <summary>
        ///     Tests that the two component Add overload invokes every component init delegate.
        /// </summary>
        [Fact]
        public void Add_Arity2_WhenComponentsHaveInitializers_InvokesInitializers()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne(), new CoverageInitTwo());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
            Assert.True(gameObject.Get<CoverageInitTwo>().Initialized);
        }

        /// <summary>
        ///     Tests that the three component Add overload invokes every component init delegate.
        /// </summary>
        [Fact]
        public void Add_Arity3_WhenComponentsHaveInitializers_InvokesInitializers()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne(), new CoverageInitTwo(), new CoverageInitThree());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
            Assert.True(gameObject.Get<CoverageInitTwo>().Initialized);
            Assert.True(gameObject.Get<CoverageInitThree>().Initialized);
        }

        /// <summary>
        ///     Tests that the four component Add overload invokes every component init delegate.
        /// </summary>
        [Fact]
        public void Add_Arity4_WhenComponentsHaveInitializers_InvokesInitializers()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne(), new CoverageInitTwo(), new CoverageInitThree(),
                new CoverageInitFour());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
            Assert.True(gameObject.Get<CoverageInitTwo>().Initialized);
            Assert.True(gameObject.Get<CoverageInitThree>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFour>().Initialized);
        }

        /// <summary>
        ///     Tests that the five component Add overload invokes every component init delegate.
        /// </summary>
        [Fact]
        public void Add_Arity5_WhenComponentsHaveInitializers_InvokesInitializers()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne(), new CoverageInitTwo(), new CoverageInitThree(),
                new CoverageInitFour(), new CoverageInitFive());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
            Assert.True(gameObject.Get<CoverageInitTwo>().Initialized);
            Assert.True(gameObject.Get<CoverageInitThree>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFour>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFive>().Initialized);
        }

        /// <summary>
        ///     Tests that the six component Add overload invokes every component init delegate.
        /// </summary>
        [Fact]
        public void Add_Arity6_WhenComponentsHaveInitializers_InvokesInitializers()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne(), new CoverageInitTwo(), new CoverageInitThree(),
                new CoverageInitFour(), new CoverageInitFive(), new CoverageInitSix());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
            Assert.True(gameObject.Get<CoverageInitTwo>().Initialized);
            Assert.True(gameObject.Get<CoverageInitThree>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFour>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFive>().Initialized);
            Assert.True(gameObject.Get<CoverageInitSix>().Initialized);
        }

        /// <summary>
        ///     Tests that the seven component Add overload invokes every component init delegate.
        /// </summary>
        [Fact]
        public void Add_Arity7_WhenComponentsHaveInitializers_InvokesInitializers()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne(), new CoverageInitTwo(), new CoverageInitThree(),
                new CoverageInitFour(), new CoverageInitFive(), new CoverageInitSix(), new CoverageInitSeven());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
            Assert.True(gameObject.Get<CoverageInitTwo>().Initialized);
            Assert.True(gameObject.Get<CoverageInitThree>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFour>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFive>().Initialized);
            Assert.True(gameObject.Get<CoverageInitSix>().Initialized);
            Assert.True(gameObject.Get<CoverageInitSeven>().Initialized);
        }

        /// <summary>
        ///     Tests that the eight component Add overload invokes every component init delegate.
        /// </summary>
        [Fact]
        public void Add_Arity8_WhenComponentsHaveInitializers_InvokesInitializers()
        {
            RegisterCoverageInitializers();

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoverageInitOne(), new CoverageInitTwo(), new CoverageInitThree(),
                new CoverageInitFour(), new CoverageInitFive(), new CoverageInitSix(), new CoverageInitSeven(),
                new CoverageInitEight());

            Assert.True(gameObject.Get<CoverageInitOne>().Initialized);
            Assert.True(gameObject.Get<CoverageInitTwo>().Initialized);
            Assert.True(gameObject.Get<CoverageInitThree>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFour>().Initialized);
            Assert.True(gameObject.Get<CoverageInitFive>().Initialized);
            Assert.True(gameObject.Get<CoverageInitSix>().Initialized);
            Assert.True(gameObject.Get<CoverageInitSeven>().Initialized);
            Assert.True(gameObject.Get<CoverageInitEight>().Initialized);
        }

        /// <summary>
        ///     Tests that unsubscribing a handler for a flag the entity never raised does not throw.
        /// </summary>
        [Fact]
        public void UnsubscribeEvent_WhenEventFlagIsNotSet_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position());
            Action<GameObject, ComponentId> handler = static (_, _) => { };

            Exception exception = Record.Exception(() =>
                gameObject.UnsubscribeEvent(handler, GameObjectFlags.RemoveComp));

            Assert.Null(exception);
            Assert.True(gameObject.IsAlive);
        }

        /// <summary>
        ///     Tests that subscribing a second handler to the same event reuses the event record and
        ///     both handlers receive the notification.
        /// </summary>
        [Fact]
        public void InitalizeEventRecord_WhenEventRecordExists_AddsHandlerAndFiresBoth()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            int firstCalls = 0;
            int secondCalls = 0;
            Action<GameObject, ComponentId> first = (_, _) => firstCalls++;
            Action<GameObject, ComponentId> second = (_, _) => secondCalls++;

            gameObject.OnComponentAdded += first;
            gameObject.OnComponentAdded += second;
            gameObject.Add(new Position());

            Assert.Equal(1, firstCalls);
            Assert.Equal(1, secondCalls);
        }

        /// <summary>
        ///     Tests that the single component Add overload skips initialization when the component
        ///     has no registered initializer.
        /// </summary>
        [Fact]
        public void Add_WhenComponentHasNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne());

            Assert.True(gameObject.Has<CoveragePlainOne>());
        }

        /// <summary>
        ///     Tests that the two component Add overload skips initialization for components that
        ///     have no registered initializer.
        /// </summary>
        [Fact]
        public void Add_Arity2_WhenComponentsHaveNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne(), new CoveragePlainTwo());

            Assert.True(gameObject.Has<CoveragePlainOne>());
            Assert.True(gameObject.Has<CoveragePlainTwo>());
        }

        /// <summary>
        ///     Tests that the three component Add overload skips initialization for components that
        ///     have no registered initializer.
        /// </summary>
        [Fact]
        public void Add_Arity3_WhenComponentsHaveNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne(), new CoveragePlainTwo(), new CoveragePlainThree());

            Assert.True(gameObject.Has<CoveragePlainOne>());
            Assert.True(gameObject.Has<CoveragePlainTwo>());
            Assert.True(gameObject.Has<CoveragePlainThree>());
        }

        /// <summary>
        ///     Tests that the four component Add overload skips initialization for components that
        ///     have no registered initializer.
        /// </summary>
        [Fact]
        public void Add_Arity4_WhenComponentsHaveNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne(), new CoveragePlainTwo(), new CoveragePlainThree(),
                new CoveragePlainFour());

            Assert.True(gameObject.Has<CoveragePlainOne>());
            Assert.True(gameObject.Has<CoveragePlainTwo>());
            Assert.True(gameObject.Has<CoveragePlainThree>());
            Assert.True(gameObject.Has<CoveragePlainFour>());
        }

        /// <summary>
        ///     Tests that the five component Add overload skips initialization for components that
        ///     have no registered initializer.
        /// </summary>
        [Fact]
        public void Add_Arity5_WhenComponentsHaveNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne(), new CoveragePlainTwo(), new CoveragePlainThree(),
                new CoveragePlainFour(), new CoveragePlainFive());

            Assert.True(gameObject.Has<CoveragePlainOne>());
            Assert.True(gameObject.Has<CoveragePlainTwo>());
            Assert.True(gameObject.Has<CoveragePlainThree>());
            Assert.True(gameObject.Has<CoveragePlainFour>());
            Assert.True(gameObject.Has<CoveragePlainFive>());
        }

        /// <summary>
        ///     Tests that the six component Add overload skips initialization for components that
        ///     have no registered initializer.
        /// </summary>
        [Fact]
        public void Add_Arity6_WhenComponentsHaveNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne(), new CoveragePlainTwo(), new CoveragePlainThree(),
                new CoveragePlainFour(), new CoveragePlainFive(), new CoveragePlainSix());

            Assert.True(gameObject.Has<CoveragePlainOne>());
            Assert.True(gameObject.Has<CoveragePlainTwo>());
            Assert.True(gameObject.Has<CoveragePlainThree>());
            Assert.True(gameObject.Has<CoveragePlainFour>());
            Assert.True(gameObject.Has<CoveragePlainFive>());
            Assert.True(gameObject.Has<CoveragePlainSix>());
        }

        /// <summary>
        ///     Tests that the seven component Add overload skips initialization for components that
        ///     have no registered initializer.
        /// </summary>
        [Fact]
        public void Add_Arity7_WhenComponentsHaveNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne(), new CoveragePlainTwo(), new CoveragePlainThree(),
                new CoveragePlainFour(), new CoveragePlainFive(), new CoveragePlainSix(), new CoveragePlainSeven());

            Assert.True(gameObject.Has<CoveragePlainOne>());
            Assert.True(gameObject.Has<CoveragePlainTwo>());
            Assert.True(gameObject.Has<CoveragePlainThree>());
            Assert.True(gameObject.Has<CoveragePlainFour>());
            Assert.True(gameObject.Has<CoveragePlainFive>());
            Assert.True(gameObject.Has<CoveragePlainSix>());
            Assert.True(gameObject.Has<CoveragePlainSeven>());
        }

        /// <summary>
        ///     Tests that the eight component Add overload skips initialization for components that
        ///     have no registered initializer.
        /// </summary>
        [Fact]
        public void Add_Arity8_WhenComponentsHaveNoInitializer_DoesNotInvokeInitializer()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.Add(new CoveragePlainOne(), new CoveragePlainTwo(), new CoveragePlainThree(),
                new CoveragePlainFour(), new CoveragePlainFive(), new CoveragePlainSix(), new CoveragePlainSeven(),
                new CoveragePlainEight());

            Assert.True(gameObject.Has<CoveragePlainOne>());
            Assert.True(gameObject.Has<CoveragePlainTwo>());
            Assert.True(gameObject.Has<CoveragePlainThree>());
            Assert.True(gameObject.Has<CoveragePlainFour>());
            Assert.True(gameObject.Has<CoveragePlainFive>());
            Assert.True(gameObject.Has<CoveragePlainSix>());
            Assert.True(gameObject.Has<CoveragePlainSeven>());
            Assert.True(gameObject.Has<CoveragePlainEight>());
        }

        private partial struct CoverageInitOne : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }

        private partial struct CoverageInitTwo : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }

        private partial struct CoverageInitThree : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }

        private partial struct CoverageInitFour : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }

        private partial struct CoverageInitFive : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }

        private partial struct CoverageInitSix : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }

        private partial struct CoverageInitSeven : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }

        private partial struct CoverageInitEight : IOnInit
        {
            public bool Initialized;

            public void OnInit(IGameObject self) => Initialized = true;
        }
        private struct CoveragePlainOne
        {
        }

        private struct CoveragePlainTwo
        {
        }

        private struct CoveragePlainThree
        {
        }

        private struct CoveragePlainFour
        {
        }

        private struct CoveragePlainFive
        {
        }

        private struct CoveragePlainSix
        {
        }

        private struct CoveragePlainSeven
        {
        }

        private struct CoveragePlainEight
        {
        }


    }
}
