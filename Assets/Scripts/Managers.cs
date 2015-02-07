using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {
	public static EmployeeManager EmployeeManager;

	void Start() {
		LoadManagers();
	}

	public void LoadManagers() {
		EmployeeManager = GetComponent(typeof(EmployeeManager)) as EmployeeManager;
	}
}
