using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Car1: MonoBehaviour {
	//add to array of points when distance between position of mousedrag and car 
	//the distance between 2 points when reach 0 go to next point in array 
	//line will be create by checking how much distance was created with 2 points and if it notices distance is far eanough will create a point and a line should be in fixed update
	//transform.position += transform.forward -- very important for char to move then store last coordinates of it moving and transform it with those last coordinates
	//check if there is a path tfor it to follow if not keep continously moving in last coord followed.
	//Values are like in order: 1000, .75, 1.3, .009, Y.085, 0.1
	public GameObject Car; 
	public float rotationSpeed = 1000f;
	public float moveSpeed = 0.5f;
	public float staticSpeed = 0.5f;
	public float gap = 0.0001f;
	public Vector3 velocity;
	public float whenToGoToNextPoint = 0.01f;
	public string carTag;

	//for after car is moved
	public float rotationSpeed2;
	public float moveSpeed2;
	public float staticSpeed2;
	public bool isRed;
	public bool isYellow;
	public float nSpeed;
	public float sSpeed;
	public float eSpeed;
	public float wSpeed;

	private Rigidbody2D rb;
	private Rigidbody2D selectedCar;
	public int currentWaypoint = 0;
	public int countWaypoints = 0;
	private bool carSelected = false;
	private Vector3 mousePos;
	private Vector2 myPosition;
	private Vector2 currentPosition;
	private Vector2 waypointPosition;
	private Vector3 movedirection;
	private bool useCurPos = true;
	private float distance;
	private Vector3 target;

	float seconds = 11;
	float secondsTwo = 15;
	float milliseconds = 0;
	bool startTimer = true;
	public GameObject orangePortal;
	public GameObject Crash;
	public GameObject Exclamation;
	public GameObject CountDown10;
	public GameObject CountDown9;
	public GameObject CountDown8;
	public GameObject CountDown7;
	public GameObject CountDown6;
	public GameObject CountDown5;
	public GameObject CountDown4;
	public GameObject CountDown3;
	public GameObject CountDown2;
	public GameObject CountDown1;
	private GameObject ReadyToMove;
	private GameObject Destroy10;
	private GameObject Destroy9;
	private GameObject Destroy8;
	private GameObject Destroy7;
	private GameObject Destroy6;
	private GameObject Destroy5;
	private GameObject Destroy4;
	private GameObject Destroy3;
	private GameObject Destroy2;
	private GameObject Destroy1;
	bool draw1 = true;
	bool draw2 = true;
	bool draw3 = true;
	bool draw4 = true;
	bool draw5 = true;
	bool draw6 = true;
	bool draw7 = true;
	bool draw8 = true;
	bool draw9 = true;
	bool draw10 = true;

	bool excMade = false;
	bool changeBehaviour = false;
	public bool touchedLot = false;
	public bool alreadyParked = false;
	public bool isCrash = false;
	public Vector3 positioner;
	public Quaternion rotater;
	public bool NorthStall = false;
	public bool SouthStall = false;
	public bool WestStall = false;
	public bool EastStall = false;
	public bool Destroyed = false;
	public bool touchedPortal = false;


	public List<Vector3> waypoints = new List<Vector3>();

	private Vector3 direction;
	private float angle;
	private Quaternion q;
		
	public List<LineRenderer> pathPoints = new List<LineRenderer> ();
	public LineRenderer pathLine;
	private int countPathpoints = 0;
	private int pathIndex = 0;
	public int pathCount = 0;

	RaycastHit2D hit;
		
		
		// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {

		/**************************PARKING************************/
		/*When in a parking lot this code will run.*/
		if (touchedLot == true) {

			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotater, 35 * Time.deltaTime); 
			this.transform.position = Vector3.MoveTowards(this.transform.position, positioner, 1.5f * Time.deltaTime);
			if(changeBehaviour == false){
				changeBehaviour = true;
				rotationSpeed = 0;
				moveSpeed = 0;
				staticSpeed = 0;
				velocity.y = 0;
				velocity.x = 0;
			}
			
			/*Our countdown for when the car can start moving again. 
			Destroys exclamation mark and prevents update from running again.*/
			if(secondsTwo == 0){ 
				Destroy (ReadyToMove);
				rotationSpeed = rotationSpeed2;
				moveSpeed = moveSpeed2;
				staticSpeed = staticSpeed2;
				if (NorthStall) {
					velocity.y = nSpeed;
					NorthStall = false;
				} else if (SouthStall){
					velocity.y = sSpeed;
					SouthStall = false;
				} else if (EastStall) {
					velocity.x = eSpeed;
					EastStall = false;
				} else if (WestStall) {
					velocity.x = wSpeed;
					WestStall = false;
				}
				useCurPos = true;
				touchedLot = false;
				alreadyParked = true;
			}
			
			/*When timer is done "0", numbers count down will stop happening and
			 our exclamation mark will be created.*/
			if(seconds == 0){
				if(excMade == false){
					excMade = true;
					startTimer = false;
					Destroy (Destroy1);
					ReadyToMove = Instantiate (Exclamation, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
				}
			}
			
			/*In this if, we make our countdown and make sure this happens
			only once.*/
			if(startTimer == true){
				if(seconds == 10){
					if(draw10 == true){
						draw10 = false;
						Destroy10 = Instantiate (CountDown10, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 9){
					if(draw9 == true){
						draw9 = false;
						Destroy (Destroy10);
						Destroy9 = Instantiate (CountDown9, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 8){
					if(draw8 == true){
						draw8 = false;
						Destroy (Destroy9);
						Destroy8 = Instantiate (CountDown8, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 7){
					if(draw7 == true){
						draw7 = false;
						Destroy (Destroy8);
						Destroy7 = Instantiate (CountDown7, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 6){
					if(draw6 == true){
						draw6 = false;
						Destroy (Destroy7);
						Destroy6 = Instantiate (CountDown6, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 5){
					if(draw5 == true){
						draw5 = false;
						Destroy (Destroy6);
						Destroy5 = Instantiate (CountDown5, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 4){
					if(draw4 == true){
						draw4 = false;
						Destroy (Destroy5);
						Destroy4 = Instantiate (CountDown4, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 3){
					if(draw3 == true){
						draw3 = false;
						Destroy (Destroy4);
						Destroy3 = Instantiate (CountDown3, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 2){
					if(draw2 == true){
						draw2 = false;
						Destroy (Destroy3);
						Destroy2 = Instantiate (CountDown2, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
				if(seconds == 1){
					if(draw1 == true){
						draw1 = false;
						Destroy (Destroy2);
						Destroy1 = Instantiate (CountDown1, this.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					}
				}
			}
			/*When the car's position is equal to the position of the lot,
			 start the timer.*/
			if(this.transform.position == positioner){
				if (milliseconds <= 0) {
					seconds--;
					secondsTwo--;
					milliseconds = 100;
				}
				
				milliseconds -= Time.deltaTime * 100;
			}
			return;
		}

		//*******************PORTALS**********************//
		if (touchedPortal == true) {
			target = waypoints [currentWaypoint];
			movedirection = target - transform.position;
			velocity = movedirection.normalized * staticSpeed;
			this.transform.position = orangePortal.transform.position;
			// SET STATIC SPEED
			//velocity.x = eSpeed;
			rb.velocity = velocity;
			Reset();
			touchedPortal = false;
		}

		//*******************MOVING***********************//
		if (Input.GetMouseButtonDown(0)) {
			
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null) 
			{
				//When you select the car
				if (hit.transform.gameObject.tag == carTag && hit.collider == this.GetComponentInChildren<BoxCollider2D>())
				{
					selectedCar = hit.transform.GetComponent<Rigidbody2D>();
					if(selectedCar.mass == 1) {
						Reset();
						carSelected = true;
					}

				} else {
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log("No hit");
			}
		} 
		
		if (Input.GetMouseButton(0)) {
			if (carSelected && selectedCar.mass == 1) {
				if (useCurPos) {
					currentPosition = transform.position;
					useCurPos = false;
				} else {
					currentPosition = waypointPosition;
				}


				mousePos = Input.mousePosition;
				mousePos = Camera.main.ScreenToWorldPoint(mousePos);
				distance = Vector2.Distance(currentPosition, mousePos);

				//if only distance is greater than gap that you make a waypoint
				if(distance > gap) {
					waypointPosition = mousePos;
					waypoints.Add(waypointPosition);

					// DRAWING THE PATH LINE
					LineRenderer newLine = (LineRenderer)Instantiate(pathLine, new Vector3(0, 0, 0), Quaternion.identity);
					newLine.SetPosition(pathIndex, new Vector3(currentPosition.x, currentPosition.y, 0));
					pathIndex++;
					newLine.SetPosition(pathIndex, new Vector3(waypointPosition.x, waypointPosition.y, 0));
					pathPoints.Add (newLine);
					countPathpoints++;
					pathIndex = 0;
				}
			}
			
		}

		if (Input.GetMouseButtonUp (0) ) {
			carSelected = false;

		}

		if (currentWaypoint < waypoints.Count) {
			target = waypoints [currentWaypoint];
			movedirection = target - transform.position;	
			transform.position = Vector2.MoveTowards (transform.position, target, moveSpeed * Time.deltaTime);

			if (Vector2.Distance (transform.position, target) <= whenToGoToNextPoint) {
				currentWaypoint++;
				try{
					waypoints.RemoveAt(countWaypoints++);
					Destroy(pathPoints[pathCount++]);
					Destroy(pathPoints[pathCount++]);
				} catch (MissingReferenceException e) {
					Debug.Log("Exception caught");
				}

				direction = waypoints [currentWaypoint] - transform.position;
				angle = (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg) - 90;
				q = Quaternion.AngleAxis (angle, Vector3.forward);
				Car.transform.rotation = Quaternion.Slerp (Car.transform.rotation, q, Time.deltaTime * rotationSpeed);

					
			} else {
				velocity = movedirection.normalized * staticSpeed;
			}
		} else {
			for(int i = 0; i < pathPoints.Count; i++){
				Destroy(pathPoints[i]);
			}
		}

		rb.velocity = velocity;


	}


	public void Reset() {
		for(int i = 0; i < pathPoints.Count; i++){
			Destroy(pathPoints[i]);
		}
		currentWaypoint = 0;
		countWaypoints = 0;
		waypoints.Clear();
		pathCount = 0;
		countPathpoints = 0;
		pathPoints.Clear ();
	}

	public void RemoveParkingTimer() {
		if (ReadyToMove != null) 
			Destroy (ReadyToMove);
		else if (Destroy1 != null)
			Destroy (Destroy1);
		else if (Destroy2 != null)
			Destroy (Destroy2);
		else if (Destroy3 != null)
			Destroy (Destroy3);
		else if (Destroy4 != null)
			Destroy (Destroy4);
		else if (Destroy5 != null)
			Destroy (Destroy5);
		else if (Destroy6!= null)
			Destroy (Destroy6);
		else if (Destroy7 != null)
			Destroy (Destroy7);
		else if (Destroy8 != null)
			Destroy (Destroy8);
		else if (Destroy9 != null)
			Destroy (Destroy9);
		else if (Destroy10 != null)
			Destroy (Destroy10);

	}

}


