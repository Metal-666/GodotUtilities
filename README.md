# GodotUtilities

A set of utilities I use in my Godot projects.

## Features

- Architecture

  - Singletons - turn custom Nodes into Singletons by adding the `Singleton` attribute.

    The included source generator will add the `Instance` property + a parameterless constructor, where it is set.

  - State (experimental) - use the `State` attribute to mark static classes as states.

    The following things will be generated for each private field in the state:

    - A public property

      Use it to modify the field.

    - An `On<Property>Changed` event

      Invoked when a property is set.

    - An interface with a single `On<Property>Changed` method.

      Implement it on any node and the method will be automatically called when the property is changed.

- Logging

  A modular logging system is available. In order to log a message, call the `Log` method on the static `LogManager` class. By default, the message will be processed by 2 loggers:

  - `EditorLogger` (activated when running the game from the editor)

    Prints the message to the Godot console using one of the `GD.PrintRich`/`GD.PushWarning`/`GD.PushError` (based on the message log level).

  - `ConsoleLogger` (activated when running the game standalone)

    Prints the message using `Console.WriteLine`.

  When logging, parameters such as `logLevel`, `sourceType` and `indentation` can be specified to format the output.

  Loggers extend a base `LoggerBase` class. If you need to implement a custom logging solution you can extend either of the stock loggers, or the base class. Then you can override the available methods and properties to change how the message is processed and output. Finally, set the `Loggers` value on the `LogManager` class (overriding the default loggers).

  Two additional logging features are available:

  - Extension methods

    A vast selection of extension methods are available for convenient logging. For example, if you call the `LogMessage` extension method, the object's `Type` will be automatically passed as the `sourceType` parameter and the log level will be set to `LogLevel.Message`. All extension methods are contained inside the static `Logging` class inside the `Metal666.GodotUtilities.Extensions` namespace.

  - `LogSource` attribute

    Attach it to a custom node class, and specify the `Color` property (use HTML color names, such as `red`). When a log arrives with that node's type as the `sourceType`, the output will be colored using the specified color. The `EditorLogger` will use the `[color]` `BBCode`, while the `ConsoleLogger` will convert the color to the closest `ConsoleColor` enum value and set the `Console.ForegroundColor`.

- Networking

  - `LocalInstanceController`

    This class can be used as an alternative to the "Launch multiple instances" editor function. Use the `Initialize` method to spawn additional game instances. At the moment it is rather basic and doesn't offer much benefit over the editor functionality. I will be extending it with more features in the future.

- Extension methods

  - Controls
    - `Range.ValueF()` - retrieve the value of a `Range` node as a `float`.
    - `Range.ValueF()` - retrieve the value of a `Range` node as a rounded `int`.
  - LINQ
    - `IEnumerable.If(bool condition, Func<IEnumerable<TSource>, IEnumerable<TSource>> branch)` - branches inside LINQ chains.
  - Math
    - `Vector2.IsEqualApprox(Vector2 b, float tolerance)` - compare vectors with tolerance.
    - `Vector3.IsEqualApprox(Vector3 b, float tolerance)` - compare vectors with tolerance.
    - `Vector2.CopyWith(float? x = null, float? y = null)` - copy vector with components modified.
    - `Vector2I.CopyWith(int? x = null, int? y = null)` - copy vector with components modified.
    - `Vector3.CopyWith(float? x = null, float? y = null, float? z = null)` - copy vector with components modified.
    - `Vector3I.CopyWith(int? x = null, int? y = null, int? z = null)` - copy vector with components modified.
    - `Vector3.RotatedDeg(Vector3 axis, float angle)` - `Vector3.Rotated`, but in degrees.
    - `int.ToDeg()`, `float.ToDeg()`, `double.ToDeg()` - shortcuts to `Mathf.RadToDeg`.
    - `int.ToRad()`, `float.ToRad()`, `double.ToRad()` - shortcuts to `Mathf.DegToRad`.
    - `Vector2.ToDeg()`, `Vector3.ToDeg()`, `Vector2.ToRad()`, `Vector3.ToRad()` - performs `float.ToDeg()`/`float.ToRad()` on all vector components.
    - `float.RoundToInt()`, `float.FloorToInt()`, `float.CeilToInt()` - shortcuts to `Mathf.RoundToInt`, `Mathf.FloorToInt` and `Mathf.CeilToInt`.
    - `double.RoundToInt()`, `double.FloorToInt()`, `double.CeilToInt()` - shortcuts to `Mathf.RoundToInt`, `Mathf.FloorToInt` and `Mathf.CeilToInt`.
    - `Vector2.RoundToInt()`, `Vector2.FloorToInt()`, `Vector2.CeilToInt()` - performs `float.RoundToInt()`/`float.FloorToInt()`/`float.CeilToInt()` on all vector components.
    - `Vector3.RoundToInt()`, `Vector3.FloorToInt()`, `Vector3.CeilToInt()` - performs `float.RoundToInt()`/`float.FloorToInt()`/`float.CeilToInt()` on all vector components.
  - Physics
    - `Node3D.RayCast(PhysicsRayQueryParameters3D parameters)` - performs `PhysicsDirectSpaceState3D.IntersectRay`. Returns a strongly typed `RaycastResult3D` object.
    - `Node2D.RayCast(PhysicsRayQueryParameters2D parameters)` - performs `PhysicsDirectSpaceState2D.IntersectRay`. Returns a strongly typed `RaycastResult2D` object.
  - Threading
    - `Action.InvokeOnMainThread()` (+ 16 overloads) - a shortcut to `Callable.From(action).CallDeferred()`.
  - Transforms
    - `Node2D.RotateDeg(int angle)`, `Node2D.RotateDeg(float angle)`, `Node2D.RotateDeg(double angle)` - `Node2D.Rotate`, but in degrees.
    - `Node3D.RotateDeg(Vector3 axis, int angle)`, `Node3D.RotateDeg(Vector3 axis, float angle)`, `Node3D.RotateDeg(Vector3 axis, double angle)` - `Node3D.Rotate`, but in degrees.
    - `Node3D.RotateXDeg(int angle)`, `Node3D.RotateXDeg(float angle)`, `Node3D.RotateXDeg(double angle)` - `Node2D.RotateX`, but in degrees.
    - `Node3D.RotateYDeg(int angle)`, `Node3D.RotateYDeg(float angle)`, `Node3D.RotateYDeg(double angle)` - `Node2D.RotateY`, but in degrees.
    - `Node3D.RotateZDeg(int angle)`, `Node3D.RotateZDeg(float angle)`, `Node3D.RotateZDeg(double angle)` - `Node2D.RotateX`, but in degrees.
  - Tree
    - `Node.Unparent()` - self-explanatory.
  - Visual
    - `Color.ToVector3()` - creates a vector from the `R`, `G` and `B` values.
    - `Color.ToVector3I()` - creates a vector from the `R8`, `G8` and `B8` values.

- Additional utilities
  - Access `Is.Editor` or `Is.Standalone` to determine if the game was launched from the editor or not.
