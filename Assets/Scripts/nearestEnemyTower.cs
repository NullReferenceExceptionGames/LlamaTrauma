using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class nearestEnemyTower : MonoBehaviour {
	
	// Update is called once per frame

	public abstract void shoot ();

	void Update () {
		var enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject closestEnemy;
		float dis = 1000f;
		foreach (var enemy in enemies){
			var tmpDis = Vector3.Distance (transform.position, enemy.transform.position);
			if (tmpDis < dis) {
				dis = tmpDis;
				closestEnemy = enemy;
			}
			GameObject shot = Instantiate (shot);
		}
	}
}