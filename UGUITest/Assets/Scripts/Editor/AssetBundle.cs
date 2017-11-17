using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class AssetBundle
{
	[MenuItem ("MyMenu/Bundle/Build Assetbundle")]
	static private void BuildAssetBundle()
	{
		string outputdir = Application.dataPath + "/StreamingAssets";

		if(!Directory.Exists(outputdir))
		{
			Directory.CreateDirectory(outputdir);
		}

		DirectoryInfo rootDirInfo = new DirectoryInfo (Application.dataPath + "/Atlas");
		foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
			List<Sprite> assets = new List<Sprite>();

			foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories)) 
			{
				string allPath = pngFile.FullName;
				string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
				assets.Add(AssetDatabase.LoadAssetAtPath<Sprite>(assetPath));
			}

			AssetBundleBuild[] buildMap  = new AssetBundleBuild[1];

			buildMap[0].assetBundleName = dirInfo.Name + "bundle"; // 任意名称 
			string[] spriteNames = new string[assets.Count];
			for(int i = 0; i < assets.Count; i++)
			{
				spriteNames[i] = "Assets/Atlas/" + dirInfo.Name + "/" + assets[i].name + ".png"; // 注意路径写全 
			}
			buildMap[0].assetNames = spriteNames;

			BuildPipeline.BuildAssetBundles(
				outputdir,  // output path
				buildMap,  // build bundles info
				BuildAssetBundleOptions.UncompressedAssetBundle,  // options
				GetBuildTarget()); // build target
		}	
	}

	[MenuItem ("MyMenu/Bundle/Build All AssetBundles")]
	static private void BuildAllAssetBundles()
	{
		BuildPipeline.BuildAssetBundles(
			Application.dataPath + "/StreamingAssets",  // output path
			BuildAssetBundleOptions.ChunkBasedCompression,  // options
			GetBuildTarget()); 
	}

	[MenuItem ("MyMenu/Bundle/Rebuild All AssetBundles")]
	static private void RebuildAllAssetBundles()
	{
		BuildPipeline.BuildAssetBundles(
			Application.dataPath + "/StreamingAssets",  // output path
			BuildAssetBundleOptions.ChunkBasedCompression |
			BuildAssetBundleOptions.ForceRebuildAssetBundle,  // options
			GetBuildTarget()); 
	}

	[MenuItem("MyMenu/Bundle/Get AssetBundle names")]
	static void GetNames()
	{
		var names = AssetDatabase.GetAllAssetBundleNames();
		foreach (var name in names)
			Debug.Log("AssetBundle: " + name);
	}

	static private BuildTarget GetBuildTarget()
	{
		BuildTarget target = BuildTarget.WebPlayer;
		#if UNITY_STANDALONE
		target = BuildTarget.StandaloneOSXIntel64;
		#elif UNITY_IPHONE
		target = BuildTarget.iPhone;
		#elif UNITY_ANDROID
		target = BuildTarget.Android;
		#endif
		return target;
	}
}

public class MyPostprocessor : AssetPostprocessor
{
	
	void OnPostprocessAssetbundleNameChanged(string path, string previous, string next)
	{
		Debug.Log("AB: " + path + " old: " + previous + " new: " + next);
	}
}