using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    private static readonly int Walking = Animator.StringToHash("Walking");
    [SerializeField] private float _minimumY = -11;
    [SerializeField] private Animator _anim;
    private AudioSource _audioSource;
    private CharacterController2D _controller;
    private SpringJoint2D _spring;
    
    public bool HasKey
    {
        get => _hasKey;
        set {
            _hasKey = value;
            OnHasKeyChanged.Invoke(_hasKey);
        }
    }
    private bool _hasKey;
    
    public UnityEvent<bool> OnHasKeyChanged = new();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if (transform.position.y < _minimumY)
        {
            Kill();
        }
        
        if(Input.GetButtonDown("Jump"))
            DestroySpring();

        var isWalking = Mathf.Abs(_controller.Velocity.x) > 0.1f;
        _anim.SetBool(Walking, isWalking);

        if (_controller.Velocity != Vector3.zero && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        else if(_controller.Velocity == Vector3.zero && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }

    public void Kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private static Vector2 GetBestContactPoint(ContactPoint2D[] contacts)
    {
        foreach (var contact in contacts)
        {
            if (contact.normal.y >= 0.1)
            {
                return contact.point;
            }
        }

        return Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Platform")) return;
        DestroySpring();
        var contactPoint = GetBestContactPoint(other.contacts);
        if (contactPoint == Vector2.zero) return;
        
        _spring = gameObject.AddComponent<SpringJoint2D>();
        _spring.enableCollision = true;
        _spring.autoConfigureConnectedAnchor = false;
        _spring.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
        _spring.connectedAnchor = transform.InverseTransformPoint(contactPoint);
        _spring.distance = 0f;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (_spring)
        {
            var contactPoint = GetBestContactPoint(other.contacts);
            if (contactPoint == Vector2.zero) return;
            _spring.anchor = new Vector2(0, 1);
            _spring.connectedAnchor = other.transform.InverseTransformPoint(contactPoint) + new Vector3(0, -1, 0);
            _spring.distance = 0f;
        }
    }

    public void OnExternalTriggerExit2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Platform")) return;
        DestroySpring();
    }

    private void DestroySpring()
    {
        if (_spring)
        {
            Destroy(_spring);
            _spring = null;
        }
    }
    
    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if(!other.gameObject.CompareTag("Platform")) return;
    //     DestroySpring();
    // }
}