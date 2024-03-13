using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Collections.Generic;

namespace Metal666.GodotUtilities.SourceGenerators.Singleton;

[Generator]
public class NotificationOverrideGenerator : GeneratorBase {

	protected override (string hintName, CompilationUnitSyntax compilationUnit)? RegisterSourceOutput(ClassDeclarationSyntax classDeclaration,
																										Compilation compilation) {

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

															SyntaxFactory.ParseMemberDeclaration(
"""
public override void _Notification(int what) {

	base._Notification(what);

	if(what == global::Godot.Node.NotificationEnterTree) {

		Instance = this;

	}

}
"""
															)!

														})));

		if(compilationUnit == null) {

			return null;

		}

		return ($"{GetFullyQualifiedClassName(classSymbol, true)}_SingletonNotificationOverride.generated.cs",
				compilationUnit);

	}

}