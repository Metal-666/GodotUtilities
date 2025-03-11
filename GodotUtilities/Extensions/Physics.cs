using Godot;

using System.Diagnostics.CodeAnalysis;

namespace Metal666.GodotUtilities.Extensions;

public static class Physics {

	public static TShape Shape<TShape>(this CollisionShape2D collider)
		where TShape : Shape2D =>
			(TShape) collider.Shape;
	public static TShape Shape<TShape>(this CollisionShape3D collider)
		where TShape : Shape3D =>
			(TShape) collider.Shape;

	public static float GetLength(this CollisionShape2D collider,
									Vector2.Axis axis = Vector2.Axis.Y) =>
		collider.Shape switch {

			SeparationRayShape2D separationRayShape =>
				separationRayShape.Length,
			RectangleShape2D rectangleShape =>
				rectangleShape.Size[(int) axis],
			CircleShape2D circleShape =>
				circleShape.Radius,
			CapsuleShape2D capsuleShape =>
				axis == Vector2.Axis.Y ?
					capsuleShape.Height :
					capsuleShape.Radius,
			_ => 0

		};

	public static float GetLength(this CollisionShape3D collider,
									Vector3.Axis axis = Vector3.Axis.Y) =>
		collider.Shape switch {

			SeparationRayShape3D separationRayShape =>
				separationRayShape.Length,
			BoxShape3D boxShape =>
				boxShape.Size[(int) axis],
			SphereShape3D sphereShape =>
				sphereShape.Radius,
			CapsuleShape3D capsuleShape =>
				axis == Vector3.Axis.Y ?
					capsuleShape.Height :
					capsuleShape.Radius,
			CylinderShape3D cylinderShape =>
				axis == Vector3.Axis.Y ?
					cylinderShape.Height :
					cylinderShape.Radius,
			_ => 0

		};

	public static void SetLength(this CollisionShape2D collider,
									float length,
									Vector2.Axis axis = Vector2.Axis.Y) {

		switch(collider.Shape) {

			case SeparationRayShape2D separationRayShape: {

				separationRayShape.Length = length;

				break;

			}

			case RectangleShape2D rectangleShape: {

				rectangleShape.Size =
					rectangleShape.Size.CopyWith(axis, length);

				break;

			}

			case CircleShape2D circleShape: {

				circleShape.Radius = length;

				break;

			}

			case CapsuleShape2D capsuleShape: {

				if(axis == Vector2.Axis.Y) {

					capsuleShape.Height = length;

				}

				else {

					capsuleShape.Radius = length;

				}

				break;

			}

		}

	}
	public static void SetLength(this CollisionShape3D collider,
									float length,
									Vector3.Axis axis = Vector3.Axis.Y) {

		switch(collider.Shape) {

			case SeparationRayShape3D separationRayShape: {

				separationRayShape.Length = length;

				break;

			}

			case BoxShape3D boxShape: {

				boxShape.Size =
					boxShape.Size.CopyWith(axis, length);

				break;

			}

			case SphereShape3D sphereShape: {

				sphereShape.Radius = length;

				break;

			}

			case CapsuleShape3D capsuleShape: {

				if(axis == Vector3.Axis.Y) {

					capsuleShape.Height = length;

				}

				else {

					capsuleShape.Radius = length;

				}

				break;

			}

			case CylinderShape3D cylinderShape: {

				if(axis == Vector3.Axis.Y) {

					cylinderShape.Height = length;

				}

				else {

					cylinderShape.Radius = length;

				}

				break;

			}

		}

	}

	public static RaycastResult3D? RayCast(this Node3D node, PhysicsRayQueryParameters3D parameters) {

		Godot.Collections.Dictionary raycastHit =
			node.GetWorld3D()
				.DirectSpaceState
				.IntersectRay(parameters);

		if(raycastHit.Count == 0) {

			return null;

		}

		return new((Node3D) raycastHit["collider"],
								(int) raycastHit["collider_id"],
								(Vector3) raycastHit["normal"],
								(Vector3) raycastHit["position"],
								(int) raycastHit["face_index"],
								(Rid) raycastHit["rid"],
								(int) raycastHit["shape"]);

	}
	public static RaycastResult2D? RayCast(this Node2D node, PhysicsRayQueryParameters2D parameters) {

		Godot.Collections.Dictionary raycastHit =
			node.GetWorld2D()
				.DirectSpaceState
				.IntersectRay(parameters);

		if(raycastHit.Count == 0) {

			return null;

		}

		return new((Node2D) raycastHit["collider"],
								(int) raycastHit["collider_id"],
								(Vector2) raycastHit["normal"],
								(Vector2) raycastHit["position"],
								(Rid) raycastHit["rid"],
								(int) raycastHit["shape"]);

	}

	public static bool TryRayCast(this Node3D node,
									PhysicsRayQueryParameters3D parameters,
									[MaybeNullWhen(false)] out RaycastResult3D result) =>
		(result = node.RayCast(parameters)) != null;
	public static bool TryRayCast(this Node2D node,
									PhysicsRayQueryParameters2D parameters,
									[MaybeNullWhen(false)] out RaycastResult2D result) =>
		(result = node.RayCast(parameters)) != null;

	public record RaycastResult3D(Node3D Collider,
									int ColliderId,
									Vector3 Normal,
									Vector3 Position,
									int FaceIndex,
									Rid Rid,
									int Shape);

	public record RaycastResult2D(Node2D Collider,
									int ColliderId,
									Vector2 Normal,
									Vector2 Position,
									Rid Rid,
									int Shape);

}