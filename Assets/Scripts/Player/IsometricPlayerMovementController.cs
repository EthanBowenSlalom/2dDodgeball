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
