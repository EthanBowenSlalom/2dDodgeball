using UnityEngine;

namespace Player
{
    public class IsometricPlayerMovementController : MonoBehaviour
    {
        public float MovementSpeed = 2.2f;
        public float SprintMultiplier = 1.5f;

        public IsometricCharacterRenderer Renderer { get; private set; }

        private void Awake()
        {
            Renderer = GetComponentInChildren<IsometricCharacterRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // TODO: Handle Network Collision
            string gameObjectName = collision.gameObject.name;
            if (!gameObjectName.Equals("PillarTilemap")
                && !gameObjectName.Contains("CourtDodgeball")) {
                var player = transform.GetComponent<PlayerStats>();

                player.SubstractHealthPoints(10);

                if (player.HealthPoints <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                MovementSpeed *= SprintMultiplier;
            } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
                MovementSpeed /= SprintMultiplier;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 currentPos = transform.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);

            //Vector2 isoVector = convertInputVectorToIsoVectorDirection(inputVector);
            //Debug.Log("Iso Vector: " + isoVector);

            Vector2 movement = inputVector * MovementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            Renderer.SetDirection(movement);

            transform.position = newPos;
        }

        public void Move(Vector3 delta)
        {
            // do the movement here
        }

        /*WIP
    public Vector2 convertInputVectorToIsoVectorDirection(Vector2 input) {
      float x = input.x;
      float y = input.y
      // down = down right
      if(x > 0 && x <= 1 && y == 0) {
        return new Vector2(1,-1);
      }

      // input vector already formatted correctly for iso movements
      return input;
    }*/
    }
}
