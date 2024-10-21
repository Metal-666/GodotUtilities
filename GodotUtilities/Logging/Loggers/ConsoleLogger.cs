using Godot;

using Metal666.GodotUtilities.Extensions;
using Metal666.GodotUtilities.Utilities;

using System;
using System.Collections.Generic;

namespace Metal666.GodotUtilities.Logging.Loggers;

[GlobalClass]
public partial class ConsoleLogger : LoggerBase {

	public static Dictionary<Type, ConsoleColor>? ConsoleSourceColors { get; set; } = null;

	public override bool ShouldLog => !Is.Editor;

	protected virtual ConsoleColor ForegroundColor { get; set; }

	protected override Log Preprocess(Log log) {

		log = base.Preprocess(log);

		InitializeConsoleColors();

		ForegroundColor = Console.ForegroundColor;

		switch(log.Level) {

			case LogLevel.Message: {

				if(log.SourceType != null &&
					ConsoleSourceColors != null &&
					ConsoleSourceColors.TryGetValue(log.SourceType,
													out ConsoleColor color)) {

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

		return log with {

			Message =
				log.Message.Indent(log.Indentation,
									"-")
							.PrependSource(log.SourceData?.Name,
											LogSourceData.LongestName)

		};

	}

	protected override void Output(Log log) =>
		Console.WriteLine(log.Message);

	protected override void Postprocess(Log log) {

		base.Postprocess(log);

		Console.ForegroundColor = ForegroundColor;

	}

	protected virtual void InitializeConsoleColors() {

		if(ConsoleSourceColors != null) {

			return;

		}

		ConsoleSourceColors = [];

		foreach((Type LogSourceType, LogSourceData LogSourceData) in LogSources) {

			if(LogSourceData.Color == null) {

				continue;

			}

			ConsoleSourceColors.Add(LogSourceType,
									ClosestConsoleColor(Color.FromString(LogSourceData.Color,
																					Colors.White)));

		}

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