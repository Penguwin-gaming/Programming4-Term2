using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GuardDetectionSorting : ActionTask {

		public BBParameter<Collider[]> nearbyTargets;
		public BBParameter<int> numberOfTargets;
		public BBParameter<Transform> target;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			Transform closestTarget = null;
			float distanceToBeat = float.MaxValue;

			for (int i = 0; i < numberOfTargets.value;  i++)
			{
				Transform currentTarget = nearbyTargets.value[i].transform;

				float distanceToTarget = Vector3.Distance(agent.transform.position, currentTarget.position);
				if (distanceToTarget < distanceToBeat)
				{
					distanceToBeat = distanceToTarget;
					closestTarget = currentTarget;
				}
			}
			target.value = closestTarget;
			EndAction(true);
		}
	}
}