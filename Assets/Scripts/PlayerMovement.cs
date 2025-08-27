using JetBrains.Annotations;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;
    public float walkingSpeed = 2.5f;
    public float runningSpeed = 7;
    public float rotationSpeed = 14;

    public bool isRunning;




    private void Awake()
    {
        
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;

    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;// se multiplica para que al no haber input el resultado sea 0 y no un valor
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.y = 0;

        moveDirection.Normalize();



        if (isRunning)
        {

            moveDirection = moveDirection * runningSpeed;

        }
        else
        {
            moveDirection = moveDirection * walkingSpeed;
        }

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.linearVelocity = movementVelocity;

    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;

        targetDirection.y = 0;
        targetDirection.Normalize();

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;

    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

}
