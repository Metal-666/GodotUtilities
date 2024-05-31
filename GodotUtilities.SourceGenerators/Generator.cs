using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Metal666.GodotUtilities.SourceGenerators;

[Generator]
public class Generator : IIncrementalGenerator {

	private List<string> Logs { get; set; } = new();
	private int LogIndent { get; set; } = 0;

	public void Initialize(IncrementalGeneratorInitializationContext igiContext) {

#nullable disable
		IncrementalValuesProvider<StateData> states =
			igiContext.SyntaxProvider
						.ForAttributeWithMetadataName("Metal666.GodotUtilities.Architecture.StateAttribute",
														(node, token) =>
																	node is ClassDeclarationSyntax classSyntax &&
																		classSyntax.Modifiers
																					.Any(SyntaxKind.PartialKeyword) &&
																		classSyntax.Modifiers
																					.Any(SyntaxKind.StaticKeyword),
														(gasContext, token) =>
																	gasContext.TargetSymbol is INamedTypeSymbol typeSymbol ?
																		new StateData(typeSymbol) : null)
						.Where(state =>
											state != null);
#nullable enable

		igiContext.RegisterSourceOutput(states,
										(spContext, state) => {

											Log($"Iterating over fields of {state.Name}");

											foreach(StateData.FieldData field in state.Fields) {

												Log($"Field: {field.Name}", 1);

												CompilationUnitSyntax compilationUnit =
													CompilationUnit()
														.WithAdditionalAnnotations(new SyntaxAnnotation("nullable", "enable"))
														.AddMembers(NamespaceDeclaration(IdentifierName(GetNamespaceRecursive(state.State)))
																			.WithLeadingTrivia(NullablePreprocessorDirective(true))
																			.NormalizeWhitespace()
																			.AddMembers(ClassDeclaration(default,
																												TokenList(Token(SyntaxKind.PublicKeyword),
																																			Token(SyntaxKind.StaticKeyword),
																																			Token(SyntaxKind.PartialKeyword)),
																												Identifier(state.Name),
																												null,
																												null,
																												default,
																												List(new MemberDeclarationSyntax[] {

																														PropertyDeclaration(default,
																																			TokenList(Token(SyntaxKind.PublicKeyword),
																																										Token(SyntaxKind.StaticKeyword)),
																																			IdentifierName(field.TypeName),
																																			null,
																																			Identifier(field.PropertyName),
																																			AccessorList(List(new AccessorDeclarationSyntax[] {

																																				AccessorDeclaration(SyntaxKind.GetAccessorDeclaration,
																																									Block(ParseStatement($"return {field.Name};"))),
																																				AccessorDeclaration(SyntaxKind.SetAccessorDeclaration,
																																										(BlockSyntax) ParseStatement($@"
{{

	{field.EventName}?.Invoke({field.Name}, value);
	{field.ListenerInterfaceName}.Invoke({field.Name}, value);
	{field.Name} = value;

}}
																																										").NormalizeWhitespace())

																																			})))
																															.NormalizeWhitespace(),
																														EventDeclaration(default,
																																			TokenList(Token(SyntaxKind.PublicKeyword),
																																										Token(SyntaxKind.StaticKeyword)),
																																			Token(SyntaxKind.EventKeyword),
																																			ParseTypeName($"System.Action<{field.TypeName}, {field.TypeName}>?"),
																																			null,
																																			Identifier(field.EventName),
																																			null,
																																			Token(SyntaxKind.SemicolonToken))
																															.NormalizeWhitespace(),
																														InterfaceDeclaration(default,
																																				TokenList(Token(SyntaxKind.PublicKeyword)),
																																				Identifier(field.ListenerInterfaceName),
																																				null,
																																				null,
																																				default,
																																				List(new MemberDeclarationSyntax[] {

																																					PropertyDeclaration(default,
																																										TokenList(Token(SyntaxKind.PrivateKeyword),
																																																	Token(SyntaxKind.StaticKeyword)),
																																										ParseTypeName($"System.Collections.Generic.List<Godot.WeakRef>"),
																																										null,
																																										Identifier("Listeners"),
																																										AccessorList(List(new AccessorDeclarationSyntax[] {

																																											AccessorDeclaration(SyntaxKind.GetAccessorDeclaration,
																																																default,
																																																default,
																																																Token(SyntaxKind.GetKeyword),
																																																null,
																																																null,
																																																Token(SyntaxKind.SemicolonToken))

																																										})),
																																										null,
																																										EqualsValueClause(ImplicitObjectCreationExpression())
																																													.NormalizeWhitespace(),
																																										Token(SyntaxKind.SemicolonToken))
																																						.NormalizeWhitespace(),
																																					MethodDeclaration(default,
																																										TokenList(Token(SyntaxKind.PublicKeyword)),
																																										PredefinedType(Token(SyntaxKind.VoidKeyword)),
																																										null,
																																										Identifier(field.EventName),
																																										null,
																																										ParameterList(SeparatedList(new ParameterSyntax[] {

																																											Parameter(default,
																																														default,
																																														IdentifierName(field.TypeName),
																																														Identifier("oldValue"),
																																														null),
																																											Parameter(default,
																																														default,
																																														IdentifierName(field.TypeName),
																																														Identifier("newValue"),
																																														null)

																																										})),
																																										default,
																																										null,
																																										null,
																																										Token(SyntaxKind.SemicolonToken))
																																						.NormalizeWhitespace(),
																																					ParseMemberDeclaration($@"
public static void Invoke({field.TypeName} oldValue, {field.TypeName} newValue) {{

	foreach(Godot.WeakRef listenerReference in new System.Collections.Generic.List<Godot.WeakRef>(Listeners)) {{

		{field.ListenerInterfaceName}? listener = ((Godot.GodotObject?) listenerReference.GetRef()) as {field.ListenerInterfaceName};

		if(listener == null) {{

			Listeners.Remove(listenerReference);

			Godot.GD.Print(""Removed stale listener"");

			continue;

		}}

		listener.{field.EventName}(oldValue, newValue);

	}}

}}
																																					")!.NormalizeWhitespace(),
																																					ParseMemberDeclaration($@"
public static void Subscribe(Godot.GodotObject listener) {{

	Listeners.Add(Godot.GodotObject.WeakRef(listener));

}}
																																					")!.NormalizeWhitespace()

																																				}))
																															.NormalizeWhitespace()

																												}))
																								.NormalizeWhitespace()
																			.NormalizeWhitespace()))
														.NormalizeWhitespace();

												string fileName =
													$"{state.Name}_{field.Name}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";

												spContext.AddSource($"{fileName}.g.cs",
																	compilationUnit.ToFullString());

												WriteLogs(spContext, $"{fileName}.logs");

											}

										});

#nullable disable

		IncrementalValuesProvider<CustomNodeData> customNodes =
			igiContext.SyntaxProvider
						.CreateSyntaxProvider((node, token) =>
														node is ClassDeclarationSyntax,
												(gsContext, token) =>
															gsContext.SemanticModel
																		.GetDeclaredSymbol(gsContext.Node) as INamedTypeSymbol)
						.Where(potentialListener =>
											potentialListener != null)
						.Combine(states.Collect())
						.Select((pair, token) => {

							INamedTypeSymbol customNode = pair.Left!;

							IEnumerable<(string InterfaceName, string StateName)> interfaces =
								pair.Right
									.SelectMany(state =>
															state.Fields
																	.Select(field =>
																						field.ListenerInterfaceName)
																	.Select(interfaceName =>
																						(InterfaceName: interfaceName,
																							StateName: state.Name)));

							IEnumerable<string> listenerInterfaceNames =
								customNode.Interfaces
											.Select(interfaceSymbol => {

												foreach((string InterfaceName, string StateName) in interfaces) {

													string fullName = $"{StateName}.{InterfaceName}";

													if(interfaceSymbol.Name.Equals(InterfaceName) ||
														interfaceSymbol.Name.Equals(fullName)) {

														return fullName;

													}

												}

												return null;

											})
											.OfType<string>();

							return new CustomNodeData(customNode,
														listenerInterfaceNames.ToList(),
														customNode.GetAttributes()
																			.Any(attributeData => {

																				INamedTypeSymbol attributeClass =
																					attributeData.AttributeClass!;

																				return "Metal666.GodotUtilities.Architecture.SingletonAttribute" ==
																							$"{GetNamespaceRecursive(attributeClass)}.{attributeClass.Name}";

																			}));

						})
						.Where(listener =>
											listener.ListenerInterfaceNames.Count > 0 ||
											listener.IsSingleton);
#nullable enable

		igiContext.RegisterSourceOutput(customNodes,
										(spContext, customNode) => {

											Log($"Processing custom node: {customNode.CustomNode.Name}", 1);

											Log($"Is Singleton: {customNode.IsSingleton}");

											Log("Listener Interfaces:");

											LogIndent++;

											foreach(string listenerInterfaceName in customNode.ListenerInterfaceNames) {

												Log(listenerInterfaceName);

											}

											LogIndent--;

											string customNodeName = customNode.CustomNode.Name;

											CompilationUnitSyntax compilationUnit =
												CompilationUnit()
													.AddMembers(NamespaceDeclaration(IdentifierName(GetNamespaceRecursive(customNode.CustomNode)))
																		.WithLeadingTrivia(NullablePreprocessorDirective(true))
																		.NormalizeWhitespace()
																		.AddMembers(ClassDeclaration(default,
																											TokenList(Token(SyntaxKind.PublicKeyword),
																																		Token(SyntaxKind.PartialKeyword)),
																											Identifier(customNodeName),
																											null,
																											null,
																											default,
																											List(new MemberDeclarationSyntax?[] {

																												customNode.IsSingleton ?
																													PropertyDeclaration(default,
																																		TokenList(Token(SyntaxKind.PublicKeyword),
																																						Token(SyntaxKind.StaticKeyword)),
																																		IdentifierName(customNodeName),
																																		null,
																																		Identifier("Instance"),
																																		AccessorList(List(new AccessorDeclarationSyntax[] {

																																			AccessorDeclaration(SyntaxKind.GetAccessorDeclaration,
																																								default,
																																								default,
																																								Token(SyntaxKind.GetKeyword),
																																								null,
																																								null,
																																								Token(SyntaxKind.SemicolonToken)),
																																			AccessorDeclaration(SyntaxKind.SetAccessorDeclaration,
																																								default,
																																								default,
																																								Token(SyntaxKind.SetKeyword),
																																								null,
																																								null,
																																								Token(SyntaxKind.SemicolonToken))

																																		})))
																														.WithLeadingTrivia(NullablePreprocessorDirective(false))
																														.WithTrailingTrivia(NullablePreprocessorDirective(true))
																														.NormalizeWhitespace() :
																													null,
																												ParseMemberDeclaration($@"
public {customNodeName}() {{

	{(customNode.IsSingleton ?
		"Instance = this;" :
		"")}

	{string.Join("\n",
				customNode.ListenerInterfaceNames
								.Select(interfaceName =>
													$"{interfaceName}.Subscribe(this);"))}

}}
																												")!.NormalizeWhitespace()

																											}.OfType<MemberDeclarationSyntax>()))
																							.NormalizeWhitespace())
																		.NormalizeWhitespace())
													.NormalizeWhitespace();

											string fileName =
												$"{customNodeName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";

											spContext.AddSource($"{fileName}.g.cs",
																compilationUnit.ToFullString());

											WriteLogs(spContext, $"{fileName}.logs");

										});

	}

	private SyntaxTrivia NullablePreprocessorDirective(bool enable) =>
		Trivia(NullableDirectiveTrivia(Token(enable ?
																	SyntaxKind.EnableKeyword :
																	SyntaxKind.DisableKeyword),
											true));

	private string GetNamespaceRecursive(INamedTypeSymbol symbol) {

		StringBuilder result = new();

		void GetNamespace(INamespaceSymbol namespaceSymbol) {

			result.Insert(0, namespaceSymbol.Name);

			INamespaceSymbol containingNamespaceSymbol =
				namespaceSymbol.ContainingNamespace;

			if(containingNamespaceSymbol == null ||
				containingNamespaceSymbol.IsGlobalNamespace) {

				return;

			}

			result.Insert(0, '.');

			GetNamespace(containingNamespaceSymbol);

		}

		GetNamespace(symbol.ContainingNamespace);

		return result.ToString();

	}

	private void Log(string message, int indent = 0) {

		LogIndent += indent;

		Logs.Add(string.Concat(Enumerable.Range(0, LogIndent)
													.Select(_ => "\t")
													.Append(message)));

	}

	private void WriteLogs(SourceProductionContext spContext, string hint) {

#if DEBUG

		spContext.AddSource(hint, string.Join("\n", Logs));

		Logs.Clear();

		LogIndent = 0;

#endif

	}

}

public record StateData {

	public INamedTypeSymbol State { get; }

	public string Name { get; }
	public List<FieldData> Fields { get; }

	public StateData(INamedTypeSymbol state) {

		State = state;
		Name = State.Name;
		Fields =
			State.GetMembers()
					.OfType<IFieldSymbol>()
					.Select(fieldSymbol =>
										new FieldData(fieldSymbol))
					.ToList();

	}

	public record FieldData {

		public IFieldSymbol Field { get; }

		public ITypeSymbol Type { get; }
		public string TypeName { get; }
		public string Name { get; }
		public string PropertyName { get; }
		public string EventName { get; }
		public string ListenerInterfaceName { get; }

		public FieldData(IFieldSymbol field) {

			Field = field;
			Type = Field.Type;
			TypeName = Type.ToString();
			Name = Field.Name;
			PropertyName =
				string.Concat(Name.Skip(1)
										.Prepend(char.ToUpperInvariant(Name.First())));
			EventName = $"On{PropertyName}Changed";
			ListenerInterfaceName = $"I{PropertyName}ChangedListener";

		}

	}

}

public record CustomNodeData {

	public INamedTypeSymbol CustomNode { get; }
	public List<string> ListenerInterfaceNames { get; }
	public bool IsSingleton { get; }

	public CustomNodeData(INamedTypeSymbol customNode,
							List<string> listenerInterfaceNames,
							bool isSingleton) {

		CustomNode = customNode;
		ListenerInterfaceNames = listenerInterfaceNames;
		IsSingleton = isSingleton;

	}

}