// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProxyGenerator.cs
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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    /// The method interceptor class
    /// </summary>
    public static class MethodInterceptor
    {
        /// <summary>
        /// Creates the interceptor using the specified instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="instance">The instance</param>
        /// <returns>The</returns>
        public static T CreateInterceptor<T>(T instance) where T : class
        {
            Type type = typeof(T);
            TypeBuilder typeBuilder = CreateDynamicTypeBuilder(type);

            foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                PrePostMethodAttribute attribute = method.GetCustomAttribute<PrePostMethodAttribute>();
                if (attribute != null)
                {
                    MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                        method.Name,
                        MethodAttributes.Public | MethodAttributes.Virtual,
                        CallingConventions.Standard,
                        method.ReturnType,
                        Type.EmptyTypes
                    );

                    ILGenerator ilGenerator = methodBuilder.GetILGenerator();
                    GenerateMethodBody(ilGenerator, method, attribute);
                    typeBuilder.DefineMethodOverride(methodBuilder, method);
                }
            }

            Type proxyType = typeBuilder.CreateType();
            ConstructorInfo constructor = proxyType.GetConstructor(new[] { type });
            return (T)constructor.Invoke(new object[] { instance });
        }

        /// <summary>
        /// Creates the dynamic type builder using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The type builder</returns>
        private static TypeBuilder CreateDynamicTypeBuilder(Type type)
        {
            string assemblyName = type.FullName + "ProxyAssembly";
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName(assemblyName),
                AssemblyBuilderAccess.Run
            );

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName);
            string typeName = type.Name + "Proxy";
            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                typeName,
                TypeAttributes.Public | TypeAttributes.Class,
                type
            );

            ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.HasThis,
                new[] { type }
            );

            ILGenerator constructorIL = constructorBuilder.GetILGenerator();
            constructorIL.Emit(OpCodes.Ldarg_0);
            constructorIL.Emit(OpCodes.Call, type.GetConstructor(Type.EmptyTypes));
            constructorIL.Emit(OpCodes.Ret);

            return typeBuilder;
        }

        /// <summary>
        /// Generates the method body using the specified il generator
        /// </summary>
        /// <param name="ilGenerator">The il generator</param>
        /// <param name="method">The method</param>
        /// <param name="attribute">The attribute</param>
        private static void GenerateMethodBody(ILGenerator ilGenerator, MethodInfo method, PrePostMethodAttribute attribute)
        {
            MethodInfo onEntryMethod = typeof(PrePostMethodAttribute).GetMethod("OnEntry");
            MethodInfo onExitMethod = typeof(PrePostMethodAttribute).GetMethod("OnExit");

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Callvirt, onEntryMethod);

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, method);

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Callvirt, onExitMethod);

            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
