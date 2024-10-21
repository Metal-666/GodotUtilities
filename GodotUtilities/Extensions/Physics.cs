using Godot;

namespace Metal666.GodotUtilities.Extensions;

public static class Physics {

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