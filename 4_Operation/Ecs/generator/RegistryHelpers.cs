
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Ecs.Generator
{
    /// <summary>
    /// The registry helpers class
    /// </summary>
    public static class RegistryHelpers
    {
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="names"></param>
        /// <returns></returns>
        public static StringBuilder AppendNamespace(this StringBuilder sb, string names)
        {
            if (names == string.Empty)
                return sb;
            return sb.Append(names).Append('.');
        }

        /// <summary>
        /// Appends the full type name using the specified sb
        /// </summary>
        /// <param name="sb">The sb</param>
        /// <param name="typeName">The type name</param>
        /// <returns>The string builder</returns>
        public static StringBuilder AppendFullTypeName(this StringBuilder sb, string typeName)
        {
            return sb.Append("").Append(typeName);
        }

        /// <summary>
        /// Ises the partial using the specified named type symbol
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
        /// Ises the or extends i component base using the specified symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>The bool</returns>
        public static bool IsOrExtendsIComponentBase(this INamedTypeSymbol symbol)
        {
            if (symbol.IsIComponentBase())
                return true;
            foreach(var @interface in symbol.Interfaces)
            {
                if(@interface.IsIComponentBase())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Ises the i component base using the specified symbol
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
        /// Ises the special component interface using the specified named type symbol
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
        /// Ises the alis component interface using the specified type
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

        /// <summary>
        /// The update type attribute name
        /// </summary>
        public const string UpdateTypeAttributeName = "Alis.Core.Ecs.Updating.UpdateTypeAttribute";
        /// <summary>
        /// The update method name
        /// </summary>
        public const string UpdateMethodName = "Update";
        /// <summary>
        /// The fully qualified target interface name
        /// </summary>
        public const string FullyQualifiedTargetInterfaceName = "Alis.Core.Aspect.Fluent.Components.IComponentBase";
        /// <summary>
        /// The fully qualified initable interface name
        /// </summary>
        public const string FullyQualifiedInitableInterfaceName = "Alis.Core.Aspect.Fluent.Components.IInitable";
        /// <summary>
        /// The fully qualified destroyable interface name
        /// </summary>
        public const string FullyQualifiedDestroyableInterfaceName = "Alis.Core.Aspect.Fluent.Components.IDestroyable";

        /// <summary>
        /// The target interface name
        /// </summary>
        public const string TargetInterfaceName = "IComponentBase";
        /// <summary>
        /// The initable interface name
        /// </summary>
        public const string InitableInterfaceName = "IInitable";
        /// <summary>
        /// The destroyable interface name
        /// </summary>
        public const string DestroyableInterfaceName = "IDestroyable";
    }
}

