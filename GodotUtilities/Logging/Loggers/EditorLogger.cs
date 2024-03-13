using Godot;

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Metal666.GodotUtilities.Logging.Loggers;

public record EditorLogger : LoggerBase {

	public static Dictionary<Type, Color?> TypesLogColorsCache { get; set; } =
		new();

	public override void Write(string message, LogLevel logLevel, Type? sourceType = null) {

		Color? logColor = null;

		if(sourceType != null) {

			if(!TypesLogColorsCache.TryGetValue(sourceType, out logColor)) {

				logColor =
					sourceType.GetCustomAttribute<LogColorAttribute>()?
								.Color;

				TypesLogColorsCache[sourceType] = logColor;

			}

		}

		switch(logLevel) {

			case LogLevel.Message: {

				if(logColor.HasValue) {

					GD.PrintRich($"[color={logColor.Value.ToHtml()}]{message}[/color]");

				}

				else {

					GD.Print(message);

				}

				break;

			}

			case LogLevel.Warning: {

				GD.PushWarning(message);

				break;

			}

			case LogLevel.Error: {

				GD.PushError(message);

				break;

			}

		}

	}

}