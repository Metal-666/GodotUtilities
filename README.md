# GodotUtilities

A set of utilities I use in my Godot projects.

## Features

### Architecture

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

### Logging

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

### Networking

- `LocalInstanceController`

  This class can be used as an alternative to the "Launch multiple instances" editor function. Use the `Initialize` method to spawn additional game instances. At the moment it is rather basic and doesn't offer much benefit over the editor functionality. I will be extending it with more features in the future.

### Input

- `MouseContext`

  This is a wrapper around `Input.MouseMode`. When you call the `ChangeMouseMode` method, the current mouse mode is added to a stack collection. You can call `RevertMouseMode` to go backwards through the stack and apply previous mouse modes. This is useful if you have a complex UI setup where different view/overlays/windows require different mouse modes. You can call `ChangeMouseMode` when a new view opens and `RevertMouseMode` when it closes.

  Additionally, you can use the `PauseMouseModeUpdates` and `ResumeMouseModeUpdates` methods to temporarily stop the mouse mode from being applied (the stack will still have values added/removed from it). This can be useful when the game is minimized or the user is alt-tabbed and you don't want to mess with their mouse. To retrieve the "intended" mouse mode use the `CurrentMouseMode` property.

  The `MouseContext` class can be instantiated, or you can use the static `MouseContext.Global` version of it. You can set the `LogEvents` property to `true` to enable logging.

### Extension methods

- Controls
  - `Range.ValueF()` - retrieve the value of a `Range` node as a `float`.
  - `Range.ValueI()` - retrieve the value of a `Range` node as a rounded `int`.
  - `Tree.SetColumn(int index, TreeColumnData treeColumnData)` - a shortcut to `Tree.SetColumn*` methods. Set all column properties with a single object.
  - `Tree.SetColumns(IEnumerable<TreeColumnData> treeColumnDatas)` - sets all Tree columns using the above method.
- LINQ
  - `IEnumerable.If(bool condition, Func<IEnumerable<TSource>, IEnumerable<TSource>> branch)` - branches inside LINQ chains.
