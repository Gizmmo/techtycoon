using UnityEngine;

public class Project {
	float _effortContributed;
	float _effortNeeded;

	public Project(float effortNeeded) {
		_effortContributed = 0.0f;
		_effortNeeded = effortNeeded;
	}

	public float ContributeEffort(float amountContributed) {
		AddEffort(amountContributed);
		Debug.Log ("Effort Contributed by ActorEmployee: " + amountContributed +", Total Effort Contribued: " + _effortContributed + ", Total Effort Needed: " + _effortNeeded );
		return _effortContributed;
	}

	void AddEffort(float amountContributed) {
		if(_effortContributed + amountContributed > _effortNeeded) {
			_effortContributed = _effortNeeded;
		} else {
			_effortContributed += amountContributed;
		}
	}

	public bool IsProjectComplete() {
		return _effortContributed >= _effortNeeded;
	}
}
