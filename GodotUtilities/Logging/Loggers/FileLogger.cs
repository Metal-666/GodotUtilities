using Godot;

using System;
using System.IO;

namespace Metal666.GodotUtilities.Logging.Loggers;

[GlobalClass]
public partial class FileLogger : LoggerBase {

#nullable disable
	[Export]
	public virtual string Path { get; set; }
#nullable enable

	protected override void Write(string message,
									LogLevel logLevel,
									Type? sourceType = null,
									LogSourceData? sourceData = null,
									int indentation = 0) {

		try {

			File.WriteAllText(Path,
								message.Indent(indentation)
												.PrependSource(sourceData?.Name));

		}

		catch(Exception e) {

			GD.PushError($"{GetType().Name} failed to write log: {e.Message}");

		}

	}

}