using Godot;

using System;
using System.Linq;

namespace Metal666.GodotUtilities.Extensions;

public static class Math {

	public static float Lerp(this float from, float to, float weight) =>
		Mathf.Lerp(from, to, weight);
	public static double Lerp(this double from, double to, double weight) =>
		Mathf.Lerp(from, to, weight);
	public static float Lerp(this float from, float to, double weight) =>
		(float) Lerp((double) from, (double) to, weight);

	public static float MoveToward(this float from, float to, float delta) =>
		Mathf.MoveToward(from, to, delta);
	public static double MoveToward(this double from, double to, double delta) =>
		Mathf.MoveToward(from, to, delta);
	public static float MoveToward(this float from, float to, double delta) =>
		(float) MoveToward((double) from, (double) to, delta);

	public static float LerpAngle(this float from, float to, float weight) =>
		Mathf.LerpAngle(from, to, weight);
	public static double LerpAngle(this double from, double to, double weight) =>
		Mathf.LerpAngle(from, to, weight);
	public static float LerpAngle(this float from, float to, double weight) =>
		(float) LerpAngle((double) from, (double) to, weight);

	public static int Abs(this int value) =>
		Mathf.Abs(value);
	public static float Abs(this float value) =>
		Mathf.Abs(value);
	public static double Abs(this double value) =>
		Mathf.Abs(value);

	public static int Clamp(this int value, int min, int max) =>
		Mathf.Clamp(value, min, max);
	public static float Clamp(this float value, float min, float max) =>
		Mathf.Clamp(value, min, max);
	public static double Clamp(this double value, double min, double max) =>
		Mathf.Clamp(value, min, max);

	public static int Clamp(this int value, Vector2I range) =>
		Clamp(value, range.X, range.Y);
	public static float Clamp(this float value, Vector2 range) =>
		Clamp(value, range.X, range.Y);

	public static int Wrap(this int value, int min, int max) =>
		Mathf.Wrap(value, min, max);
	public static float Wrap(this float value, float min, float max) =>
		Mathf.Wrap(value, min, max);
	public static double Wrap(this double value, double min, double max) =>
		Mathf.Wrap(value, min, max);

	public static int PosMod(this int a, int b) =>
		Mathf.PosMod(a, b);
	public static float PosMod(this float a, float b) =>
		Mathf.PosMod(a, b);
	public static double PosMod(this double a, double b) =>
		Mathf.PosMod(a, b);

	public static int Wrap360Deg(this int angle) =>
		PosMod(angle, 360);
	public static float Wrap360Deg(this float angle) =>
		PosMod(angle, 360);
	public static double Wrap360Deg(this double angle) =>
		PosMod(angle, 360);

	public static float Wrap360Rad(this float angle) =>
		PosMod(angle, Mathf.Tau);
	public static double Wrap360Rad(this double angle) =>
		PosMod(angle, Mathf.Tau);

	public static int SignedWrap360Deg(this int angle) =>
		Wrap(angle, -180, 180);
	public static float SignedWrap360Deg(this float angle) =>
		Wrap(angle, -180, 180);
	public static double SignedWrap360Deg(this double angle) =>
		Wrap(angle, -180, 180);

	public static float SignedWrap360Rad(this float angle) =>
		Wrap(angle, -Mathf.Pi, Mathf.Pi);
	public static double SignedWrap360Rad(this double angle) =>
		Wrap(angle, -Mathf.Pi, Mathf.Pi);

	public static int Wrap720Deg(this int angle) =>
		PosMod(angle, 720);
	public static float Wrap720Deg(this float angle) =>
		PosMod(angle, 720);
	public static double Wrap720Deg(this double angle) =>
		PosMod(angle, 720);

	public static float Wrap720Rad(this float angle) =>
		PosMod(angle, Mathf.Tau * 2);
	public static double Wrap720Rad(this double angle) =>
		PosMod(angle, Mathf.Tau * 2);

	public static int SignedWrap720Deg(this int angle) =>
		Wrap(angle, -360, 360);
	public static float SignedWrap720Deg(this float angle) =>
		Wrap(angle, -360, 360);
	public static double SignedWrap720Deg(this double angle) =>
		Wrap(angle, -360, 360);

	public static float SignedWrap720Rad(this float angle) =>
		Wrap(angle, -Mathf.Tau, Mathf.Tau);
	public static double SignedWrap720Rad(this double angle) =>
		Wrap(angle, -Mathf.Tau, Mathf.Tau);

