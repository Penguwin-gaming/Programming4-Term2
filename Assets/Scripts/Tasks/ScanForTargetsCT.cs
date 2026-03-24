using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ScanForTargetsCT : ConditionTask {

		public BBParameter<Collider[]> nearbyTargets;
		public BBParameter<int> numberOfTargets;
		public BBParameter<float> scanRadius;
		public BBParameter<LayerMask> scanLayers;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			numberOfTargets.value = Physics.OverlapSphereNonAlloc(agent.transform.position, scanRadius.value, nearbyTargets.value, scanLayers.value);

			if (numberOfTargets.value > 0)
			{
				return true;
			} else
			{
				return false;
			}
		}
	}
}