using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

using System.Collections.Generic;

using System.Xml;

public class MissionContent: Singleton<MissionContent>  {

	//public delegate void   ActionDelegate<T>(T item );有错误

	//public  Dictionary <string ,ActionDelegate<T>> actionDictionary = new Dictionary <string,ActionDelegate<T>>();有错误

	public delegate void   ActionDelegate(string item );
	public  Dictionary <string ,ActionDelegate> actionDictionary = new Dictionary <string,ActionDelegate>();
	void Awake()  {
		//actionDictionary.Add("test",test);
		//actionDictionary.Add("haha",haha);
		actionDictionary["test"]=test;
		actionDictionary["haha"]=haha;
	}

	void Update () {
	}

	/*public void ShowIn_Obj(string obj){
		GameObject _Obj=Resources.Load("others/"+obj) as GameObject;
		_Obj.SendMessage("ShowIn");
	}*/
	public void test(string content ){
		Debug.Log ("content:"+content);
	}
	public void haha(string name){
		Debug.Log ("hahaa");
	}
}
