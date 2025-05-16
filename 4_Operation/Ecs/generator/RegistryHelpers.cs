using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Ecs.Generator
{
    public static class RegistryHelpers
    {
        public static StringBuilder AppendNamespace(this StringBuilder sb, string @namespace)
        {
            if (@namespace == string.Empty)
                return sb;
            return sb.Append(@namespace).Append('.');
        }

        public static StringBuilder AppendFullTypeName(this StringBuilder sb, string typeName)
        {
            return sb.Append("global::").Append(typeName);
        }

        public static bool IsPartial(this INamedTypeSymbol namedTypeSymbol)
        {
            return namedTypeSymbol.DeclaringSyntaxReferences
                .Select(syntaxRef => syntaxRef.GetSyntax() as TypeDeclarationSyntax)
                .Any(syntax => syntax?.Modifiers.Any(SyntaxKind.PartialKeyword) ?? false);
        }

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

        public static bool IsIComponentBase(this INamedTypeSymbol symbol) => symbol is
        {
            Name: TargetInterfaceName,
            ContainingNamespace:
            {
                Name: "Components",
                ContainingNamespace:
                {
                    Name: "Ecs",
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
        };

        public static bool IsSpecialComponentInterface(this INamedTypeSymbol namedTypeSymbol) => namedTypeSymbol is
        {
            Name: TargetInterfaceName or InitableInterfaceName or DestroyableInterfaceName,
            ContainingNamespace:
            {
                Name: "Components",
                ContainingNamespace:
                {
                    Name: "Ecs",
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
        };

        public static bool IsAlisComponentInterface(this INamedTypeSymbol type) => type is
        {
         ContainingNamespace:
         {
             Name: "Components",
             ContainingNamespace:
             {
                 Name: "Ecs",
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
        };

        public const string UpdateTypeAttributeName = "Alis.Core.Ecs.Updating.UpdateTypeAttribute";
        public const string UpdateMethodName = "Update";
        public const string FullyQualifiedTargetInterfaceName = "Alis.Core.Ecs.Components.IComponentBase";
        public const string FullyQualifiedInitableInterfaceName = "Alis.Core.Ecs.Components.IInitable";
        public const string FullyQualifiedDestroyableInterfaceName = "Alis.Core.Ecs.Components.IDestroyable";

        public const string TargetInterfaceName = "IComponentBase";
        public const string InitableInterfaceName = "IInitable";
        public const string DestroyableInterfaceName = "IDestroyable";
    }
}

