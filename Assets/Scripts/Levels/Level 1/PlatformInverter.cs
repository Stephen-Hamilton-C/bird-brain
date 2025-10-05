using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlatformInverter : MonoBehaviour
{
    [SerializeField] private Sprite[] _groundSprites;
    [SerializeField] private Sprite[] _lavaSprites;
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    private KillBox _killBox;

    private void Start()
    {
        Debug.Assert(
            _groundSprites.Length == _lavaSprites.Length && _lavaSprites.Length == _spriteRenderers.Length,
            "Ground sprites, lava sprites, and sprite renderers must be the same length"
        );
        
        _killBox = GetComponent<KillBox>();
        if (!_killBox)
        {
            _killBox = gameObject.AddComponent<KillBox>();
            _killBox.enabled = false;
        }
    }

    public void Invert()
    {
        _killBox.enabled = !_killBox.enabled;
        for (var i = 0; i < _spriteRenderers.Length; i++)
        {
            _spriteRenderers[i].sprite = _killBox.enabled ? _lavaSprites[i] : _groundSprites[i];
        }
    }
}
