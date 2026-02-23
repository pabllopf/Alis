// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SerializableSourceGenerator.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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

                // Generate serialization and deserialization code
                var builder = new SerializationCodeBuilder(typeSymbol);
                string source = builder.Build();
                context.AddSource($"{typeSymbol.Name}_Serialization.g.cs", source);
            }
        }
    }
}
