using System;
using UnityEngine;

public class CircleCrouch : MonoBehaviour
{
    [SerializeField] private Vector3 _crouchScale;
    [SerializeField] private Vector3 _crouchPosition;

    private Vector3 _standScale;
    private Vector3 _standPosition;

    private void Start()
    {
        _standScale = transform.localScale;
        _standPosition = transform.localPosition;
    }

    public void Crouch(bool isCrouching)
    {
        transform.localScale = isCrouching ? _crouchScale : _standScale;
        transform.localPosition = isCrouching ? _crouchPosition : _standPosition;
    }
}
