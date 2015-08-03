using UnityEngine;

public class MoveToOpenSeat : MonoBehaviour {
	private ActorEmployee _actorEmployee;
	private EmployeeManager _employeeManager;
	private Transform _startMarker;
	private Transform _endMarker;
	private float _startTime;
	private float _journeyLength;
	private ChairStatus _chair;

	public float Speed = 1.0f;
	public Transform Target;
	public float Smooth = 5.0F;
	public float MinimumDistance = 1.0f;

	void Awake () {

	}
	// Use this for initialization
	void Start () {
		_actorEmployee = GetComponent<ActorEmployee>();
		_employeeManager = EmployeeManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		if(!_actorEmployee.IsInSeat) {
			LookForSeat();
		}
	}

	void LookForSeat() {
		if (_actorEmployee.Seat == null) {
			FindASeat();
		} else {
			MoveToSeat();
		}
	}

	void FindASeat () {
		var seat = _employeeManager.GetEmptySeat();
		if (seat == null) {
			return;
		}
		_actorEmployee.Seat = seat;
		_startMarker = transform;
		_endMarker = _actorEmployee.Seat.transform;
		_startTime = Time.time;
		_journeyLength = Vector3.Distance(_startMarker.position, _endMarker.position);
		_chair = seat.GetComponent(typeof(ChairStatus)) as ChairStatus;
		_chair.isChairOpen = false;
	}

	void MoveToSeat() {
		var distCovered = (Time.time - _startTime) * Speed;
		var fracJourney = distCovered / _journeyLength;
		transform.position = Vector3.Lerp(_startMarker.position, _endMarker.position, fracJourney);
		IsAtSeat();
	}

	void IsAtSeat() {
		if(Vector3.Distance(transform.position, _endMarker.position) < MinimumDistance) {
			SitDown();
		}
	}

	void SitDown() {
		_actorEmployee.SitDown();
		_chair.isChairOpen = false;
		transform.position = _chair.transform.position;
	}
}
