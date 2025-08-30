using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement PlayerMovement;
    Animator animator;

    public bool isInteracting;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        PlayerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        inputManager.HaandleAllInputs();
    }

    private void FixedUpdate()
    {
        PlayerMovement.HandleAllMovement();


    }

    private void LateUpdate()
    {
        isInteracting = animator.GetBool("isInteracting");
    }

}
