using Godot;

namespace Metal666.GodotUtilities.Extensions;

public static class Transforms {

	public static void RotateDeg(this Node2D node, int angle) =>
		node.Rotate(angle.ToRad());
	public static void RotateDeg(this Node2D node, float angle) =>
		node.Rotate(angle.ToRad());
	public static void RotateDeg(this Node2D node, double angle) =>
		RotateDeg(node, (float) angle);

	public static void RotateDeg(this Node3D node, Vector3 axis, int angle) =>
		node.Rotate(axis, angle.ToRad());
	public static void RotateDeg(this Node3D node, Vector3 axis, float angle) =>
		node.Rotate(axis, angle.ToRad());
	public static void RotateDeg(this Node3D node, Vector3 axis, double angle) =>
		RotateDeg(node, axis, (float) angle);

	public static void RotateXDeg(this Node3D node, int angle) =>
		node.RotateX(angle.ToRad());
	public static void RotateXDeg(this Node3D node, float angle) =>
		node.RotateX(angle.ToRad());
	public static void RotateXDeg(this Node3D node, double angle) =>
		RotateXDeg(node, (float) angle);

	public static void RotateYDeg(this Node3D node, int angle) =>
		node.RotateY(angle.ToRad());
	public static void RotateYDeg(this Node3D node, float angle) =>
		node.RotateY(angle.ToRad());
	public static void RotateYDeg(this Node3D node, double angle) =>
		RotateYDeg(node, (float) angle);

	public static void RotateZDeg(this Node3D node, int angle) =>
		node.RotateZ(angle.ToRad());
	public static void RotateZDeg(this Node3D node, float angle) =>
		node.RotateZ(angle.ToRad());
	public static void RotateZDeg(this Node3D node, double angle) =>
		RotateZDeg(node, (float) angle);

	public static void SetXRotation(this Node3D node, int angle) =>
		node.Rotation = node.Rotation.CopyWith(x: angle);
	public static void SetXRotation(this Node3D node, float angle) =>
		node.Rotation = node.Rotation.CopyWith(x: angle);
	public static void SetXRotation(this Node3D node, double angle) =>
		SetXRotation(node, (float) angle);

	public static void SetYRotation(this Node3D node, int angle) =>
		node.Rotation = node.Rotation.CopyWith(y: angle);
	public static void SetYRotation(this Node3D node, float angle) =>
		node.Rotation = node.Rotation.CopyWith(y: angle);
	public static void SetYRotation(this Node3D node, double angle) =>
		SetYRotation(node, (float) angle);

	public static void SetZRotation(this Node3D node, int angle) =>
		node.Rotation = node.Rotation.CopyWith(z: angle);
	public static void SetZRotation(this Node3D node, float angle) =>
		node.Rotation = node.Rotation.CopyWith(z: angle);
	public static void SetZRotation(this Node3D node, double angle) =>
		SetZRotation(node, (float) angle);

	public static void SetXRotationDeg(this Node3D node, int angle) =>
		node.RotationDegrees = node.RotationDegrees.CopyWith(x: angle);
	public static void SetXRotationDeg(this Node3D node, float angle) =>
		node.RotationDegrees = node.RotationDegrees.CopyWith(x: angle);
	public static void SetXRotationDeg(this Node3D node, double angle) =>
		SetXRotationDeg(node, (float) angle);

	public static void SetYRotationDeg(this Node3D node, int angle) =>
		node.RotationDegrees = node.RotationDegrees.CopyWith(y: angle);
	public static void SetYRotationDeg(this Node3D node, float angle) =>
		node.RotationDegrees = node.RotationDegrees.CopyWith(y: angle);
	public static void SetYRotationDeg(this Node3D node, double angle) =>
		SetYRotationDeg(node, (float) angle);

	public static void SetZRotationDeg(this Node3D node, int angle) =>
		node.RotationDegrees = node.RotationDegrees.CopyWith(z: angle);
	public static void SetZRotationDeg(this Node3D node, float angle) =>
		node.RotationDegrees = node.RotationDegrees.CopyWith(z: angle);
	public static void SetZRotationDeg(this Node3D node, double angle) =>
		SetZRotationDeg(node, (float) angle);

	public static void SetXRotationGlobal(this Node3D node, int angle) =>
		node.GlobalRotation = node.GlobalRotation.CopyWith(x: angle);
	public static void SetXRotationGlobal(this Node3D node, float angle) =>
		node.GlobalRotation = node.GlobalRotation.CopyWith(x: angle);
	public static void SetXRotationGlobal(this Node3D node, double angle) =>
		SetXRotationGlobal(node, (float) angle);

	public static void SetYRotationGlobal(this Node3D node, int angle) =>
		node.GlobalRotation = node.GlobalRotation.CopyWith(y: angle);
	public static void SetYRotationGlobal(this Node3D node, float angle) =>
		node.GlobalRotation = node.GlobalRotation.CopyWith(y: angle);
	public static void SetYRotationGlobal(this Node3D node, double angle) =>
		SetYRotationGlobal(node, (float) angle);

