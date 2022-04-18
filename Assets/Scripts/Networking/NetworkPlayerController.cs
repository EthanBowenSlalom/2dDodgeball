using System;
using Fusion;
using Player;
using UnityEngine;

namespace Networking
{
    public class NetworkPlayerController : NetworkBehaviour
    {
        [SerializeField]
        private IsometricPlayerMovementController Controller;

        [SerializeField]
        private IsometricCharacterRenderer Renderer;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData input))
            {
                input.Direction.Normalize();

                var sprintMultiplier = input.IsSprint ? Controller.SprintMultiplier : 1;
                var delta = sprintMultiplier * Controller.MovementSpeed * input.Direction * Runner.DeltaTime;

                transform.position += (Vector3) delta;
                Renderer.SetDirection(delta);
            }
        }
    }
}
