using Godot;

namespace Metal666.GodotUtilities.Extensions;

public static class Controls {

	public static float ValueF(this Range range) =>
		(float) range.Value;

	public static int ValueI(this Range range) =>
		range.Value.RoundToInt();

}