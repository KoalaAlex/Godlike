using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class infinityStarsNetwork : NetworkBehaviour {

	private Transform tx;
	private ParticleSystem.Particle[] points;
	private float starDistanceSqr;
	private float starCippDistanceSqr;

	public int starsMax = 100;
	public float starSize = 1;
	public float starDistance = 10;
	public float starCippDistance = 4;


	// Use this for initialization
	void Start () {
		if(!isLocalPlayer){
			return;
		}
		tx = transform;
		starDistanceSqr = starDistance * starDistance;
		starCippDistanceSqr = starCippDistance * starCippDistance;
	}


	private void createStars(){

		points = new ParticleSystem.Particle[starsMax];


		for( int i =0 ; i < starsMax ; i++){

			points[i].position = Random.insideUnitSphere * starDistance + tx.position;
			points[i].color = new Color(1,1,1, 1);
			points[i].size = starSize;
		}
	}




	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer){
			return;
		}
		if( points == null ){
			createStars();	
		} 

		for( int i =0 ; i < starsMax ; i++){

			if((points[i].position - tx.position).sqrMagnitude > starDistanceSqr){
				points[i].position = Random.insideUnitSphere * starDistance + tx.position;
			}


			if((points[i].position - tx.position).sqrMagnitude <= starCippDistanceSqr){

				float percent = (points[i].position - tx.position).sqrMagnitude / starCippDistanceSqr;
				points[i].color = new Color(1,1,1,percent);
				points[i].size = percent * starSize;
			}


		}



		GetComponent<ParticleSystem>().SetParticles(points, points.Length);﻿
	}
}
