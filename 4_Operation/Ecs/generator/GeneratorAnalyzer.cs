// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneratorAnalyzer.cs
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

using System.Collections.Immutable;
using System.Linq;
using Alis.Core.Ecs.Generator.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Alis.Core.Ecs.Generator
{
    /// <summary>
    ///     The generator analyzer class
    /// </summary>
    /// <seealso cref="DiagnosticAnalyzer" />
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    internal class GeneratorAnalyzer : DiagnosticAnalyzer
    {
        /// <summary>
        ///     The supported diagnostics
        /// </summary>
        private static readonly FastImmutableArray<DiagnosticDescriptor> _supportedDiagnostics;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GeneratorAnalyzer" /> class
        /// </summary>
        static GeneratorAnalyzer()
        {
            FastImmutableArray<DiagnosticDescriptor>.Builder b = FastImmutableArray<DiagnosticDescriptor>.CreateBuilder<DiagnosticDescriptor>(4);
            b.Add(NonPartialGenericComponent);
            b.Add(NonPartialOuterInaccessibleType);
            b.Add(NonPartialNestedInaccessibleType);
            b.Add(MultipleComponentInterfaces);
            _supportedDiagnostics = b.MoveToImmutable();
        }

        /// <summary>
        ///     Gets the value of the supported diagnostics
        /// </summary>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics.ToImmutableArray();

        /// <summary>
        ///     Initializes the context
        /// </summary>
        /// <param name="context">The context</param>
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(AnalyzeTypeDeclaration, SyntaxKind.ClassDeclaration, SyntaxKind.StructDeclaration, SyntaxKind.InterfaceDeclaration);
        }

        /// <summary>
        ///     Analyzes the type declaration using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeTypeDeclaration(SyntaxNodeAnalysisContext context)
        {
            TypeDeclarationSyntax typeDeclarationSyntax = (TypeDeclarationSyntax) context.Node;
            if (context.SemanticModel.GetDeclaredSymbol(typeDeclarationSyntax) is not INamedTypeSymbol namedTypeSymbol)
            {
                return;
            }

            bool isComponent = false;
            int updateInterfaceCount = 0;


            foreach (INamedTypeSymbol @interface in namedTypeSymbol.AllInterfaces)
            {
                if (!@interface.IsOrExtendsIComponentBase())
                {
                    return;
                }

                isComponent = true;
                if (!@interface.IsSpecialComponentInterface() && @interface.IsAlisComponentInterface())
                {
                    updateInterfaceCount++;
                }
            }

            if (!isComponent)
            {
                return;
            }

            bool isPartial = namedTypeSymbol.IsPartial();
            bool componentTypeIsAcsessableFromModule =
                namedTypeSymbol.DeclaredAccessibility == Accessibility.Public ||
                namedTypeSymbol.DeclaredAccessibility == Accessibility.Internal;

            if (!isPartial)
            {
                if (namedTypeSymbol.IsGenericType)
                {
                    Report(NonPartialGenericComponent, namedTypeSymbol, namedTypeSymbol.Name);
                }
                else if (!componentTypeIsAcsessableFromModule)
                {
                    Report(NonPartialNestedInaccessibleType, namedTypeSymbol, namedTypeSymbol.Name);
                }
            }

            INamedTypeSymbol current = namedTypeSymbol;
            while (current.ContainingType is not null)
            {
                current = current.ContainingType;

                if (!componentTypeIsAcsessableFromModule && !current.IsPartial())
                {
                    Report(NonPartialOuterInaccessibleType, current, current.Name);
                }
            }

            if (updateInterfaceCount > 1)
            {
                Report(MultipleComponentInterfaces, current);
            }

            void Report(DiagnosticDescriptor diagnosticDescriptor, ISymbol location, params object[] args)
            {
                context.ReportDiagnostic(Diagnostic.Create(diagnosticDescriptor, location.Locations.First(), args));
            }
        }

#pragma warning disable RS2008 // Enable analyzer release tracking
        /// <summary>
        ///     The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor NonPartialGenericComponent = new(
            "FR0000",
            "Non-partial Generic Component Type",
            "Generic Component '{0}' must be marked as partial",
            "Source Generation",
            DiagnosticSeverity.Error,
            true);

        /// <summary>
        ///     The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor NonPartialOuterInaccessibleType = new(
            "FR0001",
            "Non-partial Outer Inaccessible Type",
            "Outer type of inaccessible nested component type '{0}' must be marked as partial",
            "Source Generation",
            DiagnosticSeverity.Error,
            true);

        /// <summary>
        ///     The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor NonPartialNestedInaccessibleType = new(
            "FR0002",
            "Non-partial Nested Inaccessible Component Type",
            "Inaccessible Nested Component Type '{0}' must be marked as partial",
            "Source Generation",
            DiagnosticSeverity.Error,
            true);

        /// <summary>
        ///     The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor MultipleComponentInterfaces = new(
            "FR0003",
            "Multiple Component Interface Implementations",
            "Components should only implement one update component interface",
            "Source Generation",
            DiagnosticSeverity.Warning,
            true);
    }
}