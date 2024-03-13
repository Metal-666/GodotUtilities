using System;
using System.Collections.Generic;

namespace Metal666.GodotUtilities.Extensions;

public static class Linq {

	public static IEnumerable<TSource> If<TSource>(this IEnumerable<TSource> source,
													bool condition,
													Func<IEnumerable<TSource>, IEnumerable<TSource>> branch) =>
		condition ? branch(source) : source;

	public static IEnumerable<TSource> If<TSource>(this IEnumerable<TSource> source,
													Func<IEnumerable<TSource>, bool> condition,
													Func<IEnumerable<TSource>, IEnumerable<TSource>> branch) =>
		condition(source) ? branch(source) : source;

}