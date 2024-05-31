using Godot;

namespace Metal666.GodotUtilities.Extensions;

public static class Visual {

	public static Vector3 ToVector3(this Color color) =>
		new(color.R, color.G, color.B);

	public static Vector3I ToVector3I(this Color color) =>
		new(color.R8, color.G8, color.B8);

}