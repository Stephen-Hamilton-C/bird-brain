using System;
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
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float _tolerance = 0.05f;

    private int _desiredPositionIdx;
    private Vector3 DesiredPosition => _positions[_desiredPositionIdx].position;
    private int DirectionInt => Direction ? 1 : -1;
    private Rigidbody2D _rb;
    private Rigidbody2D _playerRb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void SetNextPosition()
    {
        if (_loopType == LoopType.Linear)
        {
            _desiredPositionIdx = (_desiredPositionIdx + DirectionInt) % _positions.Length;
        }
        else if (_loopType == LoopType.PingPong)
        {
            _desiredPositionIdx += DirectionInt;
            if (_desiredPositionIdx >= _positions.Length - 1 || _desiredPositionIdx <= 0)
                Direction = !Direction;
        }

        _rb.velocity = (DesiredPosition - transform.position).normalized * Speed;
        
        if (_playerRb)
        {
            // _playerRb.GetComponent<CharacterController2D>().PlatformVelocity = new Vector2(_rb.velocity.x, 0);
        }
    }

    private void FixedUpdate()
    {
        if (_positions.Length == 0) return;
        
        if (Vector3.Distance(DesiredPosition, transform.position) <= _tolerance)
        {
            SetNextPosition();
        }
        
        _rb.velocity = (DesiredPosition - transform.position).normalized * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.FindPlayer();
        if(!player) return;

        // _playerRb = player.GetComponent<Rigidbody2D>();
        // _playerRb.GetComponent<CharacterController2D>().PlatformVelocity = new Vector2(_rb.velocity.x, 0);
        // player.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.FindPlayer();
        if(!player) return;

        // _playerRb.GetComponent<CharacterController2D>().PlatformVelocity = Vector2.zero;
        // _playerRb = null;
        // player.transform.SetParent(null);
    }
}
