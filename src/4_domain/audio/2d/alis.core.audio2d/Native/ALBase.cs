// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ALBase.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Audio2D.Native
{
    /// <summary>
    ///     This is a base class for OpenAL APIs that are using DllImport and want to resolve different dll names on different
    ///     platforms.
    /// </summary>
    public abstract class ALBase
    {
        /// <summary>
        ///     This needs to be called before trying to use any OpenAL functions.
        ///     This should be done in the static constructor of any class that DllImports OpenAL functions.
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void RegisterOpenALResolver()
        {
            ALLoader.RegisterDllResolver();
        }

        /// <summary>
        ///     Calls alGetProcAddress and converts the resulting pointer into a delegate.
        /// </summary>
        /// <typeparam name="TDelegate">The delegate type to create.</typeparam>
        /// <param name="name">The name of the AL proc.</param>
        /// <returns>The created delegate.</returns>
        protected internal static TDelegate LoadDelegate<TDelegate>(string name) where TDelegate : Delegate
        {
            IntPtr ptr = AL.AL.GetProcAddress(name);
            if (ptr == IntPtr.Zero)
            {
                // If we can't load the function for whatever reason we dynamically generate a delegate to
                // give the user an error message that is actually understandable.
                MethodInfo invoke = typeof(TDelegate).GetMethod("Invoke");
                Type returnType = invoke.ReturnType;
                Type[] parameters = invoke.GetParameters().Select(p => p.ParameterType).ToArray();
                DynamicMethod method = new DynamicMethod(
                    "OpenAL_AL_Extension_Null_GetProcAddress_Exception_Delegate_" + Guid.NewGuid(),
                    returnType,
                    parameters);
                ILGenerator generator = method.GetILGenerator();

                // Here we are generating a delegate that looks like this:
                // ((<the arguments that the delegate type takes>) =>
                // throw new Exception(<error string>);
                generator.Emit(OpCodes.Ldstr,
                    "This OpenAL function could not be loaded. This likely means that this extension isn't present in the current context.");
                generator.Emit(OpCodes.Newobj, typeof(Exception).GetConstructor(new[] {typeof(string)}));
                generator.Emit(OpCodes.Throw);

                return (TDelegate) method.CreateDelegate(typeof(TDelegate));
            }

            return Marshal.GetDelegateForFunctionPointer<TDelegate>(ptr);
        }
    }
}