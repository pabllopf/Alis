using System;
using System.Runtime.InteropServices;
using Alis;
using Alis.Core.Ecs.Components;
using Xunit;

namespace Alis.Core.Ecs.Test.Generator
{
    /// <summary>
    /// The source generator tests class
    /// </summary>
    public partial class SourceGeneratorTests
    {
        /// <summary>
        /// Tests that registered properly inner
        /// </summary>
        [Fact]
        public void RegisteredProperly_Inner() =>
            TestTypeRegistration<Nest<int>.Inner<float>>(TypeRegistrationFlags.Initable);

        /// <summary>
        /// Tests that registered properly indirect interface
        /// </summary>
        [Fact]
        public void RegisteredProperly_IndirectInterface() =>
            TestTypeRegistration<IndirectInterface>(TypeRegistrationFlags.Initable | TypeRegistrationFlags.Destroyable | TypeRegistrationFlags.Updateable);

        /// <summary>
        /// Tests that registered properly in global namespace
        /// </summary>
        [Fact]
        public void RegisteredProperly_InGlobalNamespace() =>
            TestTypeRegistration<InGlobalNamespace>(TypeRegistrationFlags.Updateable);

        /// <summary>
        /// Tests that registered properly in global namespace inner
        /// </summary>
        [Fact]
        public void RegisteredProperly_InGlobalNamespaceInner() =>
            TestTypeRegistration<InGlobalNamespace.Inner<object>>(default);

        /// <summary>
        /// Tests that registered properly derived
        /// </summary>
        [Fact]
        public void RegisteredProperly_Derived() =>
            TestTypeRegistration<Derived>(TypeRegistrationFlags.Updateable);

        /// <summary>
        /// Tests that registered properly derived inner
        /// </summary>
        [Fact]
        public void RegisteredProperly_DerivedInner() =>
            TestTypeRegistration<Derived.DerivedInner>(TypeRegistrationFlags.Initable | TypeRegistrationFlags.Updateable);

        /// <summary>
        /// Tests the type registration using the specified type flags
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="typeFlags">The type flags</param>
        private static void TestTypeRegistration<T>(TypeRegistrationFlags typeFlags)
            where T : new()
        {
            using Scene scene = new();

            GameObject test = scene.Create();
            if (typeFlags.HasFlag(TypeRegistrationFlags.Initable))
                Assert.Throws<InitalizeException>(() => test.Add(new T()));
            else
                test.Add(new T());

            if (typeFlags.HasFlag(TypeRegistrationFlags.Updateable))
                Assert.Throws<UpdateException>(scene.Update);
            else
                scene.Update();

            if (typeFlags.HasFlag(TypeRegistrationFlags.Destroyable))
                Assert.Throws<DestroyException>(test.Remove<T>);
            else
                test.Remove<T>();
        }

        /// <summary>
        /// The type registration flags enum
        /// </summary>
        [Flags]
        public enum TypeRegistrationFlags
        {
            /// <summary>
            /// The initable type registration flags
            /// </summary>
            Initable = 1 << 0,
            /// <summary>
            /// The destroyable type registration flags
            /// </summary>
            Destroyable = 1 << 1,
            /// <summary>
            /// The updateable type registration flags
            /// </summary>
            Updateable = 1 << 2,
        }

        /// <summary>
        /// The nest class
        /// </summary>
        public partial class Nest<T>
        {
            /// <summary>
            /// The inner
            /// </summary>
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public partial struct Inner<T1> : IInitable
            {
                /// <summary>
                /// Inits the self
                /// </summary>
                /// <param name="self">The self</param>
                /// <exception cref="InitalizeException"></exception>
                public void Init(GameObject self)
                {
                    throw new InitalizeException();
                }
            }

            /// <summary>
            /// The inner partially class
            /// </summary>
            /// <seealso cref="IComponent"/>
            private partial class InnerPartially<T1> : IComponent
            {
                /// <summary>
                /// Updates this instance
                /// </summary>
                /// <exception cref="UpdateException"></exception>
                public void Update()
                {
                    throw new UpdateException();
                }
            }
        }

        /// <summary>
        /// The indirect interface
        /// </summary>
        private partial struct IndirectInterface : ILifetimeInterface
        {
            /// <summary>
            /// Destroys this instance
            /// </summary>
            /// <exception cref="DestroyException"></exception>
            public void Destroy()
            {
                throw new DestroyException();
            }

            /// <summary>
            /// Inits the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <exception cref="InitalizeException"></exception>
            public void Init(GameObject self)
            {
                throw new InitalizeException();
            }

            /// <summary>
            /// Updates this instance
            /// </summary>
            /// <exception cref="UpdateException"></exception>
            public void Update()
            {
                throw new UpdateException();
            }
        }
    }

    /// <summary>
    /// The in global namespace class
    /// </summary>
    /// <seealso cref="IComponent"/>
    public partial class InGlobalNamespace : IComponent
    {
        /// <summary>
        /// Updates this instance
        /// </summary>
        /// <exception cref="UpdateException"></exception>
        public void Update()
        {
            throw new UpdateException();
        }

        /// <summary>
        /// The inner
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public partial struct Inner<T> : IComponentBase
        {
            /// <summary>
            /// The unbound
            /// </summary>
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public partial struct Unbound<T1> : IComponent<T1>
            {
                /// <summary>
                /// Updates the uniform
                /// </summary>
                /// <param name="uniform">The uniform</param>
                /// <exception cref="UpdateException"></exception>
                public void Update(ref T1 uniform)
                {
                    throw new UpdateException();
                }
            }
        }
    }

    /// <summary>
    /// The derived class
    /// </summary>
    /// <seealso cref="InGlobalNamespace"/>
    public partial class Derived : InGlobalNamespace
    {
        /// <summary>
        /// The derived inner class
        /// </summary>
        /// <seealso cref="Derived"/>
        /// <seealso cref="IInitable"/>
        public partial class DerivedInner : Derived, IInitable
        {
            /// <summary>
            /// Inits the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <exception cref="InitalizeException"></exception>
            public void Init(GameObject self)
            {
                throw new InitalizeException();
            }
        }

        /// <summary>
        /// The warning class
        /// </summary>
        /// <seealso cref="IComponent"/>
        /// <seealso cref="IUniformComponent{int}"/>
        protected partial class Warning : IComponent, IComponent<int>
        {
            /// <summary>
            /// Updates this instance
            /// </summary>
            /// <exception cref="UpdateException"></exception>
            public void Update()
            {
                throw new UpdateException();
            }

            /// <summary>
            /// Updates the uniform
            /// </summary>
            /// <param name="uniform">The uniform</param>
            /// <exception cref="UpdateException"></exception>
            public void Update(ref int uniform)
            {
                throw new UpdateException();
            }
        }
    }

    /// <summary>
    /// The lifetime interface interface
    /// </summary>
    /// <seealso cref="IComponent"/>
    /// <seealso cref="IInitable"/>
    /// <seealso cref="IDestroyable"/>
    internal interface ILifetimeInterface : IComponent, IInitable, IDestroyable
    {
    }

    /// <summary>
    /// The initalize exception class
    /// </summary>
    /// <seealso cref="Exception"/>
    public class InitalizeException : Exception;

    /// <summary>
    /// The destroy exception class
    /// </summary>
    /// <seealso cref="Exception"/>
    public class DestroyException : Exception;

    /// <summary>
    /// The update exception class
    /// </summary>
    /// <seealso cref="Exception"/>
    public class UpdateException : Exception;
}