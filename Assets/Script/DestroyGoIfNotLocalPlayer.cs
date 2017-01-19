using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DestroyGoIfNotLocalPlayer : NetworkBehaviour {
	public GameObject[] gosToDestroy;
	public Component[] compToDestroy;
	
	// Update is called once per frame
	void Start () {
		if(isLocalPlayer){
			Destroy(this);
			return;
		}
		for (int i = 0; i < compToDestroy.Length; i++) {
			Destroy(compToDestroy[i]);
		}
		for (int i = 0; i < gosToDestroy.Length; i++) {
			Destroy(gosToDestroy[i]);
		}
		Destroy(this);
	}
}
