using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement PlayerMovement;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        PlayerMovement = GetComponent<PlayerMovement>();

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