- Math
  - Direct shortcuts to `Mathf` functions:
    - `float.Lerp(float to, float weight)`, `float.Lerp(float to, double weight)`, `double.Lerp(double to, double weight)`.
    - `float.MoveToward(float to, float delta)`, `float.MoveToward(float to, double delta)`, `double.MoveToward(double to, double delta)`.
    - `float.LerpAngle(float to, float weight)`, `float.LerpAngle(float to, double weight)`, `double.LerpAngle(double to, double weight)`.
    - `int.Abs()`, `float.Abs()`, `double.Abs()`.
    - `int.Clamp(int min, int max)`, `float.Clamp(float min, float max)`, `double.Clamp(double min, double max)`.
    - `int.Wrap(int min, int max)`, `float.Wrap(float min, float max)`, `double.Wrap(double min, double max)`.
    - `int.PosMod(int a, int b)`, `float.PosMod(float a, float b)`, `double.PosMod(double a, double b)`.
    - `float.AngleDifference(float to)`, `double.AngleDifference(double to)`.
    - `float.IsZeroApprox()`, `double.IsZeroApprox()`.
    - `float.IsEqualApprox(float to)`, `double.IsEqualApprox(double to)`, `float.IsEqualApprox(float to, float tolerance)`, `double.IsEqualApprox(double to, double tolerance)`.
    - `int.ToDeg()`, `float.ToDeg()`, `double.ToDeg()`.
    - `int.ToRad()`, `float.ToRad()`, `double.ToRad()`.
    - `float.RoundToInt()`, `float.FloorToInt()`, `float.CeilToInt()`.
    - `double.RoundToInt()`, `double.FloorToInt()`, `double.CeilToInt()`.
  - Extra shortcuts:
    - `int.Clamp(Vector2I range)`, `float.Clamp(Vector2 range)` - clamps using vector components as min/max values.
    - `int.Wrap360Deg()`, `float.Wrap360Deg()`, `double.Wrap360Deg()` - uses `PosMod` to ensure the angle is in range [0, 360).
    - `float.Wrap360Rad()`, `double.Wrap360Rad()` - uses `PosMod` to ensure the angle is in range [0, `Mathf.Tau`).
    - `int.SignedWrap360Deg()`, `float.SignedWrap360Deg()`, `double.SignedWrap360Deg()` - uses `Wrap` to ensure the angle is in range [-180, 180).
    - `float.SignedWrap360Rad()`, `double.SignedWrap360Rad()` - uses `Wrap` to ensure the angle is in range [-`Mathf.Pi`, `Mathf.Pi`).
    - `int.Wrap720Deg()`, `float.Wrap720Deg()`, `double.Wrap720Deg()` - uses `PosMod` to ensure the angle is in range [0, 720).
    - `float.Wrap720Rad()`, `double.Wrap720Rad()` - uses `PosMod` to ensure the angle is in range [0, `Mathf.Tau * 2`).
    - `int.SignedWrap720Deg()`, `float.SignedWrap720Deg()`, `double.SignedWrap720Deg()` - uses `Wrap` to ensure the angle is in range [-360, 360).
    - `float.SignedWrap720Rad()`, `double.SignedWrap720Rad()` - uses `Wrap` to ensure the angle is in range [-`Mathf.Tau`, `Mathf.Tau`).
    - `float.AngleDifferenceAbs(float to)`, `double.AngleDifferenceAbs(double to)` - calls `AngleDifference` then `Abs`.
    - `float.DifferenceAbs(float to)`, `double.DifferenceAbs(double to)` - calls `Abs` on `value - to`.
    - `Vector2.Get(Vector2.Axis axis)`, `Vector3.Get(Vector3.Axis axis)` - gets the vector component specified by `axis`.
    - `Vector2.IsEqualApprox(Vector2 vector, float tolerance)`, `Vector3.IsEqualApprox(Vector3 vector, float tolerance)` - compare vectors with tolerance.
    - `Vector2.CopyWith(float? x = null, float? y = null)`, `Vector2I.CopyWith(int? x = null, int? y = null)`, `Vector3.CopyWith(float? x = null, float? y = null, float? z = null)`, `Vector3I.CopyWith(int? x = null, int? y = null, int? z = null)` - returns a copy of the vector with the specified components replaced.
    - `Vector2.CopyWith(Vector2.Axis axis, float value)`, `Vector2I.CopyWith(Vector2I.Axis axis, int value)`, `Vector3.CopyWith(Vector3.Axis axis, float value)`, `Vector3I.CopyWith(Vector3I.Axis axis, int value)` - returns a copy of the vector with the component, specified by the `axis`, replaced.
    - `Vector3.Lerp(Vector3 to, double weight)`, `Vector2.Lerp(Vector2 to, double weight)` - calls `vector.Lerp` with `weight` cast to `float`.
    - `Vector3.MoveToward(Vector3 to, double weight)`, `Vector2.MoveToward(Vector2 to, double weight)` - calls `vector.MoveToward` with `delta` cast to `float`.
    - `Vector3.RotatedDeg(Vector3 axis, float angle)` - calls `Vector3.Rotated` with `angle` converted to radians.
    - `Vector3.FlattenX()`, `Vector3.FlattenY()`, `Vector3.FlattenZ()`, `Vector3I.FlattenX()`, `Vector3I.FlattenY()`, `Vector3I.FlattenZ()` - converts a 3D vector to a 2D one by removing the specified component.
    - `Vector2.AddXComponent(float x = 0)`, `Vector2.AddYComponent(float y = 0)`, `Vector2.AddZComponent(float z = 0)`,
    - `Vector2I.AddXComponent(int x = 0)`, `Vector2I.AddYComponent(int y = 0)`, `Vector2I.AddZComponent(int z = 0)` - converts a 2D vector to a 3D one by inserting the specified component.
    - `Vector2.ToDeg()`, `Vector3.ToDeg()`, `Vector2.ToRad()`, `Vector3.ToRad()` - returns a copy of the vector with all components converted to degrees/radians.
    - `Vector2.RoundToInt()`, `Vector2.FloorToInt()`, `Vector2.CeilToInt()`, `Vector3.RoundToInt()`, `Vector3.FloorToInt()`, `Vector3.CeilToInt()` - returns a copy of the vector with all components rounded/floored/ceiled to integer values.
    - `Vector2.UnsignedAngleTo(Vector2 to)` - calls `vector.AngleTo` then `Abs`.
    - `Vector2.Swap()`, `Vector2I.Swap()` - returns a copy of the vector with X and Y components swapped.
    - `Vector3.OverwriteXY(Vector2 with)`, `Vector3.OverwriteXZ(Vector2 with)`, `Vector3.OverwriteYZ(Vector2 with)`, `Vector3I.OverwriteXY(Vector2I with)`, `Vector3I.OverwriteXZ(Vector2I with)`, `Vector3I.OverwriteYZ(Vector2I with)` - returns a copy of the vector with the specified components replaced with the components from a 2D vector.
    - `Vector2.ElementWiseProduct(Vector2 other)`, `Vector3.ElementWiseProduct(Vector3 other)`, `Vector2I.ElementWiseProduct(Vector2I other)`, `Vector3I.ElementWiseProduct(Vector3I other)` - performs element-wise multiplication of the vectors.
    - `Vector3.ClampX(int min, int max)`, `Vector3.ClampX(float min, float max)`, `Vector3.ClampX(double min, double max)`, `Vector3.ClampY(int min, int max)`, `Vector3.ClampY(float min, float max)`, `Vector3.ClampY(double min, double max)`, `Vector3.ClampZ(int min, int max)`, `Vector3.ClampZ(float min, float max)`, `Vector3.ClampZ(double min, double max)`, `Vector3I.ClampX(int min, int max)`, `Vector3I.ClampY(int min, int max)`, `Vector3I.ClampZ(int min, int max)`, `Vector2.ClampX(int min, int max)`, `Vector2.ClampX(float min, float max)`, `Vector2.ClampX(double min, double max)`, `Vector2.ClampY(int min, int max)`, `Vector2.ClampY(float min, float max)`, `Vector2.ClampY(double min, double max)`, `Vector2I.ClampX(int min, int max)`, `Vector2I.ClampY(int min, int max)` - returns a copy of the vector with the specified component clamped between the `min` and `max` value.
    - `Curve.Sample(double offset)` - calls `curve.Sample` with `offset` cast to `float`.
