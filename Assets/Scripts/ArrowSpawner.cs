using UnityEngine;
using UnityEngine.Serialization;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private float _speed;
    [FormerlySerializedAs("_collider")] public Collider2D Collider;

    public void Spawn()
    {
        var arrow = Instantiate(_arrowPrefab, transform.position, transform.rotation);
        arrow.GetComponent<Arrow>().Speed = _speed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.FindPlayer()) return;
        if(Collider)
            Collider.enabled = false;
        Spawn();
    }
}
