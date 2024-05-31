using Godot;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Metal666.GodotUtilities.Logging.Loggers;

public abstract partial class LoggerBase : Resource {

#nullable disable
	public static Dictionary<Type, LogSourceData> LogSources { get; set; }
#nullable enable

	public abstract void Write(string message,
								LogLevel logLevel,
								Type? sourceType = null,
								int indentation = 0);

	public static LogSourceData? GetLogSourceData(Type? sourceType) =>
		sourceType != null ?
			LogSources.GetValueOrDefault(sourceType) :
			null;

	public static void PopulateLogSources() {

		if(LogSources != null) {

			return;

		}

		LogSources =
			AppDomain.CurrentDomain
						.GetAssemblies()
						.SelectMany(assembly =>
											assembly.GetTypes())
						.Select(type =>
											(Type: type,
												LogSourceAttribute: type.GetCustomAttribute<LogSourceAttribute>()))
						.Where(logSource =>
											logSource.LogSourceAttribute != null)
						.Select(logSourceAttribute =>
											(logSourceAttribute.Type,
												LogSourceAttribute: logSourceAttribute.LogSourceAttribute!))
						.ToDictionary(logSourceAttribute =>
													logSourceAttribute.Type,
													logSourceAttribute =>
													new LogSourceData(logSourceAttribute.Type.Name,
																		logSourceAttribute.LogSourceAttribute.Color));

	}

	public record LogSourceData {

		public static int LongestName { get; set; }

		public virtual string Name { get; set; }
		public virtual string? Color { get; set; }

		public LogSourceData(string name, string? color = null) {

			Name = name;
			Color = color;

			LongestName = Math.Max(LongestName, name.Length);

		}

	}

}