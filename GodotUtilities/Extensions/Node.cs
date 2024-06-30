using Godot;

namespace Metal666.GodotUtilities.Extensions;

public static class Tree {

	public static void Unparent(this Node node) =>
		node.GetParent()?
			.RemoveChild(node);

}