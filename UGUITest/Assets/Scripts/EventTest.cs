using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventTest : MonoBehaviour, IPointerClickHandler
{
	Transform button;
	Transform image;

	// Use this for initialization
	void Start ()
	{
		button = transform.Find("Button");
		image = transform.Find("Image");
		if(button != null)
		{
			EventTriggerListener.Get(button.gameObject).onClick = OnButtonClick;
		}
		if(image != null)
		{
			EventTriggerListener.Get(image.gameObject).onClick = OnButtonClick;
		}
	}

	private void OnButtonClick (GameObject go)
	{
		if(go == button.gameObject)
		{
			Debug.Log ("DoSomeThings");
		}
	}

	public void OnPointerClick(PointerEventData ped)
	{
		if(ped.pointerCurrentRaycast.gameObject.name == "Cube")
		{
			Debug.Log("Cube is clicked");
		}
	}
}
