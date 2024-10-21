using Godot;

namespace Metal666.GodotUtilities.Extensions;

public static class Transforms {

	public static void RotateDeg(this Node2D node, int angle) =>
		node.Rotate(angle.ToRad());

	public static void RotateDeg(this Node2D node, float angle) =>
		node.Rotate(angle.ToRad());

	public static void RotateDeg(this Node2D node, double angle) =>
		node.Rotate((float) angle.ToRad());

	public static void RotateDeg(this Node3D node, Vector3 axis, int angle) =>
		node.Rotate(axis, angle.ToRad());

	public static void RotateDeg(this Node3D node, Vector3 axis, float angle) =>
		node.Rotate(axis, angle.ToRad());

	public static void RotateDeg(this Node3D node, Vector3 axis, double angle) =>
		node.Rotate(axis, (float) angle.ToRad());

	public static void RotateXDeg(this Node3D node, int angle) =>
		node.RotateX(angle.ToRad());

	public static void RotateXDeg(this Node3D node, float angle) =>
		node.RotateX(angle.ToRad());

	public static void RotateXDeg(this Node3D node, double angle) =>
		node.RotateX((float) angle.ToRad());

	public static void RotateYDeg(this Node3D node, int angle) =>
		node.RotateY(angle.ToRad());

	public static void RotateYDeg(this Node3D node, float angle) =>
		node.RotateY(angle.ToRad());

	public static void RotateYDeg(this Node3D node, double angle) =>
		node.RotateY((float) angle.ToRad());

	public static void RotateZDeg(this Node3D node, int angle) =>
		node.RotateZ(angle.ToRad());

	public static void RotateZDeg(this Node3D node, float angle) =>
		node.RotateZ(angle.ToRad());

	public static void RotateZDeg(this Node3D node, double angle) =>
		node.RotateZ((float) angle.ToRad());

}