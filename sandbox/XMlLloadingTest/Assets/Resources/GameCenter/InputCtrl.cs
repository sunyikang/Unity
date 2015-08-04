using UnityEngine;
using System.Collections;

public class InputCtrl : Singleton<InputCtrl> {
	public CanvasGroup _UIMenu;
	public int  paused;
	GameObject[] _FPSCamera;
	MonoBehaviour[] _blurScripts;
	void Start(){
		paused=-1;
		_UIMenu.alpha=-1;
		_FPSCamera=GameObject.FindGameObjectsWithTag("MainCamera");
		_blurScripts= new MonoBehaviour[_FPSCamera.Length];

	}
	void BlurBG(){

		for (int i=0;i<_FPSCamera.Length;i++){
			_blurScripts[i]=_FPSCamera[i].GetComponent<BlurEffect>();
			if(_blurScripts[i]){
			_blurScripts[i].enabled=paused>0? true :false;
				//Debug.Log (_blurScripts[i].enabled);
			}

		}

	}
	public void ShowUI(char _menu){
		switch(_menu){
		case 'A':
			break;
		case 'B':
			break;
		case 'C':
			break;
		}
	}
	public void PausGame(){
		paused=paused*-1;
		_UIMenu.alpha=_UIMenu.alpha*-1;
		GameObject[] _player= GameObject.FindGameObjectsWithTag("Player");
		MonoBehaviour[][] _scripts=new MonoBehaviour[_player.Length][];
		for (int i=0;i<_player.Length;i++){	
			_scripts[i]=_player[i].GetComponents<MonoBehaviour>();	
		}
		//Debug.Log ("Array test :"+"X:"+_scripts[0].Length+"    "+"y:"+_scripts[1].Length);
		BlurBG();
		if(paused>0){
		Time.timeScale=0;

			for(int i=0;i<_player.Length;i++){
				for(int j=0;j<_scripts[i].Length;j++){
					_scripts[i][j].enabled=false;
				}
			}
		}else{
		Time.timeScale=1;
			for(int i=0;i<_player.Length;i++){
				for(int j=0;j<_scripts[i].Length;j++){
					_scripts[i][j].enabled=true;
					}
				}
			}

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			PausGame();
			ShowUI('A');
		}
		if (Input.GetKeyDown(KeyCode.Tab)){

		}
	}
}
