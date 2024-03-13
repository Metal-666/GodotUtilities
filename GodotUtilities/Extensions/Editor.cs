using Godot;

namespace Metal666.GodotUtilities.Extensions;

public static class Editor {

	public static bool CanDebug =>
		OS.HasFeature("editor");

}