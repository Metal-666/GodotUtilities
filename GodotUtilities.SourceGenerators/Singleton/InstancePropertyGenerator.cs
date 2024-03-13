using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Collections.Generic;

namespace Metal666.GodotUtilities.SourceGenerators.Singleton;

[Generator]
public class InstancePropertyGenerator : GeneratorBase {

	protected override (string hintName, CompilationUnitSyntax compilationUnit)? RegisterSourceOutput(ClassDeclarationSyntax classDeclaration,
																										Compilation compilation) {

		const string InstancePropertyName = "Instance";

		INamedTypeSymbol? classSymbol =
			GetNamedTypeSymbol(classDeclaration, compilation);

		if(classSymbol == null) {

			return null;

		}

		CompilationUnitSyntax? compilationUnit =
			GeneratePartialClass(classDeclaration,
									compilation,
									classDeclaration =>
														classDeclaration.WithMembers(SyntaxFactory.List(new List<MemberDeclarationSyntax>() {

															SyntaxFactory.PropertyDeclaration(SyntaxFactory.List<AttributeListSyntax>(),
																								SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword),
																																		SyntaxFactory.Token(SyntaxKind.StaticKeyword)),
																								SyntaxFactory.ParseTypeName(classSymbol.Name),
																								null,
																								SyntaxFactory.Identifier(InstancePropertyName),
																								SyntaxFactory.AccessorList(SyntaxFactory.List(new List<AccessorDeclarationSyntax>() {

																									SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
																													.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
																									SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
																													.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))

																								})))

														})));

		if(compilationUnit == null) {

			return null;

		}

		return ($"{GetFullyQualifiedClassName(classSymbol, true)}_Singleton{InstancePropertyName}Property.generated.cs",
				compilationUnit);

	}

}