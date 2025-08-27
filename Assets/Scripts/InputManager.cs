using UnityEngine;

public class InputManager : MonoBehaviour
{
  
    PlayerControls playerControls;
    public Vector2 movementInput;


    public float verticalInput;
    public float horizontalInput;

    AnimatorManager animatorManager;
    public float moveAmount;

    PlayerMovement playerMovement;
    public bool shiftInput;


    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.Shift.performed += i => shiftInput = true;
            playerControls.PlayerActions.Shift.canceled += i => shiftInput = false;
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

        animatorManager.UpdateAnimatorValues(0, moveAmount, playerMovement.isRunning);
    }

    public void HaandleAllInputs()
    {
        HandleMovementInput ();
        HandleRunningInput ();

    }

    public void HandleRunningInput()
    {
        if (shiftInput && moveAmount > 0.5f)
            playerMovement.isRunning = true;
        else
            playerMovement.isRunning = false;
    }




}
