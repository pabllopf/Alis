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
    /// The generator analyzer class
    /// </summary>
    /// <seealso cref="DiagnosticAnalyzer"/>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    internal class GeneratorAnalyzer : DiagnosticAnalyzer
    {
       /// <summary>
       /// Gets the value of the supported diagnostics
       /// </summary>
       public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics.ToImmutableArray();
       
        /// <summary>
        /// The supported diagnostics
        /// </summary>
        private static readonly FastImmutableArray<DiagnosticDescriptor> _supportedDiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratorAnalyzer"/> class
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
        /// Initializes the context
        /// </summary>
        /// <param name="context">The context</param>
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(AnalyzeTypeDeclaration, SyntaxKind.ClassDeclaration, SyntaxKind.StructDeclaration, SyntaxKind.InterfaceDeclaration);
        }
    
        /// <summary>
        /// Analyzes the type declaration using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeTypeDeclaration(SyntaxNodeAnalysisContext context)
        {
            TypeDeclarationSyntax typeDeclarationSyntax = (TypeDeclarationSyntax)context.Node;
            if (context.SemanticModel.GetDeclaredSymbol(typeDeclarationSyntax) is not INamedTypeSymbol namedTypeSymbol)
                return;

            bool isComponent = false;
            int updateInterfaceCount = 0;


            foreach(INamedTypeSymbol @interface in namedTypeSymbol.AllInterfaces)
            {
                if (!@interface.IsOrExtendsIComponentBase())
                    return;

                isComponent = true;
                if(!@interface.IsSpecialComponentInterface() && @interface.IsAlisComponentInterface())
                {
                    updateInterfaceCount++;
                }
            }
            if (!isComponent)
                return;

            bool isPartial = namedTypeSymbol.IsPartial();
            bool componentTypeIsAcsessableFromModule =
                namedTypeSymbol.DeclaredAccessibility == Accessibility.Public ||
                namedTypeSymbol.DeclaredAccessibility == Accessibility.Internal;

            if (!isPartial)
            {
                if(namedTypeSymbol.IsGenericType)
                {
                    Report(NonPartialGenericComponent, namedTypeSymbol, namedTypeSymbol.Name);
                }
                else if(!componentTypeIsAcsessableFromModule)
                {
                    Report(NonPartialNestedInaccessibleType, namedTypeSymbol, namedTypeSymbol.Name);
                }
            }

            INamedTypeSymbol current = namedTypeSymbol;
            while (current.ContainingType is not null)
            {
                current = current.ContainingType;

                if (!componentTypeIsAcsessableFromModule && !current.IsPartial())
                    Report(NonPartialOuterInaccessibleType, current, current.Name);
            }

            if(updateInterfaceCount > 1)
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
        /// The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor NonPartialGenericComponent = new(
            id: "FR0000",
            title: "Non-partial Generic Component Type",
            messageFormat: "Generic Component '{0}' must be marked as partial",
            category: "Source Generation",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor NonPartialOuterInaccessibleType = new(
            id: "FR0001",
            title: "Non-partial Outer Inaccessible Type",
            messageFormat: "Outer type of inaccessible nested component type '{0}' must be marked as partial",
            category: "Source Generation",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor NonPartialNestedInaccessibleType = new(
            id: "FR0002",
            title: "Non-partial Nested Inaccessible Component Type",
            messageFormat: "Inaccessible Nested Component Type '{0}' must be marked as partial",
            category: "Source Generation",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        public static readonly DiagnosticDescriptor MultipleComponentInterfaces = new(
            id: "FR0003",
            title: "Multiple Component Interface Implementations",
            messageFormat: "Components should only implement one update component interface",
            category: "Source Generation",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);
    }
}
