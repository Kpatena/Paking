using UnityEngine;
using System.Collections;

public class LotBehaviour : MonoBehaviour 
{
	public int points = 100;

	public Vector3 enteredLot(){
		return this.transform.position;
	}
}
