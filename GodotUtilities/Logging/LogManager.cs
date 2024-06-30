using Metal666.GodotUtilities.Logging.Loggers;

using System;
using System.Collections.Generic;

namespace Metal666.GodotUtilities.Logging;

public static class LogManager {

	public static List<LoggerBase>? Loggers { get; set; }

	public static void Log(string message,
							LogLevel logLevel = LogLevel.Message,
							Type? sourceType = null,
							int indentation = 0) {

		Loggers ??=
			new() {

				new EditorLogger(),
				new ConsoleLogger()

			};

		foreach(LoggerBase logger in Loggers) {

			logger.Log(message, logLevel, sourceType, indentation);

		}

	}

}