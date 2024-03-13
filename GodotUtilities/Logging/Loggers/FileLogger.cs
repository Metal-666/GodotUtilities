using Godot;

using System;
using System.IO;

namespace Metal666.GodotUtilities.Logging.Loggers;

public record FileLogger(string Path) : LoggerBase {

	public override void Write(string message, LogLevel logLevel, Type? source = null) {

		try {

			File.WriteAllText(Path, $"{(source == null ? "" : $"[{source.Name}]")}{message}");

		}

		catch(Exception e) {

			GD.PushError($"{GetType().Name} failed to write log: {e.Message}");

		}

	}

}