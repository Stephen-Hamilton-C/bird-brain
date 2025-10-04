using UnityEngine;

public class CircleCrouch : MonoBehaviour
{
    public void Crouch(bool isCrouching)
    {
        var newScale = transform.localScale;
        newScale.y = isCrouching ? 0.75f : 1.25f;
        var newPos = transform.localPosition;
        newPos.y = isCrouching ? -0.25f : 0;
        
        transform.localScale = newScale;
        transform.localPosition = newPos;
    }
}
