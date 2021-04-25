using UnityEngine;

public class TridentAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetHeight(float height)
    {
        var tempSize = spriteRenderer.size;
        tempSize.y = height;
        spriteRenderer.size = tempSize;
    }
}