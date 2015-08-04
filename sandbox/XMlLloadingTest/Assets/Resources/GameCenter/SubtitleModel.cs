using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class SubtitleModel {
	public  SubtitleModel()
	{}

	private  string  name ;
	public   string Name {
		get {return name;}
		set {name=value;}
	}

	private  float  playTime ;
	public   float PlayTime {
		get {return playTime;}
		set {playTime=value;}
		}

	private  string  content ;
	public   string  Content {
		get {return content;}
		set {content=value;}
	}

	private  bool  autoOff ;
	public   bool  AutoOff {
		get {return autoOff;}
		set {autoOff=value;}
	}

	private  bool  autoPlay ;
	public   bool  AutoPlay {
		get {return autoPlay;}
		set {autoPlay=value;}
	}
	private  string  action ;
	public   string  Action {
		get {return action;}
		set {action=value;}
	}

	private string actionTarget;
	public  string ActionTarget{
		get {return actionTarget;}
		set {actionTarget=value;}

	}

}



