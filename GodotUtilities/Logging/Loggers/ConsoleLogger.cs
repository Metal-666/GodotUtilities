using Godot;

using Metal666.GodotUtilities.Extensions;
using Metal666.GodotUtilities.Utilities;

using System;
using System.Collections.Generic;

namespace Metal666.GodotUtilities.Logging.Loggers;

[GlobalClass]
public partial class ConsoleLogger : LoggerBase {

#nullable disable
	public static Dictionary<Type, ConsoleColor> ConsoleSourceColors { get; set; }
#nullable enable

	public override void Write(string message,
								LogLevel logLevel,
								Type? sourceType = null,
								int indentation = 0) =>
		Log(message, logLevel, sourceType, indentation);

	public static void Log(string message,
							LogLevel logLevel,
							Type? sourceType = null,
							int indentation = 0) {

		if(Is.Editor) {

			return;

		}

		PopulateLogSources();

		if(ConsoleSourceColors == null) {

			ConsoleSourceColors = new();

			foreach((Type LogSourceType, LogSourceData LogSourceData) in LogSources) {

				if(LogSourceData.Color == null) {

					continue;

				}

				ConsoleSourceColors.Add(LogSourceType,
										ClosestConsoleColor(Color.FromString(LogSourceData.Color,
																						Colors.White)));

			}

		}

		LogSourceData? logSourceData =
			GetLogSourceData(sourceType);

		ConsoleColor foregroundColor = Console.ForegroundColor;

		switch(logLevel) {

			case LogLevel.Message: {

				if(sourceType != null &
					ConsoleSourceColors.TryGetValue(sourceType, out ConsoleColor color)) {

					Console.ForegroundColor = color;

				}

				break;

			}

			case LogLevel.Warning: {

				Console.ForegroundColor = ConsoleColor.Yellow;

				break;

			}

			case LogLevel.Error: {

				Console.ForegroundColor = ConsoleColor.Red;

				break;

			}

		}

		Console.WriteLine(message.Indent(indentation,
												"-")
										.PrependSource(logSourceData?.Name,
														LogSourceData.LongestName));

		Console.ForegroundColor = foregroundColor;

	}

	// Adapted from https://stackoverflow.com/a/12340136/13027370
	public static ConsoleColor ClosestConsoleColor(Color color) {

		Vector3 colorV = color.ToVector3();

		ConsoleColor result = 0;
		double delta = double.MaxValue;

		foreach(ConsoleColor consoleColor in Enum.GetValues<ConsoleColor>()) {

			string colorName = consoleColor.ToString();

			if(colorName == "DarkYellow") {

				colorName = "Orange";

			}

			Vector3 possibleMatchV =
				Color.FromString(colorName, Colors.White)
						.ToVector3();

			float distance = possibleMatchV.DistanceSquaredTo(colorV);

			if(Mathf.IsZeroApprox(distance)) {

				return consoleColor;

			}

			if(distance > delta) {

				continue;

			}

			delta = distance;
			result = consoleColor;

		}

		return result;

	}

}