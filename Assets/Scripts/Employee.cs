using UnityEngine;
using System.Collections;

public class Employee : MonoBehaviour {
	private bool _isInSeat = false;
	private GameObject _seat;

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
	
}
