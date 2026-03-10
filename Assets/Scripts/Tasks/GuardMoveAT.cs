using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GuardMoveAT : ActionTask {

		public BBParameter<GameObject> targetBBP;
		public BBParameter<float> velocityBBP;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			agent.transform.position = Vector3.MoveTowards(agent.transform.position, targetBBP.value.transform.position, velocityBBP.value * Time.deltaTime);
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}
	}
}