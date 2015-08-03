using UnityEngine;
using System.Collections.Generic;

public class EmployeeManager : Manager<EmployeeManager> {
	List<ActorEmployee> _employees = new List<ActorEmployee>();
	List<ChairStatus> _chairs = new List<ChairStatus>();

	public List<ActorEmployee> Employees {
		get {
			return _employees;
		}
	}

	void Awake () {
		var emps = FindObjectsOfType(typeof(ActorEmployee)) as ActorEmployee[];
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

	public bool AssignProjectToEmployee (Project project, ActorEmployee actorEmployee) {
		actorEmployee.AssignProject(project);
		return true;
	}
}
