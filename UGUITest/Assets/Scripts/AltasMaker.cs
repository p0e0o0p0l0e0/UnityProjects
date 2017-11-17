using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEditor.VersionControl;

public class AltasMaker : MonoBehaviour {

	[MenuItem ("MyMenu/AtlasMaker")]
	static private void MakeAtlas()
	{
		string spriteDir = Application.dataPath + "/Resources/Sprite";
		Debug.Log("spriteDir : " + spriteDir);
		if(!Directory.Exists(spriteDir)){
			Directory.CreateDirectory(spriteDir);
		}
		
		DirectoryInfo rootDirInfo = new DirectoryInfo (Application.dataPath + "/Atlas");
		foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
			foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories)) {
				string allPath = pngFile.FullName;
				Debug.Log("allPath1 : " + allPath);
				string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
				Debug.Log("assetPath : " + assetPath);
				Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
				GameObject go = new GameObject(sprite.name);
				go.AddComponent<SpriteRenderer>().sprite = sprite;
				allPath = spriteDir+ "/" +sprite.name+ ".prefab";
				Debug.Log("allPath2 : " + allPath);
				string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
				PrefabUtility.CreatePrefab(prefabPath, go);
				GameObject.DestroyImmediate(go);
			}
		}	
	}

	[MenuItem ("MyMenu/Build Assetbundle")]
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

	[MenuItem ("MyMenu/Build All AssetBundles")]
	static private void BuildAllAssetBundles()
	{
		BuildPipeline.BuildAssetBundles(
			Application.dataPath + "/StreamingAssets",  // output path
			BuildAssetBundleOptions.ChunkBasedCompression,  // options
			GetBuildTarget()); 
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
