using Metal666.GodotUtilities.Common.Attributes;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System;
using System.Collections.Generic;

namespace Metal666.GodotUtilities.SourceGenerators.Singleton;

public abstract class GeneratorBase : IIncrementalGenerator {

	public virtual void Initialize(IncrementalGeneratorInitializationContext igiContext) {

		igiContext.RegisterSourceOutput(GetClassDeclarationsAndCompilationProvider(igiContext.SyntaxProvider,
																							igiContext.CompilationProvider),
										(spContext,
												classDeclarationAndCompilation) => {

													(string HintName, CompilationUnitSyntax CompilationUnit)? result =
														RegisterSourceOutput(classDeclarationAndCompilation.Item1,
																				classDeclarationAndCompilation.Item2);

													if(!result.HasValue) {

														return;

													}

													spContext.AddSource(result.Value
																						.HintName,
																		result.Value
																					.CompilationUnit
																					.NormalizeWhitespace()
																					.ToFullString());

												});

	}

	protected virtual IncrementalValuesProvider<(ClassDeclarationSyntax, Compilation)> GetClassDeclarationsAndCompilationProvider(SyntaxValueProvider syntaxProvider,
																																	IncrementalValueProvider<Compilation> compilationProvider) {

		IncrementalValuesProvider<ClassDeclarationSyntax> classDeclarations =
			syntaxProvider.ForAttributeWithMetadataName(typeof(SingletonAttribute).FullName,
														static (node, _) =>
																	node is ClassDeclarationSyntax,
														static (context, _) =>
																	(ClassDeclarationSyntax) context.TargetNode);

		return classDeclarations.Combine(compilationProvider);

	}

	protected virtual (string hintName, CompilationUnitSyntax compilationUnit)? RegisterSourceOutput(ClassDeclarationSyntax classDeclaration,
																										Compilation compilation) =>
		null;

	protected virtual CompilationUnitSyntax? GeneratePartialClass(ClassDeclarationSyntax classDeclaration,
																	Compilation compilation,
																	Func<ClassDeclarationSyntax, ClassDeclarationSyntax> modifyClassDeclaration) {

		INamedTypeSymbol? classSymbol =
			GetNamedTypeSymbol(classDeclaration, compilation);

		if(classSymbol == null) {

			return null;

		}

		INamedTypeSymbol? baseClassSymbol =
			classSymbol.BaseType;

		if(baseClassSymbol == null) {

			return null;

		}

		string fullyQualifiedClassName =
			GetFullyQualifiedClassName(classSymbol, true);

		string namespaceName =
			fullyQualifiedClassName.Remove(fullyQualifiedClassName.Length -
														(classSymbol.Name.Length + 1));

		CompilationUnitSyntax compilationUnit =
			SyntaxFactory.CompilationUnit();

		NamespaceDeclarationSyntax namespaceDeclaration =
			SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(namespaceName)
																	.WithLeadingTrivia(SyntaxFactory.Space));

		ClassDeclarationSyntax generatedClassDeclaration =
			classDeclaration.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(new List<BaseTypeSyntax>() {

				SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(GetFullyQualifiedClassName(baseClassSymbol, false)))

			}))).WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>());

		generatedClassDeclaration =
			modifyClassDeclaration(generatedClassDeclaration);

		namespaceDeclaration =
			namespaceDeclaration.AddMembers(generatedClassDeclaration);

		compilationUnit =
			compilationUnit.AddMembers(namespaceDeclaration);

		return compilationUnit;

	}

	protected static string GetFullyQualifiedClassName(INamedTypeSymbol symbol, bool removeGlobal) {

		string result =
			symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

		if(removeGlobal) {

			result =
				result.Replace("global::", "");

		}

		return result;

	}

	protected virtual INamedTypeSymbol? GetNamedTypeSymbol(ClassDeclarationSyntax classDeclaration,
															Compilation compilation) =>
		compilation.GetSemanticModel(classDeclaration.SyntaxTree)
						.GetDeclaredSymbol(classDeclaration);

}