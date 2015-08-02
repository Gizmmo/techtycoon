using UnityEngine;
using System.Collections.Generic;

public class EmployeeManager : Manager<EmployeeManager> {
	List<Employee> _employees = new List<Employee>();
	List<ChairStatus> _chairs = new List<ChairStatus>();

	public List<Employee> Employees {
		get {
			return _employees;
		}
	}

	void Awake () {
		var emps = FindObjectsOfType(typeof(Employee)) as Employee[];
		foreach(var emp in emps) {
			_employees.Add(emp);
		}

		ChairStatus[] chairs = FindObjectsOfType(typeof(ChairStatus)) as ChairStatus[];
		foreach(var chair in chairs) {
			this._chairs.Add(chair);
		}
	}

	public GameObject GetEmptySeat() {
		foreach(var chair in this._chairs) {
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
