using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Aspect.Data.Generator
{
    /// <summary>
    /// The serializable syntax receiver class
    /// </summary>
    /// <seealso cref="ISyntaxReceiver"/>
    internal class SerializableSyntaxReceiver : ISyntaxReceiver
    {
        /// <summary>
        /// Gets the value of the candidate types
        /// </summary>
        public List<TypeDeclarationSyntax> CandidateTypes { get; } = new();
        

        /// <summary>
        /// Ons the visit syntax node using the specified syntax node
        /// </summary>
        /// <param name="syntaxNode">The syntax node</param>
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is TypeDeclarationSyntax typeDeclaration &&
                typeDeclaration.AttributeLists.Count > 0)
            {
                foreach (AttributeListSyntax attributeList in typeDeclaration.AttributeLists)
                {
                    foreach (AttributeSyntax attribute in attributeList.Attributes)
                    {
                        string attributeName = attribute.Name.ToString();
                        if (attributeName is "Serializable" or "SerializableAttribute")
                        {
                            CandidateTypes.Add(typeDeclaration);
                            break;
                        }
                    }
                }
            }
        }
    }
}