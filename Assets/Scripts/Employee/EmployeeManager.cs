using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmployeeManager : MonoBehaviour {
	List<Employee> employees = new List<Employee>();
	List<ChairStatus> chairs = new List<ChairStatus>();

	public List<Employee> Employees {
		get {
			return employees;
		}
	}

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

	public GameObject GetEmptySeat() {
		foreach(ChairStatus chair in this.chairs) {
			if(chair.isChairOpen) {
				return chair.gameObject;
			}
		}
		return null;
	}

	public bool AssignProjectToEmployee (Project project, Employee employee) {
		employee.AssignProject(project);
		return true;
	}
}
