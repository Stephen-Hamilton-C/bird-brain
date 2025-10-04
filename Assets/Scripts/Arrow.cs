using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    public float Speed;
    [SerializeField] private Transform _sprite;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.velocity = transform.right * Speed;
    }

    public void ArrowHit(Collision2D collision)
    {
        if (collision.collider.FindPlayer()) return;
        Destroy(gameObject);
    }
}
