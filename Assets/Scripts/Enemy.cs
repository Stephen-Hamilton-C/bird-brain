using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _shootCooldown = 1f;
    [SerializeField] private ArrowSpawner _arrowSpawner;
    private float _shootTimer;
    private Player _player;

    public UnityEvent OnDie = new();

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        _shootTimer += Time.fixedDeltaTime;
        if (_shootTimer < _shootCooldown) return;
        _shootTimer = 0;

        var direction = (_player.transform.position - transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _arrowSpawner.transform.parent.localRotation = Quaternion.Euler(0, 0, angle);
        _arrowSpawner.Spawn();
    }

    private void OnDestroy()
    {
        OnDie?.Invoke();
    }
}
