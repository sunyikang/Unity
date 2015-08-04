using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundVolume_Control : MonoBehaviour {
	

	public  Slider   _vfxVolume;
	public  Slider   _globalVolume;
	AudioCtrl _audioCtrl;


	void Awake(){
		_audioCtrl=AudioCtrl.Instance;
		//_audioCtrl._globalVolume=this._globalVolume;
		//_audioCtrl._vfxVolume=this._vfxVolume;
	}
	void Start () {

		this._globalVolume.value=_audioCtrl.globalVolume;
		this._vfxVolume.value=_audioCtrl.vfxVolume;
	}
	public void ThisSetGlobalVolume () {

		_audioCtrl.globalVolume=this._globalVolume.value;
		_audioCtrl.vfxVolume=this._vfxVolume.value;
		_audioCtrl.SetGlobalVolume();
	}


}
