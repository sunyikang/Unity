using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
	public int Speed;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (h, 0.0f, v);
		rb.AddForce (movement * Speed);
	}
}
