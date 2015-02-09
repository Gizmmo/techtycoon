using UnityEngine;
using System.Collections;

public class Employee : MonoBehaviour {
	private bool _isInSeat = false;
	private GameObject _seat;
	private bool isWorking;

	private Project currentProject;

	public bool isInSeat {
		get {
			return _isInSeat;
		}
		set {
			_isInSeat = value;
		}
	}

	public GameObject seat {
		get {
			return _seat;
		}
		set {
			_seat = value;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AssignProject (Project project) {
		currentProject = project;
		StartWorking();
	}

	public void SitDown() {
		_isInSeat = true;
		StartWorking();
	}

	void StartWorking() {
		if(CanWork() && !isWorking) {
			StartCoroutine(ContributeWork());
			isWorking = true;
		}
	}

	bool CanWork() {
		if (currentProject != null && _isInSeat) {
			return true;
		}
		return false;
	}

	void StopWorking() {
		isWorking = false;
	}

	IEnumerator ContributeWork() {
		while(CanWork()) {
			Debug.Log ("Contribute!");
			yield return new WaitForSeconds(5.0f);
		}
		StopWorking();
	}
	
}
