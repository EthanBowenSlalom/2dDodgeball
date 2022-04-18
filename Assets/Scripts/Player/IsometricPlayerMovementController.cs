using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 2.2f;
    public float sprintMultiplier = 1.5f;
    public IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            movementSpeed *= sprintMultiplier;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            movementSpeed /= sprintMultiplier;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        //Vector2 isoVector = convertInputVectorToIsoVectorDirection(inputVector);
        //Debug.Log("Iso Vector: " + isoVector);

        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
