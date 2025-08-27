using UnityEngine;

public class InputManager : MonoBehaviour
{
  
    PlayerControls playerControls;
    public Vector2 movementInput;


    public float verticalInput;
    public float horizontalInput;

    AnimatorManager animatorManager;
    public float moveAmount;


    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }


    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();

    }

    private void OnDisable()
    {
        playerControls.Disable();

    }

  private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    public void HaandleAllInputs()
    {
        HandleMovementInput ();

    }
}
