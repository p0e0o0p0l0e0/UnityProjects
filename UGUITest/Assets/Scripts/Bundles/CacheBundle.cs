using System;
using UnityEngine;
using System.Collections;

public class CacheBundle : MonoBehaviour
{
	//根据平台，得到相应的路径
	public static string BundleURL = string.Empty;
	private string AssetName = "flag_green";

	//版本号
	public int version;

	void Start()
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
		StartCoroutine(DownloadAndCache());
	}

	IEnumerator DownloadAndCache()
	{
		// 需要等待缓存准备好
		while (!Caching.ready)
			yield return null;

		// 有相同版本号的AssetBundle就从缓存中获取，否则下载进缓存。
		using (WWW www = WWW.LoadFromCacheOrDownload(BundleURL, version))
		{
			yield return www;
			if (www.error != null)
				throw new Exception("WWW download had an error:" + www.error);
			AssetBundle bundle = www.assetBundle;
			GameObject go = Instantiate(bundle.LoadAsset(AssetName)) as GameObject;
			go.layer = LayerMask.NameToLayer("UI");
			go.transform.parent = transform;
			go.transform.position = new Vector3(1.5f, 0f, 0f);
			// 卸载加载完之后的AssetBundle，节省内存。
			bundle.Unload(false);

		} //由于使用using语法，www.Dispose将在加载完成后调用，释放内存
	}
}