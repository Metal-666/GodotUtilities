using Godot;

using Metal666.GodotUtilities.Utilities;

using System;

namespace Metal666.GodotUtilities.Logging.Loggers;

[GlobalClass]
public partial class EditorLogger : LoggerBase {

	protected override void Write(string message,
									LogLevel logLevel,
									Type? sourceType = null,
									LogSourceData? sourceData = null,
									int indentation = 0) {

		switch(logLevel) {

			case LogLevel.Message: {

				GD.PrintRich(message.Indent(indentation)
											.PrependSource(sourceData?.Name,
															LogSourceData.LongestName)
											.Color(sourceData?.Color));

				break;

			}

			case LogLevel.Warning: {

				GD.PushWarning(message.PrependSource(sourceData?.Name));

				break;

			}

			case LogLevel.Error: {

				GD.PushError(message.PrependSource(sourceData?.Name));

				break;

			}

		}

	}

	public override bool ShouldLog => Is.Editor && !Is.Standalone;

}