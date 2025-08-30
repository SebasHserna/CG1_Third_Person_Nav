using UnityEngine;
using System;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _Agent;

    public event Action<float> OnSpeedChange;

    public void setDestination(Vector3 destination)
    {
        _Agent.destination = destination;
        
    }

    
    
  
    // Update is called once per frame
    void Update()
    {
        OnSpeedChange?.Invoke(Mathf.Clamp01(_Agent.velocity.magnitude / _Agent.speed));

    }
}
