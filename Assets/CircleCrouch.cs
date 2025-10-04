using UnityEngine;

public class CircleCrouch : MonoBehaviour
{
    public void Crouch(bool isCrouching)
    {
        var newScale = transform.localScale;
        newScale.y = isCrouching ? 0.5f : 1;
        var newPos = transform.localPosition;
        newPos.y = isCrouching ? -0.25f : 0;
        
        transform.localScale = newScale;
        transform.localPosition = newPos;
    }
}
