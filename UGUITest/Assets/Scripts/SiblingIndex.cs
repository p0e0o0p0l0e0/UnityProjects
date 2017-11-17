using UnityEngine;
using System.Collections;

public class SiblingIndex : MonoBehaviour {

	public Transform transA;
	public Transform transB;

	void ShowSiblingIndex ()
	{
		if(transA != null && transB != null)
		{
			Debug.Log("A index : " + transA.GetSiblingIndex() + ", B index : " + transB.GetSiblingIndex() );
		}
	}

	void Reposition ()
	{
		if(transA != null)
		{
			transA.SetSiblingIndex(0);
			ShowSiblingIndex();
		}
	}

	void OnGUI ()
	{
		if(GUI.Button(new Rect(0, 0, 100, 100), "show"))
		{
			ShowSiblingIndex();
		}
		if(GUI.Button(new Rect(0, 200, 100, 100), "reposition"))
		{
			Reposition();
		}
	}
}
