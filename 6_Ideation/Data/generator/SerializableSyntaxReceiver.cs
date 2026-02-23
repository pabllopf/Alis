// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SerializableSyntaxReceiver.cs
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