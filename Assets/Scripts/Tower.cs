using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : nearestEnemyTower {

	public override void shoot(){
		var ray = Camera.main.transform.rotation * Vector3.forward;
		var bul = Instantiate(bullet);
		bul.transform.position = Camera.main.transform.position;
		bul.GetComponent<Rigidbody>().AddForce(ray * 100f);
	} 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
