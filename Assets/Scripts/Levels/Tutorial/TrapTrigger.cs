using UnityEngine;
using DG.Tweening;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _fakeGap;
    [SerializeField] private Transform _leftGround;
    [SerializeField] private Transform _rightGround;
    [SerializeField] private float _moveAmt = 15f;

    private bool _triggered;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_triggered) return;
        if (!other.FindPlayer()) return;
        
        _triggered = true;
        var leftGroundPos = _leftGround.position;
        leftGroundPos.x -= _moveAmt;
        var rightGroundPos = _rightGround.position;
        rightGroundPos.x += _moveAmt;
        
        _leftGround.DOMove(leftGroundPos, 1);
        _rightGround.DOMove(rightGroundPos, 1);
        _fakeGap.SetActive(false);
    }
}
