using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlatformInverter : MonoBehaviour
{
    [SerializeField] private Sprite _groundSprite;
    [SerializeField] private Sprite _lavaSprite;
    private KillBox _killBox;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _killBox = GetComponent<KillBox>();
        if (!_killBox)
        {
            _killBox = gameObject.AddComponent<KillBox>();
            _killBox.enabled = false;
        }
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Invert()
    {
        _killBox.enabled = !_killBox.enabled;
        _renderer.sprite = _killBox.enabled ? _lavaSprite : _groundSprite;
    }
}
