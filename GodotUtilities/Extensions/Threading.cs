using Godot;

using System;

namespace Metal666.GodotUtilities.Extensions;

public static class Threading {

	public static void InvokeOnMainThread(this Action action) =>
		Callable.From(action).CallDeferred();

	public static void InvokeOnMainThread<T1>(this Action<T1> action,
												T1 arg1) =>
		Callable.From(() => action(arg1)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2>(this Action<T1, T2> action,
													T1 arg1,
													T2 arg2) =>
		Callable.From(() => action(arg1, arg2)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3>(this Action<T1, T2, T3> action,
														T1 arg1,
														T2 arg2,
														T3 arg3) =>
		Callable.From(() => action(arg1, arg2, arg3)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action,
															T1 arg1,
															T2 arg2,
															T3 arg3,
															T4 arg4) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action,
																T1 arg1,
																T2 arg2,
																T3 arg3,
																T4 arg4,
																T5 arg5) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action,
																	T1 arg1,
																	T2 arg2,
																	T3 arg3,
																	T4 arg4,
																	T5 arg5,
																	T6 arg6) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action,
																		T1 arg1,
																		T2 arg2,
																		T3 arg3,
																		T4 arg4,
																		T5 arg5,
																		T6 arg6,
																		T7 arg7) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action,
																			T1 arg1,
																			T2 arg2,
																			T3 arg3,
																			T4 arg4,
																			T5 arg5,
																			T6 arg6,
																			T7 arg7,
																			T8 arg8) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
																				T1 arg1,
																				T2 arg2,
																				T3 arg3,
																				T4 arg4,
																				T5 arg5,
																				T6 arg6,
																				T7 arg7,
																				T8 arg8,
																				T9 arg9) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
																					T1 arg1,
																					T2 arg2,
																					T3 arg3,
																					T4 arg4,
																					T5 arg5,
																					T6 arg6,
																					T7 arg7,
																					T8 arg8,
																					T9 arg9,
																					T10 arg10) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
																						T1 arg1,
																						T2 arg2,
																						T3 arg3,
																						T4 arg4,
																						T5 arg5,
																						T6 arg6,
																						T7 arg7,
																						T8 arg8,
																						T9 arg9,
																						T10 arg10,
																						T11 arg11) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
																								T1 arg1,
																								T2 arg2,
																								T3 arg3,
																								T4 arg4,
																								T5 arg5,
																								T6 arg6,
																								T7 arg7,
																								T8 arg8,
																								T9 arg9,
																								T10 arg10,
																								T11 arg11,
																								T12 arg12) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
																									T1 arg1,
																									T2 arg2,
																									T3 arg3,
																									T4 arg4,
																									T5 arg5,
																									T6 arg6,
																									T7 arg7,
																									T8 arg8,
																									T9 arg9,
																									T10 arg10,
																									T11 arg11,
																									T12 arg12,
																									T13 arg13) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
																										T1 arg1,
																										T2 arg2,
																										T3 arg3,
																										T4 arg4,
																										T5 arg5,
																										T6 arg6,
																										T7 arg7,
																										T8 arg8,
																										T9 arg9,
																										T10 arg10,
																										T11 arg11,
																										T12 arg12,
																										T13 arg13,
																										T14 arg14) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action,
																											T1 arg1,
																											T2 arg2,
																											T3 arg3,
																											T4 arg4,
																											T5 arg5,
																											T6 arg6,
																											T7 arg7,
																											T8 arg8,
																											T9 arg9,
																											T10 arg10,
																											T11 arg11,
																											T12 arg12,
																											T13 arg13,
																											T14 arg14,
																											T15 arg15) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15)).CallDeferred();

	public static void InvokeOnMainThread<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action,
																													T1 arg1,
																													T2 arg2,
																													T3 arg3,
																													T4 arg4,
																													T5 arg5,
																													T6 arg6,
																													T7 arg7,
																													T8 arg8,
																													T9 arg9,
																													T10 arg10,
																													T11 arg11,
																													T12 arg12,
																													T13 arg13,
																													T14 arg14,
																													T15 arg15,
																													T16 arg16) =>
		Callable.From(() => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16)).CallDeferred();

}