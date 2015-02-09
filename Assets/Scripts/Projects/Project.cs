using UnityEngine;
using System.Collections;

public class Project {
	float effortContributed;
	float effortNeeded;

	public Project(float effortNeeded) {
		this.effortContributed = 0.0f;
		this.effortNeeded = effortNeeded;
	}

	public float ContributeEffort(float amountContributed) {
		AddEffort(amountContributed);
		Debug.Log ("Effort Contributed by Employee: " + amountContributed +", Total Effort Contribued: " + effortContributed + ", Total Effort Needed: " + effortNeeded );
		return effortContributed;
	}

	void AddEffort(float amountContributed) {
		if(effortContributed + amountContributed > effortNeeded) {
			amountContributed = effortNeeded;
		} else {
			effortContributed += amountContributed;
		}
	}

	public bool IsProjectComplete() {
		if(effortContributed == effortNeeded) {
			return true;
		}
		
		return false;
	}
}
