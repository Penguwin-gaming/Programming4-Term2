using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 playerInput;
    private Vector3 playerVelocity;
    private float maxSpeed;
    private float acceleration;
    private float accelerationTime;
    private float decceleration;
    private float deccelerationTime;
    Rigidbody player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxSpeed = 4f;
        accelerationTime = 0.5f;
        deccelerationTime = 0.2f;
        acceleration = maxSpeed / accelerationTime;
        decceleration = maxSpeed / deccelerationTime;
        player = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerInput.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerInput.z = -1;
        }
        else
        {
            playerInput.z = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerInput.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerInput.x = 1;
        }
        else
        {
            playerInput.x = 0;
        }
    }

    private void FixedUpdate()
    {
        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector3 playerInput)
    {
        walkInput();

        player.linearVelocity = playerVelocity;
    }

    private void walkInput()
    {
        if (playerInput.x != 0)
        {
            playerVelocity.x += playerInput.x * acceleration * Time.fixedDeltaTime;
            playerVelocity.x = Mathf.Clamp(playerVelocity.x, -maxSpeed, maxSpeed);
        }
        else if (Mathf.Abs(playerInput.x) > 0.005f)
        {
            playerVelocity.x += -Mathf.Sign(playerInput.x) * decceleration * Time.fixedDeltaTime;
        }
        else
        {
            playerVelocity.x = 0;
        }

        if (playerInput.z != 0)
        {
            playerVelocity.z += playerInput.z * acceleration * Time.fixedDeltaTime;
            playerVelocity.z = Mathf.Clamp(playerVelocity.z, -maxSpeed, maxSpeed);
        }
        else if (Mathf.Abs(playerInput.z) > 0.005f)
        {
            playerVelocity.z += -Mathf.Sign(playerInput.z) * decceleration * Time.fixedDeltaTime;
        }
        else
        {
            playerVelocity.z = 0;
        }
    }
}
