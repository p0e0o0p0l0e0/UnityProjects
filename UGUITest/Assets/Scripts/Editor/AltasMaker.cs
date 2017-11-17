using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class AltasMaker
{
	[MenuItem ("MyMenu/1 AtlasMaker")]
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
}
