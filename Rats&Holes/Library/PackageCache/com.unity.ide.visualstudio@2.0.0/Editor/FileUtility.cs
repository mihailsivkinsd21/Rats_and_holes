/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Unity Technologies.
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Microsoft.Unity.VisualStudio.Editor
{
	internal static class FileUtility
	{
		public const char WinSeparator = '\\';
		public const char UnixSeparator = '/';

		// Safe for packages as we use packageInfo.resolvedPath, so this should work in library package cache as well
		public static string[] FindPackageAssetFullPath(string assetfilter, string filefilter)
		{
			return AssetDatabase.FindAssets(assetfilter)
				.Select(AssetDatabase.GUIDToAssetPath)
				.Where(assetPath => assetPath.Contains(filefilter))
				.Select(asset =>
				 {
					 var packageInfo = UnityEditor.PackageManager.PackageInfo.FindForAssetPath(asset);
					 return Normalize(packageInfo.resolvedPath + asset.Substring(packageInfo.assetPath.Length));
				 })
				.ToArray();
		}

		public static string GetAssetFullPath(string asset)
		{
			var basePath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
			return Path.GetFullPath(Path.Combine(basePath, Normalize(asset)));
		}

		public static string Normalize(string path)
		{
			if (string.IsNullOrEmpty(path))
				return path;

			if (Path.DirectorySeparatorChar == WinSeparator)
				path = path.Replace(UnixSeparator, WinSeparator);

			return path.Replace(string.Concat(WinSeparator, WinSeparator), WinSeparator.ToString());
		}

		internal static bool IsFileInProjectDirectory(string fileName)
		{
			var basePath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
			fileName = Normalize(fileName);

			if (!Path.IsPathRooted(fileName))
				fileName = Path.Combine(basePath, fileName);

			return string.Equals(Path.GetDirectoryName(fileName), basePath, StringComparison.OrdinalIgnoreCase);
		}

		public static string FileNameWithoutExtension(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return "";
			}

			var indexOfDot = -1;
			var indexOfSlash = 0;
			for (var i = path.Length - 1; i >= 0; i--)
			{
				if (indexOfDot == -1 && path[i] == '.')
				{
					indexOfDot = i;
				}

				if (indexOfSlash == 0 && path[i] == '/' || path[i] == '\\')
				{
					indexOfSlash = i + 1;
					break;
				}
			}

			if (indexOfDot == -1)
			{
				indexOfDot = path.Length - 1;
			}

			return path.Substring(indexOfSlash, indexOfDot - indexOfSlash);
		}
	}
}