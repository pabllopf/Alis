

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Aspect.Data.Generator
{
    /// <summary>
    ///     Syntax receiver that identifies type declarations marked with the [Serializable] attribute.
    ///     This receiver collects all candidate types that should have serialization code generated.
    /// </summary>
    /// <seealso cref="ISyntaxReceiver" />
    internal class SerializableSyntaxReceiver : ISyntaxReceiver
    {
        /// <summary>
        ///     Gets the list of type declarations that are candidates for code generation.
        ///     Only types marked with [Serializable] or [SerializableAttribute] will be included.
        /// </summary>
        /// <value>A list of type declaration syntax nodes.</value>
        public List<TypeDeclarationSyntax> CandidateTypes { get; } = new();

        /// <summary>
        ///     Visits a syntax node and collects type declarations with the [Serializable] attribute.
        /// </summary>
        /// <param name="syntaxNode">The syntax node to visit.</param>
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is not TypeDeclarationSyntax typeDeclaration || typeDeclaration.AttributeLists.Count == 0)
            {
                return;
            }

            foreach (AttributeListSyntax attributeList in typeDeclaration.AttributeLists)
            {
                foreach (AttributeSyntax attribute in attributeList.Attributes)
                {
                    string attributeName = attribute.Name.ToString();
                    if (attributeName is "Serializable" or "SerializableAttribute")
                    {
                        CandidateTypes.Add(typeDeclaration);
                        return;
                    }
                }
            }
        }
    }
}