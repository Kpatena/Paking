using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car2 : MonoBehaviour {
	//add to array of points when distance1 between position of mousedrag and car 
	//the distance1 between 2 points when reach 0 go to next point in array 
	//line will be create by checking how much distance1 was created with 2 points and if it notices distance1 is far eanough will create a point and a line should be in fixed update
	//transform.position += transform.forward -- very important for char to move then store last coordinates of it moving and transform it with those last coordinates
	//check if there is a path tfor it to follow if not keep continously moving in last coord followed.
	//Values are like in order: 1000, .75, 1.3, .009, Y.085, 0.1
	public GameObject Car; 
	public float rotationSpeed1 = 2f;
	public float moveSpeed1= 1f;
	public float staticSpeed1 = 1.5f;
	public float gap1 = 0.2f;
	public Vector3 velocity1;
	public float whenToGoToNextPoint1 = 0.01f;
	
	private Rigidbody2D rb1;
	private Rigidbody2D selectedCar1;
	private int currentWaypoint1 = 0;
	private int countwaypoints = 0;
	private bool carSelected1 = false;
	private Vector3 mousePos1;
	private Vector2 currentPosition1;
	private Vector2 waypointPosition1;
	private Vector3 movedirection11;
	private int useCurPos1= 0;
	private float distance1;
	private Vector3 target1;

	public List<Vector3> waypoints = new List<Vector3>();
	
	private Vector3 direction1;
	private float angle1;
	private Quaternion q1;

	private List<LineRenderer> pathPoints = new List<LineRenderer> ();
	public LineRenderer pathLine;
	private int countPathpoints = 0;
	private int pathIndex = 0;
	private int pathCount = 0;
	
	
	// Use this for initialization
	void Start () {
		rb1 = GetComponent<Rigidbody2D> ();
		rb1.velocity = velocity1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null) 
			{
				//When you select the car
				if (hit.transform.gameObject.tag == "Car2")
				{
					selectedCar1 = hit.transform.GetComponent<Rigidbody2D>();
					if (selectedCar1.mass == 1) {
						for(int i = 0; i < pathPoints.Count; i++){
							Destroy(pathPoints[i]);
						}
						Reset();
						carSelected1 = true;
					}
					
				} else {
					//Debug.Log ("nopz");
				}
			} else {
				//Debug.Log("No hit");
			}
		} 
		
		if (Input.GetMouseButton(0)) {
			if (carSelected1 && selectedCar1.mass == 1) {
				if (useCurPos1== 0) {
					currentPosition1 = selectedCar1.transform.position;
					useCurPos1= 1;
				} else {
					currentPosition1 = waypointPosition1;
				}
				
				
				mousePos1 = Input.mousePosition;
				mousePos1 = Camera.main.ScreenToWorldPoint(mousePos1);
				distance1 = Vector2.Distance(currentPosition1, mousePos1);
				
				//if only distance1 is greater than gap1 that you make a waypoint
				if(distance1 > gap1) {
					waypointPosition1 = mousePos1;
					waypoints.Add(waypointPosition1);

					LineRenderer newLine = (LineRenderer)Instantiate(pathLine, new Vector3(0, 0, 0), Quaternion.identity);
					newLine.SetPosition(pathIndex, new Vector3(currentPosition1.x, currentPosition1.y, 0));
					pathIndex++;
					newLine.SetPosition(pathIndex, new Vector3(waypointPosition1.x, waypointPosition1.y, 0));
					pathPoints.Add (newLine);
					countPathpoints++;
					pathIndex = 0;
				}
			}
			
		}
		
		if (Input.GetMouseButtonUp (0)) {
			carSelected1 = false;
			
		}

			
			if (currentWaypoint1 < waypoints.Count) {
				target1 = waypoints [currentWaypoint1];
				movedirection11 = target1 - selectedCar1.transform.position;	
				selectedCar1.transform.position = Vector2.MoveTowards (
					selectedCar1.transform.position,
					target1,
					moveSpeed1* Time.deltaTime
				);
				
				if (Vector2.Distance (selectedCar1.transform.position, target1) <= whenToGoToNextPoint1) {
					currentWaypoint1++;
					waypoints.RemoveAt (countwaypoints++);
					Destroy(pathPoints[pathCount++]);
					Destroy(pathPoints[pathCount++]);
					//Debug.Log ("Waypoint next then destroyed last one");
					
					if (currentWaypoint1 < waypoints.Count) {
						direction1 = waypoints [currentWaypoint1] - selectedCar1.transform.position;
						angle1 = (Mathf.Atan2 (direction1.y, direction1.x) * Mathf.Rad2Deg) - 90;
						q1 = Quaternion.AngleAxis (angle1, Vector3.forward);
						selectedCar1.transform.rotation = Quaternion.Slerp (selectedCar1.transform.rotation, q1, Time.deltaTime * rotationSpeed1);
					} 
					
				} else {
					velocity1 = movedirection11.normalized * staticSpeed1;
				}

			} else {
				Car.transform.rotation = Quaternion.Slerp (Car.transform.rotation, q1, Time.deltaTime * rotationSpeed1);
				//rb1.velocity1 = new Vector2(-target1.x * Time.deltaTime * moveSpeed, -target1.y * Time.deltaTime * 10);
			}
			rb1.velocity = velocity1;

		
		
	}
	
	
	private void Reset() {
		currentWaypoint1 = 0;
		countwaypoints = 0;
		pathCount = 0;
		countPathpoints = 0;
		pathPoints.Clear ();
		waypoints.Clear();
	}
}



