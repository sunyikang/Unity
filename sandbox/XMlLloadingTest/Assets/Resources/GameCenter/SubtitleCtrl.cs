using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

using System.Collections.Generic;

using System.Xml;

public class SubtitleCtrl : MonoBehaviour {
	TextAsset textFile;
	public Text _dialogueText;
	public Text _dialogueName;
	public string path;
	XmlDocument xmlDoc= new XmlDocument();
	XmlReaderSettings setting= new XmlReaderSettings();

	List<XmlNode> y=new List<XmlNode>();
	List<XmlNodeList> nodes=new List<XmlNodeList>();
	List<SubtitleModel> subtitleModel = new List<SubtitleModel>();
	int currentSubtitleID;
	int nextSubtitleID;
	MissionContent _missionContent;
/*	XmlNode GetFirstChild(XmlDocument n){
		XmlNode x=n.FirstChild;
		while (x.NodeType!=XmlNodeType.Element){

			x=x.NextSibling;
		}
		return x;
	}
	*/
	void MovmentTest(){
		Debug.Log("hahaha xml executed the action");
	}
	void SubtitlePlay(int _id){
		currentSubtitleID=_id;
		_dialogueName.text=subtitleModel[_id].Name;
		_dialogueText.text=subtitleModel[_id].Content;
		if (subtitleModel[_id].ActionTarget!=null){

			Debug.Log(_missionContent.GetType());
			Debug.Log(subtitleModel[_id].ActionTarget);
		GameObject.Find(subtitleModel[_id].ActionTarget).SendMessage(subtitleModel[_id].Action);
		}else  {

		SendMessage(subtitleModel[_id].Action,SendMessageOptions.DontRequireReceiver);
		}
		if(_id<subtitleModel.Count-1){
			nextSubtitleID=currentSubtitleID+1;
		}else{
			nextSubtitleID=_id;
			_dialogueName.text="";
			_dialogueText.text="sir,report finished";
			//StartCoroutine(WaitForSubtitleOff(1.5f));
		}
		if(subtitleModel[_id].AutoOff==true){
		StartCoroutine(WaitForSubtitleOff(subtitleModel[_id].PlayTime));
		}
		if(subtitleModel[_id].AutoPlay==true){
		StartCoroutine(WaitForPlayNext(subtitleModel[_id].PlayTime));
		}

	}
	void SubtitleOff(){
		_dialogueName.text="";
		_dialogueText.text="";
	}
	
	IEnumerator WaitForPlayNext(float time){
		yield return new WaitForSeconds(time);
		SubtitlePlay(nextSubtitleID);
		Debug.Log ("WaitForPlayNext "+currentSubtitleID);
	}

	IEnumerator WaitForSubtitleOff(float time){
		yield return new WaitForSeconds(time);
		Debug.Log ("WaitForSubtitleOff "+currentSubtitleID);
		SubtitleOff();
	}
	void SubtitleInitialize(string _path){
		setting.IgnoreComments=true;
		setting.IgnoreProcessingInstructions=true;
		//setting.IgnoreWhitespace=true;
		textFile =(TextAsset)Resources.Load(_path);
		xmlDoc.LoadXml(textFile.text);
		XmlNode root =xmlDoc.DocumentElement;
		XmlNodeList x=root.ChildNodes;
		
		for(int i=0; i<x.Count;i++){
			SubtitleModel model= new SubtitleModel();		
			model.Name=x[i].Attributes["name"].Value;
			string a=x[i].FirstChild.InnerText;
			model.PlayTime=float.Parse(a);
			model.Content=x[i].FirstChild.NextSibling.InnerText;
		
			model.AutoOff=	Boolean.Parse(x[i].Attributes["AutoOff"].Value);
			model.AutoPlay=	Boolean.Parse(x[i].Attributes["AutoPlay"].Value);
			model.Action=x[i].FirstChild.NextSibling.NextSibling.InnerText;
			if (x[i].FirstChild.NextSibling.NextSibling.Attributes["object"]!=null){
			model.ActionTarget=x[i].FirstChild.NextSibling.NextSibling.Attributes["object"].Value;
			}else {

				model.ActionTarget=null;
			}
			//model.AutoOff=x[i].Attributes["AutoOff"].Value;
			subtitleModel.Add(model);
			//y.Add (x[i]); //将XMLmodelslist 对象转换为xmlnodes的list对象
		}
	}
	void Awake(){
		path="others/subtitle_A";
		SubtitleInitialize(path);
	    
		SubtitlePlay(currentSubtitleID);
		_missionContent=MissionContent.Instance;
		}
	void Update(){
		if (Input.GetKeyDown(KeyCode.Tab)){
		
			SubtitlePlay(nextSubtitleID);
		}
	}
}
