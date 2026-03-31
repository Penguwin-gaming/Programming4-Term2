using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AvoidAT : ActionTask {

		public BBParameter<Vector3> moveDirection;
		public LayerMask obstacleLayers;
		public float closeRadius, nearRadius, farRadius;
		public float closeWeight, nearWeight, farWeight;

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			Collider[] obstacles = Physics.OverlapSphere(agent.transform.position, farRadius, obstacleLayers);

			foreach (Collider obstacle in obstacles)
			{
				float weight = 0f;
				float distanceToObstacle = Vector3.Distance(agent.transform.position, obstacle.transform.position);

				if (distanceToObstacle < closeRadius)
					weight = closeWeight;
				else if (distanceToObstacle < nearRadius)
					weight = nearWeight;
				else
					weight = farWeight;

				Vector3 directionFromObstacle = (agent.transform.position - obstacle.transform.position).normalized;
				moveDirection.value += directionFromObstacle * weight; 
			}
		}
	}
}