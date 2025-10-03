// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RegistryHelpers.cs
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

using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Ecs.Generator
{
    /// <summary>
    ///     The registry helpers class
    /// </summary>
    public static class RegistryHelpers
    {
        /// <summary>
        ///     The update type attribute name
        /// </summary>
        public const string UpdateTypeAttributeName = "Alis.Core.Ecs.Updating.UpdateTypeAttribute";

        /// <summary>
        ///     The update method name
        /// </summary>
        public const string UpdateMethodName = "OnUpdate";

        /// <summary>
        ///     The fully qualified target interface name
        /// </summary>
        public const string FullyQualifiedTargetInterfaceName = "Alis.Core.Aspect.Fluent.Components.IComponentBase";

        /// <summary>
        ///     The fully qualified initable interface name
        /// </summary>
        public const string FullyQualifiedInitableInterfaceName = "Alis.Core.Aspect.Fluent.Components.IOnInit";

        /// <summary>
        ///     The fully qualified destroyable interface name
        /// </summary>
        public const string FullyQualifiedDestroyableInterfaceName = "Alis.Core.Aspect.Fluent.Components.IOnDestroy";

        /// <summary>
        ///     The target interface name
        /// </summary>
        public const string TargetInterfaceName = "IComponentBase";

        /// <summary>
        ///     The initable interface name
        /// </summary>
        public const string InitableInterfaceName = "IOnInit";

        /// <summary>
        ///     The destroyable interface name
        /// </summary>
        public const string DestroyableInterfaceName = "IOnDestroy";

        /// <summary>
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="names"></param>
        /// <returns></returns>
        public static StringBuilder AppendNamespace(this StringBuilder sb, string names)
        {
            if (names == string.Empty)
            {
                return sb;
            }

            return sb.Append(names).Append('.');
        }

        /// <summary>
        ///     Appends the full type name using the specified sb
        /// </summary>
        /// <param name="sb">The sb</param>
        /// <param name="typeName">The type name</param>
        /// <returns>The string builder</returns>
        public static StringBuilder AppendFullTypeName(this StringBuilder sb, string typeName) => sb.Append("").Append(typeName);

        /// <summary>
        ///     Ises the partial using the specified named type symbol
        /// </summary>
        /// <param name="namedTypeSymbol">The named type symbol</param>
        /// <returns>The bool</returns>
        public static bool IsPartial(this INamedTypeSymbol namedTypeSymbol)
        {
            return namedTypeSymbol.DeclaringSyntaxReferences
                .Select(syntaxRef => syntaxRef.GetSyntax() as TypeDeclarationSyntax)
                .Any(syntax => syntax?.Modifiers.Any(SyntaxKind.PartialKeyword) ?? false);
        }

        /// <summary>
        ///     Ises the or extends i component base using the specified symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>The bool</returns>
        public static bool IsOrExtendsIComponentBase(this INamedTypeSymbol symbol)
        {
            if (symbol.IsIComponentBase())
            {
                return true;
            }

            foreach (INamedTypeSymbol @interface in symbol.Interfaces)
            {
                if (@interface.IsIComponentBase())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Ises the i component base using the specified symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>The bool</returns>
        public static bool IsIComponentBase(this INamedTypeSymbol symbol) => symbol is
        {
            Name: TargetInterfaceName,
            ContainingNamespace:
            {
                Name: "Components",
                ContainingNamespace:
                {
                    Name: "Fluent",
                    ContainingNamespace:
                    {
                        Name: "Aspect",
                        ContainingNamespace:
                        {
                            Name: "Core",
                            ContainingNamespace:
                            {
                                Name: "Alis",
                                ContainingNamespace.IsGlobalNamespace: true
                            }
                        }
                    }
                }
            }
        };

        /// <summary>
        ///     Ises the special component interface using the specified named type symbol
        /// </summary>
        /// <param name="namedTypeSymbol">The named type symbol</param>
        /// <returns>The bool</returns>
        public static bool IsSpecialComponentInterface(this INamedTypeSymbol namedTypeSymbol) => namedTypeSymbol is
        {
            Name: TargetInterfaceName or InitableInterfaceName or DestroyableInterfaceName,
            ContainingNamespace:
            {
                Name: "Components",
                ContainingNamespace:
                {
                    Name: "Fluent",
                    ContainingNamespace:
                    {
                        Name: "Aspect",
                        ContainingNamespace:
                        {
                            Name: "Core",
                            ContainingNamespace:
                            {
                                Name: "Alis",
                                ContainingNamespace.IsGlobalNamespace: true
                            }
                        }
                    }
                }
            }
        };

        /// <summary>
        ///     Ises the alis component interface using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public static bool IsAlisComponentInterface(this INamedTypeSymbol type) => type is
        {
            ContainingNamespace:
            {
                Name: "Components",
                ContainingNamespace:
                {
                    Name: "Fluent",
                    ContainingNamespace:
                    {
                        Name: "Aspect",
                        ContainingNamespace:
                        {
                            Name: "Core",
                            ContainingNamespace:
                            {
                                Name: "Alis",
                                ContainingNamespace.IsGlobalNamespace: true
                            }
                        }
                    }
                }
            }
        };
    }
}