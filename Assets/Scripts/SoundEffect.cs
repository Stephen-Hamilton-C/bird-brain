using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
    private bool _queueDestroy;
    private AudioSource _source;
    
    public void Play()
    {
        transform.parent = null;
        _source = GetComponent<AudioSource>();
        _source.Play();
        _queueDestroy = true;
    }

    private void Update()
    {
        if (!_queueDestroy) return;
        if (_source.isPlaying) return;
        Destroy(gameObject);
    }
}
