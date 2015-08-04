using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	bool movmentTest=false ;
	float timer=0f;
	Color _color;

	// Use this for initialization
	void Start () {
		_color=this.renderer.material.color;
		_color.a=0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (movmentTest==true){
			timer=timer+Time.deltaTime;
			MovmentTest();
		}
		if (timer >=3){
			movmentTest=false;
		}
	}
	void ShowIn(){

		_color=this.renderer.material.color;
		_color.a=0.5f;

	}
	void MovmentTest (){
		movmentTest=true;
		this.transform.Rotate(Vector3.up*3);

	}
}
