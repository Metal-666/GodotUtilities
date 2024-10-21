using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Metal666.GodotUtilities.Networking;

public static class LocalInstanceController {

	public const string MultiplayerChildArg = "--multiplayer-child";

	public static int Index { get; set; } = -1;

	public static Dictionary<int, Process> MultiplayerChildProcesses { get; set; } =
		[];

	public static void Initialize(int spawnChildrenCount = 0) {

		// Read the command line
		string[] commandLineArgs =
			Environment.GetCommandLineArgs();

		// Try to find the MultiplayerChild argument
		int multiplayerChildArgIndex =
			Array.IndexOf(commandLineArgs, MultiplayerChildArg);

		// Not found: we are the main instance
		if(multiplayerChildArgIndex == -1) {

			// Set the appropriate Index
			Index = 0;

			// Find the path to current .exe
			string? processPath = Environment.ProcessPath;

			if(processPath == null) {

				return;

			}

			// Spawn child processes
			for(int i = 0; i < spawnChildrenCount; i++) {

				// Increment by one cause 0 is the main instance
				int childIndex = i + 1;

				Process childProcess =
					Process.Start(processPath,
									commandLineArgs.Append(MultiplayerChildArg)
															.Append(childIndex.ToString()));

				MultiplayerChildProcesses[childIndex] = childProcess;

			}

			return;

		}

		// This is a child instance
		// Try to get our index (should be the next argument)
		int indexArgIndex = multiplayerChildArgIndex + 1;

		// This was the last argument? Oof
		if(indexArgIndex >= commandLineArgs.Length) {

			return;

		}

		// The next argument is not a number? Oof
		if(!int.TryParse(commandLineArgs[indexArgIndex], out int index)) {

			return;

		}

		// Nice
		Index = index;

	}

	public static void StopInstance(int index) {

		if(!MultiplayerChildProcesses.Remove(index, out Process? childProcess)) {

			return;

		}

		childProcess.Kill();

	}

	public static void StopAllInstances() {

		foreach(Process childProcess in MultiplayerChildProcesses.Values) {

			childProcess.Kill();

		}

		MultiplayerChildProcesses.Clear();

	}

}