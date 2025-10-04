using UnityEngine;

public class InspectorOnly : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject);
    }
}
