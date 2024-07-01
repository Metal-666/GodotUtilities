using System;

using static Metal666.GodotUtilities.Logging.Loggers.LoggerBase;

namespace Metal666.GodotUtilities.Logging;

public record Log(string Message,
					LogLevel Level,
					Type? SourceType = null,
					int Indentation = 0) {

	public virtual LogSourceData? SourceData { get; } =
		GetLogSourceData(SourceType);

}