using UnityEngine;
using System.Collections;

public class rotationScript : MonoBehaviour {

	public float speed = 15.0F;
	public bool RotateUp;
	public bool RotateDown;
	public bool RotateLeft;
	public bool RotateRight;
	public bool RotateForward;
	public bool RotateBack;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(RotateUp)
			transform.Rotate (Vector3.up * speed * Time.deltaTime);
		if(RotateDown)
			transform.Rotate (Vector3.down * speed * Time.deltaTime);
		
		if(RotateLeft)
			transform.Rotate (Vector3.left * speed * Time.deltaTime);
		if(RotateRight)
			transform.Rotate (Vector3.right * speed * Time.deltaTime);
		
		if(RotateForward)
			transform.Rotate (Vector3.forward* speed * Time.deltaTime);
		if(RotateBack)
			transform.Rotate (Vector3.back* speed * Time.deltaTime);
	
	}
}
