using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _thrownGunPrefab;
    [SerializeField] private SpriteRenderer _playerRenderer;
    private SpriteRenderer _renderer;
    private AudioSource _audio;
    private float _xPos;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        _xPos = transform.localPosition.x;
    }

    private void Update()
    {
        _renderer.flipX = _playerRenderer.flipX;
        _renderer.enabled = _playerRenderer.enabled;
        var newPos = transform.localPosition;
        newPos.x = _renderer.flipX ? -_xPos : _xPos;
        transform.localPosition = newPos;
        
        if (Input.GetButtonDown("Fire1"))
        {
            _audio.Play();
            var thrownGun = Instantiate(_thrownGunPrefab, null);
            thrownGun.transform.position = transform.position;
            thrownGun.GetComponent<ThrownGun>().Direction = _renderer.flipX ? -1 : 1;
            gameObject.SetActive(false);
        }
    }
}
