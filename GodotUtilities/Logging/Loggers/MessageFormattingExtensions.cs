using Metal666.GodotUtilities.Extensions;

using System.Linq;

namespace Metal666.GodotUtilities.Logging.Loggers;

public static class MessageFormattingExtensions {

	public static string Indent(this string message,
								int width,
								string indentationString = "⏤") =>
		string.Concat(Enumerable.Range(0, width)
										.Select(_ => indentationString)
										.If(args => args.Any(),
											args => args.Append(" "))
										.Append(message));

	public static string PrependSource(this string message,
										string? source,
										int? padToLength = null) =>
		source != null ?
			($"[{source.PadRight(padToLength ?? 0,
									'/')}]" +
				" " +
				message) :
			message;

	public static string Color(this string message, string? color) =>
		color != null ?
			$"[color={color}]{message}[/color]" :
			message;
}