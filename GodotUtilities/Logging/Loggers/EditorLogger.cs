using Godot;

using Metal666.GodotUtilities.Utilities;

namespace Metal666.GodotUtilities.Logging.Loggers;

[GlobalClass]
public partial class EditorLogger : LoggerBase {

	public override bool ShouldLog => Is.Editor && !Is.Standalone;

	protected override Log Preprocess(Log log) {

		log = base.Preprocess(log);

		if(log.Level == LogLevel.Message) {

			log = log with {

				Message =
					log.Message.Indent(log.Indentation)
								.PrependSource(log.SourceData?.Name,
												LogSourceData.LongestName)
								.Color(log.SourceData?.Color)

			};

		}

		else {

			log = log with {

				Message = log.Message.PrependSource(log.SourceData?.Name)

			};

		}

		return log;

	}

	protected override void Output(Log log) {

		switch(log.Level) {

			case LogLevel.Message: {

				GD.PrintRich(log.Message);

				break;

			}

			case LogLevel.Warning: {

				GD.PushWarning(log.Message);

				break;

			}

			case LogLevel.Error: {

				GD.PushError(log.Message);

				break;

			}

		}

	}

}