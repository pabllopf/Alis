

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Aspect.Data.Generator
{
    /// <summary>
    ///     Source generator for automatic JSON serialization and deserialization code generation.
    ///     This generator scans for types decorated with the [Serializable] attribute and generates
    ///     implementations of IJsonSerializable and IJsonDesSerializable interfaces.
    /// </summary>
    /// <seealso cref="ISourceGenerator" />
    [Generator]
    public class SerializableSourceGenerator : ISourceGenerator
    {
        /// <summary>
        ///     Initializes the generator by registering the syntax receiver.
        /// </summary>
        /// <param name="context">The generator initialization context.</param>
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SerializableSyntaxReceiver());
        }

        /// <summary>
        ///     Executes the source generation for all types marked with [Serializable] attribute.
        /// </summary>
        /// <param name="context">The generator execution context.</param>
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not SerializableSyntaxReceiver receiver)
            {
                return;
            }

            foreach (TypeDeclarationSyntax typeDeclaration in receiver.CandidateTypes)
            {
                SemanticModel model = context.Compilation.GetSemanticModel(typeDeclaration.SyntaxTree);
                ISymbol symbol = model.GetDeclaredSymbol(typeDeclaration);

                if (symbol is not INamedTypeSymbol typeSymbol)
                {
                    continue;
                }

                SerializationCodeBuilder builder = new SerializationCodeBuilder(typeSymbol);
                string source = builder.Build();
                context.AddSource($"{typeSymbol.Name}_Serialization.g.cs", source);
            }
        }
    }
}