using UnityEngine;
using System.Collections;

public class MoveToOpenSeat : MonoBehaviour {
	private Employee employee;
	private EmployeeManager employeeManager;
	private Transform startMarker;
	private Transform endMarker;
	private float startTime;
	private float journeyLength;
	private ChairStatus chair;

	public float speed = 1.0f;
	public Transform target;
	public float smooth = 5.0F;
	public float minimumDistance = 1.0f;

	void Awake () {

	}
	// Use this for initialization
	void Start () {
		employee = GetComponent(typeof(Employee)) as Employee;
		employeeManager = Managers.EmployeeManager;
	}
	
	// Update is called once per frame
	void Update () {
		if(!employee.isInSeat) {
			LookForSeat();
		}
	}

	void LookForSeat() {
		if (employee.seat == null) {
			FindASeat();
		} else {
			MoveToSeat();
		}
	}

	void FindASeat () {
		GameObject seat = employeeManager.GetEmptySeat();
		if(seat != null) {
			employee.seat = seat;
			startMarker = transform;
			endMarker = employee.seat.transform;
			startTime = Time.time;
			journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
			chair = seat.GetComponent(typeof(ChairStatus)) as ChairStatus;
			chair.isChairOpen = false;
		}
	}

	void MoveToSeat() {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
		IsAtSeat();
	}

	void IsAtSeat() {
		if(Vector3.Distance(transform.position, endMarker.position) < minimumDistance) {
			SitDown();
		}
	}

	void SitDown() {
		employee.isInSeat = true;
		chair.isChairOpen = false;
		transform.position = chair.transform.position;
	}
}