- Physics
  - `CollisionShape2D.Shape<TShape>()`, `CollisionShape3D.Shape<TShape>()` - returns `collider.Shape` cast to `TShape`.
  - `CollisionShape2D.GetLength(Vector2.Axis axis = Vector2.Axis.Y)`, `CollisionShape3D.GetLength(Vector3.Axis axis = Vector3.Axis.Y)` - returns the length of the collider:
    - For 2D shapes:
      - `SeparationRayShape2D` - the `Length` property.
      - `RectangleShape2D` - a component of the `Size` property, specified by the `axis`.
      - `CircleShape2D` - the `Radius` property.
      - `CapsuleShape2D` - if `axis` is Y, returns the `Height` property. Otherwise returns the `Radius` property.
    - For 3D shapes:
      - `SeparationRayShape3D` - the `Length` property.
      - `BoxShape3D` - a component of the `Size` property, specified by the `axis`.
      - `SphereShape3D` - the `Radius` property.
      - `CapsuleShape3D`, `CylinderShape3D` - if `axis` is Y, returns the `Height` property. Otherwise returns the `Radius` property.
  - `CollisionShape2D.SetLength(float length, Vector2.Axis axis = Vector2.Axis.Y)`, `CollisionShape3D.SetLength(float length, Vector3.Axis axis = Vector3.Axis.Y)` - sets the length of the collider; property to set is determined using the process above.
  - `Node3D.RayCast(PhysicsRayQueryParameters3D parameters)` - performs `PhysicsDirectSpaceState3D.IntersectRay`. Returns a strongly typed `RaycastResult3D` object.
  - `Node2D.RayCast(PhysicsRayQueryParameters2D parameters)` - performs `PhysicsDirectSpaceState2D.IntersectRay`. Returns a strongly typed `RaycastResult2D` object.
  - `Node3D.TryRayCast(PhysicsRayQueryParameters3D parameters, out RaycastResult3D result)` - same as `Node3D.RayCast` but via a `TryGet` pattern.
  - `Node2D.TryRayCast(PhysicsRayQueryParameters2D parameters, out RaycastResult2D result)` - same as `Node2D.RayCast` but via a `TryGet` pattern.
- Threading
  - `Action.InvokeOnMainThread()` (+ 16 overloads) - a shortcut to `Callable.From(action).CallDeferred()`.
