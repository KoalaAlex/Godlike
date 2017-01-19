using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class movementVRNetwork : NetworkBehaviour {

	private GameObject player;
	private float currentSpeed;

	// Eigenständige Fortbewegung
	public bool autoMovement;

	// Normale Geschwindigkeit
	public float regularSpeed = 10.0f;
	// Geschwindigkeit bei Boost
	public float boostSpeed = 50.0f;

	// Winkel für Tilt-Event
	public float tiltAngle = 0.5f;

	// DoubleClick Detection
	private float lastClickTime = 0.0f;
	public float catchTime = 0.25f;


	// Shake Detection Updateinterval
	float accelerometerUpdateInterval = 1.0f / 60.0f;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds = 1.0f;
	// This next parameter is initialized to 2.0 per Apple's recommendation
	float shakeDetectionThreshold = 2.0f;
	//  Filtervariablen
	private float lowPassFilterFactor;
	private Vector3 lowPassValue = Vector3.zero;
	private Vector3 acceleration;
	private Vector3 deltaAcceleration;


	// Lookwalk
	public bool lookWalk;
	public float walk_angle = 30.0f;
	private Transform vr_camera_transform;
	private bool walk_forward;
	private CharacterController cc;



	// Use this for initialization
	void Start () {
		if(!isLocalPlayer){
			return;
		}
		cc = GetComponent<CharacterController>();
		vr_camera_transform = Camera.main.transform;
		currentSpeed = regularSpeed;
		player = GameObject.FindGameObjectWithTag("Player");

		//Shake
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;

	}

	
	// Update is called once per frame
	void Update () {
	
		if(!isLocalPlayer){
			return;
		}
		acceleration = Input.acceleration;

		// Automovement in Blickrichtung
		// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

		// Eigenständige Bewegung nach vorne mit regulärer Geschwindigkeit
		if(autoMovement)
		transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Camera.main.transform);




		// Automovement in Blickrichtung
		// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

		// Cardboard Rotation der Kamera checke
		if( lookWalk && vr_camera_transform.eulerAngles.x >= walk_angle && vr_camera_transform.eulerAngles.x < 90.0f){

			walk_forward = true;

		} else {

			walk_forward = false;
		}


		/*
		// Gear VR Version: Über Abfrage von InputTracking
		// Bitte "using UnityEngine.VR;" bei Verwendung in den Head einbinden
		//

		if( lookWalk && InputTracking.GetLocalRotation(VRNode.Head).eulerAngles.x >= walk_angle &&
			InputTracking.GetLocalRotation(VRNode.Head).eulerAngles.x < 90.0f){

			walk_forward = true;

		} else {

			walk_forward = false;
		}// Gear VR */



		// Lookwalk aktiv. User schaut nach unten, also laufen...
		if(lookWalk && walk_forward){

			Vector3 forward = vr_camera_transform.TransformDirection(Vector3.forward);
			cc.SimpleMove(forward * regularSpeed);

		}




		// Doppelclick
		// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

		if(Input.GetButtonDown("Fire1")){
			
			if(Time.time-lastClickTime<catchTime){
				//double click
				Debug.Log("Doubleclick event "+Time.time);

				// Aktuell wird bei Doppelklick die Boostr-Geschwindigekti angenommen
				if(currentSpeed != boostSpeed){
					currentSpeed = boostSpeed;
				}else{
					currentSpeed = regularSpeed;
				}

			}else{
				//normal click

			}
			lastClickTime = Time.time;
		}


		// Shake Detection
		// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

		#if UNITY_EDITOR
		// Shake ist im Unity-Editor nicht möglich, wird aber aktuell mit Jump/Space simuliert
		if(Input.GetButtonDown("Jump")){
	
			// Fake-Shake Event
			Debug.Log("Fake-Shake event detected at time "+Time.time);

		}
		#endif

		// Shake Detection auf dem Smartphone
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;

		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold){
			
			// Perform your "shaking actions" here, with suitable guards in the if check above, if necessary to not, to not fire again if they're already being performed.
			Debug.Log("Shake event detected at time "+Time.time);

		}


		// Tilt Detection
		// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


		if( Input.acceleration.x > tiltAngle){
			
			// Tilt Event
			Debug.Log(" Tilt-Left detected at time " + Time.time);

		} else if (Input.acceleration.x <= -tiltAngle){
			
			// Tilt Event
			Debug.Log(" Tilt-Right detected at time " + Time.time);
		}





	} // Ende Update


}
