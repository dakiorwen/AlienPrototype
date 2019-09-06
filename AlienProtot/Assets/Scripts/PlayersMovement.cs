using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody cRigidBody;

    #region MovementVariables
    private float horizonalMovement;

    [SerializeField]
    private float multiplierSpeed = 7f;
    private float movementSpeed;

    [SerializeField]
    float jumpSpeed = 300f;
    float gravityVelocity;

    private Vector3 finalMovementSpeed;
    #endregion

    void Start()
    {
        cRigidBody = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        SetMovementSpeed();
        Jump();
        SetFinalMovementSpeedAndVelocity();
        
    }

    void SetMovementSpeed() // as long as horizontal axis is more or less than 0, it increases 1 every second (0)
    {
        gravityVelocity = cRigidBody.velocity.y;
        horizonalMovement = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") != 0f)
        {
            movementSpeed += (Time.deltaTime * 1f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            movementSpeed = 0f;
        }

        if (movementSpeed >= 1.5f)
        {
            movementSpeed = 1f;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            cRigidBody.AddForce(Vector3.up * jumpSpeed);
        }
    }

    void SetFinalMovementSpeedAndVelocity()
    {
        finalMovementSpeed = new Vector3(horizonalMovement * movementSpeed * multiplierSpeed, cRigidBody.velocity.y, 0f);
        cRigidBody.velocity = finalMovementSpeed;
    }
}
