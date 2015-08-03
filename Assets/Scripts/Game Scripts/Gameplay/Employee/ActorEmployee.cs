using UnityEngine;
using System.Collections;

public partial class ActorEmployee : MonoBehaviour {
	private Project _currentProject;
	private bool _isWorking;

	public float ContributeAmount = 5.0f;  //This will change later when indivual team members and levels are introduced
	public GameObject Seat { get; set; }
	public bool IsInSeat { get; set; }

	private enum WorkStates {
		Working,
		Searching,
		Waiting,
		Idle
	}

	private Fsm<WorkStates, ConcreteState> _workFsm = new Fsm<WorkStates, ConcreteState>(); 
	
	public void AssignProject (Project project) {
		_currentProject = project;
		StartWorking();
	}

	public void SitDown() {
		IsInSeat = true;
		StartWorking();
	}

	void StartWorking() {
		if (!CanWork() || _isWorking) {
			return;
		}

		StartCoroutine(ContributeWork());
		_isWorking = true;
	}

	bool CanWork() {
		return _currentProject != null && IsInSeat;
	}

	void StopWorking() {
		_isWorking = false;
	}

	IEnumerator ContributeWork() {
		while(CanWork()) {
			ProjectManager.Instance.ContributeToProject(ContributeAmount, _currentProject);
			yield return new WaitForSeconds(5.0f);
		}
		StopWorking();
	}
	
}
