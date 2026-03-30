using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

    [Category("Movement/Direct")]
    [Description("Moves the agent towards to target per frame without pathfinding")]
    public class ChargeMoveAT : ActionTask<Transform> {

        [RequiredField]
        public BBParameter<Vector3> target;
        public BBParameter<float> speed = 2;
        public BBParameter<float> stopDistance = 0.1f;
        public bool waitActionFinish;

        protected override void OnUpdate()
        {
            if ((agent.position - target.value).magnitude <= stopDistance.value)
            {
                EndAction();
                return;
            }

            agent.position = Vector3.MoveTowards(agent.position, target.value, speed.value * Time.deltaTime);
            if (!waitActionFinish)
            {
                EndAction();
            }
        }
    }
}