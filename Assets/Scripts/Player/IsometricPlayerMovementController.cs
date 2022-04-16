using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 2.2f;
    public float sprintMultiplier = 1.5f;
    public IsometricCharacterRenderer isoRenderer;

    private void Awake()
    {
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    public void Move(Vector3 delta)
    {
        isoRenderer.SetDirection(delta.normalized);
        transform.position += delta;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Handle Network Collision
        string gameObjectName = collision.gameObject.name;
        if (!gameObjectName.Equals("PillarTilemap")
            && !gameObjectName.Contains("CourtDodgeball")) {
            var player = transform.GetComponent<Player>();

            player.SubstractHealthPoints(10);

            if (player.healthPoints <= 0)
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
