using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventTest : MonoBehaviour
{
	Button	button;
	Image image;

	// Use this for initialization
	void Start ()
	{
		button = transform.Find("Button").GetComponent<Button>();
		image = transform.Find("Image").GetComponent<Image>();
		EventTriggerListener.Get(button.gameObject).onClick = OnButtonClick;
		EventTriggerListener.Get(image.gameObject).onClick = OnButtonClick;
	}

	private void OnButtonClick (GameObject go)
	{
		if(go == button.gameObject)
		{
			Debug.Log ("DoSomeThings");
		}
	}
}
