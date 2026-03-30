using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChargeAT : ActionTask {

		public BBParameter<GameObject> cat;
		public BBParameter<Vector3> chargePosition;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			chargePosition.value = cat.value.transform.position;
			EndAction(true);
		}
	}
}