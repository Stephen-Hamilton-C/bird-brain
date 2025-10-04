using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _minimumY = -11;
    private AudioSource _audioSource;
    private CharacterController2D _controller;
    
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
}