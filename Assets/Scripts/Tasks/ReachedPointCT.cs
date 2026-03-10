using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ReachedPointCT : ConditionTask {

		public BBParameter<GameObject> targetBBP;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if ((agent.transform.position - targetBBP.value.transform.position).magnitude < 0.1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}