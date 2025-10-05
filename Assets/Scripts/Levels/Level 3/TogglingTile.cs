using UnityEngine;

[RequireComponent(typeof(KillBox))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class TogglingTile : MonoBehaviour
{
    [SerializeField] private Sprite _groundTile;
    [SerializeField] private Sprite _lavaTile;
    [SerializeField] private float _lavaPitch = 0.75f;
    [SerializeField] private float _groundPitch = 1f;
    [SerializeField] private float _pitchVariance = 0.1f;
    private KillBox _killBox;
    private SpriteRenderer _renderer;
    private AudioSource _audio;

    private void Start()
    {
        _killBox = GetComponent<KillBox>();
        _renderer = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
    }

    public void Toggle(Collider2D collider)
    {
        if (!collider.FindPlayer()) return;
        _killBox.enabled = !_killBox.enabled;
        _renderer.sprite = _killBox.enabled ? _lavaTile : _groundTile;
        var pitchVariance = Random.Range(-_pitchVariance, _pitchVariance);
        var pitch = _killBox.enabled ? _lavaPitch : _groundPitch;
        _audio.pitch = pitch + pitchVariance;
        _audio.Play();
    }
}
