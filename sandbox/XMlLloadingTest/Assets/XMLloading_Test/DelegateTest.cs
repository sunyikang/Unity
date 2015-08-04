using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

using System.Collections.Generic;

using System.Xml;

public class DelegateTest : MonoBehaviour {
	MissionContent _missionContent;
	string a="test";
	string b="bbb";
	int c =2;
	void Awake(){
		_missionContent=MissionContent.Instance;
	}

	void Start () {
		if(_missionContent.actionDictionary.ContainsKey(a)){
		_missionContent.actionDictionary[a](b);

		}else {
			Debug.Log ("no such function in dictionary");
			return;
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
