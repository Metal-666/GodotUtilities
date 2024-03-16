using Godot;

using Metal666.GodotUtilities.Logging;
using Metal666.GodotUtilities.Logging.Loggers;

using System;
using System.Collections.Generic;

namespace Metal666.GodotUtilities;

public abstract partial class AdvancedSceneTreeBase : SceneTree {

	public virtual List<LoggerBase> Loggers { get; set; } =
		new() {

			new EditorLogger()

		};

	public virtual void Log(string message, LogLevel logLevel, Type? sourceType = null) {

		foreach(LoggerBase logger in Loggers) {

			logger.Write(message, logLevel, sourceType);

		}

	}

}