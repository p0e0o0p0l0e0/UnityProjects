using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	void OnApplicationQuit ()
	{
		Caching.CleanCache();
	}
}
