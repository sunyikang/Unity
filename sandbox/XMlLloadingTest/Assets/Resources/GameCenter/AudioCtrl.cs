using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioCtrl : Singleton<AudioCtrl> {

	// Use this for initialization
	public float vfxVolume=1f ;
	public float globalVolume=1f;
	private float audioclipLenth;
	public 	AudioSource[] backGroundAudio = new AudioSource[4] ;

	public  AudioClip[]   musicClips;
	private  AudioSource[] AudioSourceObjPlayer  ;
	private  AudioSource[] AudioCtrlObjPlayer ;
	//public  Slider   _vfxVolume;
	//public  Slider   _globalVolume;
	GameObject[] _audioSourceObjects;

	void Start(){

		 _audioSourceObjects=GameObject.FindGameObjectsWithTag("AudioSourceObj");
		BGInitialize();

	}


	public void  BGInitialize(){
		AudioSourceObjPlayer=new AudioSource[_audioSourceObjects.Length];
		musicClips=new AudioClip[_audioSourceObjects.Length];
		for(int i=0;i<_audioSourceObjects.Length;i++){

		     AudioSourceObjPlayer[i]=_audioSourceObjects[i].GetComponent<AudioSource>();
			if ( AudioSourceObjPlayer[i]){
			 AudioSourceObjPlayer[i].playOnAwake=false;
				//Debug.Log ("volume"+i+"=="+AudioSourceObjPlayer[i].volume);
			}
		}
		for (int i=0;i<_audioSourceObjects.Length;i++){
			musicClips[i]=Resources.Load("Sound/GameSounds/"+_audioSourceObjects[i].name) as AudioClip;
			PlayAudio(true,musicClips[i],_audioSourceObjects[i].transform.position,AudioSourceObjPlayer[i].volume,1f,AudioSourceObjPlayer[i].minDistance,
			          AudioSourceObjPlayer[i].maxDistance,AudioSourceObjPlayer[i].loop);
		}
	}
	public void SetGlobalVolume(){
		GameObject[] _audioCtrlObjs=GameObject.FindGameObjectsWithTag("AudioCtrlObj");
		AudioCtrlObjPlayer=new AudioSource[_audioCtrlObjs.Length];

		for(int i=0;i<_audioCtrlObjs.Length;i++){
			AudioCtrlObjPlayer[i]=_audioCtrlObjs[i].GetComponent<AudioSource>();
			AudioCtrlObjPlayer[i].volume=globalVolume;
		}
	}
	public void SetSingleVolume(string music,float newVolume){
		GameObject muiscObj = GameObject.Find("Audio:"+music);
		muiscObj.GetComponent<AudioSource>().volume=newVolume;
	}


	public void PlayAudio(bool forever,AudioClip clip, Transform emitter, float fvolume, float pitch,float minDistance,float maxDistance,bool loop) 
	{ 
		//Create an empty game object 
	
		GameObject go = new GameObject ("Audio: " +  clip.name); 
		if(forever){
			DontDestroyOnLoad(go);

		}
		go.transform.position = emitter.position; 
		go.transform.parent = emitter; 
		go.tag="AudioCtrlObj";
		
		//Create the source 
		AudioSource source = go.AddComponent<AudioSource>(); 
		source.playOnAwake=false;
		source.clip = clip; 
		source.volume=fvolume;
		//source.volume = fvolume; 
	//	Debug.Log("fvolum"+fvolume+"sourceVolume"+source.volume+"pitch=="+source.pitch);
		source.minDistance=minDistance;
		source.maxDistance=maxDistance;
		source.pitch = pitch; 
		source.GetComponent<AudioSource>().loop=loop;
		source.Play (); 
		if(!loop){
		Destroy (go, clip.length); 
		}

		//return source; 
	} 
	public void PlayAudio(bool forever,AudioClip clip, Vector3 point, float fvolume, float pitch,float minDistance,float maxDistance,bool loop) 
	{  
		//Create an empty game object 
		GameObject go = new GameObject("Audio: " + clip.name); 
		if(forever){
			DontDestroyOnLoad(go);
			
		}
		go.transform.position = point; 
		go.tag="AudioCtrlObj";
		//Create the source 
		AudioSource source = go.AddComponent<AudioSource>(); 
		source.playOnAwake=false;
		source.clip = clip; 
		source.volume=fvolume;
		//source.volume 
//		Debug.Log("fvolum"+fvolume+"sourceVolume"+source.volume+"pitch=="+source.pitch);
		source.minDistance=minDistance;
		source.maxDistance=maxDistance;
		source.pitch = pitch; 
		source.GetComponent<AudioSource>().loop=loop;
		source.Play(); 
		if(!loop){
		Destroy(go, clip.length); 
		}
		//return source; 

	} 

}
