using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmployeeManager : MonoBehaviour {
	List<Employee> employees = new List<Employee>();
	List<ChairStatus> chairs = new List<ChairStatus>();

	void Awake () {
		Employee[] emps = FindObjectsOfType(typeof(Employee)) as Employee[];
		foreach(Employee emp in emps) {
			employees.Add(emp);
		}

		ChairStatus[] chairs = FindObjectsOfType(typeof(ChairStatus)) as ChairStatus[];
		foreach(ChairStatus chair in chairs) {
			this.chairs.Add(chair);
		}
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject GetEmptySeat() {
		foreach(ChairStatus chair in this.chairs) {
			if(chair.isChairOpen) {
				return chair.gameObject;
			}
		}
		return null;
	}
}
