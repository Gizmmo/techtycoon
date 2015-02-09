using UnityEngine;
using System.Collections;

public class ProjectFixture : MonoBehaviour {


	// Use this for initialization
	void Start () {
		AddProjectToCurrentProjects(CreateProject());
		AddProjectsToCurrentEmployees();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Project CreateProject() {
		Project newProject = new Project(100.0f);
		return newProject;
	}

	void AddProjectToCurrentProjects(Project proj) {
		Managers.ProjectManager.AddProject(proj);
	}

	void AddProjectsToCurrentEmployees() {
		foreach(Employee employee in Managers.EmployeeManager.Employees) {
			Managers.EmployeeManager.AssignProjectToEmployee(Managers.ProjectManager.GetProject(0), employee);
		}
	}
}
