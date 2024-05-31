using Godot;

using Metal666.GodotUtilities.Logging;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Metal666.GodotUtilities.Extensions;

public static class Logging {

	public static int Indent { get; set; }

	public static void Log(this Node node,
							LogLevel logLevel,
							IndentAction indentAction,
							params string[] messages) {

		switch(indentAction) {

			case IndentAction.None: {

				break;

			}

			case IndentAction.Indent:
			case IndentAction.IndentOnce: {

				Indent++;

				break;

			}

			case IndentAction.Unindent: {

				Indent--;

				break;

			}

			case IndentAction.Reset: {

				Indent = 0;

				break;

			}

		}

		foreach(string message in messages) {

			LogManager.Log(message,
							logLevel,
							node.GetType(),
							Indent);

		}

		switch(indentAction) {

			case IndentAction.IndentOnce:
			case IndentAction.UnindentAfter: {

				Indent--;

				break;

			}

			case IndentAction.IndentAfter: {

				Indent++;

				break;

			}

			case IndentAction.ResetAfter: {

				Indent = 0;

				break;

			}

		}

	}

	public static void LogMessage(this Node node,
									string message,
									IndentAction indentAction = IndentAction.None) =>
		Log(node,
			LogLevel.Message,
			indentAction,
			message);

	public static void LogWarning(this Node node,
									string message,
									IndentAction indentAction = IndentAction.None) =>
		Log(node,
			LogLevel.Warning,
			indentAction,
			message);

	public static void LogError(this Node node,
								string message,
								IndentAction indentAction = IndentAction.None) =>
		Log(node,
			LogLevel.Error,
			indentAction,
			message);

	public static void LogIndent(this Node _) =>
		Indent++;
	public static void LogUnindent(this Node _) =>
		Indent--;

	public static IEnumerable<T> Log<T>(this IEnumerable<T> source,
										Node node,
										string message,
										LogLevel logLevel,
										IndentAction indentAction = IndentAction.None) {

		Log(node, logLevel, indentAction, message);

		return source;

	}

	public static IEnumerable<T> LogMessage<T>(this IEnumerable<T> source,
												Node node,
												string message,
												IndentAction indentAction = IndentAction.None) =>
		Log(source,
			node,
			message,
			LogLevel.Message,
			indentAction);

	public static IEnumerable<T> LogWarning<T>(this IEnumerable<T> source,
												Node node,
												string message,
												IndentAction indentAction = IndentAction.None) =>
		Log(source,
			node,
			message,
			LogLevel.Warning,
			indentAction);

	public static IEnumerable<T> LogError<T>(this IEnumerable<T> source,
												Node node,
												string message,
												IndentAction indentAction = IndentAction.None) =>
		Log(source,
			node,
			message,
			LogLevel.Error,
			indentAction);

	public static IEnumerable<T> LogForEach<T>(this IEnumerable<T> source,
												Node node,
												LogLevel logLevel,
												IndentAction indentAction,
												Func<T, string> action) {

		Log(node,
			logLevel,
			indentAction,
			source.Select(action)
							.ToArray());

		return source;

	}

	public static IEnumerable<T> LogMessageForEach<T>(this IEnumerable<T> source,
														Node node,
														IndentAction indentAction,
														Func<T, string> action) =>
		LogForEach(source,
					node,
					LogLevel.Message,
					indentAction,
					action);

	public static IEnumerable<T> LogMessageForEach<T>(this IEnumerable<T> source,
														Node node,
														Func<T, string> action) =>
		LogMessageForEach(source,
							node,
							IndentAction.None,
							action);

	public static IEnumerable<T> LogWarningForEach<T>(this IEnumerable<T> source,
														Node node,
														IndentAction indentAction,
														Func<T, string> action) =>
		LogForEach(source,
					node,
					LogLevel.Warning,
					indentAction,
					action);

	public static IEnumerable<T> LogWarningForEach<T>(this IEnumerable<T> source,
														Node node,
														Func<T, string> action) =>
		LogWarningForEach(source,
							node,
							IndentAction.None,
							action);

	public static IEnumerable<T> LogErrorForEach<T>(this IEnumerable<T> source,
													Node node,
													IndentAction indentAction,
													Func<T, string> action) =>
		LogForEach(source,
					node,
					LogLevel.Warning,
					indentAction,
					action);

	public static IEnumerable<T> LogErrorForEach<T>(this IEnumerable<T> source,
													Node node,
													Func<T, string> action) =>
		LogErrorForEach(source,
						node,
						IndentAction.None,
						action);

}

public enum IndentAction {

	None,
	Indent,
	Unindent,
	Reset,
	IndentOnce,
	IndentAfter,
	UnindentAfter,
	ResetAfter

}