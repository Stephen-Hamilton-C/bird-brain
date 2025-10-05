using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class GunPickup : MonoBehaviour
{
    [SerializeField] private float _minimumY = -11;
    [SerializeField] private SoundEffect _soundEffect;
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private SpriteRenderer _renderer;

    public UnityEvent OnRespawn = new();

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        if (gameObject.CompareTag("GunRespawn"))
        {
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        var player = other.FindPlayer();
        if (!player) return;
        
        player.Gun.gameObject.SetActive(true);
        if (gameObject.CompareTag("GunRespawn"))
        {
            _soundEffect.GetComponent<AudioSource>().Play();
            Disable();
        }
        else
        {
            _soundEffect.Play();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_rb.position.y < _minimumY)
        {
            GameObject.FindGameObjectWithTag("GunRespawn").GetComponent<GunPickup>().Enable();
            OnRespawn?.Invoke();
            Destroy(gameObject);
        }
    }

    public void Disable()
    {
        _rb.Sleep();
        _collider.enabled = false;
        _renderer.enabled = false;
        enabled = false;
    }

    public void Enable()
    {
        _rb.WakeUp();
        _collider.enabled = true;
        _renderer.enabled = true;
        enabled = true;
    }
}
