using System;

namespace Metal666.GodotUtilities.Logging;

[AttributeUsage(AttributeTargets.Class)]
public class LogSourceAttribute : Attribute {

	public string? Color;

}