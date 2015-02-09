using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {
	public static EmployeeManager EmployeeManager;
	public static ProjectManager ProjectManager;

	void Awake() {
		LoadManagers();
	}

	public void LoadManagers() {
		EmployeeManager = GetComponent(typeof(EmployeeManager)) as EmployeeManager;
		ProjectManager = GetComponent(typeof(ProjectManager)) as ProjectManager;
	}
}
