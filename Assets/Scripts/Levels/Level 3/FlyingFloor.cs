using DG.Tweening;
using UnityEngine;

public class FlyingFloor : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _flyDuration;

    public void Fly()
    {
        transform.DOMove(_endPoint.position, _flyDuration);
    }
    
    
}
