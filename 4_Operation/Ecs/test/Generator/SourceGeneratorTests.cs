// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SourceGeneratorTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Ecs.Test.Generator
{
    /// <summary>
    ///     The source generator tests class
    /// </summary>
    public partial class SourceGeneratorTests
    {
        /// <summary>
        ///     The type registration flags enum
        /// </summary>
        [Flags]
        public enum TypeRegistrationFlags
        {
            /// <summary>
            ///     The initable type registration flags
            /// </summary>
            Initable = 1 << 0,

            /// <summary>
            ///     The destroyable type registration flags
            /// </summary>
            Destroyable = 1 << 1,

            /// <summary>
            ///     The updateable type registration flags
            /// </summary>
            Updateable = 1 << 2
        }
        
        /// <summary>
        ///     Tests the type registration using the specified type flags
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="typeFlags">The type flags</param>
        private static void TestTypeRegistration<T>(TypeRegistrationFlags typeFlags)
            where T : new()
        {
            using (Scene scene = new Scene())
            {
                GameObject test = scene.Create();
                if (typeFlags.HasFlag(TypeRegistrationFlags.Initable))
                {
                    Assert.Throws<InitalizeException>(() => test.Add(new T()));
                }
                else
                {
                    test.Add(new T());
                }

                if (typeFlags.HasFlag(TypeRegistrationFlags.Updateable))
                {
                    Assert.Throws<UpdateException>(scene.Update);
                }
                else
                {
                    scene.Update();
                }

                if (typeFlags.HasFlag(TypeRegistrationFlags.Destroyable))
                {
                    Assert.Throws<DestroyException>(test.Remove<T>);
                }
                else
                {
                    test.Remove<T>();
                }
            }
        }

        /// <summary>
        ///     The nest class
        /// </summary>
        public partial class Nest<T>
        {
            /// <summary>
            ///     The inner
            /// </summary>
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public partial struct Inner<T1> : IOnInit
            {
                /// <summary>
                ///     Inits the self
                /// </summary>
                /// <param name="self">The self</param>
                /// <exception cref="InitalizeException"></exception>
                public void OnInit(IGameObject self)
                {
                    throw new InitalizeException();
                }
            }

        }

        /// <summary>
        ///     The initalize exception class
        /// </summary>
        /// <seealso cref="Exception" />
        public class InitalizeException : Exception;

        /// <summary>
        ///     The destroy exception class
        /// </summary>
        /// <seealso cref="Exception" />
        public class DestroyException : Exception;

        /// <summary>
        ///     The update exception class
        /// </summary>
        /// <seealso cref="Exception" />
        public class UpdateException : Exception;
    }
}