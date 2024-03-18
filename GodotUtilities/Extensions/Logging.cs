using Godot;

using Metal666.GodotUtilities.Logging;

using System.Linq;

namespace Metal666.GodotUtilities.Extensions;

public static class Logging {

	public static int Indent { get; set; }

	public static void Log(this Node node,
							string message,
							LogLevel logLevel) {

		AdvancedSceneTreeBase? advancedSceneTree =
			node.GetTree<AdvancedSceneTreeBase>();

		if(advancedSceneTree == null) {

			GD.PushError($"Failed to write log: current tree type does not inherit {typeof(AdvancedSceneTreeBase)}!");

			return;

		}

		advancedSceneTree.Log(string.Concat(Enumerable.Range(0, Indent)
														.Select(_ => "⏤")
														.If(args => args.Any(),
															args => args.Append(" "))
														.Append(message)),
								logLevel,
								node.GetType());

	}

	public static void LogMessage(this Node node, string message) =>
		Log(node, message, LogLevel.Message);

	public static void LogWarning(this Node node, string message) =>
		Log(node, message, LogLevel.Warning);

	public static void LogError(this Node node, string message) =>
		Log(node, message, LogLevel.Error);

	public static void LogIndent(this Node _) =>
		Indent++;
	public static void LogUnindent(this Node _) =>
		Indent--;

}