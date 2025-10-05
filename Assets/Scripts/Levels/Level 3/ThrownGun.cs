using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class ThrownGun : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _rotationSpeed = 360;
    [SerializeField] private GameObject _gunPickupPrefab;
    public int Direction = 1;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rb;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.rotation += _rotationSpeed * Direction * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_speed * Direction, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.FindPlayer()) return;
        if (other.isTrigger)
        {
            var killbox = other.GetComponent<KillBox>();
            if (!killbox) return;
            if (!killbox.enabled) return;
            SpawnPickup();
            return;
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            SpawnPickup();
        }
    }

    private void SpawnPickup()
    {
        Instantiate(_gunPickupPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
