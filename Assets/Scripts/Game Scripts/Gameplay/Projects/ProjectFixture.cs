using UnityEngine;

public class ProjectFixture : MonoBehaviour {
	// Use this for initialization
	void Start () {
		AddProjectToCurrentProjects(CreateProject());
		AddProjectsToCurrentEmployees();
		AdjustAllEmployeeContribution();
	}
	Project CreateProject() {
		var newProject = new Project(100.0f);
		return newProject;
	}

	void AddProjectToCurrentProjects(Project proj) {
		ProjectManager.Instance.AddProject(proj);
	}

	void AddProjectsToCurrentEmployees() {
		//todo: easy - change to for loop
		foreach(var employee in EmployeeManager.Instance.Employees) {
			EmployeeManager.Instance.AssignProjectToEmployee(ProjectManager.Instance.GetProject(0), employee);
		}
	}

	void AdjustAllEmployeeContribution() {
		//todo: easy - Change to for loop
		foreach(ActorEmployee employee in EmployeeManager.Instance.Employees) {
			employee.ContributeAmount = Random.Range(3,8);
		}
	}
}
