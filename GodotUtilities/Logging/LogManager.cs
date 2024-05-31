using Godot;

using Metal666.GodotUtilities.Logging.Loggers;
using Metal666.GodotUtilities.Utilities;

using System;

namespace Metal666.GodotUtilities.Logging;

public partial class LogManager : Node {

	public static LogManager? Instance { get; protected set; }

#nullable disable
	[Export]
	public virtual LoggerBase[] Loggers { get; set; }
#nullable enable

	#region Node Events
	public override void _Ready() {

		base._Ready();

		Instance = this;

	}
	#endregion

	public static void Log(string message,
							LogLevel logLevel = LogLevel.Message,
							Type? sourceType = null,
							int indentation = 0) {

		LoggerBase[]? loggers = Instance?.Loggers;

		if(loggers == null) {

			if(Is.Editor) {

				EditorLogger.Log(message, logLevel, sourceType, indentation);

			}

			else {

				ConsoleLogger.Log(message, logLevel, sourceType, indentation);

			}

			return;

		}

		foreach(LoggerBase logger in loggers) {

			logger.Write(message, logLevel, sourceType, indentation);

		}

	}

}