	public static float AngleDifference(this float value, float to) =>
		Mathf.AngleDifference(value, to);
	public static double AngleDifference(this double value, double to) =>
		Mathf.AngleDifference(value, to);

	public static float AngleDifferenceAbs(this float value, float to) =>
		Abs(AngleDifference(value, to));
	public static double AngleDifferenceAbs(this double value, double to) =>
		Abs(AngleDifference(value, to));

	public static float DifferenceAbs(this float value, float to) =>
		Abs(value - to);
	public static double DifferenceAbs(this double value, double to) =>
		Abs(value - to);

	public static bool IsZeroApprox(this float value) =>
		Mathf.IsZeroApprox(value);
	public static bool IsZeroApprox(this double value) =>
		Mathf.IsZeroApprox(value);

	public static bool IsEqualApprox(this float value, float to) =>
		Mathf.IsEqualApprox(value, to);
	public static bool IsEqualApprox(this double value, double to) =>
		Mathf.IsEqualApprox(value, to);

	public static bool IsEqualApprox(this float value, float to, float tolerance) =>
		Mathf.IsEqualApprox(value, to, tolerance);
	public static bool IsEqualApprox(this double value, double to, double tolerance) =>
		Mathf.IsEqualApprox(value, to, tolerance);

	public static float Get(this Vector2 vector, Vector2.Axis axis) =>
		vector[(int) axis];
	public static float Get(this Vector3 vector, Vector3.Axis axis) =>
		vector[(int) axis];

	public static bool IsEqualApprox(this Vector2 vector,
										Vector2 to,
										float tolerance) =>
		Enum.GetValues<Vector2.Axis>()
			.All(axis =>
							IsEqualApprox(Get(vector, axis),
											Get(to, axis),
											tolerance));
	public static bool IsEqualApprox(this Vector3 vector,
										Vector3 to,
										float tolerance) =>
		Enum.GetValues<Vector3.Axis>()
			.All(axis =>
							IsEqualApprox(Get(vector, axis),
											Get(to, axis),
											tolerance));

	public static Vector2 CopyWith(this Vector2 vector,
									float? x = null,
									float? y = null) =>
		new(x ?? vector.X, y ?? vector.Y);
	public static Vector2I CopyWith(this Vector2I vector,
									int? x = null,
									int? y = null) =>
		new(x ?? vector.X, y ?? vector.Y);

	public static Vector3 CopyWith(this Vector3 vector,
									float? x = null,
									float? y = null,
									float? z = null) =>
		new(x ?? vector.X, y ?? vector.Y, z ?? vector.Z);
	public static Vector3I CopyWith(this Vector3I vector,
									int? x = null,
									int? y = null,
									int? z = null) =>
		new(x ?? vector.X, y ?? vector.Y, z ?? vector.Z);

	public static Vector2 CopyWith(this Vector2 vector,
									Vector2.Axis axis,
									float value) {

		switch(axis) {

			case Vector2.Axis.X: {

				return CopyWith(vector, x: value);

			}

			case Vector2.Axis.Y: {

				return CopyWith(vector, y: value);

			}

			default: {

				return vector;

			}

		}

	}
	public static Vector2I CopyWith(this Vector2I vector,
									Vector2I.Axis axis,
									int value) {

		switch(axis) {

			case Vector2I.Axis.X: {

				return CopyWith(vector, x: value);

			}

			case Vector2I.Axis.Y: {

				return CopyWith(vector, y: value);

			}

			default: {

				return vector;

			}

		}

	}

	public static Vector3 CopyWith(this Vector3 vector,
									Vector3.Axis axis,
									float value) {

		switch(axis) {

			case Vector3.Axis.X: {

				return CopyWith(vector, x: value);

			}

			case Vector3.Axis.Y: {

				return CopyWith(vector, y: value);

			}

			case Vector3.Axis.Z: {

				return CopyWith(vector, z: value);

			}

			default: {

				return vector;

			}

		}

	}
	public static Vector3I CopyWith(this Vector3I vector,
									Vector3I.Axis axis,
									int value) {

		switch(axis) {

			case Vector3I.Axis.X: {

				return CopyWith(vector, x: value);

			}

			case Vector3I.Axis.Y: {

				return CopyWith(vector, y: value);

			}

			case Vector3I.Axis.Z: {

				return CopyWith(vector, z: value);

			}

			default: {

				return vector;

			}

		}

	}

	public static Vector3 Lerp(this Vector3 vector, Vector3 to, double weight) =>
		vector.Lerp(to, (float) weight);
	public static Vector2 Lerp(this Vector2 vector, Vector2 to, double weight) =>
		vector.Lerp(to, (float) weight);

