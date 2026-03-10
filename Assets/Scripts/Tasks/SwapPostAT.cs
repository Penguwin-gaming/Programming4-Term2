using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SwapPostAT : ActionTask {

		public BBParameter<GameObject> targetBBP;
		public BBParameter<GameObject> Post1BBP;
		public BBParameter<GameObject> Post2BBP;
		public BBParameter<int> postIndex = 0;
		
		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if (postIndex.value == 0)
			{
				targetBBP.value = Post1BBP.value;
				postIndex.value = 1;
			}
			if (postIndex.value == 1)
			{
				targetBBP.value = Post2BBP.value;
				postIndex.value = 0;
			}
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}
	}
}