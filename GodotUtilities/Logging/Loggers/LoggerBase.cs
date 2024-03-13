using System;

namespace Metal666.GodotUtilities.Logging.Loggers;

public abstract record LoggerBase {

	public abstract void Write(string message, LogLevel logLevel, Type? source = null);

}