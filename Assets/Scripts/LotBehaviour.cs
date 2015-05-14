using UnityEngine;
using System.Collections;

public class LotBehaviour : MonoBehaviour 
{
	public bool isRed;
	public bool isYellow;

	public Vector3 enteredLot(){
		return this.transform.position;
	}
}