- Transforms
  - `Node2D.RotateDeg(int angle)`, `Node2D.RotateDeg(float angle)`, `Node2D.RotateDeg(double angle)` - calls `Node2D.Rotate` with `angle` converted to radians.
  - `Node3D.RotateDeg(Vector3 axis, int angle)`, `Node3D.RotateDeg(Vector3 axis, float angle)`, `Node3D.RotateDeg(Vector3 axis, double angle)` - calls `Node3D.Rotate` with `angle` converted to radians.
  - `Node3D.RotateXDeg(int angle)`, `Node3D.RotateXDeg(float angle)`, `Node3D.RotateXDeg(double angle)`, `Node3D.RotateYDeg(int angle)`, `Node3D.RotateYDeg(float angle)`, `Node3D.RotateYDeg(double angle)`, `Node3D.RotateZDeg(int angle)`, `Node3D.RotateZDeg(float angle)`, `Node3D.RotateZDeg(double angle)` - calls `Node3D.Rotate*` with `angle` converted to radians.
  - `Node3D.SetXRotation(int angle)`, `Node3D.SetXRotation(float angle)`, `Node3D.SetXRotation(double angle)`, `Node3D.SetYRotation(int angle)`, `Node3D.SetYRotation(float angle)`, `Node3D.SetYRotation(double angle)`, `Node3D.SetZRotation(int angle)`, `Node3D.SetZRotation(float angle)`, `Node3D.SetZRotation(double angle)`, `Node3D.SetXRotationDeg(int angle)`, `Node3D.SetXRotationDeg(float angle)`, `Node3D.SetXRotationDeg(double angle)`, `Node3D.SetYRotationDeg(int angle)`, `Node3D.SetYRotationDeg(float angle)`, `Node3D.SetYRotationDeg(double angle)`, `Node3D.SetZRotationDeg(int angle)`, `Node3D.SetZRotationDeg(float angle)`, `Node3D.SetZRotationDeg(double angle)`, `Node3D.SetXRotationGlobal(int angle)`, `Node3D.SetXRotationGlobal(float angle)`, `Node3D.SetXRotationGlobal(double angle)`, `Node3D.SetYRotationGlobal(int angle)`, `Node3D.SetYRotationGlobal(float angle)`, `Node3D.SetYRotationGlobal(double angle)`, `Node3D.SetZRotationGlobal(int angle)`, `Node3D.SetZRotationGlobal(float angle)`, `Node3D.SetZRotationGlobal(double angle)`, `Node3D.SetXRotationDegGlobal(int angle)`, `Node3D.SetXRotationGlobalDeg(float angle)`, `Node3D.SetXRotationGlobalDeg(double angle)`, `Node3D.SetYRotationGlobalDeg(int angle)`, `Node3D.SetYRotationGlobalDeg(float angle)`, `Node3D.SetYRotationGlobalDeg(double angle)`, `Node3D.SetZRotationGlobalDeg(int angle)`, `Node3D.SetZRotationGlobalDeg(float angle)`, `Node3D.SetZRotationGlobalDeg(double angle)`, `Node3D.SetXPosition(int angle)`, `Node3D.SetXPosition(float angle)`, `Node3D.SetXPosition(double angle)`, `Node3D.SetYPosition(int angle)`, `Node3D.SetYPosition(float angle)`, `Node3D.SetYPosition(double angle)`, `Node3D.SetZPosition(int angle)`, `Node3D.SetZPosition(float angle)`, `Node3D.SetZPosition(double angle)`, `Node3D.SetXPositionGlobal(int angle)`, `Node3D.SetXPositionGlobal(float angle)`, `Node3D.SetXPositionGlobal(double angle)`, `Node3D.SetYPositionGlobal(int angle)`, `Node3D.SetYPositionGlobal(float angle)`, `Node3D.SetYPositionGlobal(double angle)`, `Node3D.SetZPositionGlobal(int angle)`, `Node3D.SetZPositionGlobal(float angle)`, `Node3D.SetZPositionGlobal(double angle)`, `Node2D.SetXPosition(int angle)`, `Node2D.SetXPosition(float angle)`, `Node2D.SetXPosition(double angle)`, `Node2D.SetYPosition(int angle)`, `Node2D.SetYPosition(float angle)`, `Node2D.SetYPosition(double angle)`, `Node2D.SetXPositionGlobal(int angle)`, `Node2D.SetXPositionGlobal(float angle)`, `Node2D.SetXPositionGlobal(double angle)`, `Node2D.SetYPositionGlobal(int angle)`, `Node2D.SetYPositionGlobal(float angle)`, `Node2D.SetYPositionGlobal(double angle)` - ... yea... I... I think you can tell what these methods do.
- Tree
  - `Node.Unparent()` - self-explanatory.
  - `SceneTree.ChangeSceneToFileDeferred(string path, Action<Error>? callback = null)` - calls `SceneTree.ChangeSceneToFile` in deferred mode. The return value is passed to `callback` (if provided).
  - `SceneTree.ChangeSceneToPackedDeferred(PackedScene packedScene, Action<Error>? callback = null)` - same as above, but for `SceneTree.ChangeSceneToPacked`.
  - `Node.GetChildren<T>(bool includeInternal = false)` - calls `node.GetChildren(includeInternal)` then `.OfType<T>()`.
  - `Node.GetChildrenOrThrow<T>(bool includeInternal = false)` - calls `node.GetChildren(includeInternal)` then `.Cast<T>()`.
- Visual
  - `Color.ToVector3()` - creates a vector from the `R`, `G` and `B` values.
  - `Color.ToVector3I()` - creates a vector from the `R8`, `G8` and `B8` values.

### Additional utilities

- Access `Is.Editor` or `Is.Standalone` to determine if the game was launched from the editor or not.
