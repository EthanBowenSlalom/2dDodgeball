using System;
using Fusion;
using UnityEngine;

namespace Networking
{
    public class NetworkPlayerController : NetworkBehaviour
    {
        [SerializeField]
        private IsometricPlayerMovementController Controller;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData input))
            {
                input.Direction.Normalize();

                var sprintMultiplier = input.IsSprint ? Controller.sprintMultiplier : 1;

                var delta = sprintMultiplier * Controller.movementSpeed * input.Direction * Runner.DeltaTime;
                Debug.Log(Runner.DeltaTime);

                transform.position += (Vector3) delta;
                Controller.Move(delta);
            }
        }
    }
}
