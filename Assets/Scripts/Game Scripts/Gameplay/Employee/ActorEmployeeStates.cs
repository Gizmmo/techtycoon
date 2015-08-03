using UnityEngine;
using System.Collections;

public partial class ActorEmployee {

	public class ConcreteState : IFsmState {

		protected ActorEmployee BaseActorEmployee;

		public ConcreteState(ActorEmployee baseActorEmployee) {
			BaseActorEmployee = baseActorEmployee;
		}
		public void OnEntry() {}

		public void OnExit() {}

		public void AssignProject(Project project) {}

		public void RemoveFromProject() {
			
		}
	}

	public class WorkingState : ConcreteState {
		public WorkingState(ActorEmployee baseActorEmployee) : base(baseActorEmployee) {}
	}

	public class SearchingState : ConcreteState {
		public SearchingState(ActorEmployee baseActorEmployee) : base(baseActorEmployee) {}
	}

	public class WaitingState : ConcreteState {
		public WaitingState(ActorEmployee baseActorEmployee) : base(baseActorEmployee) {}
	}

	public class IdleState : ConcreteState {
		public IdleState(ActorEmployee baseActorEmployee) : base(baseActorEmployee) {}
	}

}
