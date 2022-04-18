using Player;
using UnityEngine;
using UnityEngine.UIElements;

namespace Projectile
{
    public class ShootProjectile : MonoBehaviour
    {
        public GameObject projectile;
        public float speed;


        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var isoContoller = transform.GetComponent<IsometricPlayerMovementController>();
                var playerStats = isoContoller.Renderer.PlayerStats;

                if (playerStats.CanThrowDodgeball())
                {
                    var inertia = GetInertia();

                    //always 'project' out from in front of the character
                    var isoForward = CalculateIsoForward(isoContoller);

                    if(playerStats.isDoubleShot)
                    {
                        /* TODO: START HERE ETHAN, position the blals next to each other but not touching
                         * Continue working on Powerup system */
                        GameObject dodgeballDouble =
                        Instantiate(projectile, transform.position + isoForward, Quaternion.identity, isoContoller.transform);
                    }
                    // create dodgeball as child of player shooting it
                    GameObject dodgeball =
                        Instantiate(projectile, transform.position + isoForward, Quaternion.identity, isoContoller.transform);

                    var force = (inertia + isoForward * speed) * isoContoller.MovementSpeed;
                    //Debug.Log("Forward Vector: " + isoForward + "\tForce: " + force);

                    //Vector3 mousePos = Vector3.Normalize(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                    //Vector3 force = (mousePos * speed);
                    dodgeball.GetComponent<Rigidbody2D>().AddForce(force);

                    playerStats.SubtractEnergyPoints(5);
                    playerStats.BallThrown();
                }
            }
        }

        /// <summary>
        /// Vector based on characters current (aka last) facing direction
        /// </summary>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        private Vector3 CalculateIsoForward(IsometricPlayerMovementController isoContoller)
        {
            Vector2 lastDirection = isoContoller.Renderer.lastDirectionAsVector;

            Vector3 isoDirectionalForward = new Vector3(1, 1, 0);

            if (lastDirection.x == 0)
            {
                isoDirectionalForward.x = 0;
            }

            if (lastDirection.x < 0)
            {
                isoDirectionalForward.x = -1;
            }

            if (lastDirection.y == 0)
            {
                isoDirectionalForward.y = 0;
            }

            if (lastDirection.y < 0)
            {
                isoDirectionalForward.y = -1;
            }

            return isoDirectionalForward;
        }

        /// <summary>
        /// Get Interia based on current player input (movement)
        /// </summary>
        /// <returns></returns>
        private Vector3 GetInertia()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 inputVector = new Vector3(horizontalInput, verticalInput, 0);
            inputVector = Vector3.ClampMagnitude(inputVector, 1);

            return inputVector * speed;
        }
    }
}
