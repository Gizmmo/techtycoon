using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectManager : MonoBehaviour {

	List<Project> currentProjects = new List<Project>();

	public void ContributeToProject(float amountContributed, Project project) {
		if (!project.IsProjectComplete()) {
			project.ContributeEffort(amountContributed);

			if (project.IsProjectComplete()) {
				EmitProjectComplete(project);
			}
		}
	}

	public void AddProject(Project newProject) {
		currentProjects.Add(newProject);
	}

	public Project GetProject(int index) {
		return currentProjects[index];
	}

	void EmitProjectComplete(Project project) {
		Debug.Log ("Project Complete");
	}
}
