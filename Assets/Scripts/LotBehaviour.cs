using UnityEngine;
using System.Collections;

public class LotBehaviour : MonoBehaviour 
{
	public int points = 1000;

	void OnTriggerEnter2D(Collider2D other)
	{
		AddPoints.addPoints (points);

	}
	public Vector3 enteredLot(){
		return this.transform.position;
	}
}
