using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LocalPlayerCreateGO : NetworkBehaviour {
	public GameObject gvrPrefab;
	
	// Update is called once per frame
	void Start () {
		if(isLocalPlayer){
			Destroy(this);
			return;
		}
		GameObject.Instantiate(gvrPrefab);
	}
}
