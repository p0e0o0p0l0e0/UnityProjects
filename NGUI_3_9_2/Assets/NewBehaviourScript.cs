using UnityEngine;
using System.Collections;
using System;

public class NewBehaviourScript : MonoBehaviour {

	Stack _stack = new Stack();

	// Use this for initialization
	void Start () {
		_stack.Push(1);
		_stack.Push(2);

		object[] s = _stack.ToArray();

		for(int i = 0; i < s.Length; i++)
		{
			Debug.Log(s[i]);
		}
	}
}
