using Godot;

using Metal666.GodotUtilities.Architecture;

using System;

namespace Metal666.GodotUtilities.Extensions;

public static class Architecture {

	public static TTree? GetTree<TTree>(this Node node)
		where TTree : SceneTree {

		if(node.GetTree() is not TTree tree) {

			return null;

		}

		return tree;

	}

	public static TNode Get<TNode>(this Node node)
		where TNode : Node, ISingleton {

		AdvancedSceneTreeBase? advancedSceneTree =
			node.GetTree<AdvancedSceneTreeBase>();

		if(advancedSceneTree == null) {

			GD.PushError("Failed to retrieve singleton instance: current tree type does not inherit {typeof(AdvancedSceneTreeBase)}!");

			throw new InvalidOperationException($"Tree does not inherit {typeof(AdvancedSceneTreeBase)}.");

		}

		return advancedSceneTree.GetSingleton<TNode>();

	}

}