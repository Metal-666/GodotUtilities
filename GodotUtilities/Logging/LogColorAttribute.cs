using Godot;

using System;

namespace Metal666.GodotUtilities.Logging;

[AttributeUsage(AttributeTargets.Class)]
public class LogColorAttribute : Attribute {

	public string color;

	public virtual Color Color =>
		Color.FromString(color, Colors.Transparent);

	public LogColorAttribute(string color) {

		this.color = color;

	}

}