	public static Vector3 MoveToward(this Vector3 vector, Vector3 to, double weight) =>
		vector.MoveToward(to, (float) weight);
	public static Vector2 MoveToward(this Vector2 vector, Vector2 to, double weight) =>
		vector.MoveToward(to, (float) weight);

	public static Vector3 RotatedDeg(this Vector3 vector,
										Vector3 axis,
										float angle) =>
		vector.Rotated(axis, ToRad(angle));

	public static Vector2 FlattenX(this Vector3 vector) =>
		new(vector.Y, vector.Z);
	public static Vector2 FlattenY(this Vector3 vector) =>
		new(vector.X, vector.Z);
	public static Vector2 FlattenZ(this Vector3 vector) =>
		new(vector.X, vector.Y);

	public static Vector2I FlattenX(this Vector3I vector) =>
		new(vector.Y, vector.Z);
	public static Vector2I FlattenY(this Vector3I vector) =>
		new(vector.X, vector.Z);
	public static Vector2I FlattenZ(this Vector3I vector) =>
		new(vector.X, vector.Y);

	public static Vector3 AddXComponent(this Vector2 vector, float x = 0) =>
		new(x, vector.X, vector.Y);
	public static Vector3 AddYComponent(this Vector2 vector, float y = 0) =>
		new(vector.X, y, vector.Y);
	public static Vector3 AddZComponent(this Vector2 vector, float z = 0) =>
		new(vector.X, vector.Y, z);

	public static Vector3I AddXComponent(this Vector2I vector, int x = 0) =>
		new(x, vector.X, vector.Y);
	public static Vector3I AddYComponent(this Vector2I vector, int y = 0) =>
		new(vector.X, y, vector.Y);
	public static Vector3I AddZComponent(this Vector2I vector, int z = 0) =>
		new(vector.X, vector.Y, z);

	public static float ToDeg(this int angle) =>
		Mathf.RadToDeg(angle);
	public static float ToDeg(this float angle) =>
		Mathf.RadToDeg(angle);
	public static double ToDeg(this double angle) =>
		Mathf.RadToDeg(angle);

	public static Vector2 ToDeg(this Vector2 rotation) =>
		new(ToDeg(rotation.X),
					ToDeg(rotation.Y));
	public static Vector3 ToDeg(this Vector3 rotation) =>
		new(ToDeg(rotation.X),
					ToDeg(rotation.Y),
					ToDeg(rotation.Z));

	public static float ToRad(this int angle) =>
		Mathf.DegToRad(angle);
	public static float ToRad(this float angle) =>
		Mathf.DegToRad(angle);
	public static double ToRad(this double angle) =>
		Mathf.DegToRad(angle);

	public static Vector2 ToRad(this Vector2 rotation) =>
		new(ToRad(rotation.X),
					ToRad(rotation.Y));
	public static Vector3 ToRad(this Vector3 rotation) =>
		new(ToRad(rotation.X),
					ToRad(rotation.Y),
					ToRad(rotation.Z));

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
		new(RoundToInt(vector.X),
					RoundToInt(vector.Y));
	public static Vector2I FloorToInt(this Vector2 vector) =>
		new(FloorToInt(vector.X),
					FloorToInt(vector.Y));
	public static Vector2I CeilToInt(this Vector2 vector) =>
		new(CeilToInt(vector.X),
					CeilToInt(vector.Y));
	public static Vector3I RoundToInt(this Vector3 vector) =>
		new(RoundToInt(vector.X),
					RoundToInt(vector.Y),
					RoundToInt(vector.Z));
	public static Vector3I FloorToInt(this Vector3 vector) =>
		new(FloorToInt(vector.X),
					FloorToInt(vector.Y),
					FloorToInt(vector.Z));
	public static Vector3I CeilToInt(this Vector3 vector) =>
		new(CeilToInt(vector.X),
					CeilToInt(vector.Y),
					CeilToInt(vector.Z));

	public static float UnsignedAngleTo(this Vector2 vector, Vector2 to) =>
		Abs(vector.AngleTo(to));

	public static Vector2 Swap(this Vector2 vector) =>
		new(vector.Y, vector.X);
	public static Vector2I Swap(this Vector2I vector) =>
		new(vector.Y, vector.X);

