using UnityEngine;
using System.Collections;

public class asteroidCreationScript : MonoBehaviour {

	public GameObject asteroidPrefab;
	public int count = 100;
	public float fieldRadius;
	public float sizeMin;
	public float sizeMax;
	public float movementSpeed;
	public float rotationSpeed;



	// Use this for initialization
	void Start () {
	
	
		for(int i = 0; i < count; ++i)
		{
			GameObject newAsteroid = (GameObject)Instantiate(asteroidPrefab, Random.insideUnitSphere * fieldRadius, Random.rotation);
			float size = Random.Range(sizeMin, sizeMax);
			newAsteroid.transform.localScale = Vector3.one * size;
			// if the asteroid has a rigidbody...
			newAsteroid.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * movementSpeed;
			newAsteroid.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationSpeed;
		}
	
	
	
	}//Start

}
