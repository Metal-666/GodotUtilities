using Godot;

using System.Collections.Generic;
using System.Linq;

namespace Metal666.GodotUtilities.Extensions;

public static class Controls {

	public static float ValueF(this Range range) =>
		(float) range.Value;

	public static int ValueI(this Range range) =>
		Math.RoundToInt(range.Value);

	public static void SetColumn(this Godot.Tree tree,
									int index,
									TreeColumnData treeColumnData) {

		if(treeColumnData.ClipContent.HasValue) {

			tree.SetColumnClipContent(index,
										treeColumnData.ClipContent.Value);

		}

		if(treeColumnData.CustomMinimumWidth.HasValue) {

			tree.SetColumnCustomMinimumWidth(index,
												treeColumnData.CustomMinimumWidth.Value);

		}

		if(treeColumnData.Expand.HasValue) {

			tree.SetColumnExpand(index,
									treeColumnData.Expand.Value);

		}

		if(treeColumnData.ExpandRatio.HasValue) {

			tree.SetColumnExpandRatio(index,
										treeColumnData.ExpandRatio.Value);

		}

		if(treeColumnData.Title != null) {

			tree.SetColumnTitle(index,
								treeColumnData.Title);

		}

		if(treeColumnData.TitleAlignment.HasValue) {

			tree.SetColumnTitleAlignment(index,
											treeColumnData.TitleAlignment.Value);

		}

		if(treeColumnData.TitleDirection.HasValue) {

			tree.SetColumnTitleDirection(index,
											treeColumnData.TitleDirection.Value);

		}

		if(treeColumnData.TitleLanguage != null) {

			tree.SetColumnTitleLanguage(index,
										treeColumnData.TitleLanguage);

		}

	}

	public static void SetColumns(this Godot.Tree tree,
									IEnumerable<TreeColumnData> treeColumnDatas) {

		foreach((TreeColumnData Column, int Index) in
					treeColumnDatas.Select((column, index) =>
													(column, index))) {

			SetColumn(tree, Index, Column);

		}

	}

	public record TreeColumnData(bool? ClipContent = null,
									int? CustomMinimumWidth = null,
									bool? Expand = null,
									int? ExpandRatio = null,
									string? Title = null,
									HorizontalAlignment? TitleAlignment = null,
									Control.TextDirection? TitleDirection = null,
									string? TitleLanguage = null);

}