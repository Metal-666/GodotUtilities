using Godot;

using Metal666.GodotUtilities.Utilities;

using System;

namespace Metal666.GodotUtilities.Logging.Loggers;

[GlobalClass]
public partial class EditorLogger : LoggerBase {

	public override void Write(string message,
								LogLevel logLevel,
								Type? sourceType = null,
								int indentation = 0) =>
		Log(message, logLevel, sourceType, indentation);

	public static void Log(string message,
							LogLevel logLevel,
							Type? sourceType = null,
							int indentation = 0) {

		if(Is.Standalone) {

			return;

		}

		PopulateLogSources();

		LogSourceData? logSourceData =
			GetLogSourceData(sourceType);

		switch(logLevel) {

			case LogLevel.Message: {

				GD.PrintRich(message.Indent(indentation)
											.PrependSource(logSourceData?.Name,
															LogSourceData.LongestName)
											.Color(logSourceData?.Color));

				break;

			}

			case LogLevel.Warning: {

				GD.PushWarning(message.PrependSource(logSourceData?.Name));

				break;

			}

			case LogLevel.Error: {

				GD.PushError(message.PrependSource(logSourceData?.Name));

				break;

			}

		}

	}

}