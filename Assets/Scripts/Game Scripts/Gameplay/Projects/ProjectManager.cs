using UnityEngine;
using System.Collections.Generic;

public class ProjectManager : Manager<ProjectManager> {

	List<Project> _currentProjects = new List<Project>();

	public void ContributeToProject(float amountContributed, Project project) {
		if (project.IsProjectComplete()) {
			return;
		}
		project.ContributeEffort(amountContributed);

		if (project.IsProjectComplete()) {
			EmitProjectComplete(project);
		}
	}

	public void AddProject(Project newProject) {
		_currentProjects.Add(newProject);
	}

	public Project GetProject(int index) {
		return _currentProjects[index];
	}

	void EmitProjectComplete(Project project) {
		Debug.Log ("Project Complete");
	}
}
