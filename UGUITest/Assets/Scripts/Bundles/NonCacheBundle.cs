using System;
using UnityEngine;
using System.Collections;

class NonCacheBundle : MonoBehaviour
{
	//根据平台，得到相应的路径
	public static string BundleURL = string.Empty;
	private string AssetName = "flag_yellow";

	IEnumerator Start()
	{
		//根据平台，得到相应的路径
		BundleURL = 
			#if UNITY_ANDROID
			"jar:file://" + Application.dataPath + "!/assets/MyAssetBundles/flagbundle";
			#elif UNITY_IPHONE
			Application.dataPath + "/Raw/MyAssetBundles/flagbundle";
			#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
			"file://" + Application.streamingAssetsPath + "/flagbundle";//由于是编辑器下，我们使用这个路径。
			#else
			string.Empty;
			#endif

		yield return new WaitForSeconds(1f);

		// 从URL中下载文件，不会存储在缓存中。
		using (WWW www = new WWW(BundleURL))
		{
			yield return www;

			if (www.error != null)
				throw new Exception("WWW download had an error:" + www.error);
			AssetBundle bundle = www.assetBundle;
			GameObject go = Instantiate(bundle.LoadAsset(AssetName)) as GameObject;
			go.layer = LayerMask.NameToLayer("UI");
			go.transform.parent = transform;
			go.transform.position = new Vector3(0f, 0f, 0f);

			// 卸载加载完之后的AssetBundle，节省内存。
			bundle.Unload(false);

		}//由于使用using语法，www.Dispose将在加载完成后调用，释放内存
	}
}