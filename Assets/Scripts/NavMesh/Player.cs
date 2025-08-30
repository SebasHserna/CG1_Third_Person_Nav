using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _input;
    [SerializeField]
    private AgentMovement _movement;

    [SerializeField]
    private AgentAnimation _agentAnimation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movement.OnSpeedChange += _agentAnimation.SetSpeed;
        _input.OnMouseClick += _movement.setDestination;
        _agentAnimation.SetSpeed(0);
    }

}
