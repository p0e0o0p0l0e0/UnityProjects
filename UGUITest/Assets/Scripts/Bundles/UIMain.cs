#define USE_ASSETBUNDLE

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.VersionControl;

public class UIMain : MonoBehaviour{

	AssetBundle assetbundle = null;
	void Start () 
	{
		CreatImage(loadSprite("flag_blue"));
		CreatImage(loadSprite("flag_yellow"));
	}

	private void CreatImage(GameObject gobj ){
		Sprite sprite = gobj.GetComponent<SpriteRenderer>().sprite as Sprite;
		GameObject go = new GameObject(sprite.name);
		go.layer = LayerMask.NameToLayer("UI");
		go.transform.parent = transform;
		go.transform.localScale = Vector3.one;
		Image image = go.AddComponent<Image>();
		image.sprite = sprite;
		image.SetNativeSize();
	}

	private GameObject loadSprite(string spriteName){
		#if USE_ASSETBUNDLE
		if(assetbundle == null)
			assetbundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath +"/flagbundle");
		return assetbundle.LoadAsset(spriteName) as GameObject;
		#else
		return Resources.Load<GameObject>("Sprite/" + spriteName);
		#endif	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0, 0, 100, 100), "unload false"))
		{
			if(assetbundle != null)
				assetbundle.Unload(false);
		}
		else if(GUI.Button(new Rect(0, 150, 100, 100), "unload true"))
		{
			if(assetbundle != null)
				assetbundle.Unload(true);
		}
	}
}