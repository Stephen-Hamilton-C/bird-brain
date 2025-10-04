using UnityEngine;

public class SecondStageSpawners : MonoBehaviour
{
    private ArrowSpawner[] _arrowSpawners;
    
    void Start()
    {
        _arrowSpawners = GetComponentsInChildren<ArrowSpawner>();
    }

    public void Activate()
    {
        foreach (var arrowSpawner in _arrowSpawners)
        {
            arrowSpawner.Collider.enabled = true;
        }
    }
}
