using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _movementSpeed = "MovementSpeed";

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_movementSpeed, speed);
    }







}
