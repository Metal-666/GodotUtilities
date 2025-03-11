using Metal666.GodotUtilities.Extensions;

using System.Collections.Generic;

namespace Metal666.GodotUtilities.Input;

public class MouseContext {

	public virtual bool LogEvents { get; set; }

	public virtual Stack<Godot.Input.MouseModeEnum> StoredMouseModes { get; protected set; } =
		new();

	public virtual Godot.Input.MouseModeEnum CurrentMouseMode { get; protected set; } =
		Godot.Input.MouseMode;

	public virtual bool AreUpdatesPaused { get; protected set; }

	public virtual void ChangeMouseMode(Godot.Input.MouseModeEnum mouseMode) {

		StoredMouseModes.Push(Godot.Input.MouseMode);

		SetMouseMode(mouseMode);

		Log($"Mouse mode changed to {Godot.Input.MouseMode}.");

	}

	public virtual void RevertMouseMode() {

		if(StoredMouseModes.Count == 0) {

			return;

		}

		SetMouseMode(StoredMouseModes.Pop());

		Log($"Mouse mode reverted to {Godot.Input.MouseMode}.");

	}

	protected virtual void SetMouseMode(Godot.Input.MouseModeEnum mouseMode) {

		CurrentMouseMode = mouseMode;

		if(AreUpdatesPaused) {

			return;

		}

		Godot.Input.MouseMode = CurrentMouseMode;

	}

	public virtual void PauseMouseModeUpdates() {

		AreUpdatesPaused = true;

		Log($"Mouse mode updates paused.");

	}

	public virtual void ResumeMouseModeUpdates() {

		AreUpdatesPaused = false;

		SetMouseMode(CurrentMouseMode);

		Log($"Mouse mode updates resumed (applied mode {CurrentMouseMode}).");

	}

	protected virtual void Log(string message) {

		if(!LogEvents) {

			return;

		}

		this.LogMessage(message);

	}

	public class Global : MouseContext {

		private static MouseContext? instance;
		public static MouseContext Instance =>
			instance ??= new();

		public static new bool LogEvents {

			get => Instance.LogEvents;
			set => Instance.LogEvents = value;

		}

		public static new Stack<Godot.Input.MouseModeEnum> StoredMouseModes {

			get => Instance.StoredMouseModes;
			set => Instance.StoredMouseModes = value;

		}

		public static new Godot.Input.MouseModeEnum CurrentMouseMode {

			get => Instance.CurrentMouseMode;
			set => Instance.CurrentMouseMode = value;

		}

		public static new bool AreUpdatesPaused =>
			Instance.AreUpdatesPaused;

		public static new void ChangeMouseMode(Godot.Input.MouseModeEnum mouseMode) =>
			Instance.ChangeMouseMode(mouseMode);
		public static new void RevertMouseMode() =>
			Instance.RevertMouseMode();
		public static new void PauseMouseModeUpdates() =>
			Instance.PauseMouseModeUpdates();
		public static new void ResumeMouseModeUpdates() =>
			Instance.ResumeMouseModeUpdates();

	}

}