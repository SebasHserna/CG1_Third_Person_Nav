using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{

    public event Action<Vector3> OnMouseClick;
    RaycastHit _HitInfo;
    public LayerMask _ClickLayerMask;



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out _HitInfo, 100, _ClickLayerMask))
            {
                OnMouseClick?.Invoke(_HitInfo.point);
                Debug.Log($"Selected Position is {_HitInfo.point}");
            }
        }
        
    }
}
