using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformDirector : MonoBehaviour
{
    public enum LoopType
    {
        Linear,
        PingPong,
    }
    
    public float Speed = 1;
    public bool Direction = true;
    public LoopType _loopType = LoopType.Linear;
    [SerializeField] private List<Transform> _positions = new();
    [SerializeField] private bool _includeCurrentPosition;
    [SerializeField] private float _tolerance = 0.05f;

    private int _desiredPositionIdx;
    private Vector3 DesiredPosition => _positions[_desiredPositionIdx].position;
    private int DirectionInt => Direction ? 1 : -1;
    private Rigidbody2D _rb;
    private Rigidbody2D _playerRb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_includeCurrentPosition)
        {
            var startPos = new GameObject(gameObject.name + "_startpos");
            startPos.transform.SetParent(null);
            startPos.transform.position = transform.position;
            _positions.Insert(0, startPos.transform);
        }
    }

    private void SetNextPosition()
    {
        if (_loopType == LoopType.Linear)
        {
            _desiredPositionIdx = (_desiredPositionIdx + DirectionInt) % _positions.Count;
        }
        else if (_loopType == LoopType.PingPong)
        {
            _desiredPositionIdx += DirectionInt;
            if (_desiredPositionIdx >= _positions.Count - 1 || _desiredPositionIdx <= 0)
                Direction = !Direction;
        }

        _rb.velocity = (DesiredPosition - transform.position).normalized * Speed;
    }

    private void FixedUpdate()
    {
        if (_positions.Count == 0) return;
        
        if (Vector3.Distance(DesiredPosition, transform.position) <= _tolerance)
        {
            SetNextPosition();
        }
        
        _rb.velocity = (DesiredPosition - transform.position).normalized * Speed;
    }
}