	public static void SetZRotationGlobal(this Node3D node, int angle) =>
		node.GlobalRotation = node.GlobalRotation.CopyWith(z: angle);
	public static void SetZRotationGlobal(this Node3D node, float angle) =>
		node.GlobalRotation = node.GlobalRotation.CopyWith(z: angle);
	public static void SetZRotationGlobal(this Node3D node, double angle) =>
		SetZRotationGlobal(node, (float) angle);

	public static void SetXRotationGlobalDeg(this Node3D node, int angle) =>
		node.GlobalRotationDegrees = node.GlobalRotationDegrees.CopyWith(x: angle);
	public static void SetXRotationGlobalDeg(this Node3D node, float angle) =>
		node.GlobalRotationDegrees = node.GlobalRotationDegrees.CopyWith(x: angle);
	public static void SetXRotationGlobalDeg(this Node3D node, double angle) =>
		SetXRotationGlobalDeg(node, (float) angle);

	public static void SetYRotationGlobalDeg(this Node3D node, int angle) =>
		node.GlobalRotationDegrees = node.GlobalRotationDegrees.CopyWith(y: angle);
	public static void SetYRotationGlobalDeg(this Node3D node, float angle) =>
		node.GlobalRotationDegrees = node.GlobalRotationDegrees.CopyWith(y: angle);
	public static void SetYRotationGlobalDeg(this Node3D node, double angle) =>
		SetYRotationGlobalDeg(node, (float) angle);

	public static void SetZRotationGlobalDeg(this Node3D node, int angle) =>
		node.GlobalRotationDegrees = node.GlobalRotationDegrees.CopyWith(z: angle);
	public static void SetZRotationGlobalDeg(this Node3D node, float angle) =>
		node.GlobalRotationDegrees = node.GlobalRotationDegrees.CopyWith(z: angle);
	public static void SetZRotationGlobalDeg(this Node3D node, double angle) =>
		SetZRotationGlobalDeg(node, (float) angle);

	public static void SetXPosition(this Node3D node, int x) =>
		node.Position = node.Position.CopyWith(x: x);
	public static void SetXPosition(this Node3D node, float x) =>
		node.Position = node.Position.CopyWith(x: x);
	public static void SetXPosition(this Node3D node, double x) =>
		SetXPosition(node, (float) x);

	public static void SetYPosition(this Node3D node, int y) =>
		node.Position = node.Position.CopyWith(y: y);
	public static void SetYPosition(this Node3D node, float y) =>
		node.Position = node.Position.CopyWith(y: y);
	public static void SetYPosition(this Node3D node, double y) =>
		SetYPosition(node, (float) y);

	public static void SetZPosition(this Node3D node, int z) =>
		node.Position = node.Position.CopyWith(z: z);
	public static void SetZPosition(this Node3D node, float z) =>
		node.Position = node.Position.CopyWith(z: z);
	public static void SetZPosition(this Node3D node, double z) =>
		SetZPosition(node, (float) z);

	public static void SetXPositionGlobal(this Node3D node, int x) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(x: x);
	public static void SetXPositionGlobal(this Node3D node, float x) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(x: x);
	public static void SetXPositionGlobal(this Node3D node, double x) =>
		SetXPositionGlobal(node, (float) x);

	public static void SetYPositionGlobal(this Node3D node, int y) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(y: y);
	public static void SetYPositionGlobal(this Node3D node, float y) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(y: y);
	public static void SetYPositionGlobal(this Node3D node, double y) =>
		SetYPositionGlobal(node, (float) y);

	public static void SetZPositionGlobal(this Node3D node, int z) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(z: z);
	public static void SetZPositionGlobal(this Node3D node, float z) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(z: z);
	public static void SetZPositionGlobal(this Node3D node, double z) =>
		SetZPositionGlobal(node, (float) z);

	public static void SetXPosition(this Node2D node, int x) =>
		node.Position = node.Position.CopyWith(x: x);
	public static void SetXPosition(this Node2D node, float x) =>
		node.Position = node.Position.CopyWith(x: x);
	public static void SetXPosition(this Node2D node, double x) =>
		SetXPosition(node, (float) x);

	public static void SetYPosition(this Node2D node, int y) =>
		node.Position = node.Position.CopyWith(y: y);
	public static void SetYPosition(this Node2D node, float y) =>
		node.Position = node.Position.CopyWith(y: y);
	public static void SetYPosition(this Node2D node, double y) =>
		SetYPosition(node, (float) y);

	public static void SetXPositionGlobal(this Node2D node, int x) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(x: x);
	public static void SetXPositionGlobal(this Node2D node, float x) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(x: x);
	public static void SetXPositionGlobal(this Node2D node, double x) =>
		SetXPositionGlobal(node, (float) x);

	public static void SetYPositionGlobal(this Node2D node, int y) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(y: y);
	public static void SetYPositionGlobal(this Node2D node, float y) =>
		node.GlobalPosition = node.GlobalPosition.CopyWith(y: y);
	public static void SetYPositionGlobal(this Node2D node, double y) =>
		SetYPositionGlobal(node, (float) y);

}