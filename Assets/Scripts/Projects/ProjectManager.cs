using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectManager : MonoBehaviour {

	List<Project> currentProjects = new List<Project>();

	public void ContributeToProject(float amountContributed, Project project) {
		project.ContributeEffort(amountContributed);
	}

	public void AddProject(Project newProject) {
		currentProjects.Add(newProject);
	}

	public Project GetProject(int index) {
		return currentProjects[index];
	}
}
