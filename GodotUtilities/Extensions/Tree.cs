using Godot;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Metal666.GodotUtilities.Extensions;

public static class Tree {

	public static void Unparent(this Node node) =>
		node.GetParent()?
			.RemoveChild(node);

	public static void ChangeSceneToFileDeferred(this SceneTree sceneTree,
													string path,
													Action<Error>? callback = null) =>
		Threading.InvokeOnMainThread((path, callback) => {

			Error error = sceneTree.ChangeSceneToFile(path);

			callback?.Invoke(error);

		}, path, callback);

	public static void ChangeSceneToPackedDeferred(this SceneTree sceneTree,
													PackedScene packedScene,
													Action<Error>? callback = null) =>
		Threading.InvokeOnMainThread((packedScene, callback) => {

			Error error = sceneTree.ChangeSceneToPacked(packedScene);

			callback?.Invoke(error);

		}, packedScene, callback);

	public static List<T> GetChildren<T>(this Node node, bool includeInternal = false) =>
		[.. node.GetChildren(includeInternal).OfType<T>()];
	public static List<T> GetChildrenOrThrow<T>(this Node node, bool includeInternal = false) =>
		[.. node.GetChildren(includeInternal).Cast<T>()];

}