using Godot;

namespace Metal666.GodotUtilities.Utilities;

public static class Is {

	public static bool Editor =>
		OS.HasFeature("editor");

	public static bool Standalone =>
		!Editor;

}