	public static Vector3 OverwriteXY(this Vector3 vector, Vector2 with) =>
		vector.CopyWith(x: with.X, y: with.Y);
	public static Vector3 OverwriteXZ(this Vector3 vector, Vector2 with) =>
		vector.CopyWith(x: with.X, z: with.Y);
	public static Vector3 OverwriteYZ(this Vector3 vector, Vector2 with) =>
		vector.CopyWith(y: with.X, z: with.Y);

	public static Vector3I OverwriteXY(this Vector3I vector, Vector2I with) =>
		vector.CopyWith(x: with.X, y: with.Y);
	public static Vector3I OverwriteXZ(this Vector3I vector, Vector2I with) =>
		vector.CopyWith(x: with.X, z: with.Y);
	public static Vector3I OverwriteYZ(this Vector3I vector, Vector2I with) =>
		vector.CopyWith(y: with.X, z: with.Y);

	public static Vector2 ElementWiseProduct(this Vector2 vector, Vector2 other) =>
		new(vector.X * other.X,
					vector.Y * other.Y);
	public static Vector3 ElementWiseProduct(this Vector3 vector, Vector3 other) =>
		new(vector.X * other.X,
					vector.Y * other.Y,
					vector.Z * other.Z);

	public static Vector2I ElementWiseProduct(this Vector2I vector, Vector2I other) =>
		new(vector.X * other.X,
					vector.Y * other.Y);
	public static Vector3I ElementWiseProduct(this Vector3I vector, Vector3I other) =>
		new(vector.X * other.X,
					vector.Y * other.Y,
					vector.Z * other.Z);

	public static Vector3 ClampX(this Vector3 vector, int min, int max) =>
		CopyWith(vector,
					x: Clamp(vector.X, min, max));
	public static Vector3 ClampX(this Vector3 vector, float min, float max) =>
		CopyWith(vector,
					x: Clamp(vector.X, min, max));
	public static Vector3 ClampX(this Vector3 vector, double min, double max) =>
		ClampX(vector,
				(float) min,
				(float) max);

	public static Vector3 ClampY(this Vector3 vector, int min, int max) =>
		CopyWith(vector,
					y: Clamp(vector.Y, min, max));
	public static Vector3 ClampY(this Vector3 vector, float min, float max) =>
		CopyWith(vector,
					y: Clamp(vector.Y, min, max));
	public static Vector3 ClampY(this Vector3 vector, double min, double max) =>
		ClampY(vector,
				(float) min,
				(float) max);

	public static Vector3 ClampZ(this Vector3 vector, int min, int max) =>
		CopyWith(vector,
					z: Clamp(vector.Z, min, max));
	public static Vector3 ClampZ(this Vector3 vector, float min, float max) =>
		CopyWith(vector,
					z: Clamp(vector.Z, min, max));
	public static Vector3 ClampZ(this Vector3 vector, double min, double max) =>
		ClampZ(vector,
				(float) min,
				(float) max);

	public static Vector3I ClampX(this Vector3I vector, int min, int max) =>
		CopyWith(vector,
					x: Clamp(vector.X, min, max));
	public static Vector3I ClampY(this Vector3I vector, int min, int max) =>
		CopyWith(vector,
					y: Clamp(vector.Y, min, max));
	public static Vector3I ClampZ(this Vector3I vector, int min, int max) =>
		CopyWith(vector,
					z: Clamp(vector.Z, min, max));

	public static Vector2 ClampX(this Vector2 vector, int min, int max) =>
		CopyWith(vector,
					x: Clamp(vector.X, min, max));
	public static Vector2 ClampX(this Vector2 vector, float min, float max) =>
		CopyWith(vector,
					x: Clamp(vector.X, min, max));
	public static Vector2 ClampX(this Vector2 vector, double min, double max) =>
		ClampX(vector,
				(float) min,
				(float) max);

	public static Vector2 ClampY(this Vector2 vector, int min, int max) =>
		CopyWith(vector,
					y: Clamp(vector.Y, min, max));
	public static Vector2 ClampY(this Vector2 vector, float min, float max) =>
		CopyWith(vector,
					y: Clamp(vector.Y, min, max));
	public static Vector2 ClampY(this Vector2 vector, double min, double max) =>
		ClampY(vector,
				(float) min,
				(float) max);

	public static Vector2I ClampX(this Vector2I vector, int min, int max) =>
		CopyWith(vector,
					x: Clamp(vector.X, min, max));
	public static Vector2I ClampY(this Vector2I vector, int min, int max) =>
		CopyWith(vector,
					y: Clamp(vector.Y, min, max));

	public static float Sample(this Curve curve, double offset) =>
		curve.Sample((float) offset);

}