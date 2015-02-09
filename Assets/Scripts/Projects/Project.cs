using UnityEngine;
using System.Collections;

public class Project {
	float effortContributed;
	float effortNeeded;

	public Project(float effortNeeded) {
		this.effortContributed = 0.0f;
		this.effortNeeded = effortNeeded;
	}

	public bool ContributeEffort(float amountContributed) {
		AddEffort(amountContributed);
		return IsEffortMaxed();
	}

	void AddEffort(float amountContributed) {
		if(effortContributed + amountContributed > effortNeeded) {
			amountContributed = effortNeeded;
		} else {
			effortContributed += amountContributed;
		}
	}

	bool IsEffortMaxed() {
		if(effortContributed > effortNeeded) {
			effortContributed = effortNeeded;
		}
		
		if(effortContributed == effortNeeded) {
			return true;
		}
		
		return false;
	}
}
