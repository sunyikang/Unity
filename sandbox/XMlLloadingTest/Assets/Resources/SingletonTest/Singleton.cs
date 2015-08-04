using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour 
	where T : Component
{	private static T _instance;
	
	// Use this for initialization
	public static  T Instance {
		
		
		get {
			if (_instance==null ){
				var type = typeof(T);
				var obj= FindObjectsOfType<T>();
				if (obj.Length>0){
					_instance= obj[0];
					for(int i=1;i<obj.Length;i++){
						DestroyImmediate( obj[i]);
					}
					return _instance;
				}
				GameObject ctrlObj= new GameObject();
				ctrlObj.name=type.ToString();
				_instance= ctrlObj.AddComponent<T>();

			}
			return _instance;
		}
	}
	public virtual void Awake(){
		
		if(_instance==null ){
			
			_instance=this as T;
			DontDestroyOnLoad(this.gameObject);
		}else{
			Destroy(this.gameObject);
			
		}
		
	}
	
	
}
