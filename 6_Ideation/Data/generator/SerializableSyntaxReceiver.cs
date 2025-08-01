using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Aspect.Data.Generator
{
    internal class SerializableSyntaxReceiver : ISyntaxReceiver
    {
        public List<TypeDeclarationSyntax> CandidateTypes { get; } = new();
        

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
                        if (attributeName == "Serializable" || attributeName == "SerializableAttribute")
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