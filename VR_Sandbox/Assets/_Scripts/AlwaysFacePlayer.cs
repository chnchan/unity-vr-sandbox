/*
    Purpose:
            Keeps target object facing player at all time (intended for UI)
    How to use: 
            1. Put script on target object or manually set 'Target reference.
*/

using UnityEngine;

public class AlwaysFacePlayer : MonoBehaviour
{
    [SerializeField]
    private Camera PlayerCamera = null;
    [SerializeField]
    private Transform Target = null;


    /// <summary>
    /// Sets defaults if not set.
    /// </summary>
    private void Awake()
    {
        if (!Target) Target = this.transform;
        if (!PlayerCamera) PlayerCamera = Camera.main;
    }


    /// <summary>
    /// Keeps target object facing player
    /// </summary>
    private void LateUpdate()
    {
        Target.LookAt(PlayerCamera.transform.position);
    }
}
