using Godot;

using Metal666.GodotUtilities.Architecture;
using Metal666.GodotUtilities.Logging;
using Metal666.GodotUtilities.Logging.Loggers;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Metal666.GodotUtilities;

public abstract partial class AdvancedSceneTreeBase : SceneTree {

	public virtual List<Node> SingletonInstances { get; set; } =
		new();

	public virtual List<LoggerBase> Loggers { get; set; } =
		new() {

			new EditorLogger()

		};

	public AdvancedSceneTreeBase() {

		NodeAdded += OnNodeAdded;

	}

	protected virtual void OnNodeAdded(Node node) {

		if(node is not ISingleton) {

			return;

		}

		SingletonInstances.Add(node);

	}

	public virtual void Log(string message,
							LogLevel logLevel = LogLevel.Message,
							Type? sourceType = null) {

		foreach(LoggerBase logger in Loggers) {

			logger.Write(message, logLevel, sourceType);

		}

	}

	public virtual TNode GetSingleton<TNode>()
		where TNode : Node, ISingleton =>
			SingletonInstances.OfType<TNode>()
								.First();

}