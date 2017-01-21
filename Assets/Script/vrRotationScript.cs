using UnityEngine;
using System.Collections;

public class vrRotationScript : MonoBehaviour {

	public float rotationSensitivity = 100.0f;
	public float colliderAngle = 60.0f;
	public LayerMask raycastLayer;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	public GameObject player;
	public GameObject cockpit;
	private GameObject rotationHelper;
	private GameObject triggerLeft;
	private GameObject triggerRight;

	private BoxCollider box;
	private Vector3 fwd;
	private Vector3 rot;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
		// Dieses Script verwendet 2 Trigger, jeweils Links und rechts vom Blickwinkel
		// Beim Start werden diese 2 Trigger erzuegt und dem Cockpit zugewiesen

		// Aktuelle Rotation vom Spieler 
		rot = player.transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;

		// Objecte erzeugen
		rotationHelper = new GameObject("rotationHelper");
		triggerLeft = new GameObject("triggerLeft");
		triggerRight = new GameObject("triggerRight");

		// Layer zuweisen
		triggerLeft.layer = 9;
		triggerRight.layer = 9;

		// Das Ganze parenten
		rotationHelper.transform.parent = cockpit.transform;
		triggerLeft.transform.parent = rotationHelper.transform;
		triggerRight.transform.parent = rotationHelper.transform;

		// Position & Rotation
		triggerLeft.transform.position = new Vector3(-1.0f,0,1.0f);
		triggerLeft.transform.Rotate(0,-colliderAngle,0);

		triggerRight.transform.position = new Vector3(1.0f,0,1.0f);
		triggerRight.transform.Rotate(0,colliderAngle,0);

		// Box-Collider adden
		triggerLeft.AddComponent<BoxCollider>();
		triggerRight.AddComponent<BoxCollider>();

		// Box-Collider Größe anpassen
		box = triggerLeft.GetComponent<BoxCollider>();
		box.size = new Vector3(1.0f,1.0f,0.05f);
		box = triggerRight.GetComponent<BoxCollider>();
		box.size = new Vector3(1.0f,1.0f,0.05f);



		/*
		// Spawn Collider Script
		//spawn object
		objToSpawn = new GameObject("Cool GameObject made from Code");
		//Add Components
		objToSpawn.AddComponent<Rigidbody>();
		objToSpawn.AddComponent<MeshFilter>();
		objToSpawn.AddComponent<BoxCollider>();
		objToSpawn.AddComponent<MeshRenderer>();

		*/




	}


	void FixedUpdate()
	{
		fwd = Camera.main.transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast(Camera.main.transform.position, fwd,  out hit, 2, raycastLayer)){
		//print("Found an object - distance: " + hit.distance);
		

			if(hit.collider.name == "triggerLeft"){

				//Rotation in negativer Y-Richtung
				rotY += -1.0f * rotationSensitivity * Time.deltaTime;
			}

			if(hit.collider.name == "triggerRight"){
				
				//Rotation in positiver Y-Richtung
				rotY += 1.0f * rotationSensitivity * Time.deltaTime;
			}


		// Rotation vom Spieler
		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		player.transform.rotation = localRotation;
		}



		
	


	}


}