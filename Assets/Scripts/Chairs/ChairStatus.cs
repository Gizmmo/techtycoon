using UnityEngine;
using System.Collections;

public class ChairStatus : MonoBehaviour {
	bool _isChairOpen = true;
	GameObject _occupant;

	public bool isChairOpen {
		get {
			return _isChairOpen;
		}

		set {
			_isChairOpen = value;
		}
	}

	public GameObject occupant {
		get {
			return _occupant;
		}

		set {
			_occupant = value;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
