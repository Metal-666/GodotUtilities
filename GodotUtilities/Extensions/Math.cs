using Godot;

using System.Linq;

namespace Metal666.GodotUtilities.Extensions;

public static class Math {

	public static bool IsEqualApprox(this Vector2 a, Vector2 b, float tolerance) =>
		Enumerable.Range(0, 2)
					.All(i => Mathf.IsEqualApprox(a[i], b[i], tolerance));

	public static bool IsEqualApprox(this Vector3 a, Vector3 b, float tolerance) =>
		Enumerable.Range(0, 3)
					.All(i => Mathf.IsEqualApprox(a[i], b[i], tolerance));

	public static Vector2 CopyWith(this Vector2 vector, float? x = null, float? y = null) =>
		new(x ?? vector.X, y ?? vector.Y);

	public static Vector2I CopyWith(this Vector2I vector, int? x = null, int? y = null) =>
		new(x ?? vector.X, y ?? vector.Y);

	public static Vector3 CopyWith(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
		new(x ?? vector.X, y ?? vector.Y, z ?? vector.Z);

	public static Vector3I CopyWith(this Vector3I vector, int? x = null, int? y = null, int? z = null) =>
		new(x ?? vector.X, y ?? vector.Y, z ?? vector.Z);

	public static Vector3 RotatedDeg(this Vector3 vector, Vector3 axis, float angle) =>
		vector.Rotated(axis, angle.ToRad());

	public static float ToDeg(this int angle) =>
		Mathf.RadToDeg(angle);

	public static float ToDeg(this float angle) =>
		Mathf.RadToDeg(angle);

	public static double ToDeg(this double angle) =>
		Mathf.RadToDeg(angle);

	public static Vector2 ToDeg(this Vector2 rotation) =>
		new(rotation.X.ToDeg(),
					rotation.Y.ToDeg());

	public static Vector3 ToDeg(this Vector3 rotation) =>
		new(rotation.X.ToDeg(),
					rotation.Y.ToDeg(),
					rotation.Z.ToDeg());

	public static float ToRad(this int angle) =>
		Mathf.DegToRad(angle);

	public static float ToRad(this float angle) =>
		Mathf.DegToRad(angle);

	public static double ToRad(this double angle) =>
		Mathf.DegToRad(angle);

	public static Vector2 ToRad(this Vector2 rotation) =>
		new(rotation.X.ToRad(),
					rotation.Y.ToRad());

	public static Vector3 ToRad(this Vector3 rotation) =>
		new(rotation.X.ToRad(),
					rotation.Y.ToRad(),
					rotation.Z.ToRad());

	public static int RoundToInt(this float value) =>
		Mathf.RoundToInt(value);

	public static int FloorToInt(this float value) =>
		Mathf.FloorToInt(value);

	public static int CeilToInt(this float value) =>
		Mathf.CeilToInt(value);

	public static int RoundToInt(this double value) =>
		Mathf.RoundToInt(value);

	public static int FloorToInt(this double value) =>
		Mathf.FloorToInt(value);

	public static int CeilToInt(this double value) =>
		Mathf.CeilToInt(value);

	public static Vector2I RoundToInt(this Vector2 vector) =>
		new(vector.X.RoundToInt(),
					vector.Y.RoundToInt());

	public static Vector2I FloorToInt(this Vector2 vector) =>
		new(vector.X.FloorToInt(),
					vector.Y.FloorToInt());

	public static Vector2I CeilToInt(this Vector2 vector) =>
		new(vector.X.CeilToInt(),
					vector.Y.CeilToInt());

	public static Vector3I RoundToInt(this Vector3 vector) =>
		new(vector.X.RoundToInt(),
					vector.Y.RoundToInt(),
					vector.Z.RoundToInt());

	public static Vector3I FloorToInt(this Vector3 vector) =>
		new(vector.X.FloorToInt(),
					vector.Y.FloorToInt(),
					vector.Z.FloorToInt());

	public static Vector3I CeilToInt(this Vector3 vector) =>
		new(vector.X.CeilToInt(),
					vector.Y.CeilToInt(),
					vector.Z.CeilToInt());

}