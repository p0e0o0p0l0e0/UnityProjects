using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ScriptControl : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		EventTrigger trigger = transform.gameObject.GetComponent<EventTrigger>();
		if (trigger == null)
			trigger = transform.gameObject.AddComponent<EventTrigger>();
		//定义所要绑定的事件类型
		EventTrigger.Entry entry = new EventTrigger.Entry();
		//设置事件类型
		entry.eventID = EventTriggerType.PointerClick;
		//设置回调函数：注意这个callback是从EventTrigger的OnPointerClick里执行的，因此如果此类重写了OnPointerClick则不会执行。
		entry.callback.AddListener(new UnityAction<BaseEventData>(OnScriptControl));
		//添加事件触发记录到GameObject的事件触发组件
		trigger.triggers.Add(entry);
	}

	public void OnScriptControl(BaseEventData arg0)
	{
		Debug.Log("Cube Test Click");
	}
}